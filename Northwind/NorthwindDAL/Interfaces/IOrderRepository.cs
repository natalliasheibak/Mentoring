using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindDAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();

        Order GetOrderById(int id);

        Order AddNew(int orderId, string customerId, int productId, decimal unitPrice, int quantity, decimal discount);

        Order Update(Order order);

        void Delete(int id);
    }
}
