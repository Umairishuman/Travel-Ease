using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TravelEaseApp
{
    partial class ServiceProviderForm
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
            sidebarPanel = new FlowLayoutPanel();
            dashboardTrayPanel = new Panel();
            dashboardTrayLabel = new Label();
            dashboardTrayPictureBox = new PictureBox();
            serviceTrayPanel = new Panel();
            serviceTrayLabel = new Label();
            serviceTrayPictureBox = new PictureBox();
            subFormPanel = new Panel();
            sidebarPanel.SuspendLayout();
            dashboardTrayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dashboardTrayPictureBox).BeginInit();
            serviceTrayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)serviceTrayPictureBox).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Controls.Add(dashboardTrayPanel);
            sidebarPanel.Controls.Add(serviceTrayPanel);
            sidebarPanel.Location = new Point(18, 12);
            sidebarPanel.Margin = new Padding(20);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(70, 649);
            sidebarPanel.TabIndex = 0;
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
            dashboardTrayPanel.Click += dashboardTrayPanel_Click;
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
            // serviceTrayPanel
            // 
            serviceTrayPanel.Controls.Add(serviceTrayLabel);
            serviceTrayPanel.Controls.Add(serviceTrayPictureBox);
            serviceTrayPanel.Cursor = Cursors.Hand;
            serviceTrayPanel.Location = new Point(3, 90);
            serviceTrayPanel.Margin = new Padding(3, 10, 3, 10);
            serviceTrayPanel.Name = "serviceTrayPanel";
            serviceTrayPanel.Size = new Size(64, 60);
            serviceTrayPanel.TabIndex = 3;
            // 
            // serviceTrayLabel
            // 
            serviceTrayLabel.BackColor = Color.Transparent;
            serviceTrayLabel.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            serviceTrayLabel.Location = new Point(3, 45);
            serviceTrayLabel.Name = "serviceTrayLabel";
            serviceTrayLabel.Size = new Size(58, 15);
            serviceTrayLabel.TabIndex = 2;
            serviceTrayLabel.Text = "Service";
            serviceTrayLabel.TextAlign = ContentAlignment.MiddleCenter;
            serviceTrayLabel.Click += serviceTrayPanel_Click;
            // 
            // serviceTrayPictureBox
            // 
            serviceTrayPictureBox.BackColor = Color.Transparent;
            serviceTrayPictureBox.Image = Properties.Resources.service_bell_svgrepo_com_B;
            serviceTrayPictureBox.Location = new Point(3, 3);
            serviceTrayPictureBox.Name = "serviceTrayPictureBox";
            serviceTrayPictureBox.Size = new Size(58, 42);
            serviceTrayPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            serviceTrayPictureBox.TabIndex = 2;
            serviceTrayPictureBox.TabStop = false;
            // 
            // subFormPanel
            // 
            subFormPanel.BackColor = SystemColors.Control;
            subFormPanel.Location = new Point(111, 12);
            subFormPanel.Name = "subFormPanel";
            subFormPanel.Size = new Size(1134, 649);
            subFormPanel.TabIndex = 1;
            // 
            // ServiceProviderForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1264, 681);
            Controls.Add(subFormPanel);
            Controls.Add(sidebarPanel);
            Name = "ServiceProviderForm";
            Text = "ServiceProvider";
            Load += ServiceProviderForm_Load;
            sidebarPanel.ResumeLayout(false);
            dashboardTrayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dashboardTrayPictureBox).EndInit();
            serviceTrayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)serviceTrayPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private void AddPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    //set it to not bold
                    textBox.ForeColor = Color.Black;
                    //textBox.Font = new Font(textBox.Font, FontStyle.Regular);
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private int SmoothTransition(int current, int target)
        {
            int diff = target - current;
            if (Math.Abs(diff) < 3)
                return target;
            return current + diff / 5;
        }

        private void AddHoverTransition(Control control, Color normalBackColor, Color hoverBackColor, Color normalTextColor, Color hoverTextColor)
        {
            Color currentBackColor = normalBackColor;
            Color currentTextColor = normalTextColor;
            bool isHovering = false;

            control.BackColor = normalBackColor;
            control.ForeColor = normalTextColor;

            System.Windows.Forms.Timer hoverTimer = new System.Windows.Forms.Timer();
            hoverTimer.Interval = 15;
            hoverTimer.Tick += (s, e) =>
            {
                // Transition for background color
                Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
                int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
                int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
                int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
                currentBackColor = Color.FromArgb(rBack, gBack, bBack);

                // Transition for text color
                Color targetTextColor = isHovering ? hoverTextColor : normalTextColor;
                int rText = SmoothTransition(currentTextColor.R, targetTextColor.R);
                int gText = SmoothTransition(currentTextColor.G, targetTextColor.G);
                int bText = SmoothTransition(currentTextColor.B, targetTextColor.B);
                currentTextColor = Color.FromArgb(rText, gText, bText);

                // Apply colors
                control.BackColor = currentBackColor;
                control.ForeColor = currentTextColor;
            };
            hoverTimer.Start();

            control.MouseEnter += (s, e) => isHovering = true;
            control.MouseLeave += (s, e) => isHovering = false;
        }

        private void SetRoundedCorners(Control control, int radius)
        {
            if (control.Width < radius * 2 || control.Height < radius * 2)
                return;

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(control.Width - radius - 1, 0, radius, radius, 270, 90);
                path.AddArc(control.Width - radius - 1, control.Height - radius - 1, radius, radius, 0, 90);
                path.AddArc(0, control.Height - radius - 1, radius, radius, 90, 90);
                path.CloseAllFigures();

                control.Region = new Region(path);
            }
        }


        private FlowLayoutPanel sidebarPanel;
        private Panel dashboardTrayPanel;
        private PictureBox dashboardTrayPictureBox;
        private Label dashboardTrayLabel;
        private Panel serviceTrayPanel;
        private Label serviceTrayLabel;
        private PictureBox serviceTrayPictureBox;
        private Panel subFormPanel;
    }
}