namespace TravelEase
{
    partial class SignInForm
    {
        //what is this? I don't know what this is
        private System.ComponentModel.IContainer components = null;
        //I don't know that dispose does nor does chat :)
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        //my variables
        private Label SignInHeading;
        private Label SignInSubtitle;
        private PictureBox topLeftLogo;
        private PictureBox signIntravller;

        private GroupBox groupBoxEmail;
        private TextBox innerEmailBox;

        private GroupBox groupBoxPassword;
        private TextBox innerPasswordBox;

        private Label signInButton;


        private void InitializeComponent()
        {
            SignInHeading = new Label();
            SignInSubtitle = new Label();
            topLeftLogo = new PictureBox();
            signIntravller = new PictureBox();
            groupBoxEmail = new GroupBox();
            innerEmailBox = new TextBox();
            groupBoxPassword = new GroupBox();
            VisibilityIcon = new PictureBox();
            innerPasswordBox = new TextBox();
            signInButton = new Label();
            ForgotPassword = new LinkLabel();
            Register = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)signIntravller).BeginInit();
            groupBoxEmail.SuspendLayout();
            groupBoxPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)VisibilityIcon).BeginInit();
            SuspendLayout();
            // 
            // SignInHeading
            // 
            SignInHeading.AutoSize = true;
            SignInHeading.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            SignInHeading.Location = new Point(98, 118);
            SignInHeading.Margin = new Padding(0);
            SignInHeading.Name = "SignInHeading";
            SignInHeading.Size = new Size(292, 37);
            SignInHeading.TabIndex = 0;
            SignInHeading.Text = "Sign In to Travel-Ease";
            SignInHeading.Click += SignInHeading_Click;
            // 
            // SignInSubtitle
            // 
            SignInSubtitle.AutoSize = true;
            SignInSubtitle.Font = new Font("Segoe UI", 10F);
            SignInSubtitle.ForeColor = Color.Gray;
            SignInSubtitle.Location = new Point(104, 99);
            SignInSubtitle.Name = "SignInSubtitle";
            SignInSubtitle.Size = new Size(122, 19);
            SignInSubtitle.TabIndex = 1;
            SignInSubtitle.Text = "Start Your Journey";
            SignInSubtitle.Click += SignInSubtitle_Click;
            // 
            // topLeftLogo
            // 
            topLeftLogo.Image = TravelEaseApp.Properties.Resources.travelEaseLogo;
            topLeftLogo.Location = new Point(228, 10);
            topLeftLogo.Name = "topLeftLogo";
            topLeftLogo.Padding = new Padding(2);
            topLeftLogo.Size = new Size(74, 63);
            topLeftLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            topLeftLogo.TabIndex = 0;
            topLeftLogo.TabStop = false;
            topLeftLogo.Click += topLeftLogo_Click;
            // 
            // signIntravller
            // 
            signIntravller.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            signIntravller.Image = TravelEaseApp.Properties.Resources.signInImage;
            signIntravller.Location = new Point(550, -2);
            signIntravller.Name = "signIntravller";
            signIntravller.Size = new Size(503, 566);
            signIntravller.SizeMode = PictureBoxSizeMode.StretchImage;
            signIntravller.TabIndex = 0;
            signIntravller.TabStop = false;
            // 
            // groupBoxEmail
            // 
            groupBoxEmail.Controls.Add(innerEmailBox);
            groupBoxEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxEmail.Location = new Point(82, 204);
            groupBoxEmail.Name = "groupBoxEmail";
            groupBoxEmail.Size = new Size(348, 58);
            groupBoxEmail.TabIndex = 0;
            groupBoxEmail.TabStop = false;
            groupBoxEmail.Text = "E-mail";
            groupBoxEmail.MouseClick += GroupBoxEmail_MouseClick;
            groupBoxEmail.MouseEnter += GroupBoxEmail_MouseEnter;
            groupBoxEmail.MouseLeave += GroupBoxEmail_MouseLeave;
            groupBoxEmail.Enter += groupBoxEmail_Enter;
            groupBoxEmail.Leave += groupBoxEmail_Leave;
            // 
            // innerEmailBox
            // 
            innerEmailBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerEmailBox.BorderStyle = BorderStyle.None;
            innerEmailBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            innerEmailBox.Location = new Point(13, 22);
            innerEmailBox.Name = "innerEmailBox";
            innerEmailBox.Size = new Size(281, 22);
            innerEmailBox.TabIndex = 3;
            innerEmailBox.TextChanged += innerEmailBox_TextChanged;
            // 
            // groupBoxPassword
            // 
            groupBoxPassword.Controls.Add(VisibilityIcon);
            groupBoxPassword.Controls.Add(innerPasswordBox);
            groupBoxPassword.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxPassword.Location = new Point(82, 268);
            groupBoxPassword.Name = "groupBoxPassword";
            groupBoxPassword.Size = new Size(348, 58);
            groupBoxPassword.TabIndex = 0;
            groupBoxPassword.TabStop = false;
            groupBoxPassword.Text = "Password";
            groupBoxPassword.MouseClick += GroupBoxPassword_MouseClick;
            groupBoxPassword.MouseEnter += GroupBoxPassword_MouseEnter;
            groupBoxPassword.MouseLeave += GroupBoxPassword_MouseLeave;
            groupBoxPassword.Enter += groupBoxPassword_Enter;
            groupBoxPassword.Leave += groupBoxPassword_Leave;
            // 
            // VisibilityIcon
            // 
            VisibilityIcon.Image = TravelEaseApp.Properties.Resources.visible;
            VisibilityIcon.Location = new Point(303, 15);
            VisibilityIcon.Margin = new Padding(3, 2, 3, 2);
            VisibilityIcon.Name = "VisibilityIcon";
            VisibilityIcon.Padding = new Padding(2);
            VisibilityIcon.Size = new Size(38, 36);
            VisibilityIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            VisibilityIcon.TabIndex = 6;
            VisibilityIcon.TabStop = false;
            VisibilityIcon.Click += VisibilityIcon_Click;
            VisibilityIcon.MouseEnter += VisibilityIcon_MouseEnter;
            VisibilityIcon.MouseLeave += VisibilityIcon_MouseLeave;
            // 
            // innerPasswordBox
            // 
            innerPasswordBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerPasswordBox.BorderStyle = BorderStyle.None;
            innerPasswordBox.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            innerPasswordBox.Location = new Point(13, 26);
            innerPasswordBox.Name = "innerPasswordBox";
            innerPasswordBox.Size = new Size(284, 17);
            innerPasswordBox.TabIndex = 0;
            innerPasswordBox.UseSystemPasswordChar = true;
            innerPasswordBox.TextChanged += innerPasswordBox_TextChanged;
            // 
            // signInButton
            // 
            signInButton.BackColor = Color.Black;
            signInButton.BorderStyle = BorderStyle.FixedSingle;
            signInButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            signInButton.ForeColor = Color.White;
            signInButton.Location = new Point(82, 372);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(348, 40);
            signInButton.TabIndex = 2;
            signInButton.Text = "Sign In";
            signInButton.TextAlign = ContentAlignment.MiddleCenter;
            signInButton.Click += signInButton_Click;
            // 
            // ForgotPassword
            // 
            ForgotPassword.AutoSize = true;
            ForgotPassword.LinkColor = Color.Black;
            ForgotPassword.Location = new Point(321, 340);
            ForgotPassword.Name = "ForgotPassword";
            ForgotPassword.Size = new Size(100, 15);
            ForgotPassword.TabIndex = 3;
            ForgotPassword.TabStop = true;
            ForgotPassword.Text = "Forgot Password?";
            ForgotPassword.LinkClicked += ForgotPassword_LinkClicked;
            // 
            // Register
            // 
            Register.AutoSize = true;
            Register.LinkColor = Color.Black;
            Register.Location = new Point(206, 441);
            Register.Name = "Register";
            Register.Size = new Size(96, 15);
            Register.TabIndex = 5;
            Register.TabStop = true;
            Register.Text = "Register/Sign-up";
            Register.LinkClicked += Register_LinkClicked;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1054, 562);
            Controls.Add(Register);
            Controls.Add(ForgotPassword);
            Controls.Add(SignInHeading);
            Controls.Add(SignInSubtitle);
            Controls.Add(topLeftLogo);
            Controls.Add(signIntravller);
            Controls.Add(groupBoxEmail);
            Controls.Add(groupBoxPassword);
            Controls.Add(signInButton);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(925, 497);
            Name = "SignInForm";
            Text = "Sign In";
            Load += SignInForm_Load;
            Click += SignInForm_Click;
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)signIntravller).EndInit();
            groupBoxEmail.ResumeLayout(false);
            groupBoxEmail.PerformLayout();
            groupBoxPassword.ResumeLayout(false);
            groupBoxPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)VisibilityIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        private void signInLabel_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, label.Width - 1, label.Height - 1);
            }
        }


        #endregion

        private LinkLabel ForgotPassword;
        private Label DontAccount;
        private LinkLabel Register;
        private PictureBox VisibilityIcon;
    }

}
