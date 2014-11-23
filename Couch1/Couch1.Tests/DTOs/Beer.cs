namespace Couch1.Tests.DTOs
{
    public class Beer : Migratable
    {
        // migratible
        public override Ver Ver { get; set; }

        // beer
        public string Name { get; set; }
        public float Abv { get; set; }
        public float Ibu { get; set; }
        public float Upc { get; set; }
        public GettingStartedWithCouchbaseTests.DrinkType @Type { get; set; }
        public string Description { get; set; }
        
        
    }
}