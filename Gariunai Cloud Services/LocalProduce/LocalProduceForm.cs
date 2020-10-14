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
using Gariunai_Cloud_Services.Entities;
using Gariunai_Cloud_Services.LocalProduce;
using Microsoft.CSharp;
using Microsoft.VisualBasic;

namespace Gariunai_Cloud_Services
{
    public partial class LocalProduceForm : Form
    {

        
        public LocalProduceForm()
        {
            InitializeComponent();
            PopulateShops();
        }

        private void PopulateShops()
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var shop in DatabaseHelper.GetBusinesses())
            {

                ListShop newShop = new ListShop(this)
                {
                    Shop = shop
                };
                flowLayoutPanel1.Controls.Add(newShop);
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


        private void accountButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form accountForm = new AccountForm(this);
            accountForm.Show();
        }

        private void LocalProduceForm_Load(object sender, EventArgs e)
        {
            PopulateShops();
        }

        private void LocalProduceForm_Activated(object sender, EventArgs e)
        {
            PopulateShops();
        }
    }
}
