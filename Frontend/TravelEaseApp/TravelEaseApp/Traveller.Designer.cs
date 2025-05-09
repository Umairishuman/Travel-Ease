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
            CompleteTripInfoPanel = new Panel();
            TravellerTripTopPanel = new Panel();
            textBox1 = new TextBox();
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
            DashboardPanel = new Panel();
            panel4 = new Panel();
            peopleTravelled = new Label();
            UpcomingTripsPanel = new Panel();
            UpcomingTripsLabel = new Label();
            PreferencesPanel = new Panel();
            preferencesAddButton = new PictureBox();
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
            mainPanel.SuspendLayout();
            TravellerTripsPanel.SuspendLayout();
            TripDisplayPanel.SuspendLayout();
            TravellerTripTopPanel.SuspendLayout();
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
            DashboardPanel.SuspendLayout();
            panel4.SuspendLayout();
            UpcomingTripsPanel.SuspendLayout();
            PreferencesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)preferencesAddButton).BeginInit();
            StatisticsPanel.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            successfulJourneysPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TravllerPicBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(TravellerTripsPanel);
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
            // 
            // TripDisplayPanel
            // 
            TripDisplayPanel.BackColor = Color.White;
            //TripDisplayPanel.Controls.Add(CompleteTripInfoPanel);
            TripDisplayPanel.Location = new Point(3, 115);
            TripDisplayPanel.Name = "TripDisplayPanel";
            TripDisplayPanel.Size = new Size(1185, 557);
            TripDisplayPanel.TabIndex = 1;
            TripDisplayPanel.Click += TripDisplayPanel_Click;
            // 
            // CompleteTripInfoPanel
            // 
            CompleteTripInfoPanel.BackColor = Color.FromArgb(224, 224, 224);
            CompleteTripInfoPanel.Location = new Point(178, 13);
            CompleteTripInfoPanel.Name = "CompleteTripInfoPanel";
            CompleteTripInfoPanel.Size = new Size(800, 529);
            CompleteTripInfoPanel.TabIndex = 0;
            CompleteTripInfoPanel.Visible = false;
            // 
            // TravellerTripTopPanel
            // 
            TravellerTripTopPanel.BackColor = Color.White;
            TravellerTripTopPanel.Controls.Add(textBox1);
            TravellerTripTopPanel.Controls.Add(TripsLabel);
            TravellerTripTopPanel.Location = new Point(3, 32);
            TravellerTripTopPanel.Name = "TravellerTripTopPanel";
            TravellerTripTopPanel.Size = new Size(1185, 73);
            TravellerTripTopPanel.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(844, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(332, 33);
            textBox1.TabIndex = 1;
            // 
            // TripsLabel
            // 
            TripsLabel.AutoSize = true;
            TripsLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TripsLabel.Location = new Point(380, 18);
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
            // DashboardPanel
            // 
            DashboardPanel.Controls.Add(panel4);
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
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(peopleTravelled);
            panel4.Location = new Point(631, 368);
            panel4.Name = "panel4";
            panel4.Size = new Size(548, 291);
            panel4.TabIndex = 6;
            // 
            // peopleTravelled
            // 
            peopleTravelled.AutoSize = true;
            peopleTravelled.BackColor = Color.White;
            peopleTravelled.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            peopleTravelled.Location = new Point(182, 11);
            peopleTravelled.Name = "peopleTravelled";
            peopleTravelled.Padding = new Padding(5);
            peopleTravelled.Size = new Size(205, 40);
            peopleTravelled.TabIndex = 0;
            peopleTravelled.Text = "Travelling Partners";
            // 
            // UpcomingTripsPanel
            // 
            UpcomingTripsPanel.BackColor = Color.White;
            UpcomingTripsPanel.Controls.Add(UpcomingTripsLabel);
            UpcomingTripsPanel.Location = new Point(631, 20);
            UpcomingTripsPanel.Name = "UpcomingTripsPanel";
            UpcomingTripsPanel.Size = new Size(548, 323);
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
            PreferencesPanel.Controls.Add(preferencesAddButton);
            PreferencesPanel.Controls.Add(PreferencesHeading);
            PreferencesPanel.Location = new Point(18, 368);
            PreferencesPanel.Name = "PreferencesPanel";
            PreferencesPanel.Size = new Size(585, 304);
            PreferencesPanel.TabIndex = 4;
            // 
            // preferencesAddButton
            // 
            preferencesAddButton.Location = new Point(531, 13);
            preferencesAddButton.Name = "preferencesAddButton";
            preferencesAddButton.Size = new Size(34, 30);
            preferencesAddButton.TabIndex = 1;
            preferencesAddButton.TabStop = false;
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
            TripDisplayPanel.ResumeLayout(false);
            TravellerTripTopPanel.ResumeLayout(false);
            TravellerTripTopPanel.PerformLayout();
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
            DashboardPanel.ResumeLayout(false);
            DashboardPanel.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            UpcomingTripsPanel.ResumeLayout(false);
            UpcomingTripsPanel.PerformLayout();
            PreferencesPanel.ResumeLayout(false);
            PreferencesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)preferencesAddButton).EndInit();
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
        private Panel PreferencesPanel;
        private Label PreferencesHeading;
        private PictureBox preferencesAddButton;
        private Panel UpcomingTripsPanel;
        private Label UpcomingTripsLabel;
        private Panel panel4;
        private Label peopleTravelled;
        private Panel TravellerTripsPanel;
        private Panel TravellerTripTopPanel;
        private Label TripsLabel;
        private TextBox textBox1;
        private Panel TripDisplayPanel;
        private Panel CompleteTripInfoPanel;
    }
}