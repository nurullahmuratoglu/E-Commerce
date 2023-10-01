namespace E_Commerce.Application.Dtos.Cart
{
    public class CartItemViewDto
    {
        public int ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal ProductPrice { get; private set; }
        public int Quantity { get; private set; }
    }
}
