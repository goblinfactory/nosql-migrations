namespace Couch1.Tests.DTOs
{
    public class Beer 
    {
        // beer
        public string Name { get; set; }
        public float Abv { get; set; }
        public float Ibu { get; set; }
        public float Upc { get; set; }
        public DrinkType @Type { get; set; }
        public string Description { get; set; }
    }
    
    public enum DrinkType { Beer, Other }

} 