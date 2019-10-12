using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Wykaz
    {
        private string id;
        private string imie;
        private string nazwisko;

        public Wykaz(string id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }
    }
}
