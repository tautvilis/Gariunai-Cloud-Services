using System;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;

namespace Gariunai_Cloud_Services
{
    public partial class AccountForm : Form
    {
        private readonly Form previousForm;

        public AccountForm(Form previousForm)
        {
            this.previousForm = previousForm;
            InitializeComponent();

            var currentUser = DatabaseHelper.GetUserById(LoginInfo.UserID);
            displayName.Text = currentUser.Name;
            descriptionBox.Text = currentUser.Description;
        }


        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            previousForm.Show();
        }

        private void ChangePictureButton_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog {Filter = "Image files (*.png, *.jpeg, *.jpg)|*.png;*.jpeg;*.jpg"};
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var selectedFileName = openFileDialog1.FileName;
                ovalPictureBox1.ImageLocation = selectedFileName;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //TODO save picture
            var currentUser = DatabaseHelper.GetUserById(LoginInfo.UserID);

            if (DatabaseHelper.GetUserByName(displayName.Text) == null)
                currentUser.Name = displayName.Text;

            currentUser.Description = descriptionBox.Text;
            var dataAccess = new DataAccess();
            dataAccess.Update(currentUser);
            dataAccess.SaveChanges();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form userShopsForm = new UserShopsForm(this);
            userShopsForm.Show();
        }
    }
}