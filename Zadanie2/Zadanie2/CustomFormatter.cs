using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class CustomFormatter : Formatter
    {
        public override ISurrogateSelector SurrogateSelector { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override SerializationBinder Binder { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override StreamingContext Context { get; set; }
        public ObjectIDGenerator iDGenerator;

        private string tmp = "";

        public CustomFormatter()
        {
            Context = new StreamingContext(StreamingContextStates.File);
            iDGenerator = new ObjectIDGenerator();
        }

        public override object Deserialize(Stream serializationStream)
        {
            List<object> deserializedObjects = new List<object>();
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            List<string> dataFromFile = new StreamReader(serializationStream).ReadToEnd().Split('\n').ToList();

            for (int i = 0; i < dataFromFile.Count() - 1; i++)
            {
                data.Add(new Dictionary<string, string>());
                List<string> entity = dataFromFile[i].Split(';').ToList();
                foreach (string e in entity)
                {
                    if (e.Length != 0)
                    {
                        List<string> pom = e.Split('=').ToList();
                        data[i].Add(pom[0], pom[1]);
                    }

                }
                Dictionary<string, string> tmpDictionary = data[i];
                SerializationInfo info = new SerializationInfo(Type.GetType(tmpDictionary["objectType"]), new FormatterConverter());
                for (int k = 2; k < tmpDictionary.Count(); k++)
                {
                    string e = tmpDictionary.Keys.ElementAt(k);
                    if (e.Substring(0,3) == "&&&")
                    {
                        info.AddValue(e.Substring(3), null);
                    }
                    else
                    {
                        Console.WriteLine("else" + e);
                        info.AddValue(e, tmpDictionary[e]);
                    }
                }
                deserializedObjects.Add(Activator.CreateInstance(Type.GetType(tmpDictionary["objectType"]), info, Context));
            }

            for (int i = 0; i < deserializedObjects.Count; i++)
            {
                for (int j = 0; j < deserializedObjects.Count; j++)
                {
                    foreach (PropertyInfo p in deserializedObjects[i].GetType().GetProperties())
                    {
                        if (p.PropertyType == deserializedObjects[j].GetType())
                        {
                            p.SetValue(deserializedObjects[i], deserializedObjects[j]);
                        }
                    }
                }
            }

            return deserializedObjects[0];
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            ISerializable data = (ISerializable)graph;
            SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
            info.AddValue("id", iDGenerator.GetId(graph, out bool FirstTime));
            info.AddValue("objectType", graph.GetType().FullName);
            data.GetObjectData(info, Context);
            foreach (SerializationEntry item in info)
            {
                WriteMember(item.Name, item.Value);
            }
            tmp += "\n";

            while(m_objectQueue.Count != 0)
            {
                Serialize(serializationStream, m_objectQueue.Dequeue());
            }

            byte[] content = Encoding.ASCII.GetBytes(tmp);
            serializationStream.Write(content, 0, content.Length);
            tmp = "";

        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            tmp += name + "=" + val.ToUniversalTime().ToString(DateTimeFormatInfo.InvariantInfo) + ";";
        }

        protected override void WriteSingle(float val, string name)
        {
            tmp += name + "=" + val.ToString(CultureInfo.InvariantCulture) + ";";
        }

        protected override void WriteInt64(long val, string name)
        {
            tmp += name + "=" + val.ToString() + ";";
        }

        private void WriteString(string val, string name)
        {
            tmp += name + "=" + val + ";";
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (obj is string)
            {
                WriteString((string)obj, name);
            }
            else
            {
                tmp += "&&&" + name + "=" + iDGenerator.GetId(obj, out bool FirstTime) + ";";
                if (FirstTime)
                {
                    m_objectQueue.Enqueue(obj);
                }
            }
        }

        protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteMember(string memberName, object data)
        {
            base.WriteMember(memberName, data);
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            tmp += name + "=" + val.ToString() + ";";
            //throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}
