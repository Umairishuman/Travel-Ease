namespace TravelEaseApp
{
    partial class ForgotPassword
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
            topLeftLogo = new PictureBox();
            groupBoxEmail = new GroupBox();
            innerEmailBox = new TextBox();
            groupBoxNewPassword = new GroupBox();
            VisibilityIconNewPass = new PictureBox();
            innerNewPasswordBox = new TextBox();
            ConfirmPassword = new GroupBox();
            VisibilityIconConfirmPass = new PictureBox();
            ConfirmInnerTextBox = new TextBox();
            ConfirmButton = new Label();
            GoBackArrow = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).BeginInit();
            groupBoxEmail.SuspendLayout();
            groupBoxNewPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VisibilityIconNewPass).BeginInit();
            ConfirmPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VisibilityIconConfirmPass).BeginInit();
            ((System.ComponentModel.ISupportInitialize)GoBackArrow).BeginInit();
            SuspendLayout();
            // 
            // topLeftLogo
            // 
            topLeftLogo.Image = Properties.Resources.travelEaseLogo;
            topLeftLogo.Location = new Point(446, 25);
            topLeftLogo.Name = "topLeftLogo";
            topLeftLogo.Padding = new Padding(2);
            topLeftLogo.Size = new Size(60, 55);
            topLeftLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            topLeftLogo.TabIndex = 1;
            topLeftLogo.TabStop = false;
            // 
            // groupBoxEmail
            // 
            groupBoxEmail.BackColor = Color.White;
            groupBoxEmail.Controls.Add(innerEmailBox);
            groupBoxEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxEmail.Location = new Point(152, 101);
            groupBoxEmail.Name = "groupBoxEmail";
            groupBoxEmail.Size = new Size(650, 58);
            groupBoxEmail.TabIndex = 2;
            groupBoxEmail.TabStop = false;
            groupBoxEmail.Text = "E-mail";
            groupBoxEmail.MouseClick += groupBoxEmail_MouseClick;
            groupBoxEmail.MouseEnter += groupBoxEmail_MouseEnter;
            groupBoxEmail.MouseLeave += groupBoxEmail_MouseLeave;
            groupBoxEmail.Enter += groupBoxEmail_Enter;
            // 
            // innerEmailBox
            // 
            innerEmailBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerEmailBox.BorderStyle = BorderStyle.None;
            innerEmailBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            innerEmailBox.Location = new Point(13, 20);
            innerEmailBox.Name = "innerEmailBox";
            innerEmailBox.Size = new Size(624, 20);
            innerEmailBox.TabIndex = 3;
            innerEmailBox.TextChanged += innerEmailBox_TextChanged;
            // 
            // groupBoxNewPassword
            // 
            groupBoxNewPassword.Controls.Add(innerNewPasswordBox);
            groupBoxNewPassword.Controls.Add(VisibilityIconNewPass);
            groupBoxNewPassword.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxNewPassword.Location = new Point(152, 226);
            groupBoxNewPassword.Name = "groupBoxNewPassword";
            groupBoxNewPassword.Size = new Size(292, 58);
            groupBoxNewPassword.TabIndex = 3;
            groupBoxNewPassword.TabStop = false;
            groupBoxNewPassword.Text = "New Password";
            groupBoxNewPassword.MouseEnter += groupBoxNewPassword_MouseEnter;
            groupBoxNewPassword.MouseLeave += groupBoxNewPassword_MouseLeave;
            groupBoxNewPassword.Enter += groupBoxNewPassword_Enter;
            groupBoxNewPassword.MouseClick += groupBoxNewPassword_MouseClick;

            // 
            // VisibilityIconNewPass
            // 
            VisibilityIconNewPass.Image = Properties.Resources.visible;
            VisibilityIconNewPass.Location = new Point(248, 16);
            VisibilityIconNewPass.Margin = new Padding(3, 2, 3, 2);
            VisibilityIconNewPass.Name = "VisibilityIconNewPass";
            VisibilityIconNewPass.Padding = new Padding(2);
            VisibilityIconNewPass.Size = new Size(38, 35);
            VisibilityIconNewPass.SizeMode = PictureBoxSizeMode.StretchImage;
            VisibilityIconNewPass.TabIndex = 7;
            VisibilityIconNewPass.TabStop = false;
            VisibilityIconNewPass.Click += VisibilityIconNewPass_Click;
            VisibilityIconNewPass.MouseEnter += VisibilityIconNewPass_MouseEnter;
            VisibilityIconNewPass.MouseLeave += VisibilityIconNewPass_MouseLeave;
            // 
            // innerNewPasswordBox
            // 
            innerNewPasswordBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerNewPasswordBox.BorderStyle = BorderStyle.None;
            innerNewPasswordBox.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            innerNewPasswordBox.Location = new Point(13, 25);
            innerNewPasswordBox.Name = "innerNewPasswordBox";
            innerNewPasswordBox.Size = new Size(226, 18);
            innerNewPasswordBox.TabIndex = 0;
            innerNewPasswordBox.UseSystemPasswordChar = true;
            // 
            // ConfirmPassword
            // 
            ConfirmPassword.Controls.Add(VisibilityIconConfirmPass);
            ConfirmPassword.Controls.Add(ConfirmInnerTextBox);
            ConfirmPassword.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConfirmPassword.Location = new Point(510, 226);
            ConfirmPassword.Name = "ConfirmPassword";
            ConfirmPassword.Size = new Size(292, 58);
            ConfirmPassword.TabIndex = 4;
            ConfirmPassword.TabStop = false;
            ConfirmPassword.Text = "Confirm Password";
            ConfirmPassword.MouseClick += ConfirmPassword_MouseClick;
            ConfirmPassword.MouseEnter += ConfirmPassword_MouseEnter;
            ConfirmPassword.MouseLeave += ConfirmPassword_MouseLeave;
            ConfirmPassword.Enter += ConfirmPassword_Enter;
            // 
            // VisibilityIconConfirmPass
            // 
            VisibilityIconConfirmPass.Image = Properties.Resources.visible;
            VisibilityIconConfirmPass.Location = new Point(248, 16);
            VisibilityIconConfirmPass.Margin = new Padding(3, 2, 3, 2);
            VisibilityIconConfirmPass.Name = "VisibilityIconConfirmPass";
            VisibilityIconConfirmPass.Padding = new Padding(2);
            VisibilityIconConfirmPass.Size = new Size(38, 35);
            VisibilityIconConfirmPass.SizeMode = PictureBoxSizeMode.StretchImage;
            VisibilityIconConfirmPass.TabIndex = 8;
            VisibilityIconConfirmPass.TabStop = false;
            VisibilityIconConfirmPass.Click += VisibilityIconConfirmPass_Click;
            VisibilityIconConfirmPass.MouseEnter += VisibilityIconConfirmPass_MouseEnter;
            VisibilityIconConfirmPass.MouseLeave += VisibilityIconConfirmPass_MouseLeave;
            // 
            // ConfirmInnerTextBox
            // 
            ConfirmInnerTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConfirmInnerTextBox.BorderStyle = BorderStyle.None;
            ConfirmInnerTextBox.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold);
            ConfirmInnerTextBox.Location = new Point(13, 27);
            ConfirmInnerTextBox.Name = "ConfirmInnerTextBox";
            ConfirmInnerTextBox.Size = new Size(226, 18);
            ConfirmInnerTextBox.TabIndex = 0;
            ConfirmInnerTextBox.UseSystemPasswordChar = true;
            // 
            // ConfirmButton
            // 
            ConfirmButton.BackColor = Color.Black;
            ConfirmButton.BorderStyle = BorderStyle.FixedSingle;
            ConfirmButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            ConfirmButton.ForeColor = Color.White;
            ConfirmButton.Location = new Point(332, 354);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(292, 40);
            ConfirmButton.TabIndex = 5;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.TextAlign = ContentAlignment.MiddleCenter;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // GoBackArrow
            // 
            GoBackArrow.BackColor = Color.WhiteSmoke;
            GoBackArrow.Image = Properties.Resources.Arrow;
            GoBackArrow.Location = new Point(-1, -2);
            GoBackArrow.Margin = new Padding(3, 2, 3, 2);
            GoBackArrow.Name = "GoBackArrow";
            GoBackArrow.Size = new Size(51, 53);
            GoBackArrow.SizeMode = PictureBoxSizeMode.StretchImage;
            GoBackArrow.TabIndex = 6;
            GoBackArrow.TabStop = false;
            GoBackArrow.Click += GoBackArrow_Click;
            // 
            // ForgotPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(920, 520);
            Controls.Add(GoBackArrow);
            Controls.Add(ConfirmButton);
            Controls.Add(ConfirmPassword);
            Controls.Add(groupBoxEmail);
            Controls.Add(groupBoxNewPassword);
            Controls.Add(topLeftLogo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ForgotPassword";
            Text = "ForgotPassword";
            Load += ForgotPassword_Load;
            Click += ForgotPassword_Click;
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).EndInit();
            groupBoxEmail.ResumeLayout(false);
            groupBoxEmail.PerformLayout();
            groupBoxNewPassword.ResumeLayout(false);
            groupBoxNewPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VisibilityIconNewPass).EndInit();
            ConfirmPassword.ResumeLayout(false);
            ConfirmPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VisibilityIconConfirmPass).EndInit();
            ((System.ComponentModel.ISupportInitialize)GoBackArrow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox topLeftLogo;
        private GroupBox groupBoxEmail;
        private TextBox innerEmailBox;
        private GroupBox groupBoxNewPassword;
        private TextBox innerNewPasswordBox;
        private GroupBox ConfirmPassword;
        private TextBox ConfirmInnerTextBox;
        private Label ConfirmButton;
        private PictureBox GoBackArrow;
        private PictureBox VisibilityIconNewPass;
        private PictureBox VisibilityIconConfirmPass;
    }
}