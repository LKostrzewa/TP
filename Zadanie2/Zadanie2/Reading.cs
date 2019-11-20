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

        public Katalog ReadKatalogFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            allKatalog.Add(parameters[4], new Katalog(int.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3])));
            //return new Katalog(Int32.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3]));
            return allKatalog[parameters[4]];
        }

        public Wykaz ReadWykazFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            allWykaz.Add(parameters[3], new Wykaz(Int32.Parse(parameters[0]), parameters[1], parameters[2]));
            return allWykaz[parameters[3]];
        }

        public OpisStanu ReadOpisStanuFromFile(string path)//, Dictionary<String, Katalog> kat)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            allOpis.Add(parameters[3], new OpisStanu(Int32.Parse(parameters[0]), allKatalog[parameters[1]], DateTime.Parse(parameters[2])));
            return allOpis[parameters[3]];
        }

        public Zdarzenie ReadZdarzenieFromFile(string path, bool type)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            if (type)
                return new Wypozyczenie(Int32.Parse(parameters[0]),
                                        allWykaz[parameters[1]],
                                        allOpis[parameters[2]]);
            else
                return new Oddanie(Int32.Parse(parameters[0]),
                                        allWykaz[parameters[1]],
                                        allOpis[parameters[2]]);
        }
    }
}
