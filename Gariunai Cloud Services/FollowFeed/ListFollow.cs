using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services
{
    public partial class ListFollow : UserControl
    {
        private Notification _notification;
        public Notification Notification
        {
            get => _notification;
            set
            {
                _notification = value;
                LabelNotificationText.Text = value.Description;
                LabelNotificationTitle.Text = value.Title;
                LabelShopName.Text = DatabaseHelper.GetShopById(value.ShopId).Name;
            }
        }

        public ListFollow()
        {
            InitializeComponent();
        }
    }
}