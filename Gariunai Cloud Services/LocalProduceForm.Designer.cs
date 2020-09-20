namespace Gariunai_Cloud_Services
{
    partial class LocalProduceForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.localProduceButton = new System.Windows.Forms.Button();
            this.followFeedButton = new System.Windows.Forms.Button();
            this.homeButton = new System.Windows.Forms.Button();
            this.accountButton = new System.Windows.Forms.Button();
            this.specificShopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // localProduceButton
            // 
            this.localProduceButton.Location = new System.Drawing.Point(12, 68);
            this.localProduceButton.Name = "localProduceButton";
            this.localProduceButton.Size = new System.Drawing.Size(344, 29);
            this.localProduceButton.TabIndex = 0;
            this.localProduceButton.Text = "Local Produce";
            this.localProduceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.localProduceButton.UseVisualStyleBackColor = true;
            this.localProduceButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // followFeedButton
            // 
            this.followFeedButton.Location = new System.Drawing.Point(362, 68);
            this.followFeedButton.Name = "followFeedButton";
            this.followFeedButton.Size = new System.Drawing.Size(360, 29);
            this.followFeedButton.TabIndex = 1;
            this.followFeedButton.Text = "Follow Feed";
            this.followFeedButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.followFeedButton.UseVisualStyleBackColor = true;
            this.followFeedButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // homeButton
            // 
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.homeButton.Location = new System.Drawing.Point(12, 12);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(127, 50);
            this.homeButton.TabIndex = 2;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            // 
            // accountButton
            // 
            this.accountButton.Location = new System.Drawing.Point(597, 30);
            this.accountButton.Name = "accountButton";
            this.accountButton.Size = new System.Drawing.Size(125, 32);
            this.accountButton.TabIndex = 3;
            this.accountButton.Text = "Account";
            this.accountButton.UseVisualStyleBackColor = true;
            // 
            // specificShopButton
            // 
            this.specificShopButton.Location = new System.Drawing.Point(12, 152);
            this.specificShopButton.Name = "specificShopButton";
            this.specificShopButton.Size = new System.Drawing.Size(424, 112);
            this.specificShopButton.TabIndex = 4;
            this.specificShopButton.Text = "SomeShop";
            this.specificShopButton.UseVisualStyleBackColor = true;
            this.specificShopButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // LocalProduceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 500);
            this.Controls.Add(this.specificShopButton);
            this.Controls.Add(this.accountButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.followFeedButton);
            this.Controls.Add(this.localProduceButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LocalProduceForm";
            this.Text = "Support Your Locals";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button localProduceButton;
        private System.Windows.Forms.Button followFeedButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button accountButton;
        private System.Windows.Forms.Button specificShopButton;
    }
}

