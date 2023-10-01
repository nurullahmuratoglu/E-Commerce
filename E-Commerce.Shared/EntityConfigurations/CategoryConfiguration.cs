using E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace E_Commerce.Shared.EntityConfigurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var baseCategory = Category.SeedData();

            builder.HasData(
                new
                {
                    Id = 1,
                    baseCategory.Name,
                    ParentCategoryID = (int?)null

                });
            builder
.HasMany(c => c.Subcategories)
.WithOne(c => c.ParentCategory)
.HasForeignKey(c => c.ParentCategoryID);

        }
    }
}
