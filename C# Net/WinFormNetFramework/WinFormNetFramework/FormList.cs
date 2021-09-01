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
    public partial class FormList : Form
    {
        public FormDetail form;
        public FormList()
        {
            InitializeComponent();
            form = new FormDetail(this);
        }

        public void Display()
        {
            ProductManager.DisplayAndSeach("SELECT * FROM product", dataGridView);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void FormList_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ProductManager.DisplayAndSeach("SELECT * FROM product WHERE Name LIKE '%"+ txtSearch.Text +"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                //Edit
                form.Clear();
                form.id = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                form.name = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                form.quantity = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                form.price = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                form.supplierid = dataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                form.UpdateInfo();
                form.ShowDialog();
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //Delete
                if(MessageBox.Show("Are you sure to delete this product?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes);
                {
                    ProductManager.DeleteProduct(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }

            }
        }
    }
}
