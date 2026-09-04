namespace Assessment4.Models
{
    public class Melon
    {
        public static List<Melon> mostLovedMelons = new List<Melon> {
            new Melon { Img = "images/crenshaw.png", Name = "Crenshaw", NumLoves = 584 },
            new Melon { Img = "images/jubilee_watermelon.jpg", Name = "Jubilee Watermelon", NumLoves = 601 },
            new Melon { Img = "images/sugar_baby_watermelon.gif", Name = "Sugar Baby Watermelon", NumLoves = 587 },
            new Melon { Img = "images/texas_garden_watermelon.jpeg", Name = "Texas Golden Watermelon", NumLoves = 598 }
        };

        public string? Img { get; set; }
        public string? Name { get; set; }  
        public int NumLoves { get; set; }
    }
}
