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
    public class MigratableTypeInfoTests
    {

        [Test]
        public void ReadClassNameTest()
        {
            var ti = MigratableTypeInfo.ReadVersion<TestPerson>();
            ti.ClassName.Should().Be("TestPerson");
        }

        [Test]
        public void ReadNamespaceTest()
        {
            var ti = MigratableTypeInfo.ReadVersion<TestPerson>();
            ti.Namespace.Should().Be("Couch1.Tests");
        }

        [TestCase(typeof(TestPerson),1,2)]
        [TestCase(typeof(NonVersioned),0,0)]
        public void ReadVersionMajorAndMinorTest(Type type, int major, int minor)
        {
            var ti = MigratableHelper.ReadVersion(type);
            ti.Version.Major.Should().Be(major);
            ti.Version.Minor.Should().Be(minor);
        }

        [Test]
        public void VersionedAndUnversionedMigratablesShouldShowVersionCorrectlyInJson()
        {
            // versioned
            var before1 = new TestPerson();
            var json1 = before1.ToJson();
            Console.WriteLine(json1);
            Console.WriteLine("------");
            var after1 = JsonConvert.DeserializeObject<TestPerson>(json1);
            var ti1 = after1.TypeInfo;
            ti1.Version.Major.Should().Be(1);
            ti1.Version.Minor.Should().Be(2);
            ti1.ClassName.Should().Be("TestPerson");

            // unversioned
            var before2 = new NonVersioned();
            var json2 = before2.ToJson();
            Console.WriteLine(json2);
            Console.WriteLine("------");
            var after2 = JsonConvert.DeserializeObject<NonVersioned>(json2);
            var ti2 = after2.TypeInfo;
            ti2.Version.Major.Should().Be(0);
            ti2.Version.Minor.Should().Be(0);
            ti2.ClassName.Should().Be("NonVersioned");
        }




        [TestCase("", "", true)]
        [TestCase("1.1", "1.1", true)]
        [TestCase("1.1", "1.2", false)]
        [TestCase("1.2", "3.2", false)]
        public void StringEqualsTest_SameTypes(string lh, string rh, bool result)
        {
            var left = new MigratableTypeInfo(lh, typeof(TestPerson));
            var right = new MigratableTypeInfo(rh, typeof (TestPerson));
            left.Equals(right).Should().Be(result);
        }

        [TestCase("1.1", "1.2",false)]
        [TestCase("1.1", "1.1", false)]
        [TestCase("", "", false)]
        [TestCase("1.2", "3.2", false)]
        public void StringEqualsTest_DifferentTypes(string lh, string rh, bool result)
        {
            var left = new MigratableTypeInfo(lh, typeof(TestPerson));
            var right = new MigratableTypeInfo(rh, typeof(TestMigratablePerson));
            left.Equals(right).Should().Be(result);
        }


        [Test]
        public void NamespaceAndClassNameTests()
        {
            var t1 = new MigratableTypeInfo(1, 1, typeof (TestPerson));
            t1.ClassName.Should().Be("TestPerson");
            t1.Namespace.Should().Be("Couch1.Tests");

            //var t2 = new Ver(1, 1, typeof(TestMigratablePerson));
        }

    }
    [JsonObject(MemberSerialization.OptIn)]
    internal class NullPerson : TestPerson { }

    internal class NonVersioned : Migratable
    {
        public override string Id { get; set; }
    }

    [Version(1, 2)]
    internal class TestPerson : Migratable
    {

        public TestPerson()
        {
            Born = null;
            Name = "";
        }

        public TestPerson(string name) : this()
        {
            Name = name;
        }
        public override string Id { get; set; }

        public DateTime? Born { get; set; }
        public string Name { get; set; }

        private TestPerson _mother;
        public TestPerson Mother
        {
            get { return _mother ?? new NullPerson(); }
            set { _mother = value; }
        }

        private TestPerson _father;
        public TestPerson Father
        {
            get { return _father ?? new NullPerson(); }
            set { _father = value; }
        }


        
    }

    internal class TestMigratablePerson : Migratable {
        public override string Id { get; set; }
    }

}
