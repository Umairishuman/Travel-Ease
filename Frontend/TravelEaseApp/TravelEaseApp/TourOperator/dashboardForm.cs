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
using static TravelEaseApp.Helpers;
using Microsoft.Data.SqlClient;

namespace TravelEaseApp.TourOperator
{
    public partial class dashboardForm : Form
    {
        string regNo;

        private Label hiddenLabel;
        private Panel CompleteServiceInfoPanel;

        List<Service> services = new List<Service>();
        List<Trip> trips = new List<Trip>();
        List<Location> locations = new List<Location>();
        List<TripReview> reviews = new List<TripReview>();

        int TourOperatorId;

        public dashboardForm(string regNo)
        {
            InitializeComponent();
            this.regNo = regNo;
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

            //SetSampleData();
            setData();
            foreach (var service in services)
            {
                AddServiceBox(availableServicesPanel, service);
            }

            // Top Stats
            // topStatLabelNumber1 = total number of trips with tourOperatorId = tourOperatorId
            // topStatLabelNumber2 = total number of trips with tourOperatorId = tourOperatorId and status = "active"
            // topStatLabelNumber3 = avg rating of all trips with tourOperatorId = tourOperatorId

            foreach (var review in reviews)
            {
                DisplayTripReviewInPanel(customerReviewsPanel, review, true);
            }
            topStatLabelNumber1.Text = trips.Count.ToString();
            topStatLabelNumber2.Text = trips.Count(t => t.Status == "active").ToString();

        }

        private void setData()
        {
            {   // get all services
                string query = "SELECT * FROM Services";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            var service = new Service
                            {
                                ServiceId = reader.GetString(0),
                                ServiceType = reader.GetString(1),
                                ServiceDescription = reader.GetString(2),
                                Price = reader.GetDecimal(3),
                                ProviderId = reader.GetString(4), // Fixed: Changed GetInt32 to GetString
                                Capacity = reader.GetInt32(5)
                            };
                            services.Add(service);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw; // Re-throw to handle in calling code
                    }
                }
            }

            {   // get all trips with operator_id == reg_no
                string query = "SELECT * FROM trips WHERE operator_id = '@regNo'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var trip = new Trip
                            {
                                TripId = reader.GetString(0),
                                Title = reader.GetString(1),
                                Description = reader.GetString(2),
                                Capacity = reader.GetInt32(3),
                                DurationDays = reader.GetInt32(4),
                                Status = reader.GetString(5),
                                PricePerPerson = reader.GetDecimal(6),
                                StartLocationId = reader.GetString(7), // Fixed: Changed GetInt32 to GetString
                                StartDate = reader.GetDateTime(8),
                                EndDate = reader.GetDateTime(9),
                                OperatorId = reader.GetString(10), // Fixed: Changed GetInt32 to GetString
                                Category = reader.GetString(11),
                            };
                            trips.Add(trip);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw; // Re-throw to handle in calling code
                    }
                }
            }

            {   // get all locations
                string query = "SELECT * FROM location";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var location = new Location
                            {
                                DestId = reader.GetString(0),
                                DestinationName = reader.GetString(1),
                                City = reader.GetString(2),
                                Region = reader.GetString(3),
                                Country = reader.GetString(4)
                            };
                            locations.Add(location);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw; // Re-throw to handle in calling code
                    }
                }
            }
            {   // get all reviews
                string query = "SELECT * FROM trip_reviews";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var review = new TripReview(
                                reviewId: reader.GetString(0),
                                tripId: reader.GetString(1),
                                travelerId: reader.GetString(2),
                                rating: reader.GetInt32(3),
                                description: reader.GetString(4),
                                reviewDate: reader.GetDateTime(5),
                                flagStatus: reader.GetString(6)
                            );
                            reviews.Add(review);
                        }
                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                        throw; // Re-throw to handle in calling code
                    }
                }
            }
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

        private string GetStarString(int rating)
        {
            if (rating < 0) rating = 0;
            if (rating > 5) rating = 5;
            return new string('⭐', rating) + new string('☆', 5 - rating);
        }

        private void availableServicesPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
