using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couch1
{
    public static class StringExtensions
    {
        public static string ToString(this IEnumerable<string> src, char seperator)
        {
            return string.Join(new string( new [] { seperator}), src);
        }
    }
}
