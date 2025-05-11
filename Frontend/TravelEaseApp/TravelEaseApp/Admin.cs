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

namespace TravelEaseApp
{
    public partial class Admin : Form
    {
        string regNo;
        Label hiddenLabel;

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
                    Button clickedButton = s as Button;
                    ServiceReview targetReview = clickedButton?.Tag as ServiceReview;
                    if (targetReview != null)
                    {
                        targetReview.FlagStatus = (targetReview.FlagStatus == "clear" ? "flagged" : "clear");
                        lblFlagStatus.Text = $"Status: {targetReview.FlagStatus.ToUpper()}";
                        lblFlagStatus.ForeColor = targetReview.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor;
                        clickedButton.Text = targetReview.FlagStatus == "clear" ? "Flag Review" : "Unflag Review";
                        clickedButton.BackColor = targetReview.FlagStatus == "clear" ? buttonFlagColor : buttonUnflagColor;
                        currentAccentColor = targetReview.FlagStatus == "clear" ? flagClearColor : flagFlaggedColor;
                        reviewCard.Invalidate();

                        MessageBox.Show($"Review '{targetReview.ReviewId}' status changed to '{targetReview.FlagStatus}'.\n(This change is local; backend update needed in a real app.)",
                                        "Flag Status Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (category == null) throw new ArgumentNullException(nameof(category));

            // --- Calculate Box Width ---
            int boxWidth = containerPanel.Width - (2 * HORIZONTAL_PAGE_PADDING);
            if (boxWidth < 250) boxWidth = 250; // Min width for a category entry

            // --- Create the main category Panel (categoryCardPanel) ---
            Panel categoryCardPanel = new Panel
            {
                Width = boxWidth,
                BackColor = _primaryBackColor,
                Padding = new Padding(BOX_INTERNAL_PADDING),
                Margin = new Padding(HORIZONTAL_PAGE_PADDING, 0, HORIZONTAL_PAGE_PADDING, VERTICAL_SPACING),
                // Tag = category, // Optionally store the category object itself for click events
            };

            // --- Determine Y position for the new card ---
            int yPositionInContainer = VERTICAL_SPACING;
            if (containerPanel.Controls.Count > 0)
            {
                Control lastControl = containerPanel.Controls[containerPanel.Controls.Count - 1];
                yPositionInContainer = lastControl.Bottom + VERTICAL_SPACING;
            }
            categoryCardPanel.Location = new Point(HORIZONTAL_PAGE_PADDING, yPositionInContainer);

            // --- Paint event for border and left accent bar ---
            categoryCardPanel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // For smoother drawing

                // Option 1: Simple Border (like TransactionUIBuilder)
                ControlPaint.DrawBorder(e.Graphics, categoryCardPanel.ClientRectangle,
                    _borderColor, 1, ButtonBorderStyle.Solid,
                    _borderColor, 1, ButtonBorderStyle.Solid,
                    _borderColor, 1, ButtonBorderStyle.Solid,
                    _borderColor, 1, ButtonBorderStyle.Solid);

                // Option 2: Rounded Border (Uncomment to use - requires GetRoundedRect method)
                // using (GraphicsPath path = GetRoundedRect(new Rectangle(0,0, categoryCardPanel.Width-1, categoryCardPanel.Height-1), 6)) // 6px radius
                // using (Pen borderPen = new Pen(_borderColor, 1))
                // {
                //     e.Graphics.DrawPath(borderPen, path);
                // }


                // Draw the accent bar
                using (SolidBrush accentBrush = new SolidBrush(_accentColorCategory))
                {
                    // Option 1: Simple Accent Bar
                    e.Graphics.FillRectangle(accentBrush, 0, 0, ACCENT_BAR_WIDTH, categoryCardPanel.Height);

                    // Option 2: Rounded Accent Bar (if using rounded panel)
                    // Rectangle accentRect = new Rectangle(0, 0, ACCENT_BAR_WIDTH + 3, categoryCardPanel.Height);
                    // using (GraphicsPath accentPath = GetRoundedRect(accentRect, 6)) // Match panel radius
                    // {
                    //      Region oldClip = e.Graphics.Clip;
                    //      e.Graphics.Clip = new Region(new Rectangle(0,0, ACCENT_BAR_WIDTH, categoryCardPanel.Height)); // Clip to only left part
                    //      e.Graphics.FillPath(accentBrush, accentPath);
                    //      e.Graphics.Clip = oldClip;
                    // }
                }
            };

            // --- Initialize Layout Variables ---
            int currentY = BOX_INTERNAL_PADDING;
            // Start X after accent bar and a little space, plus the main panel's internal padding
            int contentStartX = BOX_INTERNAL_PADDING + ACCENT_BAR_WIDTH + 8;
            int availableContentWidth = categoryCardPanel.Width - contentStartX - BOX_INTERNAL_PADDING;

            // --- Category Name ---
            Label lblCategoryName = new Label
            {
                Text = category.CategoryName,
                Font = _categoryNameFont,
                ForeColor = _categoryNameColor,
                AutoSize = false, // To enable AutoEllipsis and control width
                Width = availableContentWidth,
                Height = _categoryNameFont.Height + 4, // Add some padding for descenders
                Location = new Point(contentStartX, currentY),
                AutoEllipsis = true,
                Tag = HOVER_SENSITIVE_TAG
            };
            categoryCardPanel.Controls.Add(lblCategoryName);
            currentY += lblCategoryName.Height + 2; // Small gap

            // --- Category ID ---
            Label lblCategoryId = new Label
            {
                Text = $"ID: {category.Id}",
                Font = _categoryIdFont,
                ForeColor = _categoryIdColor,
                AutoSize = true,
                Location = new Point(contentStartX, currentY),
                Tag = HOVER_SENSITIVE_TAG
            };
            categoryCardPanel.Controls.Add(lblCategoryId);
            currentY += lblCategoryId.Height + BOX_INTERNAL_PADDING; // Add bottom padding

            // --- Set final height for the category card ---
            categoryCardPanel.Height = Math.Max(MIN_BOX_HEIGHT, currentY);

            // --- Add Hover Effect (Self-Contained) ---
            Dictionary<Control, Color> originalLabelColors = new Dictionary<Control, Color>();

            categoryCardPanel.MouseEnter += (s, e) =>
            {
                categoryCardPanel.BackColor = _hoverColor;
                // Example: Change text color on hover.
                // Iterate through direct children that are labels and tagged.
                foreach (Control c in categoryCardPanel.Controls)
                {
                    if (c is Label lbl && c.Tag?.ToString() == HOVER_SENSITIVE_TAG)
                    {
                        if (!originalLabelColors.ContainsKey(lbl))
                        {
                            originalLabelColors[lbl] = lbl.ForeColor;
                        }
                        lbl.ForeColor = _textHoverColor; // Change to hover text color
                    }
                }
            };

            categoryCardPanel.MouseLeave += (s, e) =>
            {
                if (categoryCardPanel.ClientRectangle.Contains(categoryCardPanel.PointToClient(Cursor.Position)))
                    return;

                categoryCardPanel.BackColor = _primaryBackColor;
                foreach (var entry in originalLabelColors)
                {
                    entry.Key.ForeColor = entry.Value; // Restore original text color
                }
                originalLabelColors.Clear();
            };

            //// Propagate MouseEnter/Leave to child labels to trigger parent's hover
            //foreach (Control childControl in categoryCardPanel.Controls)
            //{
            //    childControl.MouseEnter += (s, e) => categoryCardPanel.OnMouseEnter(e);
            //    childControl.MouseLeave += (s, e) => categoryCardPanel.OnMouseLeave(e);
            //}

            // --- Add to container ---
            containerPanel.Controls.Add(categoryCardPanel);

            // --- Auto-scroll logic ---
            if (containerPanel.Parent is Form || containerPanel.AutoScroll)
            {
                categoryCardPanel.Visible = true;
                containerPanel.ScrollControlIntoView(categoryCardPanel);
            }
        }




