using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    [Serializable]
    public class Class1 : ISerializable
    {
        public float num { get; set; }
        public DateTime date { get; set; }
        public string name { get; set; }
        public Class2 obj { get; set; }

        public override bool Equals(object obj)
        {
            Class1 @class = obj as Class1;
            return @class != null &&
                   num == @class.num &&
                   date == @class.date &&
                   name == @class.name &&
                   EqualityComparer<Class2>.Default.Equals(this.obj, @class.obj);
        }

        public override int GetHashCode()
        {
            var hashCode = 1246997140;
            hashCode = hashCode * -1521134295 + num.GetHashCode();
            hashCode = hashCode * -1521134295 + date.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(name);
            hashCode = hashCode * -1521134295 + EqualityComparer<Class2>.Default.GetHashCode(obj);
            return hashCode;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }



}
