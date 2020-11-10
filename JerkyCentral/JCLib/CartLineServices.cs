using JCDB;
using JCDB.Models;
using System.Collections.Generic;

namespace JCLib
{
    public class CartLineServices
    {
        /// <summary>
        /// These Are The Methods That Connect With The DBRepo and Allow Me To Use My CartLine Related Business Logic Like Adding Updating Deleting Or Getting CartLines
        /// </summary>
        private ICartLineRepo repo;

        public CartLineServices(ICartLineRepo repo)
        {
            this.repo = repo;
        }
        public void AddCartLine(CartLine cartLine)
        {
            repo.AddCartLine(cartLine);
        }
        public void UpdateCartLine(CartLine cartLine)
        {
            repo.UpdateCartLine(cartLine);
        }
        public void DeleteCartLine(CartLine cartLine)
        {
            repo.DeleteCartLine(cartLine);
        }
        public List<CartLine> GetAllCartLinesByCart(int cartId)
        {
            List<CartLine> cartLines = repo.GetAllCartLinesByCartId(cartId);
            return cartLines;
        }

        public int LocationId;
    }
}