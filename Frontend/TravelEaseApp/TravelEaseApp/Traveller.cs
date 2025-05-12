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
using static TravelEaseApp.Helpers;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace TravelEaseApp
{

    public partial class Traveller : Form
    {
        string regNo;
        Label hiddenLabel;
        //Panel currentPanel;
        public Traveller(string regNo)
        {
            this.regNo = "TR-000004";
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
            AddHoverTransition(applyfilterbox, applyfilterbox.BackColor, applyfilterbox.ForeColor, applyfilterbox.ForeColor, applyfilterbox.BackColor);



            PreferencesPanel.AutoScroll = true;

            AddPreferenceBox(PreferencesPanel, 1, "Eiffel Tower", "Paris", "Europe", "France");
            AddPreferenceBox(PreferencesPanel, 2, "Colosseum", "Rome", "Europe", "Italy");
            AddPreferenceBox(PreferencesPanel, 3, "Alpine Hiking Base", "Chamonix", "Europe", "France");



            TripDisplayPanel.AutoScroll = true;
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



            SetupGroupBoxFocusBehavior(groupBoxAccNum, innerAccNumBox);
            AddPlaceholder(innerAccNumBox, "PK47ABPL9882329237938473");
            AddHoverTransition(PayButton, PayButton.BackColor, PayButton.ForeColor, PayButton.ForeColor, PayButton.BackColor);
            PayButton.Click += PayButton_Click;


            MoneyLabel.Text = moneySlider.Value.ToString("C", CultureInfo.CurrentCulture);

            moneySlider.Scroll += (s, e) =>
            {
                MoneyLabel.Text = $"{moneySlider.Value}$";
            };

        }

        private void PayButton_Click(object? sender, EventArgs e)
        {
            
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


        const int ReviewSectionHeight = 200;
        const int StarSize = 30;
        private Panel CreateRatingControl(string prefix, int yPosition, int panelWidth, EventHandler starClickHandler)
        {
            Panel ratingPanel = new Panel
            {
                Location = new Point(MainPadding, yPosition),
                Width = panelWidth,
                Height = StarSize + 10,
                BackColor = Color.Transparent
            };

            for (int i = 1; i <= 5; i++)
            {
                PictureBox star = new PictureBox
                {
                    Name = $"{prefix}_star{i}",
                    Tag = i,
                    Image = Properties.Resources.StarEmpty, // You'll need star images
                    Size = new Size(StarSize, StarSize),
                    Location = new Point((i - 1) * (StarSize + 5), 0),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand
                };
                star.Click += starClickHandler;
                ratingPanel.Controls.Add(star);
            }

            return ratingPanel;
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

            // --- Status --- (Fixed version)
            Panel pnlStatus = new Panel
            {
                AutoSize = false,
                Height = 22,
                Padding = new Padding(5, 2, 5, 2),
                MinimumSize = new Size(70, 22)
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

            // Set status color and text
            switch (trip.Status.ToLower())
            {
                case "active":
                    pnlStatus.BackColor = Color.MediumSeaGreen;
                    lblStatusText.Text = "ACTIVE";
                    break;
                case "cancelled":
                    pnlStatus.BackColor = Color.Tomato;
                    lblStatusText.Text = "CANCELLED";
                    break;
                case "completed":
                    pnlStatus.BackColor = Color.CornflowerBlue;
                    lblStatusText.Text = "COMPLETED";
                    break;
                default:
                    pnlStatus.BackColor = Color.LightSlateGray;
                    lblStatusText.Text = trip.Status.ToUpper();
                    break;
            }

            // Calculate required width based on text
            using (Graphics g = pnlStatus.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(lblStatusText.Text, statusFont);
                pnlStatus.Width = (int)textSize.Width + 12; // Add padding
            }

            // Ensure minimum width
            if (pnlStatus.Width < 70)
                pnlStatus.Width = 70;

            pnlStatus.Location = new Point(contentPanel.Width - pnlStatus.Width - 10, 2);
            pnlStatus.Controls.Add(lblStatusText);

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
                DisplayTripInPanel(CompleteTripInfoPanel, trip, mainPanel);
            };

            // Attach to tripBox and all its children
            AttachClickToAllChildren(tripBox, showTripDetails);
        }


        private void DisplayOperatorReviews(Panel containerPanel, string operatorId)
        {
            containerPanel.AutoScroll = true;
            containerPanel.MinimumSize = new Size(containerPanel.Width, 200); // Set minimum height of 200  

            try
            {
                containerPanel.SuspendLayout();
                containerPanel.Controls.Clear();

                // SQL query to get reviews for operator's trips with traveler info  
                string query = @"  
               SELECT tr.*,   
                      t.title AS trip_title,  
                      trav.first_name + ' ' + trav.last_name AS traveler_name  
               FROM trip_reviews tr  
               JOIN trips t ON tr.trip_id = t.trip_id  
               JOIN travelers trav ON tr.traveler_id = trav.reg_no  
               WHERE t.operator_id = @operatorId  
               ORDER BY tr.review_date DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@operatorId", operatorId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                // No reviews found  
                                Label lblNoReviews = new Label
                                {
                                    Text = "No reviews found for this operator yet.",
                                    Dock = DockStyle.Top,
                                    AutoSize = true,
                                    ForeColor = Color.Gray,
                                    Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                                    Padding = new Padding(5)
                                };
                                containerPanel.Controls.Add(lblNoReviews);
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    // Create TripReview object  
                                    TripReview review = new TripReview(
                                        reader["review_id"].ToString(),
                                        reader["trip_id"].ToString(),
                                        reader["traveler_id"].ToString(),
                                        Convert.ToInt32(reader["rating"]),
                                        reader["description"].ToString(),
                                        Convert.ToDateTime(reader["review_date"]),
                                        reader["flag_status"].ToString()
                                    );

                                    // Get additional info  
                                    string tripTitle = reader["trip_title"].ToString();
                                    string travelerName = reader["traveler_name"].ToString();

                                    // Display the review  
                                    DisplayTripReviewInPanel(
                                        containerPanel,
                                        review,
                                        isPublicView: true,
                                        travelerName: travelerName
                                    );
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Error handling  
                Label lblError = new Label
                {
                    Text = $"Error loading reviews: {ex.Message}",
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 10F),
                    Padding = new Padding(5)
                };
                containerPanel.Controls.Add(lblError);
            }
            finally
            {
                containerPanel.ResumeLayout();
            }
        }

        /// <summary>
        /// Populates a panel with reviews for a specific service provider.
        /// (You will implement the database fetching and UI creation here)
        /// </summary>
        /// <param name="containerPanel">The Panel control to add review UI elements into.</param>
        /// <param name="providerId">The ID of the service provider whose reviews are needed.</param>
        /// <param name="providerName">The Name of the service provider (for display).</param>
        private void DisplayServiceProviderReviews(Panel containerPanel, string providerId, string providerName)
        {
            containerPanel.AutoScroll = true;
            containerPanel.MinimumSize = new Size(containerPanel.Width, 200); // Set minimum height of 200  

            try
            {
                containerPanel.SuspendLayout();
                containerPanel.Controls.Clear();

                // SQL query to get reviews for provider's services with traveler and service info
                string query = @"
            SELECT sr.*, 
                   s.service_type AS service_type,
                   s.service_description AS service_description,
                   trav.first_name + ' ' + trav.last_name AS traveler_name
            FROM service_reviews sr
            JOIN services s ON sr.service_id = s.service_id
            JOIN travelers trav ON sr.user_id = trav.reg_no
            WHERE s.provider_id = @providerId
            ORDER BY sr.review_date DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@providerId", providerId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                // No reviews found
                                Label lblNoReviews = new Label
                                {
                                    Text = $"No reviews found for {providerName ?? "this provider"} yet.",
                                    Dock = DockStyle.Top,
                                    AutoSize = true,
                                    ForeColor = Color.Gray,
                                    Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                                    Padding = new Padding(5)
                                };
                                containerPanel.Controls.Add(lblNoReviews);
                            }
                            else
                            {
                                // Add provider header
                                Label lblProviderHeader = new Label
                                {
                                    Text = $"Reviews for {providerName}",
                                    Dock = DockStyle.Top,
                                    Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                                    AutoSize = true,
                                    Padding = new Padding(5, 5, 5, 15)
                                };
                                containerPanel.Controls.Add(lblProviderHeader);

                                while (reader.Read())
                                {
                                    // Create ServiceReview object
                                    ServiceReview review = new ServiceReview(
                                        reader["review_id"].ToString(),
                                        reader["service_id"].ToString(),
                                        reader["user_id"].ToString(),
                                        Convert.ToInt32(reader["rating"]),
                                        reader["description"].ToString(),
                                        Convert.ToDateTime(reader["review_date"]),
                                        reader["flag_status"].ToString()
                                    );

                                    // Get additional info
                                    string travelerName = reader["traveler_name"].ToString();
                                    //string travelerProfilePic = reader["traveler_profile_pic"].ToString();

                                    // Use the existing DisplayServiceReviewInPanel method
                                    DisplayServiceReviewInPanel(
                                        containerPanel,
                                        review,
                                        isPublicView: true,
                                        travelerName: travelerName
                                    );
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Error handling
                Label lblError = new Label
                {
                    Text = $"Error loading reviews: {ex.Message}",
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    ForeColor = Color.Red,
                    Font = new Font("Segoe UI", 10F),
                    Padding = new Padding(5)
                };
                containerPanel.Controls.Add(lblError);
            }
            finally
            {
                containerPanel.ResumeLayout();
            }
        }

        public void LoadTripServices(Trip trip)
        {
            if (trip == null)
            {
                throw new ArgumentNullException(nameof(trip));
            }

            // Initialize the IncludedServices list if it's null
            if (trip.IncludedServices == null)
            {
                trip.IncludedServices = new List<Service>();
            }
            else
            {
                // Clear existing services if you want to refresh
                trip.IncludedServices.Clear();
            }

            string query = @"
        SELECT s.service_id, s.service_type, s.service_description, 
               s.price, s.capacity, s.provider_id,
               sp.provider_name AS provider_name
        FROM trip_services ts
        JOIN services s ON ts.service_id = s.service_id
        JOIN service_provider sp ON s.provider_id = sp.reg_no
        WHERE ts.trip_id = @tripId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@tripId", trip.TripId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Service service = new Service
                                {
                                    ServiceId = reader["service_id"].ToString(),
                                    ServiceType = reader["service_type"].ToString(),
                                    ServiceDescription = reader["service_description"].ToString(),
                                    Price = Convert.ToDecimal(reader["price"]),
                                    Capacity = Convert.ToInt32(reader["capacity"]),
                                    ProviderId = reader["provider_id"].ToString(),
                                    ProviderName = reader["provider_name"].ToString()
                                };

                                trip.IncludedServices.Add(service);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // You might want to log this error or handle it differently
                throw new ApplicationException($"Error loading services for trip {trip.TripId}", ex);
            }
        }

        // --- Main Display Function ---
        public void DisplayTripInPanel(Panel targetPanel, Trip trip, Panel mainPanel) // Added mainPanel parameter
        {
            // --- Theme and Styling Constants ---
            Color PanelBackgroundColor = Color.WhiteSmoke;
            Color TextColor = Color.FromArgb(30, 30, 30);
            Color MutedTextColor = Color.FromArgb(80, 80, 80);
            Color AccentColor = Color.FromArgb(0, 122, 204);
            Color ButtonTextColor = Color.White;
            Color DividerColor = Color.LightGray;
            Color CompletedTripColor = Color.FromArgb(0, 150, 0); // Green for completed status

            Font TitleFont = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            Font SubtitleFont = new Font("Segoe UI", 16F, FontStyle.Regular);
            Font BodyFont = new Font("Segoe UI", 12F, FontStyle.Regular);
            Font SectionHeaderFont = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            Font ButtonFont = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);
            Font SmallHeaderFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold); // For service provider review headers

            const int MainPadding = 20;
            const int ItemSpacing = 8;
            const int SectionSpacing = 15;
            const int ReviewPanelMinHeight = 50; // Min height for review panels


            if (targetPanel == null) throw new ArgumentNullException(nameof(targetPanel));
            if (trip == null) throw new ArgumentNullException(nameof(trip));

            targetPanel.SuspendLayout(); // Suspend layout during bulk updates

            targetPanel.Controls.Clear();
            targetPanel.BackColor = PanelBackgroundColor;
            targetPanel.ForeColor = TextColor;
            targetPanel.Padding = new Padding(MainPadding);
            targetPanel.AutoScroll = true;
            AddCloseButtonToPanel(targetPanel, mainPanel); // Assuming mainPanel is the panel to show after closing

            int currentY = MainPadding;
            int panelWidth = targetPanel.ClientSize.Width - (2 * MainPadding);

            Label AddLabel(string text, Font font, Color color, int y, int? fixedHeight = null, bool isMultiline = true, ContentAlignment alignment = ContentAlignment.TopLeft)
            {
                Label lbl = new Label
                {
                    Text = text,
                    Font = font,
                    ForeColor = color,
                    BackColor = Color.Transparent,
                    Location = new Point(MainPadding, y),
                    Width = panelWidth > 0 ? panelWidth : 400, // Ensure minimum width if panel isn't drawn yet
                    TextAlign = alignment,
                    MaximumSize = new Size(panelWidth > 0 ? panelWidth : 400, 0) // Allow vertical growth
                };

                if (isMultiline)
                {
                    lbl.AutoSize = false; // Set AutoSize false for manual height calculation/setting
                                          // Use MeasureText for accurate height calculation with word wrapping
                    Size textSize = TextRenderer.MeasureText(text, font, new Size(lbl.Width, int.MaxValue), TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
                    lbl.Height = fixedHeight ?? textSize.Height + 5; // Add a little padding
                }
                else
                {
                    lbl.AutoSize = true; // Let single-line labels size themselves
                }
                targetPanel.Controls.Add(lbl);
                return lbl;
            }

            Panel AddDivider(int y)
            {
                Panel divider = new Panel
                {
                    Height = 1,
                    BackColor = DividerColor,
                    Location = new Point(MainPadding, y),
                    Width = panelWidth > 0 ? panelWidth : 400,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right // Make divider resize horizontally
                };
                targetPanel.Controls.Add(divider);
                return divider;
            }

            // --- Image ---
            if (!string.IsNullOrWhiteSpace(trip.ImageUrl))
            {
                PictureBox pictureBox = new PictureBox
                {
                    Location = new Point(MainPadding, currentY),
                    Size = new Size(panelWidth > 0 ? panelWidth : 400, 200),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.Gainsboro,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                try
                {
                    // Prefer HttpClient, but WebClient works for basic cases
                    if (Uri.IsWellFormedUriString(trip.ImageUrl, UriKind.Absolute))
                    {
                        using (WebClient wc = new WebClient())
                        {
                            // Consider async download if UI responsiveness is critical
                            byte[] imageBytes = wc.DownloadData(trip.ImageUrl);
                            using (var ms = new System.IO.MemoryStream(imageBytes))
                            {
                                pictureBox.Image = Image.FromStream(ms);
                            }
                        }
                    }
                    else if (System.IO.File.Exists(trip.ImageUrl)) // Handle local files
                    {
                        // Use Image.FromFile for local files to avoid locking them
                        pictureBox.Image = Image.FromFile(trip.ImageUrl);
                        // pictureBox.ImageLocation = trip.ImageUrl; // Setting ImageLocation can sometimes lock files
                    }
                    else
                    {
                        // Add placeholder text if URL/path is invalid or inaccessible
                        Label imgPlaceholder = new Label { Text = "Image not available", Font = BodyFont, ForeColor = MutedTextColor, BackColor = pictureBox.BackColor, Size = pictureBox.Size, TextAlign = ContentAlignment.MiddleCenter };
                        pictureBox.Controls.Add(imgPlaceholder);
                    }
                    targetPanel.Controls.Add(pictureBox);
                    currentY += pictureBox.Height + SectionSpacing;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Image load error for {trip.ImageUrl}: {ex.Message}");
                    // Optionally add an error message label instead of crashing
                    Label imgErrorLabel = AddLabel($"Image could not be loaded.", BodyFont, MutedTextColor, currentY);
                    currentY += imgErrorLabel.Height + ItemSpacing;
                    // Don't add the picturebox if loading failed badly
                }
            }

            // --- Title, Price, Duration ---
            Label lblTitle = AddLabel(trip.Title ?? "Untitled Trip", TitleFont, TextColor, currentY, alignment: ContentAlignment.MiddleCenter);
            currentY += lblTitle.Height + ItemSpacing;

            string priceDuration = $"{trip.PricePerPerson:C} per person  |  {trip.DurationDisplay ?? "Duration N/A"}";
            Label lblPriceDuration = AddLabel(priceDuration, SubtitleFont, MutedTextColor, currentY, alignment: ContentAlignment.MiddleCenter);
            currentY += lblPriceDuration.Height + SectionSpacing;
            currentY += AddDivider(currentY).Height + SectionSpacing; // Divider after header section


            // --- Description (Overview) ---
            if (!string.IsNullOrWhiteSpace(trip.Description))
            {
                Label lblDescHeader = AddLabel("OVERVIEW", SectionHeaderFont, AccentColor, currentY);
                currentY += lblDescHeader.Height + (ItemSpacing / 2);
                Label lblDescription = AddLabel(trip.Description, BodyFont, TextColor, currentY);
                currentY += lblDescription.Height + SectionSpacing;
                currentY += AddDivider(currentY).Height + SectionSpacing;
            }

            // --- Details Section ---
            Label lblDetailsHeader = AddLabel("DETAILS", SectionHeaderFont, AccentColor, currentY);
            currentY += lblDetailsHeader.Height + (ItemSpacing / 2);

            Label lblDates = AddLabel($"Dates: {trip.StartDate:MMMM dd, yyyy} - {trip.EndDate:MMMM dd, yyyy}", BodyFont, TextColor, currentY, isMultiline: false);
            currentY += lblDates.Height + ItemSpacing;

            Label lblStartLoc = AddLabel($"Starts In: {(trip.StartLocation?.ToString() ?? "N/A")}", BodyFont, TextColor, currentY, isMultiline: false);
            currentY += lblStartLoc.Height + ItemSpacing;

            Label lblCapacity = AddLabel($"Capacity: {trip.Capacity} guests", BodyFont, TextColor, currentY, isMultiline: false);
            currentY += lblCapacity.Height + ItemSpacing;

            Label lblOperator = AddLabel($"Operated By: {trip.OperatorName ?? "N/A"}", BodyFont, TextColor, currentY, isMultiline: false);
            currentY += lblOperator.Height + ItemSpacing;

            Label lblCategory = AddLabel($"Category: {trip.Category ?? "N/A"}", BodyFont, TextColor, currentY, isMultiline: false);
            currentY += lblCategory.Height + ItemSpacing;

            Label lblStatus = AddLabel($"Status: {trip.Status ?? "N/A"}", BodyFont, TextColor, currentY, isMultiline: false);
            currentY += lblStatus.Height + SectionSpacing;
            currentY += AddDivider(currentY).Height + SectionSpacing;


            // --- Visited Locations ---
            if (trip.VisitedLocations != null && trip.VisitedLocations.Any())
            {
                Label lblVisitedHeader = AddLabel("PLACES YOU'LL VISIT", SectionHeaderFont, AccentColor, currentY);
                currentY += lblVisitedHeader.Height + (ItemSpacing / 2);
                foreach (var loc in trip.VisitedLocations)
                {
                    Label lblLoc = AddLabel($"• {loc?.ToString() ?? "Unknown Location"}", BodyFont, TextColor, currentY); // Added null check for loc
                    currentY += lblLoc.Height + (ItemSpacing / 2);
                }
                currentY += SectionSpacing - (ItemSpacing / 2); // Adjust spacing after the list
                currentY += AddDivider(currentY).Height + SectionSpacing;
            }

            // --- Included Services ---
            if (trip.IncludedServices != null && trip.IncludedServices.Any())
            {
                Label lblServicesHeader = AddLabel("WHAT'S INCLUDED", SectionHeaderFont, AccentColor, currentY);
                currentY += lblServicesHeader.Height + (ItemSpacing / 2);
                foreach (var service in trip.IncludedServices)
                {
                    if (service == null) continue; // Skip null services

                    string serviceText = $"• {service.ServiceType ?? "Service"}: {service.ServiceDescription ?? "Details not specified."}";
                    if (!string.IsNullOrWhiteSpace(service.ProviderName) && service.ProviderName != "N/A")
                    {
                        serviceText += $" (Provider: {service.ProviderName})";
                    }
                    Label lblService = AddLabel(serviceText, BodyFont, TextColor, currentY);
                    currentY += lblService.Height + (ItemSpacing / 2);
                }
                currentY += SectionSpacing - (ItemSpacing / 2); // Adjust spacing
                currentY += AddDivider(currentY).Height + SectionSpacing;
            }


            // --- ✅ Tour Operator Reviews Section ---
            if (!string.IsNullOrWhiteSpace(trip.OperatorId))
            {
                Label lblOperatorReviewHeader = AddLabel("TOUR OPERATOR REVIEWS", SectionHeaderFont, AccentColor, currentY);
                currentY += lblOperatorReviewHeader.Height + (ItemSpacing / 2);

                Panel operatorReviewsPanel = new Panel
                {
                    Location = new Point(MainPadding, currentY),
                    Width = panelWidth > 0 ? panelWidth : 400,
                    Height = ReviewPanelMinHeight, // Start with min height, might be adjusted by the function
                    BackColor = Color.Transparent, // Inherit panel background or set specific color
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                    //BorderStyle = BorderStyle.FixedSingle // Optional: for debugging layout
                };
                targetPanel.Controls.Add(operatorReviewsPanel);

                // Call the function to populate this panel
                DisplayOperatorReviews(operatorReviewsPanel, trip.OperatorId);

                // Update currentY based on the actual height of the populated panel
                currentY += operatorReviewsPanel.Height + SectionSpacing;
                currentY += AddDivider(currentY).Height + SectionSpacing;
            }

            LoadTripServices(trip); // Load services into the trip object
            // --- ✅ Service Provider Reviews Section ---
            if (trip.IncludedServices != null && trip.IncludedServices.Any())
            {
                // Get unique providers with valid IDs/Names
                var providers = trip.IncludedServices
                    .Where(s => s != null && !string.IsNullOrWhiteSpace(s.ProviderId)) // Ensure service and ProviderId exist
                    .GroupBy(s => s.ProviderId) // Group by ID (preferred)
                    .Select(g => g.First()) // Select one service per unique provider ID
                    .ToList();

                if (providers.Any())
                {
                    Label lblProviderReviewsHeader = AddLabel("SERVICE PROVIDER REVIEWS", SectionHeaderFont, AccentColor, currentY);
                    currentY += lblProviderReviewsHeader.Height + SectionSpacing; // More space before the first provider

                    foreach (var service in providers)
                    {
                        // Add a small header for *this* provider
                        Label lblProviderNameHeader = AddLabel($"Reviews for: {service.ProviderName ?? "Unknown Provider"}", SmallHeaderFont, TextColor, currentY);
                        currentY += lblProviderNameHeader.Height + (ItemSpacing / 2);

                        Panel serviceProviderReviewsPanel = new Panel
                        {
                            Location = new Point(MainPadding, currentY),
                            Width = panelWidth > 0 ? panelWidth : 400,
                            Height = ReviewPanelMinHeight, // Min height
                            BackColor = Color.Transparent,
                            Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                            // BorderStyle = BorderStyle.FixedSingle // Optional: for debugging
                        };
                        targetPanel.Controls.Add(serviceProviderReviewsPanel);

                        // Call the function to populate this panel
                        DisplayServiceProviderReviews(serviceProviderReviewsPanel, service.ProviderId, service.ProviderName);

                        // Update Y based on the populated panel's height
                        currentY += serviceProviderReviewsPanel.Height + ItemSpacing; // Space after each provider's review section
                    }
                    currentY += SectionSpacing - ItemSpacing; // Adjust spacing after the last provider
                    currentY += AddDivider(currentY).Height + SectionSpacing; // Divider after all service reviews
                }
            }

            currentY += ItemSpacing; // Extra space before the button/completion message

            // --- Action Button / Completion Message ---
            if (!trip.IsCompleted)
            {
                Button btnBookNow = new Button
                {
                    Text = "Book Now",
                    Font = ButtonFont,
                    ForeColor = ButtonTextColor,
                    BackColor = AccentColor,
                    FlatStyle = FlatStyle.Flat,
                    Height = 50,
                    Width = panelWidth > 0 ? panelWidth : 400,
                    Location = new Point(MainPadding, currentY),
                    Cursor = Cursors.Hand,
                    Tag = trip.TripId, // Store TripId for the click event handler
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };
                btnBookNow.FlatAppearance.BorderSize = 0;
                btnBookNow.Click += (sender, e) => {
                    try
                    {
                        // Generate a new booking ID
                        string bookingId = GetNextRegNo("BOOK");

                        // Prepare the SQL query
                        string query = @"
                        INSERT INTO bookings (
                            booking_id,
                            book_date,
                            booking_status,
                            traveler_id,
                            trip_id
                        ) VALUES (
                            @bookingId,
                            @bookDate,
                            @status,
                            @travelerId,
                            @tripId
                        )";

                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Add parameters
                                command.Parameters.AddWithValue("@bookingId", bookingId);
                                command.Parameters.AddWithValue("@bookDate", DateTime.Now);
                                command.Parameters.AddWithValue("@status", "pending");
                                command.Parameters.AddWithValue("@travelerId", this.regNo);
                                command.Parameters.AddWithValue("@tripId", trip.TripId);

                                // Execute the query
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Booking request submitted successfully!", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Optionally: refresh the UI or navigate away
                                    //mainPanel.Controls.Clear();
                                    // Add your code to show the main panel content
                                }
                                else
                                {
                                    MessageBox.Show("Failed to create booking.", "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error creating booking: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                targetPanel.Controls.Add(btnBookNow);
                currentY += btnBookNow.Height + MainPadding;
            }
            else
            {
                // Display a message indicating the trip is completed
                Label lblCompleted = AddLabel("This trip has been completed.", SubtitleFont, CompletedTripColor, currentY, alignment: ContentAlignment.MiddleCenter);
                lblCompleted.Font = new Font(lblCompleted.Font, FontStyle.Bold); // Make it bold
                currentY += lblCompleted.Height + MainPadding;
            }


            // --- Final Panel Adjustments ---
            targetPanel.AutoScrollMinSize = new Size(0, currentY); // Set scroll minimum size
            targetPanel.ResumeLayout(); // Resume layout and redraw everything
            targetPanel.PerformLayout(); // Force layout calculation
            targetPanel.Invalidate(); // Force redraw
        }

        private string GetNextRegNo(string userType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                UPDATE reg_counter
                SET last_number = last_number + 1
                OUTPUT INSERTED.last_number
                WHERE user_type = @type;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@type", userType);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int number = Convert.ToInt32(result);
                            return userType + "-" + number.ToString("D6");
                        }
                        else
                        {
                            throw new Exception("User type not found in reg_counter.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating registration number: " + ex.Message);
                return null; // Caller should handle null as failure
            }
        }
        // Example event handler (define this in your form/class where DisplayTripInPanel is called)
        // private void BtnBookNow_Click(object sender, EventArgs e)
        // {
        //     Button btn = sender as Button;
        //     if (btn != null && btn.Tag is string tripId)
        //     {
        //         MessageBox.Show($"Booking action for Trip ID: {tripId}");
        //         // Add booking logic here
        //     }
        // }



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
            TravellerTransactionPanel.Visible = false;

        }

        private void TripsButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            TravellerTripsPanel.Visible = true;
            TravellerBookingsPanel.Visible = false;
            TravellerTransactionPanel.Visible = false;
            retrieveTrips();
        }

        private void BookingsButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            TravellerTripsPanel.Visible = false;
            TravellerBookingsPanel.Visible = true;
            TravellerTransactionPanel.Visible = false;
            retrieveBookings(this.regNo);
        }

        private void TransactionsButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            TravellerTripsPanel.Visible = false;
            TravellerBookingsPanel.Visible = false;
            TravellerTransactionPanel.Visible = true;
            retrieveTransactions(this.regNo);
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
                btnPay.Click += (s, e) =>
                {
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
            AddCloseButtonToPanel(digitalPassesDiaplayPanel, mainPanel);
            if (currentBooking == null || currentBooking.DigitalPasses == null || !currentBooking.DigitalPasses.Any())
            {
                MessageBox.Show("No digital passes found for this booking.", "Digital Passes", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void retrieveTrips(string text = null, DateTime? startDate = null, DateTime? endDate = null, int budget = 0)
        {
            try
            {
                // Clear existing trips from the panel
                TripDisplayPanel.Controls.Clear();

                // Build the SQL query with filters
                string query = @"
            SELECT t.*, o.operator_name AS operator_name, l.destination_name AS start_location_name
            FROM trips t
            JOIN tour_operator o ON t.operator_id = o.reg_no
            JOIN location l ON t.start_loc_id = l.dest_id
            WHERE t.status = 'active'";

                // Add text filter if provided
                if (!string.IsNullOrEmpty(text))
                {
                    string searchText = text.Trim();
                    query += @" AND (
                LOWER(t.title) LIKE LOWER(@text) OR 
                LOWER(t.descirption) LIKE LOWER(@text) OR 
                LOWER(t.category) LIKE LOWER(@text) OR 
                LOWER(o.operator_name) LIKE LOWER(@text)
            )";
                }

                // Add date filters if provided
                if (startDate.HasValue)
                {
                    query += " AND t.start_date >= @startDate";
                }
                if (endDate.HasValue)
                {
                    query += " AND t.end_date <= @endDate";
                }

                // Add budget filter
                if (budget > 0)
                {
                    query += " AND t.price_per_person <= @budget";
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters
                        if (!string.IsNullOrEmpty(text))
                        {
                            command.Parameters.AddWithValue("@text", $"%{text.Trim()}%");
                        }
                        if (startDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@startDate", startDate.Value);
                        }
                        if (endDate.HasValue)
                        {
                            command.Parameters.AddWithValue("@endDate", endDate.Value);
                        }
                        if (budget > 0)
                        {
                            command.Parameters.AddWithValue("@budget", budget);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Trip trip = new Trip
                                {
                                    TripId = reader["trip_id"].ToString(),
                                    Title = reader["title"].ToString(),
                                    Description = reader["descirption"].ToString(),
                                    Capacity = Convert.ToInt32(reader["capacity"]),
                                    DurationDays = Convert.ToInt32(reader["duration"]),
                                    Category = reader["category"].ToString(),
                                    Status = reader["status"].ToString(),
                                    PricePerPerson = Convert.ToDecimal(reader["price_per_person"]),
                                    StartLocationId = reader["start_loc_id"].ToString(),
                                    StartDate = Convert.ToDateTime(reader["start_date"]),
                                    EndDate = Convert.ToDateTime(reader["end_date"]),
                                    OperatorId = reader["operator_id"].ToString(),
                                    OperatorName = reader["operator_name"].ToString(),
                                    ImageUrl = reader["profileTrip_image_url"].ToString(),
                                    StartLocation = new Location
                                    {
                                        DestId = reader["start_loc_id"].ToString(),
                                        DestinationName = reader["start_location_name"].ToString()
                                    },
                                    DurationDisplay = $"{reader["duration"]} Days"
                                };

                                // Add the trip to the panel
                                AddTripBox(TripDisplayPanel, trip);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors
                MessageBox.Show($"Error retrieving trips: {ex.Message}");
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void applyfilterbox_Click(object sender, EventArgs e)
        {
            retrieveTrips();
        }

        private void ApplyFiltersButton_Click(object sender, EventArgs e)
        {
            // Retrieve values from UI elements  
            string searchText = searchBox.Text;
            int budget = int.TryParse(MoneyLabel.Text.Replace("$", "").Trim(), out int parsedBudget) ? parsedBudget : 0;
            DateTime? startDate = dateTimePicker1.Value;
            DateTime? endDate = dateTimePicker2.Value;
            if (endDate < startDate) 
            { 
                MessageBox.Show("start date cannot be less than end date");
                return;
            }
            // Call the retrieveTrips function with the retrieved values  
            retrieveTrips(searchText, startDate, endDate, budget);
        }

        private void retrieveBookings(string regNo)
        {
            try
            {
                // Clear existing bookings from the panel
                BookingsDisplayPanel.Controls.Clear();

                // SQL query to get bookings with trip names
                string query = @"
            SELECT b.*, t.title AS trip_name
            FROM bookings b
            JOIN trips t ON b.trip_id = t.trip_id
            WHERE b.traveler_id = @regNo
            ORDER BY b.book_date DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", regNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create Booking object
                                Booking booking = new Booking(
                                    reader["booking_id"].ToString(),
                                    Convert.ToDateTime(reader["book_date"]),
                                    reader["booking_status"].ToString(),
                                    reader["traveler_id"].ToString(),
                                    reader["trip_id"].ToString()
                                );

                                // Get trip name
                                string tripName = reader["trip_name"].ToString();

                                // Add booking to the panel
                                AddBookingBox(BookingsDisplayPanel, booking, tripName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving bookings: {ex.Message}");
            }
        }


        private void retrieveTransactions(string regNo)
        {
            try
            {
                // Clear existing transactions from the panel
                TransactionDisplayPanel.Controls.Clear();

                // SQL query to get transactions with booking and trip info
                string query = @"
            SELECT txn.*, b.traveler_id, tr.title AS trip_name
            FROM transactions txn
            JOIN bookings b ON txn.booking_id = b.booking_id
            JOIN trips tr ON b.trip_id = tr.trip_id
            WHERE b.traveler_id = @regNo
            ORDER BY txn.transaction_date DESC";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@regNo", regNo);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create Transaction object
                                TravelEaseApp.Helpers.Transaction transaction = new TravelEaseApp.Helpers.Transaction(
                                    reader["transaction_id"].ToString(),
                                    Convert.ToDecimal(reader["amount"]),
                                    Convert.ToDateTime(reader["transaction_date"]),
                                    reader["payment_method"].ToString(),
                                    reader["booking_id"].ToString(),
                                    reader["status"].ToString(),
                                    reader["sending_account_number"].ToString()
                                );

                                // Get trip name
                                //string tripName = reader["trip_name"].ToString();

                                // Add transaction to the panel
                                AddTransactionToPanel(TransactionDisplayPanel, transaction);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving transactions: {ex.Message}");
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


        public void DisplayServiceReviewInPanel(
            Panel containerPanel,
            ServiceReview review,
            bool isPublicView,
            string travelerName = "Anonymous Traveler",
            string travelerProfilePicUrl = "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg")
        {
            if (containerPanel == null) throw new ArgumentNullException(nameof(containerPanel));
            if (review == null) throw new ArgumentNullException(nameof(review));

            // --- Design Constants ---
            int horizontalPagePadding = 20;
            int verticalCardSpacing = 15;
            int cardInternalPadding = 15;
            int cardAccentBarWidth = 6;
            int profilePicSize = isPublicView ? 50 : 0; // Now will show pic in public view

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
            Font starFont = new Font("Segoe UI Symbol", 12F);
            Font adminTextFont = new Font("Segoe UI", 9F);
            Font adminLabelFont = new Font("Segoe UI Semibold", 9F);
            Font buttonFont = new Font("Segoe UI Semibold", 9F);

            // --- Create the Review Card Panel ---
            Panel reviewCard = new Panel
            {
                Width = cardWidth,
                BackColor = primaryBackColor,
                Padding = new Padding(cardInternalPadding),
                Margin = new Padding(0, 0, 0, 0)
            };

            // Position the card
            int yPositionInContainer = verticalCardSpacing;
            if (containerPanel.Controls.Count > 0)
            {
                yPositionInContainer = containerPanel.Controls[containerPanel.Controls.Count - 1].Bottom + verticalCardSpacing;
            }
            reviewCard.Location = new Point(horizontalPagePadding, yPositionInContainer);

            // Accent color based on flag status
            Color currentAccentColor = isPublicView ? Color.FromArgb(200, 200, 200) :
                (review.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor);

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

            int currentY = cardInternalPadding;
            int contentStartX = cardInternalPadding + cardAccentBarWidth + (isPublicView ? profilePicSize + cardInternalPadding : 0);
            int contentWidth = reviewCard.Width - contentStartX - cardInternalPadding;
            if (contentWidth < 150) contentWidth = 150;

            // --- Profile Picture (Public View Only) ---
            if (isPublicView)
            {
                PictureBox picProfile = new PictureBox
                {
                    Width = profilePicSize,
                    Height = profilePicSize,
                    Location = new Point(cardInternalPadding + cardAccentBarWidth, cardInternalPadding),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    BackColor = Color.FromArgb(230, 230, 230)
                };

                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 0, picProfile.Width, picProfile.Height);
                picProfile.Region = new Region(path);

                try
                {
                    if (!string.IsNullOrWhiteSpace(travelerProfilePicUrl) && Uri.IsWellFormedUriString(travelerProfilePicUrl, UriKind.Absolute))
                    {
                        picProfile.LoadAsync(travelerProfilePicUrl);
                    }
                    else
                    {
                        picProfile.Image = CreatePlaceholderImage("👤", new Font("Segoe UI Symbol", profilePicSize * 0.5f),
                            picProfile.Size, picProfile.BackColor, Color.Gray);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading profile image: " + ex.Message);
                    picProfile.Image = CreatePlaceholderImage("!", new Font("Arial", profilePicSize * 0.5f),
                        picProfile.Size, picProfile.BackColor, Color.Red);
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
                    AutoSize = false,
                    Width = contentWidth - 75,
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
                Text = review.ReviewDate.ToString("MMM dd, yyyy"),
                Font = dateFont,
                ForeColor = dateColor,
                AutoSize = true,
                Tag = "HoverSensitive"
            };
            if (isPublicView)
            {
                lblDate.Location = new Point(reviewCard.Width - cardInternalPadding - lblDate.PreferredWidth - 5, currentY + 2);
            }
            reviewCard.Controls.Add(lblDate);

            if (isPublicView)
            {
                currentY += nameFont.Height + 2;
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

            // --- Admin View: IDs ---
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
                lastAdminDetail = AddAdminDetail("Service ID", review.ServiceId, currentY);
                currentY = lastAdminDetail.Bottom + 3;
                lastAdminDetail = AddAdminDetail("Traveler ID", review.TravelerId, currentY);
                currentY = lastAdminDetail.Bottom + 3;

                lblDate.Location = new Point(contentStartX, currentY);
                currentY = lblDate.Bottom + 8;
            }

            // --- Review Description ---
            Label lblDescription = new Label
            {
                Text = review.Description,
                Font = descriptionFont,
                ForeColor = descriptionColor,
                AutoSize = false,
                Width = contentWidth,
                Location = new Point(contentStartX, currentY),
                MaximumSize = new Size(contentWidth, 0),
                Tag = "HoverSensitive"
            };
            Size descSize = TextRenderer.MeasureText(review.Description, descriptionFont,
                                                  new Size(contentWidth, int.MaxValue),
                                                  TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
            lblDescription.Height = descSize.Height + 5;
            reviewCard.Controls.Add(lblDescription);
            currentY += lblDescription.Height + 10;

            // --- Admin View: Flag Status ---
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
                    Location = new Point(reviewCard.Width - cardInternalPadding - 120, lblFlagStatus.Top - (30 - lblFlagStatus.Height) / 2),
                    Tag = review
                };
                btnToggleFlag.FlatAppearance.BorderSize = 0;
                
                reviewCard.Controls.Add(btnToggleFlag);
                currentY = Math.Max(lblFlagStatus.Bottom, btnToggleFlag.Bottom) + 10;
            }

            // Set final height
            reviewCard.Height = Math.Max(cardMinHeight, currentY + cardInternalPadding - 10);

            // --- Add Hover Effect ---
            AddHoverTransition(reviewCard, primaryBackColor, cardHoverColor, descriptionColor, descriptionColor);

            // --- Add to container ---
            containerPanel.Controls.Add(reviewCard);
            if (containerPanel.Parent is Form || containerPanel.Parent?.Parent is Form)
            {
                containerPanel.ScrollControlIntoView(reviewCard);
            }
            else if (containerPanel.VerticalScroll.Visible)
            {
                containerPanel.ScrollControlIntoView(reviewCard);
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


    }

}
