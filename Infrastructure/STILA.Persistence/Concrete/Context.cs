using Microsoft.EntityFrameworkCore;
using STILA.Domain.Entities;

namespace STILA.Persistence.Concrete
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-OK3QKVJ;Database=STILA;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;Integrated Security=True;");
		}

		//public DbSet<Post> Posts { get; set; }
		public DbSet<Category> Categories { get;set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<Product> Products { get; set; }
	}
}
