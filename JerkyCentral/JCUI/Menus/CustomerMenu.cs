using System;
using JCDB;
using JCDB.Models;
using JCLib;
using System.Collections.Generic;

namespace JCUI.Menus
{
    /// <summary>
    /// Menu that is displayed to customers
    /// </summary>
    public class CustomerMenu : IMenu
    {
        private DBRepo repo;
        private User user;
        private Inventory inventory;
        private UserServices userServices;
        private LocationServices locationServices;
        private InventoryServices inventoryServices;
        private ViewLocationInventoryMenu viewLocationInventoryMenu;
        private PlaceOrderMenu placeOrderMenu;
        private ViewOrderHistoryMenu viewOrderHistoryMenu;


        /// <summary>
        /// Customer Menu Constructor
        /// </summary>

        public CustomerMenu(DBRepo dBRepo, User user)
        {
            this.repo = dBRepo;
            this.inventoryServices = new InventoryServices(repo);
            this.userServices = new UserServices(repo);
            this.locationServices = new LocationServices(repo);
            this.viewLocationInventoryMenu = new ViewLocationInventoryMenu(repo, user);
            this.viewOrderHistoryMenu = new ViewOrderHistoryMenu(repo, user);
        }

        /// <summary>
        /// Starting Point Of My Customer Menu Function
        /// </summary>
        public void Start()
        {
            System.Console.WriteLine("Welcome back to JerkyCentral! What would you like to do?");
            System.Console.WriteLine("--------------------------------------------------------");
            System.Console.WriteLine("[1] Place An Order");
            System.Console.WriteLine("[2] View Order History");
            System.Console.WriteLine("[3] View Location Inventory");
            System.Console.WriteLine("[4] Exit The Store");

            Console.WriteLine();

            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1":
                    viewLocationInventoryMenu.Start();
                    break;
                case "2":
                    viewOrderHistoryMenu.Start();
                    break;
                case "3":
                    viewLocationInventoryMenu.Start();
                    break;
                case "4":
                    Console.WriteLine("Come Back Soon!");
                    Environment.Exit(0);
                    break;
                default:
                    System.Console.WriteLine("your an idiot");
                    break;
            }
        }
    }
}