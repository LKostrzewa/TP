using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class OpisStanu
    {
        public Katalog katalog { get; private set; }
        private DateTime dataZakupu;
        private int ilosc;
        private int cena;
        private int podatek;

        public OpisStanu(Katalog katalog, DateTime dataZakupu, int ilosc, int cena, int podatek)
        {
            this.katalog = katalog;
            this.dataZakupu = dataZakupu;
            this.ilosc = ilosc;
            this.cena = cena;
            this.podatek = podatek;
        }

        public override bool Equals(object obj)
        {
            OpisStanu stanu = obj as OpisStanu;
            return stanu != null &&
                   EqualityComparer<Katalog>.Default.Equals(katalog, stanu.katalog) &&
                   dataZakupu == stanu.dataZakupu &&
                   ilosc == stanu.ilosc &&
                   cena == stanu.cena &&
                   podatek == stanu.podatek;
        }
    }
}
