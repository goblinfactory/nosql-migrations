using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Couch1
{
    [JsonConverter(typeof(ToStringJsonConverter))]
    public class MigratableTypeInfo
    {

        public bool SameClassAs(MigratableTypeInfo rh)
        {
            return ((Namespace == rh.Namespace) && (ClassName == rh.ClassName));
        }

        public static MigratableTypeInfo ReadVersion<T>()
        {
            var type = typeof(T);
            return MigratableHelper.ReadVersion(type);
        }

        public Version Version { get; set; }
        public string Namespace { get; set; }
        public string ClassName { get; set; }

        public MigratableTypeInfo()
        {
            Version = new Version();
            Version.Major = 0;
            Version.Minor = 0;
            Namespace = "undefined";
            ClassName = "undefined";
        }
        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", Namespace, ClassName, Version.Major, Version.Minor);
        }

        // we have to have an implicit operetor here because we're using ToStringJsonConverter which will cast a string to our object 
        // as it's way of deserializing member values from json.
        public static implicit operator MigratableTypeInfo(string typeInfo)
        {
            var parts = typeInfo.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                var ti = new MigratableTypeInfo();
                int len = parts.Length;
                int minorPosition = parts.Length;
                int majorPosition = minorPosition - 1;
                int classPosition = majorPosition - 1;
                int namespacePosition = classPosition - 1;
                int namespaceLength = len - namespacePosition;
                ti.Namespace = parts.Take(namespaceLength).ToString('.');
                ti.ClassName = parts[classPosition-1];
                ti.Version = new Version()
                    {
                        Major = int.Parse(parts[majorPosition - 1]),
                        Minor = int.Parse(parts[minorPosition - 1])
                    };
                return ti;
            }
            catch (Exception) { throw new SerializationException("could not deserialize TypeInfo from '" + typeInfo + "'");}
        }

        public MigratableTypeInfo(Type type) : this()
        {
            Namespace = type.Namespace;
            ClassName = type.Name;
        }

        public MigratableTypeInfo(int major, int minor, Type type) : this(type)
        {
            Version.Major = major;
            Version.Minor = minor;
        }

        public MigratableTypeInfo(string version, Type type) : this(type)
        {
            Version = new Version(version);
        }

        public bool Equals(MigratableTypeInfo other)
        {
            return (ClassName == other.ClassName && Namespace == other.Namespace && Version.Equals(other.Version));
        }

    }
}
