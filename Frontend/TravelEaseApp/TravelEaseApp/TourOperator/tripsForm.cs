using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

            var service6 = new Service
            {
                ServiceId = "SRV-0006",
                ServiceType = "activity",
                ServiceDescription = "Eiffel Tower Skip-the-line Tour",
                Price = 50.00m,
                ProviderName = "Paris Tours",
                Capacity = 20,
                AverageReview = 4.7
            };

            var service7 = new Service
            {
                ServiceId = "SRV-0007",
                ServiceType = "activity",
                ServiceDescription = "Colosseum and Roman Forum Guided Tour",
                Price = 75.00m,
                ProviderName = "Rome Adventures",
                Capacity = 15,
                AverageReview = 4.8
            };

            services.AddRange(new[] { service1, service2, service3, service4, service5, service6, service7 });

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
                Description = "Tour through iconic European destinations including Paris and Rome. Experience culture, history, and exquisite dining. This trip offers a blend of guided tours and free exploration.",
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
                IncludedServices = new List<Service> { service1, service3, service6, service7 }, // Hotel, Guide, Activities
                RequestedServices = new List<Service>() // Initially empty
            };

            var trip2 = new Trip
            {
                TripId = "TRIP-0002",
                Title = "Asian Metropolis Tour",
                Description = "Experience vibrant Asian cities, starting with the bustling streets of Tokyo. Discover modern architecture, ancient temples, and delicious local cuisine. This is an urban adventure.",
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
                IncludedServices = new List<Service> { service2, service4 }, // Transport, Hotel
                RequestedServices = new List<Service>() // Initially empty
            };

            trips.AddRange(new[] { trip1, trip2 });
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

        private void DisplayTripInPanel(Panel panel, Trip trip)
        {
            panel.Controls.Clear();
            panel.Padding = new Padding(20);
            panel.AutoScroll = true;

            // Add close button
            AddCloseButtonToPanel(panel);

            int currentY = 20;

            // Helper function to add labels
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

            // ========== TRIP INFORMATION SECTION ==========
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

            // ========== VISITED LOCATIONS SECTION ==========
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

            // ========== INCLUDED SERVICES SECTION ==========
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
            }

            // ========== REQUESTED SERVICES SECTION (Optional - uncomment to display) ==========
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
            }
            // =================================================================================
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
    }
}