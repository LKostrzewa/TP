using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public static class Writing
    {
        public static void WriteKatalogToFile(Katalog katalog, string path)
        {
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(katalog.id + ";" + katalog.tytul + ";" + katalog.gatunek + ";" + katalog.ilosc_str);
            }
        }

    }
}
