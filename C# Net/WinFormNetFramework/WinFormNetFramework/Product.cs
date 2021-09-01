using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WinFormNetFramework
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public int SupplierID { get; set; }

        public Product() { }
        public Product(string name, string quantity, string price, string supplierID)
        {
            Name = name;
            Quantity = Convert.ToInt32(quantity);
            Price = Convert.ToDecimal(price);
            SupplierID = Convert.ToInt32(supplierID);
        }
    }
}
