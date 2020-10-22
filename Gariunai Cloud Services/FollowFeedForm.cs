using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    public partial class FollowFeedForm : Form
    {
        private readonly Form previousForm;

        public FollowFeedForm(Form PreviousForm)
        {
            InitializeComponent();
            previousForm = PreviousForm;
        }

        private void FollowFeedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousForm.Show();
        }
    }
}