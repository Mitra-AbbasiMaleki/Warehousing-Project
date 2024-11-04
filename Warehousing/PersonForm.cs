#nullable disable
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Warehousing.Utilities;
using BaseBackend.Entities;
using Warehousing.DTOs;
using BaseBackend.Enums;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ComponentModel;

namespace Warehousing
{
    public partial class PersonForm : Form
    {
        AddressTitle selectedTitle;
        public PersonForm()
        {
            InitializeComponent();
        }
        private void btnCustomerRegister_Click(object sender, EventArgs e)
        {
            //call validation
            if (!ISValidateRegistrationForm())
                return;

            //Add Person
            UserRole RoleSelected = (UserRole)cmbUserRole.SelectedIndex;
            Address address = new Address()
            {
                Title = selectedTitle,
                Province = txtProvince.Text,
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
            if (cmbUserRole.SelectedIndex == 0)
            {
                MessageBox.Show("لطفاعنوان راانتخاب کنید.");
            }
            else
            {
                AddPerson(addPerson);
                //Message
                MessageBox.Show("مشتری با موفقیت ثبت شد");
                //Reset
                ResetCustomerForm();
            }
        }
        public void AddPerson(AddPerson addPerson)
        {
            //CreatObject
            switch (cmbUserRole.SelectedIndex)
            {
                case 1:
                case 2:
                    Person systemUser = new SystemUser(role: addPerson.Role, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Storage.People.Add(systemUser);
                    RefreshDataGridView(Storage.People.OfType<SystemUser>().ToList());
                    break;
                case 3:
                    Person customer = new Customer(role: addPerson.Role, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Storage.People.Add(customer);
                    Storage.People.Add(customer);
                    RefreshDataGridView(Storage.People.OfType<Customer>().ToList());
                    break;
                case 4:
                    Person supplier = new Supplier(role: addPerson.Role, companyName: addPerson.CompanyName, firstName: addPerson.FirstName, lastName: addPerson.LastName, nationalCode: addPerson.NationalCode, phoneNumber: addPerson.PhoneNumber, address: addPerson.Address);
                    Storage.People.Add(supplier);
                    Storage.People.Add(supplier);
                    RefreshDataGridView(Storage.People.OfType<Supplier>().ToList());
                    break;
                default:
                    MessageBox.Show("لطفاعنوان راانتخاب کنید.");
                    return;
            }
        }
        private bool ISValidateRegistrationForm()
        {
            //Validate FirstName
            if (string.IsNullOrEmpty(txtFirstName.Text) || !CleanData.IsValidName(txtFirstName.Text))
            {
                MessageBox.Show("لطفا نام را درست وارد کنید");
                txtNationalCode.Text = string.Empty;
                return false;
            }
            //Validate LastName
            if (string.IsNullOrEmpty(txtLastName.Text) || !CleanData.IsValidName(txtLastName.Text))
            {
                MessageBox.Show("لطفا نام خانوادگی را درست وارد کنید");
                txtNationalCode.Text = string.Empty;
                return false;
            }
            //Validate NationalCode
            if (string.IsNullOrEmpty(txtNationalCode.Text) || !CleanData.IsValidNationalCode(txtNationalCode.Text))
            {
                MessageBox.Show("لطفا کد ملی  را درست وارد کنید");
                txtNationalCode.Text = string.Empty;
                return false;
            }
            //Validate User Role
            if (cmbUserRole.SelectedIndex == 0)
            {
                MessageBox.Show("لطفاعنوان راانتخاب کنید");
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
            RefreshDataGridView(Storage.People);
            foreach (UserRole userRole in Enum.GetValues(typeof(UserRole)))
            {
                cmbUserRole.Items.Add(new { Text = userRole.GetDescription(), Value = userRole });
            }
            cmbUserRole.DisplayMember = "Text";
            cmbUserRole.ValueMember = "Value";
            cmbUserRole.SelectedIndex = 0;
            //cmbUserRole.DataSource = Enum.GetValues(typeof(UserRole));
            rdoHome.Text=AddressTitle.HOME.GetDescription();
            rdoWork.Text = AddressTitle.WORK.GetDescription();
            rdoOther.Text = AddressTitle.OTHER.GetDescription();
            rdoHome.CheckedChanged += radioButton_CheckedChanged;
            rdoWork.CheckedChanged += radioButton_CheckedChanged;
            rdoOther.CheckedChanged += radioButton_CheckedChanged;

        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Person> newList = new List<Person>();
            switch (cmbUserRole.SelectedIndex)
            {
                case 1:
                case 2:
                    txtCompanyName.Enabled = false;
                    RefreshDataGridView(Storage.People);
                    break;
                case 3:
                    txtCompanyName.Enabled = false;
                    RefreshDataGridView(Storage.People);
                    break;
                case 4:
                    txtCompanyName.Enabled = true;
                    RefreshDataGridView(Storage.People);
                    break;
                default:
                    txtCompanyName.Enabled = false;
                    RefreshDataGridView(Storage.People);
                    return;
            }
        }
        private void RefreshDataGridView<T>(List<T> list)
        {
            personDataGridView.DataSource = null;
            personDataGridView.DataSource = list;
            personDataGridView.Refresh();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                // با توجه به نام رادیو باتن، مقدار enum را مشخص کنید
                switch (radioButton.Name)
                {
                    case "rdoHome":
                        selectedTitle = AddressTitle.HOME;
                        break;
                    case "rdoWork":
                        selectedTitle = AddressTitle.WORK;
                        break;
                    case "rdoOther":
                        selectedTitle = AddressTitle.OTHER;
                        break;
                    default:
                        return; // اگر هیچ کدام نبود، خارج می‌شود
                }
            }
        }

    }
}
