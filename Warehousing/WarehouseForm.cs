#nullable disable
using BaseBackend.Entities;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Warehousing.Utilities;

namespace Warehousing
{
    public partial class WarehouseForm : Form
    {
        Warehouse newWarehouse;
        public WarehouseForm()
        {
            InitializeComponent();
            //پر کردن چک لیست باکس با محصولاتی که به هیچ انباری تخصیص نیافته اند
            LoadProductsWithoutStorage();
        }
        //تابع پر کردن چک لیست باکس 
        private void LoadProductsWithoutStorage()
        {
            var productsWithoutStorage = Storage.products.Where(p => p.WarehouseName == "No Warehouse").ToList();
            foreach (var product in productsWithoutStorage)
            {
                // اضافه کردن خود محصول به چک ‌لیست ‌باکس
                chkProductsWithoutStorage.Items.Add(product);
            }
        }

        //فراخوانی تابع ثبت انبار
        private void btnAddWarehouse_Click(object sender, EventArgs e)
        {
            //ورودی های فرم را چک میکند
            var formCheck = CheckFormData();
            //بررسی درست وارد شدن اطلاعات 
            if (formCheck.isChecked == false)
            {
                MessageBox.Show("اطلاعات را به درستی وارد کنید");
                return;
            }
            else
            {
                //تعریف انبار جدید
                newWarehouse = new Warehouse(name:formCheck.name,location:formCheck.address,isAcive:formCheck.isActive);
                //اضافه کردن محصولات انتخاب شده به انبار جدید
                foreach (var item in chkProductsWithoutStorage.CheckedItems)
                {
                    if (item is Product product)
                    {
                        product.Warehouse = newWarehouse;
                    }
                }
                //اضافه کردن انبار جدید به لیست انبارها
                Storage.warehouses.Add(newWarehouse);

                //نمایش پیغام
                MessageBox.Show($"انبار {formCheck.name} با موفقیت ثبت شد.");

                //ریست کردن فرم و بروزرسلانی کالاها
                ResetForm();
                
            }
        }

        //تعریف تابعی از نوع tuple
        private (bool isChecked,string name,string address, bool isActive) CheckFormData()
        {
            string name ;
            string address;
            bool isActive=false;

            if (rdoActive.Checked)
            { isActive = true; }
           else if (rdoDisactive.Checked)
            { isActive = false; }
            else
            { MessageBox.Show("لطفا وضعیت انبار را مشخص کنید");}

            if (string.IsNullOrEmpty(txtWarehouseName.Text) && string.IsNullOrEmpty(txtWarehouseAddress.Text))   
            {
                MessageBox.Show("نام و آدرس انبار را وارد کنید.");
                name = string.Empty;
                address = string.Empty;
                return (isChecked: false, name: name, address: address,isActive:isActive);
            }
            else
            {
               name = txtWarehouseName.Text.ToLower().Trim();
               address = txtWarehouseAddress.Text;
               return (isChecked: true, name: name, address: address, isActive: isActive);
            }
        }

        //تابع ریست کردن فرم
        private void ResetForm()
        {
            txtWarehouseName.Text = string.Empty;
            txtWarehouseAddress.Text = string.Empty;
            rdoActive.Checked = false;
            rdoDisactive.Checked = false;
            chkProductsWithoutStorage.Items.Clear();
            LoadProductsWithoutStorage();
        }
    }
}
