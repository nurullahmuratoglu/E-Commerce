using E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Shared.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            

            builder.HasData(
                new
                {
                    Id = 1,
                    Name="BaseCategory",
                    ParentCategoryID = (int?)null

                });
            builder
.HasMany(c => c.Subcategories)
.WithOne(c => c.ParentCategory)
.HasForeignKey(c => c.ParentCategoryID);

        }
    }
}
