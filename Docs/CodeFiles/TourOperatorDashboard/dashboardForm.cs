using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelEaseApp.TourOperator
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

            AddHoverTransition(addTripLabel, addTripLabel.BackColor, addTripLabel.ForeColor, addTripLabel.ForeColor, addTripLabel.BackColor);
        }

        private void dashboardForm_Load(object sender, EventArgs e)
        {

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

        public event Action RequestAddTripForm;

        private void addTripLabel_Click(object sender, EventArgs e)
        {
            RequestAddTripForm?.Invoke();
        }
    }
}
