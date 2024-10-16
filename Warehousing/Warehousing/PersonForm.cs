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
        List<Customer> customers;
        List<Supplier> suppliers;
        public PersonForm()
        {
            //Initial Value Form
            customers = new List<Customer>();
            suppliers = new List<Supplier>();
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
                    customers.Add(customer);
                    break;
                case 4:
                    Supplier supplier=new Supplier(role: addPerson.Role, companyName:addPerson.CompanyName, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    suppliers.Add(supplier);
                    break;
                default:
                    MessageBox.Show("لطفاعنوان راانتخاب کنید.");
                    return;
            } 
            MessageBox.Show("مشتری با موفقیت ثبت شد");
            this.Close();
            //ResetCustomerForm();
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
