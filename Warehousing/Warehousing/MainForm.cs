using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehousing
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNewCustomer_Click(object sender, EventArgs e)
        {
            PersonForm customerForm = new PersonForm();
            customerForm.ShowDialog();
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            ProductForm productForm = new ProductForm();
            productForm.Show();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            OrderForm orderform = new OrderForm();
            orderform.Show();
        }
    }
}
