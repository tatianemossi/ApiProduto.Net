using Microsoft.Extensions.Configuration;
using ProductApi.Net.Domain.Entity;
using ProductApi.Net.Domain.Interfaces.Repositories;
using ProductApi.Net.Infra.SqlScripts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProductApi.Net.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string ConnectioString;

        public ProductRepository(IConfiguration configuration)
        {
            ConnectioString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();
            using (var connection = new SqlConnection(ConnectioString))
            {
                var command = new SqlCommand(ProductScripts.GetAll, connection);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = ConvertReaderToProduct(reader);
                        products.Add(product);
                    }
                    reader.Close();
                }
                connection.Close();
            }

            return products;
        }

        public Product GetById(int id)
        {
            Product product = null;
            using (var connection = new SqlConnection(ConnectioString))
            {
                var command = new SqlCommand(ProductScripts.GetById, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                        product = ConvertReaderToProduct(reader);

                    reader.Close();
                }
                connection.Close();
            }

            return product;
        }

        public Product Insert(Product product)
        {
            using (var connection = new SqlConnection(ConnectioString))
            {
                var command = new SqlCommand(ProductScripts.Insert, connection);
                command.Parameters.AddWithValue("@CreatedAt", product.CreatedAt);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@UpdateAt", product.UpdateAt);

                connection.Open();

                product.Id = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();
            }

            return product;
        }

        public Product Update(int id, Product product)
        {
            using (var connection = new SqlConnection(ConnectioString))
            {
                var command = new SqlCommand(ProductScripts.Update, connection);
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@Brand", product.Brand);
                command.Parameters.AddWithValue("@UpdateAt", product.UpdateAt);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }

            return product;
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(ConnectioString))
            {
                var command = new SqlCommand(ProductScripts.Delete, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        private static Product ConvertReaderToProduct(SqlDataReader reader)
        {
            return new Product
            {
                Id = Convert.ToInt32(reader[0]),
                CreatedAt = Convert.ToDateTime(reader[1]),
                Name = reader[2].ToString(),
                Price = Convert.ToDecimal(reader[3]),
                Brand = reader[4].ToString(),
                UpdateAt = Convert.ToDateTime(reader[5])
            };
        }
    }
}
