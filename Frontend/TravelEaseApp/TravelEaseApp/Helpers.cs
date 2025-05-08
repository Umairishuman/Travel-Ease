using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEaseApp
{
    public static class Helpers
    {
        public static void AddPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    // Optional: Set font to regular
                    // textBox.Font = new Font(textBox.Font, FontStyle.Regular);
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

        public static int SmoothTransition(int current, int target)
        {
            int diff = target - current;
            if (Math.Abs(diff) < 3)
                return target;
            return current + diff / 5;
        }

        //public static void AddHoverTransition(Control control, Color normalBackColor, Color hoverBackColor, Color normalTextColor, Color hoverTextColor)
        //{
        //    Color currentBackColor = normalBackColor;
        //    Color currentTextColor = normalTextColor;
        //    bool isHovering = false;

        //    control.BackColor = normalBackColor;
        //    control.ForeColor = normalTextColor;

        //    System.Windows.Forms.Timer hoverTimer = new System.Windows.Forms.Timer();
        //    hoverTimer.Interval = 15;
        //    hoverTimer.Tick += (s, e) =>
        //    {
        //        // Transition background
        //        Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
        //        int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
        //        int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
        //        int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
        //        currentBackColor = Color.FromArgb(rBack, gBack, bBack);

        //        // Transition text color
        //        Color targetTextColor = isHovering ? hoverTextColor : normalTextColor;
        //        int rText = SmoothTransition(currentTextColor.R, targetTextColor.R);
        //        int gText = SmoothTransition(currentTextColor.G, targetTextColor.G);
        //        int bText = SmoothTransition(currentTextColor.B, targetTextColor.B);
        //        currentTextColor = Color.FromArgb(rText, gText, bText);

        //        control.BackColor = currentBackColor;
        //        control.ForeColor = currentTextColor;
        //    };
        //    hoverTimer.Start();

        //    control.MouseEnter += (s, e) => isHovering = true;
        //    control.MouseLeave += (s, e) => isHovering = false;
        //}

        public static void AddHoverTransition(
            Control control,
            Color normalBackColor,
            Color hoverBackColor,
            Color normalTextColor,
            Color hoverTextColor)
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
                Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
                int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
                int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
                int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
                currentBackColor = Color.FromArgb(rBack, gBack, bBack);

                Color targetTextColor = isHovering ? hoverTextColor : normalTextColor;
                int rText = SmoothTransition(currentTextColor.R, targetTextColor.R);
                int gText = SmoothTransition(currentTextColor.G, targetTextColor.G);
                int bText = SmoothTransition(currentTextColor.B, targetTextColor.B);
                currentTextColor = Color.FromArgb(rText, gText, bText);

                control.BackColor = currentBackColor;
                control.ForeColor = currentTextColor;
            };
            hoverTimer.Start();

            // Unified hover detection for control and children
            void AttachHoverHandlers(Control target)
            {
                target.MouseEnter += (s, e) => isHovering = true;
                target.MouseLeave += (s, e) =>
                {
                    Point mousePos = control.PointToClient(Cursor.Position);
                    if (!control.ClientRectangle.Contains(mousePos))
                    {
                        isHovering = false;
                    }
                };

                foreach (Control child in target.Controls)
                {
                    AttachHoverHandlers(child); // Recursive for nested children
                }
            }

            AttachHoverHandlers(control);
        }


        public static void AddHoverTransition(Control triggerControl, Control targetControl, Color normalBackColor, Color hoverBackColor, Color normalTextColor, Color hoverTextColor)
        {
            Color currentBackColor = normalBackColor;
            Color currentTextColor = normalTextColor;
            bool isHovering = false;

            targetControl.BackColor = normalBackColor;
            targetControl.ForeColor = normalTextColor;

            System.Windows.Forms.Timer hoverTimer = new System.Windows.Forms.Timer();
            hoverTimer.Interval = 15;
            hoverTimer.Tick += (s, e) =>
            {
                Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
                int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
                int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
                int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
                currentBackColor = Color.FromArgb(rBack, gBack, bBack);

                Color targetTextCol = isHovering ? hoverTextColor : normalTextColor;
                int rText = SmoothTransition(currentTextColor.R, targetTextCol.R);
                int gText = SmoothTransition(currentTextColor.G, targetTextCol.G);
                int bText = SmoothTransition(currentTextColor.B, targetTextCol.B);
                currentTextColor = Color.FromArgb(rText, gText, bText);

                targetControl.BackColor = currentBackColor;
                targetControl.ForeColor = currentTextColor;
            };
            hoverTimer.Start();

            triggerControl.MouseEnter += (s, e) => isHovering = true;
            triggerControl.MouseLeave += (s, e) => isHovering = false;
        }


        public static void SetupGroupBoxFocusBehavior(GroupBox groupBox, TextBox innerTextBox)
        {
            groupBox.Enter += (s, e) => innerTextBox.Focus();

            groupBox.MouseEnter += (s, e) =>
            {
                groupBox.Cursor = Cursors.IBeam;
            };

            groupBox.MouseLeave += (s, e) =>
            {
                groupBox.Cursor = Cursors.Default;
            };

            groupBox.MouseClick += (s, e) =>
            {
                innerTextBox.Focus();
            };
            groupBox.Click += (s, e) =>
            {
                innerTextBox.Focus();
            };
        }

        public static void SetupPasswordField(GroupBox groupBox, TextBox textBox, PictureBox visibilityIcon, Image showIcon, Image hideIcon)
        {
            // Visibility toggle
            visibilityIcon.Cursor = Cursors.Hand;
            visibilityIcon.Click += (s, e) =>
            {
                bool isHidden = textBox.UseSystemPasswordChar;
                textBox.UseSystemPasswordChar = !isHidden;
                visibilityIcon.Image = isHidden ? hideIcon : showIcon;
            };

            // Focus textbox when groupbox is entered or clicked
            groupBox.Enter += (s, e) => textBox.Focus();
            groupBox.MouseClick += (s, e) => textBox.Focus();

            // Cursor changes
            groupBox.MouseEnter += (s, e) => groupBox.Cursor = Cursors.IBeam;
            groupBox.MouseLeave += (s, e) => groupBox.Cursor = Cursors.Default;
        }
    }
}
