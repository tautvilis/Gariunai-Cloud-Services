using System.ComponentModel;

namespace Gariunai_Cloud_Services
{
    partial class ListFollow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LabelNotificationTitle = new System.Windows.Forms.Label();
            this.LabelNotificationText = new System.Windows.Forms.Label();
            this.ListShopImg = new System.Windows.Forms.PictureBox();
            this.LabelShopName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.ListShopImg)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelNotificationTitle
            // 
            this.LabelNotificationTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.LabelNotificationTitle.Location = new System.Drawing.Point(172, 9);
            this.LabelNotificationTitle.Name = "LabelNotificationTitle";
            this.LabelNotificationTitle.Size = new System.Drawing.Size(100, 23);
            this.LabelNotificationTitle.TabIndex = 0;
            this.LabelNotificationTitle.Text = "Title";
            // 
            // LabelNotificationText
            // 
            this.LabelNotificationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.LabelNotificationText.Location = new System.Drawing.Point(172, 32);
            this.LabelNotificationText.Name = "LabelNotificationText";
            this.LabelNotificationText.Size = new System.Drawing.Size(411, 64);
            this.LabelNotificationText.TabIndex = 1;
            this.LabelNotificationText.Text = "Title";
            // 
            // ListShopImg
            // 
            this.ListShopImg.BackColor = System.Drawing.Color.Black;
            this.ListShopImg.Location = new System.Drawing.Point(3, 9);
            this.ListShopImg.Name = "ListShopImg";
            this.ListShopImg.Size = new System.Drawing.Size(163, 159);
            this.ListShopImg.TabIndex = 2;
            this.ListShopImg.TabStop = false;
            // 
            // LabelShopName
            // 
            this.LabelShopName.Location = new System.Drawing.Point(3, 171);
            this.LabelShopName.Name = "LabelShopName";
            this.LabelShopName.Size = new System.Drawing.Size(163, 23);
            this.LabelShopName.TabIndex = 3;
            this.LabelShopName.Text = "label1";
            this.LabelShopName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListFollow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelShopName);
            this.Controls.Add(this.ListShopImg);
            this.Controls.Add(this.LabelNotificationText);
            this.Controls.Add(this.LabelNotificationTitle);
            this.Name = "ListFollow";
            this.Size = new System.Drawing.Size(589, 193);
            ((System.ComponentModel.ISupportInitialize) (this.ListShopImg)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label LabelShopName;

        private System.Windows.Forms.Label LabelNotificationText;

        private System.Windows.Forms.PictureBox ListShopImg;

        private System.Windows.Forms.Label LabelNotificationTitle;

        #endregion
    }
}