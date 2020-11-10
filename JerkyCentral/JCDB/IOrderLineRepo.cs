using System.Collections.Generic;
using JCDB.Models;

namespace JCDB
{
    /// <summary>
    /// Data access interface for orderlines
    /// </summary>
    public interface IOrderLineRepo
    {
        void AddOrderLine(OrderLine orderline);
        void UpdateOrderLine(OrderLine orderLine);
        void DeleteOrderLine(OrderLine orderLine);
        List<OrderLine> GetAllOrderLines();
    }
}