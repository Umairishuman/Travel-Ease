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
            serviceDescriptionBox = new GroupBox();
            innerServiceDescriptionBox = new TextBox();
            pricePerPersonBox = new GroupBox();
            innerPricePerPersonBox = new TextBox();
            capacityBox = new GroupBox();
            innerCapacityBox = new TextBox();
            submitLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            typeSelectionGroup = new GroupBox();
            typeSelectOptions = new ComboBox();
            serviceDescriptionBox.SuspendLayout();
            pricePerPersonBox.SuspendLayout();
            capacityBox.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            typeSelectionGroup.SuspendLayout();
            SuspendLayout();
            // 
            // serviceDescriptionBox
            // 
            serviceDescriptionBox.Controls.Add(innerServiceDescriptionBox);
            serviceDescriptionBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serviceDescriptionBox.Location = new Point(403, 260);
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
            pricePerPersonBox.Location = new Point(403, 339);
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
            capacityBox.Location = new Point(403, 418);
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
            submitLabel.Location = new Point(403, 497);
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
            flowLayoutPanel1.Controls.Add(typeSelectionGroup);
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
            // typeSelectionGroup
            // 
            typeSelectionGroup.Controls.Add(typeSelectOptions);
            typeSelectionGroup.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            typeSelectionGroup.Location = new Point(402, 177);
            typeSelectionGroup.Margin = new Padding(2);
            typeSelectionGroup.Name = "typeSelectionGroup";
            typeSelectionGroup.Padding = new Padding(2);
            typeSelectionGroup.Size = new Size(293, 71);
            typeSelectionGroup.TabIndex = 9;
            typeSelectionGroup.TabStop = false;
            typeSelectionGroup.Text = "Service Type";
            // 
            // typeSelectOptions
            // 
            typeSelectOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            typeSelectOptions.BackColor = Color.White;
            typeSelectOptions.FlatStyle = FlatStyle.Flat;
            typeSelectOptions.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeSelectOptions.ForeColor = SystemColors.InactiveCaptionText;
            typeSelectOptions.FormattingEnabled = true;
            typeSelectOptions.ItemHeight = 30;
            typeSelectOptions.Items.AddRange(new object[] { "Guide", "Hotel", "Transport", "Other" });
            typeSelectOptions.Location = new Point(4, 22);
            typeSelectOptions.Margin = new Padding(2);
            typeSelectOptions.Name = "typeSelectOptions";
            typeSelectOptions.Size = new Size(285, 38);
            typeSelectOptions.TabIndex = 4;
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
            serviceDescriptionBox.ResumeLayout(false);
            serviceDescriptionBox.PerformLayout();
            pricePerPersonBox.ResumeLayout(false);
            pricePerPersonBox.PerformLayout();
            capacityBox.ResumeLayout(false);
            capacityBox.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            typeSelectionGroup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox serviceDescriptionBox;
        private TextBox innerServiceDescriptionBox;
        private GroupBox pricePerPersonBox;
        private TextBox innerPricePerPersonBox;
        private GroupBox capacityBox;
        private TextBox innerCapacityBox;
        private Label submitLabel;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
        private GroupBox typeSelectionGroup;
        private ComboBox typeSelectOptions;
    }
}