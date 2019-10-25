using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class OpisStanu
    {
        public int id { get; private set; }
        public Katalog katalog { get; set; }
        public DateTime dataZakupu { get; set; }
        //private int ilosc;
        //private float cena;
        //private float podatek;

        public OpisStanu(int id, Katalog katalog, DateTime dataZakupu)
        {
            this.id = id;
            this.katalog = katalog;
            this.dataZakupu = dataZakupu;
            //this.ilosc = ilosc;
            //this.cena = cena;
            //this.podatek = podatek;
        }

        public override bool Equals(object obj)
        {
            OpisStanu stanu = obj as OpisStanu;
            return stanu != null &&
                   EqualityComparer<Katalog>.Default.Equals(katalog, stanu.katalog) &&
                   dataZakupu == stanu.dataZakupu;
        }
    }
}
