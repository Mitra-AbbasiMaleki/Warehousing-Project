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
        List<Product> Products = new List<Product>();
        List<Warehouse> Warehouses = new List<Warehouse>();
        Warehouse CentralWarehouse = new Warehouse(name: "Central", location: "Central Warehouse");
        public ProductForm()
        {
            Product Cloth = new Product(name: "Silk-Fabric", category: ProductCategory.Clothing, quantity: 20, unit: MeasurementUnit.Metr);
            Product Mobile = new Product(name: "Iphone15", quantity: 3, price: 250000000);
            Product Laptop = new Product(name: "Asus", category: ProductCategory.Electronics, quantity: 1);
            Product Butter = new Product(name: "Pak", category: ProductCategory.grocery, quantity: 10, unit: MeasurementUnit.pieces, price: 50000, warehouse: CentralWarehouse, expiryDate: new DateTime(1403, 09, 25), description: " Pak Butter");
            Products.Add(Cloth);
            Products.Add(Mobile);
            Products.Add(Laptop);
            Products.Add(Butter);
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
            if (!ISValidateProductForm())
                return;

            ProductCategory categorySelected =(ProductCategory)cmbProductGroup.SelectedItem;
            MeasurementUnit unitSelected = (MeasurementUnit)cmbUnit.SelectedItem;
            DateTime expirationDate = mtxExpiryDate.Text.ToExpirationDate();
            Warehouse Warehouseselected = new Warehouse();
            if (chkCentralWarehouse.Checked)
            {
                var warehouse = Warehouses.FirstOrDefault(w => w.Name == chkCentralWarehouse.Text);
                if (warehouse != null)
                {
                    Warehouseselected = warehouse; // انبار انتخاب شده را به لیست اضافه می‌کند
                }
            }
            AddProduct addProduct = new AddProduct()
            {
                ProductName = txtProductName.Text,
                Category = categorySelected,
                Quantity = Convert.ToInt32(mtxFirstQuantity.Text),
                Price = Convert.ToDecimal(txtPrice.Text),
                ExpiryDate = expirationDate,
                Warehouse = Warehouseselected,
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
            //creat object
            Product product = new Product(name:addProduct.ProductName,category:addProduct.Category,quantity:addProduct.Quantity,unit:addProduct.Unit,price:addProduct.Price,warehouse:addProduct.Warehouse,expiryDate:addProduct.ExpiryDate,description:addProduct.Description);
            Products.Add(product);
        }
        private bool ISValidateProductForm()
        {
            if (string.IsNullOrEmpty(txtProductName.Text) ||
                string.IsNullOrEmpty(mtxFirstQuantity.Text) ||
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
            mtxFirstQuantity.Text = string.Empty;
            cmbUnit.Text = string.Empty;
            txtPrice.Text = string.Empty;
            mtxExpiryDate.Text = string.Empty;
            txtSupplier.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }
    }
}
