using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    public partial class SpecificShopForm : Form
    {
        private readonly Form previousForm;

        public SpecificShopForm(Form PreviousForm)
        {

            InitializeComponent();
            previousForm = PreviousForm;
        }

        private void SpecificShopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousForm.Show();
        }
    }
}
