using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static TravelEaseApp.Helpers;
using System.Configuration.Provider;

namespace TravelEaseApp
{
    public static class Helpers
    {
        public static string connectionString = "Data Source=BLAZ\\SQLEXPRESS;Initial Catalog=ViewsBackupV2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public static void AddPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Gray;

            textBox.GotFocus += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    // Optional: Set font to regular
                    // textBox.Font = new Font(textBox.Font, FontStyle.Regular);
                }
            };

            textBox.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        public static int SmoothTransition(int current, int target)
        {
            int diff = target - current;
            if (Math.Abs(diff) < 3)
                return target;
            return current + diff / 5;
        }

        public static void AddHoverTransition(
            Control control,
            Color normalBackColor,
            Color hoverBackColor,
            Color normalTextColor,
            Color hoverTextColor)
        {
            Color currentBackColor = normalBackColor;
            Color currentTextColor = normalTextColor;
            bool isHovering = false;

            control.BackColor = normalBackColor;
            control.ForeColor = normalTextColor;

            System.Windows.Forms.Timer hoverTimer = new System.Windows.Forms.Timer();

            hoverTimer.Interval = 15;
            hoverTimer.Tick += (s, e) =>
            {
                Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
                int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
                int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
                int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
                currentBackColor = Color.FromArgb(rBack, gBack, bBack);

                Color targetTextColor = isHovering ? hoverTextColor : normalTextColor;
                int rText = SmoothTransition(currentTextColor.R, targetTextColor.R);
                int gText = SmoothTransition(currentTextColor.G, targetTextColor.G);
                int bText = SmoothTransition(currentTextColor.B, targetTextColor.B);
                currentTextColor = Color.FromArgb(rText, gText, bText);

                control.BackColor = currentBackColor;
                control.ForeColor = currentTextColor;
            };
            hoverTimer.Start();

            // Unified hover detection for control and children
            void AttachHoverHandlers(Control target)
            {
                target.MouseEnter += (s, e) => isHovering = true;
                target.MouseLeave += (s, e) =>
                {
                    Point mousePos = control.PointToClient(Cursor.Position);
                    if (!control.ClientRectangle.Contains(mousePos))
                    {
                        isHovering = false;
                    }
                };

                foreach (Control child in target.Controls)
                {
                    AttachHoverHandlers(child); // Recursive for nested children
                }
            }

            AttachHoverHandlers(control);
        }


        public static void AddHoverTransition(Control triggerControl, Control targetControl, Color normalBackColor, Color hoverBackColor, Color normalTextColor, Color hoverTextColor)
        {
            Color currentBackColor = normalBackColor;
            Color currentTextColor = normalTextColor;
            bool isHovering = false;

            targetControl.BackColor = normalBackColor;
            targetControl.ForeColor = normalTextColor;

            System.Windows.Forms.Timer hoverTimer = new System.Windows.Forms.Timer();
            hoverTimer.Interval = 15;
            hoverTimer.Tick += (s, e) =>
            {
                Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
                int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
                int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
                int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
                currentBackColor = Color.FromArgb(rBack, gBack, bBack);

                Color targetTextCol = isHovering ? hoverTextColor : normalTextColor;
                int rText = SmoothTransition(currentTextColor.R, targetTextCol.R);
                int gText = SmoothTransition(currentTextColor.G, targetTextCol.G);
                int bText = SmoothTransition(currentTextColor.B, targetTextCol.B);
                currentTextColor = Color.FromArgb(rText, gText, bText);

                targetControl.BackColor = currentBackColor;
                targetControl.ForeColor = currentTextColor;
            };
            hoverTimer.Start();

            triggerControl.MouseEnter += (s, e) => isHovering = true;
            triggerControl.MouseLeave += (s, e) => isHovering = false;
        }


        public static void SetupGroupBoxFocusBehavior(GroupBox groupBox, TextBox innerTextBox)
        {
            groupBox.Enter += (s, e) => innerTextBox.Focus();

            groupBox.MouseEnter += (s, e) =>
            {
                groupBox.Cursor = Cursors.IBeam;
            };

            groupBox.MouseLeave += (s, e) =>
            {
                groupBox.Cursor = Cursors.Default;
            };

            groupBox.MouseClick += (s, e) =>
            {
                innerTextBox.Focus();
            };
            groupBox.Click += (s, e) =>
            {
                innerTextBox.Focus();
            };
        }

        public static void SetupPasswordField(GroupBox groupBox, TextBox textBox, PictureBox visibilityIcon, Image showIcon, Image hideIcon)
        {
            // Visibility toggle
            visibilityIcon.Cursor = Cursors.Hand;
            visibilityIcon.Click += (s, e) =>
            {
                bool isHidden = textBox.UseSystemPasswordChar;
                textBox.UseSystemPasswordChar = !isHidden;
                visibilityIcon.Image = isHidden ? hideIcon : showIcon;
            };

            // Focus textbox when groupbox is entered or clicked
            groupBox.Enter += (s, e) => textBox.Focus();
            groupBox.MouseClick += (s, e) => textBox.Focus();

            // Cursor changes
            groupBox.MouseEnter += (s, e) => groupBox.Cursor = Cursors.IBeam;
            groupBox.MouseLeave += (s, e) => groupBox.Cursor = Cursors.Default;
        }

        //users class]using System;

        public class User
        {
            public string RegNo { get; set; } // e.g., TR-123456, OP-123456
            public string PasswordHash { get; set; }
            public DateTime CreatedDate { get; set; } = DateTime.Now;
            public DateTime? LastLogin { get; set; }
            public string ContactEmail { get; set; }
            public string ContactPhone { get; set; }
            public string UserStatus { get; set; } // "rejected", "accepted", "pending"
            public string UserRole { get; set; } // "traveler", "admin", etc.
            public string? UserProfileImage { get; set; }
            public string? UserProfileDescription { get; set; }

            // Optional: Add validation methods if needed
            public bool IsValidRegNo()
            {
                return System.Text.RegularExpressions.Regex.IsMatch(RegNo, @"^(TR|OP|SP|AD)-\d{6}$");
            }

            public bool IsValidEmail()
            {
                return System.Text.RegularExpressions.Regex.IsMatch(ContactEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }

            public bool IsValidPhone()
            {
                return System.Text.RegularExpressions.Regex.IsMatch(ContactPhone, @"^(\+?\d{10,15}|0\d{9,14}|92\d{9,13}|3\d{9})$");
            }
        }



        // --- Location Class ---
        public class Location
        {
            public string DestId { get; set; } // e.g., "ASI-000001"
            public string DestinationName { get; set; }
            public string City { get; set; }
            public string Region { get; set; } // Continent name
            public string Country { get; set; }

            public override string ToString()
            {
                return $"{DestinationName}, {City}, {Country}";
            }
        }
        //serviceReview class
        public class ServiceReview
        {
            public string ReviewId { get; set; }            // Format: SRVW-000001
            public string ServiceId { get; set; }           // Foreign key to services
            public string TravelerId { get; set; }          // Foreign key to travelers
            public int Rating { get; set; }                 // 1 to 5
            public string Description { get; set; }
            public DateTime ReviewDate { get; set; } = DateTime.Now;
            public string FlagStatus { get; set; } = "clear";

            public ServiceReview()
            {
                // Default constructor
            }
            public ServiceReview(string reviewId, string serviceId, string travelerId, int rating,
                                 string description, DateTime? reviewDate = null, string flagStatus = "clear")
            {
                ReviewId = reviewId;
                ServiceId = serviceId;
                TravelerId = travelerId;
                Rating = rating;
                Description = description;
                ReviewDate = reviewDate ?? DateTime.Now;
                FlagStatus = flagStatus;
            }

            public bool IsValidReviewId() => Regex.IsMatch(ReviewId, @"^SRVW-\d{6}$");
            public bool IsValidRating() => Rating >= 1 && Rating <= 5;
            public bool IsValidFlagStatus() => FlagStatus == "clear" || FlagStatus == "flagged";

            public bool IsValid() => IsValidReviewId() && IsValidRating() && IsValidFlagStatus();

            public override string ToString()
            {
                return $"ServiceReview [{ReviewId}] - {Rating}⭐ by Traveler {TravelerId}";
            }
        }

        public class TripReview
        {
            public string ReviewId { get; set; }            // Format: TRVW-000001
            public string TripId { get; set; }              // Foreign key to trips
            public string TravelerId { get; set; }          // Foreign key to travelers
            public int Rating { get; set; }                 // 1 to 5
            public string Description { get; set; }
            public DateTime ReviewDate { get; set; } = DateTime.Now;
            public string FlagStatus { get; set; } = "clear";

            public TripReview(string reviewId, string tripId, string travelerId, int rating,
                              string description, DateTime? reviewDate = null, string flagStatus = "clear")
            {
                ReviewId = reviewId;
                TripId = tripId;
                TravelerId = travelerId;
                Rating = rating;
                Description = description;
                ReviewDate = reviewDate ?? DateTime.Now;
                FlagStatus = flagStatus;
            }

            public bool IsValidReviewId() => Regex.IsMatch(ReviewId, @"^TRVW-\d{6}$");
            public bool IsValidRating() => Rating >= 1 && Rating <= 5;
            public bool IsValidFlagStatus() => FlagStatus == "clear" || FlagStatus == "flagged";

            public bool IsValid() => IsValidReviewId() && IsValidRating() && IsValidFlagStatus();

            public override string ToString()
            {
                return $"TripReview [{ReviewId}] - {Rating}⭐ for Trip {TripId}";
            }
        }



        // --- Service Class ---
        public class Service
        {
            public string ServiceId { get; set; }           // e.g., "SRV-000001"
            public string ServiceType { get; set; }         // 'hotel', 'transport', 'guide', 'activity', 'other'
            public string ServiceDescription { get; set; }
            public decimal Price { get; set; }
            public string ProviderId { get; set; }          // FK to provider
            public string ProviderName { get; set; }        // Display only
            public int Capacity { get; set; }
            public double AverageReview { get; set; }       // Star rating (1.0 to 5.0)

            public List<ServiceReview> Reviews { get; set; }

            public Service()
            {
                ProviderName = "N/A";
                Reviews = new List<ServiceReview>();
            }

            // ✅ Add a review and update average
            public bool AddReview(ServiceReview review)
            {
                if (review == null || !review.IsValid())
                    return false;

                Reviews.Add(review);
                UpdateAverageReview();
                return true;
            }

            // ✅ Recalculate the average rating
            public void UpdateAverageReview()
            {
                if (Reviews.Count > 0)
                    AverageReview = Math.Round(Reviews.Average(r => r.Rating), 2);
                else
                    AverageReview = 0;
            }

            public override string ToString()
            {
                return $"{ServiceType.ToUpper()} Service [{ServiceId}] by {ProviderName} - ★ {AverageReview} ({Reviews.Count} reviews)";
            }
        }



        // --- Trip Class ---
        public class Trip
        {
            public string TripId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public int Capacity { get; set; }
            public int DurationDays { get; set; }
            public string DurationDisplay { get; set; }
            public string Category { get; set; }
            public string Status { get; set; } // e.g., 'Scheduled', 'Active', 'Completed', 'Cancelled'
            public decimal PricePerPerson { get; set; }

            public string StartLocationId { get; set; }
            public Location StartLocation { get; set; }

            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            public string OperatorId { get; set; }
            public string OperatorName { get; set; }

            public string ImageUrl { get; set; }

            public List<Location> VisitedLocations { get; set; }
            public List<Service> IncludedServices { get; set; }
            public List<Service> RequestedServices { get; set; } // Assuming this exists or might be used later

            // Reviews and Rating for the Trip itself
            public List<TripReview> Reviews { get; set; }
            public double AverageRating { get; private set; }

            // ✅ NEW: Flag to indicate if the trip is considered completed
            public bool IsCompleted { get; set; }
            // You might want to set this based on EndDate or Status in your business logic
            // Example calculation (could be a read-only property):
            // public bool IsCompleted => EndDate < DateTime.Now || Status == "Completed" || Status == "Cancelled";


            public Trip()
            {
                VisitedLocations = new List<Location>();
                IncludedServices = new List<Service>();
                RequestedServices = new List<Service>();
                Reviews = new List<TripReview>();

                OperatorName = "N/A";
                // Initialize DurationDisplay if DurationDays is set, or handle null/default cases
                DurationDisplay = DurationDays > 0 ? $"{DurationDays} Days" : "Duration N/A";
                IsCompleted = false; // Default to not completed
            }

            public bool AddReview(TripReview review)
            {
                if (review == null || !review.IsValid())
                    return false;

                Reviews.Add(review);
                UpdateAverageReview();
                return true;
            }

            public void UpdateAverageReview()
            {
                if (Reviews != null && Reviews.Count > 0)
                    AverageRating = Math.Round(Reviews.Average(r => r.Rating), 2);
                else
                    AverageRating = 0;
            }

            public override string ToString()
            {
                return $"{Title} ({TripId}) - {Category}, ★ {AverageRating} ({Reviews?.Count ?? 0} reviews)";
            }
        }

        public class DigitalPass
        {
            private string _passId;
            private string _documentType;

            public string PassId
            {
                get => _passId;
                set
                {
                    if (!Regex.IsMatch(value, @"^(ETK|HTL|ACT)-\d{6}$"))
                        throw new ArgumentException("Pass ID must match ETK/HTL/ACT-###### format.");
                    _passId = value;
                }
            }

            public DateTime DateGenerated { get; set; }
            public DateTime ValidTill { get; set; }

            public string DocumentType
            {
                get => _documentType;
                set
                {
                    string[] allowed = { "e-ticket", "hotel voucher", "activity pass" };
                    if (Array.IndexOf(allowed, value.ToLower()) < 0)
                        throw new ArgumentException("Invalid document type.");
                    _documentType = value.ToLower();
                }
            }

            public string BookingId { get; set; }
            public string ServiceId { get; set; } // Nullable (optional)

            public DigitalPass(string passId, DateTime dateGenerated, DateTime validTill, string documentType, string bookingId, string serviceId = null)
            {
                PassId = passId;
                DateGenerated = dateGenerated;
                ValidTill = validTill;
                DocumentType = documentType;
                BookingId = bookingId;
                ServiceId = serviceId;
            }


        }


        public class Booking
        {
            private string _bookingId;
            private string _bookingStatus;

            public string BookingId
            {
                get => _bookingId;
                set
                {
                    if (!Regex.IsMatch(value, @"^BOOK-\d{6}$"))
                        throw new ArgumentException("Booking ID must match format BOOK-######.");
                    _bookingId = value;
                }
            }

            public DateTime BookDate { get; set; }

            public string BookingStatus
            {
                get => _bookingStatus;
                set
                {
                    string[] allowed = { "confirmed", "pending", "cancelled", "abandoned" };
                    if (Array.IndexOf(allowed, value.ToLower()) < 0)
                        throw new ArgumentException("Invalid booking status.");
                    _bookingStatus = value.ToLower();
                }
            }

            public string TravelerId { get; set; }
            public string TripId { get; set; }

            public List<DigitalPass> DigitalPasses { get; set; }

            public Booking(string bookingId, DateTime bookDate, string bookingStatus, string travelerId, string tripId)
            {
                BookingId = bookingId;
                BookDate = bookDate;
                BookingStatus = bookingStatus;
                TravelerId = travelerId;
                TripId = tripId;
                DigitalPasses = new List<DigitalPass>();
            }

            public void AddDigitalPass(DigitalPass pass)
            {
                if (pass.BookingId != this.BookingId)
                    throw new ArgumentException("Digital pass does not belong to this booking.");
                DigitalPasses.Add(pass);
            }
        }



        public class Transaction
        {
            // Properties
            public string TransactionId { get; set; }             // Format: TXN-###### 
            public decimal Amount { get; set; }
            public DateTime TransactionDate { get; set; }
            public string PaymentMethod { get; set; }             // credit_card, debit_card, paypal, bank_transfer
            public string BookingId { get; set; }
            public string Status { get; set; }                    // success, failed, pending
            public string SendingAccountNumber { get; set; }

            // Allowed values (simulate ENUM-like behavior)
            private static readonly HashSet<string> AllowedPaymentMethods = new HashSet<string>
            {
                "credit_card", "debit_card", "paypal", "bank_transfer"
            };

                    private static readonly HashSet<string> AllowedStatuses = new HashSet<string>
            {
                "success", "failed", "pending"
            };

            // Constructor
            public Transaction(string transactionId, decimal amount, DateTime transactionDate,
                               string paymentMethod, string bookingId, string status, string sendingAccountNumber)
            {
                TransactionId = transactionId;
                Amount = amount;
                TransactionDate = transactionDate;
                PaymentMethod = paymentMethod;
                BookingId = bookingId;
                Status = status;
                SendingAccountNumber = sendingAccountNumber;
            }

            // Validates TransactionId pattern: TXN-000001
            public bool IsValidTransactionId()
            {
                return Regex.IsMatch(TransactionId, @"^TXN-\d{6}$");
            }

            // Validates allowed payment method
            public bool IsValidPaymentMethod()
            {
                return AllowedPaymentMethods.Contains(PaymentMethod.ToLower());
            }

            // Validates allowed status
            public bool IsValidStatus()
            {
                return AllowedStatuses.Contains(Status.ToLower());
            }

            // Overall validity check
            public bool IsValid()
            {
                return IsValidTransactionId() && IsValidPaymentMethod() && IsValidStatus() && Amount >= 0;
            }

            // Optional: For debugging / logging
            public override string ToString()
            {
                return $"Transaction [{TransactionId}] | {Amount:C} | {PaymentMethod} | {Status} | {TransactionDate:d}";
            }
            public string GetFriendlyPaymentMethodName()
            {
                if (string.IsNullOrEmpty(PaymentMethod)) return "Unknown";
                switch (PaymentMethod.ToLowerInvariant())
                {
                    case "credit_card": return "Credit Card";
                    case "debit_card": return "Debit Card";
                    case "paypal": return "PayPal";
                    case "bank_transfer": return "Bank Transfer";
                    default:
                        // Capitalize first letter if it's a custom one
                        if (PaymentMethod.Length > 1)
                            return char.ToUpperInvariant(PaymentMethod[0]) + PaymentMethod.Substring(1).Replace("_", " ");
                        return PaymentMethod;
                }
            }
        }


        public static void AttachClickToAllChildren(Control parent, EventHandler handler)
        {
            parent.Click += handler;

            foreach (Control child in parent.Controls)
            {
                child.Click += handler;

                // Recursively attach to nested children
                if (child.HasChildren)
                {
                    AttachClickToAllChildren(child, handler);
                }
            }
        }

        // New Helper class for ListBox items (place this within your TravelEaseApp.TourOperator namespace)
        public class ListBoxItem
        {
            public string Text { get; set; }
            public Service Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }


        public class Category
        {
            private string _id;
            public string Id
            {
                get => _id;
                set
                {
                    // Optional: Add validation similar to your CHECK constraint
                    // Example: if (!Regex.IsMatch(value, @"^CAT-\d{6}$"))
                    // throw new ArgumentException("Category ID format is invalid. Must be CAT-######.");
                    _id = value;
                }
            }

            public string CategoryName { get; set; }


            public Category(string id, string categoryName)
            {
                // Basic validation for required fields
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentNullException(nameof(id), "Category ID cannot be null or empty.");
                if (string.IsNullOrWhiteSpace(categoryName))
                    throw new ArgumentNullException(nameof(categoryName), "Category name cannot be null or empty.");

                Id = id; // Setter will handle format validation if implemented
                CategoryName = categoryName;
            }
        }


    }
}
