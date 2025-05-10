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
            label3 = new Label();
            dashboardTrayLabel = new Label();
            topStatPanel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            topStatPanel3 = new Panel();
            label4 = new Label();
            label5 = new Label();
            pendingRequestsHeaderPanelLabel = new Label();
            addServiceLabel = new Label();
            informationPanel = new Panel();
            label11 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            statPanel1 = new FlowLayoutPanel();
            statPanel2 = new FlowLayoutPanel();
            pendingRequestsPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
            mainInfoPanel.SuspendLayout();
            topStatPanel1.SuspendLayout();
            topStatPanel2.SuspendLayout();
            topStatPanel3.SuspendLayout();
            informationPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
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
            topStatPanel1.Controls.Add(label3);
            topStatPanel1.Controls.Add(dashboardTrayLabel);
            topStatPanel1.Location = new Point(3, 3);
            topStatPanel1.Name = "topStatPanel1";
            topStatPanel1.Size = new Size(99, 60);
            topStatPanel1.TabIndex = 5;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label3.Location = new Point(3, 2);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(93, 38);
            label3.TabIndex = 3;
            label3.Text = "5";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // dashboardTrayLabel
            // 
            dashboardTrayLabel.BackColor = Color.Transparent;
            dashboardTrayLabel.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            dashboardTrayLabel.Location = new Point(3, 37);
            dashboardTrayLabel.Name = "dashboardTrayLabel";
            dashboardTrayLabel.Size = new Size(93, 15);
            dashboardTrayLabel.TabIndex = 2;
            dashboardTrayLabel.Text = "Something1";
            dashboardTrayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topStatPanel2
            // 
            topStatPanel2.BackColor = Color.White;
            topStatPanel2.Controls.Add(label1);
            topStatPanel2.Controls.Add(label2);
            topStatPanel2.Location = new Point(108, 3);
            topStatPanel2.Name = "topStatPanel2";
            topStatPanel2.Size = new Size(99, 60);
            topStatPanel2.TabIndex = 6;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label1.Location = new Point(3, 2);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(93, 38);
            label1.TabIndex = 3;
            label1.Text = "5";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label2.Location = new Point(3, 37);
            label2.Name = "label2";
            label2.Size = new Size(93, 15);
            label2.TabIndex = 2;
            label2.Text = "Something2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // topStatPanel3
            // 
            topStatPanel3.BackColor = Color.White;
            topStatPanel3.Controls.Add(label4);
            topStatPanel3.Controls.Add(label5);
            topStatPanel3.Location = new Point(213, 3);
            topStatPanel3.Name = "topStatPanel3";
            topStatPanel3.Size = new Size(99, 60);
            topStatPanel3.TabIndex = 6;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            label4.Location = new Point(3, 2);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(93, 38);
            label4.TabIndex = 3;
            label4.Text = "5";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            label5.Location = new Point(3, 37);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 2;
            label5.Text = "Something3";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pendingRequestsHeaderPanelLabel
            // 
            pendingRequestsHeaderPanelLabel.AutoSize = true;
            pendingRequestsHeaderPanelLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            pendingRequestsHeaderPanelLabel.Location = new Point(720, 16);
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
            addServiceLabel.Location = new Point(26, 344);
            addServiceLabel.Name = "addServiceLabel";
            addServiceLabel.Size = new Size(427, 40);
            addServiceLabel.TabIndex = 5;
            addServiceLabel.Text = "+ Add Service";
            addServiceLabel.TextAlign = ContentAlignment.MiddleCenter;
            addServiceLabel.Click += addServiceLabel_Click;
            // 
            // informationPanel
            // 
            informationPanel.BackColor = Color.White;
            informationPanel.Controls.Add(label11);
            informationPanel.Controls.Add(label9);
            informationPanel.Controls.Add(label8);
            informationPanel.Controls.Add(label7);
            informationPanel.Controls.Add(label6);
            informationPanel.Location = new Point(26, 138);
            informationPanel.Name = "informationPanel";
            informationPanel.Size = new Size(427, 190);
            informationPanel.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label11.Location = new Point(8, 3);
            label11.Name = "label11";
            label11.Size = new Size(152, 32);
            label11.TabIndex = 10;
            label11.Text = "Information";
            label11.Click += label10_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(166, 59);
            label9.Name = "label9";
            label9.Size = new Size(74, 21);
            label9.TabIndex = 9;
            label9.Text = "Nowhere";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.Location = new Point(166, 38);
            label8.Name = "label8";
            label8.Size = new Size(56, 21);
            label8.TabIndex = 8;
            label8.Text = "Lonely";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(11, 59);
            label7.Name = "label7";
            label7.Size = new Size(149, 21);
            label7.TabIndex = 7;
            label7.Text = "Provider Location:";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(11, 38);
            label6.Name = "label6";
            label6.Size = new Size(129, 21);
            label6.TabIndex = 6;
            label6.Text = "Provider Name:";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = SystemColors.Control;
            flowLayoutPanel2.Controls.Add(statPanel1);
            flowLayoutPanel2.Controls.Add(statPanel2);
            flowLayoutPanel2.Location = new Point(23, 402);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(433, 246);
            flowLayoutPanel2.TabIndex = 1;
            // 
            // statPanel1
            // 
            statPanel1.BackColor = Color.White;
            statPanel1.Location = new Point(3, 3);
            statPanel1.Name = "statPanel1";
            statPanel1.Size = new Size(209, 243);
            statPanel1.TabIndex = 2;
            // 
            // statPanel2
            // 
            statPanel2.BackColor = Color.White;
            statPanel2.Location = new Point(218, 3);
            statPanel2.Name = "statPanel2";
            statPanel2.Size = new Size(209, 243);
            statPanel2.TabIndex = 3;
            // 
            // pendingRequestsPanel
            // 
            pendingRequestsPanel.AutoScroll = true;
            pendingRequestsPanel.Location = new Point(473, 42);
            pendingRequestsPanel.Name = "pendingRequestsPanel";
            pendingRequestsPanel.Size = new Size(652, 606);
            pendingRequestsPanel.TabIndex = 6;
            // 
            // dashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1118, 648);
            Controls.Add(pendingRequestsHeaderPanelLabel);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(informationPanel);
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
            informationPanel.ResumeLayout(false);
            informationPanel.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
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
        private Label dashboardTrayLabel;
        private Label label3;
        private Panel topStatPanel2;
        private Label label1;
        private Label label2;
        private Panel topStatPanel3;
        private Label label4;
        private Label label5;
        private Label addServiceLabel;
        private Panel informationPanel;
        private Label label11;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel statPanel1;
        private FlowLayoutPanel statPanel2;
        private Panel pendingRequestsPanel;
    }
}