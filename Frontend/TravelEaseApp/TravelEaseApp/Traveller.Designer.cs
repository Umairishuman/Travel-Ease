namespace TravelEaseApp
{
    partial class Traveller
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
            mainPanel = new Panel();
            TravellerTripsPanel = new Panel();
            TripDisplayPanel = new Panel();
            TravellerTripTopPanel = new Panel();
            MoneyLabel = new Label();
            moneySlider = new TrackBar();
            applyfilterbox = new Label();
            groupBox2 = new GroupBox();
            dateTimePicker1 = new DateTimePicker();
            groupBox1 = new GroupBox();
            dateTimePicker2 = new DateTimePicker();
            searchBox = new TextBox();
            TripsLabel = new Label();
            SideBarPanel = new Panel();
            TransactionButtonPanel = new Panel();
            TransactionsButton = new PictureBox();
            TransactionButtonLabel = new Label();
            BookingsButtonPanel = new Panel();
            BookingsButton = new PictureBox();
            BookingsButtonLabel = new Label();
            TripButtonPanel = new Panel();
            TripsButton = new PictureBox();
            TripButtonLabel = new Label();
            DashBoardButtonPanel = new Panel();
            DashboardButton = new PictureBox();
            DashBoardButtonLabel = new Label();
            travelEaseLogo = new PictureBox();
            TravellerBookingsPanel = new Panel();
            BookingsDisplayPanel = new Panel();
            BookingsTopPanel = new Panel();
            BookingsLabel = new Label();
            TravellerTransactionPanel = new Panel();
            TransactionDisplayPanel = new Panel();
            TransactionTopPanel = new Panel();
            TransactionHeading = new Label();
            DashboardPanel = new Panel();
            UpcomingTripsPanel = new Panel();
            UpcomingTripsLabel = new Label();
            PreferencesPanel = new Panel();
            AddPreferenceButton = new Label();
            PreferencesHeading = new Label();
            StatisticsPanel = new Panel();
            StatisticLabel = new Label();
            panel3 = new Panel();
            label3 = new Label();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            successfulJourneysPanel = new Panel();
            SuccessfulJourneysNumber = new Label();
            SuccessfulJourneysLabel = new Label();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            ActiveNumberLabel = new Label();
            BookedNumberLabel = new Label();
            completedNumberLabel = new Label();
            ActiveLabel = new Label();
            BookedLabel = new Label();
            completedLabel = new Label();
            TravellerBio = new Label();
            TravllerPicBox = new PictureBox();
            TravellerName = new Label();
            paymentBookingsPanel = new Panel();
            PaymentHeadLabel = new Label();
            groupBoxAccNum = new GroupBox();
            innerAccNumBox = new TextBox();
            PayButton = new Label();
            RoleSelectionGroup = new GroupBox();
            MethodSelectOptions = new ComboBox();
            CompleteTripInfoPanel = new Panel();
            digitalPassesDiaplayPanel = new Panel();
            profilePanel = new Panel();
            mainPanel.SuspendLayout();
            TravellerTripsPanel.SuspendLayout();
            TravellerTripTopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)moneySlider).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SideBarPanel.SuspendLayout();
            TransactionButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TransactionsButton).BeginInit();
            BookingsButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BookingsButton).BeginInit();
            TripButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TripsButton).BeginInit();
            DashBoardButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DashboardButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)travelEaseLogo).BeginInit();
            TravellerBookingsPanel.SuspendLayout();
            BookingsTopPanel.SuspendLayout();
            TravellerTransactionPanel.SuspendLayout();
            TransactionTopPanel.SuspendLayout();
            DashboardPanel.SuspendLayout();
            UpcomingTripsPanel.SuspendLayout();
            PreferencesPanel.SuspendLayout();
            StatisticsPanel.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            successfulJourneysPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TravllerPicBox).BeginInit();
            paymentBookingsPanel.SuspendLayout();
            groupBoxAccNum.SuspendLayout();
            RoleSelectionGroup.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(DashboardPanel);
            mainPanel.Controls.Add(TravellerTripsPanel);
            mainPanel.Controls.Add(TravellerBookingsPanel);
            mainPanel.Controls.Add(TravellerTransactionPanel);
            mainPanel.Controls.Add(SideBarPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1276, 684);
            mainPanel.TabIndex = 0;
            // 
            // TravellerTripsPanel
            // 
            TravellerTripsPanel.Controls.Add(TripDisplayPanel);
            TravellerTripsPanel.Controls.Add(TravellerTripTopPanel);
            TravellerTripsPanel.Location = new Point(85, 0);
            TravellerTripsPanel.Name = "TravellerTripsPanel";
            TravellerTripsPanel.Size = new Size(1188, 684);
            TravellerTripsPanel.TabIndex = 1;
            TravellerTripsPanel.Visible = false;
            // 
            // TripDisplayPanel
            // 
            TripDisplayPanel.BackColor = Color.White;
            TripDisplayPanel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TripDisplayPanel.Location = new Point(3, 157);
            TripDisplayPanel.Name = "TripDisplayPanel";
            TripDisplayPanel.Padding = new Padding(4);
            TripDisplayPanel.Size = new Size(1185, 515);
            TripDisplayPanel.TabIndex = 1;
            TripDisplayPanel.Click += TripDisplayPanel_Click;
            // 
            // TravellerTripTopPanel
            // 
            TravellerTripTopPanel.BackColor = Color.White;
            TravellerTripTopPanel.Controls.Add(MoneyLabel);
            TravellerTripTopPanel.Controls.Add(moneySlider);
            TravellerTripTopPanel.Controls.Add(applyfilterbox);
            TravellerTripTopPanel.Controls.Add(groupBox2);
            TravellerTripTopPanel.Controls.Add(groupBox1);
            TravellerTripTopPanel.Controls.Add(searchBox);
            TravellerTripTopPanel.Controls.Add(TripsLabel);
            TravellerTripTopPanel.Location = new Point(3, 12);
            TravellerTripTopPanel.Name = "TravellerTripTopPanel";
            TravellerTripTopPanel.Size = new Size(1185, 137);
            TravellerTripTopPanel.TabIndex = 0;
            // 
            // MoneyLabel
            // 
            MoneyLabel.AutoSize = true;
            MoneyLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MoneyLabel.Location = new Point(797, 12);
            MoneyLabel.Name = "MoneyLabel";
            MoneyLabel.Size = new Size(73, 30);
            MoneyLabel.TabIndex = 101;
            MoneyLabel.Text = "1000$";
            // 
            // moneySlider
            // 
            moneySlider.LargeChange = 500;
            moneySlider.Location = new Point(504, 14);
            moneySlider.Maximum = 10000;
            moneySlider.Name = "moneySlider";
            moneySlider.Size = new Size(248, 45);
            moneySlider.SmallChange = 50;
            moneySlider.TabIndex = 100;
            moneySlider.TickFrequency = 100;
            moneySlider.Value = 1000;
            moneySlider.Scroll += trackBar1_Scroll;
            // 
            // applyfilterbox
            // 
            applyfilterbox.AutoSize = true;
            applyfilterbox.BackColor = Color.Black;
            applyfilterbox.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            applyfilterbox.ForeColor = Color.White;
            applyfilterbox.Location = new Point(930, 37);
            applyfilterbox.Name = "applyfilterbox";
            applyfilterbox.Padding = new Padding(4);
            applyfilterbox.Size = new Size(144, 38);
            applyfilterbox.TabIndex = 4;
            applyfilterbox.Text = "Apply Filters";
            applyfilterbox.Click += applyfilterbox_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dateTimePicker1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(196, 65);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(246, 60);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "From:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(15, 24);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(215, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(504, 65);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(248, 60);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "To:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(15, 24);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(215, 23);
            dateTimePicker2.TabIndex = 0;
            // 
            // searchBox
            // 
            searchBox.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBox.Location = new Point(196, 18);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(246, 33);
            searchBox.TabIndex = 1;
            searchBox.TextChanged += textBox1_TextChanged;
            // 
            // TripsLabel
            // 
            TripsLabel.AutoSize = true;
            TripsLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TripsLabel.Location = new Point(26, 28);
            TripsLabel.Name = "TripsLabel";
            TripsLabel.Size = new Size(69, 32);
            TripsLabel.TabIndex = 0;
            TripsLabel.Text = "Trips";
            // 
            // SideBarPanel
            // 
            SideBarPanel.BackColor = Color.White;
            SideBarPanel.Controls.Add(TransactionButtonPanel);
            SideBarPanel.Controls.Add(BookingsButtonPanel);
            SideBarPanel.Controls.Add(TripButtonPanel);
            SideBarPanel.Controls.Add(DashBoardButtonPanel);
            SideBarPanel.Controls.Add(travelEaseLogo);
            SideBarPanel.Location = new Point(0, 0);
            SideBarPanel.Name = "SideBarPanel";
            SideBarPanel.Size = new Size(86, 684);
            SideBarPanel.TabIndex = 0;
            // 
            // TransactionButtonPanel
            // 
            TransactionButtonPanel.Controls.Add(TransactionsButton);
            TransactionButtonPanel.Controls.Add(TransactionButtonLabel);
            TransactionButtonPanel.Location = new Point(4, 300);
            TransactionButtonPanel.Margin = new Padding(2);
            TransactionButtonPanel.Name = "TransactionButtonPanel";
            TransactionButtonPanel.Size = new Size(77, 62);
            TransactionButtonPanel.TabIndex = 8;
            // 
            // TransactionsButton
            // 
            TransactionsButton.Image = Properties.Resources.transaction;
            TransactionsButton.Location = new Point(14, 3);
            TransactionsButton.Name = "TransactionsButton";
            TransactionsButton.Size = new Size(49, 40);
            TransactionsButton.SizeMode = PictureBoxSizeMode.StretchImage;
            TransactionsButton.TabIndex = 4;
            TransactionsButton.TabStop = false;
            TransactionsButton.Click += TransactionsButton_Click;
            // 
            // TransactionButtonLabel
            // 
            TransactionButtonLabel.AutoSize = true;
            TransactionButtonLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TransactionButtonLabel.Location = new Point(1, 45);
            TransactionButtonLabel.Name = "TransactionButtonLabel";
            TransactionButtonLabel.Size = new Size(75, 15);
            TransactionButtonLabel.TabIndex = 6;
            TransactionButtonLabel.Text = "Transactions";
            // 
            // BookingsButtonPanel
            // 
            BookingsButtonPanel.Controls.Add(BookingsButton);
            BookingsButtonPanel.Controls.Add(BookingsButtonLabel);
            BookingsButtonPanel.Location = new Point(3, 214);
            BookingsButtonPanel.Margin = new Padding(2);
            BookingsButtonPanel.Name = "BookingsButtonPanel";
            BookingsButtonPanel.Size = new Size(77, 62);
            BookingsButtonPanel.TabIndex = 7;
            // 
            // BookingsButton
            // 
            BookingsButton.Image = Properties.Resources.bookings;
            BookingsButton.Location = new Point(9, 3);
            BookingsButton.Name = "BookingsButton";
            BookingsButton.Size = new Size(57, 40);
            BookingsButton.SizeMode = PictureBoxSizeMode.StretchImage;
            BookingsButton.TabIndex = 4;
            BookingsButton.TabStop = false;
            BookingsButton.Click += BookingsButton_Click;
            // 
            // BookingsButtonLabel
            // 
            BookingsButtonLabel.AutoSize = true;
            BookingsButtonLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BookingsButtonLabel.Location = new Point(6, 46);
            BookingsButtonLabel.Name = "BookingsButtonLabel";
            BookingsButtonLabel.Size = new Size(58, 15);
            BookingsButtonLabel.TabIndex = 6;
            BookingsButtonLabel.Text = "Bookings";
            // 
            // TripButtonPanel
            // 
            TripButtonPanel.Controls.Add(TripsButton);
            TripButtonPanel.Controls.Add(TripButtonLabel);
            TripButtonPanel.Location = new Point(4, 137);
            TripButtonPanel.Margin = new Padding(2);
            TripButtonPanel.Name = "TripButtonPanel";
            TripButtonPanel.Size = new Size(77, 62);
            TripButtonPanel.TabIndex = 6;
            // 
            // TripsButton
            // 
            TripsButton.Image = Properties.Resources.trips;
            TripsButton.Location = new Point(18, 3);
            TripsButton.Name = "TripsButton";
            TripsButton.Size = new Size(40, 40);
            TripsButton.SizeMode = PictureBoxSizeMode.StretchImage;
            TripsButton.TabIndex = 4;
            TripsButton.TabStop = false;
            TripsButton.Click += TripsButton_Click;
            // 
            // TripButtonLabel
            // 
            TripButtonLabel.AutoSize = true;
            TripButtonLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TripButtonLabel.Location = new Point(18, 44);
            TripButtonLabel.Name = "TripButtonLabel";
            TripButtonLabel.Size = new Size(33, 15);
            TripButtonLabel.TabIndex = 6;
            TripButtonLabel.Text = "Trips";
            // 
            // DashBoardButtonPanel
            // 
            DashBoardButtonPanel.Controls.Add(DashboardButton);
            DashBoardButtonPanel.Controls.Add(DashBoardButtonLabel);
            DashBoardButtonPanel.Location = new Point(3, 61);
            DashBoardButtonPanel.Margin = new Padding(2);
            DashBoardButtonPanel.Name = "DashBoardButtonPanel";
            DashBoardButtonPanel.Size = new Size(77, 60);
            DashBoardButtonPanel.TabIndex = 1;
            // 
            // DashboardButton
            // 
            DashboardButton.Image = Properties.Resources.dashboard;
            DashboardButton.Location = new Point(17, 3);
            DashboardButton.Name = "DashboardButton";
            DashboardButton.Size = new Size(40, 34);
            DashboardButton.SizeMode = PictureBoxSizeMode.StretchImage;
            DashboardButton.TabIndex = 5;
            DashboardButton.TabStop = false;
            DashboardButton.Click += DashboardButton_Click;
            // 
            // DashBoardButtonLabel
            // 
            DashBoardButtonLabel.AutoSize = true;
            DashBoardButtonLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashBoardButtonLabel.Location = new Point(3, 40);
            DashBoardButtonLabel.Name = "DashBoardButtonLabel";
            DashBoardButtonLabel.Size = new Size(66, 15);
            DashBoardButtonLabel.TabIndex = 1;
            DashBoardButtonLabel.Text = "Dashboard";
            // 
            // travelEaseLogo
            // 
            travelEaseLogo.Image = Properties.Resources.travelEaseLogo;
            travelEaseLogo.Location = new Point(16, 8);
            travelEaseLogo.Name = "travelEaseLogo";
            travelEaseLogo.Size = new Size(40, 40);
            travelEaseLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            travelEaseLogo.TabIndex = 1;
            travelEaseLogo.TabStop = false;
            // 
            // TravellerBookingsPanel
            // 
            TravellerBookingsPanel.Controls.Add(BookingsDisplayPanel);
            TravellerBookingsPanel.Controls.Add(BookingsTopPanel);
            TravellerBookingsPanel.Location = new Point(86, 0);
            TravellerBookingsPanel.Name = "TravellerBookingsPanel";
            TravellerBookingsPanel.Size = new Size(1190, 681);
            TravellerBookingsPanel.TabIndex = 3;
            TravellerBookingsPanel.Visible = false;
            // 
            // BookingsDisplayPanel
            // 
            BookingsDisplayPanel.BackColor = Color.White;
            BookingsDisplayPanel.Location = new Point(6, 140);
            BookingsDisplayPanel.Name = "BookingsDisplayPanel";
            BookingsDisplayPanel.Size = new Size(1184, 532);
            BookingsDisplayPanel.TabIndex = 2;
            // 
            // BookingsTopPanel
            // 
            BookingsTopPanel.BackColor = Color.White;
            BookingsTopPanel.Controls.Add(BookingsLabel);
            BookingsTopPanel.Location = new Point(12, 49);
            BookingsTopPanel.Name = "BookingsTopPanel";
            BookingsTopPanel.Size = new Size(1178, 80);
            BookingsTopPanel.TabIndex = 1;
            // 
            // BookingsLabel
            // 
            BookingsLabel.AutoSize = true;
            BookingsLabel.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BookingsLabel.Location = new Point(512, 25);
            BookingsLabel.Name = "BookingsLabel";
            BookingsLabel.Size = new Size(136, 37);
            BookingsLabel.TabIndex = 0;
            BookingsLabel.Text = "Bookings";
            // 
            // TravellerTransactionPanel
            // 
            TravellerTransactionPanel.Controls.Add(TransactionDisplayPanel);
            TravellerTransactionPanel.Controls.Add(TransactionTopPanel);
            TravellerTransactionPanel.Location = new Point(85, 0);
            TravellerTransactionPanel.Name = "TravellerTransactionPanel";
            TravellerTransactionPanel.Size = new Size(1191, 684);
            TravellerTransactionPanel.TabIndex = 1;
            // 
            // TransactionDisplayPanel
            // 
            TransactionDisplayPanel.BackColor = Color.White;
            TransactionDisplayPanel.Location = new Point(3, 140);
            TransactionDisplayPanel.Name = "TransactionDisplayPanel";
            TransactionDisplayPanel.Size = new Size(1185, 532);
            TransactionDisplayPanel.TabIndex = 1;
            // 
            // TransactionTopPanel
            // 
            TransactionTopPanel.BackColor = Color.White;
            TransactionTopPanel.Controls.Add(TransactionHeading);
            TransactionTopPanel.Location = new Point(3, 32);
            TransactionTopPanel.Name = "TransactionTopPanel";
            TransactionTopPanel.Size = new Size(1188, 100);
            TransactionTopPanel.TabIndex = 0;
            // 
            // TransactionHeading
            // 
            TransactionHeading.AutoSize = true;
            TransactionHeading.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TransactionHeading.Location = new Point(484, 29);
            TransactionHeading.Name = "TransactionHeading";
            TransactionHeading.Size = new Size(177, 37);
            TransactionHeading.TabIndex = 0;
            TransactionHeading.Text = "Transactions";
            // 
            // DashboardPanel
            // 
            DashboardPanel.Controls.Add(UpcomingTripsPanel);
            DashboardPanel.Controls.Add(PreferencesPanel);
            DashboardPanel.Controls.Add(StatisticsPanel);
            DashboardPanel.Controls.Add(panel1);
            DashboardPanel.Controls.Add(TravellerBio);
            DashboardPanel.Controls.Add(TravllerPicBox);
            DashboardPanel.Controls.Add(TravellerName);
            DashboardPanel.Location = new Point(85, 0);
            DashboardPanel.Name = "DashboardPanel";
            DashboardPanel.Size = new Size(1188, 684);
            DashboardPanel.TabIndex = 1;
            // 
            // UpcomingTripsPanel
            // 
            UpcomingTripsPanel.BackColor = Color.White;
            UpcomingTripsPanel.Controls.Add(UpcomingTripsLabel);
            UpcomingTripsPanel.Location = new Point(631, 20);
            UpcomingTripsPanel.Name = "UpcomingTripsPanel";
            UpcomingTripsPanel.Size = new Size(548, 652);
            UpcomingTripsPanel.TabIndex = 5;
            // 
            // UpcomingTripsLabel
            // 
            UpcomingTripsLabel.AutoSize = true;
            UpcomingTripsLabel.BackColor = Color.White;
            UpcomingTripsLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpcomingTripsLabel.Location = new Point(189, 5);
            UpcomingTripsLabel.Name = "UpcomingTripsLabel";
            UpcomingTripsLabel.Padding = new Padding(5);
            UpcomingTripsLabel.Size = new Size(177, 40);
            UpcomingTripsLabel.TabIndex = 0;
            UpcomingTripsLabel.Text = "Upcoming Trips";
            // 
            // PreferencesPanel
            // 
            PreferencesPanel.BackColor = Color.White;
            PreferencesPanel.BorderStyle = BorderStyle.FixedSingle;
            PreferencesPanel.Controls.Add(AddPreferenceButton);
            PreferencesPanel.Controls.Add(PreferencesHeading);
            PreferencesPanel.Location = new Point(18, 368);
            PreferencesPanel.Name = "PreferencesPanel";
            PreferencesPanel.Size = new Size(585, 304);
            PreferencesPanel.TabIndex = 4;
            // 
            // AddPreferenceButton
            // 
            AddPreferenceButton.AutoSize = true;
            AddPreferenceButton.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddPreferenceButton.Location = new Point(535, 8);
            AddPreferenceButton.Name = "AddPreferenceButton";
            AddPreferenceButton.Size = new Size(31, 32);
            AddPreferenceButton.TabIndex = 1;
            AddPreferenceButton.Text = "+";
            // 
            // PreferencesHeading
            // 
            PreferencesHeading.AutoSize = true;
            PreferencesHeading.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PreferencesHeading.Location = new Point(204, 11);
            PreferencesHeading.Name = "PreferencesHeading";
            PreferencesHeading.Size = new Size(148, 32);
            PreferencesHeading.TabIndex = 0;
            PreferencesHeading.Text = "Preferences";
            // 
            // StatisticsPanel
            // 
            StatisticsPanel.Controls.Add(StatisticLabel);
            StatisticsPanel.Controls.Add(panel3);
            StatisticsPanel.Controls.Add(panel2);
            StatisticsPanel.Controls.Add(successfulJourneysPanel);
            StatisticsPanel.Location = new Point(18, 157);
            StatisticsPanel.Name = "StatisticsPanel";
            StatisticsPanel.Size = new Size(585, 186);
            StatisticsPanel.TabIndex = 3;
            // 
            // StatisticLabel
            // 
            StatisticLabel.AutoSize = true;
            StatisticLabel.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            StatisticLabel.Location = new Point(228, 9);
            StatisticLabel.Name = "StatisticLabel";
            StatisticLabel.Size = new Size(99, 30);
            StatisticLabel.TabIndex = 5;
            StatisticLabel.Text = "Statistics";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(395, 45);
            panel3.Name = "panel3";
            panel3.Size = new Size(156, 126);
            panel3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(67, 79);
            label3.Name = "label3";
            label3.Size = new Size(19, 21);
            label3.TabIndex = 2;
            label3.Text = "3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(32, 63);
            label4.Name = "label4";
            label4.Size = new Size(87, 17);
            label4.TabIndex = 1;
            label4.Text = "Adventurous";
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(46, 9);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(61, 50);
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox2);
            panel2.Location = new Point(204, 45);
            panel2.Name = "panel2";
            panel2.Size = new Size(156, 126);
            panel2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 79);
            label1.Name = "label1";
            label1.Size = new Size(19, 21);
            label1.TabIndex = 2;
            label1.Text = "5";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Gray;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(145, 17);
            label2.TabIndex = 1;
            label2.Text = "Days Spend Travelling";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(46, 9);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(61, 50);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // successfulJourneysPanel
            // 
            successfulJourneysPanel.BackColor = Color.White;
            successfulJourneysPanel.Controls.Add(SuccessfulJourneysNumber);
            successfulJourneysPanel.Controls.Add(SuccessfulJourneysLabel);
            successfulJourneysPanel.Controls.Add(pictureBox1);
            successfulJourneysPanel.Location = new Point(12, 45);
            successfulJourneysPanel.Name = "successfulJourneysPanel";
            successfulJourneysPanel.Size = new Size(156, 126);
            successfulJourneysPanel.TabIndex = 0;
            // 
            // SuccessfulJourneysNumber
            // 
            SuccessfulJourneysNumber.AutoSize = true;
            SuccessfulJourneysNumber.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SuccessfulJourneysNumber.Location = new Point(67, 79);
            SuccessfulJourneysNumber.Name = "SuccessfulJourneysNumber";
            SuccessfulJourneysNumber.Size = new Size(19, 21);
            SuccessfulJourneysNumber.TabIndex = 2;
            SuccessfulJourneysNumber.Text = "3";
            // 
            // SuccessfulJourneysLabel
            // 
            SuccessfulJourneysLabel.AutoSize = true;
            SuccessfulJourneysLabel.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SuccessfulJourneysLabel.ForeColor = Color.Gray;
            SuccessfulJourneysLabel.Location = new Point(13, 62);
            SuccessfulJourneysLabel.Name = "SuccessfulJourneysLabel";
            SuccessfulJourneysLabel.Size = new Size(130, 17);
            SuccessfulJourneysLabel.TabIndex = 1;
            SuccessfulJourneysLabel.Text = "Successful Journeys";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(46, 9);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 50);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(ActiveNumberLabel);
            panel1.Controls.Add(BookedNumberLabel);
            panel1.Controls.Add(completedNumberLabel);
            panel1.Controls.Add(ActiveLabel);
            panel1.Controls.Add(BookedLabel);
            panel1.Controls.Add(completedLabel);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(147, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 72);
            panel1.TabIndex = 2;
            // 
            // ActiveNumberLabel
            // 
            ActiveNumberLabel.AutoSize = true;
            ActiveNumberLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ActiveNumberLabel.ForeColor = Color.Black;
            ActiveNumberLabel.Location = new Point(206, 14);
            ActiveNumberLabel.Name = "ActiveNumberLabel";
            ActiveNumberLabel.Size = new Size(23, 25);
            ActiveNumberLabel.TabIndex = 5;
            ActiveNumberLabel.Text = "0";
            // 
            // BookedNumberLabel
            // 
            BookedNumberLabel.AutoSize = true;
            BookedNumberLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BookedNumberLabel.ForeColor = Color.Black;
            BookedNumberLabel.Location = new Point(122, 13);
            BookedNumberLabel.Name = "BookedNumberLabel";
            BookedNumberLabel.Size = new Size(23, 25);
            BookedNumberLabel.TabIndex = 4;
            BookedNumberLabel.Text = "0";
            // 
            // completedNumberLabel
            // 
            completedNumberLabel.AutoSize = true;
            completedNumberLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            completedNumberLabel.ForeColor = Color.Black;
            completedNumberLabel.Location = new Point(36, 13);
            completedNumberLabel.Name = "completedNumberLabel";
            completedNumberLabel.Size = new Size(23, 25);
            completedNumberLabel.TabIndex = 3;
            completedNumberLabel.Text = "0";
            // 
            // ActiveLabel
            // 
            ActiveLabel.AutoSize = true;
            ActiveLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ActiveLabel.ForeColor = Color.Gray;
            ActiveLabel.Location = new Point(197, 42);
            ActiveLabel.Name = "ActiveLabel";
            ActiveLabel.Size = new Size(43, 15);
            ActiveLabel.TabIndex = 2;
            ActiveLabel.Text = "Active";
            // 
            // BookedLabel
            // 
            BookedLabel.AutoSize = true;
            BookedLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BookedLabel.ForeColor = Color.Gray;
            BookedLabel.Location = new Point(110, 42);
            BookedLabel.Name = "BookedLabel";
            BookedLabel.Size = new Size(50, 15);
            BookedLabel.TabIndex = 1;
            BookedLabel.Text = "Booked";
            // 
            // completedLabel
            // 
            completedLabel.AutoSize = true;
            completedLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            completedLabel.ForeColor = Color.Gray;
            completedLabel.Location = new Point(16, 42);
            completedLabel.Name = "completedLabel";
            completedLabel.Size = new Size(68, 15);
            completedLabel.TabIndex = 0;
            completedLabel.Text = "Completed";
            // 
            // TravellerBio
            // 
            TravellerBio.AutoSize = true;
            TravellerBio.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TravellerBio.ForeColor = SystemColors.ControlDarkDark;
            TravellerBio.Location = new Point(149, 45);
            TravellerBio.Name = "TravellerBio";
            TravellerBio.Size = new Size(126, 20);
            TravellerBio.TabIndex = 1;
            TravellerBio.Text = "I Love to Travel!!";
            // 
            // TravllerPicBox
            // 
            TravllerPicBox.Image = Properties.Resources.travellerpic;
            TravllerPicBox.Location = new Point(18, 20);
            TravllerPicBox.Name = "TravllerPicBox";
            TravllerPicBox.Size = new Size(108, 122);
            TravllerPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            TravllerPicBox.TabIndex = 1;
            TravllerPicBox.TabStop = false;
            // 
            // TravellerName
            // 
            TravellerName.AutoSize = true;
            TravellerName.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TravellerName.Location = new Point(142, 8);
            TravellerName.Name = "TravellerName";
            TravellerName.Size = new Size(129, 37);
            TravellerName.TabIndex = 0;
            TravellerName.Text = "Traveller";
            // 
            // paymentBookingsPanel
            // 
            paymentBookingsPanel.BackColor = Color.White;
            paymentBookingsPanel.Controls.Add(PaymentHeadLabel);
            paymentBookingsPanel.Controls.Add(groupBoxAccNum);
            paymentBookingsPanel.Controls.Add(PayButton);
            paymentBookingsPanel.Controls.Add(RoleSelectionGroup);
            paymentBookingsPanel.Location = new Point(209, 22);
            paymentBookingsPanel.Name = "paymentBookingsPanel";
            paymentBookingsPanel.Size = new Size(632, 486);
            paymentBookingsPanel.TabIndex = 0;
            paymentBookingsPanel.Visible = false;
            // 
            // PaymentHeadLabel
            // 
            PaymentHeadLabel.AutoSize = true;
            PaymentHeadLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PaymentHeadLabel.Location = new Point(264, 20);
            PaymentHeadLabel.Name = "PaymentHeadLabel";
            PaymentHeadLabel.Size = new Size(113, 32);
            PaymentHeadLabel.TabIndex = 9;
            PaymentHeadLabel.Text = "Payment";
            // 
            // groupBoxAccNum
            // 
            groupBoxAccNum.Controls.Add(innerAccNumBox);
            groupBoxAccNum.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBoxAccNum.Location = new Point(158, 219);
            groupBoxAccNum.Name = "groupBoxAccNum";
            groupBoxAccNum.Size = new Size(321, 63);
            groupBoxAccNum.TabIndex = 8;
            groupBoxAccNum.TabStop = false;
            groupBoxAccNum.Text = "Account Number";
            // 
            // innerAccNumBox
            // 
            innerAccNumBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            innerAccNumBox.BorderStyle = BorderStyle.None;
            innerAccNumBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            innerAccNumBox.Location = new Point(13, 22);
            innerAccNumBox.Name = "innerAccNumBox";
            innerAccNumBox.Size = new Size(302, 22);
            innerAccNumBox.TabIndex = 3;
            // 
            // PayButton
            // 
            PayButton.BackColor = Color.Black;
            PayButton.BorderStyle = BorderStyle.FixedSingle;
            PayButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            PayButton.ForeColor = Color.White;
            PayButton.Location = new Point(275, 337);
            PayButton.Name = "PayButton";
            PayButton.Size = new Size(93, 46);
            PayButton.TabIndex = 7;
            PayButton.Text = "Pay ";
            PayButton.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RoleSelectionGroup
            // 
            RoleSelectionGroup.Controls.Add(MethodSelectOptions);
            RoleSelectionGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            RoleSelectionGroup.Location = new Point(158, 101);
            RoleSelectionGroup.Margin = new Padding(2);
            RoleSelectionGroup.Name = "RoleSelectionGroup";
            RoleSelectionGroup.Padding = new Padding(2);
            RoleSelectionGroup.Size = new Size(321, 71);
            RoleSelectionGroup.TabIndex = 6;
            RoleSelectionGroup.TabStop = false;
            RoleSelectionGroup.Text = "Payment Method";
            // 
            // MethodSelectOptions
            // 
            MethodSelectOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MethodSelectOptions.BackColor = Color.White;
            MethodSelectOptions.FlatStyle = FlatStyle.Flat;
            MethodSelectOptions.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MethodSelectOptions.ForeColor = SystemColors.InactiveCaptionText;
            MethodSelectOptions.FormattingEnabled = true;
            MethodSelectOptions.ItemHeight = 30;
            MethodSelectOptions.Items.AddRange(new object[] { "Credit Card", "Debit Card", "PayPal", "Bank Transfer" });
            MethodSelectOptions.Location = new Point(10, 19);
            MethodSelectOptions.Margin = new Padding(2);
            MethodSelectOptions.Name = "MethodSelectOptions";
            MethodSelectOptions.Size = new Size(307, 38);
            MethodSelectOptions.TabIndex = 4;
            MethodSelectOptions.Text = "Credit Card";
            // 
            // CompleteTripInfoPanel
            // 
            CompleteTripInfoPanel.BackColor = Color.FromArgb(224, 224, 224);
            CompleteTripInfoPanel.Dock = DockStyle.Fill;
            CompleteTripInfoPanel.Location = new Point(0, 0);
            CompleteTripInfoPanel.Name = "CompleteTripInfoPanel";
            CompleteTripInfoPanel.Size = new Size(1188, 684);
            CompleteTripInfoPanel.TabIndex = 0;
            CompleteTripInfoPanel.Visible = false;
            // 
            // digitalPassesDiaplayPanel
            // 
            digitalPassesDiaplayPanel.Dock = DockStyle.Fill;
            digitalPassesDiaplayPanel.Location = new Point(189, 22);
            digitalPassesDiaplayPanel.Name = "digitalPassesDiaplayPanel";
            digitalPassesDiaplayPanel.Size = new Size(730, 607);
            digitalPassesDiaplayPanel.TabIndex = 0;
            digitalPassesDiaplayPanel.Visible = false;
            // 
            // profilePanel
            // 
            profilePanel.Location = new Point(85, 0);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(1191, 672);
            profilePanel.TabIndex = 1;
            // 
            // Traveller
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1276, 684);
            Controls.Add(mainPanel);
            Name = "Traveller";
            Text = "Traveller";
            Load += Traveller_Load;
            mainPanel.ResumeLayout(false);
            TravellerTripsPanel.ResumeLayout(false);
            TravellerTripTopPanel.ResumeLayout(false);
            TravellerTripTopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)moneySlider).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            SideBarPanel.ResumeLayout(false);
            TransactionButtonPanel.ResumeLayout(false);
            TransactionButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TransactionsButton).EndInit();
            BookingsButtonPanel.ResumeLayout(false);
            BookingsButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)BookingsButton).EndInit();
            TripButtonPanel.ResumeLayout(false);
            TripButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TripsButton).EndInit();
            DashBoardButtonPanel.ResumeLayout(false);
            DashBoardButtonPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DashboardButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)travelEaseLogo).EndInit();
            TravellerBookingsPanel.ResumeLayout(false);
            BookingsTopPanel.ResumeLayout(false);
            BookingsTopPanel.PerformLayout();
            TravellerTransactionPanel.ResumeLayout(false);
            TransactionTopPanel.ResumeLayout(false);
            TransactionTopPanel.PerformLayout();
            DashboardPanel.ResumeLayout(false);
            DashboardPanel.PerformLayout();
            UpcomingTripsPanel.ResumeLayout(false);
            UpcomingTripsPanel.PerformLayout();
            PreferencesPanel.ResumeLayout(false);
            PreferencesPanel.PerformLayout();
            StatisticsPanel.ResumeLayout(false);
            StatisticsPanel.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            successfulJourneysPanel.ResumeLayout(false);
            successfulJourneysPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TravllerPicBox).EndInit();
            paymentBookingsPanel.ResumeLayout(false);
            paymentBookingsPanel.PerformLayout();
            groupBoxAccNum.ResumeLayout(false);
            groupBoxAccNum.PerformLayout();
            RoleSelectionGroup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel SideBarPanel;
        private PictureBox DashboardButton;
        private PictureBox TripsButton;
        private PictureBox travelEaseLogo;
        private Label DashBoardButtonLabel;
        private Label TripButtonLabel;
        private Panel BookingsButtonPanel;
        private PictureBox BookingsButton;
        private Label BookingsButtonLabel;
        private Panel TripButtonPanel;
        private Panel DashBoardButtonPanel;
        private Panel TransactionButtonPanel;
        private PictureBox TransactionsButton;
        private Label TransactionButtonLabel;
        private Panel DashboardPanel;
        private Label TravellerName;
        private PictureBox TravllerPicBox;
        private Label TravellerBio;
        private Panel panel1;
        private Label completedLabel;
        private Label completedNumberLabel;
        private Label ActiveLabel;
        private Label BookedLabel;
        private Label ActiveNumberLabel;
        private Label BookedNumberLabel;
        private Panel StatisticsPanel;
        private Panel successfulJourneysPanel;
        private Label SuccessfulJourneysNumber;
        private Label SuccessfulJourneysLabel;
        private PictureBox pictureBox1;
        private Label StatisticLabel;
        private Panel panel3;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private PictureBox pictureBox2;
        private Panel UpcomingTripsPanel;
        private Label UpcomingTripsLabel;
        private Panel TravellerTripsPanel;
        private Panel TravellerTripTopPanel;
        private Label TripsLabel;
        private TextBox searchBox;
        private Panel TripDisplayPanel;
        private Panel CompleteTripInfoPanel;
        private Panel BookingsDisplayPanel;
        private Panel BookingsTopPanel;
        private Label BookingsLabel;
        private Panel TravellerBookingsPanel;
        private Panel digitalPassesDiaplayPanel;
        private Panel paymentBookingsPanel;
        private GroupBox RoleSelectionGroup;
        private ComboBox MethodSelectOptions;
        private Label PayButton;
        private GroupBox groupBoxAccNum;
        private TextBox innerAccNumBox;
        private Label PaymentHeadLabel;
        private Panel TravellerTransactionPanel;
        private Panel TransactionDisplayPanel;
        private Panel TransactionTopPanel;
        private Label TransactionHeading;
        private Panel PreferencesPanel;
        private Label AddPreferenceButton;
        private Label PreferencesHeading;
        private GroupBox groupBox1;
        private DateTimePicker dateTimePicker2;
        private Label applyfilterbox;
        private GroupBox groupBox2;
        private DateTimePicker dateTimePicker1;
        private Panel profilePanel;
        private TrackBar moneySlider;
        private Label MoneyLabel;
    }
}