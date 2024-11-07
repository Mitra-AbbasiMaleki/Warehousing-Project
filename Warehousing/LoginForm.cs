using BaseBackend.Entities;
using BaseBackend.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Warehousing.Utilities;

namespace Warehousing
{
    public partial class LoginForm : Form
    {
        List<UserLogin> Users;
        UserRole selectedRole;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginSuccess = false;
            string selectedUsername = txtUserName.Text.ToLower().Trim();
            string selectedPassword = txtPassword.Text;
            if (cmbUserRole.SelectedIndex == 0)
            { 
                MessageBox.Show("لطفا سطح دسترسی را انتخاب کنید");
                return;
            }
            if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text)) return;

            loginSuccess = Users.Exists(Users => Users.UserName.ToLower() == selectedUsername && Users.Password == selectedPassword && Users.UserRole == selectedRole);
            if (loginSuccess)
            {
                
                MainForm frmMain = new MainForm();
                frmMain.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Please Enter Valid Input");
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                cmbUserRole.SelectedIndex = 0;
            }
        }


        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lbltime.Text = DateTime.Now.ToShortTimeString();

            Users = new List<UserLogin>();

            string jsonDataFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Data", "loginFile.json");
            if(File.Exists(jsonDataFilePath))
            {
                string jsonDataStr = File.ReadAllText(jsonDataFilePath);
                Users = JsonConvert.DeserializeObject<List<UserLogin>>(jsonDataStr);
            }

            //EnumExtensions.PopulateComboBoxWithEnum<UserRole>(cmbUserRole);

            foreach (UserRole userRole in Enum.GetValues(typeof(UserRole)))
            {
                cmbUserRole.Items.Add(new { Text = userRole.GetDescription(), Value = userRole });
            }
            cmbUserRole.DisplayMember = "Text";
            cmbUserRole.ValueMember = "Value";
            cmbUserRole.SelectedIndex = 0;
        }

        private void cmbUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRole = (UserRole)((dynamic)cmbUserRole.SelectedItem).Value;
        }
    }
}
