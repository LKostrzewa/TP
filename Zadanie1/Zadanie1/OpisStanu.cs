using System;
using System.Collections.Generic;

namespace Zadanie1
{
    public class OpisStanu
    {
        public int id { get; private set; }
        public Katalog katalog { get; set; }
        public DateTime dataZakupu { get; set; }

        public OpisStanu(int id, Katalog katalog, DateTime dataZakupu)
        {
            this.id = id;
            this.katalog = katalog;
            this.dataZakupu = dataZakupu;
        }

        public override bool Equals(object obj)
        {
            OpisStanu stanu = obj as OpisStanu;
            return stanu != null &&
                   EqualityComparer<Katalog>.Default.Equals(katalog, stanu.katalog) &&
                   dataZakupu == stanu.dataZakupu;
        }

        public override string ToString()
        {
            return "Katalog: (" + katalog + ") zakupiony - " + dataZakupu + " - ID - " + id;
        }
    }
}
