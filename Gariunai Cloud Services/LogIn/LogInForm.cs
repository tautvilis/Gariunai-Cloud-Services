using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.LogIn;

namespace Gariunai_Cloud_Services
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        
        private void SignInButton_Click(object sender, EventArgs e)
        {

            if (DatabaseHelper.CheckIfUserExists(usernameBox.Text, passwordBox.Text))
            {
                LoginInfo.UserID = DatabaseHelper.GetUserByName(usernameBox.Text).Id;
                Form main = new LocalProduceForm();
                main.Show();
                this.Hide();
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
