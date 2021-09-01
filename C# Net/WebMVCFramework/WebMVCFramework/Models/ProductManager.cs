using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebMVCFramework.Models
{
    public class ProductManager
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\WebMVCFramework\WebMVCFramework\App_Data\WebMVCDatabase.mdf;Integrated Security=True";
        //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\WebMVCFramework\WebMVCFramework\App_Data\WebMVCDatabase.mdf;Integrated Security=True

        public static IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Product product = new Product();
                        product.ID = (int)reader["ID"];
                        product.Name = reader["Name"] as string;
                        product.Quantity = (int)reader["Quantity"];
                        product.Price = (decimal)reader["Price"];
                        product.SupplierID = (int)reader["SupplierID"];
                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Critical($"Error occured in UserManager.Authenticate: {ex.Message}");
            }
            return products;
        }


        //Get Product
        public static Product GetProductById(int id)
        {
            Product product = new Product(); ;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Product WHERE ID=@id", conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        product.ID = (int)reader["ID"];           // or product.ID = Convert.ToInt32(reader["ID"].ToString());
                        product.Name = reader["Name"] as string;  // or product.Name = reader["Name"].ToString();
                        product.Quantity = (int)reader["Quantity"];
                        product.Price = (decimal)reader["Price"];
                        product.SupplierID = (int)reader["SupplierID"];
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.Instance.Critical($"Error occured in UserManager.Authenticate: {ex.Message}");
            }
            return product;
        }

        //Add Product
        public static void AddProduct(Product product)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string columns = " Name, Quantity, Price, SupplierID";
                    string values = "@name, @quantity, @price, @supplierid";
                    string stmt = "INSERT INTO Product (" + columns + ") VALUES (" + values + ")";

                    SqlCommand cmd = new SqlCommand(stmt, conn);

                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@supplierid", product.SupplierID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        //Update Product
        public static void UpdateProduct(Product product)
        {

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string stmt = "UPDATE Product SET Name = @name, Quantity=@quantity, Price=@price, SupplierID=@supplierid WHERE ID=@id";

                    SqlCommand cmd = new SqlCommand(stmt, conn);

                    cmd.Parameters.AddWithValue("@id", product.ID);
                    cmd.Parameters.AddWithValue("@name", product.Name);
                    cmd.Parameters.AddWithValue("@quantity", product.Quantity);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@supplierid", product.SupplierID);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static Product DeletePage(int id)
        {
            var product = ProductManager.GetProductById(id);
            return product;
        }

        //Delete Product
        public static void DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    string stmt = "DELETE FROM Product WHERE ID=@id";

                    SqlCommand cmd = new SqlCommand(stmt, conn);

                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}