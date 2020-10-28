using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services
{
    public partial class ListFollow : UserControl
    {
        private Notification _post;
        public ListFollow()
        {
            InitializeComponent();
        }
        public Notification Notification
        {
            get => _post;
            set
            {
                _post = value;
                descriptionLabel.Text = value.Description;
                titleLabel.Text = value.Title;
            }
        }
    }
}