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
            ReportReview.Location = new Point(356, 63);
            ReportReview.Margin = new Padding(6, 7, 6, 7);
            ReportReview.Name = "ReportReview";
            ReportReview.OutlineExpand = true;
            ReportReview.OutlineWidth = 150;
            ReportReview.PageOffset = new Point(10, 10);
            ReportReview.RightToLeft = RightToLeft.No;
            ReportReview.SaveInitialDirectory = null;
            ReportReview.Size = new Size(961, 615);
            ReportReview.TabIndex = 0;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1764, 922);
            Controls.Add(ReportReview);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ReportForm";
            Text = "ReportForm";
            ResumeLayout(false);
        }

        #endregion

        private TravelEaseDataSetTableAdapters.RevenueByCategoryTableAdapter revenueByCategoryTableAdapter1;
        private FastReport.Preview.PreviewControl ReportReview;
    }
}