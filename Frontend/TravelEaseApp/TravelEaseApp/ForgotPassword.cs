﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelEase;
using System.Data.SqlClient;
using static TravelEaseApp.Helpers;

namespace TravelEaseApp
{


    public partial class ForgotPassword : Form
    {
        SignInForm signInForm;
        Label hiddenLabel;
        public ForgotPassword(SignInForm form)
        {
            InitializeComponent();
            signInForm = form; // Assign the passed SignInForm instance to the class variable

            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0); // Invisible
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false; // Does not appear in the tab order
            this.Controls.Add(hiddenLabel);

            this.ActiveControl = hiddenLabel; // Set focus to the invisible label

            AddPlaceholder(this.innerEmailBox, "muhammadumair19925@gmail.com");
            AddPlaceholder(this.innerNewPasswordBox, "New Password");
            AddPlaceholder(this.ConfirmInnerTextBox, "Confirm Password");
            AddHoverTransition(ConfirmButton, ConfirmButton.BackColor, ConfirmButton.ForeColor, ConfirmButton.ForeColor, ConfirmButton.BackColor);
            AddHoverTransition(GoBackArrow, GoBackArrow.BackColor, Color.Silver, GoBackArrow.ForeColor, GoBackArrow.ForeColor);

        }
        public void SetSignInForm(SignInForm form)
        {
            signInForm = form;
        }

