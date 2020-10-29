using System;
using System.Drawing;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services.LocalProduce
{
    public partial class ListShop : UserControl
    {
        private Form _parentForm;

        public ListShop(Form parentForm)
        {
            _parentForm = parentForm;
            InitializeComponent();
        }

        private Image _icon;
        private Shop _business;
        private string _distance;

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

        public string Distance
        {
            get => _distance;
            set
            {
                _distance = value;
                ListShopDistance.Text = value;
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