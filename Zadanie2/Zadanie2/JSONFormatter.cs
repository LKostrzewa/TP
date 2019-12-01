using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie2
{
    public class JsonFormatter
    {
        private readonly JsonSerializer _serializer;

        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }
        public ISurrogateSelector SurrogateSelector { get; set; }

        public JsonFormatter()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                MetadataPropertyHandling = MetadataPropertyHandling.ReadAhead,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize
            };
            _serializer = JsonSerializer.Create(settings);
            _serializer.Formatting = Formatting.Indented;
        }

        public T Deserialize<T>(Stream serializationStream)
        {
            JsonTextReader reader = new JsonTextReader(new StreamReader(serializationStream));
            return _serializer.Deserialize<T>(reader);
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            JsonTextWriter writer = new JsonTextWriter(new StreamWriter(serializationStream));
            _serializer.Serialize(writer, graph);
            writer.Flush();
            writer.Close();
        }
    }
}
