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
        public Ver()
        {
            Major = 0;
            Minor = 0;
        }

        public Ver(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }


        public Ver(string version)
        {
            var parts = version.Split(new char[] {'.'});
            Major = int.Parse(parts[0]);
            Minor = int.Parse(parts[1]);
        }

        public int Major { get; set; }
        public int Minor { get; set; }

        public override string ToString()
        {
            return string.Format("{0}.{1}",Major,Minor);
        }

        public static implicit operator Ver(string src)
        {
            return new Ver(src);
        }
        
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
