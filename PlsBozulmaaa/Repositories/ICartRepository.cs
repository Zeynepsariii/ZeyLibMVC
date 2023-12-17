namespace PlsBozulmaaa.Repositories
{
    public interface ICartRepository
    {
        Task<int> RemoveItem(int bookId);
        Task<int> AddItem(int bookId, int qty);
        Task<ShoppingCart> GetUserCart();
        Task<int> GetCartItemCount(string userId = "");
        Task<ShoppingCart> GetCart(string userId);
        Task<bool> DoCheckout();
    }
}
