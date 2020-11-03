using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services
{
    public partial class FollowFeedForm : Form
    {
        private readonly Form _previousForm;
        private User currentuser;
        public FollowFeedForm(Form previousForm)
        {
            InitializeComponent();
            _previousForm = previousForm;
            currentuser = DatabaseHelper.GetUserById(LoginInfo.UserId);
            PopulateFeed();
        }

        private void FollowFeedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _previousForm.Show();
        }

        private void PopulateFeed()
        {
            FlowLayoutPanel.Controls.Clear();
            foreach (var notification in DatabaseHelper.GetNotifications(currentuser))
            {
                var newPost = new ListFollow()
                {
                    Notification = notification
                };
                FlowLayoutPanel.Controls.Add(newPost);
            }
        }
        
    }
}