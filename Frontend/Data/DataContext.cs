using Frontend.Models;
using Microsoft.EntityFrameworkCore;

namespace Frontend.Data
{
    public class DataContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>()
                .HasMany(e => e.Products)
                .WithOne(e => e.Group)
                .HasForeignKey(e => e.GroupId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Groups)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);

        }
    }
}
