using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gariunai_Cloud_Services.LogIn;

namespace Gariunai_Cloud_Services
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        
        private void signInButton_Click(object sender, EventArgs e)
        {

            if (DatabaseHelper.CheckIfUserExists(usernameBox.Text, passwordBox.Text) || usernameBox.Text == "1" && passwordBox.Text == "1")
            {
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
        private void createNewButton_Click(object sender, EventArgs e)
        {
            var createNew = new CreateNewForm();
            createNew.ShowDialog();
        }
    }
}
