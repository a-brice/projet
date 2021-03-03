using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInfoFonda
{
    public class Maillon
    {
        string couleur;
        int id;
        static int cpt = 0;

        public Maillon(int id)
        {
            couleur = null;
            this.id = id;
        }
        public Maillon(string c)
        {
            couleur = c;
            id = ++cpt;
        }
        public Maillon()
        {
            couleur = null;
            id = ++cpt;
        }

        

        public string Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public static int Cpt
        {
            get { return Maillon.cpt; }
            set { Maillon.cpt = value; }
        }

        public override string ToString()
        {
            return "M°" + id + " => " + couleur;
        }

        public static bool operator ==(Maillon a, Maillon b)
        {
            if (a is null || b is null) return false;
            if(a.id == b.id) { return true; }
            return false;
        }
        public static bool operator !=(Maillon a, Maillon b)
        {
            if (a is null || b is null) return false;
            if(a.id == b.id) { return false; }
            return true;
        }
    }
}
