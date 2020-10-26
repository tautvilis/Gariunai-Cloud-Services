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
            label1.Visible = true;
            var state = IsPasswordOk(passwordBox.Text);
            if (state.Item1)
            {
                label1.ForeColor = Color.Green;
                label1.Text = state.Item2;

            }
            if (!state.Item1)
            {
                label1.ForeColor = Color.Red;
                label1.Text = state.Item2;
            }

        }
        private (bool, string) IsPasswordOk(string password)
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
                MessageBox.Show("Username already exists");
        }
    }
}
