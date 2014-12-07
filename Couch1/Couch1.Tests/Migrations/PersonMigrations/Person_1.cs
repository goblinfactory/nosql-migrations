using System;
using System.Linq;
using Couch1.Tests.DBTests;
using Newtonsoft.Json;

namespace Couch1.Tests.Migrations.PersonMigrations
{
    public class Person_1 : Migratable
    {
        public string Name { get; set; }
        public override string Id { get; set; }
    }


    public class Test
    {
        public void test()
        {
            var json = "{ 'Name' = 'Fred','Age' = 20, Ver ='2.1' }";
            var p = Migrator.Create<Person>(json);
        }
    }

    public class Person_2 : Migratable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public override string Id { get; set; }

        public Person_2(string json)
        {
            
        }

        public Person_2(Person_1 person)
        {
            var name = person.Name;
            if (string.IsNullOrWhiteSpace(name)) 
                return;
            var nameParts = person.Name.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            var numparts = nameParts.Length;
            if (numparts < 2) 
                return;
            FirstName = nameParts[0];
            if (nameParts.Length > 1) 
                LastName = string.Join(" ", nameParts.Skip(1).ToArray());
        }

    }

    
}
