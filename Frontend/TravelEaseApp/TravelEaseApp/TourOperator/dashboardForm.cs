using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TravelEaseApp.Helpers;

namespace TravelEaseApp.TourOperator
{
    public partial class dashboardForm : Form
    {
        private Label hiddenLabel;
        private Panel CompleteServiceInfoPanel;

        List<Service> services = new List<Service>();
        List<Trip> trips = new List<Trip>();
        List<Location> locations = new List<Location>();

        int TourOperatorId;

        public dashboardForm()
        {
            InitializeComponent();
        }

        private void InitializeComponents()
        {
            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0);
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false;
            this.Controls.Add(hiddenLabel);
            this.ActiveControl = hiddenLabel;

            this.Controls.Add(availableServicesPanel);

            CompleteServiceInfoPanel = new Panel
            {
                Visible = false,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
        }

        private void dashboardForm_Load(object sender, EventArgs e)
        {
            InitializeComponents();

            // ProfilePicture
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, profilePictureBox.Width, profilePictureBox.Height);
            profilePictureBox.Region = new Region(path);

            AddHoverTransition(addTripLabel, addTripLabel.BackColor, addTripLabel.ForeColor, addTripLabel.ForeColor, addTripLabel.BackColor);

            Color borderColor = Color.FromArgb(220, 224, 230);
            infoPanel1.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, infoPanel1.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };
            infoPanel2.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, infoPanel2.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };

            topStatPanel1.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, topStatPanel1.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };

            topStatPanel2.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, topStatPanel2.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };

            topStatPanel3.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, topStatPanel3.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };

            SetSampleData();
            foreach (var service in services)
            {
                AddServiceBox(availableServicesPanel, service);
            }

            // Top Stats
            // topStatLabelNumber1 = total number of trips with tourOperatorId = tourOperatorId
            // topStatLabelNumber2 = total number of trips with tourOperatorId = tourOperatorId and status = "active"
            // topStatLabelNumber3 = avg rating of all trips with tourOperatorId = tourOperatorId
            topStatLabelNumber1.Text = trips.Count.ToString();
            topStatLabelNumber2.Text = trips.Count(t => t.Status == "active").ToString();

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
        }

        public void AddServiceBox(Panel containerPanel, Service service)
        {
            // Design Constants
            int horizontalPadding = 0;
            int verticalSpacing = 15;
            int boxInternalPadding = 15;
            int boxWidth = containerPanel.Width - 18;
            int boxHeight = 150;

            // Colors
            Color primaryBackColor = Color.White;
            Color hoverColor = Color.FromArgb(240, 248, 255);
            Color borderColor = Color.FromArgb(220, 224, 230);
            Color accentColor = GetServiceTypeColor(service.ServiceType);
            Color titleColor = Color.FromArgb(30, 30, 30);
            Color textColor = Color.FromArgb(80, 80, 80);
            Color priceColor = Color.FromArgb(0, 100, 0);
            Color ratingColor = Color.FromArgb(255, 153, 0);

            // Fonts
            Font titleFont = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            Font typeFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Font textFont = new Font("Segoe UI", 9F);
            Font priceFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            Font ratingFont = new Font("Segoe UI", 9F);

            // Create the main service panel
            Panel serviceBox = new Panel
            {
                Width = boxWidth,
                Height = boxHeight,
                BackColor = primaryBackColor,
                Padding = new Padding(boxInternalPadding),
                Margin = new Padding(0, 0, 0, verticalSpacing),
                Tag = service,
                Cursor = Cursors.Hand
            };

            // Position the panel
            int yPosition = verticalSpacing;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPosition = lastControl.Bottom + verticalSpacing;
            }
            serviceBox.Location = new Point(horizontalPadding, yPosition);

            // Add border and accent stripe
            serviceBox.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, serviceBox.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);

                using (SolidBrush accentBrush = new SolidBrush(accentColor))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, 6, serviceBox.Height);
                }
            };

            // Service Type Badge
            Label lblType = new Label
            {
                Text = service.ServiceType.ToUpper(),
                Font = typeFont,
                ForeColor = accentColor,
                AutoSize = true,
                Location = new Point(boxInternalPadding + 10, boxInternalPadding)
            };

            // Service ID
            Label lblId = new Label
            {
                Text = $"ID: {service.ServiceId}",
                Font = textFont,
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(lblType.Right + 15, boxInternalPadding + 3)
            };

            // Title/Description
            Label lblTitle = new Label
            {
                Text = service.ServiceDescription,
                Font = titleFont,
                ForeColor = titleColor,
                AutoSize = false,
                Width = serviceBox.Width - (boxInternalPadding * 2) - 20,
                Height = 40,
                Location = new Point(boxInternalPadding + 10, lblType.Bottom + 8),
                AutoEllipsis = true
            };

            // Price
            Label lblPrice = new Label
            {
                Text = $"{service.Price:C} per person",
                Font = priceFont,
                ForeColor = priceColor,
                AutoSize = true,
                Location = new Point(boxInternalPadding + 10, lblTitle.Bottom + 8)
            };

            // Provider
            Label lblProvider = new Label
            {
                Text = $"Provider: {service.ProviderName}",
                Font = textFont,
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(boxInternalPadding + 10, lblPrice.Bottom + 4)
            };

            // Capacity
            Label lblCapacity = new Label
            {
                Text = $"Capacity: {service.Capacity} people",
                Font = textFont,
                ForeColor = textColor,
                AutoSize = true,
                Location = new Point(serviceBox.Width - 150, lblPrice.Bottom + 4)
            };

            // Rating (stars)
            Label lblRating = new Label
            {
                Text = $"{new string('★', (int)service.AverageReview)}{new string('☆', 5 - (int)service.AverageReview)}",
                Font = ratingFont,
                ForeColor = ratingColor,
                AutoSize = true,
                Location = new Point(serviceBox.Width - 100, lblTitle.Bottom + 8)
            };

            // Add controls to panel
            serviceBox.Controls.Add(lblType);
            serviceBox.Controls.Add(lblId);
            serviceBox.Controls.Add(lblTitle);
            serviceBox.Controls.Add(lblPrice);
            serviceBox.Controls.Add(lblProvider);
            serviceBox.Controls.Add(lblCapacity);
            serviceBox.Controls.Add(lblRating);

            // Hover effect
            serviceBox.MouseEnter += (s, e) => serviceBox.BackColor = hoverColor;
            serviceBox.MouseLeave += (s, e) => serviceBox.BackColor = primaryBackColor;
            foreach (Control ctl in serviceBox.Controls)
            {
                ctl.MouseEnter += (s, e) => serviceBox.BackColor = hoverColor;
                ctl.MouseLeave += (s, e) => serviceBox.BackColor = primaryBackColor;
            }

            // Click event to show details
            serviceBox.Click += (s, e) => ShowServiceDetails(service);
            foreach (Control ctl in serviceBox.Controls)
            {
                ctl.Click += (s, e) => ShowServiceDetails(service);
            }

            // Add to container
            containerPanel.Controls.Add(serviceBox);
        }
        private Color GetServiceTypeColor(string serviceType)
        {
            switch (serviceType.ToLower())
            {
                case "hotel": return Color.FromArgb(70, 130, 180);   // Steel blue
                case "transport": return Color.FromArgb(34, 139, 34); // Forest green
                case "guide": return Color.FromArgb(184, 134, 11);   // Dark goldenrod
                case "activity": return Color.FromArgb(138, 43, 226); // Blue violet
                default: return Color.FromArgb(0, 122, 204);          // Default blue
            }
        }

        private void ShowServiceDetails(Service service)
        {
            if (CompleteServiceInfoPanel.Visible == false)
            {
                availableServicesPanel.Controls.Add(CompleteServiceInfoPanel);
                CompleteServiceInfoPanel.BringToFront();
                CompleteServiceInfoPanel.Visible = true;
                CompleteServiceInfoPanel.Size = new Size(availableServicesPanel.Width - 40, availableServicesPanel.Height - 40);
                CompleteServiceInfoPanel.Location = new Point(20, 20);
            }

            DisplayServiceInPanel(CompleteServiceInfoPanel, service);
        }

        private void DisplayServiceInPanel(Panel panel, Service service)
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

            // ========== SERVICE INFORMATION SECTION ==========
            var serviceHeader = AddLabel(
                "SERVICE DETAILS",
                new Font("Segoe UI", 14, FontStyle.Bold),
                GetServiceTypeColor(service.ServiceType),
                currentY,
                panel.Width - 60);
            currentY += serviceHeader.Height + 15;

            // Service Type
            var typeLabel = AddLabel(
                $"Type: {service.ServiceType.ToUpper()}",
                new Font("Segoe UI", 11),
                GetServiceTypeColor(service.ServiceType),
                currentY,
                panel.Width - 60);
            currentY += typeLabel.Height + 10;

            // Service ID
            var idLabel = AddLabel(
                $"Service ID: {service.ServiceId}",
                new Font("Segoe UI", 10),
                Color.DimGray,
                currentY,
                panel.Width - 60);
            currentY += idLabel.Height + 10;

            // Description
            var descLabel = AddLabel(
                service.ServiceDescription,
                new Font("Segoe UI", 11),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += descLabel.Height + 15;

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
                $"Price: {service.Price:C} per person",
                new Font("Segoe UI", 12, FontStyle.Bold),
                Color.FromArgb(0, 100, 0),
                currentY,
                panel.Width - 60);
            currentY += priceLabel.Height + 10;

            // Provider
            var providerLabel = AddLabel(
                $"Provider: {service.ProviderName}",
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += providerLabel.Height + 10;

            // Capacity
            var capacityLabel = AddLabel(
                $"Capacity: {service.Capacity} people",
                new Font("Segoe UI", 10),
                Color.Black,
                currentY,
                panel.Width - 60);
            currentY += capacityLabel.Height + 10;

            // Rating
            var ratingLabel = AddLabel(
                $"Rating: {service.AverageReview:0.0}/5.0",
                new Font("Segoe UI", 10),
                Color.FromArgb(255, 153, 0),
                currentY,
                panel.Width - 60);
            currentY += ratingLabel.Height + 20;

            // ========== SERVICE-SPECIFIC ATTRIBUTES SECTION ==========
            var attributesTitle = AddLabel(
                "SERVICE ATTRIBUTES",
                new Font("Segoe UI", 11, FontStyle.Bold),
                GetServiceTypeColor(service.ServiceType),
                currentY,
                panel.Width - 60);
            currentY += attributesTitle.Height + 15;

            // Example of service-specific attributes
            switch (service.ServiceType.ToLower())
            {
                case "hotel":
                    AddLabel("Room Type: Deluxe Suite", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Amenities: Pool, Spa, WiFi", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Check-in: 3:00 PM", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Check-out: 11:00 AM", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    break;
                case "transport":
                    AddLabel("Vehicle Type: Premium SUV", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("AC: Yes", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Max Passengers: 4", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Driver Included: Yes", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    break;
                case "guide":
                    AddLabel("Guide Name: John Smith", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Experience: 8 years", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Certification: Licensed", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    currentY += 25;
                    AddLabel("Languages: English, Spanish", new Font("Segoe UI", 10), Color.Black, currentY, panel.Width - 60);
                    break;
                default:
                    AddLabel("No additional attributes available", new Font("Segoe UI", 10), Color.Gray, currentY, panel.Width - 60);
                    break;
            }
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
                panel.SendToBack();
            };

            panel.Controls.Add(closeButton);
            closeButton.BringToFront();
        }

        public event Action RequestAddTripForm;

        private void addTripLabel_Click(object sender, EventArgs e)
        {
            RequestAddTripForm?.Invoke();
        }
    }
}
