//using System.Net;
//using Couchbase;
//using Newtonsoft.Json;

//namespace Couch1
//{
//    // Extremely simplified abstraction over Couchbase. Not for production, just for learning.
//    public static class CouchbaseExtentions
//    {

//        //public static T GetT<T>(this CouchbaseClient client, string key)
//        //{
//        //    // Is there already a .net strongly typed "get" or similar fetch/read?
//        //    // seems odd that there is not?
//        //    string json = client.Get(key).ToString();
//        //    T obj = JsonConvert.DeserializeObject<T>(json);
//        //    return obj;

//        //}

//        //public static T GetMigratible<T>(this CouchbaseClient client, string key, bool writeIfMigrate = true) where T : Migratable
//        //{
//        //    string json = client.Get(key).ToString();
//        //    // get version from json
//        //    var ver = JsonConvert.DeserializeObject<MigratableTypeInfo>(json);

//        //    T obj = JsonConvert.DeserializeObject<T>(json);
//        //    return obj;
//        //}


//        //public static bool Add<T>(this CouchbaseClient client, string key, T src)
//        //{
//        //    var json = JsonConvert.SerializeObject(src);
//        //    var result = client.Store(StoreMode.Add, key, json);
//        //    return result;
//        //}


//        public static string GetJson(this CouchbaseClient client, string key)
//        {
//            string json = client.Get(key).ToString();
//            return json;
//        }

//        public static string VersionLocalhost(this CouchbaseClient client, int port)
//        {
//            return client.Stats().GetVersion(new IPEndPoint(new IPAddress(new byte[] {127, 0, 0, 1}),port)).ToString();
//        }
//    }
//}