using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Zdarzenie : IComparable<Zdarzenie>
    {
        public Wykaz wykaz { get; private set; }
        public OpisStanu opis { get; private set; }
        public DateTime data { get; private set; };
        //public DateTime czasWypozyczenia { get; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opis)
        {
            this.wykaz = wykaz;
            this.opis = opis;
            this.data = DateTime.Now;
            //if(czasWypozyczenia == null)
            //{
            //    this.czasWypozyczenia = DateTime.Now.AddDays(30);
            //}
            //else
            //{
            //    this.czasWypozyczenia = czasWypozyczenia;
            //}
        }

        public Zdarzenie(Wykaz wykaz, OpisStanu opis, DateTime date)
        {
            this.wykaz = wykaz;
            this.opis = opis;
            this.data = date;
        }

        public override bool Equals(object obj)
        {
            Zdarzenie zdarzenie = obj as Zdarzenie;
            return zdarzenie != null &&
                   EqualityComparer<Wykaz>.Default.Equals(wykaz, zdarzenie.wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(opis, zdarzenie.opis) &&
                   data.Date == zdarzenie.data.Date;
                   //dataWypozyczenia.Date == zdarzenie.dataWypozyczenia.Date &&
                   //czasWypozyczenia.Date == zdarzenie.czasWypozyczenia.Date;
        }

        public int CompareTo(Zdarzenie other)
        {
            if (data > other.data) return 1;
            else if (data == other.data) return 0;
            else return -1;
        }
    }
}
