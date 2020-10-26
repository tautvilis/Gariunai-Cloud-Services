using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    public partial class AccountForm : Form
    {
        private readonly Form previousForm;
        private bool pictureChanged = false;
        public AccountForm(Form previousForm)
        {
            this.previousForm = previousForm;
            InitializeComponent();

            var currentUser = DatabaseHelper.GetUserById(LoginInfo.UserID);
            displayName.Text = currentUser.Name;
            descriptionBox.Text = currentUser.Description;
            if(currentUser.Image != null)
                ovalPictureBox1.Image = ByteArrayToImage(currentUser.Image);
            else
                ovalPictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "Resources\\empty-profile-picture-png-2.png");;

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
                string selectedFileName = openFileDialog1.FileName;
                ovalPictureBox1.ImageLocation = selectedFileName;
                pictureChanged = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var currentUser = DatabaseHelper.GetUserById(LoginInfo.UserID);
            var image = ovalPictureBox1.Image;


            if (DatabaseHelper.GetUserByName(displayName.Text) == null)
                currentUser.Name = displayName.Text;
            if(pictureChanged == true)
                currentUser.Image = ImageToByteArray(image);
            currentUser.Description = descriptionBox.Text;
            var dataAccess = new DataAccess();
            dataAccess.Update(currentUser);
            dataAccess.SaveChanges();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var userShopsForm = new UserShopsForm(this);
            userShopsForm.Show();
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);

                return ms.ToArray();
            }
        }

        public Image ByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                using (var ms = new MemoryStream(byteArrayIn))
                {
                    var returnImage = Image.FromStream(ms);

                    return returnImage;
                }
            }
            return null;
        }
    }
}
