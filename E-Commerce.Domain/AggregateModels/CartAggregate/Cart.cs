using E_Commerce.Domain.Core.SeedWork;

namespace E_Commerce.Domain.AggregateModels.CartAggregate
{
    public class Cart : BaseEntity, IAggegateRoot
    {
        private readonly List<CartItem> _items = new List<CartItem>();

        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();
        public int? UserId { get; private set; }
        public bool IsActive { get; private set; }

        public Cart()
        {
            IsActive = true;
        }

        public void AddItem(int productId, string productName, decimal productPrice, int productStock, int quantity)
        {
            var existingItem = _items.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                quantity = Math.Min(quantity, productStock - existingItem.Quantity);
                
                existingItem.UpdateQuantity(existingItem.Quantity + quantity);
            }
            else
            {
                quantity = Math.Min(quantity, productStock);
                var newItem = new CartItem(productId, productName, productPrice, productStock, quantity);
                _items.Add(newItem);
            }
        }
        public void RemoveItem(int productId)
        {

            var itemToRemove = _items.FirstOrDefault(item => item.ProductId == productId);

            _items.Remove(itemToRemove);

        }
        public void UpdateItemQuantity(int productId, int newQuantity)
        {
            var cartItem = _items.SingleOrDefault(item => item.ProductId == productId);

            newQuantity = Math.Min(newQuantity, cartItem.ProductStock);

            cartItem.UpdateQuantity(newQuantity);
        }
        public decimal CalculateTotalPrice()
        {
            return Items.Sum(item => item.Quantity * item.ProductPrice);

        }
        public void AssignUser(int? userId)
        {
            UserId = userId;
        }

        public void MergeWith(Cart otherCart)
        {
            foreach (var item in otherCart.Items)
            {
                
                var existingItem = _items.FirstOrDefault(i => i.ProductId == item.ProductId);
                if (existingItem != null)
                {
                    var quantity = Math.Min(existingItem.ProductStock, existingItem.Quantity + item.Quantity);
                    existingItem.UpdateQuantity(quantity);
                }
                else
                {
                    _items.Add(new CartItem(item.ProductId, item.ProductName, item.ProductPrice, item.ProductStock, item.Quantity));
                }
            }
        }
        public void SetActive(bool active)
        {
            IsActive = active;
        }
    }
}