        private void ForgotPassword_Load(object sender, EventArgs e)
        {

        }
        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }



        public static bool ValidateEmail(TextBox emailTextBox)
        {
            string email = emailTextBox.Text.Trim();

            // Step 1: Validate email format using Regex
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Invalid email format", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Step 2: Check if email exists in the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM users WHERE contact_email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);

                        int emailCount = (int)command.ExecuteScalar();
                        if (emailCount > 0)
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("No email found", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool ValidatePassword(TextBox newPasswordTextBox, TextBox confirmPasswordTextBox)
        {
            string newPassword = newPasswordTextBox.Text.Trim();
            string confirmPassword = confirmPasswordTextBox.Text.Trim();

            // Step 1: Check if the password is more than 8 characters
            if (newPassword.Length <= 8)
            {
                MessageBox.Show("Password must be more than 8 characters", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Step 2: Check if the new password and confirm password are the same
            if (!newPassword.Equals(confirmPassword))
            {
                MessageBox.Show("Passwords do not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // If all validations pass
            return true;
        }

        private void innerEmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBoxEmail_Enter(object sender, EventArgs e)
        {
            innerEmailBox.Focus();
        }
        //mouse click
        private void groupBoxEmail_MouseClick(object sender, MouseEventArgs e)
        {
            innerEmailBox.Focus();
        }
        private void groupBoxEmail_MouseEnter(object sender, EventArgs e)
        {
            groupBoxEmail.Cursor = Cursors.IBeam; // Change cursor to I-beam
        }
        private void groupBoxEmail_MouseLeave(object sender, EventArgs e)
        {
            groupBoxEmail.Cursor = Cursors.Default; // Reset cursor to default
        }
        //ENter leave mouse_enter mouse_leave click
        //groupBoxNewPassword
        ////////////////////////////////////////////////////////
        ///
        private void groupBoxNewPassword_Enter(object sender, EventArgs e)
        {
            innerNewPasswordBox.Focus();
        }
        private void groupBoxNewPassword_MouseEnter(object sender, EventArgs e)
        {
            groupBoxNewPassword.Cursor = Cursors.IBeam; // Change cursor to I-beam
        }
        private void groupBoxNewPassword_MouseLeave(object sender, EventArgs e)
        {
            groupBoxNewPassword.Cursor = Cursors.Default; // Reset cursor to default
        }
        private void groupBoxNewPassword_MouseClick(object sender, MouseEventArgs e)
        {
            innerNewPasswordBox.Focus();
        }
        //groupBoxConfirmPassword
        private void ConfirmPassword_Enter(object sender, EventArgs e)
        {
            ConfirmInnerTextBox.Focus();
        }
        private void ConfirmPassword_MouseEnter(object sender, EventArgs e)
        {
            ConfirmPassword.Cursor = Cursors.IBeam; // Change cursor to I-beam
        }
        private void ConfirmPassword_MouseLeave(object sender, EventArgs e)
        {
            ConfirmPassword.Cursor = Cursors.Default; // Reset cursor to default
        }
        private void ConfirmPassword_MouseClick(object sender, MouseEventArgs e)
        {
            ConfirmInnerTextBox.Focus();
        }
        //private void 
        ////////////////////////////////////////////////////////////////////////////
        private void signInButton_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // Step 1: Validate the email
            bool isEmailValid = ValidateEmail(innerEmailBox);
            if (!isEmailValid)
            {
                return; // Exit if email validation fails
            }

            // Step 2: Validate the password
            bool isPasswordValid = ValidatePassword(innerNewPasswordBox, ConfirmInnerTextBox);
            if (!isPasswordValid)
            {
                return; // Exit if password validation fails
            }

            // Step 3: Update the password in the database
            string email = innerEmailBox.Text.Trim();
            string newPassword = innerNewPasswordBox.Text.Trim();
            string hashedPassword = newPassword; // Implement a hashing method for security

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE users SET password_hash = @PasswordHash WHERE contact_email = @Email";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        command.Parameters.AddWithValue("@Email", email);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to update password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GoBackArrow_Click(object sender, EventArgs e)
        {
            signInForm.Show();
            this.Close();
        }

        private void VisibilityIconNewPass_Click(object sender, EventArgs e)
        {
            if (innerNewPasswordBox.UseSystemPasswordChar)
            {
                innerNewPasswordBox.UseSystemPasswordChar = false; // Show the password
                VisibilityIconNewPass.Image = TravelEaseApp.Properties.Resources.hide; // Change icon to open eye
            }
            else
            {
                innerNewPasswordBox.UseSystemPasswordChar = true; // Hide the password
                VisibilityIconNewPass.Image = TravelEaseApp.Properties.Resources.visible; // Change icon to closed eye
            }
        }
        //mouse enter
        private void VisibilityIconNewPass_MouseEnter(object sender, EventArgs e)
        {
            // Change the cursor to a hand when hovering over the icon
            VisibilityIconNewPass.Cursor = Cursors.Hand;
        }
        //mouse leave
        private void VisibilityIconNewPass_MouseLeave(object sender, EventArgs e)
        {
            // Change the cursor back to default when not hovering
            VisibilityIconNewPass.Cursor = Cursors.Default;
        }
        //reapeating the same for confirm password///////////////////////////////////////////////////////////////////////////////////////
        private void VisibilityIconConfirmPass_Click(object sender, EventArgs e)
        {
            if (ConfirmInnerTextBox.UseSystemPasswordChar)
            {
                ConfirmInnerTextBox.UseSystemPasswordChar = false; // Show the password
                VisibilityIconConfirmPass.Image = TravelEaseApp.Properties.Resources.hide; // Change icon to open eye
            }
            else
            {
                ConfirmInnerTextBox.UseSystemPasswordChar = true; // Hide the password
                VisibilityIconConfirmPass.Image = TravelEaseApp.Properties.Resources.visible; // Change icon to closed eye
            }
        }
        //mouse enter
        private void VisibilityIconConfirmPass_MouseEnter(object sender, EventArgs e)
        {
            // Change the cursor to a hand when hovering over the icon
            VisibilityIconConfirmPass.Cursor = Cursors.Hand;
        }
        //mouse leave
        private void VisibilityIconConfirmPass_MouseLeave(object sender, EventArgs e)
        {
            // Change the cursor back to default when not hovering
            VisibilityIconConfirmPass.Cursor = Cursors.Default;
        }

    }
}
