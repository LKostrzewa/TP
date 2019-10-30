using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class Zdarzenie : IComparable<Zdarzenie>
    {
        public int id { get; private set; }
        public Wykaz wykaz { get; private set; }
        public OpisStanu opis { get; private set; }
        public DateTime data { get; private set; }

        public Zdarzenie(int id, Wykaz wykaz, OpisStanu opis)
        {
            this.id = id;
            this.wykaz = wykaz;
            this.opis = opis;
            this.data = DateTime.Now;
        }

        public Zdarzenie(int id, Wykaz wykaz, OpisStanu opis, DateTime date)
        {
            this.id = id;
            this.wykaz = wykaz;
            this.opis = opis;
            this.data = date;
        }

        public override bool Equals(object obj)
        {
            Zdarzenie zdarzenie = obj as Zdarzenie;
            return zdarzenie != null &&
                   id == zdarzenie.id &&
                   EqualityComparer<Wykaz>.Default.Equals(wykaz, zdarzenie.wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(opis, zdarzenie.opis) &&
                   data.Date == zdarzenie.data.Date;
        }

        public int CompareTo(Zdarzenie other)
        {
            if (data > other.data) return 1;
            else if (data == other.data) return 0;
            else return -1;
        }

        public override string ToString()
        {
            return "Zdarzenie pomiędzy " + wykaz + "\na\n" + opis;
        }
    }
}
