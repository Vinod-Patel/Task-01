using System.Data.Entity;

namespace WebApplication4.Models
{
    public class ApplicationDbContext: DbContext

    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }

    }
}
