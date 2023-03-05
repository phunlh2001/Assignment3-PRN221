using Assignment3.Extentions;
using Microsoft.EntityFrameworkCore;

namespace Assignment3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public ApplicationDbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration table by entity
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<PostCategory>().ToTable("PostCategories");
            modelBuilder.Entity<AppUser>().ToTable("AppUsers");

            // Seed datas
            modelBuilder.Seed();
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostCategory> PostCategories { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
    }
}
