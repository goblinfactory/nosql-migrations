using System;
using Couch1.Tests.DTOs;
using NUnit.Framework;

namespace Couch1.Tests.DBTests
{
    [TestFixture]
    public class GettingStartedWithCouchbaseTests
    {

        [Test]
        public void UpsertAndGet()
        {
            var pIn = new Person() { Id = "1", Name = "UpsertAndGet" };
            Test.Bucket.Upsert(pIn.Key, pIn);
            var pOut = Test.Bucket.Get<Person>(pIn.Key).Value;
            Console.WriteLine(Test.Debug.PrintObject(pOut));
        }

        [Test]
        public void EndToEndTest_Connect_WriteJson_ReadJson_WriteT_ReadT()
        {
            Console.WriteLine("Test connect to couchbase");
            Console.WriteLine("-------------------------");
            //Console.WriteLine("version:{0}",db.VersionLocalhost(Settings.CouchbaseLocahostPort));
            
            //var beer = db.GetJson("new_holland_brewing_company-sundog");
            //Console.WriteLine(beer);
        }

        [Test]
        public void CanCreateAnIncrementingCounter()
        {
            var inc1 = Test.Bucket.Increment("CanCreateAnIcrementingCounter", 1, 1).Value;
            Console.WriteLine("inc1:{0}",inc1);
            var inc2 = Test.Bucket.Increment("CanCreateAnIcrementingCounter", 1, 1).Value;
            Console.WriteLine("inc1:{0}",inc2);
        }

        [Test]
        public void CanReadStronglyTypedObjectsWithSomeFieldsMissing()
        {
            var beer = Test.Bucket.Get<Beer>("new_holland_brewing_company-sundog");
            Console.WriteLine(Test.Debug.PrintObject(beer));
        }

       
        
    }
}
