using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static TravelEaseApp.Helpers;
using System.Net;
using System.Net.NetworkInformation;
using System.Globalization;
using System.Transactions;

namespace TravelEaseApp
{

    public partial class Traveller : Form
    {
        Label hiddenLabel;
        //Panel currentPanel;
        public Traveller()
        {
            InitializeComponent();

            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0); // Invisible
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false; // Does not appear in the tab order
            this.Controls.Add(hiddenLabel);

            this.ActiveControl = hiddenLabel; // Set focus
        }

        private void Traveller_Load(object sender, EventArgs e)
        {
            AddHoverTransition(DashboardButton, DashBoardButtonPanel, DashBoardButtonPanel.BackColor, Color.Silver, DashBoardButtonPanel.ForeColor, DashBoardButtonPanel.ForeColor);
            AddHoverTransition(TripsButton, TripButtonPanel, TripButtonPanel.BackColor, Color.Silver, TripButtonPanel.ForeColor, TripButtonPanel.ForeColor);
            AddHoverTransition(BookingsButton, BookingsButtonPanel, BookingsButtonPanel.BackColor, Color.Silver, BookingsButtonPanel.ForeColor, BookingsButtonPanel.ForeColor);
            AddHoverTransition(TransactionsButton, TransactionButtonPanel, TransactionButtonPanel.BackColor, Color.Silver, TransactionButtonPanel.ForeColor, TransactionButtonPanel.ForeColor);
            AddHoverTransition(AddPreferenceButton, AddPreferenceButton.BackColor, Color.Silver, AddPreferenceButton.ForeColor, AddPreferenceButton.ForeColor);





            PreferencesPanel.AutoScroll = true;
            AddPreferenceBox(PreferencesPanel, 1, "The tower of NUCES", "Choa Saidan Shah", "Europe", "Australia");
            AddPreferenceBox(PreferencesPanel, 2, "The tower of NUCES", "Choa Saidan Shah", "Europe", "Australia");
            AddPreferenceBox(PreferencesPanel, 3, "The tower of NUCES", "Choa Saidan Shah", "Europe", "Australia");



            TripDisplayPanel.AutoScroll = true;
            //AddTripBox(TripDisplayPanel, "AN EXQUISITE JOURNEY", "a very long logn long adlkjf description", "Kashmir", "2025-12-12", "2024-12-23", "5 Days", 5, "Active", "Adventurous", 23.80f, "https://ibb.co/FbBy9qYX", "TAYYAB GROUP & SONS");
            //AddTripBox(TripDisplayPanel, "AN EXQUISITE JOURNEY", "a very long logn long adlkjf description", "Kashmir", "2025-12-12", "2024-12-23", "5 Days", 5, "Active", "Adventurous", 23.80f, "https://i.postimg.cc/D0VGX3ND/alex-shutin-k-Kv-QJ6r-K6-S4-unsplash.jpg", "TAYYAB GROUP & SONS");
            //AddTripBox(TripDisplayPanel, "AN EXQUISITE JOURNEY", "a very long logn long adlkjf description", "Kashmir", "2025-12-12", "2024-12-23", "5 Days", 5, "Active", "Adventurous", 23.80f, "","TAYYAB GROUP & SONS");

            // In your Form_Load or a button click event:
            //TripUIManager uiManager = new TripUIManager();

            // --- Mock Location Data ---
            Location locParis = new Location { DestId = "EUR-00001", DestinationName = "Eiffel Tower Visit", City = "Paris", Region = "Europe", Country = "France" };
            Location locRome = new Location { DestId = "EUR-00002", DestinationName = "Colosseum Tour", City = "Rome", Region = "Europe", Country = "Italy" };
            Location locAlps = new Location { DestId = "EUR-00003", DestinationName = "Alpine Hiking Base", City = "Chamonix", Region = "Europe", Country = "France" };


            // --- Mock Service Data ---
            Service hotelService = new Service { ServiceId = "SRV-001", ServiceType = "Hotel", ServiceDescription = "4-star hotel near city center, breakfast included.", Price = 120.00m, ProviderName = "Grand City Hotels", Capacity = 2, AverageReview = 4.5 };
            Service guideService = new Service { ServiceId = "SRV-002", ServiceType = "Guide", ServiceDescription = "Full-day licensed local guide.", Price = 80.00m, ProviderName = "Local Tour Guides Co.", Capacity = 10, AverageReview = 4.8 };
            Service transportService = new Service { ServiceId = "SRV-003", ServiceType = "Transport", ServiceDescription = "Airport transfers and city transit pass.", Price = 50.00m, ProviderName = "CityLink Transport", Capacity = 4, AverageReview = 4.2 };

            // --- Mock Trip Data ---
            Trip trip1 = new Trip
            {
                TripId = "TRIP-00001",
                Title = "European Capitals Adventure",
                Description = "Explore the rich history and vibrant culture of Paris and Rome in this 7-day whirlwind tour. See iconic landmarks, enjoy delicious cuisine, and create memories that will last a lifetime.",
                Capacity = 20,
                DurationDays = 7,
                DurationDisplay = "7 Days, 6 Nights",
                Category = "Cultural",
                Status = "Active",
                PricePerPerson = 1299.99m,
                StartLocation = locParis, // Starting point
                StartDate = new DateTime(2025, 9, 15),
                EndDate = new DateTime(2025, 9, 21),
                OperatorName = "EuroWonders Tours",
                ImageUrl = "https://i.postimg.cc/D0VGX3ND/alex-shutin-k-Kv-QJ6r-K6-S4-unsplash.jpg", // Use a real or placeholder image URL
                VisitedLocations = new List<Location> { locParis, locRome },
                IncludedServices = new List<Service> { hotelService, guideService, transportService }
            };

            Trip trip2 = new Trip
            {
                TripId = "TRIP-00002",
                Title = "Alpine Peaks Expedition",
                Description = "A breathtaking 5-day hiking trip through the majestic Alps. Perfect for adventure seekers and nature lovers. Includes guided hikes and mountain lodge accommodation.",
                Capacity = 12,
                DurationDays = 5,
                DurationDisplay = "5 Days, 4 Nights",
                Category = "Adventure",
                Status = "Active",
                PricePerPerson = 899.00m,
                StartLocation = locAlps,
                StartDate = new DateTime(2025, 7, 20),
                EndDate = new DateTime(2025, 7, 24),
                OperatorName = "Mountain Goat Adventures",
                ImageUrl = "https://via.placeholder.com/300x200.png?text=Alps+Hiking",
                VisitedLocations = new List<Location> { locAlps },
                IncludedServices = new List<Service>{

                    new Service { ServiceId = "SRV-004", ServiceType = "Accommodation", ServiceDescription = "Mountain Lodge Stay (shared rooms)", Price = 70.00m, ProviderName = "Alpine Lodges Inc.", Capacity = 4, AverageReview = 4.3 },
                    new Service { ServiceId = "SRV-005", ServiceType = "Guide", ServiceDescription = "Certified Mountain Guide for all hikes.", Price = 100.00m, ProviderName = "Peak Guides", Capacity = 6, AverageReview = 4.9 }
                }
            };


            AddTripBox(TripDisplayPanel, trip1);
            AddTripBox(TripDisplayPanel, trip2);

            mainPanel.MouseDown += (s, e) =>
            {
                // If the info panel is not visible, do nothing
                if (!CompleteTripInfoPanel.Visible)
                    return;

                // Convert mouse location to screen coordinates
                Point screenClickPoint = mainPanel.PointToScreen(e.Location);

                // Get bounds of CompleteTripInfoPanel in screen coordinates
                Rectangle infoBounds = CompleteTripInfoPanel.RectangleToScreen(CompleteTripInfoPanel.ClientRectangle);

                // Check if click is outside the bounds of the panel
                if (!infoBounds.Contains(screenClickPoint))
                {
                    mainPanel.Controls.Remove(CompleteTripInfoPanel);
                    CompleteTripInfoPanel.Visible = false;
                    CompleteTripInfoPanel.SendToBack();
                }
            };

            Booking booking1 = new Booking("BOOK-123456", DateTime.Now, "confirmed", "TRAV-001", "TRIP-002");
            DigitalPass digitalPasses = new DigitalPass("ETK-654321", DateTime.Now, DateTime.Now.AddDays(7), "e-ticket", "BOOK-123456", "SRV-0001");
            DigitalPass digitalPasses1 = new DigitalPass("ETK-654321", DateTime.Now, DateTime.Now.AddDays(7), "e-ticket", "BOOK-123456", "SRV-0002");

            booking1.AddDigitalPass(digitalPasses);
            booking1.AddDigitalPass(digitalPasses1);

            Booking booking2 = new Booking("BOOK-123456", DateTime.Now, "pending", "TRAV-001", "TRIP-002");

            booking2.AddDigitalPass(digitalPasses);
            booking2.AddDigitalPass(digitalPasses1);
            AddBookingBox(BookingsDisplayPanel, booking1, trip1.Title);
            AddBookingBox(BookingsDisplayPanel, booking2, trip2.Title);



            SetupGroupBoxFocusBehavior(groupBoxAccNum, innerAccNumBox);
            AddPlaceholder(innerAccNumBox, "PK47ABPL9882329237938473");
            AddHoverTransition(PayButton, PayButton.BackColor, PayButton.ForeColor, PayButton.ForeColor, PayButton.BackColor);

            TravelEaseApp.Helpers.Transaction newTransaction = new TravelEaseApp.Helpers.Transaction(
            $"TXN-{new Random().Next(100000, 999999)}",
            150.75m,
            DateTime.Now.AddHours(-new Random().Next(1, 72)),
            "credit_card",
            "BKG-00123", // Associated Booking ID
            "success",
            "ACCT-XXXX-1234"
                );

            AddTransactionToPanel(TransactionDisplayPanel, newTransaction);

            TravelEaseApp.Helpers.Transaction pendingTransaction = new TravelEaseApp.Helpers.Transaction(
                $"TXN-{new Random().Next(100000, 999999)}",
                75.00m,
                DateTime.Now.AddMinutes(-30),
                "paypal",
                "BKG-00124",
                "pending",
                "ACCT-XXXX-5678"
            );
            AddTransactionToPanel(TransactionDisplayPanel, pendingTransaction);


            AddTripBox(UpcomingTripsPanel, trip1);
            AddTripBox(UpcomingTripsPanel, trip2);

        }



