using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consolepers
{
    class correct
    {/*using System;
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
            Console.WriteLine("ecrire la dimension de la matrice :");
            int dim = Convert.ToInt32(Console.ReadLine());



            Console.WriteLine("ecrire la matrice :");
            List<string> ligned = new List<string>();
            string chaine = "";
            for (int i = 0; i < dim; i++)
            {
                ligned.Add(Console.ReadLine() + " ");

            }

            for (int i = 0; i < dim; i++)
            {
                chaine += ligned[i];
            }

            string[] temp = chaine.Split(' ');

            List<List<double>> mat = new List<List<double>>();      // matrice A
            List<List<double>> matinv = new List<List<double>>();   // matrice I
            int k = 0;


            while (k < dim * dim - 1)
            {
                List<double> l = new List<double>();
                for (int i = 0; i < dim; i++)
                {

                    l.Add(Convert.ToInt32(temp[k]));
                    k++;
                }

                mat.Add(l);

            }
            Console.WriteLine();

            for (int i = 0; i < dim; i++)
            {
                List<double> lst = new List<double>();
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
                List<double> col1 = mat[0 + g];
                List<double> col1inv = matinv[0 + g];

                double v0 = col1[0 + g];

                for (int i = 1 + g; i < dim; i++)
                {
                    List<double> coli = mat[i];
                    List<double> coliinv = matinv[i];

                    double v1 = coli[0 + g];
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
            }

           



        }

        static void affichagemat(List<List<double>> mat, List<List<double>> matinv)
        {
            int inc = 0;
            foreach (List<double> item in matinv)
            {
                List<double> lst = mat[inc];
                foreach (double items in item)
                {
                    Console.Write(arrondi(items) + "\t");
                }
                Console.Write(" |");
                lst.ForEach(x => Console.Write("\t" + arrondi(x)));
                Console.WriteLine();
                inc++;
            }

        }

        static double arrondi(double nb)
        {
            int inc = 0;
            string s = nb.ToString();
            for (int i = s.Length - 1; i > 0; i--)
            {
                if (s[i] == ',' && inc > 3) s = s.Remove(i + 3);
                inc++;
            }
            return double.Parse(s);
        }
        static void Main(string[] args)
        {
            
            mat();
            Console.ReadKey();
        }
    }
}
*/
    }
}
