
using Microsoft.Data.SqlClient;
using Task1_BuildTheSystem.Interfaces;
using Task1_BuildTheSystem.Models;

namespace Task1_BuildTheSystem.Repos
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
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (var command = new SqlCommand("INSERT INTO Orders (ProductId, Quantity) VALUES (@ProductId, @Quantity)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ProductId", order.ProductId);
                            command.Parameters.AddWithValue("@Quantity", order.Quantity);
                            command.ExecuteNonQuery();
                        }

                        using (var updateCommand = new SqlCommand("UPDATE Products SET Stock = Stock - @Quantity WHERE ProductId = @ProductId", connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@Quantity", order.Quantity);
                            updateCommand.Parameters.AddWithValue("@ProductId", order.ProductId);
                            updateCommand.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Orders", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                OrderId = (int)reader["OrderId"],
                                ProductId = (int)reader["ProductId"],
                                Quantity = (int)reader["Quantity"],
                                OrderDate = (DateTime)reader["OrderDate"]
                            });
                        }
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
                using (var command = new SqlCommand("SELECT * FROM Orders WHERE OrderId = @OrderId", connection))
                {
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = new Order
                            {
                                OrderId = (int)reader["OrderId"],
                                ProductId = (int)reader["ProductId"],
                                Quantity = (int)reader["Quantity"],
                                OrderDate = (DateTime)reader["OrderDate"]
                            };
                        }
                    }
                }
            }

            return order;
        }
    }
}
