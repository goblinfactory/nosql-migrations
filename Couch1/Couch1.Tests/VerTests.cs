using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Couch1.Tests
{

    [JsonObject(MemberSerialization.OptIn)]
    internal class NullPerson : TestPerson { }
    
    [Version(1,2)]
    internal class TestPerson : Migratable
    {
        public DateTime? Born { get; set; }
        public string Name { get; set; }
                
        private TestPerson _mother;
        public TestPerson Mother
        {
            get { return _mother ?? new NullPerson(); }
            set { _mother = value;  }
        }

        private TestPerson _father;
        public TestPerson Father
        {
            get { return _father ?? new NullPerson(); }
            set { _father = value; }
        }

        public TestPerson(string name) : this()
        {
            Name = name;
        }
        
        public TestPerson()
        {
            Born = null;
            Name = "";
        }
    }

    internal class TestMigratablePerson : Migratable {}

    public class VerTests
    {

        [Test]
        public void JsonSerialisationTests()
        {
            var fred = new TestPerson("Fred")
                {
                    Mother = new TestPerson("Susan Wefflayminskster"),
                    Father = new TestPerson("Mike Minder") { Mother = new TestPerson("Sally Franks") }
                };

            Console.WriteLine("fred.Mother.Mother.Mother.Father.Father.Mother.Name:{0}", fred.Mother.Mother.Mother.Father.Father.Mother.Name);
            Console.WriteLine("fred.Father.Mother.Name:{0}",fred.Father.Mother.Name);
            Console.WriteLine("----");
            var json = fred.ToJson();
            Console.WriteLine(json);
            //NB! now test I can deserialize this Json back to a valid object! use Fluent to check the whole object
            var p2 = JsonConvert.DeserializeObject<TestPerson>(json);
            Console.WriteLine("fred.Mother.Mother.Mother.Father.Father.Mother.Name:{0}", p2.Mother.Mother.Mother.Father.Father.Mother.Name);
            Console.WriteLine("fred.Father.Mother.Name:{0}", p2.Father.Mother.Name);
            
        }


        [TestCase("1.1", "1.2", false)]
        [TestCase("1.1", "1.1", true)]
        [TestCase("", "",  true)]
        [TestCase("1.2", "3.2", false)]
        public void StringEqualsTest_SameTypes(string lh, string rh, bool result)
        {
            StringEqualsTest(lh,rh, true, result);
        }

        [TestCase("1.1", "1.2",false, false)]
        [TestCase("1.1", "1.1", false, false)]
        [TestCase("", "", false, false)]
        [TestCase("1.2", "3.2", false, false)]
        public void StringEqualsTest_DifferentTypes(string lh, string rh, bool typeSame, bool result)
        {
            StringEqualsTest(lh, rh, false, result);
        }

        [TestCase("1.1", "1.2", false)]
        [TestCase("1.1", "1.1", false)]
        [TestCase("", "", false)]
        [TestCase("1.2", "3.2", false)]
        [TestCase("3.2", "3.1", true)]
        [TestCase("1.5", "2.1", false)]
        [TestCase("5.2", "2.9", true)]
        public void OperatorGreaterTests_SameTypes(string lh, string rh, bool result)
        {
            OperatorGreaterTests(lh,rh,true,result);
        }


        [TestCase("1.1", "1.2", false)]
        [TestCase("1.1", "1.1", false)]
        [TestCase("", "", false)]
        [TestCase("1.2", "3.2", false)]
        [TestCase("3.2", "3.1", true)]
        [TestCase("1.5", "2.1", false)]
        [TestCase("5.2", "2.9", true)]
        public void OperatorGreaterTests_DifferentTypes(string lh, string rh, bool result)
        {
            OperatorGreaterTests(lh, rh, false, result);
        }

        public void OperatorGreaterTests(string lh, string rh, bool typeSame, bool result)
        {
            var left = new TypeInfo(lh, typeof(TestPerson));
            var right = typeSame
                            ? new TypeInfo(rh, typeof(TestPerson))
                            : new TypeInfo(rh, typeof(TestMigratablePerson));
            (left > right).Should().Be(result);
        }

        [Test]
        public void NamespaceAndClassNameTests()
        {
            var t1 = new TypeInfo(1, 1, typeof (TestPerson));
            t1.ClassName.Should().Be("TestPerson");
            t1.Namespace.Should().Be("Couch1.Tests");

            //var t2 = new Ver(1, 1, typeof(TestMigratablePerson));
        }



        // ************************************
        //              BINDINGS
        // ************************************

        public void StringEqualsTest(string lh, string rh, bool typeSame, bool result)
        {
            var left = new TypeInfo(lh, typeof(TestPerson));
            var right = typeSame
                            ? new TypeInfo(rh, typeof(TestPerson))
                            : new TypeInfo(rh, typeof(TestMigratablePerson));
            lh.Equals(rh).Should().Be(result);
        }


    }
}
