namespace Warehousing
{
    partial class MainForm
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
            this.btnNewCustomer = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewCustomer
            // 
            this.btnNewCustomer.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewCustomer.Location = new System.Drawing.Point(429, 37);
            this.btnNewCustomer.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewCustomer.Name = "btnNewCustomer";
            this.btnNewCustomer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewCustomer.Size = new System.Drawing.Size(141, 88);
            this.btnNewCustomer.TabIndex = 0;
            this.btnNewCustomer.Text = "مشتری جدید";
            this.btnNewCustomer.UseVisualStyleBackColor = true;
            this.btnNewCustomer.Click += new System.EventHandler(this.btnNewCustomer_Click);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewProduct.Location = new System.Drawing.Point(262, 37);
            this.btnNewProduct.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewProduct.Size = new System.Drawing.Size(141, 88);
            this.btnNewProduct.TabIndex = 0;
            this.btnNewProduct.Text = "کالای جدید";
            this.btnNewProduct.UseVisualStyleBackColor = true;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnNewOrder.Location = new System.Drawing.Point(97, 37);
            this.btnNewOrder.Margin = new System.Windows.Forms.Padding(4);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewOrder.Size = new System.Drawing.Size(141, 88);
            this.btnNewOrder.TabIndex = 0;
            this.btnNewOrder.Text = "سفارش جدید";
            this.btnNewOrder.UseVisualStyleBackColor = true;
            this.btnNewOrder.Click += new System.EventHandler(this.btnNewOrder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 413);
            this.Controls.Add(this.btnNewCustomer);
            this.Controls.Add(this.btnNewProduct);
            this.Controls.Add(this.btnNewOrder);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "صفحه اصلی";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewCustomer;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Button btnNewOrder;
    }
}