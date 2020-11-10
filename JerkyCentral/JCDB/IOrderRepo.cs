using System;
using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data access interface for JerkyCentral orders
    /// </summary>
    public interface IOrderRepo
    {
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(Order order );
        Order GetOrderById(int id);
        Order GetOrderByDate(DateTime dt);
        List<Order> GetOrdersByUserId(int id);
        List<Order> GetOrdersByLocationId(int id);
        List<Order> GetAllOrders();
    }
}