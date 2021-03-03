using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolepers
{
    class Program
    {
        static void mat()
        {
            
            int dim = 0;
            do
            {
                Console.WriteLine("Entrer la dimension de la matrice :");
            } while (!int.TryParse(Console.ReadLine(), out dim) || dim == 0 || dim == 1 );
            Console.WriteLine("\n");



            Console.WriteLine("Ecrire la matrice à inverser :");
            List<string> ligned = new List<string>();
            string chaine = "";
            for (int i = 0; i < dim; i++)
            {
                Console.Write("\t\t\t\t\t\t");
                ligned.Add(Console.ReadLine() + " ");

            }

            for (int i = 0; i < dim; i++)
            {
                chaine += ligned[i].Replace(".", ",");
            }

            string[] temp = chaine.Split(new char[]{' ','/','*'}, StringSplitOptions.RemoveEmptyEntries);

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


            Console.WriteLine();

            affichagemat(matinv, mat);
            Console.WriteLine();
            for (int g = 0; g < dim; g++)
            {
                List<decimal> col1 = mat[0 + g];
                List<decimal> col1inv = matinv[0 + g];

                decimal v0 = col1[0 + g];
                for (int j = 0; j < dim; j++)
                {
                    col1[j] = col1[j]/v0;
                    col1inv[j] = col1inv[j]/v0;
                }
                affichagemat(matinv, mat);


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
                affichagemat(matinv, mat);
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);
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
                affichagemat(matinv, mat);
                Console.WriteLine();
                System.Threading.Thread.Sleep(1000);

            }




        }

        static void affichagemat(List<List<decimal>> mat, List<List<decimal>> matinv)
        {
            int inc = 0;
            foreach (List<decimal> item in matinv)
            {
                List<decimal> lst = mat[inc];
                foreach (decimal items in item)
                {
                    Console.Write(arrondi(items) + "\t");
                }
                Console.Write(" |");
                lst.ForEach(x => Console.Write("\t" + arrondi(x)));
                Console.WriteLine();
                
                inc++;
            }
            Console.WriteLine();

        }

        static decimal arrondi(decimal nb)
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
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            mat();
            Console.ReadKey();
        }
    }
}