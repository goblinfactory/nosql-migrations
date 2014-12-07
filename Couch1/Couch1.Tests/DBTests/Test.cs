using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Core;
using NUnit.Framework;
using DebugPrinter = StatePrinter.StatePrinter;

namespace Couch1.Tests.DBTests
{
    [SetUpFixture]
    public class Test 
    {

        //NB! insert setup and teardown for the whole namespace ... dispose the db connection
        
        public static IBucket Bucket;
        public static Cluster Cluster;
        public static DebugPrinter Debug;

        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Test Setup");
            Cluster = new Cluster();
            Debug = new DebugPrinter();
            var bucket = ConfigurationManager.AppSettings["default-bucket"];
            var pword = ConfigurationManager.AppSettings["default-pword"];
            try
            {
                Bucket = Cluster.OpenBucket(bucket, pword);
                }
            catch (AggregateException ae)
            {
                foreach (var ex in ae.InnerExceptions)
                {
                    Console.WriteLine(ex);
                }
                throw;
            }
        }

        [TearDown]
        public void Teardown()
        {
            Console.WriteLine("Test Teardown");
            Bucket.Dispose();
            Cluster.Dispose();
        }
        

    }
}
