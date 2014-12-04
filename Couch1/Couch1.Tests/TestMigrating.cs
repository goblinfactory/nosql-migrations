using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couch1;
using Couch1.Tests.DTOs;
using Couch1.Tests.Migrations.PersonMigrations;
using NUnit.Framework;

namespace Couch1.Tests
{


    public class TestMigrating
    {

        [Test]
        public void TestIt()
        {
            // note:could use couchbase incrementor! (will do that later!)

            var db = new Couchbase();

            // write ver 1.0 into database
            var key = "gf:person:" + Guid.NewGuid().ToString();
            var person_1 = new Person_1() { Name = "Fred Smith " };
            db.Add(key, person_1);

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
        public string Address { get; set; }

        // on bigger objects would use Inject to auto map the fields 
        public Person(Person_2 person)
        {

        }

    }

}