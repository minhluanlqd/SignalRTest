using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserAuth> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAuth>().ToTable("users");
        }
    }
}
