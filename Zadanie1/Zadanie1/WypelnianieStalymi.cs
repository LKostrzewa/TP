﻿using System;
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
            context.wykazy.Add(new Wykaz("1", "Adam", "Małysz"));
            context.wykazy.Add(new Wykaz("2", "Kamil", "Stoch"));
            context.wykazy.Add(new Wykaz("3", "Piotr", "Żyła"));
            context.katalogi.Add("00-00", new Katalog(10, "Android Studio w 24 godziny", "Podręcznik", 100));
            context.katalogi.Add("00-01", new Katalog(20, "Docker. Praktyczne zastosowania", "Podręcznik", 450));
            context.katalogi.Add("00-02", new Katalog(30, "Harry Potter", "Przygodowa", 360));
            context.katalogi.Add("00-03", new Katalog(40, "K-Pax", "Fantastyka", 20));
            context.opisyStanu.Add(new OpisStanu(context.katalogi["00-00"], new DateTime(2019, 10, 5), 10, 29, 5));
            context.opisyStanu.Add(new OpisStanu(context.katalogi["00-03"], new DateTime(2019, 10, 13), 500, 60, 10));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[0], context.opisyStanu[0], DateTime.Now.AddDays(90)));
            context.zdarzenia.Add(new Zdarzenie(context.wykazy[2], context.opisyStanu[1], DateTime.Now.AddDays(180)));
        }
    }
}