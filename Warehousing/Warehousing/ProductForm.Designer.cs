namespace Warehousing
{
    partial class ProductForm
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
            this.grpNewPruduct = new System.Windows.Forms.GroupBox();
            this.mtxFirstQuantity = new System.Windows.Forms.MaskedTextBox();
            this.chkCentralWarehouse = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.mtxExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.lblExpiryDate = new System.Windows.Forms.Label();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblWarehous = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRial = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblProductGroup = new System.Windows.Forms.Label();
            this.cmbProductGroup = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.btnProductRegistration = new System.Windows.Forms.Button();
            this.grpNewPruduct.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNewPruduct
            // 
            this.grpNewPruduct.AutoSize = true;
            this.grpNewPruduct.Controls.Add(this.mtxFirstQuantity);
            this.grpNewPruduct.Controls.Add(this.chkCentralWarehouse);
            this.grpNewPruduct.Controls.Add(this.txtDescription);
            this.grpNewPruduct.Controls.Add(this.txtSupplier);
            this.grpNewPruduct.Controls.Add(this.mtxExpiryDate);
            this.grpNewPruduct.Controls.Add(this.lblExpiryDate);
            this.grpNewPruduct.Controls.Add(this.lblSupplier);
            this.grpNewPruduct.Controls.Add(this.lblDescription);
            this.grpNewPruduct.Controls.Add(this.lblWarehous);
            this.grpNewPruduct.Controls.Add(this.label1);
            this.grpNewPruduct.Controls.Add(this.lblRial);
            this.grpNewPruduct.Controls.Add(this.lblQuantity);
            this.grpNewPruduct.Controls.Add(this.lblProductName);
            this.grpNewPruduct.Controls.Add(this.txtProductName);
            this.grpNewPruduct.Controls.Add(this.lblProductGroup);
            this.grpNewPruduct.Controls.Add(this.cmbProductGroup);
            this.grpNewPruduct.Controls.Add(this.lblPrice);
            this.grpNewPruduct.Controls.Add(this.txtPrice);
            this.grpNewPruduct.Controls.Add(this.lblUnit);
            this.grpNewPruduct.Controls.Add(this.cmbUnit);
            this.grpNewPruduct.Controls.Add(this.btnProductRegistration);
            this.grpNewPruduct.Location = new System.Drawing.Point(15, 30);
            this.grpNewPruduct.Margin = new System.Windows.Forms.Padding(4);
            this.grpNewPruduct.Name = "grpNewPruduct";
            this.grpNewPruduct.Padding = new System.Windows.Forms.Padding(4);
            this.grpNewPruduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpNewPruduct.Size = new System.Drawing.Size(504, 524);
            this.grpNewPruduct.TabIndex = 0;
            this.grpNewPruduct.TabStop = false;
            this.grpNewPruduct.Text = "مشخصات کالا";
            // 
            // mtxFirstQuantity
            // 
            this.mtxFirstQuantity.Location = new System.Drawing.Point(236, 148);
            this.mtxFirstQuantity.Mask = "00000";
            this.mtxFirstQuantity.Name = "mtxFirstQuantity";
            this.mtxFirstQuantity.Size = new System.Drawing.Size(107, 27);
            this.mtxFirstQuantity.TabIndex = 3;
            // 
            // chkCentralWarehouse
            // 
            this.chkCentralWarehouse.AutoSize = true;
            this.chkCentralWarehouse.Location = new System.Drawing.Point(236, 241);
            this.chkCentralWarehouse.Name = "chkCentralWarehouse";
            this.chkCentralWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCentralWarehouse.Size = new System.Drawing.Size(102, 23);
            this.chkCentralWarehouse.TabIndex = 6;
            this.chkCentralWarehouse.Text = "انبار مرکزی";
            this.chkCentralWarehouse.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(58, 381);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(284, 27);
            this.txtDescription.TabIndex = 9;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Location = new System.Drawing.Point(131, 332);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Size = new System.Drawing.Size(211, 27);
            this.txtSupplier.TabIndex = 8;
            // 
            // mtxExpiryDate
            // 
            this.mtxExpiryDate.Location = new System.Drawing.Point(185, 283);
            this.mtxExpiryDate.Mask = "00/00/0000";
            this.mtxExpiryDate.Name = "mtxExpiryDate";
            this.mtxExpiryDate.Size = new System.Drawing.Size(158, 27);
            this.mtxExpiryDate.TabIndex = 7;
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.AutoSize = true;
            this.lblExpiryDate.Location = new System.Drawing.Point(349, 283);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(88, 19);
            this.lblExpiryDate.TabIndex = 10;
            this.lblExpiryDate.Text = "تاریخ انقضا :";
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(349, 335);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(102, 19);
            this.lblSupplier.TabIndex = 12;
            this.lblSupplier.Text = " تامین کننده :";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(349, 384);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(78, 19);
            this.lblDescription.TabIndex = 15;
            this.lblDescription.Text = "توضیحات :";
            // 
            // lblWarehous
            // 
            this.lblWarehous.AutoSize = true;
            this.lblWarehous.Location = new System.Drawing.Point(349, 238);
            this.lblWarehous.Name = "lblWarehous";
            this.lblWarehous.Size = new System.Drawing.Size(45, 19);
            this.lblWarehous.TabIndex = 18;
            this.lblWarehous.Text = "انبار :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "قسمت های ستاره دار حتما باید پر شود";
            // 
            // lblRial
            // 
            this.lblRial.AutoSize = true;
            this.lblRial.Location = new System.Drawing.Point(96, 197);
            this.lblRial.Name = "lblRial";
            this.lblRial.Size = new System.Drawing.Size(34, 19);
            this.lblRial.TabIndex = 9;
            this.lblRial.Text = "ریال";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(349, 151);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(105, 19);
            this.lblQuantity.TabIndex = 3;
            this.lblQuantity.Text = "* مقدار اولیه :";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Location = new System.Drawing.Point(349, 72);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(80, 19);
            this.lblProductName.TabIndex = 0;
            this.lblProductName.Text = "* نام کالا :";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(58, 69);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(285, 27);
            this.txtProductName.TabIndex = 1;
            // 
            // lblProductGroup
            // 
            this.lblProductGroup.AutoSize = true;
            this.lblProductGroup.Location = new System.Drawing.Point(349, 110);
            this.lblProductGroup.Name = "lblProductGroup";
            this.lblProductGroup.Size = new System.Drawing.Size(92, 19);
            this.lblProductGroup.TabIndex = 0;
            this.lblProductGroup.Text = "* گروه کالا :";
            // 
            // cmbProductGroup
            // 
            this.cmbProductGroup.FormattingEnabled = true;
            this.cmbProductGroup.Location = new System.Drawing.Point(58, 107);
            this.cmbProductGroup.Name = "cmbProductGroup";
            this.cmbProductGroup.Size = new System.Drawing.Size(285, 27);
            this.cmbProductGroup.TabIndex = 2;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(349, 194);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(108, 19);
            this.lblPrice.TabIndex = 7;
            this.lblPrice.Text = "* قیمت خرید :";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(184, 191);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(159, 27);
            this.txtPrice.TabIndex = 5;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(166, 153);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(51, 19);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "واحد :";
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(58, 148);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(102, 27);
            this.cmbUnit.TabIndex = 4;
            // 
            // btnProductRegistration
            // 
            this.btnProductRegistration.Location = new System.Drawing.Point(28, 438);
            this.btnProductRegistration.Margin = new System.Windows.Forms.Padding(4);
            this.btnProductRegistration.Name = "btnProductRegistration";
            this.btnProductRegistration.Size = new System.Drawing.Size(468, 54);
            this.btnProductRegistration.TabIndex = 10;
            this.btnProductRegistration.Text = "ثبت کالا";
            this.btnProductRegistration.UseVisualStyleBackColor = true;
            this.btnProductRegistration.Click += new System.EventHandler(this.btnProductRegistration_Click);
            // 
            // ProductForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 563);
            this.Controls.Add(this.grpNewPruduct);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ProductForm";
            this.Text = "فرم تعریف کالای جدید";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            this.grpNewPruduct.ResumeLayout(false);
            this.grpNewPruduct.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNewPruduct;
        private System.Windows.Forms.Label lblProductGroup;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.ComboBox cmbProductGroup;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblRial;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.MaskedTextBox mtxExpiryDate;
        private System.Windows.Forms.Label lblExpiryDate;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnProductRegistration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWarehous;
        private System.Windows.Forms.CheckBox chkCentralWarehouse;
        private System.Windows.Forms.MaskedTextBox mtxFirstQuantity;
    }
}