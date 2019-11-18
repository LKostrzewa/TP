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

        public static void WriteWykazToFile(Wykaz wykaz, string path)
        {
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(wykaz.id + ";" + wykaz.imie + ";" + wykaz.nazwisko);
            }
        }

        public static void WriteOpisStanuToFile(OpisStanu opis, string path)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(opis.id + ";" + opis.dataZakupu.ToString() + ";" +
                                opis.katalog.id + ";" + opis.katalog.tytul + ";" + opis.katalog.gatunek + ";" + opis.katalog.ilosc_str);
            }
        }

        public static void WriteZdarzenieToFile(Zdarzenie zdarzenie, string path)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(zdarzenie.id + ";" +
                                zdarzenie.wykaz.id + ";" + zdarzenie.wykaz.imie + ";" + zdarzenie.wykaz.nazwisko +
                                zdarzenie.opis.id + ";" + zdarzenie.opis.dataZakupu + ";" +
                                    zdarzenie.opis.katalog.id + ";" + zdarzenie.opis.katalog.tytul + ";" + zdarzenie.opis.katalog.gatunek + ";" + zdarzenie.opis.katalog.ilosc_str
                             + ";" + zdarzenie.data);
            }
        }

        public static void WriteObjectToJSON(object obj, string path)
        {
            string output = JsonConvert.SerializeObject(obj);
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(output);
            }
        }

        public static void WriteCollectionToJSON<T>(IEnumerable<T> col, string path)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (T k in col)
                {
                    string output = JsonConvert.SerializeObject(k);
                    tw.WriteLine(output);
                }
            }
        }
    }
}
