namespace Gariunai_Cloud_Services
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountForm));
            this.ovalPictureBox1 = new Gariunai_Cloud_Services.OvalPictureBox();
            this.ChangePictureButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ovalPictureBox1
            // 
            this.ovalPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ovalPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("ovalPictureBox1.Image")));
            this.ovalPictureBox1.Location = new System.Drawing.Point(40, 32);
            this.ovalPictureBox1.Name = "ovalPictureBox1";
            this.ovalPictureBox1.Size = new System.Drawing.Size(179, 188);
            this.ovalPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ovalPictureBox1.TabIndex = 0;
            this.ovalPictureBox1.TabStop = false;
            // 
            // ChangePictureButton
            // 
            this.ChangePictureButton.Location = new System.Drawing.Point(40, 226);
            this.ChangePictureButton.Name = "ChangePictureButton";
            this.ChangePictureButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChangePictureButton.Size = new System.Drawing.Size(179, 29);
            this.ChangePictureButton.TabIndex = 1;
            this.ChangePictureButton.Text = "Change picture";
            this.ChangePictureButton.UseVisualStyleBackColor = true;
            this.ChangePictureButton.Click += new System.EventHandler(this.ChangePictureButton_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 562);
            this.Controls.Add(this.ChangePictureButton);
            this.Controls.Add(this.ovalPictureBox1);
            this.Name = "AccountForm";
            this.Text = "Support Your Locals";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OvalPictureBox ovalPictureBox1;
        private System.Windows.Forms.Button ChangePictureButton;
    }
}