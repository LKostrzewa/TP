using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Wykaz
    {
        public int id { get; private set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }

        public Wykaz(int id, string imie, string nazwisko)
        {
            this.id = id;
            this.imie = imie;
            this.nazwisko = nazwisko;
        }

        public override bool Equals(object obj)
        {
            Wykaz wykaz = obj as Wykaz;
            return wykaz != null &&
                   id == wykaz.id &&
                   imie == wykaz.imie &&
                   nazwisko == wykaz.nazwisko;
        }

        public override string ToString()
        {
            return "Klient: " + imie + " " + nazwisko + " - ID= " + id ;
        }
    }
}
