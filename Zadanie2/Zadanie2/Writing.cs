using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Zadanie1;

namespace Zadanie2
{
    public static class Writing
    {
        public static void WriteKatalogToFile(Katalog katalog, string path, ObjectIDGenerator iDGenerator)
        {
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(katalog.id + ";" + katalog.tytul + ";" + katalog.gatunek + ";" + katalog.ilosc_str + ";" + iDGenerator.GetId(katalog, out bool firstTime));
            }
            //tw.Close();
        }

        public static void WriteKatalogsToFile(IEnumerable<Katalog> katalogs, string path, ObjectIDGenerator iDGenerator)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            //fs.
            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (Katalog kat in katalogs)
                {
                    //WriteKatalogToFile(kat, iDGenerator, tw);
                }
            }
        }

        public static void WriteWykazToFile(Wykaz wykaz, string path, ObjectIDGenerator iDGenerator)
        {
            using(TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(wykaz.id + ";" + wykaz.imie + ";" + wykaz.nazwisko + ";" + iDGenerator.GetId(wykaz, out bool firstTime));
            }
        }

        public static void WriteOpisStanuToFile(OpisStanu opis, string path, ObjectIDGenerator iDGenerator)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(opis.id + ";" + iDGenerator.GetId(opis.katalog, out bool firstTime) + ";" + opis.dataZakupu.ToString() + ";" + iDGenerator.GetId(opis, out firstTime));
            }
        }

        public static void WriteZdarzenieToFile(Zdarzenie zdarzenie, string path, ObjectIDGenerator iDGenerator)
        {
            using (TextWriter tw = new StreamWriter(path))
            {
                tw.WriteLine(iDGenerator.GetId(zdarzenie.wykaz, out bool firstTime) + ";" + iDGenerator.GetId(zdarzenie.opis, out firstTime) + ";"
                               + zdarzenie.data.ToString() + iDGenerator.GetId(zdarzenie, out firstTime) );
            }
        }

        public static void WriteObjectToJSON(object obj, string path)
        {
            string output = JsonConvert.SerializeObject(obj, new JsonSerializerSettings{ PreserveReferencesHandling = PreserveReferencesHandling.Objects });
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
                    string output = JsonConvert.SerializeObject(k, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                    tw.WriteLine(output);
                }
            }
        }
    }
}