        //TripDisplayPanel_Click
        private void TripDisplayPanel_Click(object sender, EventArgs e)
        {

        }

        public void AddPreferenceBox(
            Panel containerPanel,
            int destId,
            string destinationName,
            string city,
            string region,
            string country)
        {

            int horizontalPadding = 20;
            int verticalPadding = 12;
            int boxHeight = 120;
            int boxWidth = containerPanel.Width - 2 * horizontalPadding;

            Panel box = new Panel
            {
                Width = boxWidth,
                Height = boxHeight,
                BackColor = Color.White,
                //BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            int boxTop = (containerPanel.Controls.Count - 1) * (boxHeight + verticalPadding) - 70;
            box.Location = new Point(horizontalPadding, boxTop);


            box.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, box.ClientRectangle,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid,
                    Color.LightGray, 1, ButtonBorderStyle.Solid);
            };


            // Title: Destination Name (Top Left)
            Label lblTitle = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Text = destinationName,
                ForeColor = Color.Black,
                Location = new Point(10, 10),
                Width = box.Width - 20,
                Height = 24
            };

            // Left-aligned: ID and Region
            Label lblLeft = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray,
                Location = new Point(10, lblTitle.Bottom + 8),
                Width = (box.Width / 2) - 15,
                Height = 40,
                Text = $"ID: {destId}\nRegion: {region}"
            };

            // Right-aligned: City and Country
            Label lblRight = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.DimGray,
                TextAlign = ContentAlignment.TopRight,
                Location = new Point(box.Width / 2, lblTitle.Bottom + 8),
                Width = (box.Width / 2) - 20,
                Height = 40,
                Text = $"City: {city}\nCountry: {country}"
            };


            AddHoverTransition(box, box.BackColor, Color.Silver, box.ForeColor, box.ForeColor);
            box.Controls.Add(lblTitle);
            box.Controls.Add(lblLeft);
            box.Controls.Add(lblRight);

            containerPanel.Controls.Add(box);
        }




        public void AddTripBox(Panel containerPanel, Trip trip)
        {
            // --- Design Constants ---
            int horizontalPagePadding = 20;
            int verticalSpacing = 20;
            int boxInternalPadding = 15;

            int boxWidth = containerPanel.Width - 2 * horizontalPagePadding;
            if (boxWidth < 400) boxWidth = 400;
            int boxHeight = 230;

            int imageWidth = (int)(boxWidth * 0.35);
            if (imageWidth > 200) imageWidth = 200;
            int imageHeight = boxHeight - 2 * boxInternalPadding;

            // --- Colors ---
            Color primaryBackColor = Color.FromArgb(255, 255, 255);
            Color hoverColor = Color.FromArgb(240, 248, 255);
            Color borderColor = Color.FromArgb(220, 224, 230);
            Color accentColor = Color.FromArgb(0, 0, 0);
            Color titleColor = Color.FromArgb(30, 30, 30);
            Color textColor = Color.FromArgb(80, 80, 80);
            Color subtleTextColor = Color.FromArgb(120, 120, 120);
            Color priceColor = Color.FromArgb(0, 100, 0);

            // --- Fonts ---
            Font titleFont = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 9F);
            Font smallTextFont = new Font("Segoe UI", 8F, FontStyle.Italic);
            Font priceFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Font statusFont = new Font("Segoe UI Semibold", 8F, FontStyle.Bold);

            // --- Create the main trip Panel (tripBox) ---
            Panel tripBox = new Panel
            {
                Width = boxWidth,
                Height = boxHeight,
                BackColor = primaryBackColor,
                Padding = new Padding(boxInternalPadding),
                Margin = new Padding(0, 0, 0, verticalSpacing)
            };

            int yPosition = verticalSpacing;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPosition = lastControl.Bottom + verticalSpacing;
            }
            tripBox.Location = new Point(horizontalPagePadding, yPosition);

            tripBox.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, tripBox.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);

                using (SolidBrush accentBrush = new SolidBrush(accentColor))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, 6, tripBox.Height);
                }
            };

            // --- PictureBox for Image ---
            PictureBox tripImage = new PictureBox
            {
                Width = imageWidth,
                Height = imageHeight,
                Location = new Point(boxInternalPadding + 6, boxInternalPadding),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.FromArgb(230, 230, 230)
            };

            if (!string.IsNullOrWhiteSpace(trip.ImageUrl))
            {
                if (trip.ImageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) || File.Exists(trip.ImageUrl))
                {
                    tripImage.LoadAsync(trip.ImageUrl);
                }
            }

            // --- Content Panel ---
            Panel contentPanel = new Panel
            {
                Location = new Point(tripImage.Right + boxInternalPadding, boxInternalPadding),
                Width = tripBox.Width - tripImage.Width - (boxInternalPadding * 3) - 6,
                Height = imageHeight,
                BackColor = Color.Transparent
            };

            // --- Title ---
            Label lblTitle = new Label
            {
                Text = trip.Title,
                Font = titleFont,
                ForeColor = titleColor,
                AutoSize = false,
                Width = contentPanel.Width - 85,
                Height = titleFont.Height + 4,
                Location = new Point(0, 0),
                AutoEllipsis = true
            };

            // --- Status ---
            Panel pnlStatus = new Panel
            {
                Height = 22,
                //AutoSize = true,
                Padding = new Padding(0, 0, 0, 0)
            };
            Label lblStatusText = new Label
            {
                Text = trip.Status.ToUpper(),
                Font = statusFont,
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false,
                Location = new Point(0, 0)
            };
            pnlStatus.Controls.Add(lblStatusText);
            pnlStatus.MinimumSize = new Size(70, 22);

            switch (trip.Status.ToLower())
            {
                case "active":
                    pnlStatus.BackColor = Color.MediumSeaGreen;
                    lblStatusText.Text = "ACHLKhhgghJK";
                    break;
                case "cancelled":
                    pnlStatus.BackColor = Color.Tomato;
                    break;
                case "completed":
                    pnlStatus.BackColor = Color.CornflowerBlue;
                    break;
                default:
                    pnlStatus.BackColor = Color.LightSlateGray;
                    lblStatusText.Text = "N/A";
                    break;
            }
            pnlStatus.Location = new Point(contentPanel.Width - pnlStatus.Width - 10, 2);
            //lblStatusText.Location = new Point(0, 0);

            // --- Description ---
            Label lblDescription = new Label
            {
                Text = trip.Description,
                Font = textFont,
                ForeColor = textColor,
                AutoSize = false,
                Width = contentPanel.Width,
                Height = 38,
                Location = new Point(0, lblTitle.Bottom + 6),
                AutoEllipsis = true
            };

            // --- Dates and Locations (Start + End) ---
            string endLocationName = (trip.VisitedLocations != null && trip.VisitedLocations.Count > 0)
                ? trip.VisitedLocations.Last().DestinationName
                : "N/A";

            Label lblDatesAndLocation = new Label
            {
                Text = $"📍 {trip.StartLocation?.DestinationName} ➝ {endLocationName}\n🗓️ {trip.StartDate:MMM dd, yyyy} - {trip.EndDate:MMM dd, yyyy}",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(0, lblDescription.Bottom + 8)
            };

            // --- Duration and Category ---
            Label lblDurationCategory = new Label
            {
                Text = $"⏳ {trip.DurationDisplay}   |   🏷️ {trip.Category}",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(0, lblDatesAndLocation.Bottom + 8)
            };

            // --- Capacity ---
            Label lblCapacity = new Label
            {
                Text = $"👥 Capacity: {trip.Capacity} guests",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(0, lblDurationCategory.Bottom + 8)
            };

            // --- Price ---
            Label lblPrice = new Label
            {
                Text = $"{trip.PricePerPerson:C}",
                Font = priceFont,
                ForeColor = priceColor,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Width = (int)(contentPanel.Width * 0.4),
                Height = priceFont.Height + 4,
                Location = new Point(contentPanel.Width - (int)(contentPanel.Width * 0.4), contentPanel.Height - priceFont.Height - 4)
            };

            // --- Operator ---
            Label lblOperator = new Label
            {
                Text = $"Operator: {trip.OperatorName}",
                Font = smallTextFont,
                ForeColor = accentColor,
                AutoSize = false,
                AutoEllipsis = true,
                Width = contentPanel.Width - lblPrice.Width - 10,
                Height = smallTextFont.Height + 2,
                Location = new Point(0, contentPanel.Height - smallTextFont.Height - 6)
            };

            // --- Add to panels ---
            contentPanel.Controls.Add(lblTitle);
            contentPanel.Controls.Add(pnlStatus);
            //contentPanel.Controls.Add(lblStatusText);
            contentPanel.Controls.Add(lblDescription);
            contentPanel.Controls.Add(lblDatesAndLocation);
            contentPanel.Controls.Add(lblDurationCategory);
            contentPanel.Controls.Add(lblCapacity);
            contentPanel.Controls.Add(lblPrice);
            contentPanel.Controls.Add(lblOperator);

            tripBox.Controls.Add(tripImage);
            tripBox.Controls.Add(contentPanel);

            //// --- Hover effect ---
            //foreach (Control ctl in contentPanel.Controls)
            //{
            //    if (ctl is Label) ctl.BackColor = Color.Transparent;
            //    ctl.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
            //    ctl.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;
            //}
            //tripImage.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
            //tripImage.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;

            AddHoverTransition(tripBox, primaryBackColor, hoverColor, titleColor, textColor);

            // --- Add to container ---
            containerPanel.Controls.Add(tripBox);
            containerPanel.ScrollControlIntoView(tripBox);

            EventHandler showTripDetails = (s, e) =>
            {
                if (CompleteTripInfoPanel.Visible == false)
                {
                    mainPanel.Controls.Add(CompleteTripInfoPanel);
                    CompleteTripInfoPanel.BringToFront();
                    CompleteTripInfoPanel.Visible = true;

                }
                DisplayTripInPanel(CompleteTripInfoPanel, trip);
            };

            // Attach to tripBox and all its children
            AttachClickToAllChildren(tripBox, showTripDetails);

        }

     

        public void DisplayTripInPanel(Panel targetPanel, Trip trip)
        {
               // --- UPDATED Theme and Styling Constants for WHITE BACKGROUND ---
             Color PanelBackgroundColor = Color.WhiteSmoke; // Light background
             Color TextColor = Color.FromArgb(30, 30, 30);          // Dark text
             Color MutedTextColor = Color.FromArgb(80, 80, 80);      // Slightly lighter dark text
             Color AccentColor = Color.FromArgb(0, 122, 204);      // Modern Blue for accents/button
             Color ButtonTextColor = Color.White;                    // White text for button
             Color DividerColor = Color.LightGray;                   // Light grey for dividers

             Font TitleFont = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
             Font SubtitleFont = new Font("Segoe UI", 16F, FontStyle.Regular);
             Font BodyFont = new Font("Segoe UI", 12F, FontStyle.Regular);
             Font SectionHeaderFont = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
             Font ButtonFont = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);

             const int MainPadding = 20;
             const int ItemSpacing = 8;
             const int SectionSpacing = 15;


            if (targetPanel == null) throw new ArgumentNullException(nameof(targetPanel));
            if (trip == null) throw new ArgumentNullException(nameof(trip));




            targetPanel.Controls.Clear();
            targetPanel.BackColor = PanelBackgroundColor;
            targetPanel.ForeColor = TextColor; // Default text color
            targetPanel.Padding = new Padding(MainPadding);
            targetPanel.AutoScroll = true;
            //add a small cross on the top right corner of the panel to close the panel
            AddCloseButtonToPanel(targetPanel, mainPanel);



            int currentY = MainPadding;

            Label AddLabel(string text, Font font, Color color, int y, int? fixedHeight = null, bool isMultiline = true, ContentAlignment alignment = ContentAlignment.TopLeft)
            {
                Label lbl = new Label
                {
                    Text = text,
                    Font = font,
                    ForeColor = color,
                    BackColor = Color.Transparent, // Important for themed background
                    Location = new Point(MainPadding, y),
                    Width = targetPanel.ClientSize.Width - (2 * MainPadding),
                    TextAlign = alignment,
                };

                if (isMultiline)
                {
                    lbl.AutoSize = false;
                    Size textSize = TextRenderer.MeasureText(text, font, new Size(lbl.Width, int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                    lbl.Height = fixedHeight ?? textSize.Height + 5;
                }
                else
                {
                    lbl.AutoSize = true;
                }
                targetPanel.Controls.Add(lbl);
                return lbl;
            }

            Panel AddDivider(int y) // Not used in current white theme, but kept for potential future use
            {
                Panel divider = new Panel
                {
                    Height = 1,
                    BackColor = DividerColor, // Updated divider color
                    Location = new Point(MainPadding, y),
                    Width = targetPanel.ClientSize.Width - (2 * MainPadding),
                };
                targetPanel.Controls.Add(divider);
                return divider;
            }

            if (!string.IsNullOrWhiteSpace(trip.ImageUrl))
            {
                PictureBox pictureBox = new PictureBox
                {
                    Location = new Point(MainPadding, currentY),
                    Size = new Size(targetPanel.ClientSize.Width - (2 * MainPadding), 200),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Gainsboro // Lighter background for image placeholder on white theme
                };
                try
                {
                    if (Uri.IsWellFormedUriString(trip.ImageUrl, UriKind.Absolute))
                    {
                        using (WebClient wc = new WebClient())
                        {
                            byte[] imageBytes = wc.DownloadData(trip.ImageUrl);
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else if (System.IO.File.Exists(trip.ImageUrl))
                    {
                        pictureBox.ImageLocation = trip.ImageUrl;
                    }
                    else
                    {
                        Label imgPlaceholder = new Label
                        {
                            Text = "Image not available",
                            Font = BodyFont,
                            ForeColor = MutedTextColor,
                            BackColor = pictureBox.BackColor, // Match picbox background
                            Size = pictureBox.Size,
                            TextAlign = ContentAlignment.MiddleCenter
                        };
                        pictureBox.Controls.Add(imgPlaceholder); // Add placeholder text over PictureBox
                    }
                    targetPanel.Controls.Add(pictureBox);
                    currentY += pictureBox.Height + SectionSpacing;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Image load error: {ex.Message}");
                    Label imgErrorLabel = AddLabel("Image could not be loaded.", BodyFont, MutedTextColor, currentY);
                    currentY += imgErrorLabel.Height + ItemSpacing;
                }
            }

            Label lblTitle = AddLabel(trip.Title ?? "Untitled Trip", TitleFont, TextColor, currentY, alignment: ContentAlignment.MiddleCenter);
            currentY += lblTitle.Height + ItemSpacing;

            string priceDuration = $"{trip.PricePerPerson:C} per person  |  {trip.DurationDisplay ?? "Duration N/A"}";
            Label lblPriceDuration = AddLabel(priceDuration, SubtitleFont, MutedTextColor, currentY, alignment: ContentAlignment.MiddleCenter);
            currentY += lblPriceDuration.Height + SectionSpacing;
            currentY += AddDivider(currentY).Height + ItemSpacing; // Add a divider line

            if (!string.IsNullOrWhiteSpace(trip.Description))
            {
                Label lblDescHeader = AddLabel("OVERVIEW", SectionHeaderFont, AccentColor, currentY);
                currentY += lblDescHeader.Height + (ItemSpacing / 2);
                Label lblDescription = AddLabel(trip.Description, BodyFont, TextColor, currentY);
                currentY += lblDescription.Height + SectionSpacing;
                currentY += AddDivider(currentY).Height + ItemSpacing; // Add a divider line
            }

            Label lblDetailsHeader = AddLabel("DETAILS", SectionHeaderFont, AccentColor, currentY);
            currentY += lblDetailsHeader.Height + (ItemSpacing / 2);

            Label lblDates = AddLabel($"Dates: {trip.StartDate:MMMM dd, yyyy} - {trip.EndDate:MMMM dd, yyyy}", BodyFont, TextColor, currentY);
            currentY += lblDates.Height + ItemSpacing;

            Label lblStartLoc = AddLabel($"Starts In: {(trip.StartLocation?.ToString() ?? "N/A")}", BodyFont, TextColor, currentY);
            currentY += lblStartLoc.Height + ItemSpacing;

            Label lblCapacity = AddLabel($"Capacity: {trip.Capacity} guests", BodyFont, TextColor, currentY);
            currentY += lblCapacity.Height + ItemSpacing;

            Label lblOperator = AddLabel($"Operated By: {trip.OperatorName ?? "N/A"}", BodyFont, TextColor, currentY);
            currentY += lblOperator.Height + ItemSpacing;

            Label lblCategory = AddLabel($"Category: {trip.Category ?? "N/A"}", BodyFont, TextColor, currentY);
            currentY += lblCategory.Height + ItemSpacing;

            Label lblStatus = AddLabel($"Status: {trip.Status ?? "N/A"}", BodyFont, TextColor, currentY);
            currentY += lblStatus.Height + SectionSpacing;
            currentY += AddDivider(currentY).Height + ItemSpacing; // Add a divider line

            if (trip.VisitedLocations != null && trip.VisitedLocations.Any())
            {
                Label lblVisitedHeader = AddLabel("PLACES YOU'LL VISIT", SectionHeaderFont, AccentColor, currentY);
                currentY += lblVisitedHeader.Height + (ItemSpacing / 2);
                foreach (var loc in trip.VisitedLocations)
                {
                    Label lblLoc = AddLabel($"• {loc.ToString()}", BodyFont, TextColor, currentY);
                    currentY += lblLoc.Height + (ItemSpacing / 2);
                }
                currentY += SectionSpacing - (ItemSpacing / 2);
                currentY += AddDivider(currentY).Height + ItemSpacing; // Add a divider line
            }

            if (trip.IncludedServices != null && trip.IncludedServices.Any())
            {
                Label lblServicesHeader = AddLabel("WHAT'S INCLUDED", SectionHeaderFont, AccentColor, currentY);
                currentY += lblServicesHeader.Height + (ItemSpacing / 2);
                foreach (var service in trip.IncludedServices)
                {
                    string serviceText = $"• {service.ServiceType ?? "Service"}: {service.ServiceDescription ?? "Details not specified."}";
                    if (!string.IsNullOrWhiteSpace(service.ProviderName) && service.ProviderName != "N/A")
                    {
                        serviceText += $" (Provider: {service.ProviderName})";
                    }
                    Label lblService = AddLabel(serviceText, BodyFont, TextColor, currentY);
                    currentY += lblService.Height + (ItemSpacing / 2);
                }
                currentY += SectionSpacing - (ItemSpacing / 2);
            }
            currentY += ItemSpacing;

            Button btnBookNow = new Button
            {
                Text = "Book Now",
                Font = ButtonFont,
                ForeColor = ButtonTextColor,
                BackColor = AccentColor,
                FlatStyle = FlatStyle.Flat,
                Height = 50,
                Width = targetPanel.ClientSize.Width - (2 * MainPadding),
                Location = new Point(MainPadding, currentY),
                Cursor = Cursors.Hand,
                Tag = trip.TripId
            };
            btnBookNow.FlatAppearance.BorderSize = 0;
            targetPanel.Controls.Add(btnBookNow);
            currentY += btnBookNow.Height + MainPadding;

            targetPanel.AutoScrollMinSize = new Size(0, currentY);
            targetPanel.Invalidate(); // Ensure the panel redraws with new styles
        }
        public void AddCloseButtonToPanel(Panel panel, Panel mainPanel)
        {
            // Create the close button
            Button closeButton = new Button
            {
                Text = "×",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkGray,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(25, 25),
                Location = new Point(5, 5),
                TabStop = false,
                Cursor = Cursors.Hand
            };

            // Remove border styling
            closeButton.FlatAppearance.BorderSize = 0;

            // Handle click event
            closeButton.Click += (s, e) =>
            {
                mainPanel.Controls.Remove(panel);
                panel.Visible = false;
                panel.SendToBack();
            };

            // Ensure button is always on top
            panel.Controls.Add(closeButton);
            closeButton.BringToFront();
        }


        private void DashboardButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = true;
            TravellerTripsPanel.Visible = false;
            TravellerBookingsPanel.Visible = false;
            //TravellerTransactionsPanel.Visible = false;

        }

        private void TripsButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            TravellerTripsPanel.Visible = true;
            TravellerBookingsPanel.Visible = false;
            //TravellerTransactionsPanel.Visible = false;

        }

        private void BookingsButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            TravellerTripsPanel.Visible = false;
            TravellerBookingsPanel.Visible = true;
            //TravellerTransactionsPanel.Visible = false;
        }

        private void TransactionsButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            TravellerTripsPanel.Visible = false;
            TravellerBookingsPanel.Visible = false;
            //TravellerTransactionsPanel.Visible = true;;
        }


        public void AddBookingBox(Panel containerPanel, Booking booking, string tripName)
        {
            // --- Design Constants (adapted from AddTripBox) ---
            int horizontalPagePadding = 20;
            int verticalSpacing = 20;
            int boxInternalPadding = 15;

            int boxWidth = containerPanel.Width - 2 * horizontalPagePadding;
            if (boxWidth < 350) boxWidth = 350; // Min width for booking box
                                                // Height will be somewhat dynamic based on content, but we can set a min
            int minBoxHeight = 160;
            int buttonAreaHeight = 45 + boxInternalPadding; // For buttons

            // --- Colors (consistent with AddTripBox's white theme) ---
            Color primaryBackColor = Color.FromArgb(255, 255, 255); // White
            Color hoverColor = Color.FromArgb(240, 248, 255);     // AliceBlue (light blue for hover)
            Color borderColor = Color.FromArgb(220, 224, 230);    // Light grey border
            Color accentColor = Color.FromArgb(0, 0, 0);          // Black accent bar on left
            Color titleColor = Color.FromArgb(30, 30, 30);        // Dark grey for titles
            Color textColor = Color.FromArgb(80, 80, 80);         // Medium grey for text
            Color subtleTextColor = Color.FromArgb(120, 120, 120); // Lighter grey for less important text
            Color buttonBlue = Color.FromArgb(0, 123, 255);       // Standard button blue
            Color buttonRed = Color.FromArgb(220, 53, 69);        // Standard button red (for cancel)
            Color buttonDisabledColor = Color.LightGray;
            Color buttonDisabledTextColor = Color.DarkGray;

            // Status Colors
            Color statusConfirmedColor = Color.FromArgb(40, 167, 69); // Green
            Color statusPendingColor = Color.FromArgb(255, 193, 7);   // Yellow/Orange
            Color statusCancelledColor = Color.FromArgb(220, 53, 69); // Red
            Color statusAbandonedColor = Color.FromArgb(108, 117, 125); // Grey

            // --- Fonts ---
            Font tripNameFont = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            Font headingFont = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 9F);
            Font smallTextFont = new Font("Segoe UI", 8F);
            Font statusFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            Font buttonFont = new Font("Segoe UI Semibold", 9F);

            // --- Create the main booking Panel (bookingCardPanel) ---
            Panel bookingCardPanel = new Panel
            {
                Width = boxWidth,
                // Height will be set later
                BackColor = primaryBackColor,
                Padding = new Padding(boxInternalPadding),
                Margin = new Padding(0, 0, 0, verticalSpacing) // Bottom margin for spacing
            };

            int yPositionInContainer = verticalSpacing; // Default for the first box
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPositionInContainer = lastControl.Bottom + verticalSpacing;
            }
            bookingCardPanel.Location = new Point(horizontalPagePadding, yPositionInContainer);

            // Paint event for border and left accent bar
            bookingCardPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, bookingCardPanel.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);

                using (SolidBrush accentBrush = new SolidBrush(accentColor))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, 6, bookingCardPanel.Height); // 6px wide accent bar
                }
            };

            int currentY = boxInternalPadding; // Y position inside the bookingCardPanel
            int contentStartX = boxInternalPadding + 6; // Start X after accent bar
            int contentWidth = bookingCardPanel.Width - contentStartX - boxInternalPadding;


            // --- Trip Name ---
            Label lblTripName = new Label
            {
                Text = tripName ?? "N/A Trip Name",
                Font = tripNameFont,
                ForeColor = titleColor,
                AutoSize = false,
                Width = contentWidth - 100, // Allow space for status
                Height = tripNameFont.Height + 4,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true,
                Tag = "HoverSensitive" // For simplified hover
            };
            bookingCardPanel.Controls.Add(lblTripName);

            // --- Booking Status Panel ---
            Panel pnlStatus = new Panel
            {
                Height = 24,
                Width = 90, // Adjust as needed
                Location = new Point(bookingCardPanel.Width - boxInternalPadding - 90, currentY), // Top-right
                Padding = new Padding(5, 0, 5, 0)
            };
            Label lblStatusText = new Label
            {
                Text = booking.BookingStatus.ToUpper(),
                Font = statusFont,
                ForeColor = Color.White, // Text color for status will be white on colored background
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false
            };
            pnlStatus.Controls.Add(lblStatusText);

            switch (booking.BookingStatus.ToLower())
            {
                case "confirmed":
                    pnlStatus.BackColor = statusConfirmedColor;
                    break;
                case "pending":
                    pnlStatus.BackColor = statusPendingColor;
                    lblStatusText.ForeColor = Color.Black; // Better contrast for yellow
                    break;
                case "cancelled":
                    pnlStatus.BackColor = statusCancelledColor;
                    break;
                case "abandoned":
                    pnlStatus.BackColor = statusAbandonedColor;
                    break;
                default:
                    pnlStatus.BackColor = Color.LightSlateGray;
                    lblStatusText.Text = "UNKNOWN";
                    break;
            }
            bookingCardPanel.Controls.Add(pnlStatus);
            currentY += Math.Max(lblTripName.Height, pnlStatus.Height) + 8;


            // --- Booking Details ---
            Label lblBookingId = new Label
            {
                Text = $"Booking ID: {booking.BookingId}",
                Font = textFont,
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY),
                Tag = "HoverSensitive"
            };
            bookingCardPanel.Controls.Add(lblBookingId);
            currentY += lblBookingId.Height + 5;

            Label lblBookDate = new Label
            {
                Text = $"Booked On: {booking.BookDate:MMM dd, yyyy hh:mm tt}",
                Font = textFont,
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY),
                Tag = "HoverSensitive"
            };
            bookingCardPanel.Controls.Add(lblBookDate);
            currentY += lblBookDate.Height + 5;

            Label lblTravelerId = new Label
            {
                Text = $"Traveler ID: {booking.TravelerId}",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY),
                Tag = "HoverSensitive"
            };
            bookingCardPanel.Controls.Add(lblTravelerId);
            currentY += lblTravelerId.Height + 15; // More space before buttons


            // --- Buttons Area ---
            Panel buttonsPanel = new Panel
            {
                Location = new Point(contentStartX, currentY),
                Width = contentWidth,
                Height = buttonAreaHeight - boxInternalPadding, // Height for buttons
                BackColor = Color.Transparent
            };
            bookingCardPanel.Controls.Add(buttonsPanel);

            int buttonWidth = 130;
            int buttonHeight = 30;
            int buttonSpacing = 10;


            if (booking.BookingStatus.ToLower() == "pending")
            {
                Button btnPay = new Button
                {
                    Text = "Pay Now",
                    Font = buttonFont,
                    ForeColor = Color.White,
                    BackColor = buttonBlue,
                    Width = buttonWidth,
                    Height = buttonHeight,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(0, 0),
                    Tag = booking.BookingId // Store booking ID for click event
                };
                btnPay.FlatAppearance.BorderSize = 0;
                btnPay.Click += (s, e) => {
                    if (paymentBookingsPanel.Visible == false)
                    {
                        paymentBookingsPanel.Visible = true;
                        mainPanel.Controls.Add(paymentBookingsPanel);
                        paymentBookingsPanel.BringToFront();
                    }

                };
                buttonsPanel.Controls.Add(btnPay);
                AddCloseButtonToPanel(paymentBookingsPanel, mainPanel);

                Button btnCancelPending = new Button
                {
                    Text = "Cancel Booking",
                    Font = buttonFont,
                    ForeColor = Color.White,
                    BackColor = buttonRed,
                    Width = buttonWidth,
                    Height = buttonHeight,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(btnPay.Right + buttonSpacing, 0),
                    Tag = booking.BookingId
                };
                btnCancelPending.FlatAppearance.BorderSize = 0;
                btnCancelPending.Click += (s, e) => { /* TODO: Implement Cancel Click Logic */ MessageBox.Show($"Cancel Booking ID: {((Button)s).Tag}"); };
                buttonsPanel.Controls.Add(btnCancelPending);
            }
            else if (booking.BookingStatus.ToLower() == "confirmed")
            {
                Button btnPaid = new Button
                {
                    Text = "Paid",
                    Font = buttonFont,
                    ForeColor = buttonDisabledTextColor,
                    BackColor = buttonDisabledColor,
                    Width = buttonWidth,
                    Height = buttonHeight,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(0, 0),
                    Enabled = false // Disabled
                };
                btnPaid.FlatAppearance.BorderSize = 0;
                buttonsPanel.Controls.Add(btnPaid);

                Button btnViewPasses = new Button
                {
                    Text = "View Digital Passes",
                    Font = buttonFont,
                    ForeColor = Color.White,
                    BackColor = buttonBlue, // Or a different color like Green
                    Width = buttonWidth + 30, // Slightly wider for longer text
                    Height = buttonHeight,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(btnPaid.Right + buttonSpacing, 0),
                    Tag = booking.BookingId
                };
                btnViewPasses.FlatAppearance.BorderSize = 0;
                //btnViewPasses.Click += (s, e) => { /* TODO: Implement View Passes Click Logic */ MessageBox.Show($"View Passes for Booking ID: {((Button)s).Tag}"); };
                btnViewPasses.Click += (s, e) =>
                {
                    if (digitalPassesDiaplayPanel.Visible == false)
                    {
                        mainPanel.Controls.Add(digitalPassesDiaplayPanel);
                        digitalPassesDiaplayPanel.BringToFront();
                        digitalPassesDiaplayPanel.Visible = true;
                    }
                    ShowDigitalPassesForBooking(booking);
                };

                buttonsPanel.Controls.Add(btnViewPasses);
            }
            // For "cancelled" or "abandoned", no buttons are added as per current requirement.

            currentY += buttonsPanel.Height + boxInternalPadding;

            // Set final height for the booking card
            bookingCardPanel.Height = Math.Max(minBoxHeight, currentY);

            // --- Add Hover Effect ---
            // Using the simplified one. Replace with your actual AddHoverTransition if it's different.
            AddHoverTransition(bookingCardPanel, primaryBackColor, hoverColor, titleColor, titleColor);


            // --- Add to container ---
            containerPanel.Controls.Add(bookingCardPanel);
            if (containerPanel.Parent is Form) // Simple check if scroll is needed
            {
                containerPanel.ScrollControlIntoView(bookingCardPanel);
            }
            else // If nested, just ensure it's added. Scrolling might be handled by parent.
            {
                // Optional: Adjust scroll position of containerPanel if it's scrollable
                if (containerPanel.VerticalScroll.Visible)
                {
                    containerPanel.ScrollControlIntoView(bookingCardPanel);
                }
            }
        }


        private void ShowDigitalPassesForBooking(Booking currentBooking)
        {
            if (currentBooking == null || currentBooking.DigitalPasses == null || !currentBooking.DigitalPasses.Any())
            {
                MessageBox.Show("No digital passes found for this booking.", "Digital Passes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                digitalPassesDiaplayPanel.Controls.Clear(); // Clear the panel
                Label lblNoPasses = new Label { Text = "No passes to display.", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleCenter };
                digitalPassesDiaplayPanel.Controls.Add(lblNoPasses);
                return;
            }

            // 1. Get the list of passes
            List<DigitalPass> passesToShow = currentBooking.DigitalPasses;

            // 2. Create the Service ID to Service Name map (CRUCIAL STEP)
            // This is a placeholder. You need to implement the logic to fetch service names.
            Dictionary<string, string> serviceMap = new Dictionary<string, string>();
            foreach (var pass in passesToShow)
            {
                if (!string.IsNullOrEmpty(pass.ServiceId) && !serviceMap.ContainsKey(pass.ServiceId))
                {
                    // --- Pseudocode for fetching service name ---
                    // string serviceName = GetServiceNameFromServerOrDatabase(pass.ServiceId);
                    // if (!string.IsNullOrEmpty(serviceName))
                    // {
                    //     serviceMap[pass.ServiceId] = serviceName;
                    // }
                    // --- End Pseudocode ---

                    // For demonstration, let's add some dummy service names:
                    if (pass.ServiceId == "SRV-0001") serviceMap[pass.ServiceId] = "Grand Alpine Hotel - Deluxe Room";
                    if (pass.ServiceId == "SRV-FLIGHT002") serviceMap[pass.ServiceId] = "Flight AX101 to Zurich (Business Class)";
                    if (pass.ServiceId == "SRV-ACTIVITY003") serviceMap[pass.ServiceId] = "Guided City Tour & Museum Entry";
                }
            }

            // 3. Call the display function
            DisplayPassesInPanel(digitalPassesDiaplayPanel, passesToShow, serviceMap);
            AddCloseButtonToPanel(digitalPassesDiaplayPanel, mainPanel);

        }



        public void DisplayPassesInPanel(Panel containerPanel, List<DigitalPass> passes, Dictionary<string, string> serviceIdToNameMap)
        {
            if (containerPanel == null) throw new ArgumentNullException(nameof(containerPanel));
            if (passes == null) throw new ArgumentNullException(nameof(passes));
            if (serviceIdToNameMap == null) throw new ArgumentNullException(nameof(serviceIdToNameMap));

            containerPanel.Controls.Clear(); // Clear previous content
            containerPanel.AutoScroll = true; // Ensure scrolling if content overflows

            // --- Design Constants for Pass Cards ---
            int horizontalPagePadding = 15; // Padding within the containerPanel for the cards
            int verticalCardSpacing = 15;   // Spacing between pass cards
            int cardInternalPadding = 12;
            int cardAccentBarWidth = 8;
            int interElementSpacing = 5; // Spacing between elements like icon, title, button

            int cardWidth = containerPanel.ClientSize.Width - (2 * horizontalPagePadding);
            if (cardWidth < 350) cardWidth = 350; // Minimum width for a pass card (increased slightly for button)
            int cardMinHeight = 120; // Minimum height, will adjust based on content

            // --- Colors (consistent with previous white theme) ---
            Color primaryBackColor = Color.FromArgb(255, 255, 255);         // White
            Color cardHoverColor = Color.FromArgb(245, 248, 255);           // Very light blue for hover
            Color cardBorderColor = Color.FromArgb(220, 224, 230);          // Light grey border
            Color passTitleColor = Color.FromArgb(20, 20, 20);              // Darker for pass type title
            Color passTextColor = Color.FromArgb(50, 50, 50);               // Standard dark text
            Color passSubtleTextColor = Color.FromArgb(100, 100, 100);      // Grey for less important details
            Color validityColorUpcoming = Color.FromArgb(30, 130, 30);      // Green for valid
            Color validityColorExpired = Color.FromArgb(200, 50, 50);       // Red for expired
            Color downloadButtonHoverColor = Color.FromArgb(230, 230, 230); // Light grey for button hover

            // Pass Type Specific Accent Colors
            Color eticketAccentColor = Color.FromArgb(0, 123, 255);     // Blue
            Color hotelAccentColor = Color.FromArgb(40, 167, 69);       // Green
            Color activityAccentColor = Color.FromArgb(255, 128, 0);    // Orange

            // --- Fonts ---
            Font passTypeFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Font detailHeaderFont = new Font("Segoe UI Semibold", 9F);
            Font detailTextFont = new Font("Segoe UI", 9F);
            Font validityFont = new Font("Segoe UI Semibold", 9F);
            Font iconFont = new Font("Segoe UI Symbol", 12F); // For Unicode icons
            Font downloadButtonFont = new Font("Segoe UI Symbol", 11F); // Font for download button icon

            int currentYInContainer = verticalCardSpacing; // Initial Y position for the first card

            if (!passes.Any())
            {
                Label lblNoPasses = new Label
                {
                    Text = "No digital passes available for this booking.",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = passSubtleTextColor,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill, // Center in the panel if it's empty
                    Padding = new Padding(20)
                };
                containerPanel.Controls.Add(lblNoPasses);
                return;
            }

            foreach (DigitalPass pass in passes)
            {
                // --- Create the Pass Card Panel ---
                Panel passCard = new Panel
                {
                    Width = cardWidth,
                    BackColor = primaryBackColor,
                    Padding = new Padding(cardInternalPadding), // Internal padding for content
                    Margin = new Padding(0, 0, 0, 0), // Will set location manually
                    Location = new Point(horizontalPagePadding, currentYInContainer)
                };

                Color currentAccentColor;
                string passIconUnicode = "";
                string passTypeDisplay = pass.DocumentType; // Default

                switch (pass.DocumentType.ToLower())
                {
                    case "e-ticket":
                        currentAccentColor = eticketAccentColor;
                        passIconUnicode = "✈️"; // U+2708 Airplane or 🎫 U+1F3AB Ticket
                        passTypeDisplay = "E-Ticket";
                        break;
                    case "hotel voucher":
                        currentAccentColor = hotelAccentColor;
                        passIconUnicode = "🏨"; // U+1F3E8 Hotel
                        passTypeDisplay = "Hotel Voucher";
                        break;
                    case "activity pass":
                        currentAccentColor = activityAccentColor;
                        passIconUnicode = "🎟️"; // U+1F39F Admission Tickets
                        passTypeDisplay = "Activity Pass";
                        break;
                    default:
                        currentAccentColor = Color.Gray;
                        passIconUnicode = "📄"; // Default document icon
                        passTypeDisplay = pass.DocumentType.ToUpper(); // Default display for unknown types
                        break;
                }

                // Paint event for border and left accent bar
                passCard.Paint += (s, e) =>
                {
                    ControlPaint.DrawBorder(e.Graphics, passCard.ClientRectangle,
                        cardBorderColor, 1, ButtonBorderStyle.Solid,
                        cardBorderColor, 1, ButtonBorderStyle.Solid,
                        cardBorderColor, 1, ButtonBorderStyle.Solid,
                        cardBorderColor, 1, ButtonBorderStyle.Solid);

                    using (SolidBrush accentBrush = new SolidBrush(currentAccentColor))
                    {
                        e.Graphics.FillRectangle(accentBrush, 0, 0, cardAccentBarWidth, passCard.Height);
                    }
                };

                int currentYOnCard = cardInternalPadding; // Y position inside the passCard
                int contentStartX = cardInternalPadding + cardAccentBarWidth; // Start X after accent bar and internal padding
                                                                              // Total width available for content (icon + title + button + details)
                int availableContentWidth = passCard.Width - contentStartX - cardInternalPadding;


                // --- Download Button ---
                Button btnDownload = new Button
                {
                    Text = "📥", // Download icon (U+1F4E5 Inbox Tray) or "💾" (U+1F4BE Floppy Disk)
                    Font = downloadButtonFont,
                    ForeColor = passSubtleTextColor,
                    BackColor = primaryBackColor, // Or a specific color
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(30, 30), // Fixed size for the button
                    Cursor = Cursors.Hand,
                    Tag = pass.PassId, // Store PassId for the click event to identify the pass
                    Location = new Point(contentStartX + availableContentWidth - 30, currentYOnCard) // Positioned at the top-right of content area
                };
                btnDownload.FlatAppearance.BorderSize = 0;
                btnDownload.FlatAppearance.MouseOverBackColor = downloadButtonHoverColor;
                btnDownload.FlatAppearance.MouseDownBackColor = cardBorderColor; // Darker grey press

                // Add ToolTip to the download button
                //downloadToolTip.SetToolTip(btnDownload, $"Download {passTypeDisplay} (ID: {pass.PassId})");

                btnDownload.Click += (sender, eventArgs) =>
                {
                    Button clickedButton = sender as Button;
                    if (clickedButton != null)
                    {
                        string passIdToDownload = clickedButton.Tag as string;
                        // Placeholder for actual download logic
                        // You would typically call a method here like:
                        // DownloadDigitalPass(passIdToDownload);
                        MessageBox.Show($"Download requested for pass ID: {passIdToDownload}", "Download Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
                passCard.Controls.Add(btnDownload);


                // --- Pass Type Title and Icon ---
                Label lblPassIcon = new Label
                {
                    Text = passIconUnicode,
                    Font = iconFont,
                    ForeColor = currentAccentColor,
                    AutoSize = true,
                    // Vertically align icon with the center of the (slightly taller) download button or pass type text
                    Location = new Point(contentStartX, currentYOnCard + (btnDownload.Height - iconFont.Height) / 2 + 1)
                };
                passCard.Controls.Add(lblPassIcon);

                Label lblPassType = new Label
                {
                    Text = passTypeDisplay.ToUpper(),
                    Font = passTypeFont,
                    ForeColor = passTitleColor,
                    AutoSize = false, // Important for setting width
                                      // Calculate width: from right of icon to left of download button, with spacing
                    Width = (btnDownload.Left - interElementSpacing) - (lblPassIcon.Right + interElementSpacing),
                    Height = passTypeFont.Height + 4, // Sufficient height for the font
                    Location = new Point(lblPassIcon.Right + interElementSpacing, currentYOnCard),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Tag = "HoverSensitive"
                };
                passCard.Controls.Add(lblPassType);

                // Determine max height of header elements (icon, title, button) for currentY progression
                int headerMaxHeight = Math.Max(lblPassType.Height, Math.Max(lblPassIcon.Height, btnDownload.Height));
                currentYOnCard += headerMaxHeight + 10; // Space after header section


                // --- Pass Details ---
                // Local function to add detail labels (header and value)
                Func<string, string, int, Label> AddDetail = (headerText, valueText, yPos) =>
                {
                    Label lblHeader = new Label
                    {
                        Text = headerText,
                        Font = detailHeaderFont,
                        ForeColor = passSubtleTextColor,
                        AutoSize = true,
                        Location = new Point(contentStartX, yPos)
                    };
                    passCard.Controls.Add(lblHeader);

                    Label lblValue = new Label
                    {
                        Text = valueText,
                        Font = detailTextFont,
                        ForeColor = passTextColor,
                        AutoSize = false, // Allow wrapping
                        Width = availableContentWidth, // Use the full available content width for details
                        MaximumSize = new Size(availableContentWidth, 0), // Allow height to grow indefinitely
                                                                          // Calculate height based on text content and width
                        Height = TextRenderer.MeasureText(valueText, detailTextFont, new Size(availableContentWidth, int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl).Height + 2,
                        Location = new Point(contentStartX, yPos + lblHeader.Height - 2), // Slightly overlap for dense look
                        Tag = "HoverSensitive"
                    };
                    passCard.Controls.Add(lblValue);
                    return lblValue; // Return the value label to get its bottom for positioning next control
                };

                Label lastDetailLabel;
                lastDetailLabel = AddDetail("PASS ID:", pass.PassId, currentYOnCard);
                currentYOnCard = lastDetailLabel.Bottom + 8;

                string serviceName = "N/A";
                if (!string.IsNullOrEmpty(pass.ServiceId))
                {
                    serviceIdToNameMap.TryGetValue(pass.ServiceId, out serviceName);
                    if (string.IsNullOrEmpty(serviceName)) serviceName = $"Service (ID: {pass.ServiceId})";
                }
                else if (pass.DocumentType.ToLower() == "e-ticket")
                {
                    serviceName = "Travel E-Ticket"; // Generic placeholder if ServiceId is not present for e-tickets
                }

                if (serviceName != "N/A" || !string.IsNullOrEmpty(pass.ServiceId)) // Show service if available or ID is present
                {
                    lastDetailLabel = AddDetail("SERVICE:", serviceName, currentYOnCard);
                    currentYOnCard = lastDetailLabel.Bottom + 8;
                }

                lastDetailLabel = AddDetail("ISSUED ON:", pass.DateGenerated.ToString("MMM dd, yyyy hh:mm tt"), currentYOnCard);
                currentYOnCard = lastDetailLabel.Bottom + 12; // More space before validity status

                // --- Validity Status ---
                Label lblValidTillHeader = new Label
                {
                    Text = "VALID UNTIL:",
                    Font = detailHeaderFont,
                    ForeColor = passSubtleTextColor,
                    AutoSize = true,
                    Location = new Point(contentStartX, currentYOnCard)
                };
                passCard.Controls.Add(lblValidTillHeader);

                Label lblValidTillValue = new Label
                {
                    Text = pass.ValidTill.ToString("MMM dd, yyyy"),
                    Font = validityFont,
                    ForeColor = pass.ValidTill.Date >= DateTime.Today ? validityColorUpcoming : validityColorExpired,
                    AutoSize = true,
                    Location = new Point(contentStartX, currentYOnCard + lblValidTillHeader.Height - 2)
                };
                passCard.Controls.Add(lblValidTillValue);
                currentYOnCard = lblValidTillValue.Bottom + cardInternalPadding; // Add final internal padding to bottom

                // Set final height for the pass card, ensuring it meets minimum height
                passCard.Height = Math.Max(cardMinHeight, currentYOnCard);

                // --- Add Hover Effect (Optional, using a hypothetical method) ---
                // AddHoverTransition(passCard, primaryBackColor, cardHoverColor, passTextColor, passTextColor);
                // For simplicity, hover is handled by button's FlatAppearance and card can have its own simple hover if needed.
                passCard.MouseEnter += (s, e) => passCard.BackColor = cardHoverColor;
                passCard.MouseLeave += (s, e) => passCard.BackColor = primaryBackColor;
                // Ensure child controls also trigger parent's hover or have transparent backcolors if needed for visual consistency
                foreach (Control ctrl in passCard.Controls)
                {
                    if (ctrl != btnDownload) // Exclude button as it has its own hover
                    {
                        ctrl.MouseEnter += (s, e) => passCard.BackColor = cardHoverColor;
                        ctrl.MouseLeave += (s, e) => passCard.BackColor = primaryBackColor;
                    }
                }


                // Add the fully constructed pass card to the container panel
                containerPanel.Controls.Add(passCard);
                currentYInContainer += passCard.Height + verticalCardSpacing; // Update Y for the next card
            }

            // Adjust container's scrollable area if it's a standard Panel (not a FlowLayoutPanel)
            if (!(containerPanel is FlowLayoutPanel))
            {
                containerPanel.AutoScrollMinSize = new Size(0, currentYInContainer);
            }

            // This line was in the original code. Ensure digitalPassesDiaplayPanel and mainPanel are accessible.
            // If they are class members or static, this is fine. If they were meant to be containerPanel, adjust accordingly.
            // AddCloseButtonToPanel(digitalPassesDiaplayPanel, mainPanel);
        }



        public void AddTransactionToPanel(Panel containerPanel, TravelEaseApp.Helpers.Transaction transaction)
        {
            // --- Design Constants ---
            const int HORIZONTAL_PAGE_PADDING = 15;
            const int VERTICAL_SPACING = 10;
            const int BOX_INTERNAL_PADDING = 12;
            const int MIN_BOX_HEIGHT = 105; // Adjusted slightly
            const int ACCENT_BAR_WIDTH = 5;
            const string HOVER_SENSITIVE_TAG = "HoverSensitiveText"; // Tag for labels whose text color might change on hover

            // --- Colors ---
            Color primaryBackColor = Color.FromArgb(255, 255, 255); // White
            Color hoverColor = Color.FromArgb(247, 250, 255);       // Very Light Blue, almost ethereal
            Color borderColor = Color.FromArgb(228, 231, 235);       // Softer grey border
            Color accentColorSuccess = Color.FromArgb(34, 187, 51);   // Vibrant Green (Success)
            Color accentColorFailed = Color.FromArgb(239, 68, 68);    // Clear Red (Failed)
            Color accentColorPending = Color.FromArgb(245, 158, 11);  // Warm Amber (Pending)
            Color accentColorDefault = Color.FromArgb(107, 114, 128); // Neutral Grey (Default/Unknown)

            Color titleColor = Color.FromArgb(31, 41, 55);          // Darker, more modern grey for main info
            Color textColor = Color.FromArgb(75, 85, 99);           // Medium grey for details
            Color subtleTextColor = Color.FromArgb(107, 114, 128);    // Lighter grey for less prominent text
            Color amountColor = Color.FromArgb(5, 100, 20);         // Darker, rich green for amount (success)
            Color amountNegativeColor = Color.FromArgb(199, 24, 24);  // Softer Reddish for refunds

            Color statusSuccessColor = Color.FromArgb(22, 128, 43);   // Dark Green for text
            Color statusFailedColor = Color.FromArgb(185, 28, 28);    // Dark Red for text
            Color statusPendingColor = Color.FromArgb(192, 117, 5);   // Dark Yellow/Orange for text
            Color textHoverColor = Color.FromArgb(0, 110, 199);       // A distinct blue for text hover, if used

            // --- Fonts ---
            Font idFont = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            Font dateFont = new Font("Segoe UI", 8.25F, FontStyle.Regular);
            Font amountFont = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            Font detailsFont = new Font("Segoe UI", 9F, FontStyle.Regular);
            Font statusFont = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);

            // --- Calculate Box Width ---
            int boxWidth = containerPanel.Width - (2 * HORIZONTAL_PAGE_PADDING);
            if (boxWidth < 320) boxWidth = 320; // Min width for a transaction entry

            // --- Create the main transaction Panel (transactionCardPanel) ---
            Panel transactionCardPanel = new Panel
            {
                Width = boxWidth,
                BackColor = primaryBackColor,
                Padding = new Padding(BOX_INTERNAL_PADDING),
                Margin = new Padding(HORIZONTAL_PAGE_PADDING, 0, HORIZONTAL_PAGE_PADDING, VERTICAL_SPACING)
            };

            // --- Determine Y position for the new card ---
            int yPositionInContainer = VERTICAL_SPACING;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPositionInContainer = lastControl.Bottom + VERTICAL_SPACING;
            }
            transactionCardPanel.Location = new Point(HORIZONTAL_PAGE_PADDING, yPositionInContainer);

            // --- Determine Colors based on Status ---
            Color currentAccentColor;
            Color currentStatusTextColor;
            string statusText = transaction.Status?.ToUpperInvariant() ?? "UNKNOWN";

            switch (transaction.Status?.ToLowerInvariant())
            {
                case "success":
                    currentAccentColor = accentColorSuccess;
                    currentStatusTextColor = statusSuccessColor;
                    break;
                case "failed":
                    currentAccentColor = accentColorFailed;
                    currentStatusTextColor = statusFailedColor;
                    break;
                case "pending":
                    currentAccentColor = accentColorPending;
                    currentStatusTextColor = statusPendingColor;
                    break;
                default:
                    currentAccentColor = accentColorDefault;
                    currentStatusTextColor = titleColor; // Default color for unknown status text
                    statusText = "UNKNOWN";
                    break;
            }

            // --- Paint event for border and left accent bar ---
            transactionCardPanel.Paint += (s, e) =>
            {
                // Draw a softer, rounded border (if possible, or just a thin line)
                // Standard ControlPaint.DrawBorder doesn't support rounded corners easily.
                // For perfect rounded corners, you'd need a custom panel or more complex GDI+ drawing.
                // Here, we'll stick to a simple border.
                ControlPaint.DrawBorder(e.Graphics, transactionCardPanel.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid, // Left
                    borderColor, 1, ButtonBorderStyle.Solid, // Top
                    borderColor, 1, ButtonBorderStyle.Solid, // Right
                    borderColor, 1, ButtonBorderStyle.Solid); // Bottom

                // Draw the accent bar
                using (SolidBrush accentBrush = new SolidBrush(currentAccentColor))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, ACCENT_BAR_WIDTH, transactionCardPanel.Height);
                }
            };

            // --- Initialize Layout Variables ---
            int currentY = BOX_INTERNAL_PADDING;
            int contentStartX = BOX_INTERNAL_PADDING + ACCENT_BAR_WIDTH + 8; // Start X after accent bar and a little space
            int availableContentWidth = transactionCardPanel.Width - contentStartX - BOX_INTERNAL_PADDING;

            // --- Transaction ID ---
            Label lblTransactionId = new Label
            {
                Text = transaction.TransactionId ?? "N/A",
                Font = idFont,
                ForeColor = titleColor,
                AutoSize = false,
                Width = availableContentWidth - 100, // Allow space for status
                Height = idFont.Height + 3,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true,
                Tag = HOVER_SENSITIVE_TAG
            };
            transactionCardPanel.Controls.Add(lblTransactionId);

            // --- Transaction Status (Right Aligned) ---
            Label lblStatus = new Label
            {
                Text = statusText,
                Font = statusFont,
                ForeColor = currentStatusTextColor,
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = false,
                Width = 90, // Fixed width for status
                Height = statusFont.Height + 3,
                Tag = HOVER_SENSITIVE_TAG
            };
            lblStatus.Location = new Point(transactionCardPanel.Width - BOX_INTERNAL_PADDING - lblStatus.Width, currentY + ((lblTransactionId.Height - lblStatus.Height) / 2)); // Align with ID
            transactionCardPanel.Controls.Add(lblStatus);

            currentY += Math.Max(lblTransactionId.Height, lblStatus.Height) + 6; // Increased spacing

            // --- Transaction Date ---
            Label lblTransactionDate = new Label
            {
                Text = $"Date: {transaction.TransactionDate:MMM dd, yyyy hh:mm tt}",
                Font = dateFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY),
                Tag = HOVER_SENSITIVE_TAG
            };
            transactionCardPanel.Controls.Add(lblTransactionDate);
            currentY += lblTransactionDate.Height + 10; // Increased spacing

            // --- Amount ---
            Label lblAmount = new Label
            {
                Text = transaction.Amount.ToString("C", CultureInfo.CurrentUICulture), // Use CurrentUICulture for currency
                Font = amountFont,
                ForeColor = (transaction.Amount >= 0) ? amountColor : amountNegativeColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY),
                Tag = HOVER_SENSITIVE_TAG
            };
            transactionCardPanel.Controls.Add(lblAmount);

            // --- Payment Method (Right of Amount or below) ---
            string friendlyPaymentMethod = "Unknown";
            if (transaction.GetType().GetMethod("GetFriendlyPaymentMethodName") != null)
            {
                friendlyPaymentMethod = transaction.GetFriendlyPaymentMethodName();
            }
            else if (!string.IsNullOrEmpty(transaction.PaymentMethod))
            {
                // Basic fallback if GetFriendlyPaymentMethodName is not available
                friendlyPaymentMethod = transaction.PaymentMethod.Replace("_", " ");
                if (friendlyPaymentMethod.Length > 0)
                    friendlyPaymentMethod = char.ToUpperInvariant(friendlyPaymentMethod[0]) + friendlyPaymentMethod.Substring(1);
            }


            Label lblPaymentMethod = new Label
            {
                Text = $"Via: {friendlyPaymentMethod}",
                Font = detailsFont,
                ForeColor = textColor,
                AutoSize = true,
                Tag = HOVER_SENSITIVE_TAG,
                TextAlign = ContentAlignment.MiddleRight
            };
            // Position payment method to the right end of the amount line
            lblPaymentMethod.Location = new Point(
                transactionCardPanel.Width - BOX_INTERNAL_PADDING - lblPaymentMethod.PreferredWidth,
                currentY + (lblAmount.Height - lblPaymentMethod.Height) / 2 // Vertically align with amount
            );
            // Ensure it doesn't overlap with amount if amount is too wide
            if (lblPaymentMethod.Left < lblAmount.Right + 10)
            {
                // If overlap, move payment method to next line
                currentY += lblAmount.Height + 5;
                lblPaymentMethod.Location = new Point(contentStartX, currentY);
            }
            transactionCardPanel.Controls.Add(lblPaymentMethod);

            currentY += Math.Max(lblAmount.Height, (lblPaymentMethod.Top == lblAmount.Top ? lblPaymentMethod.Height : lblAmount.Height + 5 + lblPaymentMethod.Height)) + BOX_INTERNAL_PADDING;


            // --- Set final height for the transaction card ---
            transactionCardPanel.Height = Math.Max(MIN_BOX_HEIGHT, currentY);

            // --- Add Hover Effect (Self-Contained) ---
            Dictionary<Control, Color> originalLabelColors = new Dictionary<Control, Color>();

            // Lambda for MouseEnter
            transactionCardPanel.MouseEnter += (s, e) =>
            {
                transactionCardPanel.BackColor = hoverColor;
                foreach (Control c in transactionCardPanel.Controls)
                {
                    if (c is Label lbl && c.Tag?.ToString() == HOVER_SENSITIVE_TAG)
                    {
                        if (!originalLabelColors.ContainsKey(lbl)) // Store original color only once
                        {
                            originalLabelColors[lbl] = lbl.ForeColor;
                        }
                        // Example: Change text color on hover. You can make this more specific.
                        // For now, let's not change label colors to keep it simple,
                        // as textHoverColor might not suit all original label colors.
                        // lbl.ForeColor = textHoverColor;
                    }
                }
            };

            // Lambda for MouseLeave
            transactionCardPanel.MouseLeave += (s, e) =>
            {
                // Check if the mouse is still within the bounds of the control (or its children)
                // This helps prevent flickering if the mouse quickly moves over child elements.
                if (transactionCardPanel.ClientRectangle.Contains(transactionCardPanel.PointToClient(Cursor.Position)))
                    return;

                transactionCardPanel.BackColor = primaryBackColor;
                foreach (var entry in originalLabelColors)
                {
                    entry.Key.ForeColor = entry.Value; // Restore original text color
                }
                originalLabelColors.Clear(); // Clear for next hover sequence
            };

            //// Propagate MouseEnter/Leave to child labels to trigger parent's hover
            //foreach (Control childControl in transactionCardPanel.Controls)
            //{
            //    childControl.MouseEnter += (s, e) => transactionCardPanel.OnMouseEnter(e);
            //    childControl.MouseLeave += (s, e) => transactionCardPanel.OnMouseLeave(e);
            //}


            // --- Add to container ---
            containerPanel.Controls.Add(transactionCardPanel);

            // --- Auto-scroll logic ---
            if (containerPanel.Parent is Form || containerPanel.AutoScroll)
            {
                // Ensure the panel is made visible before trying to scroll to it
                // This is generally good practice, though Add() usually handles visibility.
                transactionCardPanel.Visible = true;
                containerPanel.ScrollControlIntoView(transactionCardPanel);
            }
        }


    }



}
