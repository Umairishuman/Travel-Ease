namespace TravelEaseApp
{
    partial class ReportForm
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
            revenueByCategoryTableAdapter1 = new TravelEaseApp.TravelEaseDataSetTableAdapters.RevenueByCategoryTableAdapter();
            ReportReview = new FastReport.Preview.PreviewControl();
            SuspendLayout();
            // 
            // revenueByCategoryTableAdapter1
            // 
            revenueByCategoryTableAdapter1.ClearBeforeFill = true;
            // 
            // ReportReview
            // 
            ReportReview.BackColor = SystemColors.AppWorkspace;
            ReportReview.ControlHScrollBarHeight = null;
            ReportReview.ControlVScrollBarWidth = null;
            ReportReview.Font = new Font("Tahoma", 8F);
            ReportReview.Location = new Point(249, 38);
            ReportReview.Name = "ReportReview";
            ReportReview.OutlineExpand = true;
            ReportReview.OutlineWidth = 150;
            ReportReview.PageOffset = new Point(10, 10);
            ReportReview.RightToLeft = RightToLeft.No;
            ReportReview.SaveInitialDirectory = null;
            ReportReview.Size = new Size(673, 369);
            ReportReview.TabIndex = 0;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1235, 553);
            Controls.Add(ReportReview);
            Name = "ReportForm";
            Text = "ReportForm";
            ResumeLayout(false);
        }

        #endregion

        private TravelEaseDataSetTableAdapters.RevenueByCategoryTableAdapter revenueByCategoryTableAdapter1;
        private FastReport.Preview.PreviewControl ReportReview;
    }
}