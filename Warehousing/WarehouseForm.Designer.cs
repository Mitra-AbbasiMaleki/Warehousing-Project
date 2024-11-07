namespace Warehousing
{
    partial class WarehouseForm
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
            this.grpNewWarehouse = new System.Windows.Forms.GroupBox();
            this.btnAddWarehouse = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoActive = new System.Windows.Forms.RadioButton();
            this.rdoDisactive = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkProductsWithoutStorage = new System.Windows.Forms.CheckedListBox();
            this.txtWarehouseAddress = new System.Windows.Forms.TextBox();
            this.txtWarehouseName = new System.Windows.Forms.TextBox();
            this.grpNewWarehouse.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpNewWarehouse
            // 
            this.grpNewWarehouse.Controls.Add(this.label3);
            this.grpNewWarehouse.Controls.Add(this.chkProductsWithoutStorage);
            this.grpNewWarehouse.Controls.Add(this.panel1);
            this.grpNewWarehouse.Controls.Add(this.label4);
            this.grpNewWarehouse.Controls.Add(this.btnAddWarehouse);
            this.grpNewWarehouse.Controls.Add(this.label2);
            this.grpNewWarehouse.Controls.Add(this.label1);
            this.grpNewWarehouse.Controls.Add(this.txtWarehouseAddress);
            this.grpNewWarehouse.Controls.Add(this.txtWarehouseName);
            this.grpNewWarehouse.Location = new System.Drawing.Point(20, 14);
            this.grpNewWarehouse.Name = "grpNewWarehouse";
            this.grpNewWarehouse.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.grpNewWarehouse.Size = new System.Drawing.Size(435, 341);
            this.grpNewWarehouse.TabIndex = 0;
            this.grpNewWarehouse.TabStop = false;
            this.grpNewWarehouse.Text = "تعریف انبار جدید";
            // 
            // btnAddWarehouse
            // 
            this.btnAddWarehouse.Location = new System.Drawing.Point(50, 269);
            this.btnAddWarehouse.Name = "btnAddWarehouse";
            this.btnAddWarehouse.Size = new System.Drawing.Size(303, 51);
            this.btnAddWarehouse.TabIndex = 7;
            this.btnAddWarehouse.Text = "ثبت انبار جدید";
            this.btnAddWarehouse.UseVisualStyleBackColor = true;
            this.btnAddWarehouse.Click += new System.EventHandler(this.btnAddWarehouse_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "وضعیت  انبار : ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoActive);
            this.panel1.Controls.Add(this.rdoDisactive);
            this.panel1.Location = new System.Drawing.Point(51, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 29);
            this.panel1.TabIndex = 6;
            // 
            // rdoActive
            // 
            this.rdoActive.AutoSize = true;
            this.rdoActive.Location = new System.Drawing.Point(178, 5);
            this.rdoActive.Name = "rdoActive";
            this.rdoActive.Size = new System.Drawing.Size(45, 19);
            this.rdoActive.TabIndex = 4;
            this.rdoActive.TabStop = true;
            this.rdoActive.Text = "فعال";
            this.rdoActive.UseVisualStyleBackColor = true;
            // 
            // rdoDisactive
            // 
            this.rdoDisactive.AutoSize = true;
            this.rdoDisactive.Location = new System.Drawing.Point(55, 5);
            this.rdoDisactive.Name = "rdoDisactive";
            this.rdoDisactive.Size = new System.Drawing.Size(62, 19);
            this.rdoDisactive.TabIndex = 5;
            this.rdoDisactive.TabStop = true;
            this.rdoDisactive.Text = "غیرفعال";
            this.rdoDisactive.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "لیست محصولات انبار :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(293, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "آدرس انبار :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام انبار : ";
            // 
            // chkProductsWithoutStorage
            // 
            this.chkProductsWithoutStorage.FormattingEnabled = true;
            this.chkProductsWithoutStorage.Location = new System.Drawing.Point(51, 141);
            this.chkProductsWithoutStorage.Name = "chkProductsWithoutStorage";
            this.chkProductsWithoutStorage.Size = new System.Drawing.Size(237, 112);
            this.chkProductsWithoutStorage.TabIndex = 3;
            // 
            // txtWarehouseAddress
            // 
            this.txtWarehouseAddress.Location = new System.Drawing.Point(50, 65);
            this.txtWarehouseAddress.Name = "txtWarehouseAddress";
            this.txtWarehouseAddress.Size = new System.Drawing.Size(237, 23);
            this.txtWarehouseAddress.TabIndex = 2;
            // 
            // txtWarehouseName
            // 
            this.txtWarehouseName.Location = new System.Drawing.Point(50, 26);
            this.txtWarehouseName.Name = "txtWarehouseName";
            this.txtWarehouseName.Size = new System.Drawing.Size(237, 23);
            this.txtWarehouseName.TabIndex = 1;
            // 
            // WarehouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 392);
            this.Controls.Add(this.grpNewWarehouse);
            this.Name = "WarehouseForm";
            this.RightToLeftLayout = true;
            this.Text = "WarehouseForm";
            this.grpNewWarehouse.ResumeLayout(false);
            this.grpNewWarehouse.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpNewWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkProductsWithoutStorage;
        private System.Windows.Forms.TextBox txtWarehouseAddress;
        private System.Windows.Forms.TextBox txtWarehouseName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoActive;
        private System.Windows.Forms.RadioButton rdoDisactive;
        private System.Windows.Forms.Button btnAddWarehouse;
    }
}