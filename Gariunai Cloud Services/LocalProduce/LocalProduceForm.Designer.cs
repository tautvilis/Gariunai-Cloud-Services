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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // localProduceButton
            // 
            this.localProduceButton.Location = new System.Drawing.Point(10, 51);
            this.localProduceButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.localProduceButton.Name = "localProduceButton";
            this.localProduceButton.Size = new System.Drawing.Size(301, 22);
            this.localProduceButton.TabIndex = 0;
            this.localProduceButton.Text = "Local Produce";
            this.localProduceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.localProduceButton.UseVisualStyleBackColor = true;
            this.localProduceButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // followFeedButton
            // 
            this.followFeedButton.Location = new System.Drawing.Point(316, 51);
            this.followFeedButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.followFeedButton.Name = "followFeedButton";
            this.followFeedButton.Size = new System.Drawing.Size(315, 22);
            this.followFeedButton.TabIndex = 1;
            this.followFeedButton.Text = "Follow Feed";
            this.followFeedButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.followFeedButton.UseVisualStyleBackColor = true;
            this.followFeedButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // homeButton
            // 
            this.homeButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.homeButton.Location = new System.Drawing.Point(10, 9);
            this.homeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.homeButton.Name = "homeButton";
            this.homeButton.Size = new System.Drawing.Size(111, 38);
            this.homeButton.TabIndex = 2;
            this.homeButton.Text = "Home";
            this.homeButton.UseVisualStyleBackColor = true;
            // 
            // accountButton
            // 
            this.accountButton.Location = new System.Drawing.Point(522, 22);
            this.accountButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.accountButton.Name = "accountButton";
            this.accountButton.Size = new System.Drawing.Size(109, 24);
            this.accountButton.TabIndex = 3;
            this.accountButton.Text = "Account";
            this.accountButton.UseVisualStyleBackColor = true;
            this.accountButton.Click += new System.EventHandler(this.accountButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 78);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(645, 297);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // LocalProduceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 375);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.accountButton);
            this.Controls.Add(this.homeButton);
            this.Controls.Add(this.followFeedButton);
            this.Controls.Add(this.localProduceButton);
            this.Name = "LocalProduceForm";
            this.Text = "Support Your Locals";
            this.Load += new System.EventHandler(this.LocalProduceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button localProduceButton;
        private System.Windows.Forms.Button followFeedButton;
        private System.Windows.Forms.Button homeButton;
        private System.Windows.Forms.Button accountButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

