using BaseBackend.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Warehousing.DTOs;
using Warehousing.Utilities;

namespace Warehousing
{
    public partial class ProductForm : Form
    {
        List<MeasurementUnit> units;
        List<ProductCategory> categories;
        public ProductForm()
        {
            InitializeComponent();
            string jsonDataUnitFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "unitsFile.json");
            if (File.Exists(jsonDataUnitFilePath))
            {
                string jsonDataStrUnit = File.ReadAllText(jsonDataUnitFilePath);
                units = JsonConvert.DeserializeObject<List<MeasurementUnit>>(jsonDataStrUnit);
            }

            string jsonDataCategoryFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "categoriesFile.json");
            if (File.Exists(jsonDataCategoryFilePath))
            {
                string jsonDataStrCategory = File.ReadAllText(jsonDataCategoryFilePath);
                categories = JsonConvert.DeserializeObject<List<ProductCategory>>(jsonDataStrCategory);
            }
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
                warehouselected = Storage.centralWarehouse;  // اختصاص انبار مرکزی
            }
            else if (chkOtherWarehouse.Checked)
            {
                warehouselected = Storage.wasteWarehouse;  // اختصاص انبار دیگر
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
            Storage.products.Add(product);
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
            productDataGridView.DataSource = Storage.products;
            productDataGridView.Columns["Category"].Visible = false;
            productDataGridView.Columns["Unit"].Visible = false;
            productDataGridView.Columns["Warehouse"].Visible = false;
        }
    }
}
