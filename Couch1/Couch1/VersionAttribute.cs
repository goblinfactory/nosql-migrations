using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couch1
{
    public class VersionAttribute : Attribute
    {
        public VersionAttribute(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }

        public int Major { get; set; }
        public int Minor { get; set; }

        public override int GetHashCode()
        {
            return (Major * 10000) + Minor;
        }
        public override bool Equals(object attribute)
        {
            var att = attribute as VersionAttribute;
            return (att.GetHashCode() == GetHashCode());
        }

        // override greater than and less than operators

    }
}
