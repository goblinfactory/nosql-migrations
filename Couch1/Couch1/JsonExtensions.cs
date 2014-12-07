using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Couch1
{
    public static class JsonExtensions
    {
        public static string ToJson(this object src)
        {
            return JsonConvert.SerializeObject(src, Formatting.Indented);
        }
    }
}
