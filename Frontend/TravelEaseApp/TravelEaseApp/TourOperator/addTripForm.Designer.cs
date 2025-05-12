namespace TravelEaseApp.TourOperator
{
    partial class addTripForm
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
            serviceTypeBoxEmail = new GroupBox();
            innerTitleBox = new TextBox();
            serviceDescriptionBox = new GroupBox();
            innerDescriptionBox = new TextBox();
            capacityBox = new GroupBox();
            startDatePicker = new DateTimePicker();
            submitLabel = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            startLocationBox = new GroupBox();
            startLocationComboBox = new ComboBox();
            groupBox1 = new GroupBox();
            endDatePicker = new DateTimePicker();
            flowLayoutPanel2 = new FlowLayoutPanel();
            groupBox3 = new GroupBox();
            innerCapacityBox = new TextBox();
            categoryGroupBox = new GroupBox();
            categoryComboBox = new ComboBox();
            groupBox6 = new GroupBox();
            innerPricePerPersonBox = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            groupBox10 = new GroupBox();
            pictureBox1 = new PictureBox();
            locationsSelectedLabel = new Label();
            locationsSelected = new Label();
            addLocationButton = new Label();
            selectLocationsGroupBox = new GroupBox();
            selectLocationsComboBox = new ComboBox();
            serviceTypeBoxEmail.SuspendLayout();
            serviceDescriptionBox.SuspendLayout();
            capacityBox.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            startLocationBox.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBox3.SuspendLayout();
            categoryGroupBox.SuspendLayout();
            groupBox6.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            selectLocationsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            label1.Location = new Point(427, 58);
            label1.Name = "label1";
            label1.Size = new Size(292, 55);
            label1.TabIndex = 8;
            label1.Text = "Add Trip";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // serviceTypeBoxEmail
            // 
            serviceTypeBoxEmail.Controls.Add(innerTitleBox);
            serviceTypeBoxEmail.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serviceTypeBoxEmail.Location = new Point(3, 10);
            serviceTypeBoxEmail.Margin = new Padding(3, 10, 3, 10);
            serviceTypeBoxEmail.Name = "serviceTypeBoxEmail";
            serviceTypeBoxEmail.Size = new Size(292, 59);
            serviceTypeBoxEmail.TabIndex = 1;
            serviceTypeBoxEmail.TabStop = false;
            serviceTypeBoxEmail.Text = "Title";
            // 
            // innerTitleBox
            // 
            innerTitleBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerTitleBox.BackColor = SystemColors.Control;
            innerTitleBox.BorderStyle = BorderStyle.None;
            innerTitleBox.Font = new Font("Segoe UI", 9F);
            innerTitleBox.Location = new Point(13, 25);
            innerTitleBox.Name = "innerTitleBox";
            innerTitleBox.Size = new Size(273, 16);
            innerTitleBox.TabIndex = 3;
            // 
            // serviceDescriptionBox
            // 
            serviceDescriptionBox.Controls.Add(innerDescriptionBox);
            serviceDescriptionBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            serviceDescriptionBox.Location = new Point(3, 89);
            serviceDescriptionBox.Margin = new Padding(3, 10, 3, 10);
            serviceDescriptionBox.Name = "serviceDescriptionBox";
            serviceDescriptionBox.Size = new Size(292, 59);
            serviceDescriptionBox.TabIndex = 4;
            serviceDescriptionBox.TabStop = false;
            serviceDescriptionBox.Text = "Description";
            // 
            // innerDescriptionBox
            // 
            innerDescriptionBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerDescriptionBox.BackColor = SystemColors.Control;
            innerDescriptionBox.BorderStyle = BorderStyle.None;
            innerDescriptionBox.Font = new Font("Segoe UI", 9F);
            innerDescriptionBox.Location = new Point(13, 25);
            innerDescriptionBox.Name = "innerDescriptionBox";
            innerDescriptionBox.Size = new Size(273, 16);
            innerDescriptionBox.TabIndex = 3;
            // 
            // capacityBox
            // 
            capacityBox.Controls.Add(startDatePicker);
            capacityBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            capacityBox.Location = new Point(3, 243);
            capacityBox.Margin = new Padding(3, 10, 3, 10);
            capacityBox.Name = "capacityBox";
            capacityBox.Size = new Size(292, 59);
            capacityBox.TabIndex = 6;
            capacityBox.TabStop = false;
            capacityBox.Text = "Start Date";
            // 
            // startDatePicker
            // 
            startDatePicker.CalendarMonthBackground = SystemColors.Control;
            startDatePicker.Location = new Point(6, 21);
            startDatePicker.Name = "startDatePicker";
            startDatePicker.Size = new Size(280, 22);
            startDatePicker.TabIndex = 10;
            // 
            // submitLabel
            // 
            submitLabel.BackColor = Color.Black;
            submitLabel.BorderStyle = BorderStyle.FixedSingle;
            submitLabel.Cursor = Cursors.Hand;
            submitLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            submitLabel.ForeColor = Color.White;
            submitLabel.Location = new Point(427, 400);
            submitLabel.Margin = new Padding(3, 10, 3, 10);
            submitLabel.Name = "submitLabel";
            submitLabel.Size = new Size(299, 40);
            submitLabel.TabIndex = 7;
            submitLabel.Text = "Submit";
            submitLabel.TextAlign = ContentAlignment.MiddleCenter;
            submitLabel.Click += submitTripButton_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(serviceTypeBoxEmail);
            flowLayoutPanel1.Controls.Add(serviceDescriptionBox);
            flowLayoutPanel1.Controls.Add(startLocationBox);
            flowLayoutPanel1.Controls.Add(capacityBox);
            flowLayoutPanel1.Controls.Add(groupBox1);
            flowLayoutPanel1.Location = new Point(65, 166);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(299, 401);
            flowLayoutPanel1.TabIndex = 9;
            // 
            // startLocationBox
            // 
            startLocationBox.Controls.Add(startLocationComboBox);
            startLocationBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            startLocationBox.Location = new Point(2, 160);
            startLocationBox.Margin = new Padding(2);
            startLocationBox.Name = "startLocationBox";
            startLocationBox.Padding = new Padding(2);
            startLocationBox.Size = new Size(293, 71);
            startLocationBox.TabIndex = 14;
            startLocationBox.TabStop = false;
            startLocationBox.Text = "Service Type";
            // 
            // startLocationComboBox
            // 
            startLocationComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            startLocationComboBox.BackColor = Color.White;
            startLocationComboBox.FlatStyle = FlatStyle.Flat;
            startLocationComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startLocationComboBox.ForeColor = SystemColors.InactiveCaptionText;
            startLocationComboBox.FormattingEnabled = true;
            startLocationComboBox.ItemHeight = 17;
            startLocationComboBox.Location = new Point(3, 21);
            startLocationComboBox.Margin = new Padding(2);
            startLocationComboBox.Name = "startLocationComboBox";
            startLocationComboBox.Size = new Size(284, 25);
            startLocationComboBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(endDatePicker);
            groupBox1.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(3, 322);
            groupBox1.Margin = new Padding(3, 10, 3, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(292, 59);
            groupBox1.TabIndex = 11;
            groupBox1.TabStop = false;
            groupBox1.Text = "End Date";
            // 
            // endDatePicker
            // 
            endDatePicker.CalendarMonthBackground = SystemColors.Control;
            endDatePicker.Location = new Point(6, 21);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(280, 22);
            endDatePicker.TabIndex = 10;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(groupBox3);
            flowLayoutPanel2.Controls.Add(categoryGroupBox);
            flowLayoutPanel2.Controls.Add(groupBox6);
            flowLayoutPanel2.Location = new Point(427, 166);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(299, 231);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(innerCapacityBox);
            groupBox3.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(3, 10);
            groupBox3.Margin = new Padding(3, 10, 3, 10);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(292, 59);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Capacity";
            // 
            // innerCapacityBox
            // 
            innerCapacityBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerCapacityBox.BackColor = SystemColors.Control;
            innerCapacityBox.BorderStyle = BorderStyle.None;
            innerCapacityBox.Font = new Font("Segoe UI", 9F);
            innerCapacityBox.Location = new Point(13, 25);
            innerCapacityBox.Name = "innerCapacityBox";
            innerCapacityBox.Size = new Size(273, 16);
            innerCapacityBox.TabIndex = 3;
            // 
            // categoryGroupBox
            // 
            categoryGroupBox.Controls.Add(categoryComboBox);
            categoryGroupBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            categoryGroupBox.Location = new Point(2, 81);
            categoryGroupBox.Margin = new Padding(2);
            categoryGroupBox.Name = "categoryGroupBox";
            categoryGroupBox.Padding = new Padding(2);
            categoryGroupBox.Size = new Size(293, 71);
            categoryGroupBox.TabIndex = 16;
            categoryGroupBox.TabStop = false;
            categoryGroupBox.Text = "Category";
            // 
            // categoryComboBox
            // 
            categoryComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            categoryComboBox.BackColor = Color.White;
            categoryComboBox.FlatStyle = FlatStyle.Flat;
            categoryComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            categoryComboBox.ForeColor = SystemColors.InactiveCaptionText;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.ItemHeight = 17;
            categoryComboBox.Location = new Point(4, 26);
            categoryComboBox.Margin = new Padding(2);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(285, 25);
            categoryComboBox.TabIndex = 4;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(innerPricePerPersonBox);
            groupBox6.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox6.Location = new Point(3, 164);
            groupBox6.Margin = new Padding(3, 10, 3, 10);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(292, 59);
            groupBox6.TabIndex = 11;
            groupBox6.TabStop = false;
            groupBox6.Text = "Price Per Person";
            // 
            // innerPricePerPersonBox
            // 
            innerPricePerPersonBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerPricePerPersonBox.BackColor = SystemColors.Control;
            innerPricePerPersonBox.BorderStyle = BorderStyle.None;
            innerPricePerPersonBox.Font = new Font("Segoe UI", 9F);
            innerPricePerPersonBox.Location = new Point(13, 27);
            innerPricePerPersonBox.Name = "innerPricePerPersonBox";
            innerPricePerPersonBox.Size = new Size(273, 16);
            innerPricePerPersonBox.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(groupBox10);
            flowLayoutPanel3.Location = new Point(427, 444);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(299, 123);
            flowLayoutPanel3.TabIndex = 13;
            flowLayoutPanel3.Paint += flowLayoutPanel3_Paint;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(pictureBox1);
            groupBox10.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox10.Location = new Point(3, 10);
            groupBox10.Margin = new Padding(3, 10, 3, 10);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new Size(292, 143);
            groupBox10.TabIndex = 6;
            groupBox10.TabStop = false;
            groupBox10.Text = "Image";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Image = Properties.Resources.image_svgrepo_com;
            pictureBox1.InitialImage = Properties.Resources.image_svgrepo_com;
            pictureBox1.Location = new Point(6, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // locationsSelectedLabel
            // 
            locationsSelectedLabel.AutoSize = true;
            locationsSelectedLabel.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            locationsSelectedLabel.Location = new Point(749, 166);
            locationsSelectedLabel.Name = "locationsSelectedLabel";
            locationsSelectedLabel.Size = new Size(135, 19);
            locationsSelectedLabel.TabIndex = 14;
            locationsSelectedLabel.Text = "Locations Selected";
            // 
            // locationsSelected
            // 
            locationsSelected.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            locationsSelected.Location = new Point(749, 195);
            locationsSelected.Name = "locationsSelected";
            locationsSelected.Size = new Size(296, 98);
            locationsSelected.TabIndex = 15;
            // 
            // addLocationButton
            // 
            addLocationButton.BackColor = Color.Black;
            addLocationButton.BorderStyle = BorderStyle.FixedSingle;
            addLocationButton.Cursor = Cursors.Hand;
            addLocationButton.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            addLocationButton.ForeColor = Color.White;
            addLocationButton.Location = new Point(749, 400);
            addLocationButton.Margin = new Padding(3, 10, 3, 10);
            addLocationButton.Name = "addLocationButton";
            addLocationButton.Size = new Size(293, 40);
            addLocationButton.TabIndex = 16;
            addLocationButton.Text = "Add Location";
            addLocationButton.TextAlign = ContentAlignment.MiddleCenter;
            addLocationButton.Click += addLocationButton_Click;
            // 
            // selectLocationsGroupBox
            // 
            selectLocationsGroupBox.Controls.Add(selectLocationsComboBox);
            selectLocationsGroupBox.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            selectLocationsGroupBox.Location = new Point(749, 317);
            selectLocationsGroupBox.Margin = new Padding(2);
            selectLocationsGroupBox.Name = "selectLocationsGroupBox";
            selectLocationsGroupBox.Padding = new Padding(2);
            selectLocationsGroupBox.Size = new Size(293, 71);
            selectLocationsGroupBox.TabIndex = 15;
            selectLocationsGroupBox.TabStop = false;
            selectLocationsGroupBox.Text = "Locations";
            // 
            // selectLocationsComboBox
            // 
            selectLocationsComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            selectLocationsComboBox.BackColor = Color.White;
            selectLocationsComboBox.FlatStyle = FlatStyle.Flat;
            selectLocationsComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectLocationsComboBox.ForeColor = SystemColors.InactiveCaptionText;
            selectLocationsComboBox.FormattingEnabled = true;
            selectLocationsComboBox.ItemHeight = 17;
            selectLocationsComboBox.Location = new Point(4, 26);
            selectLocationsComboBox.Margin = new Padding(2);
            selectLocationsComboBox.Name = "selectLocationsComboBox";
            selectLocationsComboBox.Size = new Size(285, 25);
            selectLocationsComboBox.TabIndex = 4;
            // 
            // addTripForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 649);
            Controls.Add(selectLocationsGroupBox);
            Controls.Add(addLocationButton);
            Controls.Add(locationsSelected);
            Controls.Add(locationsSelectedLabel);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label1);
            Controls.Add(submitLabel);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "addTripForm";
            Text = "Form1";
            serviceTypeBoxEmail.ResumeLayout(false);
            serviceTypeBoxEmail.PerformLayout();
            serviceDescriptionBox.ResumeLayout(false);
            serviceDescriptionBox.PerformLayout();
            capacityBox.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            startLocationBox.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            categoryGroupBox.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            selectLocationsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private GroupBox serviceTypeBoxEmail;
        private TextBox innerTitleBox;
        private GroupBox serviceDescriptionBox;
        private TextBox innerDescriptionBox;
        private GroupBox pricePerPersonBox;
        private TextBox innerStartLocationBox;
        private GroupBox capacityBox;
        private Label submitLabel;
        private DateTimePicker startDatePicker;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox groupBox1;
        private DateTimePicker endDatePicker;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox groupBox3;
        private TextBox innerCapacityBox;
        private GroupBox groupBox6;
        private TextBox innerPricePerPersonBox;
        private FlowLayoutPanel flowLayoutPanel3;
        private GroupBox groupBox10;
        private PictureBox pictureBox1;
        private GroupBox startLocationBox;
        private ComboBox startLocationComboBox;
        private Label locationsSelectedLabel;
        private Label locationsSelected;
        private Label addLocationButton;
        private GroupBox selectLocationsGroupBox;
        private ComboBox selectLocationsComboBox;
        private GroupBox categoryGroupBox;
        private ComboBox categoryComboBox;
    }
}