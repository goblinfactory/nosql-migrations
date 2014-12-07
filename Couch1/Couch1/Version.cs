using Newtonsoft.Json;

namespace Couch1
{
    public class Version
    {
        public Version() {}

        public Version(string version)
        {
            if (string.IsNullOrWhiteSpace(version)) return;
            var parts = version.Split(new char[] { '.' });
            Major = int.Parse(parts[0]);
            Minor = int.Parse(parts[1]);
        }
        public int Major { get; set; }
        public int Minor { get; set; }

        public override bool Equals(object obj)
        {
            var v = obj as Version;
            if (v == null) return false;
            return v.Major == Major && v.Minor == Minor;
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", Major, Minor);
        }
       
    }
}