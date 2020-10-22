using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace Gariunai_Cloud_Services
{
    public partial class SpecificShopForm : Form
    {
        private Form _previousForm;

        readonly GMapOverlay _top = new GMapOverlay();
        GMapMarker _currentMarker;

        public SpecificShopForm(Form previousForm, Shop shop)
        {
            InitializeComponent();
            _previousForm = previousForm;
            shopDescription.Text = shop.Description;
            //pictureBox1.Image = shop.Image;
            foreach (var produce in shop.Produce)
            {
                productList.Items.Add(produce.Name);
            }
            Setmap();
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
            MainMap.Position = new PointLatLng(54.685740, 25.286622);
            MainMap.MinZoom = 0;
            MainMap.MaxZoom = 20;
            MainMap.Zoom = 11;

            MainMap.ShowCenter = false;

            MainMap.Overlays.Add(_top);

            _currentMarker = new GMarkerGoogle(MainMap.Position, GMarkerGoogleType.arrow) {IsHitTestVisible = false};
            _top.Markers.Add(_currentMarker);
        }
    }
}
