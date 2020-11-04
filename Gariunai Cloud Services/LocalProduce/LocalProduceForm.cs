using System;
using System.Device.Location;
using System.Linq;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Account;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.LocalProduce;

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
            foreach (var newShop in DatabaseHelper.GetBusinesses().Select(shop => new ListShop(this)
            {
                Shop = shop,
                Distance = ListShop.CalculateDistance(shop.Location)
            }))
            {
                flowLayoutPanel1.Controls.Add(newShop);
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form followFeedForm = new FollowFeedForm(this);
            followFeedForm.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }


        private void AccountButton_Click(object sender, EventArgs e)
        {
            Hide();
            Form accountForm = new AccountForm(this);
            accountForm.Show();
        }

        private void LocalProduceForm_Load(object sender, EventArgs e)
        {
            PopulateShops();
        }

        private void LocalProduceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}