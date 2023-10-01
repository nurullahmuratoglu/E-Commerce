namespace E_Commerce.Application.Dtos.Category
{
    public class CategoryViewDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryViewDtos> Subcategories { get; set; }
    }
}
 