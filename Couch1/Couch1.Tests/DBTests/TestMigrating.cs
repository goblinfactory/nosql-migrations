using System;
using Couch1.Tests.Migrations.PersonMigrations;
using Couchbase;
using Couchbase.Core;
using NUnit.Framework;

namespace Couch1.Tests.DBTests
{


    public class TestMigrating
    {

        [Test]
        public void TestIt()
        {
            // note:could use couchbase incrementor! (will do that later!)

            // write ver 1.0 into database
            var key = "gf:person:" + Guid.NewGuid().ToString();
            var person_1 = new Person_1() { Name = "Fred Smith " };
            Test.Bucket.Upsert(key, person_1);

            // note: we only need the agggregate roots to have unique names ?
            // ======================================================
            // e.g. -> GF:Person:1.3:0000000005

            // read into ver 1.1, migrate it, save back to disk
            //var person_1_1 = db.GetMigratible<PersonMigrations.Person2>(key);

            // read from db into v() FirstName, LastName, Address

            // read json, print to console.

            //var beer = db.GetMigratible<Beer>("new_holland_brewing_company-sundog");
        }
    }

    [Version(3,0)]
    public class Person : Migratable
    {
        public Person() {}
        public override string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public int Age { get; set; }

        // on bigger objects would use Inject to auto map the fields 
        public Person(Person_2 person)
        {

        }

        
    }

}