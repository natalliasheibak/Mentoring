using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Common;
using NorthwindDAL.Exceptions;

namespace NorthwindDAL
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbProviderFactory providerFactory;
        private readonly string ConnectionString;

        public OrderRepository(string connectionString, string provider)
        {
            providerFactory = DbProviderFactories.GetFactory(provider);
            ConnectionString = connectionString;
        }

        public Customer GetCustomerOrderHistory(string custId)
        {
            var storedProcedureName = "CustOrderHist";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@CustomerID", custId);

            using (var reader = ExecuteReader(storedProcedureName, parameters, CommandType.StoredProcedure))
            {
                if (!reader.HasRows) return null;

                var customer = new Customer();
                customer.CustomerID = custId;
                customer.BoughtProducts = new List<Product>();

                while (reader.Read())
                {
                    var product = new Product();
                    product.ProductName = (string)reader["ProductName"];
                    product.Total = (decimal)reader["Total"];

                    customer.BoughtProducts.Add(product);
                }

                return customer;
            }
        }

        public OrderDetail GetCustomerOrderDetails(int orderId)
        {
            var storedProcedureName = "CustOrdersDetails";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@OrderID", orderId);

            using (var reader = ExecuteReader(storedProcedureName, parameters, CommandType.StoredProcedure))
            {
                if (!reader.HasRows) return null;

                var orderDetail = new OrderDetail();
                orderDetail.ProductName = (string)reader["ProductName"];
                orderDetail.Quantity = (int)reader["Quantity"];
                orderDetail.UnitPrice = (decimal)reader["UnitPrice"];
                orderDetail.Discount = (decimal)reader["Discount"];
                orderDetail.ExtendedPrice = (decimal)reader["ExtendedPrice"];

                return orderDetail;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            var resultOrders = new List<Order>();

            var commandText = "SELECT OrderID, OrderDate, ShippedDated FROM dbo.Orders";

            using (var reader = ExecuteReader(commandText))
            {
                while (reader.Read())
                {
                    var order = new Order();
                    order.OrderID = reader.GetInt32(0);
                    order.OrderDate = reader.GetDateTime(1);
                    order.ShippedDate = reader.GetDateTime(2);
                    order.OrderStatus = order.OrderDate == null ? OrderStatus.New : order.ShippedDate == null ? OrderStatus.InProgress : OrderStatus.Shipped;

                    resultOrders.Add(order);
                }
            }

            return resultOrders;
        }

        public Order GetOrderById(int id)
        {
            var commandText = "SELECT OrderID, OrderDate, ShippedDate FROM dbo.Orders WHERE OrderID = @id; " +
                                    "SELECT OD.ProductID, OD.Quantity, OD.UnitPrice, OD.Discount, P.ProductName FROM dbo.[Order Details] AS OD, dbo.[Products] AS P WHERE OD.OrderID = @id AND OD.ProductID = P.ProductID;";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);

            using (var reader = ExecuteReader(commandText, parameters))
            {
                if (!reader.HasRows) return null;

                reader.Read();
                var order = new Order();
                order.OrderID = reader.GetInt32(0);
                order.OrderDate = reader.GetDateTime(1);
                order.ShippedDate = reader.GetDateTime(2);
                order.OrderStatus = order.OrderDate == null ? OrderStatus.New : order.ShippedDate == null ? OrderStatus.InProgress : OrderStatus.Shipped;

                reader.NextResult();
                order.Details = new List<OrderDetail>();

                while (reader.Read())
                {
                    var detail = new OrderDetail();
                    detail.UnitPrice = (decimal)reader["UnitPrice"];
                    detail.Quantity = (int)reader["Quantity"];
                    detail.ProductID = (int)reader["ProductID"];
                    detail.Discount = (int)reader["Discount"];
                    detail.ProductName = (string)reader["ProductName"];

                    order.Details.Add(detail);
                }

                

                return order;
            }
        }

        public Order AddNew(int orderId, string customerId, int productId, decimal unitPrice, int quantity, decimal discount)
        {
            var commandText = "BEGIN TRANSACTION " +
                              "INSERT INTO dbo.Orders (OrderID, OrderDate, CustomerID, ShippedDate) VALUES (null, GETDATE(), @custId, null); " +
                              "INSERT INTO dbo.[Order Details] (OrderID, ProductID, UnitPrice, Quantity, Discount) Values (@orderID, @productID, @unitPrice, @quantity, @discount); " + 
                              "COMMIT TRANSACTION";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@orderId", orderId);
            parameters.Add("@custId", customerId);
            parameters.Add("@prodId", productId);
            parameters.Add("@quantity", quantity);
            parameters.Add("@discount", discount);
            parameters.Add("@unitPrice", unitPrice);

            if (ExecuteNonQuery(commandText, parameters) > 0)
            {
                var order = GetOrderById(orderId);
                order.OrderStatus = OrderStatus.New;
                return order;
            }
            else
            {
                throw new OrderIsNotAddedException();
            }
        }

        public Order Update(Order order)
        {
            var commandText = "UPDATE dbo.Orders SET OrderDate = @orderDate WHERE OrderID = @orderId";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@orderId", order.OrderID);
            parameters.Add("@orderDate", order.OrderDate);

            if (ExecuteNonQuery(commandText, parameters) > 0)
            {
                return GetOrderById(order.OrderID);
            }
            else
            {
                throw new OrderIsNotUpdatedException();
            }
        }

        public void Delete(int id)
        {
            var commandText = "DELETE FROM dbo.Orders WHERE OrderID = @orderId";

            var parameters = new Dictionary<string, object>();
            parameters.Add("@orderId", id);

            if (ExecuteNonQuery(commandText, parameters) == 0)
            {
                throw new OrderIsNotDeletedException();
            }
        }

        #region private

        private int ExecuteNonQuery(string commandText, Dictionary<string ,object> parameters, CommandType commandType = CommandType.Text)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    foreach (var parameter in parameters)
                    {
                        var param = command.CreateParameter();
                        param.ParameterName = parameter.Key;
                        param.Value = parameter.Value;
                        command.Parameters.Add(parameter);
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        private DbDataReader ExecuteReader(string commandText, Dictionary<string, object> parameters, CommandType commandType = CommandType.Text)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    foreach (var parameter in parameters)
                    {
                        var param = command.CreateParameter();
                        param.ParameterName = parameter.Key;
                        param.Value = parameter.Value;
                        command.Parameters.Add(parameter);
                    }

                    return command.ExecuteReader();
                }
            }
        }

        private DbDataReader ExecuteReader(string commandText, CommandType commandType = CommandType.Text)
        {
            using (var connection = providerFactory.CreateConnection())
            {
                connection.ConnectionString = ConnectionString;
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    return command.ExecuteReader();
                }
            }
        }


        #endregion
    }
}
