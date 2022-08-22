using Microsoft.EntityFrameworkCore;
using TestProject.Data.Entities;

namespace TestProject.Data
{
    public class ZipCoContext : DbContext
    {
        public ZipCoContext(DbContextOptions<ZipCoContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Account>().ToTable("Accounts");
        }
    }
}