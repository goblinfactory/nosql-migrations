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
            string json = _client.Get(key).ToString();
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        //public void Add<T>(string key, T src)
        //{
        //    var json = JsonConvert.SerializeObject(src);

        //    _client.Store(StoreMode.Add,key, )
        //    return obj;
        //}


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