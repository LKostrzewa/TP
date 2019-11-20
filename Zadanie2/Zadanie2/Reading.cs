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
    public class Reading
    {
        private Dictionary<string, Katalog> allKatalog = new Dictionary<string, Katalog>();
        private Dictionary<string, Wykaz> allWykaz = new Dictionary<string, Wykaz>();
        private Dictionary<string, OpisStanu> allOpis = new Dictionary<string, OpisStanu>();


        public static T ReadObjectFromJSON <T> (string path)
        {
            //using(StreamReader reader = new StreamReader(path))
            //{
            //    return JsonConvert.DeserializeObject<T>(reader.ReadLine());
            //}
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
        }

        public static IEnumerable<T> ReadCollectionFromJSON <T> (string path)
        {
            //List<T> list = new List<T>();
            //int lineCount = File.ReadLines(path).Count();
            //for(int i = 0; i < lineCount; i++)
            //{ 
            //    list.Add(JsonConvert.DeserializeObject<T>(File.ReadLines(path).Skip(i).Take(1).First()));
            //}
            List<T> list = new List<T>();
            string jsonToDeserilize = File.ReadAllText(path);
            list = JsonConvert.DeserializeObject<List<T>>(jsonToDeserilize);
            return list;
        }

        public Katalog ReadKatalogFromFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string[] parameters = reader.ReadLine().Split(';');
                allKatalog.Add(parameters[4], new Katalog(int.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3])));
                return allKatalog[parameters[4]];
            }
            //return new Katalog(Int32.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3]));
        }

        public IEnumerable<Katalog> ReadKatalogsFromFile(string path)
        {
            List<Katalog> list = new List<Katalog>();
            int lineCount = File.ReadLines(path).Count();
            for (int i = 0; i < lineCount; i++)
            {
                string[] parameters = File.ReadLines(path).Skip(i).Take(1).First().Split(';');
                allKatalog.Add(parameters[4], new Katalog(int.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3])));
                list.Add(allKatalog[parameters[4]]);
            }
            return list;
        }

        public Wykaz ReadWykazFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            allWykaz.Add(parameters[3], new Wykaz(Int32.Parse(parameters[0]), parameters[1], parameters[2]));
            return allWykaz[parameters[3]];
        }

        public IEnumerable<Wykaz> ReadWykazsFromFile(string path)
        {
            List<Wykaz> list = new List<Wykaz>();
            int lineCount = File.ReadLines(path).Count();
            for (int i = 0; i < lineCount; i++)
            {
                string[] parameters = File.ReadLines(path).Skip(i).Take(1).First().Split(';');
                allWykaz.Add(parameters[3], new Wykaz(Int32.Parse(parameters[0]), parameters[1], parameters[2]));
                list.Add(allWykaz[parameters[3]]);
            }
            return list;
        }

        public OpisStanu ReadOpisStanuFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            allOpis.Add(parameters[3], new OpisStanu(Int32.Parse(parameters[0]), allKatalog[parameters[1]], DateTime.Parse(parameters[2])));
            return allOpis[parameters[3]];
        }

        public IEnumerable<OpisStanu> ReadOpisStanusFromFile(string path)
        {
            List<OpisStanu> list = new List<OpisStanu>();
            int lineCount = File.ReadLines(path).Count();
            for (int i = 0; i < lineCount; i++)
            {
                string[] parameters = File.ReadLines(path).Skip(i).Take(1).First().Split(';');
                allOpis.Add(parameters[3], new OpisStanu(Int32.Parse(parameters[0]), allKatalog[parameters[1]], DateTime.Parse(parameters[2])));
                list.Add(allOpis[parameters[3]]);
            }
            return list;
        }

        public Zdarzenie ReadZdarzenieFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            if (parameters[5] == "Zadanie1.Wypozyczenie")
                return new Wypozyczenie(Int32.Parse(parameters[0]),
                                        allWykaz[parameters[1]],
                                        allOpis[parameters[2]]);
            else
                return new Oddanie(Int32.Parse(parameters[0]),
                                        allWykaz[parameters[1]],
                                        allOpis[parameters[2]]);
        }

        public IEnumerable<Zdarzenie> ReadZdarzeniesFromFile(string path)
        {
            List<Zdarzenie> list = new List<Zdarzenie>();
            int lineCount = File.ReadLines(path).Count();
            for (int i = 0; i < lineCount; i++)
            {
                string[] parameters = File.ReadLines(path).Skip(i).Take(1).First().Split(';');
                if (parameters[5] == "Zadanie1.Wypozyczenie")
                    list.Add(new Wypozyczenie(Int32.Parse(parameters[0]),
                                            allWykaz[parameters[1]],
                                            allOpis[parameters[2]]));
                else
                    list.Add(new Oddanie(Int32.Parse(parameters[0]),
                                        allWykaz[parameters[1]],
                                        allOpis[parameters[2]]));
            }
            return list;
        }
    }
}
