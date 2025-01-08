using AspMVCProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AspMVCProject
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> products { get; set; }

    }
}
