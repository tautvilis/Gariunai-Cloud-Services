using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

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
            _user = DatabaseHelper.GetUserById(LoginInfo.UserID);
            foreach (Shop shop in _user.Businesses)
            {
                listViewShops.Items.Add(shop.Name);
            }
        }
        private void UserShopsForm_Load(object sender, EventArgs e)
        {
           
        }

        private void UserShopsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parentForm.Show();
        }

        private void buttonNewShop_Click(object sender, EventArgs e)
        {
            if(!_editingNewShop)
            {
                _editingNewShop = true;
                _selectedShop = "";
                buttonNewShop.Hide();
                ClearAllTexts();
            }
        }

        private void ClearAllTexts()
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
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
            Shop shop = new Shop()
            {
                Name = textBoxShopName.Text,
                Description = textBoxShortDescription.Text,
                Produce = new List<Produce>(){ }
            };

            foreach(ListViewItem product in listViewProducts.Items)
            {
                shop.Produce.Add(new Produce() { Name = product.Text });
            }

            return shop;
        }

        private void buttonSaveShop_Click(object sender, EventArgs e)
        {
            if (_editingNewShop)
            {
                Shop newShop = new Shop()
                {
                    Name = textBoxShopName.Text,
                    Description = textBoxShortDescription.Text
                };

                bool registrationSuccessfull = DatabaseHelper.RegisterShop(newShop, _user.Name);
                if(registrationSuccessfull)
                {
                    _selectedShop = newShop.Name;
                    _editingNewShop = false;
                    ReloadInfo();
                    buttonNewShop.Show();
                }
            }
            else 
            {
                DataAccess da = new DataAccess();
                da.Attach(_user);

                var newShop = GatherShopData();
                var oldShop = _user.Businesses.FirstOrDefault(b => b.Name == _selectedShop);
                oldShop.Name = newShop.Name;
                oldShop.Description = newShop.Description;
                oldShop.Produce = newShop.Produce;
                Debug.WriteLine(_user.Businesses[0].Produce.Count);

                da.SaveChanges();

                _selectedShop = newShop.Name;
                ReloadInfo();
            }
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
