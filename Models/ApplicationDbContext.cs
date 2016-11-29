using Microsoft.EntityFrameworkCore;

namespace UIConfiguration.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=../Users.db");
            
        }
    }
}