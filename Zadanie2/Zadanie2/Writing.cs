using Newtonsoft.Json;
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

        public static void WriteKatalogToJSON(Katalog katalog, string path)
        {
            string output = JsonConvert.SerializeObject(katalog);
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(output);
            }
        }

        public static void WriteWykazToFile(Wykaz wykaz, string path)
        {
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(wykaz.id + ";" + wykaz.imie + ";" + wykaz.nazwisko);
            }
        }

        public static void WriteWykazToJSON(Wykaz wykaz, string path)
        {
            string output = JsonConvert.SerializeObject(wykaz);
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(output);
            }
        }


    }
}
