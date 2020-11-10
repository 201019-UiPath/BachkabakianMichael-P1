using System;
using JCDB;
using JCDB.Models;
using JCLib;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace JCUI.Menus
{
    /// <summary>
    /// Menu That Is Displayed To A Manager When They Want To Replenish The Inventory Of A Selected Location
    /// </summary>

    public class ReplenishInventoryMenu : IMenu
    {
        private string userInput;
        private int selectedLocationId;
        private Inventory selectedItem;
        private LocationServices locationServices;
        private InventoryServices inventoryServices;
        private ProductServices productServices;
        private LoginMenu loginMenu;
        private DBRepo repo;
        
        /// <summary>
        /// Replenish Inventory Menu Constructor
        /// </summary>

        public ReplenishInventoryMenu(DBRepo repo) 
        {
            this.locationServices = new LocationServices(repo);
            this.inventoryServices = new InventoryServices(repo);
            this.productServices = new ProductServices(repo);
            this.repo = repo;
            
        }

        /// <summary>
        /// Starting Point Of My Replenish Inventory Menu
        /// </summary>

        public void Start()
        {
            Console.WriteLine();
            System.Console.WriteLine("Which location do you want to manage:");
            System.Console.WriteLine("-------------------------------------");

            List<Location> locations = locationServices.GetAllLocations();
            foreach(Location location in locations) 
            {
                System.Console.WriteLine($"{location.LocationId} {location.LocationName}");
            }

            Console.WriteLine();

            userInput = Console.ReadLine();

            selectedLocationId = Int32.Parse(userInput);

            Console.WriteLine();

            foreach(Location location in locations)
            {
                if(selectedLocationId == location.LocationId)
                {
                    EditInventory(selectedLocationId);
                }
            }
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
        /// Function That Allows The Manager To Replenish The Stock Of A Specific Product At The Selected Location
        /// </summary>

        public void EditInventory(int locationId)
        {
            string input;

            do {
                System.Console.WriteLine("Which item do you want to replenish?");
                System.Console.WriteLine("------------------------------------");

                List<Inventory> items = GetInventoryForLocation(locationId);
                foreach(Inventory item in items) 
                {
                    Product product = productServices.GetProductById(item.ProductId);
                    Console.WriteLine($" {product.ProductId} {product.ProductName} {item.QuantityOnHand} ");
                }

                Console.WriteLine();

                input = Console.ReadLine();

                Console.WriteLine();

                switch(input) 
                {
                    case "1":
                        Replenish(1);
                        break;

                    case "2":
                        Replenish(2);
                        break;

                    case "3":
                        Replenish(3);
                        break;

                    case "4":
                        Replenish(4);            
                        break;

                    case "5":
                        Replenish(5);                     
                        break;

                    case "6":
                        break;

                    default:
                        System.Console.WriteLine("Put on your glasses and try again");
                        break;
                }
            } while(!input.Equals("6"));

        }

        /// <summary>
        /// Function That Actually Does The Re-Stocking Of A Product
        /// </summary>

         public void Replenish(int ProductId) {
            selectedItem = inventoryServices.GetInventoryByLocationIdProductId(selectedLocationId, ProductId);
            Console.WriteLine("Replenish stock by how many items?");
            Console.WriteLine("----------------------------------");

            Console.WriteLine();

            int plusStock = Int32.Parse(Console.ReadLine());

            Console.WriteLine();

            selectedItem.QuantityOnHand = plusStock + selectedItem.QuantityOnHand;
            inventoryServices.UpdateInventory(selectedItem);

            Console.WriteLine("Stock Replenished!\n");
            this.loginMenu = new LoginMenu(repo);
            loginMenu.Start();
        }
    }
}