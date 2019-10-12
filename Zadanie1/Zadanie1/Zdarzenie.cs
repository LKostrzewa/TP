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

        public Zdarzenie(Wykaz wykaz, OpisStanu opis)
        {
            this.wykaz = wykaz;
            this.opis = opis;
        }
    }
}
