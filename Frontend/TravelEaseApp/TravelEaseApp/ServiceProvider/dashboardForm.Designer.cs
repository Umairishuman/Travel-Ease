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
            dashboardTrayPanel = new Panel();
            label3 = new Label();
            dashboardTrayLabel = new Label();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            label4 = new Label();
            label5 = new Label();
            pendingRequestsPanel = new FlowLayoutPanel();
            pendingRequestsHeaderPanel = new Panel();
            pendingRequestsHeaderPanelLabel = new Label();
            mainStatsPanel = new FlowLayoutPanel();
            addServiceLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).BeginInit();
            mainInfoPanel.SuspendLayout();
            dashboardTrayPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pendingRequestsPanel.SuspendLayout();
            pendingRequestsHeaderPanel.SuspendLayout();
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
            mainInfoPanel.BackColor = Color.White;
            mainInfoPanel.Controls.Add(dashboardTrayPanel);
            mainInfoPanel.Controls.Add(panel1);
            mainInfoPanel.Controls.Add(panel2);
            mainInfoPanel.Location = new Point(141, 59);
            mainInfoPanel.Name = "mainInfoPanel";
            mainInfoPanel.Size = new Size(315, 64);
            mainInfoPanel.TabIndex = 3;
            // 
            // dashboardTrayPanel
            // 
            dashboardTrayPanel.Controls.Add(label3);
            dashboardTrayPanel.Controls.Add(dashboardTrayLabel);
            dashboardTrayPanel.Location = new Point(3, 3);
            dashboardTrayPanel.Name = "dashboardTrayPanel";
            dashboardTrayPanel.Size = new Size(99, 60);
            dashboardTrayPanel.TabIndex = 5;
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
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(108, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(99, 60);
            panel1.TabIndex = 6;
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
            // panel2
            // 
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(213, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(99, 60);
            panel2.TabIndex = 6;
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
            // pendingRequestsPanel
            // 
            pendingRequestsPanel.BackColor = Color.White;
            pendingRequestsPanel.Controls.Add(pendingRequestsHeaderPanel);
            pendingRequestsPanel.Location = new Point(477, 23);
            pendingRequestsPanel.Name = "pendingRequestsPanel";
            pendingRequestsPanel.Size = new Size(291, 216);
            pendingRequestsPanel.TabIndex = 4;
            // 
            // pendingRequestsHeaderPanel
            // 
            pendingRequestsHeaderPanel.Controls.Add(pendingRequestsHeaderPanelLabel);
            pendingRequestsHeaderPanel.Location = new Point(3, 3);
            pendingRequestsHeaderPanel.Name = "pendingRequestsHeaderPanel";
            pendingRequestsHeaderPanel.Size = new Size(288, 46);
            pendingRequestsHeaderPanel.TabIndex = 6;
            // 
            // pendingRequestsHeaderPanelLabel
            // 
            pendingRequestsHeaderPanelLabel.AutoSize = true;
            pendingRequestsHeaderPanelLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            pendingRequestsHeaderPanelLabel.Location = new Point(5, 10);
            pendingRequestsHeaderPanelLabel.Name = "pendingRequestsHeaderPanelLabel";
            pendingRequestsHeaderPanelLabel.Size = new Size(156, 25);
            pendingRequestsHeaderPanelLabel.TabIndex = 0;
            pendingRequestsHeaderPanelLabel.Text = "Service Requests";
            // 
            // mainStatsPanel
            // 
            mainStatsPanel.BackColor = Color.White;
            mainStatsPanel.Location = new Point(38, 141);
            mainStatsPanel.Name = "mainStatsPanel";
            mainStatsPanel.Size = new Size(411, 297);
            mainStatsPanel.TabIndex = 4;
            // 
            // addServiceLabel
            // 
            addServiceLabel.BackColor = Color.Blue;
            addServiceLabel.BorderStyle = BorderStyle.FixedSingle;
            addServiceLabel.Cursor = Cursors.Hand;
            addServiceLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            addServiceLabel.ForeColor = Color.White;
            addServiceLabel.Location = new Point(548, 398);
            addServiceLabel.Name = "addServiceLabel";
            addServiceLabel.Size = new Size(148, 40);
            addServiceLabel.TabIndex = 5;
            addServiceLabel.Text = "+ Add Service";
            addServiceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Location = new Point(477, 245);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(291, 139);
            flowLayoutPanel1.TabIndex = 5;
            // 
            // dashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(addServiceLabel);
            Controls.Add(mainStatsPanel);
            Controls.Add(pendingRequestsPanel);
            Controls.Add(mainInfoPanel);
            Controls.Add(tagline);
            Controls.Add(username);
            Controls.Add(profilePictureBox);
            Name = "dashboardForm";
            Text = "dashboardForm";
            ((System.ComponentModel.ISupportInitialize)profilePictureBox).EndInit();
            mainInfoPanel.ResumeLayout(false);
            dashboardTrayPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pendingRequestsPanel.ResumeLayout(false);
            pendingRequestsHeaderPanel.ResumeLayout(false);
            pendingRequestsHeaderPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox profilePictureBox;
        private Label username;
        private Label tagline;
        private FlowLayoutPanel mainInfoPanel;
        private FlowLayoutPanel pendingRequestsPanel;
        private FlowLayoutPanel mainStatsPanel;
        private Panel pendingRequestsHeaderPanel;
        private Label pendingRequestsHeaderPanelLabel;
        private Panel dashboardTrayPanel;
        private Label dashboardTrayLabel;
        private Label label3;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private Panel panel2;
        private Label label4;
        private Label label5;
        private Label addServiceLabel;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}