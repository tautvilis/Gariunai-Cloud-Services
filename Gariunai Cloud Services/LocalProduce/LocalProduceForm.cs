using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gariunai_Cloud_Services.LocalProduce;
using Microsoft.VisualBasic;

namespace Gariunai_Cloud_Services
{
    public partial class LocalProduceForm : Form
    {
        public LocalProduceForm()
        {
            InitializeComponent();
            populateShops();
        }

        private void populateShops()
        {
            ListShop[] listShops = new ListShop[10];

            //Change with specific DB names
            for (int i = 0; i < listShops.Length; i++)
            {
                listShops[i] = new ListShop();
                listShops[i].Title = "Local Shop Title";
                listShops[i].Description = "Local shop description";
                
                flowLayoutPanel1.Controls.Add(listShops[i]);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form followFeedForm = new FollowFeedForm(this);
            followFeedForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //public void button5_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    Form specificShopForm = new SpecificShopForm(this);
        //    specificShopForm.Show();
        //}

        private void accountButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form accountForm = new AccountForm(this);
            accountForm.Show();
        }

        public static void OpenSpecificForm()
        {
            Form specificShopForm = new SpecificShopForm();
            specificShopForm.Show();
        }

    }
}
