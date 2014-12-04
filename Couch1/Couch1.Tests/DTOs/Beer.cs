namespace Couch1.Tests.DTOs
{
    public class Beer : Migratable
    {
        // beer
        public string Name { get; set; }
        public float Abv { get; set; }
        public float Ibu { get; set; }
        public float Upc { get; set; }
        public GettingStartedWithCouchbaseTests.DrinkType @Type { get; set; }
        public string Description { get; set; }
        
        
    }
}