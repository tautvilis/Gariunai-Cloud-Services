using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services.LogIn
{
    public partial class CreateNewForm : Form
    {
        public CreateNewForm()
        {
            InitializeComponent();
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            var state = isPasswordOk(passwordBox.Text);
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
        private (bool, string) isPasswordOk(string password)
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

        private void createNewButton_Click(object sender, EventArgs e)
        {
            if (DatabaseHelper.CheckIfUserExists(usernameBox.Text, passwordBox.Text) == false)
            {
                //TODO add user to db
                this.Close();
            }
        }
    }
}
