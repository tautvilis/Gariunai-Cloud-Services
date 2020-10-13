using Gariunai_Cloud_Services.Entities;
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
        private Form _previousForm;

        public SpecificShopForm(Form previousForm, Shop shop)
        {
            InitializeComponent();
            _previousForm = previousForm;
            shopDescription.Text = shop.Description;
            //pictureBox1.Image = shop.Image;
            foreach (var produce in shop.Produce)
            {
                productList.Items.Add(produce.Name);
            }
        }

        private void SpecificShopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            _previousForm.Show();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            Hide();
            _previousForm.Show();
        }
    }
}
