namespace E_Commerce.Application.Dtos.Product
{
    public class ProductInfoDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string CategoryName { get; set; }
    }
}
