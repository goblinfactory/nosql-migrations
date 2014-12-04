using System.Net;
using Couchbase;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;

namespace Couch1
{
    // Extremely simplified abstraction over Couchbase. Not for production, just for learning.
    public class Couchbase
    {
        private CouchbaseClient _client;
        public Couchbase()
        {
            _client = CouchbaseManager.Instance;
        }

        public T Get<T>(string key)
        {
            // Is there already a .net strongly typed "get" or similar fetch/read?
            // seems odd that there is not?
            string json = _client.Get(key).ToString();
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;

        }

        public T GetMigratible<T>(string key, bool writeIfMigrate = true) where T : Migratable
        {
            string json = _client.Get(key).ToString();
            // get version from json
            var ver = JsonConvert.DeserializeObject<TypeInfo>(json);

            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }


        public bool Add<T>(string key, T src)
        {
            var json = JsonConvert.SerializeObject(src);
            var result = _client.Store(StoreMode.Add, key, json);
            return result;
        }


        public string GetJson(string key)
        {
            string json = _client.Get(key).ToString();
            return json;
        }

        public string VersionLocalhost(int port)
        {
            return _client.Stats().GetVersion(new IPEndPoint(new IPAddress(new byte[] {127, 0, 0, 1}),port)).ToString();
        }
    }
}