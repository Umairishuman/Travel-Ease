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
            innerPasswordBox = new TextBox();
            signInButton = new Label();
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
            SignInHeading.Location = new Point(107, 190);
            SignInHeading.Margin = new Padding(0);
            SignInHeading.Name = "SignInHeading";
            SignInHeading.Size = new Size(427, 54);
            SignInHeading.TabIndex = 0;
            SignInHeading.Text = "Sign In to Travel-Ease";
            SignInHeading.Click += SignInHeading_Click;
            // 
            // SignInSubtitle
            // 
            SignInSubtitle.AutoSize = true;
            SignInSubtitle.Font = new Font("Segoe UI", 10F);
            SignInSubtitle.ForeColor = Color.Gray;
            SignInSubtitle.Location = new Point(116, 158);
            SignInSubtitle.Margin = new Padding(4, 0, 4, 0);
            SignInSubtitle.Name = "SignInSubtitle";
            SignInSubtitle.Size = new Size(170, 28);
            SignInSubtitle.TabIndex = 1;
            SignInSubtitle.Text = "Start Your Journey";
            SignInSubtitle.Click += SignInSubtitle_Click;
            // 
            // topLeftLogo
            // 
            topLeftLogo.Image = TravelEaseApp.Properties.Resources.travelEaseLogo;
            topLeftLogo.Location = new Point(261, 20);
            topLeftLogo.Margin = new Padding(4, 5, 4, 5);
            topLeftLogo.Name = "topLeftLogo";
            topLeftLogo.Padding = new Padding(3);
            topLeftLogo.Size = new Size(106, 105);
            topLeftLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            topLeftLogo.TabIndex = 0;
            topLeftLogo.TabStop = false;
            topLeftLogo.Click += topLeftLogo_Click;
            // 
            // signIntravller
            // 
            signIntravller.Image = TravelEaseApp.Properties.Resources.signInImage;
            signIntravller.Location = new Point(659, 0);
            signIntravller.Margin = new Padding(4, 5, 4, 5);
            signIntravller.Name = "signIntravller";
            signIntravller.Size = new Size(657, 867);
            signIntravller.SizeMode = PictureBoxSizeMode.StretchImage;
            signIntravller.TabIndex = 0;
            signIntravller.TabStop = false;
            // 
            // groupBoxEmail
            // 
            groupBoxEmail.Controls.Add(innerEmailBox);
            groupBoxEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxEmail.Location = new Point(107, 332);
            groupBoxEmail.Margin = new Padding(4, 5, 4, 5);
            groupBoxEmail.Name = "groupBoxEmail";
            groupBoxEmail.Padding = new Padding(4, 5, 4, 5);
            groupBoxEmail.Size = new Size(417, 98);
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
            innerEmailBox.Font = new Font("Segoe UI", 9F);
            innerEmailBox.Location = new Point(19, 42);
            innerEmailBox.Margin = new Padding(4, 5, 4, 5);
            innerEmailBox.Name = "innerEmailBox";
            innerEmailBox.Size = new Size(389, 24);
            innerEmailBox.TabIndex = 3;
            innerEmailBox.TextChanged += innerEmailBox_TextChanged;
            AddPlaceholder(innerEmailBox, "BlazingBeam@HELPME.com");
            // 
            // groupBoxPassword
            // 
            groupBoxPassword.Controls.Add(innerPasswordBox);
            groupBoxPassword.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxPassword.Location = new Point(107, 440);
            groupBoxPassword.Margin = new Padding(4, 5, 4, 5);
            groupBoxPassword.Name = "groupBoxPassword";
            groupBoxPassword.Padding = new Padding(4, 5, 4, 5);
            groupBoxPassword.Size = new Size(417, 98);
            groupBoxPassword.TabIndex = 0;
            groupBoxPassword.TabStop = false;
            groupBoxPassword.Text = "Password";
            groupBoxPassword.MouseClick += GroupBoxPassword_MouseClick;
            groupBoxPassword.MouseEnter += GroupBoxPassword_MouseEnter;
            groupBoxPassword.MouseLeave += GroupBoxPassword_MouseLeave;
            groupBoxPassword.Enter += groupBoxPassword_Enter;
            groupBoxPassword.Leave += groupBoxPassword_Leave;
            // 
            // innerPasswordBox
            // 
            innerPasswordBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerPasswordBox.BorderStyle = BorderStyle.None;
            innerPasswordBox.Location = new Point(19, 43);
            innerPasswordBox.Margin = new Padding(4, 5, 4, 5);
            innerPasswordBox.Name = "innerPasswordBox";
            innerPasswordBox.Size = new Size(389, 23);
            innerPasswordBox.TabIndex = 0;
            innerPasswordBox.UseSystemPasswordChar = true;
            innerPasswordBox.TextChanged += innerPasswordBox_TextChanged;
            AddPlaceholder(innerPasswordBox, "********");
            // 
            // signInButton
            // 
            signInButton.BackColor = Color.Blue;
            signInButton.BorderStyle = BorderStyle.FixedSingle;
            signInButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            signInButton.ForeColor = Color.White;
            signInButton.Location = new Point(107, 583);
            signInButton.Margin = new Padding(4, 0, 4, 0);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(416, 65);
            signInButton.TabIndex = 2;
            signInButton.Text = "Sign In";
            signInButton.TextAlign = ContentAlignment.MiddleCenter;
            signInButton.Click += signInButton_Click;
            AddHoverTransition(signInButton, signInButton.BackColor, signInButton.ForeColor, signInButton.ForeColor, signInButton.BackColor);
            // 
            // SignInForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            //this.AutoSize = false;
            ClientSize = new Size(1314, 867);
            this.MinimumSize = new Size(1314, 800);
            //this.Size = new Size(1314, 867);
            Controls.Add(SignInHeading);
            Controls.Add(SignInSubtitle);
            Controls.Add(topLeftLogo);
            Controls.Add(signIntravller);
            Controls.Add(groupBoxEmail);
            Controls.Add(groupBoxPassword);
            Controls.Add(signInButton);
            Margin = new Padding(4, 3, 4, 3);
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

        private void signInLabel_Paint(object sender, PaintEventArgs e)
        {
            Label label = sender as Label;
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, label.Width - 1, label.Height - 1);
            }
        }


        #endregion
    }

}
