using E_Commerce.Domain.AggregateModels.CartAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Shared.EntityConfigurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder
    .HasMany(c => c.Items).WithOne(ci => ci.Cart).HasForeignKey(ci => ci.CartId).OnDelete(DeleteBehavior.Cascade)
.OnDelete(DeleteBehavior.Cascade);





        }
    }
}
