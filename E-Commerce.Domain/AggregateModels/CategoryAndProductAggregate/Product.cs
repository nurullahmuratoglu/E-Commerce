using E_Commerce.Domain.Core.SeedWork;

namespace E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate
{
    public class Product : BaseEntity
    {

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public Category Category { get; private set; }
        public bool IsActive { get; private set; }

        public Product(string name, decimal price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
            IsActive = true;
        }
        public Product()
        {

        }

    }
}
