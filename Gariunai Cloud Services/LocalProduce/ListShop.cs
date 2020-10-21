using System;
using System.Drawing;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend.Entities;
using Gariunai_Cloud_Services.SpecificShop;

namespace Gariunai_Cloud_Services.LocalProduce
{
    public partial class ListShop : UserControl
    {
        private readonly Form _parentForm;
        private Shop _business;

        private Image _icon;

        public ListShop(Form parentForm)
        {
            _parentForm = parentForm;
            InitializeComponent();
        }

        public Image Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                ListShopImg.Image = value;
            }
        }

        public Shop Shop
        {
            get => _business;
            set
            {
                _business = value;
                ListShopDesc.Text = value.Description;
                ListShopOwner.Text = value.Owner.Name;
                ListShopTitle.Text = value.Name;
            }
        }

        public void ListShop_Click(object sender, EventArgs e)
        {
            _parentForm.Hide();
            Form specificShopForm = new SpecificShopForm(_parentForm, Shop);
            specificShopForm.Show();
        }
    }
}