namespace TravelEaseApp.ServiceProvider
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
            profilePictureBox = new PictureBox();
            username = new Label();
            tagline = new Label();
            mainInfoPanel = new FlowLayoutPanel();
            topStatPanel1 = new Panel();
            topStatLabelNumber1 = new Label();
            topStatLabel1 = new Label();
            topStatPanel2 = new Panel();
            topStatLabelNumber2 = new Label();
            topStatLabel2 = new Label();
            topStatPanel3 = new Panel();
            topStatLabelNumber3 = new Label();
            topStatLabel3 = new Label();
            pendingRequestsHeaderPanelLabel = new Label();
            addServiceLabel = new Label();
            pendingRequestsPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
            mainInfoPanel.SuspendLayout();
            topStatPanel1.SuspendLayout();
            topStatPanel2.SuspendLayout();
            topStatPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // profilePictureBox
            // 
            profilePictureBox.BackColor = Color.DodgerBlue;
            profilePictureBox.Image = Properties.Resources.images;
            profilePictureBox.InitialImage = null;
            profilePictureBox.Location = new Point(26, 23);
            profilePictureBox.Name = "profilePictureBox";
            profilePictureBox.Size = new Size(100, 100);
            profilePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            profilePictureBox.TabIndex = 0;
            profilePictureBox.TabStop = false;
            profilePictureBox.Click += profilePictureBox_Click;
            // 
            // username
            // 
            username.AutoSize = true;
            username.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            username.Location = new Point(137, 14);
            username.Name = "username";
            username.Size = new Size(141, 28);
            username.TabIndex = 1;
            username.Text = "Blazing Beam";
            username.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tagline
            // 
            tagline.AutoSize = true;
            tagline.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            tagline.Location = new Point(141, 42);
            tagline.Name = "tagline";
            tagline.Size = new Size(100, 13);
            tagline.TabIndex = 2;
            tagline.Text = "Some cool text 😎";
            // 
            // mainInfoPanel
            // 
            mainInfoPanel.BackColor = SystemColors.Control;
            mainInfoPanel.Controls.Add(topStatPanel1);
            mainInfoPanel.Controls.Add(topStatPanel2);
            mainInfoPanel.Controls.Add(topStatPanel3);
            mainInfoPanel.Location = new Point(141, 59);
            mainInfoPanel.Name = "mainInfoPanel";
            mainInfoPanel.Size = new Size(315, 64);
            mainInfoPanel.TabIndex = 3;
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
            topStatLabel1.Text = "Total Services";
            topStatLabel1.TextAlign = ContentAlignment.MiddleCenter;
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
            topStatLabel2.Text = "Services Used";
            topStatLabel2.TextAlign = ContentAlignment.MiddleCenter;
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
            // pendingRequestsHeaderPanelLabel
            // 
            pendingRequestsHeaderPanelLabel.AutoSize = true;
            pendingRequestsHeaderPanelLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            pendingRequestsHeaderPanelLabel.Location = new Point(26, 142);
            pendingRequestsHeaderPanelLabel.Name = "pendingRequestsHeaderPanelLabel";
            pendingRequestsHeaderPanelLabel.Size = new Size(156, 25);
            pendingRequestsHeaderPanelLabel.TabIndex = 0;
            pendingRequestsHeaderPanelLabel.Text = "Service Requests";
            // 
            // addServiceLabel
            // 
            addServiceLabel.BackColor = Color.Black;
            addServiceLabel.BorderStyle = BorderStyle.FixedSingle;
            addServiceLabel.Cursor = Cursors.Hand;
            addServiceLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            addServiceLabel.ForeColor = Color.White;
            addServiceLabel.Location = new Point(483, 83);
            addServiceLabel.Name = "addServiceLabel";
            addServiceLabel.Size = new Size(292, 40);
            addServiceLabel.TabIndex = 5;
            addServiceLabel.Text = "+ Add Service";
            addServiceLabel.TextAlign = ContentAlignment.MiddleCenter;
            addServiceLabel.Click += addServiceLabel_Click;
            // 
            // pendingRequestsPanel
            // 
            pendingRequestsPanel.AutoScroll = true;
            pendingRequestsPanel.Location = new Point(26, 170);
            pendingRequestsPanel.Name = "pendingRequestsPanel";
            pendingRequestsPanel.Size = new Size(1099, 478);
            pendingRequestsPanel.TabIndex = 6;
            // 
            // dashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1118, 648);
            Controls.Add(pendingRequestsHeaderPanelLabel);
            Controls.Add(addServiceLabel);
            Controls.Add(mainInfoPanel);
            Controls.Add(tagline);
            Controls.Add(username);
            Controls.Add(profilePictureBox);
            Controls.Add(pendingRequestsPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboardForm";
            Text = "dashboardForm";
            Load += dashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
            mainInfoPanel.ResumeLayout(false);
            topStatPanel1.ResumeLayout(false);
            topStatPanel2.ResumeLayout(false);
            topStatPanel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox profilePictureBox;
        private Label username;
        private Label tagline;
        private FlowLayoutPanel mainInfoPanel;
        private Label pendingRequestsHeaderPanelLabel;
        private Panel topStatPanel1;
        private Label topStatLabel1;
        private Label topStatLabelNumber1;
        private Panel topStatPanel2;
        private Label topStatLabelNumber2;
        private Label topStatLabel2;
        private Panel topStatPanel3;
        private Label topStatLabelNumber3;
        private Label topStatLabel3;
        private Label addServiceLabel;
        private Panel pendingRequestsPanel;
    }
}