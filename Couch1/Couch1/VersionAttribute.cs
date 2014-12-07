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
    }
}
