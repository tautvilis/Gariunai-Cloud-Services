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
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.displayName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            // descriptionBox
            // 
            this.descriptionBox.AcceptsReturn = true;
            this.descriptionBox.AcceptsTab = true;
            this.descriptionBox.Location = new System.Drawing.Point(238, 261);
            this.descriptionBox.MaxLength = 512;
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(463, 241);
            this.descriptionBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(238, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "About me";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(578, 508);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(123, 42);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save profile";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // displayName
            // 
            this.displayName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.displayName.Location = new System.Drawing.Point(238, 46);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(275, 34);
            this.displayName.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(238, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Display name";
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 562);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.ChangePictureButton);
            this.Controls.Add(this.ovalPictureBox1);
            this.Name = "AccountForm";
            this.Text = "LoginScreen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AccountForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OvalPictureBox ovalPictureBox1;
        private System.Windows.Forms.Button ChangePictureButton;
        private System.Windows.Forms.TextBox displayName;
        private System.Windows.Forms.TextBox descriptionBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label2;
    }
}