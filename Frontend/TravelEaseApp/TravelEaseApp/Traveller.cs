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
            AddTripBox(TripDisplayPanel, "AN EXQUISITE JOURNEY", "a very long logn long adlkjf description", "Kashmir", "2025-12-12", "2024-12-23", "5 Days", 5, "Active", "Adventurous", 23.80f, "https://ibb.co/FbBy9qYX", "TAYYAB GROUP & SONS");
            AddTripBox(TripDisplayPanel, "AN EXQUISITE JOURNEY", "a very long logn long adlkjf description", "Kashmir", "2025-12-12", "2024-12-23", "5 Days", 5, "Active", "Adventurous", 23.80f, "" ,"TAYYAB GROUP & SONS");
            AddTripBox(TripDisplayPanel, "AN EXQUISITE JOURNEY", "a very long logn long adlkjf description", "Kashmir", "2025-12-12", "2024-12-23", "5 Days", 5, "Active", "Adventurous", 23.80f, "","TAYYAB GROUP & SONS");


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


        public void AddTripBox(
           Panel containerPanel,
           string title,
           string description,
           string startLocationName,
           string startDate,
           string endDate,
           string duration, // e.g., "7 days", "2 nights"
           int capacity,
           string status, // "active", "cancelled", "completed"
           string category,
           float pricePerPerson,
           string imageUrl,
           string operatorName)
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

            if (!string.IsNullOrWhiteSpace(imageUrl))
            {
                if (imageUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) || File.Exists(imageUrl))
                {
                    tripImage.LoadAsync(imageUrl); // Async loading for web URLs. No try-catch here.
                }
                //else: If not a web URL or existing file, no image will be loaded.
                //You might want to set a default image here if the path / URL is invalid
                //e.g., tripImage.Image = YourApp.Properties.Resources.DefaultImage;
            }


            // --- Content Panel (to the right of the image) ---
            Panel contentPanel = new Panel
            {
                Location = new Point(tripImage.Right + boxInternalPadding, boxInternalPadding),
                Width = tripBox.Width - tripImage.Width - (boxInternalPadding * 3) - 6,
                Height = imageHeight,
                BackColor = Color.Transparent
            };

            // --- Title Label ---
            Label lblTitle = new Label
            {
                Text = title,
                Font = titleFont,
                ForeColor = titleColor,
                AutoSize = false,
                Width = contentPanel.Width - 85,
                Height = titleFont.Height + 4,
                Location = new Point(0, 0),
                AutoEllipsis = true
            };

            // --- Status Panel (visual badge) ---
            Panel pnlStatus = new Panel
            {
                Height = 22,
                AutoSize = true,
                Padding = new Padding(8, 0, 8, 0)
                // Location set after determining width
            };
            Label lblStatusText = new Label
            {
                Text = status.ToUpper(),
                Font = statusFont,
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                AutoSize = false
            };
            pnlStatus.Controls.Add(lblStatusText);
            pnlStatus.MinimumSize = new Size(70, 22);

            switch (status.ToLower())
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


            // --- Description Label ---
            Label lblDescription = new Label
            {
                Text = description,
                Font = textFont,
                ForeColor = textColor,
                AutoSize = false,
                Width = contentPanel.Width,
                Height = 38,
                Location = new Point(0, lblTitle.Bottom + 6),
                AutoEllipsis = true
            };

            // --- Dates and Location Label ---
            Label lblDatesAndLocation = new Label
            {
                Text = $"📍 {startLocationName}\n🗓️ {startDate:MMM dd, yyyy} - {endDate:MMM dd, yyyy}",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(0, lblDescription.Bottom + 8)
            };

            // --- Duration and Category ---
            Label lblDurationCategory = new Label
            {
                Text = $"⏳ {duration}   |   🏷️ {category}",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(0, lblDatesAndLocation.Bottom + 8)
            };

            // --- Capacity Label ---
            Label lblCapacity = new Label
            {
                Text = $"👥 Capacity: {capacity} guests",
                Font = textFont,
                ForeColor = subtleTextColor,
                AutoSize = true,
                Location = new Point(0, lblDurationCategory.Bottom + 8)
            };

            // --- Price Label ---
            Label lblPrice = new Label
            {
                Text = $"{pricePerPerson:C}",
                Font = priceFont,
                ForeColor = priceColor,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleRight,
                Width = (int)(contentPanel.Width * 0.4),
                Height = priceFont.Height + 4,
                Location = new Point(contentPanel.Width - (int)(contentPanel.Width * 0.4), contentPanel.Height - priceFont.Height - 4)
            };

            // --- Operator Name Label ---
            Label lblOperator = new Label
            {
                Text = $"Operator: {operatorName}",
                Font = smallTextFont,
                ForeColor = accentColor,
                AutoSize = false,
                AutoEllipsis = true,
                Width = contentPanel.Width - lblPrice.Width - 10,
                Height = smallTextFont.Height + 2,
                Location = new Point(0, contentPanel.Height - smallTextFont.Height - 6)
            };

            // --- Add controls to respective panels ---
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

            // --- Add hover effect ---
            //AddHoverTransition(tripBox, primaryBackColor, hoverColor);
            foreach (Control ctl in contentPanel.Controls)
            {
                if (ctl is Label) ctl.BackColor = Color.Transparent;
                // Pass through mouse events for labels if they cover the panel
                ctl.MouseEnter += (s, e) => tripBox.BackColor = hoverColor;
                ctl.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;
            }
            tripImage.MouseEnter += (s, e) => tripBox.BackColor = hoverColor; // Image also triggers parent hover
            tripImage.MouseLeave += (s, e) => tripBox.BackColor = primaryBackColor;


            // --- Add the tripBox to the containerPanel ---
            containerPanel.Controls.Add(tripBox);
            containerPanel.ScrollControlIntoView(tripBox);
            
        }
    }
}