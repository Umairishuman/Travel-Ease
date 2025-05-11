namespace TravelEaseApp.TourOperator
{
    partial class tripsForm
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
            label1 = new Label();
            availableTripsPanel = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(519, 9);
            label1.Name = "label1";
            label1.Size = new Size(97, 46);
            label1.TabIndex = 6;
            label1.Text = "Trips";
            // 
            // availableTripsPanel
            // 
            availableTripsPanel.AutoScroll = true;
            availableTripsPanel.Location = new Point(12, 67);
            availableTripsPanel.Name = "availableTripsPanel";
            availableTripsPanel.Size = new Size(1110, 582);
            availableTripsPanel.TabIndex = 7;
            // 
            // tripsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 648);
            Controls.Add(availableTripsPanel);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "tripsForm";
            Text = "Form1";
            Load += tripsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Panel availableTripsPanel;
    }
}