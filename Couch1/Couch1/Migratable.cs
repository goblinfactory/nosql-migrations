using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Couch1
{

    [JsonConverter(typeof(ToStringJsonConverter))]
    public class Ver
    {
        public Ver(int major, int minor, int build)
        {
            Major = major;
            Minor = minor;
            Build = build;
        }


        public Ver(string version)
        {
            var parts = version.Split(new char[] {'.'});
            Major = int.Parse(parts[0]);
            Minor = int.Parse(parts[1]);
            Build = int.Parse(parts[2]);
        }

        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }

        public override string ToString()
        {
            return string.Format("{0}.{1}.{2}",Major,Minor,Build);
        }

        public static implicit operator Ver(string src)
        {
            return new Ver(src);
        }
        
    }

    // namespace (tolower) : version : id
    // e.g. couch1.person:1.1:0001
    public abstract class Migratable
    {
        public abstract Ver Ver { get; set; }
    }


    class ToStringJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override bool CanRead
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
