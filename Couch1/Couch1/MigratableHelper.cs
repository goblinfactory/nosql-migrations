using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Couch1
{
    public static class MigratableHelper
    {
        public static TypeInfo ConfirmCompatible<T>(TypeInfo fromVersion) where T : Migratable
        {
            var toVersion = ReadVersion<T>();
            if (toVersion.GetHashCode() >= fromVersion.GetHashCode()) return toVersion; // e.g. from 2.1 to 3.6 IS migratable!
            var name = fromVersion.GetType().Name;
            // if got here then version is not migratable, e.g. backwards, from 3.6 to 2.1!
            var msg = string.Format("{0}.{1} cannot migrate backwards from {0}.{1} to {0}.{2}", name, fromVersion, toVersion);
            throw new SerializationException(msg);
        }

        public static TypeInfo ReadVersion(Type type)
        {
            // if class is decorated with a version attribute
            var ver = (VersionAttribute)type.GetCustomAttributes(typeof(VersionAttribute), true).FirstOrDefault();
            if (ver != null) return new TypeInfo(ver.Major, ver.Minor, type);
            // if class has no version attribute, look for version in naming convention!
            var className = type.Name;
            var parts = className.Split(new char[] { '_' });
            var version = new TypeInfo();
            var build = version.Version;
            try
            {
                if (parts.Length == 2) // Person_1
                {
                    build.Major = int.Parse(parts[1]);
                }
                if (parts.Length == 3) // Person_1_1
                {
                    build.Major = int.Parse(parts[1]);
                    build.Minor = int.Parse(parts[2]);
                }
            }
            catch (Exception)
            {
                build.Major = -1;
                build.Minor = -1;
            }
            return version;
            
        }
        public static TypeInfo ReadVersion<T>()
        {
            var type = typeof(T);
            return ReadVersion(type);
        }
    }
}
