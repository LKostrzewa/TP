using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Zdarzenie
    {
        public Wykaz wykaz { get; private set; }
        public OpisStanu opis { get; private set; }
        private DateTime dataWypozyczenia;
        public DateTime czasWypozyczenia { get; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opis, DateTime czasWypozyczenia)
        {
            this.wykaz = wykaz;
            this.opis = opis;
            this.dataWypozyczenia = DateTime.Now;
            if(czasWypozyczenia == null)
            {
                this.czasWypozyczenia = DateTime.Now.AddDays(30);
            }
            else
            {
                this.czasWypozyczenia = czasWypozyczenia;
            }
        }

        public override bool Equals(object obj)
        {
            Zdarzenie zdarzenie = obj as Zdarzenie;
            return zdarzenie != null &&
                   EqualityComparer<Wykaz>.Default.Equals(wykaz, zdarzenie.wykaz) &&
                   EqualityComparer<OpisStanu>.Default.Equals(opis, zdarzenie.opis) &&
                   dataWypozyczenia.Date == zdarzenie.dataWypozyczenia.Date &&
                   czasWypozyczenia.Date == zdarzenie.czasWypozyczenia.Date;
        }
    }
}
