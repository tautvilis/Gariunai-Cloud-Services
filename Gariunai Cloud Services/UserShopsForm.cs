using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services
{
    public partial class UserShopsForm : Form
    {

        private Form _parentForm;
        private User _user;
        private String _selectedShop;
        private bool _editingNewShop;
        public UserShopsForm(Form parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;

            ReloadInfo();
        }

        private void ReloadInfo()
        {
            listViewShops.Items.Clear();
            _user = DatabaseHelper.GetUserById(LoginInfo.UserId);
            foreach (Shop shop in _user.Businesses)
            {
                listViewShops.Items.Add(shop.Name);
            }
        }

        private void UserShopsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm.Show();
        }

        private void ButtonNewShop_Click(object sender, EventArgs e)
        {
            if(!_editingNewShop)
            {
                _editingNewShop = true;
                _selectedShop = "";
                buttonNewShop.Hide();

                listViewProducts.Items.Clear();
                ClearAllTexts();
            }
        }

        private void ClearAllTexts()
        {
            foreach (TextBox tb in Controls.OfType<TextBox>())
            {
                tb.Clear();
            }
        }

        private void listViewShops_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItems = listViewShops.SelectedItems;
            if(selectedItems.Count > 0) 
            {
                _selectedShop = selectedItems[0].Text;
                UpdateFields(_user.Businesses.Find(s => s.Name == _selectedShop));
            }

            _editingNewShop = false;
            buttonNewShop.Show();
        }

        private void UpdateFields(Shop shop) 
        {
            textBoxShopName.Text = shop.Name;
            textBoxShortDescription.Text = shop.Description;

            listViewProducts.Items.Clear();
            foreach(Produce product in shop.Produce)
            {
                listViewProducts.Items.Add(product.Name);
            }
        }

        private Shop GatherShopData()
        {
            Shop shop = new Shop
            {
                Name = textBoxShopName.Text,
                Description = textBoxShortDescription.Text,
                Produce = new List<Produce>()
            };

            foreach(ListViewItem product in listViewProducts.Items)
            {
                shop.Produce.Add(new Produce { Name = product.Text });
            }

            return shop;
        }

        private void buttonSaveShop_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            da.Attach(_user);

            if (_editingNewShop)
            {
                Shop newShop = GatherShopData();
                _user.Businesses.Add(newShop);
                _editingNewShop = false;
                _selectedShop = newShop.Name;
            }
            else 
            {
                var newShop = GatherShopData();
                var oldShop = _user.Businesses.FirstOrDefault(b => b.Name == _selectedShop);
                oldShop.Name = newShop.Name;
                oldShop.Description = newShop.Description;
                oldShop.Produce = newShop.Produce;
                Debug.WriteLine(_user.Businesses[0].Produce.Count);

                _selectedShop = newShop.Name;
            }
            da.SaveChanges();
            ReloadInfo();
            buttonNewShop.Show();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            string newProduct = textBoxProduct.Text;

            if (!string.IsNullOrEmpty(newProduct))
            {
                bool alreadyExists = false;
                foreach (ListViewItem currentProduct in listViewProducts.Items)
                {
                    if (currentProduct.Text == newProduct)
                    {
                        alreadyExists = true;
                        break;
                    }
                }

                if(!alreadyExists)
                {
                    listViewProducts.Items.Add(newProduct);
                }
            }
        }
    }
}
