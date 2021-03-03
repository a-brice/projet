using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using System.IO;


namespace WpfInfoFonda
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        

        

        /// <summary>
        /// Cette fonction permets de creer aléatoirement des liens entre des maillons 
        /// </summary>
        /// <param name="nbLien">Nombre de lein que l'utilisateur souhaite avoir</param>
        /// <param name="nbMaillon">Nombre de maillons disponible</param>
        /// <returns>Le tableau de lien est retourné complété avec des liens (sans doublons) utilisable</returns>
        static Lien[] createLink(int nbLien, int nbMaillon)
        {
            Lien[] link = new Lien[nbLien];
            int i = 0;
            if (nbLien > 0 && nbMaillon > 0)
                do
                {
                    Random r = new Random();
                    int id1 = r.Next(1, nbMaillon + 1), id2 = r.Next(1, nbMaillon + 1);
                    if (id1 != id2)
                    {
                        bool condition = true;
                        for (int j = 0; j < i; j++)
                        {
                            if ((link[j].A.Id == id1 && link[j].B.Id == id2) || (link[j].B.Id == id1 && link[j].A.Id == id2)) condition = false;
                        }
                        Maillon a = new Maillon(id1);
                        Maillon b = new Maillon(id2);
                        Lien l = new Lien(a, b);
                        link[i] = l;
                        if (condition) i++;
                    }
                } while (i < nbLien);

            return link;
        }

        static string afficheLink(Lien[] link) // Affiche les lien du tableau
        {
            string l = "";
            if (link != null)
            {
                foreach (Lien item in link)
                {
                    l+=(item) + "\n";
                }
            }
            return l;
        }

        

        public Lien[] saveLink()
        {
            Lien[] lienUtilisateur = null;
            if(textboxlink.Text != null && textboxlink.Text .Length > 2 && !textboxlink.Text.Contains("<=>"))
            {
                string[] sep = { ";", Environment.NewLine };
                string[] link = textboxlink.Text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                List<Lien> lstlien = new List<Lien>();
                Array.ForEach(link, x => {
                    int.TryParse(x.Split('-')[0], out int m1);
                    int.TryParse(x.Split('-')[1], out int m2);
                    if(m1 > 0 && m2 > 0)
                    {
                        Lien l = new Lien(new Maillon(m1), new Maillon(m2));
                        lstlien.Add(l);
                    }
                } );
                lienUtilisateur = lstlien.ToArray();
            }
            return lienUtilisateur;
        }
    
        public int NbMaxLien(int nbmaillon)     // methode recursive calculant le nombre max de lien en fonction du nombre de maillons
        {
            if (nbmaillon <= 0) return 0;
            else return (nbmaillon - 1) + NbMaxLien(--nbmaillon);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Entrée utilisateur 
            int nbMaillon = 0,
                nbLien = 0;
            string Lientextbox = textboxlink.Text;
            bool radioComplexite = radio2.IsChecked.Value == true,
                 checkboxLienAlea = checkbox1.IsChecked == true;


            

            int radiocolor = radio3.IsChecked == true ? 1 : radio4.IsChecked == true ? 2 : radio5.IsChecked == true ? 3 : radio6.IsChecked == true ? 4 : 0;

            if (txtbox1 != null && txtbox2 != null && int.TryParse(txtbox1.Text, out nbMaillon) 
                && int.TryParse(txtbox2.Text, out nbLien) && nbMaillon > 0 && nbLien > 0)
            {
                int abc = NbMaxLien(nbMaillon);
                if (nbLien > NbMaxLien(nbMaillon))
                {
                    System.Windows.MessageBox.Show("Le nombre de lien est trop grand" +
                        " par rapport au nombre de de Maillons, les liens ne doivent pas etre en doublons !");

                }
                else     // Complexité exponentielle 
                {
                    Lien[] link;

                    if (checkboxLienAlea)
                    {
                        link = createLink(nbLien, nbMaillon);
                    }
                    else
                    {
                        link = saveLink();
                    }
                    blockaffiche.Text = afficheLink(link);

                    string[] tabCouleur = null;

                    switch (radiocolor)
                    {
                        case 1: tabCouleur = new string[] { "Rouge", "Violet" }; break;
                        case 2: tabCouleur = new string[] { "Rouge", "Violet", "Vert" }; break;
                        case 3: tabCouleur = new string[] { "Rouge", "Violet", "Vert", "Bleue" }; break;
                        case 4: tabCouleur = new string[] { "Rouge", "Violet", "Vert", "Bleue", "Orange" }; break;
                        default:
                            break;
                    }

                    DateTime tempsdebut = DateTime.Now;

                    Maillon.Cpt = 0;
                    if (radioComplexite)
                    {
                        int solutionAafficher = 1; // On affichera la premiere solution
                        Dictionary<int, List<Maillon>> dico = Expo.Solveur(nbMaillon, tabCouleur, link);
                        
                        Search s = new Search(dico, link,tempsdebut, solutionAafficher);
                        s.Show();

                    }
                    else    // Complexité Polynomiale
                    {
                        List<Maillon> lstSolutionPolynomial = Poly.Solveur(nbMaillon, tabCouleur, link);
                        Dictionary<int, List<Maillon>> dico = new Dictionary<int, List<Maillon>>();
                        dico.Add(1, lstSolutionPolynomial);
                        Search s = new Search(dico, link,tempsdebut, 1 /* =  1 seul solution a afficher */ );
                        s.Show();
                    } 
                }
               
                
            }
            
        }

        private void Checkbox1_Click(object sender, RoutedEventArgs e)
        {
            if(stackpanellien != null)
            {
                if(stackpanellien.Visibility == Visibility.Collapsed)
                {
                    stackpanellien.Visibility = Visibility.Visible;
                    blockaffiche.Visibility = Visibility.Collapsed;
                }
                else
                {
                    stackpanellien.Visibility = Visibility.Collapsed;
                    blockaffiche.Visibility = Visibility.Visible;

                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Verificateur().Show();
        }
    }
}
