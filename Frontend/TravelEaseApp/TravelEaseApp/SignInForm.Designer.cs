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


        private void InitializeComponent()
        {
            SignInHeading = new Label();
            SignInSubtitle = new Label();
            topLeftLogo = new PictureBox();
            signIntravller = new PictureBox();
            groupBoxEmail = new GroupBox();
            innerEmailBox = new TextBox();
            groupBoxPassword = new GroupBox();
            innerPasswordBox = new TextBox();
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)signIntravller).BeginInit();
            groupBoxEmail.SuspendLayout();
            groupBoxPassword.SuspendLayout();
            SuspendLayout();
            // 
            // SignInHeading
            // 
            SignInHeading.AutoSize = true;
            SignInHeading.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            SignInHeading.Location = new Point(75, 114);
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
            SignInSubtitle.Location = new Point(81, 95);
            SignInSubtitle.Name = "SignInSubtitle";
            SignInSubtitle.Size = new Size(122, 19);
            SignInSubtitle.TabIndex = 1;
            SignInSubtitle.Text = "Start Your Journey";
            SignInSubtitle.Click += SignInSubtitle_Click;
            // 
            // topLeftLogo
            // 
            topLeftLogo.Image = TravelEaseApp.Properties.Resources.travelEaseLogo;
            topLeftLogo.Location = new Point(183, 12);
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
            signIntravller.Image = TravelEaseApp.Properties.Resources.signInImage;
            signIntravller.Location = new Point(461, 0);
            signIntravller.Name = "signIntravller";
            signIntravller.Size = new Size(460, 520);
            signIntravller.SizeMode = PictureBoxSizeMode.StretchImage;
            signIntravller.TabIndex = 0;
            signIntravller.TabStop = false;
            // 
            // groupBoxEmail
            // 
            groupBoxEmail.Controls.Add(innerEmailBox);
            groupBoxEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxEmail.Location = new Point(75, 199);
            groupBoxEmail.Name = "groupBoxEmail";
            groupBoxEmail.Size = new Size(292, 59);
            groupBoxEmail.TabIndex = 0;
            groupBoxEmail.TabStop = false;
            groupBoxEmail.Text = "E-mail";

            groupBoxEmail.MouseEnter += GroupBoxEmail_MouseEnter;
            groupBoxEmail.MouseLeave += GroupBoxEmail_MouseLeave;
            groupBoxEmail.Enter += groupBoxEmail_Enter;
            groupBoxEmail.Leave += groupBoxEmail_Leave;
            groupBoxEmail.MouseClick += GroupBoxEmail_MouseClick;
            // 
            // innerEmailBox
            // 
            innerEmailBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerEmailBox.BorderStyle = BorderStyle.None;
            innerEmailBox.Location = new Point(13, 25);
            innerEmailBox.Name = "innerEmailBox";
            innerEmailBox.Size = new Size(272, 15);
            innerEmailBox.TabIndex = 3;
            innerEmailBox.TextChanged += innerEmailBox_TextChanged;
            AddPlaceholder(innerEmailBox, "abc@gmail.com");
            // 
            // groupBoxPassword
            // 
            groupBoxPassword.Controls.Add(innerPasswordBox);
            groupBoxPassword.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxPassword.Location = new Point(75, 264);
            groupBoxPassword.Name = "groupBoxPassword";
            groupBoxPassword.Size = new Size(292, 59);
            groupBoxPassword.TabIndex = 0;
            groupBoxPassword.TabStop = false;
            groupBoxPassword.Text = "Password";

            groupBoxPassword.Enter += groupBoxPassword_Enter;
            groupBoxPassword.Leave += groupBoxPassword_Leave;
            groupBoxPassword.MouseEnter += GroupBoxPassword_MouseEnter;
            groupBoxPassword.MouseLeave += GroupBoxPassword_MouseLeave;
            groupBoxPassword.MouseClick += GroupBoxPassword_MouseClick;
            // 
            // innerPasswordBox
            // 
            innerPasswordBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerPasswordBox.BorderStyle = BorderStyle.None;
            innerPasswordBox.Location = new Point(13, 26);
            innerPasswordBox.Name = "innerPasswordBox";
            innerPasswordBox.Size = new Size(272, 15);
            innerPasswordBox.TabIndex = 0;
            innerPasswordBox.UseSystemPasswordChar = true;
            innerPasswordBox.TextChanged += innerPasswordBox_TextChanged;
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(920, 520);
            Controls.Add(SignInHeading);
            Controls.Add(SignInSubtitle);
            Controls.Add(topLeftLogo);
            Controls.Add(signIntravller);
            Controls.Add(groupBoxEmail);
            Controls.Add(groupBoxPassword);
            Margin = new Padding(3, 2, 3, 2);
            Name = "SignInForm";
            Text = "Sign In";
            Load += SignInForm_Load;
            //on click on the form
            Click += SignInForm_Click;
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)signIntravller).EndInit();
            groupBoxEmail.ResumeLayout(false);
            groupBoxEmail.PerformLayout();
            groupBoxPassword.ResumeLayout(false);
            groupBoxPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
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


        #endregion
    }

}
