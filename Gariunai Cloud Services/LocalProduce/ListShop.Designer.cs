using System.ComponentModel;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services.LocalProduce
{
    partial class ListShop
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
            this.ListShopImg = new System.Windows.Forms.PictureBox();
            this.ListShopTitle = new System.Windows.Forms.Label();
            this.ListShopDesc = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListShopOwner = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ListShopImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListShopImg
            // 
            this.ListShopImg.BackColor = System.Drawing.Color.Black;
            this.ListShopImg.Location = new System.Drawing.Point(19, 12);
            this.ListShopImg.Name = "ListShopImg";
            this.ListShopImg.Size = new System.Drawing.Size(89, 90);
            this.ListShopImg.TabIndex = 0;
            this.ListShopImg.TabStop = false;
            this.ListShopImg.Click += new System.EventHandler(this.ListShop_Click);
            // 
            // ListShopTitle
            // 
            this.ListShopTitle.AutoSize = true;
            this.ListShopTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ListShopTitle.Location = new System.Drawing.Point(147, 16);
            this.ListShopTitle.Name = "ListShopTitle";
            this.ListShopTitle.Size = new System.Drawing.Size(39, 21);
            this.ListShopTitle.TabIndex = 2;
            this.ListShopTitle.Text = "Title";
            this.ListShopTitle.Click += new System.EventHandler(this.ListShop_Click);
            // 
            // ListShopDesc
            // 
            this.ListShopDesc.Location = new System.Drawing.Point(147, 37);
            this.ListShopDesc.Name = "ListShopDesc";
            this.ListShopDesc.Size = new System.Drawing.Size(368, 54);
            this.ListShopDesc.TabIndex = 3;
            this.ListShopDesc.Text = "Short Description of the shop";
            this.ListShopDesc.Click += new System.EventHandler(this.ListShop_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.ListShopImg);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(128, 116);
            this.panel1.TabIndex = 4;
            this.panel1.Click += new System.EventHandler(this.ListShop_Click);
            // 
            // ListShopOwner
            // 
            this.ListShopOwner.AutoSize = true;
            this.ListShopOwner.Location = new System.Drawing.Point(147, 95);
            this.ListShopOwner.Name = "ListShopOwner";
            this.ListShopOwner.Size = new System.Drawing.Size(42, 15);
            this.ListShopOwner.TabIndex = 5;
            this.ListShopOwner.Text = "Owner";
            // 
            // ListShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListShopOwner);
            this.Controls.Add(this.ListShopTitle);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ListShopDesc);
            this.Name = "ListShop";
            this.Size = new System.Drawing.Size(573, 116);
            this.Click += new System.EventHandler(this.ListShop_Click);
            ((System.ComponentModel.ISupportInitialize)(this.ListShopImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox ListShopImg;
        private Label ListShopTitle;
        private Label ListShopDesc;
        private Panel panel1;
        private Label ListShopOwner;
    }
}
