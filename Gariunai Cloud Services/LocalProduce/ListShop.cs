using System;
using System.Device.Location;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
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

        private static double _latitude;
        private static double _longitude;


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

        struct Coords
        {
            private Coords(double lng, double lat)
            {
                longitude = lng;
                latitude = lat;
            }

            public double longitude { get; set; }
            public double latitude { get; set; }
        }


        public static string CalculateDistance(string address)
        {
            var coordinates = Coordinates.GetDistance(address);
            var shopCoords = new Coords();
            var userCoords = new Coords();
            if (coordinates != null && coordinates.Length != 0)
            {

                shopCoords.latitude = coordinates[0];
                shopCoords.longitude = coordinates[1];

                userCoords.latitude = coordinates[2];
                userCoords.longitude = coordinates[3];
                _latitude = shopCoords.latitude;
                _longitude = shopCoords.longitude;

                var sCoords = new GeoCoordinate(shopCoords.latitude, shopCoords.longitude);
                var uCoords = new GeoCoordinate(userCoords.latitude, userCoords.longitude);
                var distance = sCoords.GetDistanceTo(uCoords) / 1000;
                return String.Format("{0:0.00} km", distance);
            }
            else
            {
                return "0 km";
            }

        }


        private void ListShop_Click(object sender, EventArgs e)
        {
            _parentForm.Hide();
            Form specificShopForm = new SpecificShopForm(_parentForm, Shop, _longitude, _latitude);
            specificShopForm.Show();
        }

    }
}