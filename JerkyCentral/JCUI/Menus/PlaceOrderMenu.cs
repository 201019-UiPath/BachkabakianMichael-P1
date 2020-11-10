using JCDB;
using JCDB.Models;
using JCLib;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;

namespace JCUI.Menus
{
    /// <summary>
    /// Menu That Is Used To Actually Place A Order
    /// </summary>
    
    class PlaceOrderMenu : IMenu
    {
        private User user;
        private Order order;
        private OrderServices orderServices;
        private OrderLineServices orderLineServices;
        private ProductServices productServices;
        private CartLineServices cartLineServices;
        private CartServices cartServices;
        private int locationId;

        /// <summary>
        /// Place Order Menu Constructor
        /// </summary>

        public PlaceOrderMenu(DBRepo repo, User user, int locationId)
        {
            this.orderServices = new OrderServices(repo);
            this.orderLineServices = new OrderLineServices(repo);
            this.cartServices = new CartServices(repo);
            this.cartLineServices = new CartLineServices(repo);
            this.productServices = new ProductServices(repo);
            this.user = user;
            this.locationId = locationId;

        }

        /// <summary>
        /// Starting Point Of The Place Order Menu
        /// </summary>

        public void Start()
        {
            
            order = new Order();
            
            order.UserId = user.UserID;
            order.LocationId = locationId;
            order.OrderDate = DateTime.Now;

            Cart cart = cartServices.GetCartByUserId(user.UserID);

            double totalPrice = 0.00;
            
            List<CartLine> sessionItems = cartLineServices.GetAllCartLinesByCart(cart.CartId);

            foreach (CartLine item in sessionItems)
            {
                OrderLine orderLine = new OrderLine();
                orderLine.Order = order;
                orderLine.Product = item.Product;
                orderLine.Quantity = item.Quantity;
                totalPrice += item.Product.ListPrice * item.Quantity;
                orderLineServices.AddOrderLine(orderLine);

                cartLineServices.DeleteCartLine(item);
            }

            order.OrderTotal = totalPrice;

            orderServices.UpdateOrder(order);

            Log.Logger.Information("A Order was Placed");

            Console.WriteLine("Your order has been placed!");
            Console.WriteLine("---------------------------");

        }
    }
}
