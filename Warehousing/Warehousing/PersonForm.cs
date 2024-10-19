#nullable disable
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehousing.Utilities;
using BaseBackend.Entities;
using Warehousing.DTOs;
using BaseBackend.Enums;
using System.Drawing;

namespace Warehousing
{
    public partial class PersonForm : Form
    {
        List<Customer> Customers;
        List<Supplier> Suppliers;
        List<SystemUser> SystemUsers;
        List<Person> Persons;
        DataGridView personDataGridView;
        public PersonForm()
        {
            //Initial Value Form
            Address address1 = new Address(province: "Tehran", city: "Tehran", street: "Azadi", number: "12");
            Address address2 = new Address(province: "Alborz", city: "Karaj", street: "Taleghani", number: "54");
            Address address3 = new Address(province: "AzarbayjaneSharghi", city: "tabriz", street: "Shahnaz", number: "78");
            Address address4 = new Address(province: "Esfahan", city: "sfahan", street: "Emam", number: "22");
            Address address5 = new Address(province: "Gilan", city: "Rasht", street: "Bahonar", number: "65");
            Address address6 = new Address(province: "Mazandaran", city: "Sari", street: "Azadi", number: "98");
            SystemUser Admin = new SystemUser(role: UserRole.ADMIN, firstName: "mitra", lastName: "abbasi", nationalCode: "5310111107", phoneNumber: "09123456789",address:address1);
            SystemUser User = new SystemUser(role: UserRole.USER, firstName: "elham", lastName: "maleki", nationalCode: "7078184262", phoneNumber: "09987654321", address: address2);
            Customer customer1 = new Customer(role: UserRole.CUSTOMER, firstName: "ali", lastName: "alavi", nationalCode: "4320101014", phoneNumber: "09123456789", address:address3);
            Customer customer2 = new Customer(role: UserRole.CUSTOMER, firstName: "reza", lastName: "rezaee", nationalCode: "0295255684", phoneNumber: "09187664321", address: address4);
            Supplier supplier1 = new Supplier(role: UserRole.SUPPLIER, companyName: "kaleh", firstName: "ahmad", lastName: "ahmadi", nationalCode: "1971614866", phoneNumber: "09363636363",address:address5);
            Supplier supplier2 = new Supplier(role: UserRole.SUPPLIER, companyName: "LG", firstName: "taha", lastName: "moradi", nationalCode: "0937955027", phoneNumber: "09854565352",address:address6);
            
            Persons = new List<Person> { Admin, User, customer1, customer2, supplier1, supplier2 };
            Customers = new List<Customer>() { customer1, customer2 };
            Suppliers = new List<Supplier>() { supplier1, supplier2 };
            SystemUsers = new List<SystemUser>() { Admin, User };

            personDataGridView = new DataGridView();
            personDataGridView.Location = new Point(12, 320);
            personDataGridView.Size = new Size(1000, 200);
            this.Controls.Add(personDataGridView);
            personDataGridView.AutoGenerateColumns = true;
            personDataGridView.DataSource = null;
            personDataGridView.DataSource = Persons;
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
            Address address = new Address()
            { Province = txtProvince.Text,
                City = txtCity.Text,
                Street = txtStreet.Text,
                Number = txtNumber.Text
            };
            AddPerson addPerson = new AddPerson()
            {
                Role = RoleSelected,
                FirstName = txtFirstName.Text.CleanName(),
                LastName = txtLastName.Text.CleanName(),
                NationalCode = txtNationalCode.Text,
                PhoneNumber = txtPhoneNumber.Text.CleanPhoneNumber(),
                Address = address, 
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
                    SystemUser systemUser = new SystemUser(role:addPerson.Role,firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Persons.Add(systemUser);
                    RefreshDataGridView(Persons);
                    break;
                case 3:
                    Customer customer = new Customer(role: addPerson.Role, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Customers.Add(customer);
                    Persons.Add(customer);
                    RefreshDataGridView(Customers);
                    break;
                case 4:
                    Supplier supplier=new Supplier(role: addPerson.Role, companyName:addPerson.CompanyName, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Suppliers.Add(supplier);
                    Persons.Add(supplier);
                    RefreshDataGridView(Suppliers);
                    break;
                default:
                    MessageBox.Show("لطفاعنوان راانتخاب کنید.");
                    return;
            } 
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
            RefreshDataGridView(Persons);
            cmbUserRole.DataSource = Enum.GetValues(typeof(UserRole));
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbUserRole.SelectedIndex)
            {
                case 1:
                case 2:
                    RefreshDataGridView(Persons); 
                    break;
                case 3:
                    RefreshDataGridView(Customers);
                    break;
                case 4:
                    txtCompanyName.Enabled = true;
                    RefreshDataGridView(Suppliers);
                    break;
                default:
                    RefreshDataGridView(Persons);
                    return;
            }
        }
        private void RefreshDataGridView<T>(List<T> list)
        {
            personDataGridView.DataSource = null;
            personDataGridView.DataSource =list;
            personDataGridView.Columns["Address"].Visible = false;

        }
    }
}
