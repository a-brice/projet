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
using System.IO;

namespace WpfApppers
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
        public int inc = 0;

 

        public void mat(string chaine)
        {

            string[] temp = chaine.Split(new char[] { ' ', '/', '*', ';' }, StringSplitOptions.RemoveEmptyEntries);
            int dim = Convert.ToInt32(Math.Sqrt(temp.Length));
            List<List<decimal>> mat = new List<List<decimal>>();      // matrice A
            List<List<decimal>> matinv = new List<List<decimal>>();   // matrice I
            int k = 0;


            while (k < dim * dim - 1)
            {
                List<decimal> l = new List<decimal>();
                for (int i = 0; i < dim; i++)
                {

                    l.Add(Convert.ToDecimal(temp[k]));
                    k++;
                }

                mat.Add(l);

            }
            Console.WriteLine();

            for (int i = 0; i < dim; i++)
            {
                List<decimal> lst = new List<decimal>();
                for (int j = 0; j < dim; j++)
                {
                    if (i == j) lst.Add(1);
                    else lst.Add(0);
                }
                matinv.Add(lst);
            }
            // on a la matrice identite I(inv) et la matrice A(mat)



            affichagemat(matinv, mat, dim, false);
            affichagemat2(matinv, mat, dim);

            try
            {
                for (int g = 0; g < dim; g++)
                {
                    List<decimal> col1 = mat[0 + g];
                    List<decimal> col1inv = matinv[0 + g];

                    decimal v0 = col1[0 + g];
                    for (int j = 0; j < dim; j++)
                    {
                        col1[j] = col1[j] / v0;
                        col1inv[j] = col1inv[j] / v0;
                    }
                    affichagemat(matinv, mat, dim, false);
                    affichagemat2(matinv, mat, dim);



                    for (int i = 1 + g; i < dim; i++)
                    {
                        List<decimal> coli = mat[i];
                        List<decimal> coliinv = matinv[i];

                        decimal v1 = coli[0 + g];
                        for (int j = 0; j < dim; j++)
                        {
                            coli[j] = coli[j] - v1 * col1[j];
                            coliinv[j] = coliinv[j] - v1 * col1inv[j];
                        }
                        mat[i] = coli;
                        matinv[i] = coliinv;
                    }
                    affichagemat(matinv, mat, dim, false);
                    affichagemat2(matinv, mat, dim);

                }
                for (int g = dim - 1; g > 0; g--)
                {
                    List<decimal> col1 = mat[0 + g];
                    List<decimal> col1inv = matinv[0 + g];

                    decimal v0 = col1[0 + g];

                    for (int i = g - 1; i >= 0; i--)
                    {
                        List<decimal> coli = mat[i];
                        List<decimal> coliinv = matinv[i];

                        decimal v1 = coli[0 + g];
                        for (int j = 0; j < dim; j++)
                        {
                            coli[j] = coli[j] - (v1 / v0) * col1[j];
                            coliinv[j] = coliinv[j] - (v1 / v0) * col1inv[j];
                        }
                        mat[i] = coli;
                        matinv[i] = coliinv;
                    }
                    affichagemat(matinv, mat, dim, false);
                    affichagemat2(matinv, mat, dim);


                }
                affichagemat(matinv, mat, dim, true);
                affichagemat2(matinv, mat, dim);

            }
            catch (Exception)
            {

                MessageBox.Show("Matrice A n'est pas inversible.");
            }
            

            



        }
        public string save= "", save2 = "";
        public void affichagemat( List<List<decimal>> matinv,List<List<decimal>> mat, int dim, bool dernier)
        {
            if (!dernier)
            {
                for (int i = 0; i < dim; i++)
                {
                    mat[i].ForEach(x => save += arrondi(x) + "\t");
                    save += "|\t";
                    matinv[i].ForEach(x => save += arrondi(x) + "\t");
                    save += "\n";

                }
                save += "\n";
            }
            else
            {
                for (int i = 0; i < dim; i++)
                {
                    
                    matinv[i].ForEach(x => save2 += arrondi(x) + "\t");
                    save2 += "\n";

                }
            }
            

        }
        public void affichagemat2(List<List<decimal>> matinv, List<List<decimal>> mat, int dim)
        {
            StreamWriter sr = new StreamWriter("justif.csv", true);
                for (int i = 0; i < dim; i++)
                {
                    mat[i].ForEach(x => sr.Write(x + ";"));
                sr.Write(";");
                    matinv[i].ForEach(x => sr.Write(x + ";"));
                sr.Write("\n");


                }
            sr.WriteLine("\n");
            sr.Close();

        }
        public decimal arrondi(decimal nb)
        {
            int inc = 0;
            string s = nb.ToString();
            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] == ',' && inc > 4) s = s.Remove(i + 4);
                inc++;
            }
            return decimal.Parse(s);
        }

        
        private void txt_select(object sender, RoutedEventArgs e)
        {
            if(inc == 1)
            {
                txtbox.Foreground = Brushes.Black;
                txtbox.Text = "";
            }
            inc++;
        }

        private void Bouton_Click(object sender, RoutedEventArgs e)
        {
            save = ""; save2 = "";
            StreamWriter sr = new StreamWriter("justif.csv", false);
            sr.Close();

            string contains = txtbox.Text.Replace("\r\n", " ").Replace(".", ",");
            try
            {
                mat(contains);

            }
            catch (Exception)
            {

                MessageBox.Show("Une erreur s'est produite ! Vérifier à ce que la matrice soit carré");
            }
            Window1 w = new Window1(save2,save);
            w.Show();
        }
    }
}
