namespace Task1_BuildTheSystem.Repos
{
    using System.Collections.Generic;
    using Microsoft.Data.SqlClient;
    using Dapper;
    using Task1_BuildTheSystem.Interfaces;
    using Task1_BuildTheSystem.Models;

    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetAllProducts(int pageNumber, int pageSize)
        {
            var products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Products", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        connection.Open();
                        var query = "SELECT * FROM Products ORDER BY ProductId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY;";
                        return connection.Query<Product>(query, new { Offset = (pageNumber - 1) * pageSize, PageSize = pageSize }).ToList();
                    }
                }
            }

            return products;
        }

        public Product GetProductById(int productId)
        {
            Product product = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Products WHERE ProductId = @ProductId", connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                ProductId = (int)reader["ProductId"],
                                Name = reader["Name"].ToString(),
                                Price = (decimal)reader["Price"],
                                Stock = (int)reader["Stock"]
                            };
                        }
                    }
                }
            }

            return product;
        }

        public void AddProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Products (Name, Price, Stock) VALUES (@Name, @Price, @Stock)", connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Products SET Name = @Name, Price = @Price, Stock = @Stock WHERE ProductId = @ProductId", connection))
                {
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Stock", product.Stock);
                    command.Parameters.AddWithValue("@ProductId", product.ProductId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int productId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", connection))
                {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
