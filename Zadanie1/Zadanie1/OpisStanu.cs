using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class OpisStanu
    {
        private Katalog katalog;
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
    }
}
