using System;

namespace Gariunai_Cloud_Services
{
    partial class UserShopsForm
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
            this.SuspendLayout();
            // 
            // listViewShops
            // 
            this.listViewShops.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewShops.HideSelection = false;
            this.listViewShops.Location = new System.Drawing.Point(12, 45);
            this.listViewShops.MultiSelect = false;
            this.listViewShops.Name = "listViewShops";
            this.listViewShops.Size = new System.Drawing.Size(144, 364);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "My shops";
            // 
            // buttonNewShop
            // 
            this.buttonNewShop.Location = new System.Drawing.Point(12, 415);
            this.buttonNewShop.Name = "buttonNewShop";
            this.buttonNewShop.Size = new System.Drawing.Size(144, 23);
            this.buttonNewShop.TabIndex = 2;
            this.buttonNewShop.Text = "New shop";
            this.buttonNewShop.UseVisualStyleBackColor = true;
            this.buttonNewShop.Click += new System.EventHandler(this.buttonNewShop_Click);
            // 
            // textBoxShopName
            // 
            this.textBoxShopName.Location = new System.Drawing.Point(300, 45);
            this.textBoxShopName.Name = "textBoxShopName";
            this.textBoxShopName.Size = new System.Drawing.Size(323, 23);
            this.textBoxShopName.TabIndex = 3;
            // 
            // textBoxShortDescription
            // 
            this.textBoxShortDescription.Location = new System.Drawing.Point(300, 74);
            this.textBoxShortDescription.Multiline = true;
            this.textBoxShortDescription.Name = "textBoxShortDescription";
            this.textBoxShortDescription.Size = new System.Drawing.Size(323, 33);
            this.textBoxShortDescription.TabIndex = 4;
            // 
            // listViewProducts
            // 
            this.listViewProducts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listViewProducts.HideSelection = false;
            this.listViewProducts.Location = new System.Drawing.Point(629, 45);
            this.listViewProducts.Name = "listViewProducts";
            this.listViewProducts.Size = new System.Drawing.Size(159, 261);
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
            this.textBoxLongDescription.Location = new System.Drawing.Point(300, 113);
            this.textBoxLongDescription.Multiline = true;
            this.textBoxLongDescription.Name = "textBoxLongDescription";
            this.textBoxLongDescription.Size = new System.Drawing.Size(323, 95);
            this.textBoxLongDescription.TabIndex = 4;
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(629, 312);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(159, 23);
            this.textBoxProduct.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Shop name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Short description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Long description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(629, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Produce";
            // 
            // buttonSaveShop
            // 
            this.buttonSaveShop.Location = new System.Drawing.Point(629, 415);
            this.buttonSaveShop.Name = "buttonSaveShop";
            this.buttonSaveShop.Size = new System.Drawing.Size(159, 23);
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
            this.buttonAddProduct.Location = new System.Drawing.Point(629, 341);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(159, 23);
            this.buttonAddProduct.TabIndex = 10;
            this.buttonAddProduct.Text = "Add product";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // textAdress
            // 
            this.textAdress.Location = new System.Drawing.Point(300, 214);
            this.textAdress.Name = "textAdress";
            this.textAdress.Size = new System.Drawing.Size(323, 23);
            this.textAdress.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Adress";
            // 
            // textPhoneNumber
            // 
            this.textPhoneNumber.Location = new System.Drawing.Point(300, 243);
            this.textPhoneNumber.Name = "textPhoneNumber";
            this.textPhoneNumber.Size = new System.Drawing.Size(323, 23);
            this.textPhoneNumber.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(197, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Phone number";
            // 
            // UserShopsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 447);
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

        #endregion

        private System.Windows.Forms.ListView listViewShops;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNewShop;
        private System.Windows.Forms.TextBox textBoxShopName;
        private System.Windows.Forms.TextBox textBoxShortDescription;
        private System.Windows.Forms.ListView listViewProducts;
        private System.Windows.Forms.TextBox textBoxLongDescription;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSaveShop;
        private System.Windows.Forms.Button vaiduolis;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.TextBox textAdress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPhoneNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}