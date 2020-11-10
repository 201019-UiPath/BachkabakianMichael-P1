using System.Collections.Generic;
using JCDB.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Cryptography.X509Certificates;

namespace JCDB
{
    public class DBRepo : IBrandRepo, ICategoryRepo, IInventoryRepo, ILocationRepo, IOrderLineRepo, IOrderRepo, IProductRepo, IUserRepo, ICartRepo, ICartLineRepo , IManagerRepo
    {
        private JCContext context;

        public DBRepo(JCContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// CRUD Methods for my Brands
        /// </summary>
        /// <param name="brand"></param>
        public void AddBrand(Brand brand)
        {
            context.Brands.Add(brand);
            context.SaveChanges();
        }

        public void UpdateBrand(Brand brand)
        {
            context.Brands.Update(brand);
            context.SaveChanges();
        }

        public void DeleteBrand(Brand brand)
        {
            context.Brands.Remove(brand);
            context.SaveChanges();
        }

        public Brand GetBrandById(int id)
        {
            return context.Brands.Single(x => x.BrandId == id);
        }

        public Brand GetBrandByName(string name)
        {
            return context.Brands.Single(x => x.BrandName == name);
        }

        public List<Brand> GetAllBrands()
        {
            return context.Brands.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my Categories
        /// </summary>
        /// <param name="category"></param>
        public void AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            context.Categories.Update(category);
            context.SaveChanges();
        }

        public void DeleteCategory(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public Category GetCategoryById(int id)
        {
            return context.Categories.Single(x => x.CategoryId == id);
        }

        public Category GetCategoryByName(string name)
        {
            return context.Categories.Single(x => x.CategoryName == name);
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my Inventories
        /// </summary>
        /// <param name="inventory"></param>
        public void AddInventory(Inventory inventory)
        {
            context.Inventories.Add(inventory);
            context.SaveChanges();
        }

        public void UpdateInventory(Inventory inventory)
        {
            context.Inventories.Update(inventory);
            context.SaveChanges();
        }

        public void DeleteInventory(Inventory inventory)
        {
            context.Inventories.Remove(inventory);
            context.SaveChanges();
        }

        public Inventory GetInventoryByLocationIdProductId(int locationId, int productId) {
            return context.Inventories.Single(x => x.LocationId == locationId && x.ProductId == productId);
        }

        public List<Inventory> GetAllInventoryItemsByLocationId(int locationId) {
            return context.Inventories.Include("Product").Where(x => x.LocationId == locationId).ToList();
        }

        /// <summary>
        /// CRUD methods for my Locations
        /// </summary>
        /// <param name="location"></param>
        public void AddLocation(Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            context.Locations.Update(location);
            context.SaveChanges();
        }

        public void DeleteLocation(Location location)
        {
            context.Locations.Remove(location);
            context.SaveChanges();
        }

        public Location GetLocationById(int id)
        {
            return context.Locations.Single(x => x.LocationId == id);
        }

        public Location GetLocationByName(string name)
        {
            return context.Locations.Single(x => x.LocationName == name);
        }

        public List<Location> GetAllLocations()
        {
            return context.Locations.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my OrderLines
        /// </summary>
        /// <param name="orderline"></param>
        public void AddOrderLine(OrderLine orderline)
        {
            context.OrderLines.Add(orderline);
            context.SaveChanges();
        }

        public void UpdateOrderLine(OrderLine orderLine)
        {
            context.OrderLines.Update(orderLine);
            context.SaveChanges();
        }

        public void DeleteOrderLine(OrderLine orderLine)
        {
            context.OrderLines.Remove(orderLine);
            context.SaveChanges();
        }

        public List<OrderLine> GetAllOrderLines()
        {
            return context.OrderLines.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my Orders
        /// </summary>
        /// <param name="order"></param>
        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }

        public void DeleteOrder(Order order)
        {
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public Order GetOrderById(int id)
        {
            return context.Orders.Single(x => x.OrderId == id);
        }

        public Order GetOrderByDate(DateTime dt)
        {
            return context.Orders.Single(x => x.OrderDate == dt);
        }

        public List<Order> GetOrdersByUserId(int id)
        {
            return context.Orders.Where(x => x.UserId == id).ToList();
        }

        public List<Order> GetOrdersByLocationId(int id)
        {
            return context.Orders.Where(x => x.LocationId == id).ToList();
        }

        public List<Order> GetAllOrders()
        {
            return context.Orders.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my Products
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            context.Products.Update(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return context.Products.Single(x => x.ProductId == id);
        }

        public Product GetProductByName(string name)
        {
            return context.Products.Single(x => x.ProductName == name);
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my Users
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return context.Users.Single(x => x.UserID == id);
        }

        public User GetUserByName(string name)
        {
            return context.Users.Single(x => x.Name == name);
        }

        //old way of determining manager
        // public User GetUserByManagerStatus(bool status)
        // {
        //     return (User) context.Users.Single(x => x.ManagerStatus == true);
        // }

        public List<User> GetAllUsers()
        {
            return context.Users.Select(x => x).ToList();
        }

        /// <summary>
        /// CRUD methods for my Carts
        /// </summary>
        /// <param name="cart"></param>
        public void AddCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public void UpdateCart(Cart cart)
        {
            context.Carts.Update(cart);
            context.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            context.Carts.Remove(cart);
            context.SaveChanges();
        }

        public Cart GetCartById(int id)
        {
            return context.Carts.Single(x => x.CartId == id);
        }

        public Cart GetCartByUserId(int id) 
        {
            return (Cart) context.Carts.Single(x => x.UserId == id);
        }

        /// <summary>
        /// CRUD methods for CartLines
        /// </summary>
        /// <param name="cartLine"></param>
        public void AddCartLine(CartLine cartLine)
        {
            context.CartLines.Add(cartLine);
            context.SaveChanges();
        }

        public void UpdateCartLine(CartLine cartLine)
        {
            context.CartLines.Update(cartLine);
            context.SaveChanges();
        }

        public void DeleteCartLine(CartLine cartLine)
        {
            context.CartLines.Remove(cartLine);
            context.SaveChanges();
        }

        public List<CartLine> GetAllCartLinesByCartId(int cartId)
        {
            return context.CartLines.Include("Cart").Where(x => x.CartId == cartId).ToList();
        }

        /// <summary>
        /// CRUD methods for managers
        /// </summary>
        /// <param name="manager"></param>
        public void AddManager(Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
        }

        public void UpdateManager(Manager manager)
        {
            context.Managers.Update(manager);
            context.SaveChanges();
        }

        public void DeleteManager(Manager manager)
        {
            context.Managers.Remove(manager);
            context.SaveChanges();
        }

        public Manager GetManagerById(int id)
        {
            return context.Managers.Single(x => x.ManagerID == id);
        }

        public Manager GetManagerByName(string name)
        {
            return context.Managers.Single(x => x.Name == name);
        }

        public List<Manager> GetAllManagers()
        {
            return context.Managers.Select(x => x).ToList();
        }
    }
}