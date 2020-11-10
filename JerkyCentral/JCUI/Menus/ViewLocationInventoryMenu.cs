using System;
using System.Collections.Generic;
using JCDB;
using JCDB.Models;
using JCLib;
using System.Text;
using Microsoft.Extensions.Caching.Memory;

namespace JCUI.Menus
{

    /// <summary>
    /// Menu That Is Used For Both Viewing A Locations Inventory As Well As Populating A Users Cart To Prep For Order Placement 
    /// </summary>

    class ViewLocationInventoryMenu : IMenu
    {
        private int selectedLocationId;
        private string selectedItem;
        private string yesorno;
        private int quantity;
        private User user;
        private LocationServices locationServices;
        private InventoryServices inventoryServices;
        private ProductServices productServices;
        private CartLineServices cartLineServices;
        private CartServices cartServices;
        private CustomerMenu customerMenu;
        private DBRepo repo;
        private PlaceOrderMenu placeOrderMenu;

        /// <summary>
        /// Constructor For The View Location Inventory Menu
        /// </summary>

        public ViewLocationInventoryMenu(DBRepo repo, User user)
        {
            this.locationServices = new LocationServices(repo);
            this.inventoryServices = new InventoryServices(repo);
            this.productServices = new ProductServices(repo);
            this.cartLineServices = new CartLineServices(repo);
            this.cartServices = new CartServices(repo);
            this.user = user;
            this.repo = repo;
        }

        /// <summary>
        /// Starting Point Of My View Location Inventory Menu
        /// </summary>

        public void Start()
        {
            do
            {
                Console.WriteLine();

                System.Console.WriteLine("Which location do you want to View:");
                System.Console.WriteLine("-----------------------------------");

                //TODO: Needs validation
                List<Location> locations = locationServices.GetAllLocations();
                foreach (Location location in locations)
                {
                    System.Console.WriteLine($"{location.LocationId} {location.LocationName}");
                }

                Console.WriteLine();

                string locationInput = Console.ReadLine();
                selectedLocationId = Int32.Parse(locationInput);


                Console.WriteLine();

                List<Inventory> CurrentInventory = new List<Inventory>();

                foreach (Location location in locations)
                {
                    if (selectedLocationId == location.LocationId)
                    {
                        CurrentInventory = GetInventoryForLocation(selectedLocationId);
                    }
                }

                foreach (Inventory item in CurrentInventory)
                {
                    Console.WriteLine($"{item.Product.ProductId} {item.Product.ProductName} {item.QuantityOnHand}");
                }

                Console.WriteLine();

                //From here on is where the order taking process is implemented

                Console.WriteLine("Do you want to place an order from this location? (Y/N)");
                System.Console.WriteLine("------------------------------------------------");
                yesorno = Console.ReadLine();

                Console.WriteLine();

                while (!InputValidator.ValidateYesOrNoInput(yesorno))
                {
                    Console.WriteLine("Thats not a valid input. ");
                    Console.WriteLine("Do you want to place an order from this location? Please enter either 'Y' or 'N'");
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    yesorno = Console.ReadLine();
                }

                if (yesorno.Equals("N") || yesorno.Equals("n"))
                {
                    this.customerMenu = new CustomerMenu(repo, user);
                    customerMenu.Start();
                }

                if (yesorno.Equals("Y") || yesorno.Equals("y"))
                {
                    do
                    {
                        Console.WriteLine("Select a product to add to your cart");
                        Console.WriteLine("------------------------------------");

                        Console.WriteLine();

                        foreach (Inventory item in CurrentInventory)
                        {
                            Console.WriteLine($"{item.Product.ProductId} {item.Product.ProductName} {item.QuantityOnHand}");
                        }

                        Console.WriteLine("7 Checkout");
                        Console.WriteLine("8 Back\n");

                        selectedItem = Console.ReadLine();

                        Console.WriteLine();

                        Cart cart = cartServices.GetCartByUserId(user.UserID);
                        CartLine cartLine = new CartLine();

                        switch (selectedItem)
                        {
                            case "1":
                                PopulateCart(1);
                                break;
                            case "2":
                                PopulateCart(2);
                                break;
                            case "3":
                                PopulateCart(3);
                                break;
                            case "4":
                                PopulateCart(4);
                                break;
                            case "5":
                                PopulateCart(5);
                                break;
                            case "6":
                                PopulateCart(6);
                                break;
                            case "7":
                                this.placeOrderMenu = new PlaceOrderMenu(repo, user, selectedLocationId);
                                this.customerMenu = new CustomerMenu(repo, user);
                                placeOrderMenu.Start();
                                customerMenu.Start();
                                break;
                            case "8":
                                this.customerMenu = new CustomerMenu(repo, user);
                                customerMenu.Start();
                                break;
                            default:
                                break;
                        }
                    } while (!selectedItem.Equals("7"));
                }
            } while (!yesorno.Equals("Y") || !yesorno.Equals("y"));


        }

        /// <summary>
        /// Function That Gets All Inventory Items For A Selected Location
        /// </summary>

        public List<Inventory> GetInventoryForLocation(int locationId)
        {
            List<Inventory> items = inventoryServices.GetAllInventoryItemsByLocationId(locationId);
            return items;
        }

        /// <summary>
        /// Function That Is Used To Populate The Customers Cart With The Products They Have Selected Earlier
        /// </summary>

        public void PopulateCart(int prodid)
        {
            Product prod = productServices.GetProductById(prodid);
            Cart cart = cartServices.GetCartByUserId(user.UserID);
            CartLine cartLine = new CartLine();

            Console.WriteLine("How many do you want to add");
            Console.WriteLine("---------------------------");

            Console.WriteLine();

            quantity = Int32.Parse(Console.ReadLine());

            cartLine.CartId = cart.CartId;
            cartLine.Quantity = quantity;
            cartLine.ProductId = prodid;
            cartLineServices.AddCartLine(cartLine);

            Console.WriteLine($"You Added {quantity} {prod.ProductName} to your cart");
            Console.WriteLine("-----------------------------------------------------");
        }
    }
}
