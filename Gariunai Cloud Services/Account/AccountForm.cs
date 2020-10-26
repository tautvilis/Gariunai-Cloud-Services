using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Gariunai_Cloud_Services.Backend;
using Gariunai_Cloud_Services.Entities;

namespace Gariunai_Cloud_Services.Account
{
    public partial class AccountForm : Form
    {
        private readonly Form _previousForm;
        private bool _pictureChanged;
        public AccountForm(Form previousForm)
        {
            _previousForm = previousForm;
            InitializeComponent();

            var currentUser = DatabaseHelper.GetUserById(LoginInfo.UserId);
            displayName.Text = currentUser.Name;
            descriptionBox.Text = currentUser.Description;
            if(currentUser.Image != null)
                ovalPictureBox1.Image = ByteArrayToImage(currentUser.Image);
            else
                ovalPictureBox1.ImageLocation = Path.Combine(Application.StartupPath, "Resources\\empty-profile-picture-png-2.png");

        }


        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            _previousForm.Show();
        }

        private void ChangePictureButton_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog {Filter = @"Image files (*.png, *.jpeg, *.jpg)|*.png;*.jpeg;*.jpg"};
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var selectedFileName = openFileDialog1.FileName;
                ovalPictureBox1.ImageLocation = selectedFileName;
                _pictureChanged = true;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            var currentUser = DatabaseHelper.GetUserById(LoginInfo.UserId);
            var image = ovalPictureBox1.Image;


            if (DatabaseHelper.GetUserByName(displayName.Text) == null)
                currentUser.Name = displayName.Text;
            if(_pictureChanged)
                currentUser.Image = ImageToByteArray(image);
            currentUser.Description = descriptionBox.Text;
            var dataAccess = new DataAccess();
            dataAccess.Update(currentUser);
            dataAccess.SaveChanges();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Hide();
            var userShopsForm = new UserShopsForm(this);
            userShopsForm.Show();
        }
        public byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Gif);

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
