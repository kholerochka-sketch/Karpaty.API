namespace Karpaty.API.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PlaceCategory Category { get; set; }
        public string ImageUrl { get; set; }
        public double Rating { get; set; }
    }

    public enum PlaceCategory
    {
        Озеро,
        Річка, 
        Водоспад,
        Музей
    }
}
