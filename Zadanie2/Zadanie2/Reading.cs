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
    }
}
