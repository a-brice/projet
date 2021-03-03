using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfInfoFonda
{
    public class Lien
    {
        Maillon a;
        Maillon b;

        public Lien(Maillon a, Maillon b)
        {
            this.a = a;
            this.b = b;
        }

        public Maillon A
        {
            get { return a; }
            set { a = value; }
        }
        public Maillon B
        {
            get { return b; }
            set { b = value; }
        }

        public override string ToString()
        {
            return "Lien :  M° " + a.Id + " <=> M° " + b.Id;
        }
    }
}
