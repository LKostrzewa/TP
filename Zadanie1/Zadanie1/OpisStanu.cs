using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Zadanie1
{
    public class OpisStanu //: ISerializable
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
                   dataZakupu.Date == stanu.dataZakupu.Date;
        }

        public override string ToString()
        {
            return "Katalog: (" + katalog + ") zakupiony - " + dataZakupu + " - ID - " + id;
        }

       /* public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("id", id);
            info.AddValue("katalog", katalog);
            info.AddValue("dataZakupu", dataZakupu);
        }

        public OpisStanu(SerializationInfo info)
        {
            id = info.GetInt32("id");
            dataZakupu = info.GetDateTime("dataZakupu");
            katalog = (Katalog)info.GetValue("katalog", typeof(Katalog));
        }*/
    }
}
