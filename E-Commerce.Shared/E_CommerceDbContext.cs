using E_Commerce.Domain.AggregateModels.CartAggregate;
using E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;
using E_Commerce.Domain.Model;
using E_Commerce.Shared.EntityConfigurations;
using Microsoft.EntityFrameworkCore;


namespace E_Commerce.Shared
{
    public class E_CommerceDbContext : DbContext
    {
        public E_CommerceDbContext(DbContextOptions<E_CommerceDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; } 
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        }
    }
}
