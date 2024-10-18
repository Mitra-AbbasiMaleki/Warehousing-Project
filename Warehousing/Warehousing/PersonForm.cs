#nullable disable
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehousing.Utilities;
using BaseBackend.Entities;
using Warehousing.DTOs;
using BaseBackend.Enums;

namespace Warehousing
{
    public partial class PersonForm : Form
    {
        List<Customer> Customers;
        List<Supplier> Suppliers;
        List<SysetmUser> SystemUsers;
        public PersonForm()
        {
            //Initial Value Form
            Customers = new List<Customer>();
            Suppliers = new List<Supplier>();
            SystemUsers = new List<SysetmUser>();
            SysetmUser Admin = new SysetmUser(role: UserRole.ADMIN, firstName: "mitra", lastName: "abbasi", nationalCode: "5310111107", phoneNumber: "09123456789", address: "tehran");
            SysetmUser User = new SysetmUser(role: UserRole.USER, firstName: "elham", lastName: "maleki", nationalCode: "7078184262", phoneNumber: "09987654321", address: "karaj");
            Customer customer1 = new Customer(role: UserRole.CUSTOMER, firstName: "ali", lastName: "alavi", nationalCode: "4320101014", phoneNumber: "09123456789", address: "esfahan");
            Customer customer2 = new Customer(role: UserRole.CUSTOMER, firstName: "reza", lastName: "rezaee", nationalCode: "0295255684", phoneNumber: "09187664321", address: "tabriz");
            Supplier supplier1 = new Supplier(role: UserRole.SUPPLIER, companyName: "kaleh", firstName: "ahmad", lastName: "ahmadi", nationalCode: "1971614866", phoneNumber: "09363636363", address: "hamadan");
            Supplier supplier2 = new Supplier(role: UserRole.SUPPLIER, companyName: "LG", firstName: "taha", lastName: "moradi", nationalCode: "0937955027", phoneNumber: "09854565352", address: "shiraz");
            SystemUsers.Add(Admin);
            SystemUsers.Add(User);
            Customers.Add(customer1);
            Customers.Add(customer2);
            Suppliers.Add(supplier1);
            Suppliers.Add(supplier2);
            InitializeComponent();
        }
        private void btnCustomerRegister_Click(object sender, EventArgs e)
        {
            //call validation
            if (!ISValidateRegistrationForm())
                return;
            //Validate FullName
            if (!CleanData.IsValidName(txtFirstName.Text))
            {
                MessageBox.Show("نام را درست وارد کنید");
                txtNationalCode.Text = string.Empty;
            }
            if (!CleanData.IsValidName(txtLastName.Text))
            {
                MessageBox.Show("نام خانوادگی را درست وارد کنید");
                txtNationalCode.Text = string.Empty;
            }
            if (!CleanData.IsValidNationalCode(txtNationalCode.Text))
            {
                MessageBox.Show("کد ملی نامعتبراست");
                txtNationalCode.Text = string.Empty;
            }
            
            //Add Person
            UserRole RoleSelected = (UserRole)cmbUserRole.SelectedItem;
            AddPerson addPerson = new AddPerson()
            {
                Role = RoleSelected,
                FirstName = txtFirstName.Text.CleanName(),
                LastName = txtLastName.Text.CleanName(),
                NationalCode = txtNationalCode.Text,
                PhoneNumber = txtPhoneNumber.Text.CleanPhoneNumber(),
                Address = txtProvince.Text + " " + txtCity.Text + " " + txtStreet.Text + " " + txtNumber.Text,
                CompanyName = txtCompanyName.Text,
            };
            
            AddPerson(addPerson);
            //Message
            MessageBox.Show("مشتری با موفقیت ثبت شد");
            //Reset
            ResetCustomerForm();
        }
        public void AddPerson(AddPerson addPerson)
        {
            //CreatObject
            switch (cmbUserRole.SelectedIndex)
            {
                case 1:
                case 2:
                    SysetmUser systemUser = new SysetmUser(role:addPerson.Role,firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    break;
                case 3:
                    Customer customer = new Customer(role: addPerson.Role, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Customers.Add(customer);
                    break;
                case 4:
                    Supplier supplier=new Supplier(role: addPerson.Role, companyName:addPerson.CompanyName, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Suppliers.Add(supplier);
                    break;
                default:
                    MessageBox.Show("لطفاعنوان راانتخاب کنید.");
                    return;
            } 
            
            this.Close();

        }
        private bool ISValidateRegistrationForm()
        {
            if (string.IsNullOrEmpty(txtFirstName.Text) ||
                string.IsNullOrEmpty(txtLastName.Text) ||
                string.IsNullOrEmpty(txtNationalCode.Text))
            {
                MessageBox.Show("لطفا فیلدهای ضروری را پر کنید.");
                return false;
            }
            else
                return true;
        }
        private void ResetCustomerForm()
        {
            cmbUserRole.SelectedIndex = 0;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalCode.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtProvince.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtStreet.Text = string.Empty;
            txtNumber.Text = string.Empty;
        }

        private void PersonForm_Load(object sender, EventArgs e)
        {
            cmbUserRole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbUserRole.SelectedIndex == 4)
            {
                txtCompanyName.Enabled = true;
            }
        }
    }
}
