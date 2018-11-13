using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia.Models
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Post> Posts { get; set; }
		public DbSet<Special> Specials { get; set; }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { Database.EnsureCreated(); }
	}
}