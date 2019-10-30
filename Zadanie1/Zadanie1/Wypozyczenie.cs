using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(int id, Wykaz wykaz, OpisStanu opis) : base(id, wykaz, opis) { }
    }
}
