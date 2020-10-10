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
            correctPassword.Visible = true;
            var state = isPasswordOk(passwordBox.Text);
            if (state.Item1)
            {
                correctPassword.ForeColor = Color.Green;
                correctPassword.Text = state.Item2;
                
            }
            if(!state.Item1)
            {
                correctPassword.ForeColor = Color.Red;
                correctPassword.Text = state.Item2;
            }

        }
        private (bool,string) isPasswordOk(string password)
        {
            var message = "Password strength is ok";
            bool ispassok = true;
            if (password.Length < 5)
            {
                ispassok = false;
                message = "Password too short";
             
            }
            else if (password.Contains(" "))
            {
                ispassok = false;
                message = "Password cannot contain spaces";
            }
            return (ispassok, message);

        }
        private void signInButton_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.CheckIfUserExists(usernameBox.Text, passwordBox.Text))
            {
                Form main = new LocalProduceForm();
                main.Show();
                this.Close();
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
