using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }
        
        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            if(passwordBox.Text.Length < 5)
            {
                correctPassword.Text = "Password too short.";
                correctPassword.ForeColor = Color.Red;
                correctPassword.Visible = true;
            }
            else if(passwordBox.Text.Contains(" "))
            {
                correctPassword.Text = "Password cannot contain spaces.";
                correctPassword.ForeColor = Color.Red;
                correctPassword.Visible = true;
            }
            else
            {
                correctPassword.Text = "Password strength is ok.";
                correctPassword.ForeColor = Color.Green;
                correctPassword.Visible = true;
            }

        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text.Length > 5 && !passwordBox.Text.Contains(" "))
            {
                var password = passwordBox.Text;
                var username = usernameBox.Text;
                // check username and password against DB.
                // MOVE TO LOCALPRUDEFROM
                throw new NotImplementedException();
            }
        }

        private void createNewButton_Click(object sender, EventArgs e)
        {
            if (passwordBox.Text.Length > 5 && !passwordBox.Text.Contains(" "))
            {
                var password = passwordBox.Text;
                var username = usernameBox.Text;
                // check username and password against DB.
                // ADD TO DB
                // MOVE TO LOCALPRUDEFROM
                throw new NotImplementedException();
            }

        }
    }
}
