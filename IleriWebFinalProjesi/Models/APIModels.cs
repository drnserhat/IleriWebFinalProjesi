namespace IleriWebFinalProjesi.Models
{
    public class Movie
    {
        public int Rank { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public string Rating { get; set; }
        public string Id { get; set; }
        public string Year { get; set; }
        public string Image { get; set; }
        public string Big_Image { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public string Trailer_Embed_Link { get; set; }
        public string Trailer_Youtube_Id { get; set; }
        public List<string> Genre { get; set; }
        public List<string> Director { get; set; }
        public List<string> Writers { get; set; }
        public string ImdbId { get; set; }
        public string Imdb_Link { get; set; }

        public MovieType MovieType { get; set; }
    }

   
}
