﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static TravelEaseApp.Helpers;
using System.Numerics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.Data.SqlClient;

namespace TravelEaseApp.ServiceProvider
{
    public partial class dashboardForm : Form
    {
        string regNo;
        private Label hiddenLabel;
        private Panel CompleteServiceInfoPanel;

        List<Service> services = new List<Service>();

        List<Trip> trips = new List<Trip>();

        List<ServiceReview> reviews = new List<ServiceReview>();

        public dashboardForm(string REGNO)
        {
            InitializeComponent();
            regNo = REGNO;
            InitializeComponents();

            // ProfilePicture
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, profilePictureBox.Width, profilePictureBox.Height);
            profilePictureBox.Region = new Region(path);

            // Add Service Button
            AddHoverTransition(addServiceLabel, addServiceLabel.BackColor, addServiceLabel.ForeColor, addServiceLabel.ForeColor, addServiceLabel.BackColor);

            Color borderColor = Color.FromArgb(220, 224, 230);
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
        }

        private void setData()
        {
            {   // get all services
                string query = "SELECT * FROM services WHERE provider_id = '" + regNo + "'";

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
                string query = "SELECT * FROM trips";
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
                foreach (var trip in trips)
                {
                    // find the services for each trip
                    string query2 = "SELECT * FROM trip_services WHERE trip_id = '@tripId'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query2, connection);
                        command.Parameters.AddWithValue("@tripId", trip.TripId);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                var service = services.FirstOrDefault(s => s.ServiceId == reader.GetString(1));
                                var status = reader.GetString(2);
                                if (status == "accepted")
                                {
                                    trip.IncludedServices.Add(service);
                                }
                                else
                                {
                                    trip.RequestedServices.Add(service);
                                }
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

            {   // get serviceReviews

                string query = "SELECT * FROM service_reviews";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var review = new ServiceReview
                            {
                                ReviewId = reader.GetString(0),
                                TravelerId = reader.GetString(1),
                                ServiceId = reader.GetString(2),
                                Rating = reader.GetInt32(3),
                                Description = reader.GetString(4),
                                ReviewDate = reader.GetDateTime(5),
                                FlagStatus = reader.GetString(6),
                            };
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

            // Create trips (without service references)
            var trip1 = new Trip
            {
                TripId = "TRIP-0001",
                Title = "Luxury Beach Getaway",
                Description = "5-star beach resort vacation with premium amenities",
                Capacity = 20,
                DurationDays = 7,
                DurationDisplay = "7 Days, 6 Nights",
                Category = "Luxury",
                Status = "active",
                PricePerPerson = 2500.00m,
                StartDate = DateTime.Now.AddDays(30),
                EndDate = DateTime.Now.AddDays(37),
                OperatorName = "Elite Vacations"
            };
            trip1.IncludedServices = new List<Service> { service1, service2 };
            trip1.RequestedServices = new List<Service> { service3, service4 };

            var trip2 = new Trip
            {
                TripId = "TRIP-0002",
                Title = "Cultural City Tour",
                Description = "Explore historical landmarks with expert guides",
                Capacity = 15,
                DurationDays = 5,
                DurationDisplay = "5 Days, 4 Nights",
                Category = "Cultural",
                Status = "active",
                PricePerPerson = 1800.00m,
                StartDate = DateTime.Now.AddDays(45),
                EndDate = DateTime.Now.AddDays(50),
                OperatorName = "Heritage Tours"
            };
            trip2.IncludedServices = new List<Service> { service3, service4 };

            var trip3 = new Trip
            {
                TripId = "TRIP-0003",
                Title = "Adventure Safari",
                Description = "Wildlife safari with expert trackers",
                Capacity = 12,
                DurationDays = 10,
                DurationDisplay = "10 Days, 9 Nights",
                Category = "Adventure",
                Status = "upcoming",
                PricePerPerson = 3200.00m,
                StartDate = DateTime.Now.AddDays(60),
                EndDate = DateTime.Now.AddDays(70),
                OperatorName = "Wilderness Expeditions"
            };
            trip3.IncludedServices = new List<Service> { service2, service5 };
            trip3.RequestedServices = new List<Service> { service1, service4 };

            trips.AddRange(new[] { trip1, trip2, trip3 });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dashboardForm_Load(object sender, EventArgs e)
        {
            //SetSampleData();
            setData();
            // Add service boxes to the panel
            foreach (var service in services)
            {
                try
                {
                    // Check if service is found in requestedServices
                    foreach (var trip in trips)
                    {
                        if (trip.RequestedServices != null && trip.RequestedServices.Contains(service))
                        {
                            AddServiceBox(pendingRequestsPanel, service, trip);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while processing service {service.ServiceId}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            {   // run sql queries to get user info from service_provider
                string query = "SELECT * FROM service_provider WHERE reg_no = '" + regNo + "'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            var name = reader.GetString(1);
                            var location = reader.GetString(2);

                            username.Text = name;
                            tagline.Text = location;
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

            {   //Initialize topStatLabelNumberX's
                topStatLabelNumber1.Text = services.Count.ToString();

                //topstatlabelnumber2 = number of services that are included in atleast 1 trip
                int includedCount = 0;
                foreach (var trip in trips)
                {
                    includedCount += trip.IncludedServices.Count;
                }
                topStatLabelNumber2.Text = includedCount.ToString();

                //avgrating
                double totalRating = 0;
                foreach (var service in services)
                {
                    foreach (var review in reviews)
                    {
                        if (service.ServiceId == review.ServiceId)
                        {
                            totalRating += review.Rating;
                        }
                    }
                }
                if (services.Count > 0)
                {
                    double avgRating = totalRating / services.Count;
                    topStatLabelNumber3.Text = $"{avgRating:0.0}";
                }
                else
                {
                    topStatLabelNumber3.Text = "N/A";
                }
            }
        }

        private void addServiceLabel_Click(object sender, EventArgs e)
        {
            RequestAddServiceForm?.Invoke();
        }

        private void profilePictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        public event Action RequestAddServiceForm;

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void InitializeComponents()
        {
            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0);
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false;
            this.Controls.Add(hiddenLabel);
            this.ActiveControl = hiddenLabel;

            this.Controls.Add(pendingRequestsPanel);

            CompleteServiceInfoPanel = new Panel
            {
                Visible = false,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                AutoScroll = true
            };
        }

        public void AddServiceBox(Panel containerPanel, Service service, Trip trip)
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
            serviceBox.Click += (s, e) => ShowServiceDetails(service, trip);
            foreach (Control ctl in serviceBox.Controls)
            {
                ctl.Click += (s, e) => ShowServiceDetails(service, trip);
            }

            // Add to container
            containerPanel.Controls.Add(serviceBox);

            // Create a panel for the action buttons (+ and -)
            Panel actionPanel = new Panel
            {
                Width = 60,
                Height = 30,
                Location = new Point(serviceBox.Width - 60, 10),
                BackColor = Color.Transparent
            };

            // + Button
            Button plusButton = new Button
            {
                Text = "+",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Green,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(25, 25),
                Location = new Point(0, 0),
                Cursor = Cursors.Hand,
                Tag = service // Store the service reference
            };
            plusButton.FlatAppearance.BorderSize = 1;
            plusButton.FlatAppearance.BorderColor = Color.LightGray;
            plusButton.Click += (s, e) => {
                // Handle + button click (approve service)
                Button btn = (Button)s;
                Service serviceToApprove = (Service)btn.Tag;
                MessageBox.Show($"Approving service: {serviceToApprove.ServiceId} - Linked with Trip: {trip.TripId}");
                // Update status in trip_services and local lists inside a transaction
                string query = "UPDATE trip_services SET status = 'accepted' WHERE trip_id = '" + trip.TripId + "' AND service_id = '" + serviceToApprove.ServiceId + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 1. Update database
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected == 0) throw new Exception("Service not found in database");
                        }

                        // 2. Update local lists
                        if (trip.RequestedServices.Contains(serviceToApprove))
                        {
                            trip.RequestedServices.Remove(serviceToApprove);
                            trip.IncludedServices.Add(serviceToApprove);
                        }
                        else throw new Exception("Service not found in local requested services");

                        // 3. Commit transaction
                        transaction.Commit();

                        // 4. Refresh UI (outside transaction)
                        pendingRequestsPanel.Controls.Clear();
                        foreach (var service in services)
                        {
                            foreach (var t in trips)
                            {
                                if (t.RequestedServices != null && t.RequestedServices.Contains(service))
                                {
                                    AddServiceBox(pendingRequestsPanel, service, t);
                                }
                            }
                        }

                        MessageBox.Show("Service approved successfully.");
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { /* Handle rollback failure */ }
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            };

            // - Button
            Button minusButton = new Button
            {
                Text = "-",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.Red,
                BackColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(25, 25),
                Location = new Point(30, 0),
                Cursor = Cursors.Hand,
                Tag = service // Store the service reference
            };

            minusButton.FlatAppearance.BorderSize = 1;
            minusButton.FlatAppearance.BorderColor = Color.LightGray;
            minusButton.Click += (s, e) => {
                Button btn = (Button)s;
                Service serviceToReject = (Service)btn.Tag;

                string query = "UPDATE trip_services SET status = 'rejected' WHERE trip_id = '" +
                               trip.TripId + "' AND service_id = '" + serviceToReject.ServiceId + "'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 1. Update database
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected == 0) throw new Exception("Service not found in database");
                        }

                        // 2. Update local lists
                        if (trip.RequestedServices.Contains(serviceToReject))
                        {
                            trip.RequestedServices.Remove(serviceToReject);
                            // Note: Unlike approval, we don't add to IncludedServices for rejections
                        }
                        else throw new Exception("Service not found in local requested services");

                        // 3. Commit transaction
                        transaction.Commit();

                        // 4. Refresh UI
                        pendingRequestsPanel.Controls.Clear();
                        foreach (var service in services)
                        {
                            foreach (var t in trips)
                            {
                                if (t.RequestedServices != null && t.RequestedServices.Contains(service))
                                {
                                    AddServiceBox(pendingRequestsPanel, service, t);
                                }
                            }
                        }

                        MessageBox.Show($"Service {serviceToReject.ServiceId} rejected successfully.");
                    }
                    catch (Exception ex)
                    {
                        try { transaction.Rollback(); } catch { /* Handle rollback failure */ }
                        MessageBox.Show($"Error rejecting service: {ex.Message}");
                    }
                }
            };

            // Add buttons to action panel
            actionPanel.Controls.Add(plusButton);
            actionPanel.Controls.Add(minusButton);

            // Add hover effects to buttons
            AddHoverTransition(plusButton, Color.White, Color.Green, Color.Green, Color.White);
            AddHoverTransition(minusButton, Color.White, Color.Red, Color.Red, Color.White);

            // Add the action panel to the service box
            serviceBox.Controls.Add(actionPanel);

            // Ensure the action panel stays on top
            actionPanel.BringToFront();
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

        private void ShowServiceDetails(Service service, Trip trip)
        {
            if (CompleteServiceInfoPanel.Visible == false)
            {
                pendingRequestsPanel.Controls.Add(CompleteServiceInfoPanel);
                CompleteServiceInfoPanel.BringToFront();
                CompleteServiceInfoPanel.Visible = true;
                CompleteServiceInfoPanel.Size = new Size(pendingRequestsPanel.Width - 40, pendingRequestsPanel.Height - 40);
                CompleteServiceInfoPanel.Location = new Point(20, 20);
            }

            DisplayServiceInPanel(CompleteServiceInfoPanel, service, trip);
        }

        private void DisplayServiceInPanel(Panel panel, Service service, Trip trip)
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

            // ========== ASSOCIATED TRIP SECTION ==========
            if (trip != null)
            {
                // Divider before trip info
                panel.Controls.Add(new Panel
                {
                    BackColor = Color.LightGray,
                    Height = 1,
                    Width = panel.Width - 60,
                    Location = new Point(20, currentY)
                });
                currentY += 20;

                var tripHeader = AddLabel(
                    "ASSOCIATED TRIP",
                    new Font("Segoe UI", 14, FontStyle.Bold),
                    Color.FromArgb(70, 130, 180), // Different color for trip section
                    currentY,
                    panel.Width - 60);
                currentY += tripHeader.Height + 15;

                // Trip ID
                var tripIdLabel = AddLabel(
                    $"Trip ID: {trip.TripId}",
                    new Font("Segoe UI", 11, FontStyle.Bold),
                    Color.FromArgb(70, 130, 180),
                    currentY,
                    panel.Width - 60);
                currentY += tripIdLabel.Height + 10;

                // Trip Description
                var tripTitleLabel = AddLabel(
                    trip.Title,
                    new Font("Segoe UI", 10),
                    Color.Black,
                    currentY,
                    panel.Width - 60);
                currentY += tripTitleLabel.Height + 15;
            }

            // Another divider
            panel.Controls.Add(new Panel
            {
                BackColor = Color.LightGray,
                Height = 1,
                Width = panel.Width - 60,
                Location = new Point(20, currentY)
            });
            currentY += 20;

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
    }
}