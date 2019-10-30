using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    public class WypelnianieStalymi : IDataFiller
    {
        public void fill(DataContext context)
        {
            context.wykazy.Add(new Wykaz(1, "Adam", "Małysz"));
            context.wykazy.Add(new Wykaz(2, "Kamil", "Stoch"));
            context.wykazy.Add(new Wykaz(3, "Piotr", "Żyła"));
            Katalog tmp = new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100);
            Katalog tmp2 = new Katalog(20, "Docker. Praktyczne zastosowania", "Podręcznik", 450);
            Katalog tmp3 = new Katalog(30, "Harry Potter", "Przygodowa", 360);
            Katalog tmp4 = new Katalog(40, "K-Pax", "Fantastyka", 20);
            context.katalogi.Add(tmp.id, tmp);
            context.katalogi.Add(tmp2.id, tmp2);
            context.katalogi.Add(tmp3.id, tmp3);
            context.katalogi.Add(tmp4.id, tmp4);
            //context.opisyStanu.Add(new OpisStanu(0, context.katalogi[10], new DateTime(2019, 10, 5), 10, 29, 5));
            //context.opisyStanu.Add(new OpisStanu(1, context.katalogi[30], new DateTime(2019, 10, 13), 500, 60, 10));           
            context.opisyStanu.Add(new OpisStanu(0, context.katalogi[10], new DateTime(2019, 10, 5)));
            context.opisyStanu.Add(new OpisStanu(1, context.katalogi[20], new DateTime(2019, 10, 13)));
            context.opisyStanu.Add(new OpisStanu(2, context.katalogi[30], new DateTime(2019, 10, 15)));
            context.opisyStanu.Add(new OpisStanu(4, context.katalogi[40], new DateTime(2019, 10, 23)));
            context.zdarzenia.Add(new Wypozyczenie(0, context.wykazy[0], context.opisyStanu[0]));
            context.zdarzenia.Add(new Wypozyczenie(1, context.wykazy[2], context.opisyStanu[1]));
            //context.zdarzenia.Add(new Zdarzenie(context.wykazy[1], context.opisyStanu[2], DateTime.Now.AddDays(10)));            
        }
    }
}
