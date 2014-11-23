using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couch1.Tests.DTOs;
using NUnit.Framework;

namespace Couch1.Tests
{

    public class TestMigrating
    {
        [Test]
        public void TestIt()
        {
            var db = new Couchbase();

            // could use couchbase incrementor! (will do that later!)
            var id = "gf:person:" + Guid.NewGuid().ToString();
            var person = new Person() {Name = "Fred Smith "};
            db.Add(id, person);

            // read from db into v(2) FirstName, LastName, Address

            // read json, print to console.

            //var beer = db.GetMigratible<Beer>("new_holland_brewing_company-sundog");
        }

        public class Person : Migratable
        {
            public Person() { Ver = new Ver(1,0); }
            
            public string Name { get; set; }
            public override Ver Ver { get; set; }
        }
    }
}
