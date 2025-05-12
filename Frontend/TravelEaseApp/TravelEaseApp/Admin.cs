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
using static TravelEaseApp.Helpers;
using System.Data.SqlClient;
using System.Globalization;
using FastReport;

namespace TravelEaseApp
{
    public partial class Admin : Form
    {
        string regNo;
        Label hiddenLabel;

        private Panel CompleteReportPanel = new Panel();

        List<string> reportList = new List<string>
        {
            "1. Revenue by Category Report",
            "2. Trip Booking Revenue Report",
            "3. Trip Cancellation Rate Report",
            "4. Peak Booking Periods Report",
            "5. Average Booking Value Report",
            "6. Traveler Demographics Report",
            "7. Preferred Trip Types Report",
            "8. Preferred Destinations Report",
            "9. Traveler Spending Habits Report",
            "10. Average Operator Rating Report",
            "11. Operator Total Revenue Report",
            "12. Hotel Occupancy Rate Report",
            "13. Guide Service Ratings Report",
            "14. Most Booked Destinations Report",
            "15. Seasonal Trends Report",
            "16. Traveler Satisfaction Score Report",
            "17. Emerging Destinations Report",
            "18. Abandoned Booking Analysis Report",
            "19. Abandoned Booking Reasons Report",
            "20. Abandoned Booking Recovery Rate Report",
            "21. Potential Revenue Loss Report",
            "22. New User Registrations Report",
            "23. Monthly Active Users Report",
            "24. Partnership Growth Report",
            "25. Regional Expansion Report",
            "26. Payment Success/Failure Rate Report",
            "27. Chargeback Rate Report"
        };

        public Admin(string regNo)
        {
            this.regNo = regNo;

            InitializeComponent();
            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0); // Invisible
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false; // Does not appear in the tab order
            this.Controls.Add(hiddenLabel);
            this.ActiveControl = hiddenLabel; // Set focus to the invisible label
            this.regNo = regNo;

            //submitLabel.BackColor, submitLabel.ForeColor, submitLabel.ForeColor, submitLabel.BackColor
            AddHoverTransition(ReportViewButton, ReportViewButton.BackColor, ReportViewButton.ForeColor, ReportViewButton.ForeColor, ReportViewButton.BackColor);
            PopulateSelectReportComboBox();

            CompleteReportPanel.Visible = false;

