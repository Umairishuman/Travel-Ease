using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static TravelEaseApp.Helpers; // Assuming Helpers contains Location, Service, Trip classes

namespace TravelEaseApp.TourOperator
{
    public partial class tripsForm : Form
    {
        private Label hiddenLabel;
        private Panel CompleteTripInfoPanel;

        // New controls for service request functionality
        private Panel ServiceRequestPanel;
        private TextBox serviceSearchTextBox;
        private ListBox availableServicesListBox;
        private Button requestServiceConfirmButton;
        private Trip _currentTripForServiceRequest; // To hold the trip for which service is being requested

        List<Service> services = new List<Service>();
        List<Trip> trips = new List<Trip>();
        List<Location> locations = new List<Location>();
        List<TripReview> reviews = new List<TripReview>();
        public tripsForm()
        {
            InitializeComponent();
        }

        private void tripsForm_Load(object sender, EventArgs e)
        {
            InitializeComponents();

            SetSampleData();

            foreach (var trip in trips)
            {
                AddTripBox(availableTripsPanel, trip);
            }
        }

        private void InitializeComponents()
        {
            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0);
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false;
            this.Controls.Add(hiddenLabel);
            this.ActiveControl = hiddenLabel;

            this.Controls.Add(availableTripsPanel);

            CompleteTripInfoPanel = new Panel
            {
                Visible = false,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
            // Note: CompleteTripInfoPanel is added to availableTripsPanel in ShowTripDetails
            // If you want it to overlay the entire form, add it to this.Controls

            // Initialize ServiceRequestPanel
            ServiceRequestPanel = new Panel
            {
                Visible = false,
                BackColor = Color.FromArgb(245, 245, 245), // Light grey background
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true,
                Padding = new Padding(20),
                // Set a reasonable initial size and center it
                Size = new Size(450, 420)
            };
            this.Controls.Add(ServiceRequestPanel); // Add to form controls
            ServiceRequestPanel.Location = new Point(
                (this.ClientSize.Width - ServiceRequestPanel.Width) / 2,
                (this.ClientSize.Height - ServiceRequestPanel.Height) / 2
            );
            // Ensure it stays centered if form resizes (requires handling Resize event or anchoring)
            ServiceRequestPanel.Anchor = AnchorStyles.None;


            // Service Search Text Box
            serviceSearchTextBox = new TextBox
            {
                Location = new Point(20, 50),
                Width = ServiceRequestPanel.Width - 40, // Adjust width for padding
                PlaceholderText = "Search services (e.g., hotel, guide, specific description)",
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5),
                TabIndex = 0
            };
            serviceSearchTextBox.TextChanged += ServiceSearchTextBox_TextChanged;
            ServiceRequestPanel.Controls.Add(serviceSearchTextBox);

            // Available Services ListBox
            availableServicesListBox = new ListBox
            {
                Location = new Point(20, serviceSearchTextBox.Bottom + 15),
                Width = ServiceRequestPanel.Width - 40,
                Height = 220, // Increased height to show more options
                SelectionMode = SelectionMode.One,
                Font = new Font("Segoe UI", 9.5F),
                BorderStyle = BorderStyle.FixedSingle,
                TabIndex = 1
            };
            ServiceRequestPanel.Controls.Add(availableServicesListBox);

            // Request Service Confirmation Button
            requestServiceConfirmButton = new Button
            {
                Text = "Request Selected Service",
                Location = new Point(20, availableServicesListBox.Bottom + 20),
                AutoSize = true,
                Font = new Font("Segoe UI Semibold", 10F),
                BackColor = Color.FromArgb(46, 139, 87), // Sea green
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Padding = new Padding(10, 5, 10, 5),
                Cursor = Cursors.Hand,
                TabIndex = 2
            };
            requestServiceConfirmButton.FlatAppearance.BorderSize = 0;
            requestServiceConfirmButton.Click += RequestServiceConfirmButton_Click;
            ServiceRequestPanel.Controls.Add(requestServiceConfirmButton);

            // Header Label for Service Request Panel
            Label serviceRequestHeader = new Label
            {
                Text = "Request a New Service",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(70, 130, 180), // Steel Blue
                Location = new Point(20, 15),
                AutoSize = true
            };
            ServiceRequestPanel.Controls.Add(serviceRequestHeader);


            // Add a close button for the ServiceRequestPanel
            Button closeServiceRequestButton = new Button
            {
                Text = "×", // 'x' character
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(ServiceRequestPanel.Width - 40, 10),
                Cursor = Cursors.Hand
            };
            closeServiceRequestButton.FlatAppearance.BorderSize = 0;
            closeServiceRequestButton.Click += (s, e) => ServiceRequestPanel.Visible = false;
            ServiceRequestPanel.Controls.Add(closeServiceRequestButton);
            closeServiceRequestButton.BringToFront(); // Ensure it's clickable
        }

