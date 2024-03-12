using Microsoft.EntityFrameworkCore;

namespace IleriWebFinalProjesi.Models
{
	public class MyDbContext:DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Comment> Comments { get; set; }
    }
}
