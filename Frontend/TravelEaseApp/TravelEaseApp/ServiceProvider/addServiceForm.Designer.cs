namespace TravelEaseApp.ServiceProvider
{
    partial class addServiceForm
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
            serviceTypeBoxEmail = new GroupBox();
            innerServiceTypeBox = new TextBox();
            serviceDescriptionBox = new GroupBox();
            innerServiceDescriptionBox = new TextBox();
            pricePerPersonBox = new GroupBox();
            innerPricePerPersonBox = new TextBox();
            capacityBox = new GroupBox();
            innerCapacityBox = new TextBox();
            submitLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            serviceTypeBoxEmail.SuspendLayout();
            serviceDescriptionBox.SuspendLayout();
            pricePerPersonBox.SuspendLayout();
            capacityBox.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // serviceTypeBoxEmail
            // 
            serviceTypeBoxEmail.Controls.Add(innerServiceTypeBox);
            serviceTypeBoxEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serviceTypeBoxEmail.Location = new Point(403, 185);
            serviceTypeBoxEmail.Margin = new Padding(3, 10, 3, 10);
            serviceTypeBoxEmail.Name = "serviceTypeBoxEmail";
            serviceTypeBoxEmail.Size = new Size(292, 59);
            serviceTypeBoxEmail.TabIndex = 1;
            serviceTypeBoxEmail.TabStop = false;
            serviceTypeBoxEmail.Text = "Service Type";
            // 
            // innerServiceTypeBox
            // 
            innerServiceTypeBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerServiceTypeBox.BackColor = SystemColors.Control;
            innerServiceTypeBox.BorderStyle = BorderStyle.None;
            innerServiceTypeBox.Font = new Font("Segoe UI", 9F);
            innerServiceTypeBox.Location = new Point(13, 25);
            innerServiceTypeBox.Name = "innerServiceTypeBox";
            innerServiceTypeBox.Size = new Size(269, 16);
            innerServiceTypeBox.TabIndex = 3;
            // 
            // serviceDescriptionBox
            // 
            serviceDescriptionBox.Controls.Add(innerServiceDescriptionBox);
            serviceDescriptionBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serviceDescriptionBox.Location = new Point(403, 264);
            serviceDescriptionBox.Margin = new Padding(3, 10, 3, 10);
            serviceDescriptionBox.Name = "serviceDescriptionBox";
            serviceDescriptionBox.Size = new Size(292, 59);
            serviceDescriptionBox.TabIndex = 4;
            serviceDescriptionBox.TabStop = false;
            serviceDescriptionBox.Text = "Service Description";
            // 
            // innerServiceDescriptionBox
            // 
            innerServiceDescriptionBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerServiceDescriptionBox.BackColor = SystemColors.Control;
            innerServiceDescriptionBox.BorderStyle = BorderStyle.None;
            innerServiceDescriptionBox.Font = new Font("Segoe UI", 9F);
            innerServiceDescriptionBox.Location = new Point(13, 25);
            innerServiceDescriptionBox.Name = "innerServiceDescriptionBox";
            innerServiceDescriptionBox.Size = new Size(269, 16);
            innerServiceDescriptionBox.TabIndex = 3;
            // 
            // pricePerPersonBox
            // 
            pricePerPersonBox.Controls.Add(innerPricePerPersonBox);
            pricePerPersonBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pricePerPersonBox.Location = new Point(403, 343);
            pricePerPersonBox.Margin = new Padding(3, 10, 3, 10);
            pricePerPersonBox.Name = "pricePerPersonBox";
            pricePerPersonBox.Size = new Size(292, 59);
            pricePerPersonBox.TabIndex = 5;
            pricePerPersonBox.TabStop = false;
            pricePerPersonBox.Text = "Price Per Person";
            // 
            // innerPricePerPersonBox
            // 
            innerPricePerPersonBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerPricePerPersonBox.BackColor = SystemColors.Control;
            innerPricePerPersonBox.BorderStyle = BorderStyle.None;
            innerPricePerPersonBox.Font = new Font("Segoe UI", 9F);
            innerPricePerPersonBox.Location = new Point(13, 25);
            innerPricePerPersonBox.Name = "innerPricePerPersonBox";
            innerPricePerPersonBox.Size = new Size(269, 16);
            innerPricePerPersonBox.TabIndex = 3;
            // 
            // capacityBox
            // 
            capacityBox.Controls.Add(innerCapacityBox);
            capacityBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            capacityBox.Location = new Point(403, 422);
            capacityBox.Margin = new Padding(3, 10, 3, 10);
            capacityBox.Name = "capacityBox";
            capacityBox.Size = new Size(292, 59);
            capacityBox.TabIndex = 6;
            capacityBox.TabStop = false;
            capacityBox.Text = "Capacity";
            // 
            // innerCapacityBox
            // 
            innerCapacityBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerCapacityBox.BackColor = SystemColors.Control;
            innerCapacityBox.BorderStyle = BorderStyle.None;
            innerCapacityBox.Font = new Font("Segoe UI", 9F);
            innerCapacityBox.Location = new Point(13, 25);
            innerCapacityBox.Name = "innerCapacityBox";
            innerCapacityBox.Size = new Size(269, 16);
            innerCapacityBox.TabIndex = 3;
            // 
            // submitLabel
            // 
            submitLabel.BackColor = Color.Black;
            submitLabel.BorderStyle = BorderStyle.FixedSingle;
            submitLabel.Cursor = Cursors.Hand;
            submitLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            submitLabel.ForeColor = Color.White;
            submitLabel.Location = new Point(403, 501);
            submitLabel.Margin = new Padding(3, 10, 3, 10);
            submitLabel.Name = "submitLabel";
            submitLabel.Size = new Size(292, 40);
            submitLabel.TabIndex = 7;
            submitLabel.Text = "Submit";
            submitLabel.TextAlign = ContentAlignment.MiddleCenter;
            submitLabel.Click += submitLabel_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(serviceTypeBoxEmail);
            flowLayoutPanel1.Controls.Add(serviceDescriptionBox);
            flowLayoutPanel1.Controls.Add(pricePerPersonBox);
            flowLayoutPanel1.Controls.Add(capacityBox);
            flowLayoutPanel1.Controls.Add(submitLabel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(400, 120, 0, 0);
            flowLayoutPanel1.Size = new Size(1118, 610);
            flowLayoutPanel1.TabIndex = 8;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(403, 120);
            label1.Name = "label1";
            label1.Size = new Size(292, 55);
            label1.TabIndex = 8;
            label1.Text = "Add Service";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addServiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 610);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "addServiceForm";
            Text = "Form1";
            Load += Form1_Load;
            serviceTypeBoxEmail.ResumeLayout(false);
            serviceTypeBoxEmail.PerformLayout();
            serviceDescriptionBox.ResumeLayout(false);
            serviceDescriptionBox.PerformLayout();
            pricePerPersonBox.ResumeLayout(false);
            pricePerPersonBox.PerformLayout();
            capacityBox.ResumeLayout(false);
            capacityBox.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox serviceTypeBoxEmail;
        private TextBox innerServiceTypeBox;
        private GroupBox serviceDescriptionBox;
        private TextBox innerServiceDescriptionBox;
        private GroupBox pricePerPersonBox;
        private TextBox innerPricePerPersonBox;
        private GroupBox capacityBox;
        private TextBox innerCapacityBox;
        private Label submitLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
    }
}