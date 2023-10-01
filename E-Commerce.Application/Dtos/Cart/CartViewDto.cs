namespace E_Commerce.Application.Dtos.Cart
{
    public class CartViewDto
    {
        public int Id { get; set; }
        public List<CartItemViewDto> Items { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
