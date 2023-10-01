using E_Commerce.Domain.Core.SeedWork;

namespace E_Commerce.Domain.AggregateModels.CartAggregate
{
    public class CartItem : BaseEntity
    { 
        public int ProductId { get; private set; }

        public string ProductName { get; private set; }
        public decimal ProductPrice { get; private set; }
        public int ProductStock { get; set; }
        public int CartId { get; private set; }
        public Cart Cart { get; private set; }
        public int Quantity { get; private set; }

        public CartItem(int productId, string productName, decimal productPrice, int productStock, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductPrice = productPrice;
            ProductStock = productStock;
            Quantity = quantity;
            
        }

        public void UpdateQuantity(int newQuantity)
        {
            Quantity = newQuantity;
            
        }
    }
}
