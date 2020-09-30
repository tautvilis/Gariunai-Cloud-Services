using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    public partial class AccountForm : Form
    {
        private readonly Form previousForm;

        public AccountForm(Form previousForm)
        {
            this.previousForm = previousForm;
            InitializeComponent();
            //load textbox text and picture from db
        }


        private void AccountForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save();
            previousForm.Show();
        }

        private void ChangePictureButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.png, *.jpeg, *.jpg)|*.png;*.jpeg;*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog1.FileName;
                ovalPictureBox1.ImageLocation = selectedFileName;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            //save textbox texts to db and picture
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogInForm logIn = new LogInForm();
            logIn.ShowDialog();
        }
    }
}
