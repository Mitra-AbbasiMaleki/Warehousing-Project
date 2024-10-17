using BaseBackend.Entities;
using BaseBackend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Warehousing.DTOs;
using Warehousing.Utilities;

namespace Warehousing
{
    public partial class ProductForm : Form
    {
        List<Warehouse> Warehouses;
        public ProductForm()
        {
            Warehouse CentralWarehouse = new Warehouse(name: "Central", location: "Central Warehouse");
            Warehouses = new List<Warehouse>();
            Warehouses.Add(CentralWarehouse);
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            cmbProductGroup.DataSource = Enum.GetValues(typeof(ProductCategory));
            cmbUnit.DataSource = Enum.GetValues(typeof(MeasurementUnit));
        }

        private void btnProductRegistration_Click(object sender, EventArgs e)
        {
            //call validation
            if (!ISValidateRegistrationForm())
                return;

            ProductCategory categorySelected =(ProductCategory)cmbProductGroup.SelectedItem;
            MeasurementUnit unitSelected = (MeasurementUnit)cmbUnit.SelectedItem;
            DateTime expirationDate = mtxExpiryDate.Text.ToExpirationDate();
            Warehouse warehouseSelected = new Warehouse();
            if (chkCentralWarehouse.Checked)
            {
                var warehouse = Warehouses.FirstOrDefault(w => w.Name == chkCentralWarehouse.Text);
                if (warehouse != null)
                {
                    warehouseSelected = warehouse; // انبار انتخاب شده را به لیست اضافه می‌کند
                }
            }
            AddProduct addProduct = new AddProduct()
            {
                ProductName = txtProductName.Text,
                Category = categorySelected,
                Quantity = Convert.ToInt32(txtFirstQuantity.Text),
                Price = Convert.ToDecimal(txtPrice.Text),
                ExpiryDate = expirationDate,
                Warehouse = warehouseSelected,
                Unit = unitSelected,
                Description = txtDescription.Text
            };
            //Add Product
            AddProduct(addProduct);
            //Show Messag
            MessageBox.Show("محصول با موفقیت ثبت شد");
            //Reset Form
            ResetProductForm();
        }
        public void AddProduct(AddProduct addProduct)
        {
            Product product = new Product(name:addProduct.ProductName,category:addProduct.Category,quantity:addProduct.Quantity,unit:addProduct.Unit,price:addProduct.Price,expiryDate:addProduct.ExpiryDate,description:addProduct.Description);
            
            this.Close();
        }
        private bool ISValidateRegistrationForm()
        {
            if (string.IsNullOrEmpty(txtProductName.Text) ||
                string.IsNullOrEmpty(txtFirstQuantity.Text) ||
                cmbUnit.SelectedItem == null||
                string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("لطفا فیلدهای ضروری را پر کنید.");
                return false;
            }
            else
                return true;
        }
        private void ResetProductForm()
        {
            txtProductName.Text = string.Empty;
            cmbProductGroup.SelectedIndex = 0;
            txtFirstQuantity.Text = string.Empty;
            cmbUnit.Text = string.Empty;
            txtPrice.Text = string.Empty;
            mtxExpiryDate.Text = string.Empty;
            txtSupplier.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}