        private void SetSampleData()
        {
            // Clear existing data
            services.Clear();
            locations.Clear();
            trips.Clear();

            // Create services
            var service1 = new Service
            {
                ServiceId = "SRV-0001",
                ServiceType = "hotel",
                ServiceDescription = "Luxury 5-star hotel with ocean view and spa",
                Price = 350.00m,
                ProviderName = "Grand Hotels International",
                Capacity = 2,
                AverageReview = 4.8
            };

            var service2 = new Service
            {
                ServiceId = "SRV-0002",
                ServiceType = "transport",
                ServiceDescription = "Premium SUV with professional driver",
                Price = 120.00m,
                ProviderName = "City Transfers Ltd",
                Capacity = 4,
                AverageReview = 4.5
            };

            var service3 = new Service
            {
                ServiceId = "SRV-0003",
                ServiceType = "guide",
                ServiceDescription = "Certified local guide for historical tours",
                Price = 80.00m,
                ProviderName = "Heritage Guides",
                Capacity = 10,
                AverageReview = 4.9
            };

            var service4 = new Service
            {
                ServiceId = "SRV-0004",
                ServiceType = "hotel",
                ServiceDescription = "Boutique city center hotel",
                Price = 220.00m,
                ProviderName = "Urban Stay Hotels",
                Capacity = 2,
                AverageReview = 4.6
            };

            var service5 = new Service
            {
                ServiceId = "SRV-0005",
                ServiceType = "transport",
                ServiceDescription = "Luxury minibus for group transfers",
                Price = 200.00m,
                ProviderName = "Group Travel Solutions",
                Capacity = 12,
                AverageReview = 4.4
            };
            services.AddRange(new[] { service1, service2, service3, service4, service5 });

            // 2. First create and store all locations
            var paris = new Location
            {
                DestId = "EUR-001",
                DestinationName = "Eiffel Tower",
                City = "Paris",
                Region = "Europe",
                Country = "France"
            };

            var tokyo = new Location
            {
                DestId = "ASI-001",
                DestinationName = "Shibuya Crossing",
                City = "Tokyo",
                Region = "Asia",
                Country = "Japan"
            };

            var newYork = new Location
            {
                DestId = "NAM-001",
                DestinationName = "Times Square",
                City = "New York",
                Region = "North America",
                Country = "USA"
            };

            var rome = new Location
            {
                DestId = "EUR-002",
                DestinationName = "Colosseum",
                City = "Rome",
                Region = "Europe",
                Country = "Italy"
            };

            locations.AddRange(new[] { paris, tokyo, newYork, rome });

            // 3. Create trips that reference locations and services
            var trip1 = new Trip
            {
                TripId = "TRIP-0001",
                Title = "European Highlights",
                Description = "Tour through iconic European destinations",
                Capacity = 15,
                DurationDays = 7,
                DurationDisplay = "7 Days, 6 Nights",
                Category = "Cultural",
                Status = "active",
                PricePerPerson = 2500.00m,
                StartLocation = paris,  // Reference to Paris location object
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(37),
                OperatorName = "EuroTours",
                VisitedLocations = new List<Location> { paris, rome },  // References to location objects
                IncludedServices = new List<Service> { service1, service3 },
                RequestedServices = new List<Service> { service5 }
            };

            var trip2 = new Trip
            {
                TripId = "TRIP-0002",
                Title = "Asian Metropolis Tour",
                Description = "Experience vibrant Asian cities",
                Capacity = 12,
                DurationDays = 5,
                DurationDisplay = "5 Days, 4 Nights",
                Category = "Urban",
                Status = "upcoming",
                PricePerPerson = 1800.00m,
                StartLocation = tokyo,  // Reference to Tokyo location object
                StartDate = DateTime.Now.AddDays(45),
                EndDate = DateTime.Now.AddDays(50),
                OperatorName = "Asia Adventures",
                VisitedLocations = new List<Location> { tokyo },  // Reference to location object
                IncludedServices = new List<Service> { service2, service4 }
            };

            trips.AddRange(new[] { trip1, trip2 });

            // 4. Create Trip Reviews
            var review1 = new TripReview(
                reviewId: "TRVW-000001",
                tripId: "TRIP-0001",
                travelerId: "TRVL-001",
                rating: 5,
                description: "Absolutely fantastic trip! Paris and Rome were breathtaking. The hotel was superb and the guide was very knowledgeable.",
                reviewDate: new DateTime(2025, 4, 15),
                flagStatus: "clear"
            );

            var review2 = new TripReview(
                reviewId: "TRVW-000002",
                tripId: "TRIP-0001",
                travelerId: "TRVL-002",
                rating: 4,
                description: "Enjoyed the European Highlights tour. Some parts felt a bit rushed, but overall a great experience. The transport service was excellent.",
                reviewDate: new DateTime(2025, 4, 16),
                flagStatus: "clear"
            );

            var review3 = new TripReview(
                reviewId: "TRVW-000003",
                tripId: "TRIP-0002",
                travelerId: "TRVL-003",
                rating: 5,
                description: "Tokyo was incredible! The hotel was perfect and the city tour guide made everything so easy. Highly recommend this trip.",
                reviewDate: new DateTime(2025, 3, 10),
                flagStatus: "clear"
            );

            var review4 = new TripReview(
                reviewId: "TRVW-000004",
                tripId: "TRIP-0002",
                travelerId: "TRVL-004",
                rating: 3,
                description: "The Asian Metropolis tour was good, but I wish there were more options for dining. The transport was comfortable.",
                reviewDate: new DateTime(2025, 3, 12),
                flagStatus: "flagged" // Example of a flagged review
            );

            var review5 = new TripReview(
                reviewId: "TRVW-000005",
                tripId: "TRIP-0001",
                travelerId: "TRVL-005",
                rating: 5,
                description: "A dream come true! Every detail was handled perfectly, from the luxurious hotel to the insightful tours. Loved every moment.",
                reviewDate: new DateTime(2025, 4, 18),
            flagStatus: "clear"
            );

            reviews.AddRange(new[] { review1, review2, review3, review4, review5 });
        }

