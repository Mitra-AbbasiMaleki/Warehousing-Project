namespace Warehousing
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblAccesslevel = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbAccessLevel = new System.Windows.Forms.ComboBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.grpTime = new System.Windows.Forms.GroupBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.grpLogin.SuspendLayout();
            this.grpTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.lblAccesslevel);
            this.grpLogin.Controls.Add(this.lblPassword);
            this.grpLogin.Controls.Add(this.cmbAccessLevel);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.txtUserName);
            this.grpLogin.Controls.Add(this.lblUsername);
            this.grpLogin.Location = new System.Drawing.Point(12, 97);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpLogin.Size = new System.Drawing.Size(359, 248);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "اطلاعات ورود";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(44, 190);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(183, 41);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "ورود";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblAccesslevel
            // 
            this.lblAccesslevel.AutoSize = true;
            this.lblAccesslevel.Location = new System.Drawing.Point(259, 138);
            this.lblAccesslevel.Name = "lblAccesslevel";
            this.lblAccesslevel.Size = new System.Drawing.Size(83, 15);
            this.lblAccesslevel.TabIndex = 2;
            this.lblAccesslevel.Text = "سطح دسترسی :";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(259, 86);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(55, 15);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "رمز عبور :";
            // 
            // cmbAccessLevel
            // 
            this.cmbAccessLevel.FormattingEnabled = true;
            this.cmbAccessLevel.Location = new System.Drawing.Point(44, 135);
            this.cmbAccessLevel.Name = "cmbAccessLevel";
            this.cmbAccessLevel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbAccessLevel.Size = new System.Drawing.Size(183, 23);
            this.cmbAccessLevel.TabIndex = 5;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(44, 83);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(183, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.Text = "admin";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(44, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "UserName";
            this.txtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUserName.Size = new System.Drawing.Size(183, 23);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "admin";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(259, 43);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(65, 15);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "نام کاربری :";
            // 
            // grpTime
            // 
            this.grpTime.Controls.Add(this.lblDate);
            this.grpTime.Controls.Add(this.lbltime);
            this.grpTime.Location = new System.Drawing.Point(13, 13);
            this.grpTime.Name = "grpTime";
            this.grpTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpTime.Size = new System.Drawing.Size(358, 64);
            this.grpTime.TabIndex = 1;
            this.grpTime.TabStop = false;
            this.grpTime.Text = "تاریخ و زمان";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(258, 28);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(31, 15);
            this.lblDate.TabIndex = 1;
            this.lblDate.Text = "Date";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Location = new System.Drawing.Point(43, 28);
            this.lbltime.Name = "lbltime";
            this.lbltime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbltime.Size = new System.Drawing.Size(34, 15);
            this.lbltime.TabIndex = 0;
            this.lbltime.Text = "Time";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 350);
            this.Controls.Add(this.grpLogin);
            this.Controls.Add(this.grpTime);
            this.Name = "LoginForm";
            this.Text = "صفحه ورود";
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.grpTime.ResumeLayout(false);
            this.grpTime.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ComboBox cmbAccessLevel;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblAccesslevel;
        private System.Windows.Forms.GroupBox grpTime;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lblDate;
    }
}