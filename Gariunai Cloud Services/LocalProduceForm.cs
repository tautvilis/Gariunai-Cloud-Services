using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    public partial class LocalProduceForm : Form
    {
        public LocalProduceForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form followFeedForm = new FollowFeedForm(this);
            followFeedForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form specificShopForm = new SpecificShopForm(this);
            specificShopForm.Show();
        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form accountForm = new AccountForm(this);
            accountForm.Show();
        }
    }
}
