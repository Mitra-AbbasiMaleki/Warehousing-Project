using BaseBackend.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Warehousing
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            cmbProductGroup.DataSource = Enum.GetValues(typeof(ProductCategory));
            cmbUnit.DataSource = Enum.GetValues(typeof(MeasurementUnit));
        }

        private void btnProductRegistration_Click(object sender, EventArgs e)
        {

        }
    }
}
