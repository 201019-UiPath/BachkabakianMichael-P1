using System;
using JCDB;
using JCDB.Models;
using JCLib;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace JCUI.Menus
{
    /// <summary>
    /// Menu That Allows A Manager To View All Order Histories By Location
    /// </summary>

    class ViewOrderHistoryByLocationMenu : IMenu
    {
        private DBRepo repo;
        private Order order;
        private OrderServices orderServices;
        private LoginMenu loginMenu;

        /// <summary>
        /// Constructor For The View Order History Menu
        /// </summary>

        public ViewOrderHistoryByLocationMenu(DBRepo dbRepo)
        {
            this.repo = dbRepo;
            this.orderServices = new OrderServices(repo);
        }

        /// <summary>
        /// Starting Point For The View Order History Menu. This Will Create Ascending and Descending Order Lists For A Order Histories By Location
        /// </summary>

        public void Start()
        {
            List<Order> orders = orderServices.GetAllOrders();


            var AscListDate = orders.OrderBy(o => o.OrderDate);
            var DescListDate = orders.OrderBy(o => o.OrderDate).Reverse();

            var AscListPrice = orders.OrderBy(o => o.OrderTotal);
            var DescListPrice = orders.OrderBy(o => o.OrderTotal).Reverse();

            Console.WriteLine();

            Console.WriteLine("How Do You Want To Sort The Orders?");
            Console.WriteLine("-----------------------------------");

            System.Console.WriteLine("[1] By Order Date");
            System.Console.WriteLine("[2] By Order Total Price");

            Console.WriteLine();

            string userInput = Console.ReadLine();

            Console.WriteLine();

            while (!InputValidator.ValidateDigitInput(userInput))
            {
                Console.WriteLine("Thats not a valid input. ");
                Console.WriteLine("Please enter either [1] or [2] ");
                Console.WriteLine("-------------------------------");
                userInput = Console.ReadLine();
            }

            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Do You Want To Sort Them By Date with Ascending Order or Descending Order?");
                    Console.WriteLine("--------------------------------------------------------------------------");

                    System.Console.WriteLine("[1] Ascending Date Order");
                    System.Console.WriteLine("[2] Descending Date Order");

                    Console.WriteLine();

                    string dateSortTypeInput = Console.ReadLine();

                    Console.WriteLine();

                    while (!InputValidator.ValidateDigitInput(dateSortTypeInput))
                    {
                        Console.WriteLine("Thats not a valid input. ");
                        Console.WriteLine("Please enter either [1] or [2] ");
                        Console.WriteLine("-------------------------------");
                        dateSortTypeInput = Console.ReadLine();
                    }

                    if (dateSortTypeInput == "1")
                    {
                        foreach (Order order in AscListDate)
                        {
                            Console.WriteLine($"Location ID: {order.LocationId}, Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Order Total: {order.OrderTotal}");
                        }

                        Console.WriteLine();

                    }
                    else if (dateSortTypeInput == "2")
                    {
                        foreach (Order order in DescListDate)
                        {
                            Console.WriteLine($"Location ID: {order.LocationId}, Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Order Total: {order.OrderTotal}");
                        }

                        Console.WriteLine();

                    }

                    break;
                case "2":
                    Console.WriteLine("Do You Want To Sort Them By Total Price with Ascending Order or Descending Order?");
                    Console.WriteLine("---------------------------------------------------------------------------------");

                    System.Console.WriteLine("[1] Ascending Total Price Order");
                    System.Console.WriteLine("[2] Descending Total Price Order");

                    Console.WriteLine();

                    string priceSortTypeInput = Console.ReadLine();

                    Console.WriteLine();

                    while (!InputValidator.ValidateDigitInput(priceSortTypeInput))
                    {
                        Console.WriteLine("Thats not a valid input. ");
                        Console.WriteLine("Please enter either [1] or [2]");
                        Console.WriteLine("------------------------------");
                        priceSortTypeInput = Console.ReadLine();
                    }

                    if (priceSortTypeInput == "1")
                    {
                        foreach (Order order in AscListPrice)
                        {
                            Console.WriteLine($"Location ID: {order.LocationId}, Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Order Total: {order.OrderTotal}");
                        }

                        Console.WriteLine();

                    }
                    else if (priceSortTypeInput == "2")
                    {
                        foreach (Order order in DescListPrice)
                        {
                            Console.WriteLine($"Location ID: {order.LocationId}, Order ID: {order.OrderId}, Order Date: {order.OrderDate}, Order Total: {order.OrderTotal}");
                        }

                        Console.WriteLine();

                    }

                    break;
                default:
                    Console.WriteLine("Your an idiot");
                    break;
            }

            this.loginMenu = new LoginMenu(repo);
            loginMenu.Start();
        }
    }
}
