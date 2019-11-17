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
        public static Katalog ReadKatalogFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            return new Katalog(Int32.Parse(parameters[0]), parameters[1], parameters[2], Int32.Parse(parameters[3]));
        }

        public static Katalog ReadKatalogFromJSON(string path)
        {
            StreamReader reader = new StreamReader(path);
            return JsonConvert.DeserializeObject<Katalog>(reader.ReadLine());
        }

        public static Wykaz ReadWykazFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            return new Wykaz(Int32.Parse(parameters[0]), parameters[1], parameters[2]);
        }

        public static Wykaz ReadWykazFromJSON(string path)
        {
            StreamReader reader = new StreamReader(path);
            return JsonConvert.DeserializeObject<Wykaz>(reader.ReadLine());
        }

        public static OpisStanu ReadOpisStanuFromJSON(string path)
        {
            StreamReader reader = new StreamReader(path);
            return JsonConvert.DeserializeObject<OpisStanu>(reader.ReadLine());
        }

        public static OpisStanu ReadOpisStanuFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string[] parameters = reader.ReadLine().Split(';');
            //return new Wykaz(Int32.Parse(parameters[0]), parameters[1], parameters[2]);
            return new OpisStanu(Int32.Parse(parameters[0]),
                                 new Katalog(Int32.Parse(parameters[2]), 
                                             parameters[3], 
                                             parameters[4], 
                                             Int32.Parse(parameters[5])),
                                 DateTime.Parse(parameters[1]));
        }

        public static Zdarzenie ReadZdarzenieFromJSON(string path, bool type)
        {
            StreamReader reader = new StreamReader(path);
            if(type)
                return JsonConvert.DeserializeObject<Wypozyczenie>(reader.ReadLine());
            else
                return JsonConvert.DeserializeObject<Oddanie>(reader.ReadLine());
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
