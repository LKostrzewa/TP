﻿using System;
using System.Collections;
using System.Collections.Generic;
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
        private bool FirstTime;

        public CustomFormatter()
        {
            Context = new StreamingContext(StreamingContextStates.File);
            iDGenerator = new ObjectIDGenerator();
        }

        public override object Deserialize(Stream serializationStream)
        {
            throw new NotImplementedException();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {
            if(!(graph is ISerializable))
            {
                throw new Exception("Graph has to be ISerializable !");
            }
            else
            {
                ISerializable data = (ISerializable)graph;
                SerializationInfo info = new SerializationInfo(graph.GetType(), new FormatterConverter());
                info.AddValue("id", iDGenerator.GetId(graph, out FirstTime));
                data.GetObjectData(info, Context);
                foreach (SerializationEntry item in info)
                {
                    if (item.Value is ISerializable && item.Value.GetType() != typeof(DateTime))
                    {
                        WriteMember(item.Name, item.Value);
                        if (FirstTime == true)
                        {
                            tmp += "\n";
                            Serialize(serializationStream, item.Value);
                        }
                    }
                    else
                    {
                        WriteMember(item.Name, item.Value);
                    }
                }
                byte[] content = Encoding.ASCII.GetBytes(tmp);
                serializationStream.Write(content, 0, content.Length);
                tmp = "";
            }
        }

        /*private void WriteStream(Stream stream)
        {
            using(StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(tmp);
            }
        }*/

        protected override void WriteDateTime(DateTime val, string name)
        {
            tmp += name + ":" + val.ToString() + ";";
        }

        protected override void WriteSingle(float val, string name)
        {
            tmp += name + ":" + val.ToString() + ";";
        }

        protected override void WriteInt64(long val, string name)
        {
            tmp += name + ":" + val.ToString() + ";";
        }

        private void WriteString(string val, string name)
        {
            tmp += name + ":" + val + ";";
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if (obj is string)
            {
                WriteString((string)obj, name);
            }
            else
            {
                tmp += name + ":" + iDGenerator.GetId(obj, out FirstTime) + ";";
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
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}