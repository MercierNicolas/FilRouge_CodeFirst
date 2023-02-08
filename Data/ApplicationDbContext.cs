using FilRouge_Test_CodeFirst.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilRouge_Test_CodeFirst.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Quiz> Quiz { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Sujet> sujets { get; set; }
		public DbSet<Level> levels { get; set; }
	}
}