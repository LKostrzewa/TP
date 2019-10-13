using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    internal class WypelnianieStalymi : IDataFiller
    {
        public void fill(DataContext context)
        {
            //O kurde co tu dać panie majster
            context.wykazy.Add(new Wykaz("1", "Adam", "Małysz"));
            context.wykazy.Add(new Wykaz("2", "Kamil", "Stoch"));
            context.wykazy.Add(new Wykaz("3", "Piotr", "Żyła"));
            // itd;
            //context.katalogi.Add(new Dictionary<string, Katalog>("jeden", new Katalog("1", "cos", "jakis", 100)));
        }
    }
}
