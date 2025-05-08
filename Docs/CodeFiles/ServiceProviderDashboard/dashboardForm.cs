using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TravelEaseApp.ServiceProvider
{
    public partial class dashboardForm : Form
    {
        public dashboardForm()
        {
            InitializeComponent();

            // ProfilePicture
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, profilePictureBox.Width, profilePictureBox.Height);
            profilePictureBox.Region = new Region(path);

            // Add Service Button
            AddHoverTransition(addServiceLabel, addServiceLabel.BackColor, addServiceLabel.ForeColor, addServiceLabel.ForeColor, addServiceLabel.BackColor);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void dashboardForm_Load(object sender, EventArgs e)
        {
            //SetRoundedCorners(pendingRequestsPanel, 20);
            //SetRoundedCorners(flowLayoutPanel1, 20);
            //SetRoundedCorners(flowLayoutPanel2, 20);
            //SetRoundedCorners(panel3, 20);
            //SetRoundedCorners(flowLayoutPanel3, 20);
            //SetRoundedCorners(flowLayoutPanel4, 20);
            //SetRoundedCorners(flowLayoutPanel5, 20);
        }

        private void addServiceLabel_Click(object sender, EventArgs e)
        {
            RequestAddServiceForm?.Invoke();
        }

        private void profilePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public event Action RequestAddServiceForm;

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}