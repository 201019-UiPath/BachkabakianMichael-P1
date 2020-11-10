using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data Access Layer for Carts
    /// </summary>
    public interface ICartRepo
    {
        void AddCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
        Cart GetCartById(int id);
        Cart GetCartByUserId(int userId);
    }
}