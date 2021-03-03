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
    public class Expo
    {
        /// <summary>
        /// Cette fonction permettra de transformer les nombres transmis en parametre en nombre "binaire ou ternaire" ou de base supérieur en chaine de caractere afin 
        /// d'avoir toute les possibilités de couleur que peuvent prendre les maillons par la suite 
        /// </summary>
        /// <param name="dec">Nombre Décimal à transformer en base "Base"</param>
        /// <param name="nbBit">Nombre de bit sur lesquel seront stocké le résultat (ex: (base 10)3 => (base 2)11 => (base 2)00011 )</param>
        /// <param name="Base">(ex: 2, 3 ou plus) Base 2 signifie qu'il y'aura 2 couleur </param>
        /// <returns></returns>
        static string ConvertirEnBit(int dec, int nbBit, int Base)
        {
            int reste;
            string res = "";
            while (dec > 0)
            {
                reste = dec % Base;
                dec = dec / Base;
                res = reste + res;
            }
            while (res.Length < nbBit)
            {
                res = "0" + res;
            }
            return res;
        }
        /// <summary>
        /// Création d'une fonction capable de calculer et d'enregistrer l'ensemble des combinaisons de couleur pouvant etre prise avec N maillon 
        /// (ex : Pour N = 2 Maillons, la fonction retourne la matrice 
        /// (couleur1,couleur1)
        /// (couleur1,couleur2)
        /// (couleur2,couleur1)
        /// (couleur2,couleur2)
        /// </summary>
        /// <param name="tabCouleur">tableau de couleur dont la taille varie en fonction du nombre de couleur entrer par l'utilisateur</param>
        /// <param name="nbMaillon">Nombre de couleurs entrer par l'utilisateur</param>
        /// <returns></returns>
        static Maillon[,] creation(string[] tabCouleur, int nbMaillon)
        {

            List<Maillon> lst = new List<Maillon>();
            int nbCouleur = tabCouleur.Length;
            Maillon[,] tot;


            if (nbCouleur != 0 && nbMaillon != 0)
            {
                for (int i = 0; i < nbMaillon; i++)
                {
                    Maillon m = new Maillon();
                    lst.Add(m);     // Attribution des N Maillons avec des id s'incrémentant et sans couleur 
                }


                int ligne = (int)Math.Pow(nbCouleur, nbMaillon);
                tot = new Maillon[ligne, nbMaillon];

                for (int i = 0; i < tot.GetLength(0); i++)
                {
                    string bit = ConvertirEnBit(i, nbMaillon, nbCouleur);
                    for (int j = 0; j < tot.GetLength(1); j++)
                    {
                        Maillon m = new Maillon();
                        m.Id = lst[j].Id;
                        m.Couleur = tabCouleur[Convert.ToInt32(bit[j].ToString())];
                        tot[i, j] = m;

                    }
                }
            }
            else tot = null;

            return tot;
        }
        /// <summary>
        /// Retourne un dictionnaire avec comme value toute les list de combinaisons-solution 
        /// </summary>
        /// <param name="lst">liste des ligne de la matrice pour lesquelles la combinaison des maillons repondent positif au test avec les liens</param>
        /// <param name="total">Matrice (totale) de toute les combinaisons pouvant etre prises</param>
        /// <returns></returns>
        static Dictionary<int, List<Maillon>> DicoSolution(List<int> lst, Maillon[,] total)
        {
            Dictionary<int, List<Maillon>> dic = new Dictionary<int, List<Maillon>>();
            if (lst != null && total != null)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    List<Maillon> lstM = new List<Maillon>();
                    for (int j = 0; j < total.GetLength(1); j++)
                    {
                        lstM.Add(total[lst[i], j]);
                    }
                    dic.Add(i + 1, lstM);
                }
            }
            return dic;
        }

        static List<int> LigneMatriceTotalSolution(Maillon[,] total, Lien[] link)
        {
            List<int> lstColsSolution = new List<int>();

            if (total != null)
            {

                List<int> lstColsFasle = new List<int>();       // ligne fausse de la matrice total
                if (total != null && link != null)
                {
                    for (int i = 0; i < link.Length; i++)   
                    {
                        int id1 = link[i].A.Id, id2 = link[i].B.Id; // Recupérer l'id des maillons d'un lien
                        for (int j = 0; j < total.GetLength(0); j++)
                        {
                            if (total.GetLength(1) > id1 - 1 && total.GetLength(1) > id2 - 1 && total[j, id1 - 1].Couleur == total[j, id2 - 1].Couleur) // On stocke toute les lignes fauses (qui ne peuvent pas etre solution) dans lstColsFalse
                            {
                                if (!lstColsFasle.Contains(j)) // Eviter les doublons 
                                    lstColsFasle.Add(j);
                            }
                        }
                    }
                }
                lstColsFasle.Sort();
                for (int i = 1; i < total.GetLength(0); i++)
                {
                    if (!lstColsFasle.Contains(i)) lstColsSolution.Add(i);
                }
            }
            return lstColsSolution;

        }

        static void affichemat(Maillon[,] mat) // Affiche les maillons dans fichier csv dans le Bin Debug
        {
            try
            {
                StreamWriter sw = new StreamWriter("fich.csv", false);
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (j == mat.GetLength(1) - 1) sw.WriteLine(mat[i, j].Couleur); // Affiche juste les couleurs dans le fichier car il seront rangé par ID
                        else sw.Write(mat[i, j].Couleur + ";");
                    }
                }

                System.Threading.Thread.Sleep(500);
                sw.Close();
            }
            catch (Exception e)
            {

                System.Windows.MessageBox.Show(e.Message);
            }

        }

        public static Dictionary<int, List<Maillon>> Solveur(int nbMaillon,string[] tabCouleur,Lien[] link)
        {


            Maillon[,] total = creation(tabCouleur, nbMaillon);     // Toutes les possibilités que peuvent prendre les maillons || Systeme binaire 
            affichemat(total);  // CSV


            List<int> lstColsSolution = LigneMatriceTotalSolution(total, link);      // Le numéro des lignes des combinaisons-solutions au probleme y sont indiqués
                                                                                     //Console.WriteLine("Nombre de Solutions : {0}", lstColsSolution.Count);
                                                                                     //if (lstColsSolution.Count > 0)
                                                                                     //lstColsSolution.ForEach(x => Console.Write(x + " "));
            Dictionary<int, List<Maillon>> dico = DicoSolution(lstColsSolution, total); // On stocke toute les solutions dans le dictionnaire avec la key(int) qui represente 
                                                                                        // le numéro de la solution et a pour value une combinaison de maillon solution

            return dico;
        }



    }
}
