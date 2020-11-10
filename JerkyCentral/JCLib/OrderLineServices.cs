using JCDB;
using JCDB.Models;
using System.Collections.Generic;

namespace JCLib
{
    public class OrderLineServices
    {
        /// <summary>
        /// These Are The Methods That Connect With The DBRepo and Allow Me To Use My OrderLine Related Business Logic Like Adding Updating Deleting Or Getting OrderLines
        /// </summary>
        private IOrderLineRepo repo;

        public OrderLineServices(IOrderLineRepo repo)
        {
            this.repo = repo;
        }
        public void AddOrderLine(OrderLine orderLine)
        {
            repo.AddOrderLine(orderLine);
        }
        public void UpdateOrderLine(OrderLine orderLine)
        {
            repo.UpdateOrderLine(orderLine);
        }
        public void DeleteOrderLine(OrderLine orderLine)
        {
            repo.DeleteOrderLine(orderLine);
        }
        public List<OrderLine> GetAllOrderLines()
        {
            List<OrderLine> orderLines = repo.GetAllOrderLines();
            return orderLines;
        }
    }
}