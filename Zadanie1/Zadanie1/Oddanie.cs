using System;
namespace Zadanie1
{
    public class Oddanie : Zdarzenie
    {
        public Oddanie(int id, Wykaz wykaz, OpisStanu opis, DateTime time) : base(id, wykaz, opis, time) { }
    }
}
