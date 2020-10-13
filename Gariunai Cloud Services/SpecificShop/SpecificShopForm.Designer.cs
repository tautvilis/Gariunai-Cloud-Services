namespace Gariunai_Cloud_Services
{
    partial class SpecificShopForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contactBtn = new System.Windows.Forms.Button();
            this.followBtn = new System.Windows.Forms.Button();
            this.shopDescription = new System.Windows.Forms.Label();
            this.productList = new System.Windows.Forms.ListBox();
            this.PRODUCTS = new System.Windows.Forms.Label();
            this.homeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(616, 122);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox3.Location = new System.Drawing.Point(207, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(218, 122);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pictureBox2.Location = new System.Drawing.Point(425, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(191, 122);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Gray;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 122);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // contactBtn
            // 
            this.contactBtn.Location = new System.Drawing.Point(12, 230);
            this.contactBtn.Name = "contactBtn";
            this.contactBtn.Size = new System.Drawing.Size(188, 45);
            this.contactBtn.TabIndex = 1;
            this.contactBtn.Text = "CONTACT";
            this.contactBtn.UseVisualStyleBackColor = true;
            // 
            // followBtn
            // 
            this.followBtn.AccessibleName = "followBtn";
            this.followBtn.Location = new System.Drawing.Point(12, 295);
            this.followBtn.Name = "followBtn";
            this.followBtn.Size = new System.Drawing.Size(188, 45);
            this.followBtn.TabIndex = 1;
            this.followBtn.Text = "FOLLOW";
            this.followBtn.UseVisualStyleBackColor = true;
            // 
            // shopDescription
            // 
            this.shopDescription.Location = new System.Drawing.Point(219, 230);
            this.shopDescription.Name = "shopDescription";
            this.shopDescription.Size = new System.Drawing.Size(409, 110);
            this.shopDescription.TabIndex = 2;
            this.shopDescription.Text = "label1";
            // 
            // productList
            // 
            this.productList.FormattingEnabled = true;
            this.productList.ItemHeight = 15;
            this.productList.Location = new System.Drawing.Point(12, 389);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(188, 94);
            this.productList.TabIndex = 3;
            // 
            // PRODUCTS
            // 
            this.PRODUCTS.AutoSize = true;
            this.PRODUCTS.Location = new System.Drawing.Point(12, 357);
            this.PRODUCTS.Name = "PRODUCTS";
            this.PRODUCTS.Size = new System.Drawing.Size(66, 15);
            this.PRODUCTS.TabIndex = 4;
            this.PRODUCTS.Text = "PRODUCTS";
            // 
            // homeBtn
            // 
            this.homeBtn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.homeBtn.Location = new System.Drawing.Point(21, 17);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(122, 49);
            this.homeBtn.TabIndex = 5;
            this.homeBtn.Text = "HOME";
            this.homeBtn.UseVisualStyleBackColor = true;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // SpecificShopForm
            // 
            this.AccessibleName = "followBtn";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 514);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.PRODUCTS);
            this.Controls.Add(this.productList);
            this.Controls.Add(this.shopDescription);
            this.Controls.Add(this.followBtn);
            this.Controls.Add(this.contactBtn);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SpecificShopForm";
            this.Text = "FOLLOW";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpecificShopForm_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button contactBtn;
        private System.Windows.Forms.Button followBtn;
        private System.Windows.Forms.Label shopDescription;
        private System.Windows.Forms.ListBox productList;
        private System.Windows.Forms.Label PRODUCTS;
        private System.Windows.Forms.Button homeBtn;
    }
}