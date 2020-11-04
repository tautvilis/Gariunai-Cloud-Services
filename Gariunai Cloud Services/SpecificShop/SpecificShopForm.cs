using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;
using Gariunai_Cloud_Services.LocalProduce;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Gariunai_Cloud_Services
{
    public partial class SpecificShopForm : Form
    {
        private readonly Form _previousForm;
        private readonly GMapOverlay _top = new GMapOverlay();
        private GMapMarker _currentMarker;
        private double _latCO;
        private double _longCO;
        private Shop _shop;
        

        public SpecificShopForm(Form previousForm, Shop shop, double lng, double lat)
        {
            InitializeComponent();
            _previousForm = previousForm;
            _shop = shop;
            _latCO = lat;
            _longCO = lng;
            shopDescription.Text = shop.Description;
            //pictureBox1.Image = shop.Image;
            foreach (var produce in shop.Produce) productList.Items.Add(produce.Name);
            Setmap();
            _updateView();
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

        private void Setmap()
        {
            MainMap.MapProvider = GMapProviders.LithuaniaMap;
            MainMap.Position = new PointLatLng(_latCO, _longCO);
            MainMap.MinZoom = 0;
            MainMap.MaxZoom = 20;
            MainMap.Zoom = 11;

            MainMap.ShowCenter = false;

            MainMap.Overlays.Add(_top);

            _currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.arrow) {IsHitTestVisible = false};
            _top.Markers.Add(_currentMarker);
        }

        private void FollowBtn_Click(object sender, EventArgs e)
        {
            DatabaseHelper.ChangeFollowStatus(LoginInfo.UserId, _shop.Id);
            _shop = DatabaseHelper.GetShopById(_shop.Id);
            _updateView();
        }

        private void _updateView()
        {
            followBtn.Text = DatabaseHelper.GetFollowStatus(LoginInfo.UserId, _shop.Id) ? "UNFOLLOW" : "FOLLOW";
        }
    }
}