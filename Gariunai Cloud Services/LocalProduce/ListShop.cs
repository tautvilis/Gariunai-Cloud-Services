using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services.LocalProduce
{
    public partial class ListShop : UserControl
    {
        public ListShop()
        {
            InitializeComponent();
        }

        private string _title;
        private string _description;
        private Image _icon;

        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value;
                ListShopTitle.Text = value;
            }
        }

        [Category("Custom Props")]
        public string Description
        {
            get { return _description; }
            set {
                _description = value;
                ListShopDesc.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value;
                ListShopImg.Image = value;
            }
        }

        public void ListShop_Click(object sender, EventArgs e)
        {
            LocalProduceForm.OpenSpecificForm();
        }

    }
}
