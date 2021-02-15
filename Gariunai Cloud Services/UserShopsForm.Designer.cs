using System.ComponentModel;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    partial class UserShopsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewShops = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNewShop = new System.Windows.Forms.Button();
            this.textBoxShopName = new System.Windows.Forms.TextBox();
            this.textBoxShortDescription = new System.Windows.Forms.TextBox();
            this.listViewProducts = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.textBoxLongDescription = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSaveShop = new System.Windows.Forms.Button();
            this.vaiduolis = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.textAdress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textPhoneNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TextBoxNotificationTitle = new System.Windows.Forms.TextBox();
            this.TextBoxNotificationDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewShops
            // 
            this.listViewShops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.columnHeader1});
            this.listViewShops.HideSelection = false;
            this.listViewShops.Location = new System.Drawing.Point(10, 39);
            this.listViewShops.MultiSelect = false;
            this.listViewShops.Name = "listViewShops";
            this.listViewShops.Size = new System.Drawing.Size(124, 316);
            this.listViewShops.TabIndex = 0;
            this.listViewShops.UseCompatibleStateImageBehavior = false;
            this.listViewShops.View = System.Windows.Forms.View.Details;
            this.listViewShops.SelectedIndexChanged += new System.EventHandler(this.listViewShops_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Shop name";
            this.columnHeader1.Width = 144;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "My shops";
            // 
            // buttonNewShop
            // 
            this.buttonNewShop.Location = new System.Drawing.Point(10, 360);
            this.buttonNewShop.Name = "buttonNewShop";
            this.buttonNewShop.Size = new System.Drawing.Size(123, 20);
            this.buttonNewShop.TabIndex = 2;
            this.buttonNewShop.Text = "New shop";
            this.buttonNewShop.UseVisualStyleBackColor = true;
            this.buttonNewShop.Click += new System.EventHandler(this.ButtonNewShop_Click);
            // 
            // textBoxShopName
            // 
            this.textBoxShopName.Location = new System.Drawing.Point(257, 39);
            this.textBoxShopName.Name = "textBoxShopName";
            this.textBoxShopName.Size = new System.Drawing.Size(277, 20);
            this.textBoxShopName.TabIndex = 3;
            // 
            // textBoxShortDescription
            // 
            this.textBoxShortDescription.Location = new System.Drawing.Point(257, 64);
            this.textBoxShortDescription.Multiline = true;
            this.textBoxShortDescription.Name = "textBoxShortDescription";
            this.textBoxShortDescription.Size = new System.Drawing.Size(277, 29);
            this.textBoxShortDescription.TabIndex = 4;
            // 
            // listViewProducts
            // 
            this.listViewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.columnHeader2});
            this.listViewProducts.HideSelection = false;
            this.listViewProducts.Location = new System.Drawing.Point(539, 39);
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(137, 227);
            this.listViewProducts.TabIndex = 5;
            this.listViewProducts.UseCompatibleStateImageBehavior = false;
            this.listViewProducts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Products";
            this.columnHeader2.Width = 144;
            // 
            // textBoxLongDescription
            // 
            this.textBoxLongDescription.Location = new System.Drawing.Point(257, 98);
            this.textBoxLongDescription.Multiline = true;
            this.textBoxLongDescription.Name = "textBoxLongDescription";
            this.textBoxLongDescription.Size = new System.Drawing.Size(277, 83);
            this.textBoxLongDescription.TabIndex = 4;
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(539, 270);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(137, 20);
            this.textBoxProduct.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shop name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Short description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(169, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Long description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(539, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Produce";
            // 
            // buttonSaveShop
            // 
            this.buttonSaveShop.Location = new System.Drawing.Point(539, 360);
            this.buttonSaveShop.Name = "buttonSaveShop";
            this.buttonSaveShop.Size = new System.Drawing.Size(136, 20);
            this.buttonSaveShop.TabIndex = 9;
            this.buttonSaveShop.Text = "Save shop";
            this.buttonSaveShop.UseVisualStyleBackColor = true;
            this.buttonSaveShop.Click += new System.EventHandler(this.buttonSaveShop_Click);
            // 
            // vaiduolis
            // 
            this.vaiduolis.AutoSize = true;
            this.vaiduolis.Location = new System.Drawing.Point(10, 10);
            this.vaiduolis.MaximumSize = new System.Drawing.Size(10, 10);
            this.vaiduolis.MinimumSize = new System.Drawing.Size(10, 10);
            this.vaiduolis.Name = "vaiduolis";
            this.vaiduolis.Size = new System.Drawing.Size(10, 10);
            this.vaiduolis.TabIndex = 6;
            this.vaiduolis.Text = "button1";
            this.vaiduolis.UseVisualStyleBackColor = false;
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(539, 296);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(136, 20);
            this.buttonAddProduct.TabIndex = 10;
            this.buttonAddProduct.Text = "Add product";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // textAdress
            // 
            this.textAdress.Location = new System.Drawing.Point(257, 185);
            this.textAdress.Name = "textAdress";
            this.textAdress.Size = new System.Drawing.Size(277, 20);
            this.textAdress.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(169, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Adress";
            // 
            // textPhoneNumber
            // 
            this.textPhoneNumber.Location = new System.Drawing.Point(257, 211);
            this.textPhoneNumber.Name = "textPhoneNumber";
            this.textPhoneNumber.Size = new System.Drawing.Size(277, 20);
            this.textPhoneNumber.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Phone number";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label8.Location = new System.Drawing.Point(169, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(250, 33);
            this.label8.TabIndex = 15;
            this.label8.Text = "Send new notification";
            // 
            // TextBoxNotificationTitle
            // 
            this.TextBoxNotificationTitle.Location = new System.Drawing.Point(257, 270);
            this.TextBoxNotificationTitle.Name = "TextBoxNotificationTitle";
            this.TextBoxNotificationTitle.Size = new System.Drawing.Size(276, 20);
            this.TextBoxNotificationTitle.TabIndex = 16;
            // 
            // TextBoxNotificationDescription
            // 
            this.TextBoxNotificationDescription.Location = new System.Drawing.Point(257, 297);
            this.TextBoxNotificationDescription.Multiline = true;
            this.TextBoxNotificationDescription.Name = "TextBoxNotificationDescription";
            this.TextBoxNotificationDescription.Size = new System.Drawing.Size(276, 58);
            this.TextBoxNotificationDescription.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(169, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Title";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(169, 297);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 19);
            this.label10.TabIndex = 19;
            this.label10.Text = "Description";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(276, 20);
            this.button1.TabIndex = 20;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SendNotification_ButtonClick);
            // 
            // UserShopsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TextBoxNotificationDescription);
            this.Controls.Add(this.TextBoxNotificationTitle);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textPhoneNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textAdress);
            this.Controls.Add(this.buttonAddProduct);
            this.Controls.Add(this.buttonSaveShop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.textBoxLongDescription);
            this.Controls.Add(this.listViewProducts);
            this.Controls.Add(this.textBoxShortDescription);
            this.Controls.Add(this.textBoxShopName);
            this.Controls.Add(this.buttonNewShop);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewShops);
            this.Name = "UserShopsForm";
            this.Text = "UserShopsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserShopsForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox TextBoxNotificationDescription;
        private System.Windows.Forms.TextBox TextBoxNotificationTitle;

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;

        private System.Windows.Forms.Label label8;

        #endregion

        private ListView listViewShops;
        private Label label1;
        private Button buttonNewShop;
        private TextBox textBoxShopName;
        private TextBox textBoxShortDescription;
        private ListView listViewProducts;
        private TextBox textBoxLongDescription;
        private TextBox textBoxProduct;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button buttonSaveShop;
        private Button vaiduolis;
        private Button buttonAddProduct;
        private TextBox textAdress;
        private Label label6;
        private TextBox textPhoneNumber;
        private Label label7;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}