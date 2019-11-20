using System;

namespace Zadanie1
{
    public class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(int id, Wykaz wykaz, OpisStanu opis, DateTime time) : base(id, wykaz, opis, time) { }
    }
}
