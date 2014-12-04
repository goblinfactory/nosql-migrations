using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Couch1
{

    public class TypeInfo
    {
        public Version Version { get; set; }

        public string Namespace { get; set; }
        public string ClassName { get; set; }

        public TypeInfo()
        {
            Version = new Version();
            Version.Major = 0;
            Version.Minor = 0;
            Namespace = "undefined";
            ClassName = "undefined";
        }

        public TypeInfo(Type type) : this()
        {
            Namespace = type.Namespace;
            ClassName = type.Name;
        }

        public TypeInfo(int major, int minor, Type type) : this(type)
        {
            Version.Major = major;
            Version.Minor = minor;
        }

        public override int GetHashCode()
        {
            return Version.Major * 100000 + Version.Minor;
        }

        public TypeInfo(string version, Type type) : this(type)
        {
            if (string.IsNullOrWhiteSpace(version)) return;
        }

        public static bool operator >(TypeInfo lh, TypeInfo rh)
        {
            return lh.GetHashCode() > rh.GetHashCode();
        }

        public static bool operator <(TypeInfo lh, TypeInfo rh)
        {
            return lh.GetHashCode() < rh.GetHashCode();
        }

    }

    [JsonConverter(typeof (ToStringJsonConverter))]
    public class Version
    {
        public Version()
        {}

    public Version(string version)
        {
            var parts = version.Split(new char[] { '.' });
            Major = int.Parse(parts[0]);
            Minor = int.Parse(parts[1]);
        }
        public int Major { get; set; }
        public int Minor { get; set; }
        public override string ToString()
        {
            return string.Format("{0}.{1}", Major, Minor);
        }

        public static implicit operator Version(string src)
        {
            return new Version(src);
        }

    }

}
