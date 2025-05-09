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

namespace TravelEaseApp
{

    public partial class Traveller : Form
    {
        Label hiddenLabel;
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
            Color accentColor = Color.FromArgb(0, 122, 204);
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
                AutoSize = true,
                Padding = new Padding(8, 0, 8, 0)
            };
            Label lblStatusText = new Label
            {
                Text = trip.Status.ToUpper(),
                Font = statusFont,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false
            };
            pnlStatus.Controls.Add(lblStatusText);
            pnlStatus.MinimumSize = new Size(70, 22);

            switch (trip.Status.ToLower())
            {
                case "active":
                    pnlStatus.BackColor = Color.MediumSeaGreen;
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
            pnlStatus.Location = new Point(contentPanel.Width - pnlStatus.Width, 2);

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
            contentPanel.Controls.Add(lblDescription);
            contentPanel.Controls.Add(lblDatesAndLocation);
            contentPanel.Controls.Add(lblDurationCategory);
            contentPanel.Controls.Add(lblCapacity);
            contentPanel.Controls.Add(lblPrice);
            contentPanel.Controls.Add(lblOperator);

            tripBox.Controls.Add(tripImage);
            tripBox.Controls.Add(contentPanel);

            // --- Hover effect ---
            foreach (Control ctl in contentPanel.Controls)
            {
                if (ctl is Label) ctl.BackColor = Color.Transparent;
                ctl.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
                ctl.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;
            }
            tripImage.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
            tripImage.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;

            // --- Add to container ---
            containerPanel.Controls.Add(tripBox);
            containerPanel.ScrollControlIntoView(tripBox);

            EventHandler showTripDetails = (s, e) =>
            {
                if(CompleteTripInfoPanel.Visible == false)
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

        // --- UPDATED Theme and Styling Constants for WHITE BACKGROUND ---
        private static readonly Color PanelBackgroundColor = Color.WhiteSmoke; // Light background
        private static readonly Color TextColor = Color.FromArgb(30, 30, 30);          // Dark text
        private static readonly Color MutedTextColor = Color.FromArgb(80, 80, 80);      // Slightly lighter dark text
        private static readonly Color AccentColor = Color.FromArgb(0, 122, 204);      // Modern Blue for accents/button
        private static readonly Color ButtonTextColor = Color.White;                    // White text for button
        private static readonly Color DividerColor = Color.LightGray;                   // Light grey for dividers

        private static readonly Font TitleFont = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
        private static readonly Font SubtitleFont = new Font("Segoe UI", 12F, FontStyle.Regular);
        private static readonly Font BodyFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        private static readonly Font SectionHeaderFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        private static readonly Font ButtonFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);

        private const int MainPadding = 20;
        private const int ItemSpacing = 8;
        private const int SectionSpacing = 15;

        public void DisplayTripInPanel(Panel targetPanel, Trip trip)
        {

            

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
                    SizeMode = PictureBoxSizeMode.Zoom,
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




    }



}