        public void AddTripBox(Panel containerPanel, Trip trip)
        {
            // Design Constants
            int horizontalPadding = 0;
            int verticalSpacing = 15;
            int boxInternalPadding = 20;
            int boxWidth = containerPanel.Width - 18;
            int boxHeight = 220; // Slightly taller for new button

            // Colors
            Color primaryBackColor = Color.White;
            Color hoverColor = Color.FromArgb(240, 248, 255);
            Color borderColor = Color.FromArgb(220, 224, 230);
            Color accentColor = GetTripCategoryColor(trip.Category);
            Color titleColor = Color.FromArgb(30, 30, 30);
            Color textColor = Color.FromArgb(80, 80, 80);
            Color priceColor = Color.FromArgb(0, 100, 0);
            Color dateColor = Color.FromArgb(128, 0, 128);

            // Fonts
            Font titleFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Font idFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 9F);
            Font priceFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            Font dateFont = new Font("Segoe UI", 9F, FontStyle.Italic);
            Font buttonFont = new Font("Segoe UI Semibold", 9F);


            // Create the main trip panel
            Panel tripBox = new Panel
            {
                Width = boxWidth,
                Height = boxHeight,
                BackColor = primaryBackColor,
                Padding = new Padding(boxInternalPadding, boxInternalPadding, boxInternalPadding, boxInternalPadding),
                Margin = new Padding(0, 0, 0, verticalSpacing),
                Tag = trip,
                Cursor = Cursors.Hand
            };

