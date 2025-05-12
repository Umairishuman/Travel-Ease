namespace TravelEaseApp.TourOperator
{
    partial class dashboardForm
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
            availableServicesPanel = new Panel();
            availableServicesLabel = new Label();
            topStatLabelNumber3 = new Label();
            topStatLabel3 = new Label();
            topStatLabelNumber2 = new Label();
            topStatLabel2 = new Label();
            topStatLabelNumber1 = new Label();
            topStatLabel1 = new Label();
            mainInfoPanel = new FlowLayoutPanel();
            topStatPanel1 = new Panel();
            topStatPanel2 = new Panel();
            topStatPanel3 = new Panel();
            customerReviewsLabel = new Label();
            username = new Label();
            customerReviewsPanel = new FlowLayoutPanel();
            addTripLabel = new Label();
            tagline = new Label();
            profilePictureBox = new PictureBox();
            infoPanel = new FlowLayoutPanel();
            infoPanel1 = new Panel();
            infoLabel = new Label();
            mainInfoPanel.SuspendLayout();
            topStatPanel1.SuspendLayout();
            topStatPanel2.SuspendLayout();
            topStatPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
            infoPanel.SuspendLayout();
            infoPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // availableServicesPanel
            // 
            availableServicesPanel.AutoScroll = true;
            availableServicesPanel.BackColor = SystemColors.Control;
            availableServicesPanel.Location = new Point(27, 166);
            availableServicesPanel.Name = "availableServicesPanel";
            availableServicesPanel.Size = new Size(431, 482);
            availableServicesPanel.TabIndex = 41;
            availableServicesPanel.Paint += availableServicesPanel_Paint;
            // 
            // availableServicesLabel
            // 
            availableServicesLabel.AutoSize = true;
            availableServicesLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            availableServicesLabel.Location = new Point(27, 130);
            availableServicesLabel.Name = "availableServicesLabel";
            availableServicesLabel.Size = new Size(218, 32);
            availableServicesLabel.TabIndex = 39;
            availableServicesLabel.Text = "Available Services";
            // 
            // topStatLabelNumber3
            // 
            topStatLabelNumber3.BackColor = Color.Transparent;
            topStatLabelNumber3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            topStatLabelNumber3.Location = new Point(3, 2);
            topStatLabelNumber3.Margin = new Padding(0);
            topStatLabelNumber3.Name = "topStatLabelNumber3";
            topStatLabelNumber3.Size = new Size(93, 38);
            topStatLabelNumber3.TabIndex = 3;
            topStatLabelNumber3.Text = "5";
            topStatLabelNumber3.TextAlign = ContentAlignment.TopCenter;
            // 
            // topStatLabel3
            // 
            topStatLabel3.BackColor = Color.Transparent;
            topStatLabel3.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            topStatLabel3.Location = new Point(3, 37);
            topStatLabel3.Name = "topStatLabel3";
            topStatLabel3.Size = new Size(93, 15);
            topStatLabel3.TabIndex = 2;
            topStatLabel3.Text = "Avg Rating";
            topStatLabel3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topStatLabelNumber2
            // 
            topStatLabelNumber2.BackColor = Color.Transparent;
            topStatLabelNumber2.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            topStatLabelNumber2.Location = new Point(3, 2);
            topStatLabelNumber2.Margin = new Padding(0);
            topStatLabelNumber2.Name = "topStatLabelNumber2";
            topStatLabelNumber2.Size = new Size(93, 38);
            topStatLabelNumber2.TabIndex = 3;
            topStatLabelNumber2.Text = "5";
            topStatLabelNumber2.TextAlign = ContentAlignment.TopCenter;
            // 
            // topStatLabel2
            // 
            topStatLabel2.BackColor = Color.Transparent;
            topStatLabel2.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            topStatLabel2.Location = new Point(3, 37);
            topStatLabel2.Name = "topStatLabel2";
            topStatLabel2.Size = new Size(93, 15);
            topStatLabel2.TabIndex = 2;
            topStatLabel2.Text = "Active Trips";
            topStatLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topStatLabelNumber1
            // 
            topStatLabelNumber1.BackColor = Color.Transparent;
            topStatLabelNumber1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            topStatLabelNumber1.Location = new Point(3, 2);
            topStatLabelNumber1.Margin = new Padding(0);
            topStatLabelNumber1.Name = "topStatLabelNumber1";
            topStatLabelNumber1.Size = new Size(93, 38);
            topStatLabelNumber1.TabIndex = 3;
            topStatLabelNumber1.Text = "5";
            topStatLabelNumber1.TextAlign = ContentAlignment.TopCenter;
            // 
            // topStatLabel1
            // 
            topStatLabel1.BackColor = Color.Transparent;
            topStatLabel1.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            topStatLabel1.Location = new Point(3, 37);
            topStatLabel1.Name = "topStatLabel1";
            topStatLabel1.Size = new Size(93, 15);
            topStatLabel1.TabIndex = 2;
            topStatLabel1.Text = "Completed Trips";
            topStatLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // mainInfoPanel
            // 
            mainInfoPanel.BackColor = SystemColors.Control;
            mainInfoPanel.Controls.Add(topStatPanel1);
            mainInfoPanel.Controls.Add(topStatPanel2);
            mainInfoPanel.Controls.Add(topStatPanel3);
            mainInfoPanel.Location = new Point(143, 56);
            mainInfoPanel.Name = "mainInfoPanel";
            mainInfoPanel.Size = new Size(315, 64);
            mainInfoPanel.TabIndex = 35;
            // 
            // topStatPanel1
            // 
            topStatPanel1.BackColor = Color.White;
            topStatPanel1.Controls.Add(topStatLabelNumber1);
            topStatPanel1.Controls.Add(topStatLabel1);
            topStatPanel1.Location = new Point(3, 3);
            topStatPanel1.Name = "topStatPanel1";
            topStatPanel1.Size = new Size(99, 60);
            topStatPanel1.TabIndex = 5;
            // 
            // topStatPanel2
            // 
            topStatPanel2.BackColor = Color.White;
            topStatPanel2.Controls.Add(topStatLabelNumber2);
            topStatPanel2.Controls.Add(topStatLabel2);
            topStatPanel2.Location = new Point(108, 3);
            topStatPanel2.Name = "topStatPanel2";
            topStatPanel2.Size = new Size(99, 60);
            topStatPanel2.TabIndex = 6;
            // 
            // topStatPanel3
            // 
            topStatPanel3.BackColor = Color.White;
            topStatPanel3.Controls.Add(topStatLabelNumber3);
            topStatPanel3.Controls.Add(topStatLabel3);
            topStatPanel3.Location = new Point(213, 3);
            topStatPanel3.Name = "topStatPanel3";
            topStatPanel3.Size = new Size(99, 60);
            topStatPanel3.TabIndex = 6;
            // 
            // customerReviewsLabel
            // 
            customerReviewsLabel.AutoSize = true;
            customerReviewsLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            customerReviewsLabel.Location = new Point(472, 137);
            customerReviewsLabel.Name = "customerReviewsLabel";
            customerReviewsLabel.Size = new Size(167, 25);
            customerReviewsLabel.TabIndex = 30;
            customerReviewsLabel.Text = "Customer Reviews";
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            username.Location = new Point(139, 11);
            username.Name = "username";
            username.Size = new Size(145, 28);
            username.TabIndex = 33;
            username.Text = "Tour Operator";
            username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // customerReviewsPanel
            // 
            customerReviewsPanel.AutoScroll = true;
            customerReviewsPanel.BackColor = SystemColors.Control;
            customerReviewsPanel.Location = new Point(472, 166);
            customerReviewsPanel.Name = "customerReviewsPanel";
            customerReviewsPanel.Size = new Size(644, 482);
            customerReviewsPanel.TabIndex = 37;
            // 
            // addTripLabel
            // 
            addTripLabel.BackColor = Color.Black;
            addTripLabel.BorderStyle = BorderStyle.FixedSingle;
            addTripLabel.Cursor = Cursors.Hand;
            addTripLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            addTripLabel.ForeColor = Color.White;
            addTripLabel.Location = new Point(459, 15);
            addTripLabel.Name = "addTripLabel";
            addTripLabel.Size = new Size(178, 50);
            addTripLabel.TabIndex = 38;
            addTripLabel.Text = "Add New Trip";
            addTripLabel.TextAlign = ContentAlignment.MiddleCenter;
            addTripLabel.Click += addTripLabel_Click_1;
            // 
            // tagline
            // 
            tagline.AutoSize = true;
            tagline.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            tagline.Location = new Point(143, 39);
            tagline.Name = "tagline";
            tagline.Size = new Size(100, 13);
            tagline.TabIndex = 34;
            tagline.Text = "Some cool text 😎";
            // 
            // profilePictureBox
            // 
            profilePictureBox.BackColor = Color.DodgerBlue;
            profilePictureBox.Image = Properties.Resources.images;
            profilePictureBox.InitialImage = null;
            profilePictureBox.Location = new Point(27, 20);
            profilePictureBox.Name = "profilePictureBox";
            profilePictureBox.Size = new Size(100, 100);
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.TabIndex = 31;
            profilePictureBox.TabStop = false;
            // 
            // infoPanel
            // 
            infoPanel.BackColor = SystemColors.Control;
            infoPanel.Controls.Add(infoPanel1);
            infoPanel.Location = new Point(472, 39);
            infoPanel.Name = "infoPanel";
            infoPanel.Size = new Size(644, 72);
            infoPanel.TabIndex = 32;
            // 
            // infoPanel1
            // 
            infoPanel1.Controls.Add(addTripLabel);
            infoPanel1.Location = new Point(3, 3);
            infoPanel1.Name = "infoPanel1";
            infoPanel1.Size = new Size(638, 66);
            infoPanel1.TabIndex = 0;
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            infoLabel.Location = new Point(475, 4);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(152, 32);
            infoLabel.TabIndex = 36;
            infoLabel.Text = "Information";
            // 
            // dashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 648);
            Controls.Add(availableServicesPanel);
            Controls.Add(availableServicesLabel);
            Controls.Add(mainInfoPanel);
            Controls.Add(customerReviewsLabel);
            Controls.Add(username);
            Controls.Add(customerReviewsPanel);
            Controls.Add(tagline);
            Controls.Add(profilePictureBox);
            Controls.Add(infoPanel);
            Controls.Add(infoLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboardForm";
            Text = "Form1";
            Load += dashboardForm_Load;
            mainInfoPanel.ResumeLayout(false);
            topStatPanel1.ResumeLayout(false);
            topStatPanel2.ResumeLayout(false);
            topStatPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
            infoPanel.ResumeLayout(false);
            infoPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel availableServicesPanel;
        private Label availableServicesLabel;
        private Label topStatLabelNumber3;
        private Label topStatLabel3;
        private Label topStatLabelNumber2;
        private Label topStatLabel2;
        private Label topStatLabelNumber1;
        private Label topStatLabel1;
        private FlowLayoutPanel mainInfoPanel;
        private Panel topStatPanel1;
        private Panel topStatPanel2;
        private Panel topStatPanel3;
        private Label customerReviewsLabel;
        private Label username;
        private FlowLayoutPanel customerReviewsPanel;
        private Label addTripLabel;
        private Label tagline;
        private PictureBox profilePictureBox;
        private FlowLayoutPanel infoPanel;
        private Label infoLabel;
        private Panel infoPanel1;
    }
}