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


        private void InitializeComponent()
        {
            SignInHeading = new Label();
            SignInSubtitle = new Label();
            topLeftLogo = new PictureBox();
            signIntravller = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)signIntravller).BeginInit();
            SuspendLayout();
            // 
            // SignInHeading
            // 
            SignInHeading.AutoSize = true;
            SignInHeading.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            SignInHeading.Location = new Point(31, 116);
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
            SignInSubtitle.Location = new Point(37, 97);
            SignInSubtitle.Name = "SignInSubtitle";
            SignInSubtitle.Size = new Size(122, 19);
            SignInSubtitle.TabIndex = 1;
            SignInSubtitle.Text = "Start Your Journey";
            SignInSubtitle.Click += SignInSubtitle_Click;
            // 
            // topLeftLogo
            // 
            topLeftLogo.Image = TravelEaseApp.Properties.Resources.travelEaseLogo;
            topLeftLogo.Location = new Point(37, 25);
            topLeftLogo.Name = "topLeftLogo";
            topLeftLogo.Padding = new Padding(2);
            topLeftLogo.Size = new Size(43, 45);
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
            Margin = new Padding(3, 2, 3, 2);
            Name = "SignInForm";
            Text = "Sign In";
            Load += SignInForm_Load;
            ((System.ComponentModel.ISupportInitialize)topLeftLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)signIntravller).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
