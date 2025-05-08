using System;
using System.Windows.Forms;
using TravelEaseApp;
using static TravelEaseApp.Helpers;
namespace TravelEase
{
    public partial class SignInForm : Form
    {
        ForgotPassword forgotPasswordForm; // Create an instance of the ForgotPassword form
        Label hiddenLabel;
        public SignInForm()
        {
            InitializeComponent(); // Sets up the UI (controls, layout) — defined in Designer

            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0); // Invisible
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false; // Does not appear in the tab order
            this.Controls.Add(hiddenLabel);

            this.ActiveControl = hiddenLabel; // Set focus to the invisible label

            AddPlaceholder(innerEmailBox, "BlazingBeam@HELP.com");
            AddPlaceholder(innerPasswordBox, "YOU ARE A PASSWORD");
            AddHoverTransition(signInButton, signInButton.BackColor, signInButton.ForeColor, signInButton.ForeColor, signInButton.BackColor);
            AddHoverTransition(VisibilityIcon, VisibilityIcon.BackColor, Color.Silver, VisibilityIcon.ForeColor, VisibilityIcon.ForeColor);
        }
        // Method to set rounded corners for a control
        private void SetRoundedCorners(Control control, int radius)
        {
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                // Create a rounded rectangle path
                path.AddArc(0, 0, radius, radius, 180, 90); // Top-left corner
                path.AddArc(control.Width - radius - 1, 0, radius, radius, 270, 90); // Top-right corner
                path.AddArc(control.Width - radius - 1, control.Height - radius - 1, radius, radius, 0, 90); // Bottom-right corner
                path.AddArc(0, control.Height - radius - 1, radius, radius, 90, 90); // Bottom-left corner
                path.CloseAllFigures();

                // Set the control's region to the rounded path
                control.Region = new Region(path);
            }
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {
            // This runs when the form is loaded
            this.Text = "TravelEase - Sign In"; // Set the window title
            //CenterCursorInRichTextBox();  // Center the cursor when the form loads
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }
        private void SignInForm_Click(object sender, EventArgs e)
        {
            // This runs when the form is clicked
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }

        private void SignInHeading_Click(object sender, EventArgs e)
        {
            //no need 
        }

        private void SignInSubtitle_Click(object sender, EventArgs e)
        {
            //no need
        }


        private void topLeftLogo_Click(object sender, EventArgs e)
        {
            //no need
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //group email box events
        private void innerEmailBox_TextChanged(object sender, EventArgs e)
        {
            //we will see
        }
        private void groupBoxEmail_Enter(object sender, EventArgs e)
        {
            innerEmailBox.Focus();
            //groupBoxEmail.BackColor = Color.LightBlue;
        }
        private void groupBoxEmail_Leave(object sender, EventArgs e)
        {
            groupBoxEmail.BackColor = Color.White; // Reset the background color when leaving
        }
        private void GroupBoxEmail_MouseEnter(object sender, EventArgs e)
        {

            groupBoxEmail.Cursor = Cursors.IBeam; // Change cursor to I-beam

        }

        private void GroupBoxEmail_MouseClick(object sender, MouseEventArgs e)
        {
            innerEmailBox.Focus(); // Set focus to the email box when the group box is clicked
        }
        // Event handler for MouseLeave
        private void GroupBoxEmail_MouseLeave(object sender, EventArgs e)
        {
            groupBoxEmail.Cursor = Cursors.Default; // Restore default cursor
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////
        private void groupBoxPassword_Enter(object sender, EventArgs e)
        {
            innerPasswordBox.Focus();
            //groupBoxPassword.BackColor = Color.LightBlue;
        }
        private void groupBoxPassword_Leave(object sender, EventArgs e)
        {
            groupBoxPassword.BackColor = Color.Transparent; // Reset the background color when leaving
        }
        private void GroupBoxPassword_MouseEnter(object sender, EventArgs e)
        {
            groupBoxPassword.Cursor = Cursors.IBeam; // Change cursor to I-beam
        }
        // Event handler for MouseLeave
        private void GroupBoxPassword_MouseLeave(object sender, EventArgs e)
        {
            groupBoxPassword.Cursor = Cursors.Default; // Restore default cursor
        }

        private void GroupBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            innerPasswordBox.Focus(); // Set focus to the password box when the group box is clicked
        }
        private void innerPasswordBox_TextChanged(object sender, EventArgs e)
        {

        }
        ///////////////////////////////////////////////////////////////////////////////////////////////
        //sign In button events
        private void signInButton_Click(object sender, EventArgs e)
        {
            // Handle sign-in logic here
            string email = innerEmailBox.Text;
            string password = innerPasswordBox.Text;
            // Example: Display a message box with the entered email and password
            MessageBox.Show($"Email: {email}\nPassword: {password}", "Sign In");
        }

        private void ForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgotPasswordForm = new ForgotPassword(this); // Create a new instance of the ForgotPassword form
            this.Hide(); // Hide the current form
            forgotPasswordForm.FormClosed += (s, args) => this.Show(); // Show the current form when ForgotPassword is closed
            forgotPasswordForm.Show(); // Show the ForgotPassword form
        }

        private void DontAccount_Click(object sender, EventArgs e)
        {

        }

        private void Register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration_Form registration_Form = new Registration_Form();
            this.Hide();
            registration_Form.FormClosed += (s, args) => this.Show();
            registration_Form.Show();
        }
        ////////////////////////////////////////////////////////////////////////////////////
        //////eye icond
        ///
        //mouse enter
        private void VisibilityIcon_MouseEnter(object sender, EventArgs e)
        {
            // Change the cursor to a hand when hovering over the icon
            VisibilityIcon.Cursor = Cursors.Hand;
           
        }
        //mouse leave
        private void VisibilityIcon_MouseLeave(object sender, EventArgs e)
        {
            // Change the cursor back to default when not hovering
            VisibilityIcon.Cursor = Cursors.Default;
        }
        //mouse click
        //private void VisibilityIcon_MouseClick(object sender, MouseEventArgs e)
        //{
        //    // Toggle the password visibility
        //    if (innerPasswordBox.UseSystemPasswordChar)
        //    {
        //        innerPasswordBox.UseSystemPasswordChar = false; // Show the password
        //        VisibilityIcon.Image = TravelEaseApp.Properties.Resources.visible; // Change icon to open eye
        //    }
        //    else
        //    {
        //        innerPasswordBox.UseSystemPasswordChar = true; // Hide the password
        //        VisibilityIcon.Image = TravelEaseApp.Properties.Resources.hide; // Change icon to closed eye
        //    }
        //}
        private void VisibilityIcon_Click(object sender, EventArgs e)
        {
            if (innerPasswordBox.UseSystemPasswordChar)
            {
                innerPasswordBox.UseSystemPasswordChar = false; // Show the password
                VisibilityIcon.Image = TravelEaseApp.Properties.Resources.hide; // Change icon to open eye
            }
            else
            {
                innerPasswordBox.UseSystemPasswordChar = true; // Hide the password
                VisibilityIcon.Image = TravelEaseApp.Properties.Resources.visible; // Change icon to closed eye
            }
        }
    }
}
