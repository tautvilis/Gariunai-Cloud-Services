using System.ComponentModel;
using System.Windows.Forms;

namespace Gariunai_Cloud_Services
{
    partial class LogInForm
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
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.createNewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(102, 62);
            this.usernameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(230, 23);
            this.usernameBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(102, 121);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(230, 23);
            this.passwordBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // signInButton
            // 
            this.signInButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.signInButton.Location = new System.Drawing.Point(245, 172);
            this.signInButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(87, 32);
            this.signInButton.TabIndex = 2;
            this.signInButton.Text = "Sign in";
            this.signInButton.UseVisualStyleBackColor = true;
            this.signInButton.Click += new System.EventHandler(this.SignInButton_Click);
            // 
            // createNewButton
            // 
            this.createNewButton.Location = new System.Drawing.Point(102, 184);
            this.createNewButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(137, 20);
            this.createNewButton.TabIndex = 3;
            this.createNewButton.Text = "Create New Account";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += new System.EventHandler(this.CreateNewButton_Click);
            // 
            // LogInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 236);
            this.Controls.Add(this.createNewButton);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LogInForm";
            this.Text = "Support Your Locals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox usernameBox;
        private TextBox passwordBox;
        private Label label1;
        private Label label2;
        private Button signInButton;
        private Button createNewButton;
    }
}