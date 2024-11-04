using BaseBackend.Entities;
using BaseBackend.Enums;
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
        ProductStatus statusSelected;
        
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
            rdoAvailable.Text = ProductStatus.Available.GetDescription();
            rdoUnavailable.Text = ProductStatus.Unavailable.GetDescription();
            rdoBackOrdered.Text = ProductStatus.BackOrdered.GetDescription();
            rdoAvailable.CheckedChanged += radioButton_CheckedChanged;
            rdoUnavailable.CheckedChanged += radioButton_CheckedChanged;
            rdoBackOrdered.CheckedChanged += radioButton_CheckedChanged;
            cmbUnit.DataSource = units;
            cmbProductGroup.DataSource = categories;
            cmbSupplier.DataSource = Storage.People.OfType<Supplier>().ToList();
            cmbSupplier.DisplayMember = "FullName";
            cmbSupplier.ValueMember = "Id";
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
            Warehouse warehouseSelected;
            Supplier supplierSelected=(Supplier)cmbSupplier.SelectedItem;
            if (chkCentralWarehouse.Checked)
            {
                warehouseSelected = Storage.centralWarehouse;  // اختصاص انبار مرکزی
            }
            else if (chkOtherWarehouse.Checked)
            {
                warehouseSelected = Storage.wasteWarehouse;  // اختصاص انبار دیگر
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
                Warehouse = warehouseSelected,
                Unit = unitSelected,
                Description = txtDescription.Text,
                Status = statusSelected,
                Supplier=supplierSelected                
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
            //Creat Object
            Product product = new Product(name:addProduct.ProductName,category:addProduct.Category,quantity:addProduct.Quantity,status:addProduct.Status,unit:addProduct.Unit,price:addProduct.Price,supplier:addProduct.Supplier,warehouse:addProduct.Warehouse,expiryDate:addProduct.ExpiryDate,description:addProduct.Description);
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
            cmbSupplier.SelectedIndex = 0;
            txtDescription.Text = string.Empty;
        }
        private void RefreshDataGridView()
        {
            productDataGridView.DataSource = null;
            productDataGridView.DataSource = Storage.products;
            productDataGridView.Columns["Category"].Visible = false;
            productDataGridView.Columns["Unit"].Visible = false;
            productDataGridView.Columns["Supplier"].Visible = false;
            productDataGridView.Columns["Warehouse"].Visible = false; 
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // با توجه به نام رادیو باتن، مقدار enum را مشخص کنید
                switch (radioButton.Name)
                {
                    case "rdoAvailable":
                        statusSelected = ProductStatus.Available;
                        break;
                    case "rdoUnavailable":
                        statusSelected = ProductStatus.Unavailable;
                        break;
                    case "rdoBackOrdered":
                        statusSelected = ProductStatus.BackOrdered;
                        break;
                    default:
                        return; // اگر هیچ کدام نبود، خارج می‌شود
                }
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                // فرمت کردن قیمت به فرمت پولی
                txtPrice.Text = price.ToString("N0"); // "C" برای فرمت پولی
                                                      // موقعیت کرسر را به انتهای TextBox برمی‌گردانیم
                txtPrice.SelectionStart = txtPrice.Text.Length;
            }
        }
    }
}
