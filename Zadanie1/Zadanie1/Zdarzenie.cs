using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class Zdarzenie
    {
        private Wykaz wykaz;
        private OpisStanu opis;
        private DateTime dataWypozyczenia;
        private DateTime czasWypozyczenia;

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
    }
}
