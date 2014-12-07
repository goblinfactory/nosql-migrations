using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Couch1.Tests.MiscTests
{
    public class DefaultNullObjectTests
    {
        [Test]
        public void ReferencingPropertiesOfNullObjectsShouldReturnNullDefaultObjectsAndNotThrowException()
        {
            var fred = new TestPerson("Fred")
            {
                Mother = new TestPerson("Susan Wefflayminskster"),
                Father = new TestPerson("Mike Minder") { Mother = new TestPerson("Sally Franks") }
            };

            Console.WriteLine("fred.Mother.Mother.Mother.Father.Father.Mother.Name:{0}", fred.Mother.Mother.Mother.Father.Father.Mother.Name);
            Console.WriteLine("fred.Father.Mother.Name:{0}", fred.Father.Mother.Name);
            Console.WriteLine("---- fred json ----");
            var json = fred.ToJson();
            Console.WriteLine(json);
            //NB! now test I can deserialize this Json back to a valid object! use Fluent to check the whole object
            var p2 = JsonConvert.DeserializeObject<TestPerson>(json);
            Console.WriteLine("fred.Mother.Mother.Mother.Father.Father.Mother.Name:{0}", p2.Mother.Mother.Mother.Father.Father.Mother.Name);
            Console.WriteLine("fred.Father.Mother.Name:{0}", p2.Father.Mother.Name);
        }
    }
}
