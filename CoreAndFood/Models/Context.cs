using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Models
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-T8JNUES\\SQLEXPRESS; database=DbCoreFood; integrated security=true; TrustServerCertificate=true;");
		}
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
