using CoreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreProject.DB_Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }
    }
}