            // Position the panel
            int yPosition = verticalSpacing;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPosition = lastControl.Bottom + verticalSpacing;
            }
            tripBox.Location = new Point(horizontalPadding, yPosition);

            // Add border and accent stripe
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

            // Trip ID Badge
            Label lblId = new Label
            {
                Text = trip.TripId,
                Font = idFont,
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(boxInternalPadding + 10, boxInternalPadding)
            };

            // Trip Category
            Label lblCategory = new Label
            {
                Text = trip.Category.ToUpper(),
                Font = idFont,
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(lblId.Right + 15, boxInternalPadding)
            };

            // Title
            Label lblTitle = new Label
            {
                Text = trip.Title,
                Font = titleFont,
                ForeColor = titleColor,
                AutoSize = false,
                Width = tripBox.Width - (boxInternalPadding * 2) - 20,
                Height = 40,
                Location = new Point(boxInternalPadding + 10, lblId.Bottom + 8),
                AutoEllipsis = true
            };

            // Description (shortened)
            Label lblDesc = new Label
            {
                Text = trip.Description.Length > 100 ?
                        trip.Description.Substring(0, 100) + "..." :
                        trip.Description,
                Font = textFont,
                ForeColor = textColor,
                AutoSize = false,
                Width = tripBox.Width - (boxInternalPadding * 2) - 20,
                Height = 40,
                Location = new Point(boxInternalPadding + 10, lblTitle.Bottom + 4),
                AutoEllipsis = true
            };

            // Price
            Label lblPrice = new Label
            {
                Text = $"{trip.PricePerPerson:C} per person",
                Font = priceFont,
                ForeColor = priceColor,
                AutoSize = true,
                Location = new Point(boxInternalPadding + 10, lblDesc.Bottom + 8)
            };

            // Dates
            Label lblDates = new Label
            {
                Text = $"{trip.StartDate:MMM dd} - {trip.EndDate:MMM dd, yyyy}",
                Font = dateFont,
                ForeColor = dateColor,
                AutoSize = true,
                Location = new Point(tripBox.Width - 138, lblDesc.Bottom + 8)
            };

            // Duration
            Label lblDuration = new Label
            {
                Text = trip.DurationDisplay,
                Font = textFont,
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(boxInternalPadding + 10, lblPrice.Bottom + 4)
            };

            // Start Location
            Label lblLocation = new Label
            {
                Text = $"Start: {trip.StartLocation?.ToString() ?? "N/A"}",
                Font = textFont,
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(lblDuration.Left , lblDuration.Bottom + 4)
            };

            // Add Request Service Button
            Button btnRequestService = new Button
            {
                Text = "Request Service",
                Font = buttonFont,
                BackColor = Color.FromArgb(0, 122, 204), // A nice blue
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(120, 30),
                Location = new Point(tripBox.Width - 120 - boxInternalPadding, lblDuration.Bottom - 20), // Position below duration or location
                Tag = trip, // Store the trip object
                Cursor = Cursors.Hand
            };
            btnRequestService.FlatAppearance.BorderSize = 0;
            btnRequestService.Click += BtnRequestService_Click;

            // Add controls to panel
            tripBox.Controls.Add(lblId);
            tripBox.Controls.Add(lblCategory);
            tripBox.Controls.Add(lblTitle);
            tripBox.Controls.Add(lblDesc);
            tripBox.Controls.Add(lblPrice);
            tripBox.Controls.Add(lblDates);
            tripBox.Controls.Add(lblDuration);
            tripBox.Controls.Add(lblLocation);
            tripBox.Controls.Add(btnRequestService); // Add the new button

            // Hover effect
            tripBox.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
            tripBox.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;
            foreach (Control ctl in tripBox.Controls)
            {
                ctl.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
                ctl.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;
            }

            // Click event to show details
            // Ensure the Request Service button's click is handled separately
            tripBox.Click += (s, e) =>
            {
                // Check if the click originated from the Request Service button
                ShowTripDetails(trip);
            };
            foreach (Control ctl in tripBox.Controls)
            {
                // Prevent the Request Service button from triggering ShowTripDetails
                if (ctl != btnRequestService)
                {
                    ctl.Click += (s, e) => ShowTripDetails(trip);
                }
            }

            // Add to container
            containerPanel.Controls.Add(tripBox);
        }

        private Color GetTripCategoryColor(string category)
        {
            switch (category?.ToLower())
            {
                case "luxury": return Color.FromArgb(184, 134, 11);   // Dark goldenrod
                case "cultural": return Color.FromArgb(34, 139, 34);  // Forest green
                case "urban": return Color.FromArgb(70, 130, 180);    // Steel blue
                case "adventure": return Color.FromArgb(138, 43, 226); // Blue violet
                default: return Color.FromArgb(0, 122, 204);          // Default blue
            }
        }

        private void ShowTripDetails(Trip trip)
        {
            if (CompleteTripInfoPanel.Visible == false)
            {
                // Add CompleteTripInfoPanel to the current form controls if not already
                // This ensures it overlays the whole form, not just availableTripsPanel
                if (!this.Controls.Contains(CompleteTripInfoPanel))
                {
                    this.Controls.Add(CompleteTripInfoPanel);
                }

                CompleteTripInfoPanel.BringToFront();
                CompleteTripInfoPanel.Visible = true;
                // Set size and location relative to the main form
                CompleteTripInfoPanel.Size = new Size(this.ClientSize.Width - 80, this.ClientSize.Height - 80);
                CompleteTripInfoPanel.Location = new Point(40, 40);
            }

            DisplayTripInPanel(CompleteTripInfoPanel, trip);
        }

        // The existing DisplayTripInPanel method, updated to call DisplayTripReviewInPanel
        private void DisplayTripInPanel(Panel panel, Trip trip)
        {
            panel.Controls.Clear();
            panel.Padding = new Padding(20);
            panel.AutoScroll = true;

            // Add close button
            AddCloseButtonToPanel(panel);

            int currentY = 20;

            // Helper function to add labels (remains the same)
            Label AddLabel(string text, Font font, Color color, int y, int width, bool isMultiline = true)
            {
                var label = new Label
                {
                    Text = text,
                    Font = font,
                    ForeColor = color,
                    Location = new Point(20, y),
                    Width = width,
                    AutoSize = isMultiline,
                    MaximumSize = new Size(width, 0)
                };
                panel.Controls.Add(label);
                return label;
            }

            // ========== TRIP INFORMATION SECTION (existing code) ==========
            var tripHeader = AddLabel(
                "TRIP DETAILS",
                new Font("Segoe UI", 14, FontStyle.Bold),
                GetTripCategoryColor(trip.Category),
                currentY,
                panel.Width - 60);
            currentY += tripHeader.Height + 15;

            // Trip ID
            var idLabel = AddLabel(
                $"Trip ID: {trip.TripId}",
                new Font("Segoe UI", 10),
                Color.DimGray,
                currentY,
                panel.Width - 60);
            currentY += idLabel.Height + 10;

            // Title
            var titleLabel = AddLabel(
                trip.Title,
                new Font("Segoe UI", 12, FontStyle.Bold),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += titleLabel.Height + 10;

            // Category and Status
            var statusLabel = AddLabel(
                $"{trip.Category} | {trip.Status}",
                new Font("Segoe UI", 10),
                GetTripCategoryColor(trip.Category),
                currentY,
                panel.Width - 60);
            currentY += statusLabel.Height + 15;

            // Description
            var descLabel = AddLabel(
                trip.Description,
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += descLabel.Height + 20;

            // Divider
            panel.Controls.Add(new Panel
            {
                BackColor = Color.LightGray,
                Height = 1,
                Width = panel.Width - 60,
                Location = new Point(20, currentY)
            });
            currentY += 20;

            // Price
            var priceLabel = AddLabel(
                $"Price: {trip.PricePerPerson:C} per person",
                new Font("Segoe UI", 12, FontStyle.Bold),
                Color.FromArgb(0, 100, 0),
                currentY,
                panel.Width - 60);
            currentY += priceLabel.Height + 10;

            // Dates
            var datesLabel = AddLabel(
                $"Dates: {trip.StartDate:MMMM d, yyyy} to {trip.EndDate:MMMM d, yyyy}",
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += datesLabel.Height + 10;

            // Duration
            var durationLabel = AddLabel(
                $"Duration: {trip.DurationDisplay}",
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += durationLabel.Height + 10;

            // Start Location
            var locationLabel = AddLabel(
                $"Start Location: {trip.StartLocation?.ToString() ?? "Not specified"}",
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += locationLabel.Height + 15;

            // Operator
            var operatorLabel = AddLabel(
                $"Operator: {trip.OperatorName}",
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += operatorLabel.Height + 20;

            // ========== VISITED LOCATIONS SECTION (existing code) ==========
            if (trip.VisitedLocations != null && trip.VisitedLocations.Count > 0)
            {
                panel.Controls.Add(new Panel
                {
                    BackColor = Color.LightGray,
                    Height = 1,
                    Width = panel.Width - 60,
                    Location = new Point(20, currentY)
                });
                currentY += 20;

                var locationsHeader = AddLabel(
                    "ITINERARY",
                    new Font("Segoe UI", 12, FontStyle.Bold),
                    GetTripCategoryColor(trip.Category),
                    currentY,
                    panel.Width - 60);
                currentY += locationsHeader.Height + 10;

                foreach (var location in trip.VisitedLocations)
                {
                    var locLabel = AddLabel(
                        $"• {location.ToString()}",
                        new Font("Segoe UI", 10),
                        Color.Black,
                        currentY,
                        panel.Width - 80);
                    currentY += locLabel.Height + 5;
                }
                currentY += 10;
            }

            // ========== INCLUDED SERVICES SECTION (existing code) ==========
            if (trip.IncludedServices != null && trip.IncludedServices.Count > 0)
            {
                panel.Controls.Add(new Panel
                {
                    BackColor = Color.LightGray,
                    Height = 1,
                    Width = panel.Width - 60,
                    Location = new Point(20, currentY)
                });
                currentY += 20;

                var servicesHeader = AddLabel(
                    "INCLUDED SERVICES",
                    new Font("Segoe UI", 12, FontStyle.Bold),
                    GetTripCategoryColor(trip.Category),
                    currentY,
                    panel.Width - 60);
                currentY += servicesHeader.Height + 10;

                foreach (var service in trip.IncludedServices)
                {
                    var serviceLabel = AddLabel(
                        $"• {service.ServiceType.ToUpper()}: {service.ServiceDescription} (Provider: {service.ProviderName}, Price: {service.Price:C})",
                        new Font("Segoe UI", 10),
                        Color.Black,
                        currentY,
                        panel.Width - 80);
                    currentY += serviceLabel.Height + 5;
                }
                currentY += 10; // Add space after last service
            }

            // ========== REQUESTED SERVICES SECTION (Optional - existing code) ==========
            if (trip.RequestedServices != null && trip.RequestedServices.Count > 0)
            {
                panel.Controls.Add(new Panel
                {
                    BackColor = Color.LightGray,
                    Height = 1,
                    Width = panel.Width - 60,
                    Location = new Point(20, currentY)
                });
                currentY += 20;

                var requestedServicesHeader = AddLabel(
                    "REQUESTED SERVICES",
                    new Font("Segoe UI", 12, FontStyle.Bold),
                    Color.Coral, // A distinct color for requested services
                    currentY,
                    panel.Width - 60);
                currentY += requestedServicesHeader.Height + 10;

                foreach (var service in trip.RequestedServices)
                {
                    var serviceLabel = AddLabel(
                        $"• {service.ServiceType.ToUpper()}: {service.ServiceDescription} (Provider: {service.ProviderName}, Price: {service.Price:C}) - PENDING",
                        new Font("Segoe UI", 10),
                        Color.DarkOrange,
                        currentY,
                        panel.Width - 80);
                    currentY += serviceLabel.Height + 5;
                }
                currentY += 10; // Add space after last requested service
            }

            // ========== TRIP REVIEWS SECTION (NEW) ==========
            // Call the new function to display reviews in their own scrollable panel
            foreach (var review in reviews)
            {
                if (review.TripId == trip.TripId)
                {
                    DisplayTripReviewInPanel(panel, review, true);
                }
            }

            // Adjust the panel's AutoScrollMinSize to ensure all content is scrollable
            // Make sure to account for the height of the new reviewsContainerPanel
            panel.AutoScrollMinSize = new Size(0, currentY + 20); // Add some buffer at the end
        }

        private void AddCloseButtonToPanel(Panel panel)
        {
            Button closeButton = new Button
            {
                Text = "×",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.Gray,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(30, 30),
                Location = new Point(panel.Width - 50, 10),
                Cursor = Cursors.Hand
            };

            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.Click += (s, e) =>
            {
                panel.Visible = false;
                // If you added it to this.Controls, you might want to send it to back
                // to allow other controls to be interacted with if it's not hidden.
                // However, setting Visible = false is usually sufficient.
            };

            panel.Controls.Add(closeButton);
            closeButton.BringToFront();
        }

        // Event handler for the "Request Service" button on each trip box
        private void BtnRequestService_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                Trip trip = clickedButton.Tag as Trip;
                if (trip != null)
                {
                    _currentTripForServiceRequest = trip; // Store the current trip
                    ServiceRequestPanel.Visible = true;
                    ServiceRequestPanel.BringToFront(); // Bring it to the front of the form
                    PopulateAvailableServicesListBox(trip, ""); // Populate with all non-included services initially
                    serviceSearchTextBox.Text = ""; // Clear search box
                    serviceSearchTextBox.Focus(); // Focus the search box
                }
            }
        }

        // Event handler for the search text box
        private void ServiceSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            PopulateAvailableServicesListBox(_currentTripForServiceRequest, serviceSearchTextBox.Text);
        }

        // Helper method to populate the listbox with services not already included in the trip
        private void PopulateAvailableServicesListBox(Trip trip, string searchText)
        {
            availableServicesListBox.Items.Clear();

            // Filter services not already included in the trip
            // Also ensure not already in requested services to prevent requesting same thing multiple times
            var nonIncludedOrRequestedServices = services.Where(s =>
                !trip.IncludedServices.Any(incS => incS.ServiceId == s.ServiceId) &&
                !trip.RequestedServices.Any(reqS => reqS.ServiceId == s.ServiceId)
            ).ToList();

            // Further filter by search text
            var filteredServices = nonIncludedOrRequestedServices.Where(s =>
                string.IsNullOrEmpty(searchText) ||
                s.ServiceType.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                s.ServiceDescription.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                s.ProviderName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            // Add to listbox, store Service object in Tag for easy retrieval
            foreach (var service in filteredServices)
            {
                // Display format for the listbox item
                string display = $"{service.ServiceType.ToUpper()} - {service.ServiceDescription} (Provider: {service.ProviderName}, Price: {service.Price:C})";
                availableServicesListBox.Items.Add(new ListBoxItem { Text = display, Value = service });
            }
        }

        // Event handler for the "Request Selected Service" button in the request panel
        private void RequestServiceConfirmButton_Click(object sender, EventArgs e)
        {
            if (availableServicesListBox.SelectedItem != null)
            {
                ListBoxItem selectedItem = availableServicesListBox.SelectedItem as ListBoxItem;
                if (selectedItem != null)
                {
                    Service selectedService = selectedItem.Value as Service;
                    if (selectedService != null && _currentTripForServiceRequest != null)
                    {
                        // Add the selected service to the trip's RequestedServices
                        // The filtering in PopulateAvailableServicesListBox already ensures it's not in IncludedServices
                        // We re-check RequestedServices here just for robustness, though it should already be excluded.
                        if (!_currentTripForServiceRequest.RequestedServices.Any(rs => rs.ServiceId == selectedService.ServiceId))
                        {
                            _currentTripForServiceRequest.RequestedServices.Add(selectedService);
                            MessageBox.Show($"Service '{selectedService.ServiceDescription}' requested for trip '{_currentTripForServiceRequest.Title}'.", "Service Requested", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("This service has already been requested for this trip or is already included.", "Duplicate Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        ServiceRequestPanel.Visible = false; // Hide the panel after request

                        // Optional: Refresh the trip details if displayed (e.g., in CompleteTripInfoPanel)
                        // Uncomment the following lines if you want the details panel to reflect the change immediately
                        if (CompleteTripInfoPanel.Visible && CompleteTripInfoPanel.Tag == _currentTripForServiceRequest)
                        {
                            DisplayTripInPanel(CompleteTripInfoPanel, _currentTripForServiceRequest);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a service to request.", "No Service Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void DisplayTripReviewInPanel(
            Panel containerPanel,
            TripReview review,
            bool isPublicView,
            string travelerName = "Anonymous Traveler",
            string travelerProfilePicUrl = "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg"
        )
        {
            if (containerPanel == null) throw new ArgumentNullException(nameof(containerPanel));
            if (review == null) throw new ArgumentNullException(nameof(review));

            // --- Design Constants ---
            int horizontalPagePadding = 20;
            int verticalCardSpacing = 15;
            int cardInternalPadding = 15;
            int cardAccentBarWidth = 6;
            int profilePicSize = isPublicView ? 50 : 0;

            int cardWidth = containerPanel.ClientSize.Width - (2 * horizontalPagePadding);
            if (cardWidth < (isPublicView ? 350 : 400)) cardWidth = (isPublicView ? 350 : 400); // Min width
            int cardMinHeight = isPublicView ? 100 : 150; // Min height

            // --- Colors ---
            Color primaryBackColor = Color.FromArgb(255, 255, 255); // White
            Color cardHoverColor = Color.FromArgb(247, 249, 252);   // Very light blue for hover
            Color cardBorderColor = Color.FromArgb(220, 224, 230);  // Light grey border
            Color nameColor = Color.FromArgb(25, 25, 25);           // Dark grey for name
            Color dateColor = Color.FromArgb(110, 110, 110);        // Medium grey for date
            Color descriptionColor = Color.FromArgb(45, 45, 45);    // Dark grey for description
            Color starColor = Color.FromArgb(255, 180, 0);          // Gold/Yellow for stars
            Color adminTextColor = Color.FromArgb(70, 70, 70);      // Text color for admin details
            Color adminLabelColor = Color.FromArgb(90, 90, 90);     // Label color for admin fields

            Color flagClearColor = Color.FromArgb(30, 150, 75);     // Softer Green
            Color flagFlaggedColor = Color.FromArgb(210, 60, 75);   // Softer Red
            Color buttonFlagColor = Color.FromArgb(0, 123, 255);    // Blue for "Flag"
            Color buttonUnflagColor = Color.FromArgb(255, 120, 0);  // Orange for "Unflag"

            // --- Fonts ---
            Font nameFont = new Font("Segoe UI Semibold", 11F);
            Font dateFont = new Font("Segoe UI", 8.5F);
            Font descriptionFont = new Font("Segoe UI", 9.5F);
            Font starFont = new Font("Segoe UI Symbol", 12F); // Ensure this font supports stars
            Font adminTextFont = new Font("Segoe UI", 9F);
            Font adminLabelFont = new Font("Segoe UI Semibold", 9F);
            Font buttonFont = new Font("Segoe UI Semibold", 9F);

            // --- Create the Review Card Panel ---
            Panel reviewCard = new Panel
            {
                Width = cardWidth,
                BackColor = primaryBackColor,
                Padding = new Padding(cardInternalPadding),
                Margin = new Padding(0, 0, 0, 0) // Location set manually
            };

            // Position the new card below the last control in the container panel
            int yPositionInContainer = verticalCardSpacing;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPositionInContainer = lastControl.Bottom + verticalCardSpacing;
            }
            reviewCard.Location = new Point(horizontalPagePadding, yPositionInContainer);

            // Determine accent color based on view type and flag status
            Color currentAccentColor = isPublicView ? Color.FromArgb(200, 200, 200) : (review.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor);

            reviewCard.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, reviewCard.ClientRectangle,
                    cardBorderColor, 1, ButtonBorderStyle.Solid, cardBorderColor, 1, ButtonBorderStyle.Solid,
                    cardBorderColor, 1, ButtonBorderStyle.Solid, cardBorderColor, 1, ButtonBorderStyle.Solid);

                using (SolidBrush accentBrush = new SolidBrush(currentAccentColor))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, cardAccentBarWidth, reviewCard.Height);
                }
            };

            int currentY = cardInternalPadding; // Y-position inside the review card
                                                // Calculate start X for content, accounting for profile pic in public view
            int contentStartX = cardInternalPadding + cardAccentBarWidth + (isPublicView ? profilePicSize + cardInternalPadding : 0);
            int contentWidth = reviewCard.Width - contentStartX - cardInternalPadding;
            if (contentWidth < 150) contentWidth = 150; // Prevent content area from being too narrow

            // --- Profile Picture (Public View Only) ---
            if (isPublicView)
            {
                PictureBox picProfile = new PictureBox
                {
                    Width = profilePicSize,
                    Height = profilePicSize,
                    Location = new Point(cardInternalPadding + cardAccentBarWidth, cardInternalPadding),
                    SizeMode = PictureBoxSizeMode.StretchImage, // Changed to StretchImage for potentially non-square images
                    BackColor = Color.FromArgb(230, 230, 230)
                };
                // Simple rounded effect for PictureBox
                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, picProfile.Width, picProfile.Height);
                picProfile.Region = new Region(path);

                try
                {
                    if (!string.IsNullOrWhiteSpace(travelerProfilePicUrl) && Uri.IsWellFormedUriString(travelerProfilePicUrl, UriKind.Absolute))
                    {
                        picProfile.LoadAsync(travelerProfilePicUrl);
                    }
                    else // Load default placeholder if URL is invalid
                    {
                        picProfile.Image = CreatePlaceholderImage("👤", new Font("Segoe UI Symbol", profilePicSize * 0.5f), picProfile.Size, picProfile.BackColor, Color.Gray);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading profile image: " + ex.Message);
                    picProfile.Image = CreatePlaceholderImage("!", new Font("Arial", profilePicSize * 0.5f), picProfile.Size, picProfile.BackColor, Color.Red);
                }
                reviewCard.Controls.Add(picProfile);
            }

            // --- Traveler Name (Public View) ---
            if (isPublicView)
            {
                Label lblName = new Label
                {
                    Text = travelerName,
                    Font = nameFont,
                    ForeColor = nameColor,
                    AutoSize = false, // Allow AutoEllipsis
                    Width = contentWidth - 75, // Space for date label on the right
                    Height = nameFont.Height,
                    Location = new Point(contentStartX, currentY),
                    AutoEllipsis = true,
                    Tag = "HoverSensitive"
                };
                reviewCard.Controls.Add(lblName);
            }

            // --- Review Date ---
            Label lblDate = new Label
            {
                Text = review.ReviewDate.ToString("MMM dd, yyyy"), // Format date
                Font = dateFont,
                ForeColor = dateColor,
                AutoSize = true,
                Tag = "HoverSensitive"
            };
            if (isPublicView) // Position date top-right in public view
            {
                lblDate.Location = new Point(reviewCard.Width - cardInternalPadding - lblDate.PreferredWidth - 5, currentY + 2);
            }
            // For admin view, lblDate will be positioned later in the flow.
            reviewCard.Controls.Add(lblDate);

            if (isPublicView)
            {
                currentY += nameFont.Height + 2; // Move Y down after name
            }

            // --- Star Rating ---
            Label lblStars = new Label
            {
                Text = GetStarString(review.Rating),
                Font = starFont,
                ForeColor = starColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY)
            };
            reviewCard.Controls.Add(lblStars);
            currentY += lblStars.Height + 6;

            // --- Admin View: IDs (Review ID, Trip ID, Traveler ID) ---
            if (!isPublicView)
            {
                Func<string, string, int, Label> AddAdminDetail = (labelText, valueText, yPos) =>
                {
                    Label lbl = new Label
                    {
                        Text = $"{labelText}: {valueText}",
                        Font = adminTextFont,
                        ForeColor = adminTextColor,
                        AutoSize = true,
                        Location = new Point(contentStartX, yPos),
                        Tag = "HoverSensitive"
                    };
                    reviewCard.Controls.Add(lbl);
                    return lbl;
                };

                Label lastAdminDetail;
                lastAdminDetail = AddAdminDetail("Review ID", review.ReviewId, currentY);
                currentY = lastAdminDetail.Bottom + 3;
                lastAdminDetail = AddAdminDetail("Trip ID", review.TripId, currentY);
                currentY = lastAdminDetail.Bottom + 3;
                lastAdminDetail = AddAdminDetail("Traveler ID", review.TravelerId, currentY);
                currentY = lastAdminDetail.Bottom + 3;

                // Position Date for Admin View (after IDs, before description)
                lblDate.Location = new Point(contentStartX, currentY);
                currentY = lblDate.Bottom + 8;
            }

            // --- Review Description ---
            Label lblDescription = new Label
            {
                Text = review.Description,
                Font = descriptionFont,
                ForeColor = descriptionColor,
                AutoSize = false, // Important for multi-line and fixed width
                Width = contentWidth,
                Location = new Point(contentStartX, currentY),
                MaximumSize = new Size(contentWidth, 0), // Width is fixed, height is dynamic
                Tag = "HoverSensitive"
            };
            // Calculate height needed for the description text
            Size descSize = TextRenderer.MeasureText(review.Description, descriptionFont,
                                                     new Size(contentWidth, int.MaxValue),
                                                     TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
            lblDescription.Height = descSize.Height + 5; // Add a little padding
            reviewCard.Controls.Add(lblDescription);
            currentY += lblDescription.Height + 10;

            // --- Admin View: Flag Status and Action Button ---
            if (!isPublicView)
            {
                Label lblFlagStatus = new Label
                {
                    Text = $"Status: {review.FlagStatus.ToUpper()}",
                    Font = adminLabelFont,
                    ForeColor = review.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor,
                    AutoSize = true,
                    Location = new Point(contentStartX, currentY)
                };
                reviewCard.Controls.Add(lblFlagStatus);

                Button btnToggleFlag = new Button
                {
                    Text = review.FlagStatus == "clear" ? "Flag Review" : "Unflag Review",
                    Font = buttonFont,
                    ForeColor = Color.White,
                    BackColor = review.FlagStatus == "clear" ? buttonFlagColor : buttonUnflagColor,
                    Width = 120,
                    Height = 30,
                    FlatStyle = FlatStyle.Flat,
                    // Position button to the right of the status label or aligned right on the card
                    Location = new Point(reviewCard.Width - cardInternalPadding - 120, lblFlagStatus.Top - (30 - lblFlagStatus.Height) / 2),
                    Tag = review // Store the review object for easy access in the event handler
                };
                btnToggleFlag.FlatAppearance.BorderSize = 0;
                btnToggleFlag.Click += (s, e) =>
                {
                    Button clickedButton = s as Button;
                    TripReview targetReview = clickedButton?.Tag as TripReview;
                    if (targetReview != null)
                    {
                        // Simulate toggling flag status (in a real app, update backend)
                        targetReview.FlagStatus = (targetReview.FlagStatus == "clear" ? "flagged" : "clear");

                        // Update UI elements to reflect the change
                        lblFlagStatus.Text = $"Status: {targetReview.FlagStatus.ToUpper()}";
                        lblFlagStatus.ForeColor = targetReview.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor;
                        clickedButton.Text = targetReview.FlagStatus == "clear" ? "Flag Review" : "Unflag Review";
                        clickedButton.BackColor = targetReview.FlagStatus == "clear" ? buttonFlagColor : buttonUnflagColor;

                        // Update accent bar color and repaint the card
                        currentAccentColor = targetReview.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor;
                        reviewCard.Invalidate(); // Forces the Paint event to re-run

                        MessageBox.Show($"Review '{targetReview.ReviewId}' status changed to '{targetReview.FlagStatus}'.\n(This change is local; backend update needed in a real app.)",
                                        "Flag Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                };
                reviewCard.Controls.Add(btnToggleFlag);
                currentY = Math.Max(lblFlagStatus.Bottom, btnToggleFlag.Bottom) + 10; // Ensure Y is below the taller of the two
            }

            // Set final height for the review card, ensuring it's at least minHeight
            reviewCard.Height = Math.Max(cardMinHeight, currentY + cardInternalPadding - 10); // Final adjustment for bottom padding

            // --- Add Hover Effect ---
            // Use a distinct hover forecolor if needed, or keep it same as original text color
            AddHoverTransition(reviewCard, primaryBackColor, cardHoverColor, descriptionColor, descriptionColor);

            // --- Add to container ---
            containerPanel.Controls.Add(reviewCard);
            // Scroll the new card into view if the container panel is on a top-level form
            if (containerPanel.Parent is Form || containerPanel.Parent?.Parent is Form)
            {
                containerPanel.ScrollControlIntoView(reviewCard);
            }
            else // For nested panels, check if the immediate container is scrollable
            {
                if (containerPanel.VerticalScroll.Visible)
                {
                    containerPanel.ScrollControlIntoView(reviewCard);
                }
            }
        }

        private string GetStarString(int rating)
        {
            if (rating < 0) rating = 0;
            if (rating > 5) rating = 5;
            return new string('⭐', rating) + new string('☆', 5 - rating);
        }


        private Image CreatePlaceholderImage(string text, Font font, Size size, Color backColor, Color foreColor)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            using (Brush backBrush = new SolidBrush(backColor))
            using (Brush foreBrush = new SolidBrush(foreColor))
            {
                g.FillRectangle(backBrush, 0, 0, size.Width, size.Height);
                g.DrawString(text, font, foreBrush, new RectangleF(0, 0, size.Width, size.Height), sf);
            }
            return bmp;
        }
    }
}