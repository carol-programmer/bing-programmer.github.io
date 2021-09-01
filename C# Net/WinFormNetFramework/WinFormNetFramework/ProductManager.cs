using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WinFormNetFramework
{
    class ProductManager
    {
        public static MySqlConnection GetConnection()
        {
            const string connectionString = "datasource=localhost;port=3306;username=root;password=;database=retailsecurity";
            MySqlConnection conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return conn;
        }

        public static void AddProduct(Product product)
        {
            string sql = "INSERT INTO product VALUES (NULL, @name, @quantity, @price, @supplierid)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = product.Quantity;
            cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = product.Price;
            cmd.Parameters.Add("@supplierid", MySqlDbType.Int32).Value = product.SupplierID;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Added Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product Not Added. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateProduct(Product product, string id)
        {
            string sql = "UPDATE product SET Name=@name,Quantity=@quantity, Price=@price, SupplierID=@supplierid WHERE ID=@id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = product.Name;
            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = product.Quantity;
            cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = product.Price;
            cmd.Parameters.Add("@supplierid", MySqlDbType.Int32).Value = product.SupplierID;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Updated Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product Not Updated. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DeleteProduct(string id)
        {
            string sql = "DELETE FROM product WHERE ID = @id";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = Convert.ToInt32(id);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product Deleted Successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Product Not Deleted. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSeach(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
