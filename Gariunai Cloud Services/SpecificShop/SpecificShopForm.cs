using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;
using Gariunai_Cloud_Services.LocalProduce;
namespace Gariunai_Cloud_Services.SpecificShop
{
    public partial class SpecificShopForm : Form
    {
        private readonly Form _previousForm;
        private double _latitude;
        private double _longitude;
        private Shop _shop;
        

        public SpecificShopForm(Form previousForm, Shop shop, double lng, double lat)
        {
            InitializeComponent();
            _previousForm = previousForm;
            _shop = shop;
            _latitude = lat;
            _longitude = lng;
            shopDescription.Text = shop.Description;
            //pictureBox1.Image = shop.Image;
            foreach (var produce in shop.Produce) productList.Items.Add(produce.Name);
            _updateView();
            SetFollowerLabel();
        }

        private void SpecificShopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _previousForm.Show();
            Hide();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            _previousForm.Show();
            Hide();
        }


        private void FollowBtn_Click(object sender, EventArgs e)
        {
            DatabaseHelper.ChangeFollowStatus(LoginInfo.UserId, _shop.Id);
            _shop = DatabaseHelper.GetShopById(_shop.Id);
            _updateView();
            SetFollowerLabel();
        }

        private void _updateView()
        {
            followBtn.Text = DatabaseHelper.GetFollowStatus(LoginInfo.UserId, _shop.Id) ? "UNFOLLOW" : "FOLLOW";
        }

        private void SetFollowerLabel()
        {
            label2.Text = DatabaseHelper.GetFollowers(_shop).ToString();
        }
    }
}