using System;
using System.Drawing;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services.LogIn
{
    public partial class CreateNewForm : Form
    {
        public CreateNewForm()
        {
            InitializeComponent();
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            var (item1, item2) = IsPasswordOk(passwordBox.Text);
            ConfigurePasswordBox(item1, item2);
        }

        private void ConfigurePasswordBox(bool state = false, string message = "Error checking if password is viable. Password has to be longer than 5 characters and cannot contain spaces")
        {
            label1.Visible = true;
            if (state)
            {
                label1.ForeColor = Color.Green;
                label1.Text = message;
            }
            else if(!state)
            {
                label1.ForeColor = Color.Red;
                label1.Text = message;
            }
        }
        
        private static (bool, string) IsPasswordOk(string password)
        {
            var message = "Password strength is ok";
            var ispassok = true;
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

        private void CreateNewButton_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.CheckIfUsernameTaken(usernameBox.Text) == false)
            {
                var user = new User
                {
                    Name = usernameBox.Text
                };
                if (DatabaseHelper.RegisterUser(user, passwordBox.Text))
                {
                    MessageBox.Show("New user created", "Sucess");
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Username already exists");
            }
        }
    }
}