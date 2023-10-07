using E_Commerce.Domain.Core.SeedWork;

namespace E_Commerce.Domain.AggregateModels.CategoryAndProductAggregate
{
    public class Category : BaseEntity, IAggegateRoot
    {

        public string Name { get; private set; }
        public int? ParentCategoryID { get; private set; }


        private readonly List<Category> _subcategories = new List<Category>();
        public IReadOnlyCollection<Category> Subcategories => _subcategories.AsReadOnly();


        private readonly List<Product>? _product= new List<Product>();
        public IReadOnlyCollection<Product>? Products => _product;

        public Category? ParentCategory { get; private set; }

        public Category()
        {

        }
        public Category(string name, int? parentCategoryId = null)
        {
            Name = name;
            ParentCategoryID = parentCategoryId;
        }


        public void AddSubcategory(Category subcategory)
        {
            _subcategories.Add(subcategory);
        }


        public void AddProduct(string ProductName, Decimal ProductPrice,int stock)
        {
            var newProduct=new Product(ProductName, ProductPrice,stock);
            _product.Add(newProduct);

        }

    }

}

