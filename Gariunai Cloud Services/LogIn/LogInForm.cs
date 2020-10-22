using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.LocalProduce;

namespace Gariunai_Cloud_Services.LogIn
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            usernameBox.Focus();
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.CheckIfUserExists(usernameBox.Text, passwordBox.Text))
            {
                LoginInfo.UserID = DatabaseHelper.GetUserByName(usernameBox.Text).Id;
                Form main = new LocalProduceForm();
                main.Show();
                Hide();
            }
            else
            {
                var message = "User not found";
                MessageBox.Show(message, "Error");
            }
        }

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            var createNew = new CreateNewForm();
            createNew.ShowDialog();
        }
    }
}