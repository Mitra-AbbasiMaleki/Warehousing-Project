using BaseBackend.Entities;
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
        List<Product> products;
        List<Warehouse>warehouses;
        List<ProductCategory> categories;
        Warehouse centralWarehouse;
        Warehouse otherWarehouse;
        List<MeasurementUnit> units;
        public ProductForm()
        {
            centralWarehouse = new Warehouse(name: "Central", location: "Tehran");
            otherWarehouse = new Warehouse(name: "Other", location: "Karaj");
            warehouses = new List<Warehouse> { centralWarehouse, otherWarehouse };
            ProductCategory Electronics = new ProductCategory("electronics");
            ProductCategory Grocery = new ProductCategory("grocery");
            ProductCategory Clothing = new ProductCategory("clothing");
            ProductCategory Furniture = new ProductCategory("furniture");
            categories= new List<ProductCategory>() { Electronics,Grocery,Clothing,Furniture};

            MeasurementUnit Kilogeram = new MeasurementUnit("kilogeram");
            MeasurementUnit Pieces = new MeasurementUnit("pieces");
            MeasurementUnit Litre = new MeasurementUnit("litre");
            MeasurementUnit Metr = new MeasurementUnit("metr");
            units = new List<MeasurementUnit>() {Kilogeram,Pieces,Litre,Metr };

            Product Cloth = new Product(name: "Silk-Fabric", category: Clothing, quantity: 20, unit: Metr);
            Product Mobile = new Product(name: "Iphone15", quantity: 3, price: 250000000);
            Product Laptop = new Product(name: "Asus", quantity: 1,price:500000000);
            Product Butter = new Product(name: "Pak", category: Grocery, quantity: 10, unit: Pieces, price: 50000, warehouse: centralWarehouse, expiryDate: new DateTime(1403, 09, 25), description: " Pak Butter");
            products = new List<Product>() { Cloth, Mobile, Laptop, Butter };

            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            cmbUnit.DataSource = units;
            cmbProductGroup.DataSource = categories;
            RefreshDataGridView();
        }

        private void btnProductRegistration_Click(object sender, EventArgs e)
        {
            //call validation
            if (!ISValidateProductForm())
                return;

            ProductCategory categorySelected =(ProductCategory)cmbProductGroup.SelectedItem;
            MeasurementUnit unitSelected = (MeasurementUnit)cmbUnit.SelectedItem;
            DateTime expirationDate = mtxExpiryDate.Text.ToExpirationDate();
            Warehouse warehouselected;
            if (chkCentralWarehouse.Checked)
            {
                warehouselected = centralWarehouse;  // اختصاص انبار مرکزی
            }
            else if (chkOtherWarehouse.Checked)
            {
                warehouselected = otherWarehouse;  // اختصاص انبار ضایعات
            }
            else
            {
                MessageBox.Show("لطفاً یک انبار انتخاب کنید.");
                return;
            }
 
            //DTO
            AddProduct addProduct = new AddProduct()
            {
                ProductName = txtProductName.Text,
                Category = categorySelected,
                Quantity = Convert.ToInt32(mtxFirstQuantity.Text),
                Price = Convert.ToDecimal(txtPrice.Text),
                ExpiryDate = expirationDate,
                Warehouse = warehouselected,
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
            products.Add(product);
            RefreshDataGridView();
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
        private void RefreshDataGridView()
        {
            productDataGridView.DataSource = null;
            productDataGridView.DataSource = products;
            productDataGridView.Columns["Category"].Visible = false;
            productDataGridView.Columns["Unit"].Visible = false;
            productDataGridView.Columns["Warehouse"].Visible = false;

        }
    }
}
