using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExploreCalifornia.Models
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Post> Posts { get; set; }
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { Database.EnsureCreated(); }
	}
}
