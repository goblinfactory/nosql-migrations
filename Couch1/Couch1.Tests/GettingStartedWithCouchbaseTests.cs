using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couch1.Tests.DTOs;
using NUnit.Framework;
using DebugPrinter = StatePrinter.StatePrinter;

namespace Couch1.Tests
{
    [TestFixture]
    public class GettingStartedWithCouchbaseTests
    {
        private DebugPrinter _printer;

        public GettingStartedWithCouchbaseTests()
        {
            _printer = new DebugPrinter();
        }

        [Test]
        public void Blah()
        {
            // write some random class to the database, so that I can update it and later   
        }

        [Test]
        public void EndToEndTest_Connect_WriteJson_ReadJson_WriteT_ReadT()
        {
            Console.WriteLine("Test connect to couchbase");
            Console.WriteLine("-------------------------");
            var db = new Couchbase();
            //Console.WriteLine("version:{0}",db.VersionLocalhost(Settings.CouchbaseLocahostPort));
            
            //var beer = db.GetJson("new_holland_brewing_company-sundog");
            //Console.WriteLine(beer);
        }

        [Test]
        public void CanReadStronglyTypedObjectsWithSomeFieldsMissing()
        {
            var db = new Couchbase();
            var beer = db.Get<Beer>("new_holland_brewing_company-sundog");
            Console.WriteLine(_printer.PrintObject(beer));
        }

        public enum DrinkType { Beer, Other }
    }
}
