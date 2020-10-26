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
            this.ovalPictureBox1 = new Gariunai_Cloud_Services.OvalPictureBox();
            this.ChangePictureButton = new System.Windows.Forms.Button();
            this.descriptionBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.displayName = new System.Windows.Forms.TextBox();
            this.buttonShops = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ovalPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ovalPictureBox1
            // 
            this.ovalPictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.ovalPictureBox1.ImageLocation = "";
            this.ovalPictureBox1.Location = new System.Drawing.Point(12, 44);
            this.ovalPictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ovalPictureBox1.Name = "ovalPictureBox1";
            this.ovalPictureBox1.Size = new System.Drawing.Size(157, 141);
            this.ovalPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ovalPictureBox1.TabIndex = 0;
            this.ovalPictureBox1.TabStop = false;
            // 
            // ChangePictureButton
            // 
            this.ChangePictureButton.Location = new System.Drawing.Point(12, 204);
            this.ChangePictureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChangePictureButton.Name = "ChangePictureButton";
            this.ChangePictureButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChangePictureButton.Size = new System.Drawing.Size(157, 22);
            this.ChangePictureButton.TabIndex = 1;
            this.ChangePictureButton.Text = "Change picture";
            this.ChangePictureButton.UseVisualStyleBackColor = true;
            this.ChangePictureButton.Click += new System.EventHandler(this.ChangePictureButton_Click);
            // 
            // descriptionBox
            // 
            this.descriptionBox.AcceptsReturn = true;
            this.descriptionBox.AcceptsTab = true;
            this.descriptionBox.Location = new System.Drawing.Point(208, 44);
            this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.descriptionBox.MaxLength = 512;
            this.descriptionBox.Multiline = true;
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(406, 182);
            this.descriptionBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(208, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "About me";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(533, 381);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(108, 32);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save profile";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // displayName
            // 
            this.displayName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.displayName.Location = new System.Drawing.Point(12, 11);
            this.displayName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.displayName.Name = "displayName";
            this.displayName.Size = new System.Drawing.Size(157, 29);
            this.displayName.TabIndex = 5;
            // 
            // buttonShops
            // 
            this.buttonShops.Location = new System.Drawing.Point(12, 381);
            this.buttonShops.Name = "buttonShops";
            this.buttonShops.Size = new System.Drawing.Size(104, 32);
            this.buttonShops.TabIndex = 6;
            this.buttonShops.Text = "My shops";
            this.buttonShops.UseVisualStyleBackColor = true;
            this.buttonShops.Click += new System.EventHandler(this.Button1_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 422);
            this.Controls.Add(this.buttonShops);
            this.Controls.Add(this.displayName);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionBox);
            this.Controls.Add(this.ChangePictureButton);
            this.Controls.Add(this.ovalPictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Button buttonShops;
    }
}