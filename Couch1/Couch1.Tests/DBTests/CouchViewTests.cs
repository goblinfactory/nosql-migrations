using Couchbase;
using Couchbase.Core;
using NUnit.Framework;

namespace Couch1.Tests.DBTests
{
    public class CouchViewTests
    {

        [Test]
        public void CanQueryViews()
        {

            // will need to query using RestSharp! Bug in community Edition!
            
            //var result = Test.Bucket.GetView("_design/test1", "test1",false).ToList();
            //result.ForEach(
            //    v => Console.WriteLine("{0}:{1}",v.ItemId,v.Info["name"])
            //);
        }

        


        [Test]
        public void CanWorkWithViews()
        {
            //// create users with departments
            //var users =
            //    Enumerable.Range(1, 100)
            //              .Select(i => new Person
            //              {
            //                  Id = i.ToString(),
            //                  Name = "Person " + i,
            //                  Department = "Dept" + (i % 3),
            //                  Age = i % 25,
            //                  Address = (i % 7) + " thing street"
            //              });

            //users.ToList().ForEach(u => Test.Bucket.Store(StoreMode.Set, u.Key, u.ToJson()));

            //            var view = @"function (doc, meta) {
            //              if (doc.type && doc.type == ""beer"" && doc.name) {
            //                 emit(doc.name, null);
            //            ";

        }

    }
}
