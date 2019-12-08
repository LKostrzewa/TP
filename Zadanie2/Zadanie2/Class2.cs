using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    [Serializable]
    public class Class2 : ISerializable
    {
        public float num { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public Class3 obj { get; set; }

        public Class2()
        {
        }

        public Class2(float num, DateTime date, string name)
        {
            this.num = num;
            this.date = date;
            this.name = name;
        }

        public override bool Equals(object obj)
        {
            Class2 @class = obj as Class2;
            return @class != null &&
                   num == @class.num &&
                   date == @class.date &&
                   name == @class.name &&
                   EqualityComparer<Class3>.Default.Equals(this.obj, @class.obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1246997140;
            hashCode = hashCode * -1521134295 + num.GetHashCode();
            hashCode = hashCode * -1521134295 + date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Class3>.Default.GetHashCode(obj);
            return hashCode;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(num), num, typeof(float));
            info.AddValue(nameof(date), date.ToUniversalTime(), typeof(DateTime));
            info.AddValue(nameof(name), name, typeof(string));
            info.AddValue(nameof(obj), obj, typeof(Class3));
        }

        public Class2(SerializationInfo info, StreamingContext context)
        {
            num = info.GetSingle("num");
            date = info.GetDateTime("date").ToLocalTime();
            name = info.GetString("name");
            obj = (Class3) info.GetValue("obj", typeof(Class3));
        }
    }
}
