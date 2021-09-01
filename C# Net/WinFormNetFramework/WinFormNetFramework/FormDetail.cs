using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormNetFramework
{
    public partial class FormDetail : Form
    {
        private readonly FormList _parent;
        public string id, name, quantity, price, supplierid;
        public FormDetail(FormList parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lblText.Text = "Update Product";
            btnSave.Text = "Update";
            lblProductID.Text = id;
            txtName.Text = name;
            txtQuantity.Text = quantity;
            txtPrice.Text = price;
            txtSupplierID.Text = supplierid;
        }

        public void SaveInfo()
        {
            lblText.Text = "Add Product";
            btnSave.Text = "Save";
        }


        public void Clear()
        {
            txtName.Text = txtQuantity.Text = txtPrice.Text = txtSupplierID.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Length <3)
            {
                MessageBox.Show("Product Name is Empty ( > 1). ");
                return;
            }
            if (txtQuantity.Text.Trim().Length < 1)
            {
                MessageBox.Show("Product Quantity is Empty ( >1). ");
                return;
            }
            if (txtPrice.Text.Trim().Length < 1)
            {
                MessageBox.Show("Product Price is Empty ( >1). ");
                return;
            }
            if (txtSupplierID.Text.Trim().Length < 1)
            {
                MessageBox.Show("Supplier ID is Empty ( >1). ");
                return;
            }
            if(btnSave.Text == "Save")
            {
        
                name = txtName.Text.Trim();
                quantity = txtQuantity.Text.Trim();
                price = txtPrice.Text.Trim();
                supplierid = txtSupplierID.Text.Trim();
                Product product = new Product(name, quantity, price, supplierid);
                ProductManager.AddProduct(product);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                id = lblProductID.Text.Trim();
                name = txtName.Text.Trim();
                quantity = txtQuantity.Text.Trim();
                price = txtPrice.Text.Trim();
                supplierid = txtSupplierID.Text.Trim();
                Product product = new Product(name, quantity, price, supplierid);
                ProductManager.UpdateProduct(product, id);
                Clear();
            }

            _parent.Display();
        }
    }
}
