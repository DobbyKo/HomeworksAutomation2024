using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Task1.BuildTheSystem
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void PlaceOrder(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Orders (ProductId, Quantity, OrderDate) VALUES (@ProductId, @Quantity, @OrderDate)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ProductId", order.ProductId);
                    command.Parameters.AddWithValue("@Quantity", order.Quantity);
                    command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Orders";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new Order
                        {
                            OrderId = reader.GetInt32(0),
                            ProductId = reader.GetInt32(1),
                            Quantity = reader.GetInt32(2),
                            OrderDate = reader.GetDateTime(3)
                        };
                        orders.Add(order);
                    }
                }
            }
            return orders;
        }

        public Order GetOrderById(int orderId)
        {
            Order order = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Orders WHERE OrderId = @OrderId";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                OrderId = reader.GetInt32(0),
                                ProductId = reader.GetInt32(1),
                                Quantity = reader.GetInt32(2),
                                OrderDate = reader.GetDateTime(3)
                            };
                        }
                    }
                }
            }
            return order;
        }
    }
}
