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
        private string _selectedShop;
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
            foreach (var shop in _user.Businesses) listViewShops.Items.Add(shop.Name);
        }

        private void UserShopsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm.Show();
        }

        private void ButtonNewShop_Click(object sender, EventArgs e)
        {
            if (!_editingNewShop)
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
            foreach (var tb in Controls.OfType<TextBox>()) tb.Clear();
        }

        private void listViewShops_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItems = listViewShops.SelectedItems;
            if (selectedItems.Count > 0)
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
            textBoxLongDescription.Text = shop.LongDescription;
            textPhoneNumber.Text = shop.Contacts;
            textAdress.Text = shop.Location;
            listViewProducts.Items.Clear();
            foreach (var product in shop.Produce) listViewProducts.Items.Add(product.Name);
        }

        private Shop GatherShopData()
        {
            var shop = new Shop
            {
                Name = textBoxShopName.Text,
                Description = textBoxShortDescription.Text,
                Produce = new List<Produce>(),
                LongDescription = textBoxLongDescription.Text,
                Location = textAdress.Text,
                Contacts = textPhoneNumber.Text
            };

            foreach (ListViewItem product in listViewProducts.Items)
                shop.Produce.Add(new Produce {Name = product.Text});

            return shop;
        }

        private void buttonSaveShop_Click(object sender, EventArgs e)
        {
            var da = new DataAccess();
            var updatedShop = GatherShopData();
            
            da.Attach(_user);

            if (_editingNewShop)
            {
                _user.Businesses.Add(updatedShop);
                _selectedShop = updatedShop.Name;
                _editingNewShop = false;
            }
            else
            {
                var oldShop = _user.Businesses.FirstOrDefault(b => b.Name == _selectedShop);
                oldShop.Name = updatedShop.Name;
                oldShop.Description = updatedShop.Description;
                oldShop.Produce = updatedShop.Produce;
                oldShop.Contacts = updatedShop.Contacts;
                oldShop.LongDescription = updatedShop.Description;
                oldShop.Location = updatedShop.Location;

                _selectedShop = updatedShop.Name;
            }

            da.SaveChanges();
            ReloadInfo();
            buttonNewShop.Show();
        }

        private void buttonAddProduct_Click(object sender, EventArgs e)
        {
            var newProduct = textBoxProduct.Text;

            if (string.IsNullOrEmpty(newProduct)) return;
            
            var alreadyExists = listViewProducts.Items.Cast<ListViewItem>()
                .Any(currentProduct => currentProduct.Text == newProduct);

            if (!alreadyExists)
            {
                listViewProducts.Items.Add(newProduct);
                textBoxProduct.Clear();
            }
        }
    }
}