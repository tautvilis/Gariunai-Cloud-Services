using System;
using System.Windows.Forms;
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
            foreach (var shop in DatabaseHelper.GetBusinesses())
            {
                ListShop newShop = new ListShop
                {
                    Title = shop.Name, Description = shop.Description, Owner = shop.Owner.Name
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

        private void LocalProduceForm_Load(object sender, EventArgs e)
        {
            PopulateShops();
        }
    }
}
