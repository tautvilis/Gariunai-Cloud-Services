namespace Gariunai_Cloud_Services.LogIn
{
    partial class CreateNewForm
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(79, 87);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(262, 27);
            this.usernameBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(79, 182);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(262, 27);
            this.passwordBox.TabIndex = 0;
            this.passwordBox.TextChanged += new System.EventHandler(this.passwordBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Password is ok.";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 43);
            this.button1.TabIndex = 3;
            this.button1.Text = "Create New Account";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createNewButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // CreateNewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 326);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Name = "CreateNewForm";
            this.Text = "Support Your Locals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}