        private void Admin_Load(object sender, EventArgs e)
        {
            AddHoverTransition(DashboardButton, DashBoardButtonPanel, DashboardButton.BackColor, Color.Silver, DashboardButton.ForeColor, DashboardButton.ForeColor);
            AddHoverTransition(CategoryButton, CategoryButtonPanel, CategoryButton.BackColor, Color.Silver, CategoryButton.ForeColor, CategoryButton.ForeColor);
            AddHoverTransition(ServiceRevButton, serviceRevButtonPanel, ServiceRevButton.BackColor, Color.Silver, ServiceRevButton.ForeColor, ServiceRevButton.ForeColor);
            AddHoverTransition(UserRevButton, UserRevButtonPanel, UserRevButton.BackColor, Color.Silver, UserRevButton.ForeColor, UserRevButton.ForeColor);

            AddHoverTransition(AddCategoryButton, AddCategoryButton.BackColor, AddCategoryButton.ForeColor, AddCategoryButton.ForeColor, AddCategoryButton.BackColor);
            AddPlaceholder(addCategoryBox, "Add a Category");
            TripReview review1 = new TripReview("TRVW-000001", "TRIP-123", "USER-001", 5, "This was an absolutely amazing experience! The sights were breathtaking and the guide was fantastic.", DateTime.Now.AddDays(-7));
            TripReview review2 = new TripReview("TRVW-000002", "TRIP-456", "USER-002", 3, "The trip was okay, but the hotel could have been better. Some aspects felt rushed.", DateTime.Now.AddDays(-3), "clear");

            ServiceReview serviceReview1 = new ServiceReview("SRVW-000001", "SRVC-789", "USER-003", 4, "The service was great, but there is room for improvement.", DateTime.Now.AddDays(-5), "clear");

            Category category1 = new Category("CAT-00001", "Adventurous");
            Category category2 = new Category("CAT-00002", "Relaxation");
            Category category3 = new Category("CAT-00003", "Cultural");
            Category category4 = new Category("CAT-00004", "Family");
            Category category5 = new Category("CAT-00005", "Romantic");
            Category category6 = new Category("CAT-00006", "Luxury");
            Category category7 = new Category("CAT-00007", "Budget");
            Category category8 = new Category("CAT-00008", "Nature");
            Category category9 = new Category("CAT-00009", "Adventure Sports");
            Category category10 = new Category("CAT-00010", "Historical");
            Category category11 = new Category("CAT-00011", "Wellness");

            DisplayTripReviewInPanel(TripReviewDisplayPanel, review1, true);
            DisplayTripReviewInPanel(TripReviewDisplayPanel, review2, false);
            DisplayServiceReviewInPanel(ServiceRevDisplayPanel, serviceReview1, true);

            AddCategoryToPanel(CategoryDisplayPanel, category1);
            AddCategoryToPanel(CategoryDisplayPanel, category2);
            AddCategoryToPanel(CategoryDisplayPanel, category3);
            AddCategoryToPanel(CategoryDisplayPanel, category4);
            AddCategoryToPanel(CategoryDisplayPanel, category5);
            AddCategoryToPanel(CategoryDisplayPanel, category6);
            AddCategoryToPanel(CategoryDisplayPanel, category7);
            AddCategoryToPanel(CategoryDisplayPanel, category8);
            AddCategoryToPanel(CategoryDisplayPanel, category9);
            AddCategoryToPanel(CategoryDisplayPanel, category10);
            AddCategoryToPanel(CategoryDisplayPanel, category11);
        }

        private void DashboardButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = true;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = false;
            CategoryPanel.Visible = false;
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = false;
            CategoryPanel.Visible = true;
        }

        private void UserRevButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = false;
            TripReviewPanel.Visible = true;
            CategoryPanel.Visible = false;
        }

        private void ServiceRevButton_Click(object sender, EventArgs e)
        {
            DashboardPanel.Visible = false;
            serviceReviewPanel.Visible = true;
            TripReviewPanel.Visible = false;
            CategoryPanel.Visible = false;
        }
    }
}
