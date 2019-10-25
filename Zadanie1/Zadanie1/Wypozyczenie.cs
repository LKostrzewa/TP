using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Wykaz wykaz, OpisStanu opis) : base(wykaz, opis) { }
    }
}
