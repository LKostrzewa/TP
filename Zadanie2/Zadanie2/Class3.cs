using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    [Serializable]
    public class Class3 : ISerializable
    {
        public float num { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public Class1 obj { get; set; }

        public Class3()
        {
        }

        public Class3(float num, DateTime date, string name)
        {
            this.num = num;
            this.date = date;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            Class3 @class = obj as Class3;
            return @class != null &&
                   num == @class.num &&
                   date == @class.date &&
                   name == @class.name &&
                   EqualityComparer<Class1>.Default.Equals(this.obj, @class.obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1246997140;
            hashCode = hashCode * -1521134295 + num.GetHashCode();
            hashCode = hashCode * -1521134295 + date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Class1>.Default.GetHashCode(obj);
            return hashCode;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("num", num, typeof(float));
            info.AddValue("date", date, typeof(DateTime));
            info.AddValue("name", name, typeof(string));
            info.AddValue("obj", obj, typeof(Class1));
        }

        public Class3(SerializationInfo info, StreamingContext context)
        {
            num = info.GetSingle("num");
            date = info.GetDateTime("date");
            name = info.GetString("name");
            obj = info.GetValue("obj", typeof(Class1)) as Class1;
        }
    }
}
