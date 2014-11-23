using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Couch1.Tests
{
    public static class Settings
    {
        public static int CouchbaseLocahostPort { get { return int.Parse(ConfigurationManager.AppSettings["couchbase-localhost-port"]); } }
    }
}
