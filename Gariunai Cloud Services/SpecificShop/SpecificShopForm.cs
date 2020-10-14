using Gariunai_Cloud_Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
            Hide();
            _previousForm.Show();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            Hide();
            _previousForm.Show();
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
