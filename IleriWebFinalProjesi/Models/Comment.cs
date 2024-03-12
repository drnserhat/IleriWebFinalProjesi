namespace IleriWebFinalProjesi.Models
{
	public class Comment:BaseEntity
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string MovieDataId { get; set; }
        public MovieType MovieType { get; set; }
    }
}
