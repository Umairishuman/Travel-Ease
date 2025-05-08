namespace TravelEaseApp.TourOperator
{
    partial class tourOperatorForm
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
            subFormPanel = new Panel();
            sidebarPanel = new FlowLayoutPanel();
            dashboardTrayPanel = new Panel();
            dashboardTrayLabel = new Label();
            dashboardTrayPictureBox = new PictureBox();
            tripTrayPanel = new Panel();
            tripTrayLabel = new Label();
            tripTrayPictureBox = new PictureBox();
            sidebarPanel.SuspendLayout();
            dashboardTrayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashboardTrayPictureBox).BeginInit();
            tripTrayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tripTrayPictureBox).BeginInit();
            SuspendLayout();
            // 
            // subFormPanel
            // 
            subFormPanel.BackColor = SystemColors.Control;
            subFormPanel.Location = new Point(112, 16);
            subFormPanel.Name = "subFormPanel";
            subFormPanel.Size = new Size(1134, 649);
            subFormPanel.TabIndex = 3;
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Controls.Add(dashboardTrayPanel);
            sidebarPanel.Controls.Add(tripTrayPanel);
            sidebarPanel.Location = new Point(19, 16);
            sidebarPanel.Margin = new Padding(20);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(70, 649);
            sidebarPanel.TabIndex = 2;
            // 
            // dashboardTrayPanel
            // 
            dashboardTrayPanel.Controls.Add(dashboardTrayLabel);
            dashboardTrayPanel.Controls.Add(dashboardTrayPictureBox);
            dashboardTrayPanel.Cursor = Cursors.Hand;
            dashboardTrayPanel.Location = new Point(3, 10);
            dashboardTrayPanel.Margin = new Padding(3, 10, 3, 10);
            dashboardTrayPanel.Name = "dashboardTrayPanel";
            dashboardTrayPanel.Size = new Size(64, 60);
            dashboardTrayPanel.TabIndex = 1;
            // 
            // dashboardTrayLabel
            // 
            dashboardTrayLabel.BackColor = Color.Transparent;
            dashboardTrayLabel.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            dashboardTrayLabel.Location = new Point(3, 45);
            dashboardTrayLabel.Name = "dashboardTrayLabel";
            dashboardTrayLabel.Size = new Size(58, 15);
            dashboardTrayLabel.TabIndex = 2;
            dashboardTrayLabel.Text = "Dashboard";
            dashboardTrayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dashboardTrayPictureBox
            // 
            dashboardTrayPictureBox.BackColor = Color.Transparent;
            dashboardTrayPictureBox.Image = Properties.Resources.dashboard_svgrepo_com_B;
            dashboardTrayPictureBox.Location = new Point(3, 3);
            dashboardTrayPictureBox.Name = "dashboardTrayPictureBox";
            dashboardTrayPictureBox.Size = new Size(58, 42);
            dashboardTrayPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            dashboardTrayPictureBox.TabIndex = 2;
            dashboardTrayPictureBox.TabStop = false;
            // 
            // tripTrayPanel
            // 
            tripTrayPanel.Controls.Add(tripTrayLabel);
            tripTrayPanel.Controls.Add(tripTrayPictureBox);
            tripTrayPanel.Cursor = Cursors.Hand;
            tripTrayPanel.Location = new Point(3, 90);
            tripTrayPanel.Margin = new Padding(3, 10, 3, 10);
            tripTrayPanel.Name = "tripTrayPanel";
            tripTrayPanel.Size = new Size(64, 60);
            tripTrayPanel.TabIndex = 3;
            // 
            // tripTrayLabel
            // 
            tripTrayLabel.BackColor = Color.Transparent;
            tripTrayLabel.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            tripTrayLabel.Location = new Point(3, 45);
            tripTrayLabel.Name = "tripTrayLabel";
            tripTrayLabel.Size = new Size(58, 15);
            tripTrayLabel.TabIndex = 2;
            tripTrayLabel.Text = "Trips";
            tripTrayLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tripTrayPictureBox
            // 
            tripTrayPictureBox.BackColor = Color.Transparent;
            tripTrayPictureBox.Image = Properties.Resources.travel_luggage_svgrepo_com_B;
            tripTrayPictureBox.Location = new Point(3, 3);
            tripTrayPictureBox.Name = "tripTrayPictureBox";
            tripTrayPictureBox.Size = new Size(58, 42);
            tripTrayPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            tripTrayPictureBox.TabIndex = 2;
            tripTrayPictureBox.TabStop = false;
            // 
            // tourOperatorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(subFormPanel);
            Controls.Add(sidebarPanel);
            Name = "tourOperatorForm";
            Text = "TourOperator";
            Load += tourOperatorForm_Load;
            sidebarPanel.ResumeLayout(false);
            dashboardTrayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dashboardTrayPictureBox).EndInit();
            tripTrayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tripTrayPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel subFormPanel;
        private FlowLayoutPanel sidebarPanel;
        private Panel dashboardTrayPanel;
        private Label dashboardTrayLabel;
        private PictureBox dashboardTrayPictureBox;
        private Panel tripTrayPanel;
        private Label tripTrayLabel;
        private PictureBox tripTrayPictureBox;
    }
}