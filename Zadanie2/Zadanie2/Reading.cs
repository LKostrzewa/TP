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
    public static class Reading
    {
        public static T ReadObjectFromJSON <T> (string path)
        {   
            using(StreamReader reader = new StreamReader(path))
            {
                return JsonConvert.DeserializeObject<T>(reader.ReadLine());
            }
        }

        public static IEnumerable<T> ReadCollectionFromJSON <T> (string path)
        {
            List<T> list = new List<T>();
            int lineCount = File.ReadLines(path).Count();
            for(int i = 0; i < lineCount; i++)
            { 
                list.Add(JsonConvert.DeserializeObject<T>(File.ReadLines(path).Skip(i).Take(1).First()));
            }
            return list;
        }

        public static Katalog ReadKatalogFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            return new Katalog(Int32.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3]));
        }

        public static Wykaz ReadWykazFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            return new Wykaz(Int32.Parse(parameters[0]), parameters[1], parameters[2]);
        }

        public static OpisStanu ReadOpisStanuFromFile(string path, Dictionary<String, Katalog> kat)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            return new OpisStanu(Int32.Parse(parameters[0]),
                                kat[parameters[1]], DateTime.Parse(parameters[2]));
        }

        public static Zdarzenie ReadZdarzenieFromFile(string path, bool type)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            if (type)
                return new Wypozyczenie(Int32.Parse(parameters[0]),
                                        new Wykaz(Int32.Parse(parameters[1]), parameters[2], parameters[3]),
                                        new OpisStanu(Int32.Parse(parameters[4]),
                                            new Katalog(Int32.Parse(parameters[6]),
                                                        parameters[7],
                                                        parameters[8],
                                                        Int32.Parse(parameters[9])),
                                            DateTime.Parse(parameters[5])));
            else
                return new Oddanie(Int32.Parse(parameters[0]),
                                        new Wykaz(Int32.Parse(parameters[1]), parameters[2], parameters[3]),
                                        new OpisStanu(Int32.Parse(parameters[4]),
                                            new Katalog(Int32.Parse(parameters[6]),
                                                        parameters[7],
                                                        parameters[8],
                                                        Int32.Parse(parameters[9])),
                                            DateTime.Parse(parameters[5])));
        }
    }
}