            Color borderColor = Color.FromArgb(220, 224, 230);
            CompleteReportPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, CompleteReportPanel.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };
        }

        private void PopulateSelectReportComboBox()
        {
            //categoryComboBox.DataSource = null; // Clear previous bindings
            //categoryComboBox.DisplayMember = "CategoryName"; // Display user-friendly string
            //categoryComboBox.ValueMember = "Id"; // Set the value to location_id
            //categoryComboBox.DataSource = categories; // Bind the data

            // show strings from reportList, but output the index of the selection
            selectReportComboBox.DataSource = reportList;
            selectReportComboBox.SelectedIndex = -1; // No selection by default
        }

        private void CategoryButtonLabel_Click(object sender, EventArgs e)
        {

        }

        private void DashboardPanel_Paint(object sender, PaintEventArgs e)
        {

        }


        private string GetStarString(int rating)
        {
            if (rating < 0) rating = 0;
            if (rating > 5) rating = 5;
            return new string('⭐', rating) + new string('☆', 5 - rating);
        }

        /// <summary>
        /// Displays a single trip review in a styled card format within the specified panel.
        /// </summary>
        /// <param name="containerPanel">The panel to add the review card to.</param>
        /// <param name="review">The TripReview object to display.</param>
        /// <param name="isPublicView">True for public display (name, pic, review), False for admin view (all details, flag button).</param>
        /// <param name="travelerName">The name of the traveler (for public view). Defaults to "Anonymous Traveler".</param>
        /// <param name="travelerProfilePicUrl">URL for the traveler's profile picture (for public view). Defaults to a placeholder.</param>
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
                    // Get the review ID from the button's Tag property (set when creating the button)
                    string reviewId = review.ReviewId;
                    if (reviewId != "")
                    {
                        try
                        {
                            // Determine the new status (toggle between 'flagged' and 'clear')
                            string newStatus = "";
                            string currentStatus = "";

                            // Create connection string (replace with your actual connection string)

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                // Get current status
                                string getStatusSql = "SELECT flag_status FROM trip_reviews WHERE review_id = @reviewId";
                                using (SqlCommand getStatusCmd = new SqlCommand(getStatusSql, connection))
                                {
                                    getStatusCmd.Parameters.AddWithValue("@reviewId", reviewId);
                                    currentStatus = getStatusCmd.ExecuteScalar()?.ToString();
                                }

                                // Determine new status
                                newStatus = currentStatus == "flagged" ? "clear" : "flagged";

                                // Update the status
                                string updateSql = "UPDATE trip_reviews SET flag_status = @newStatus WHERE review_id = @reviewId";
                                using (SqlCommand updateCmd = new SqlCommand(updateSql, connection))
                                {
                                    updateCmd.Parameters.AddWithValue("@newStatus", newStatus);
                                    updateCmd.Parameters.AddWithValue("@reviewId", reviewId);

                                    int rowsAffected = updateCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Update successful - refresh the view
                                        MessageBox.Show($"Trip review status changed to {newStatus}");

                                        LogTripRevStatus(reviewId, this.regNo, newStatus); // Log the status change
                                        // Also log this action
                                        //LogTripReviewStatusChange(reviewId, newStatus);

                                        // Refresh the current view based on the selected filter
                                        if (tripFlagOption.Text == "Flagged")
                                            retrieveTripReviews("flagged");
                                        else if (tripFlagOption.Text == "Clear")
                                            retrieveTripReviews("clear");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No trip review found with that ID");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error toggling flag status: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No review ID associated with this button");
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
                btnToggleFlag.Click += (s, e) =>
                {
                    // Get the review ID from the button's Tag property (set when creating the button)
                    string reviewId = review.ReviewId;
                    if (reviewId != "")
                    {
                        try
                        {
                            // Determine the new status (toggle between 'flagged' and 'clear')
                            string newStatus = "";
                            string currentStatus = "";

                            // First get the current status

                            using (SqlConnection connection = new SqlConnection(connectionString))
                            {
                                connection.Open();

                                // Get current status
                                string getStatusSql = "SELECT flag_status FROM service_reviews WHERE review_id = @reviewId";
                                using (SqlCommand getStatusCmd = new SqlCommand(getStatusSql, connection))
                                {
                                    getStatusCmd.Parameters.AddWithValue("@reviewId", reviewId);
                                    currentStatus = getStatusCmd.ExecuteScalar()?.ToString();
                                }

                                // Determine new status
                                newStatus = currentStatus == "flagged" ? "clear" : "flagged";

                                // Update the status
                                string updateSql = "UPDATE service_reviews SET flag_status = @newStatus WHERE review_id = @reviewId";
                                using (SqlCommand updateCmd = new SqlCommand(updateSql, connection))
                                {
                                    updateCmd.Parameters.AddWithValue("@newStatus", newStatus);
                                    updateCmd.Parameters.AddWithValue("@reviewId", reviewId);

                                    int rowsAffected = updateCmd.ExecuteNonQuery();

                                    if (rowsAffected > 0)
                                    {
                                        // Update successful - refresh the view
                                        MessageBox.Show($"Review status changed to {newStatus}");
                                        LogServiceRevStatus(reviewId, this.regNo, newStatus);
                                        retrieveServiceReviews(serviceFlagOption.Text);

                                        // Refresh the current view
                                    }
                                    else
                                    {
                                        MessageBox.Show("No review found with that ID");
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error toggling flag status: {ex.Message}");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No review ID associated with this button");
                    }
                };
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

        // --- Design Constants (consistent with TransactionUIBuilder) ---
        private const int HORIZONTAL_PAGE_PADDING = 15;
        private const int VERTICAL_SPACING = 10;
        private const int BOX_INTERNAL_PADDING = 15; // Slightly more padding for a softer look
        private const int MIN_BOX_HEIGHT = 70;
        private const int ACCENT_BAR_WIDTH = 5;
        private const string HOVER_SENSITIVE_TAG = "HoverSensitiveText";

        // --- Colors (derived from TransactionUIBuilder theme) ---
        private readonly Color _primaryBackColor = Color.FromArgb(255, 255, 255); // White
        private readonly Color _hoverColor = Color.FromArgb(247, 250, 255);       // Very Light Blue
        private readonly Color _borderColor = Color.FromArgb(228, 231, 235);       // Softer grey border
                                                                                   // Using a neutral but distinct accent color for categories
        private readonly Color _accentColorCategory = Color.FromArgb(79, 70, 229); // Indigo/Deep Blue

        private readonly Color _categoryNameColor = Color.FromArgb(31, 41, 55);  // Dark grey for name
        private readonly Color _categoryIdColor = Color.FromArgb(107, 114, 128); // Lighter grey for ID
        private readonly Color _textHoverColor = Color.FromArgb(59, 130, 246);    // A distinct blue for text hover

        // --- Fonts (consistent style) ---
        private readonly Font _categoryNameFont = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
        private readonly Font _categoryIdFont = new Font("Segoe UI", 8.5F, FontStyle.Regular);

        // Optional: Method for rounded corners (more advanced GDI+)
        private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }



        public void AddCategoryToPanel(Panel containerPanel, Category category)
        {

            // --- Colors --- (Define these at the class level or pass them in)
            Color _primaryBackColor = Color.White;
            Color _borderColor = Color.LightGray;
            Color _accentColorCategory = Color.SteelBlue;
            Color _categoryNameColor = Color.Black;
            Color _categoryIdColor = Color.Gray;
            Color _hoverColor = Color.FromArgb(240, 240, 240);
            Color _textHoverColor = Color.DarkBlue;

            // --- Fonts --- (Define these at the class level or pass them in)
            Font _categoryNameFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font _categoryIdFont = new Font("Segoe UI", 8);

            if (category == null) throw new ArgumentNullException(nameof(category));
            if (containerPanel == null) throw new ArgumentNullException(nameof(containerPanel)); // Good practice to check container too

            // --- Constants ---
            const int HORIZONTAL_PADDING = 10;
            int REDUCED_WIDTH = containerPanel.ClientSize.Width - (HORIZONTAL_PADDING * 2); // Use ClientSize for accuracy, consider scrollbar later if needed
            const int ACCENT_BAR_WIDTH = 5;
            const int BOX_INTERNAL_PADDING = 8;
            const int VERTICAL_SPACING = 10; // This now solely comes from the Margin
            const int MIN_BOX_HEIGHT = 60;
            const string HOVER_SENSITIVE_TAG = "hover-sensitive";

            // --- Create the main category Panel ---
            Panel categoryCardPanel = new Panel
            {
                // Width set relative to container, taking horizontal padding into account
                Width = REDUCED_WIDTH,
                BackColor = _primaryBackColor,
                Padding = new Padding(BOX_INTERNAL_PADDING),
                // Margin includes top (0), left/right (HORIZONTAL_PADDING), and bottom (VERTICAL_SPACING)
                // The bottom margin creates the space BEFORE the *next* control.
                Margin = new Padding(HORIZONTAL_PADDING, 0, HORIZONTAL_PADDING, VERTICAL_SPACING)
                // Note: Location is set below based on the previous control
            };

            // --- Position the card ---
            int yPosition = VERTICAL_SPACING; // Default top spacing for the *first* card
            if (containerPanel.Controls.Count > 0)
            {
                // Position below the bottom edge of the previous control.
                // The Margin.Bottom of the *previous* control effectively creates the space.
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPosition = lastControl.Bottom + lastControl.Margin.Bottom; // More robust: use Bottom + Margin.Bottom of previous
                                                                            // Or simply lastControl.Bottom if Margin is consistent
            }
            // Set location using calculated yPosition and standard horizontal padding
            categoryCardPanel.Location = new Point(HORIZONTAL_PADDING, yPosition);

            // --- Paint event for styling ---
            categoryCardPanel.Paint += (s, e) =>
            {
                Panel panel = s as Panel;
                if (panel == null) return;

                // Draw border (using ClientRectangle respects Padding)
                ControlPaint.DrawBorder(e.Graphics, panel.ClientRectangle,
                    _borderColor, 1, ButtonBorderStyle.Solid,
                    _borderColor, 1, ButtonBorderStyle.Solid,
                    _borderColor, 1, ButtonBorderStyle.Solid,
                    _borderColor, 1, ButtonBorderStyle.Solid);

                // Draw accent bar
                using (SolidBrush accentBrush = new SolidBrush(_accentColorCategory))
                {
                    // Draw inside the padding area on the left
                    e.Graphics.FillRectangle(accentBrush, 0, 0, ACCENT_BAR_WIDTH, panel.Height);
                }
            };

            // --- Content Layout ---
            int currentY = BOX_INTERNAL_PADDING; // Start Y relative to the panel's top padding
                                                 // Start X after the accent bar and a small gap, relative to the panel's left padding
            int contentStartX = BOX_INTERNAL_PADDING + ACCENT_BAR_WIDTH + 5;
            // Calculate content width considering internal padding, accent bar, gap, and right padding
            int contentWidth = categoryCardPanel.ClientSize.Width - contentStartX - BOX_INTERNAL_PADDING;
            // Ensure contentWidth is not negative if panel is too small
            if (contentWidth < 10) contentWidth = 10;


            // --- Category Name ---
            Label lblCategoryName = new Label
            {
                Text = category.CategoryName,
                Font = _categoryNameFont,
                ForeColor = _categoryNameColor,
                // Use MaximumSize and AutoSize for better wrapping and height calculation
                MaximumSize = new Size(contentWidth, 0), // Max width, height adjusts automatically
                AutoSize = true, // Let the label determine its height based on text and width
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true, // Still useful if text is single line and very long
                Tag = HOVER_SENSITIVE_TAG
            };
            categoryCardPanel.Controls.Add(lblCategoryName);
            // Use Bottom property which includes the calculated height
            currentY = lblCategoryName.Bottom + 2; // Add 2px gap before the next label


            // --- Category ID ---
            Label lblCategoryId = new Label
            {
                Text = $"ID: {category.Id}",
                Font = _categoryIdFont,
                ForeColor = _categoryIdColor,
                AutoSize = true, // Let label determine its own size
                MaximumSize = new Size(contentWidth, 0), // Allow wrapping if needed
                Location = new Point(contentStartX, currentY),
                Tag = HOVER_SENSITIVE_TAG
            };
            categoryCardPanel.Controls.Add(lblCategoryId);
            // Use Bottom property which includes the calculated height
            currentY = lblCategoryId.Bottom + BOX_INTERNAL_PADDING; // Add bottom internal padding


            // --- Set final height ---
            // Calculate required height based on content bottom + panel's bottom padding
            int calculatedHeight = currentY;
            // Ensure minimum height is met
            categoryCardPanel.Height = Math.Max(MIN_BOX_HEIGHT, calculatedHeight);

            // --- Hover Effects ---
            Dictionary<Control, Color> originalColors = new Dictionary<Control, Color>();
            Dictionary<Control, Color> originalBackColors = new Dictionary<Control, Color>(); // Store label BackColors too if needed

            Action<Control> applyHover = (control) =>
            {
                control.BackColor = _hoverColor;
                originalBackColors.Clear(); // Clear previous hover states
                originalColors.Clear();

                foreach (Control c in control.Controls)
                {
                    originalBackColors[c] = c.BackColor; // Store original backcolor
                    c.BackColor = _hoverColor; // Make label background match panel hover

                    if (c.Tag?.ToString() == HOVER_SENSITIVE_TAG && c is Label) // Apply text color change only to tagged labels
                    {
                        originalColors[c] = c.ForeColor;
                        c.ForeColor = _textHoverColor;
                    }
                }
            };

            Action<Control> removeHover = (control) =>
            {
                if (control.ClientRectangle.Contains(control.PointToClient(Cursor.Position)))
                    return; // Still inside the panel, do nothing

                control.BackColor = _primaryBackColor; // Restore panel background

                foreach (var entry in originalColors)
                {
                    entry.Key.ForeColor = entry.Value; // Restore text color
                }
                foreach (var entry in originalBackColors)
                {
                    entry.Key.BackColor = entry.Value; // Restore control background (often Transparent or same as parent)
                }
                originalColors.Clear();
                originalBackColors.Clear();
            };


            // Apply hover to panel and its children recursively
            Action<Control> subscribeToHover = null;
            subscribeToHover = (control) =>
            {
                control.MouseEnter += (s, e) => applyHover(categoryCardPanel); // Always trigger based on the main panel
                control.MouseLeave += (s, e) => removeHover(categoryCardPanel); // Always trigger based on the main panel

                foreach (Control child in control.Controls)
                {
                    subscribeToHover(child); // Subscribe children too
                }
            };

            subscribeToHover(categoryCardPanel); // Start subscribing from the main panel


            // --- Add to container ---
            containerPanel.Controls.Add(categoryCardPanel);

            // --- Auto-scroll if needed ---
            // Ensure layout is updated before scrolling, might need Application.DoEvents() in some complex scenarios, but try without first
            containerPanel.PerformLayout(); // Force layout calculation
            if (containerPanel.VerticalScroll.Visible && !containerPanel.ClientRectangle.Contains(categoryCardPanel.Bounds))
            {
                containerPanel.ScrollControlIntoView(categoryCardPanel);
            }
            // Adjust width again if scrollbar appeared/disappeared (optional, can be complex)
            // Consider using a FlowLayoutPanel if dynamic width adjustment is critical
        }

        Color _statusColorPending = Color.FromArgb(255, 165, 0);
        Color _statusColorAccepted = Color.FromArgb(0, 128, 0);
        Color _statusColorRejected = Color.FromArgb(220, 20, 60);

        public void DisplayUser(Panel containerPanel, User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            // --- Styling constants - these can be adjusted to fit your UI theme ---
            Color _primaryBackColor = Color.FromArgb(242, 245, 249);
            Color _borderColor = Color.FromArgb(220, 220, 220);
            Color _accentColor = Color.FromArgb(100, 149, 237);
            Color _hoverColor = Color.FromArgb(230, 230, 230);
            Color _textHoverColor = Color.FromArgb(0, 0, 0);
            Font _regNoFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Color _regNoColor = Color.FromArgb(34, 34, 34);
            Font _emailFont = new Font("Segoe UI", 9);
            Color _emailColor = Color.FromArgb(102, 102, 102);
            Font _phoneFont = new Font("Segoe UI", 9);
            Color _phoneColor = Color.FromArgb(102, 102, 102);
            Font _statusFont = new Font("Segoe UI", 9, FontStyle.Italic);
            Font _roleFont = new Font("Segoe UI", 9, FontStyle.Bold);
            Color _roleColor = Color.FromArgb(70, 130, 180);

            const int HORIZONTAL_PAGE_PADDING = 20;
            const int VERTICAL_SPACING = 10;
            const int BOX_INTERNAL_PADDING = 10;
            const int ACCENT_BAR_WIDTH = 5;
            const int MIN_BOX_HEIGHT = 80;
            const int BUTTON_SPACING = 5;
            const string HOVER_SENSITIVE_TAG = "hoverSensitive";

            // --- Calculate Box Width ---
            int boxWidth = containerPanel.Width - (2 * HORIZONTAL_PAGE_PADDING);
            if (boxWidth < 250)
            {
                boxWidth = 250; // Min width
            }

            // --- Create the main user Panel (userCardPanel) ---
            Panel userCardPanel = new Panel
            {
                Width = boxWidth,
                BackColor = _primaryBackColor,
                Padding = new Padding(BOX_INTERNAL_PADDING),
                Margin = new Padding(HORIZONTAL_PAGE_PADDING, 0, HORIZONTAL_PAGE_PADDING, VERTICAL_SPACING),
            };

            // --- Determine Y position for the new card ---
            int yPositionInContainer = VERTICAL_SPACING;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPositionInContainer = lastControl.Bottom + VERTICAL_SPACING;
            }
            userCardPanel.Location = new Point(HORIZONTAL_PAGE_PADDING, yPositionInContainer);

            // --- Paint event for border and left accent bar ---
            userCardPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                // Draw rounded border
                using (GraphicsPath path = GetRoundedRect(userCardPanel.ClientRectangle, 6))
                using (Pen borderPen = new Pen(_borderColor, 1))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }

                // Draw the accent bar
                using (SolidBrush accentBrush = new SolidBrush(_accentColor))
                {
                    e.Graphics.FillRectangle(accentBrush, 0, 0, ACCENT_BAR_WIDTH, userCardPanel.Height);
                }
            };

            // --- Initialize Layout Variables ---
            int currentY = BOX_INTERNAL_PADDING;
            int contentStartX = BOX_INTERNAL_PADDING + ACCENT_BAR_WIDTH + 8;
            int availableContentWidth = userCardPanel.Width - contentStartX - BOX_INTERNAL_PADDING;

            // --- RegNo Label ---
            Label regNoLabel = new Label
            {
                Text = "RegNo: " + user.RegNo,
                Font = _regNoFont,
                ForeColor = _regNoColor,
                AutoSize = false,
                Width = availableContentWidth,
                Height = _regNoFont.Height + 4,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true,
                Tag = HOVER_SENSITIVE_TAG
            };
            userCardPanel.Controls.Add(regNoLabel);
            currentY += regNoLabel.Height + 2;

            // --- Email Label ---
            Label emailLabel = new Label
            {
                Text = "Email: " + user.ContactEmail,
                Font = _emailFont,
                ForeColor = _emailColor,
                AutoSize = false,
                Width = availableContentWidth,
                Height = _emailFont.Height + 4,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true,
                Tag = HOVER_SENSITIVE_TAG
            };
            userCardPanel.Controls.Add(emailLabel);
            currentY += emailLabel.Height + 2;

            // --- Phone Label ---
            Label phoneLabel = new Label
            {
                Text = "Phone: " + user.ContactPhone,
                Font = _phoneFont,
                ForeColor = _phoneColor,
                AutoSize = false,
                Width = availableContentWidth,
                Height = _phoneFont.Height + 4,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true
            };
            userCardPanel.Controls.Add(phoneLabel);
            currentY += phoneLabel.Height + 2;

            // --- Status Label ---
            Label statusLabel = new Label
            {
                Text = "Status: " + user.UserStatus,
                Font = _statusFont,
                ForeColor = GetStatusColor(user.UserStatus),
                AutoSize = false,
                Width = availableContentWidth,
                Height = _statusFont.Height + 4,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true
            };
            userCardPanel.Controls.Add(statusLabel);
            currentY += statusLabel.Height + 2;

            // --- Role Label ---
            Label roleLabel = new Label
            {
                Text = "Role: " + user.UserRole,
                Font = _roleFont,
                ForeColor = _roleColor,
                AutoSize = false,
                Width = availableContentWidth,
                Height = _roleFont.Height + 4,
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true
            };
            userCardPanel.Controls.Add(roleLabel);
            currentY += roleLabel.Height + BOX_INTERNAL_PADDING;

            // --- Add Accept/Reject buttons if needed ---
            if (user.UserStatus == "pending" || user.UserStatus == "accepted" || user.UserStatus == "rejected")
            {
                // Create a panel to hold the buttons for better layout control
                Panel buttonPanel = new Panel
                {
                    Width = availableContentWidth,
                    Height = 30, // Fixed height for button container
                    Location = new Point(contentStartX, currentY)
                };

                Button acceptButton = new Button
                {
                    Text = "Accept",
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 26,
                    Width = 80,
                    Cursor = Cursors.Hand
                };
                acceptButton.FlatAppearance.BorderSize = 0;

                Button rejectButton = new Button
                {
                    Text = "Reject",
                    BackColor = Color.FromArgb(231, 76, 60),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Height = 26,
                    Width = 80,
                    Cursor = Cursors.Hand
                };
                rejectButton.FlatAppearance.BorderSize = 0;

                // Position buttons with proper spacing
                if (user.UserStatus == "pending")
                {
                    acceptButton.Visible = true;
                    rejectButton.Visible = true;

                    // Center both buttons in the available space
                    int totalWidth = acceptButton.Width + rejectButton.Width + BUTTON_SPACING;
                    int startX = (buttonPanel.Width - totalWidth) / 2;

                    acceptButton.Location = new Point(startX, 2);
                    rejectButton.Location = new Point(startX + acceptButton.Width + BUTTON_SPACING, 2);
                }
                else if (user.UserStatus == "accepted")
                {
                    acceptButton.Visible = false;
                    rejectButton.Text = "Reject";
                    rejectButton.Visible = true;
                    rejectButton.Location = new Point((buttonPanel.Width - rejectButton.Width) / 2, 2);
                }
                else if (user.UserStatus == "rejected")
                {
                    acceptButton.Text = "Accept";
                    acceptButton.Visible = true;
                    rejectButton.Visible = false;
                    acceptButton.Location = new Point((buttonPanel.Width - acceptButton.Width) / 2, 2);
                }

                // Attach event handlers
                acceptButton.Click += (sender, e) => AcceptRejectUser(user.RegNo, "accepted");
                rejectButton.Click += (sender, e) => AcceptRejectUser(user.RegNo, "rejected");

                buttonPanel.Controls.Add(acceptButton);
                buttonPanel.Controls.Add(rejectButton);
                userCardPanel.Controls.Add(buttonPanel);
                currentY += buttonPanel.Height + BOX_INTERNAL_PADDING;
            }

            // Set final height
            userCardPanel.Height = Math.Max(MIN_BOX_HEIGHT, currentY);
            containerPanel.Controls.Add(userCardPanel);

            // --- Hover Effect ---
            Dictionary<Control, Color> originalLabelColors = new Dictionary<Control, Color>();
            userCardPanel.MouseEnter += (s, e) =>
            {
                userCardPanel.BackColor = _hoverColor;
                foreach (Control c in userCardPanel.Controls)
                {
                    if (c is Label lbl && c.Tag?.ToString() == HOVER_SENSITIVE_TAG)
                    {
                        if (!originalLabelColors.ContainsKey(lbl))
                        {
                            originalLabelColors[lbl] = lbl.ForeColor;
                        }
                        lbl.ForeColor = _textHoverColor;
                    }
                }
            };

            userCardPanel.MouseLeave += (s, e) =>
            {
                if (userCardPanel.ClientRectangle.Contains(userCardPanel.PointToClient(Cursor.Position)))
                    return;
                userCardPanel.BackColor = _primaryBackColor;
                foreach (var entry in originalLabelColors)
                {
                    entry.Key.ForeColor = entry.Value;
                }
                originalLabelColors.Clear();
            };
        }


        private Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "pending": return _statusColorPending;
                case "accepted": return _statusColorAccepted;
                case "rejected": return _statusColorRejected;
                default: return Color.Black;
            }
        }

        void AcceptRejectUser(string regNo, string newStatus)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(regNo) || string.IsNullOrWhiteSpace(newStatus))
            {
                MessageBox.Show("Registration number and status cannot be empty");
                return;
            }

            // Validate the new status
            if (newStatus != "accepted" && newStatus != "rejected" && newStatus != "pending")
            {
                MessageBox.Show("Invalid status. Must be 'accepted', 'rejected', or 'pending'");
                return;
            }

            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Create SQL command to update user status
                    string sql = @"UPDATE users 
                          SET user_status = @newStatus 
                          WHERE reg_no = @regNo";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@regNo", regNo);
                        command.Parameters.AddWithValue("@newStatus", newStatus);

                        // Execute the update
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"Successfully updated user {regNo} to status: {newStatus}");
                            LogUserStatus(regNo, this.regNo, newStatus);
                            retrieveUsersForApprovals(statusSelectOption.Text);
                        }
                        else
                        {
                            MessageBox.Show($"No user found with registration number: {regNo}");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void Admin_Load(object sender, EventArgs e)


        {


            //mainPanel.Controls.Add(DashboardPanel);
            //mainPanel.Controls.Add(CategoryPanel);
            //mainPanel.Controls.Add(TripReviewPanel);
            //mainPanel.Controls.Add(serviceReviewPanel);



            AddHoverTransition(DashboardButton, DashBoardButtonPanel, DashboardButton.BackColor, Color.Silver, DashboardButton.ForeColor, DashboardButton.ForeColor);
            AddHoverTransition(CategoryButton, CategoryButtonPanel, CategoryButton.BackColor, Color.Silver, CategoryButton.ForeColor, CategoryButton.ForeColor);
            AddHoverTransition(ServiceRevButton, serviceRevButtonPanel, ServiceRevButton.BackColor, Color.Silver, ServiceRevButton.ForeColor, ServiceRevButton.ForeColor);
            AddHoverTransition(UserRevButton, UserRevButtonPanel, UserRevButton.BackColor, Color.Silver, UserRevButton.ForeColor, UserRevButton.ForeColor);
            AddHoverTransition(UserApprovalButton, UserApprovalButtonPanel, UserApprovalButton.BackColor, Color.Silver, UserApprovalButton.ForeColor, UserApprovalButton.ForeColor);
            AddHoverTransition(AddCategoryButton, AddCategoryButton.BackColor, AddCategoryButton.ForeColor, AddCategoryButton.ForeColor, AddCategoryButton.BackColor);
            AddHoverTransition(ApplyButton, ApplyButton.BackColor, ApplyButton.ForeColor, ApplyButton.ForeColor, ApplyButton.BackColor);
            AddHoverTransition(serviceFilerButton, serviceFilerButton.BackColor, serviceFilerButton.ForeColor, serviceFilerButton.ForeColor, serviceFilerButton.BackColor);
            AddHoverTransition(tripFilterButton, tripFilterButton.BackColor, tripFilterButton.ForeColor, tripFilterButton.ForeColor, tripFilterButton.BackColor);

            AddPlaceholder(addCategoryBox, "Add a Category");

            UpdateTotalUsersLabel(TotalUsersNumberLabel, connectionString);
            UpdateActiveUsersLabel(ActiveUsersNumberLabel, connectionString);
            UpdateAverageTripCostLabel(AverageTripCostNumberLabel, connectionString);
            UpdateAverageTripLengthLabel(AverageTripLengthNumber, connectionString);
            UpdateTotalRevenueLabel(TotalRevenueNumberLabel, connectionString);




        }






        private void DashboardButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = true;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = false;
            CategoryPanel.Visible = false;
            UserApprPanel.Visible = false;

            UpdateTotalUsersLabel(TotalUsersNumberLabel, connectionString);
            UpdateActiveUsersLabel(ActiveUsersNumberLabel, connectionString);
            UpdateAverageTripCostLabel(AverageTripCostNumberLabel, connectionString);
            UpdateAverageTripLengthLabel(AverageTripLengthNumber, connectionString);
            UpdateTotalRevenueLabel(TotalRevenueNumberLabel, connectionString);
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = false;
            UserApprPanel.Visible = false;
            CategoryPanel.Visible = true;

            retrieveCategories();
        }

        private void UserRevButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = true;
            CategoryPanel.Visible = false;
            UserApprPanel.Visible = false;

            retrieveTripReviews(tripFlagOption.Text);
        }

        private void ServiceRevButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = true;
            TripReviewPanel.Visible = false;
            CategoryPanel.Visible = false;
            UserApprPanel.Visible = false;

            retrieveServiceReviews(serviceFlagOption.Text);
        }

        private void UserApprovalButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = false;
            CategoryPanel.Visible = false;
            UserApprPanel.Visible = true;

            retrieveUsersForApprovals(statusSelectOption.Text);


        }


        private void retrieveTripReviews(string status)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(status) || (status != "clear" && status != "flagged"))
                {
                    MessageBox.Show("Invalid status. Must be 'clear' or 'flagged'");
                    return;
                }

                // Clear existing controls from panel
                TripReviewDisplayPanel.Controls.Clear();

                // Create connection string (replace with your actual connection string)

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get reviews with traveler names and trip info
                    string sql = @"
                SELECT tr.review_id, tr.trip_id, tr.traveler_id, 
                       tr.rating, tr.description, tr.review_date, tr.flag_status,
                       t.first_name + ' ' + t.last_name AS traveler_name
                FROM trip_reviews tr
                JOIN travelers t ON tr.traveler_id = t.reg_no
                JOIN trips tp ON tr.trip_id = tp.trip_id
                WHERE tr.flag_status = @status
                ORDER BY tr.review_date DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@status", status);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create TripReview object from database record
                                TripReview review = new TripReview(
                                    reviewId: reader["review_id"].ToString(),
                                    tripId: reader["trip_id"].ToString(),
                                    travelerId: reader["traveler_id"].ToString(),
                                    rating: Convert.ToInt32(reader["rating"]),
                                    description: reader["description"].ToString(),
                                    reviewDate: Convert.ToDateTime(reader["review_date"]),
                                    flagStatus: reader["flag_status"].ToString()
                                );

                                string travelerName = reader["traveler_name"].ToString();

                                // Display the review in the panel
                                DisplayTripReviewInPanel(
                                    TripReviewDisplayPanel,
                                    review,
                                    false,
                                    travelerName
                                    );
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void retrieveServiceReviews(string status)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(status) || (status != "clear" && status != "flagged"))
                {
                    MessageBox.Show("Invalid status. Must be 'clear' or 'flagged'");
                    return;
                }

                // Clear existing controls from panel
                ServiceRevDisplayPanel.Controls.Clear();

                // Create connection string (replace with your actual connection string)

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get reviews with traveler names
                    string sql = @"
                SELECT sr.review_id, sr.service_id, sr.user_id, 
                       sr.rating, sr.description, sr.review_date, sr.flag_status,
                       t.first_name + ' ' + t.last_name AS traveler_name
                FROM service_reviews sr
                JOIN travelers t ON sr.user_id = t.reg_no
                WHERE sr.flag_status = @status
                ORDER BY sr.review_date DESC";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@status", status);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create ServiceReview object from database record
                                ServiceReview review = new ServiceReview(
                                    reader["review_id"].ToString(),
                                    reader["service_id"].ToString(),
                                    reader["user_id"].ToString(),
                                    Convert.ToInt32(reader["rating"]),
                                    reader["description"].ToString(),
                                    Convert.ToDateTime(reader["review_date"]),
                                    reader["flag_status"].ToString()
                                );

                                string travelerName = reader["traveler_name"].ToString();

                                // Display the review in the panel
                                DisplayServiceReviewInPanel(
                                    ServiceRevDisplayPanel,
                                    review,
                                    isPublicView: false,
                                    travelerName: travelerName);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void retrieveUsersForApprovals(string status)
        {
            // Validate the status parameter
            if (string.IsNullOrEmpty(status) ||
                !(status.ToLower() == "pending" ||
                  status.ToLower() == "accepted" ||
                  status.ToLower() == "rejected"))
            {
                MessageBox.Show("Invalid status parameter. Must be 'pending', 'accepted', or 'rejected'.");
                return;
            }
            UsersDiplayPanel.Controls.Clear();

            // Clear existing controls if needed (optional)
            // containerPanel.Controls.Clear();

            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    reg_no, 
                    password_hash, 
                    created_date, 
                    last_login, 
                    contact_email, 
                    contact_phone, 
                    user_status, 
                    user_role, 
                    user_profile_image, 
                    user_profile_description
                FROM users 
                WHERE user_status = @status
                ORDER BY created_date DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@status", status.ToLower());

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User user = new User
                                {
                                    RegNo = reader["reg_no"].ToString(),
                                    PasswordHash = reader["password_hash"].ToString(),
                                    CreatedDate = Convert.ToDateTime(reader["created_date"]),
                                    ContactEmail = reader["contact_email"].ToString(),
                                    ContactPhone = reader["contact_phone"].ToString(),
                                    UserStatus = reader["user_status"].ToString(),
                                    UserRole = reader["user_role"].ToString(),
                                    UserProfileImage = reader["user_profile_image"] != DBNull.Value ?
                                                      reader["user_profile_image"].ToString() : null,
                                    UserProfileDescription = reader["user_profile_description"] != DBNull.Value ?
                                                           reader["user_profile_description"].ToString() : null
                                };

                                if (reader["last_login"] != DBNull.Value)
                                {
                                    user.LastLogin = Convert.ToDateTime(reader["last_login"]);
                                }

                                users.Add(user);
                            }
                        }
                    }

                    // Display each user in the container panel
                    foreach (User user in users)
                    {
                        DisplayUser(UsersDiplayPanel, user);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            retrieveUsersForApprovals(statusSelectOption.Text);
        }

        private void serviceFilerButton_Click(object sender, EventArgs e)
        {
            retrieveServiceReviews(serviceFlagOption.Text);

        }

        private void tripFilterButton_Click(object sender, EventArgs e)
        {
            retrieveTripReviews(tripFlagOption.Text);
        }


        // Logs trip review status changes
        private void LogTripRevStatus(string reviewId, string adminId, string newStatus, string reason = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get next log ID using the counter table
                    string logId = GetNextRegNo("TRL");

                    string sql = @"INSERT INTO trip_review_logs 
                         (log_id, review_id, admin_id, log_time, action, reason)
                         VALUES 
                         (@logId, @reviewId, @adminId, GETDATE(), @action, @reason)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@logId", logId);
                        command.Parameters.AddWithValue("@reviewId", reviewId);
                        command.Parameters.AddWithValue("@adminId", adminId);
                        command.Parameters.AddWithValue("@action", newStatus);
                        command.Parameters.AddWithValue("@reason", reason ?? $"Status changed to {newStatus}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging trip review status change: {ex.Message}");
                // Consider throwing or handling differently based on your needs
            }
        }

        // Logs service review status changes
        private void LogServiceRevStatus(string reviewId, string adminId, string newStatus, string reason = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get next log ID using the counter table
                    string logId = GetNextRegNo("TRL"); // Assuming same prefix for service review logs

                    string sql = @"INSERT INTO service_review_logs 
                         (log_id, review_id, admin_id, log_time, action, reason)
                         VALUES 
                         (@logId, @reviewId, @adminId, GETDATE(), @action, @reason)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@logId", logId);
                        command.Parameters.AddWithValue("@reviewId", reviewId);
                        command.Parameters.AddWithValue("@adminId", adminId);
                        command.Parameters.AddWithValue("@action", newStatus);
                        command.Parameters.AddWithValue("@reason", reason ?? $"Status changed to {newStatus}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging service review status change: {ex.Message}");
            }
        }

        // Logs user status changes
        private void LogUserStatus(string userId, string adminId, string newStatus, string reason = null)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get next log ID using the counter table
                    string logId = GetNextRegNo("UAL");

                    string sql = @"INSERT INTO user_approval_logs 
                         (log_id, user_id, admin_id, log_time, action, reason)
                         VALUES 
                         (@logId, @userId, @adminId, GETDATE(), @action, @reason)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@logId", logId);
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@adminId", adminId);
                        command.Parameters.AddWithValue("@action", newStatus);
                        command.Parameters.AddWithValue("@reason", reason ?? $"Status changed to {newStatus}");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error logging user status change: {ex.Message}");
            }
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

        private void retrieveCategories()
        {
            try
            {
                // Clear existing controls from panel
                CategoryDisplayPanel.Controls.Clear();

                // Create connection string (replace with your actual connection string)

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to get all categories
                    string sql = "SELECT id, category_name FROM Category ORDER BY category_name";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Create Category object from database record
                                Category category = new Category(
                                   reader["id"].ToString(),
                                   reader["category_name"].ToString()
                               );

                                // Display the category in the panel
                                AddCategoryToPanel(CategoryDisplayPanel, category);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void AddCategoryButton_Click(object sender, EventArgs e)
        {
            string categoryName = addCategoryBox.Text.Trim();

            // Validate input
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                MessageBox.Show("Please enter a category name");
                return;
            }

            try
            {
                // Generate the category ID
                string categoryId = GetNextRegNo("CAT");

                // Create connection string (replace with your actual connection string)

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL command to insert new category
                    string sql = "INSERT INTO Category (id, category_name) VALUES (@id, @name)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", categoryId);
                        command.Parameters.AddWithValue("@name", categoryName);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Category added successfully!");
                            addCategoryBox.Text = ""; // Clear the input field
                            retrieveCategories(); // Refresh the category list
                        }
                        else
                        {
                            MessageBox.Show("Failed to add category");
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    MessageBox.Show("A category with this name already exists");
                }
                else
                {
                    MessageBox.Show($"Database error: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }




        private static object ExecuteScalar(string connectionString, string query)
        {
            object result = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        result = command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error executing query: {ex.Message}");
                // Optionally log the error: Log.Error($"SQL Error: {ex.Message}\nQuery: {query}");
                result = null; // Indicate error by returning null
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error executing query: {ex.Message}");
                // Optionally log the error
                result = null; // Indicate error by returning null
            }
            return result;
        }

        public static void UpdateTotalUsersLabel(Label targetLabel, string connectionString)
        {
            string query = "SELECT COUNT(*) FROM users;";
            object result = ExecuteScalar(connectionString, query);

            if (result != null && result != DBNull.Value)
            {
                targetLabel.Text = Convert.ToInt32(result).ToString();
            }
            else
            {
                targetLabel.Text = "Error"; // Or "0" if preferred on error
            }
        }

        public static void UpdateActiveUsersLabel(Label targetLabel, string connectionString)
        {
            // Users whose last_login is not null and is within the last 20 days
            string query = "SELECT COUNT(*) FROM users WHERE last_login IS NOT NULL AND last_login >= DATEADD(day, -365, GETDATE());";
            object result = ExecuteScalar(connectionString, query);

            if (result != null && result != DBNull.Value)
            {
                targetLabel.Text = Convert.ToInt32(result).ToString();
            }
            else
            {
                targetLabel.Text = "Error"; // Or "0"
            }
        }

        public static void UpdateTotalRevenueLabel(Label targetLabel, string connectionString)
        {
            // Sum of price_per_person from trips associated with 'confirmed' bookings
            string query = @"
            SELECT SUM(t.price_per_person)
            FROM bookings b
            JOIN trips t ON b.trip_id = t.trip_id
            WHERE b.booking_status = 'confirmed';";

            object result = ExecuteScalar(connectionString, query);

            if (result != null && result != DBNull.Value)
            {
                decimal totalRevenue = Convert.ToDecimal(result);
                // Format as currency (e.g., $1,234.56 or use specific culture)
                targetLabel.Text = totalRevenue.ToString("C", CultureInfo.CurrentCulture);
            }
            else if (result == DBNull.Value)
            {
                // No confirmed bookings found, revenue is 0
                targetLabel.Text = 0.ToString("C", CultureInfo.CurrentCulture);
            }
            else // result was null, indicating an error from ExecuteScalar
            {
                targetLabel.Text = "Error";
            }
        }

        public static void UpdateAverageTripCostLabel(Label targetLabel, string connectionString)
        {
            string query = "SELECT AVG(price_per_person) FROM trips;";
            object result = ExecuteScalar(connectionString, query);

            if (result != null && result != DBNull.Value)
            {
                decimal avgCost = Convert.ToDecimal(result);
                // Format as currency
                targetLabel.Text = avgCost.ToString("C", CultureInfo.CurrentCulture);
            }
            else if (result == DBNull.Value)
            {
                // No trips found
                targetLabel.Text = "N/A"; // Or 0 formatted as currency
            }
            else
            {
                targetLabel.Text = "Error";
            }
        }

        public static void UpdateAverageTripLengthLabel(Label targetLabel, string connectionString)
        {
            // Cast duration to decimal for accurate average calculation
            string query = "SELECT AVG(CAST(duration AS DECIMAL(10,2))) FROM trips;";
            object result = ExecuteScalar(connectionString, query);

            if (result != null && result != DBNull.Value)
            {
                decimal avgLength = Convert.ToDecimal(result);
                // Format to one decimal place and add " days"
                targetLabel.Text = $"{avgLength:F1} days";
            }
            else if (result == DBNull.Value)
            {
                // No trips found
                targetLabel.Text = "N/A"; // Or "0.0 days"
            }
            else
            {
                targetLabel.Text = "Error";
            }
        }

        private void ReportViewButton_Click(object sender, EventArgs e)
        {
            ShowReportDetails();
        }

        private void ShowReportDetails()
        {
            if (selectReportComboBox.SelectedIndex >= 0 && selectReportComboBox.SelectedIndex < reportList.Count)
            {

                if (!CompleteReportPanel.Visible)
                {
                    // Add CompleteReportPanel to the current form controls if not already
                    if (!this.Controls.Contains(CompleteReportPanel))
                    {
                        this.Controls.Add(CompleteReportPanel);
                    }

                    CompleteReportPanel.BringToFront();
                    CompleteReportPanel.Visible = true;
                    // Set size and location relative to the main form
                    CompleteReportPanel.Size = new Size(this.ClientSize.Width - 80, this.ClientSize.Height - 80);
                    CompleteReportPanel.Location = new Point(40, 40);
                    CompleteReportPanel.Controls.Clear(); // Clear any existing controls

                    // Assuming the order in reportList corresponds to your reportType cases (1-based)
                    int selectedReportIndex = selectReportComboBox.SelectedIndex;
                    int reportTypeToPass = selectedReportIndex + 1; // Adjust if your mapping is different

                    var rep = new ReportsForm(reportTypeToPass);
                    rep.Dock = DockStyle.Fill;
                    rep.TopLevel = false;
                    rep.FormBorderStyle = FormBorderStyle.None;
                    rep.BackColor = Color.White;
                    CompleteReportPanel.Controls.Add(rep);
                    rep.Show();
                    rep.BringToFront();
                    AddCloseButtonToPanel(CompleteReportPanel);
                }
            }
            else
            {
                MessageBox.Show("Please select a report from the list.");
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
            };

            panel.Controls.Add(closeButton);
            closeButton.BringToFront();
        }
    }
}