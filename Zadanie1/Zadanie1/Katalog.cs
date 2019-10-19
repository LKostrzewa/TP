using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Katalog
    {
        private int id;
        private string tytul;
        private string gatunek;
        private int ilosc_str;

        public Katalog(int id, string tytul, string gatunek, int ilosc_str)
        {
            this.id = id;
            this.tytul = tytul;
            this.gatunek = gatunek;
            this.ilosc_str = ilosc_str;
        }
    }
}
