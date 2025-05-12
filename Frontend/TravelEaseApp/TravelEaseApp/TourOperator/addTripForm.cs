using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelEaseApp.ServiceProvider;
using static TravelEaseApp.Helpers;
using Microsoft.Data.SqlClient;

namespace TravelEaseApp.TourOperator
{
    public partial class addTripForm : Form
    {
        string regNo;
        List<Service> services = new List<Service>();
        List<Trip> trips = new List<Trip>();
        List<Location> locations = new List<Location>();
        List<TripReview> reviews = new List<TripReview>();
        List<Location> tripLocations = new List<Location>();
        List<Category> categories = new List<Category>();
        public addTripForm(string REGNO)
        {
            InitializeComponent();
            AddHoverTransition(submitLabel, submitLabel.BackColor, submitLabel.ForeColor, submitLabel.ForeColor, submitLabel.BackColor);
            regNo = REGNO;
            setData();
            PopulateStartLocationComboBox();
            PopulateSelectLocationsComboBox();
            PopulateCategoryComboBox();
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
                string query = "SELECT * FROM trips WHERE operator_id = '" + @regNo + "'";
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
                    string query2 = "SELECT * FROM trip_services WHERE trip_id = '" + trip.TripId + "'";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query2, connection);
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
                                else if (status != "rejected")
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

            {   // setup visitedLocations attribute for trips
                // find all locations related to trip and push to list order in ascending order by destination_order
                foreach (var trip in trips)
                {
                    string query = $"SELECT * FROM trip_location WHERE trip_id = '{trip.TripId}' ORDER BY destination_order ASC";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        try
                        {
                            connection.Open();
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                var location = locations.FirstOrDefault(l => l.DestId == reader.GetString(1));
                                if (location != null)
                                {
                                    trip.VisitedLocations.Add(location);
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

            {   // fetch all categories
                string query = "SELECT * FROM category";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var category = new Category(reader.GetString(0), reader.GetString(1));
                            categories.Add(category);
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

        private int SmoothTransition(int current, int target)
        {
            int diff = target - current;
            if (Math.Abs(diff) < 3)
                return target;
            return current + diff / 5;
        }

        private void AddHoverTransition(Control control, Color normalBackColor, Color hoverBackColor, Color normalTextColor, Color hoverTextColor)
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
                // Transition for background color
                Color targetBackColor = isHovering ? hoverBackColor : normalBackColor;
                int rBack = SmoothTransition(currentBackColor.R, targetBackColor.R);
                int gBack = SmoothTransition(currentBackColor.G, targetBackColor.G);
                int bBack = SmoothTransition(currentBackColor.B, targetBackColor.B);
                currentBackColor = Color.FromArgb(rBack, gBack, bBack);

                // Transition for text color
                Color targetTextColor = isHovering ? hoverTextColor : normalTextColor;
                int rText = SmoothTransition(currentTextColor.R, targetTextColor.R);
                int gText = SmoothTransition(currentTextColor.G, targetTextColor.G);
                int bText = SmoothTransition(currentTextColor.B, targetTextColor.B);
                currentTextColor = Color.FromArgb(rText, gText, bText);

                // Apply colors
                control.BackColor = currentBackColor;
                control.ForeColor = currentTextColor;
            };
            hoverTimer.Start();

            control.MouseEnter += (s, e) => isHovering = true;
            control.MouseLeave += (s, e) => isHovering = false;
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addLocationButton_Click(object sender, EventArgs e)
        {
            // check selectLocationsComboBox, verify from locations and add to locationsSelected
            if (selectLocationsComboBox.SelectedItem != null)
            {
                var selectedLocation = (Location)selectLocationsComboBox.SelectedItem;
                bool found = false;
                foreach (var location in locations)
                {
                    if (location.DestId == selectedLocation.DestId)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    // add selectedLocation.GetString() to locationsSelected
                    tripLocations.Add(selectedLocation);
                    // add selectedLocation to the listbox
                    locationsSelected.Text += selectedLocation.ToString() + "\n";
                }
                else
                {
                    MessageBox.Show("Location not found in the list.");
                }

            }
            else
            {
                MessageBox.Show("Please select a valid location to add.");
            }

        }
        private void PopulateStartLocationComboBox()
        {
            startLocationComboBox.DataSource = null;
            startLocationComboBox.DisplayMember = "ToString";
            startLocationComboBox.ValueMember = "DestId";
            startLocationComboBox.DataSource = new List<Location>(locations); // Create a copy
        }

        private void PopulateSelectLocationsComboBox()
        {
            selectLocationsComboBox.DataSource = null;
            selectLocationsComboBox.DisplayMember = "ToString";
            selectLocationsComboBox.ValueMember = "DestId";
            selectLocationsComboBox.DataSource = new List<Location>(locations); // Create a copy
        }

        private void PopulateCategoryComboBox()
        {
            categoryComboBox.DataSource = null; // Clear previous bindings
            categoryComboBox.DisplayMember = "CategoryName"; // Display user-friendly string
            categoryComboBox.ValueMember = "Id"; // Set the value to location_id
            categoryComboBox.DataSource = categories; // Bind the data
        }

        private void submitTripButton_Click(object sender, EventArgs e)
        {
            // Create new trip object with validated data
            Trip trip = new Trip
            {
                Title = innerTitleBox.Text,
                Description = innerDescriptionBox.Text,
                StartDate = startDatePicker.Value,
                EndDate = endDatePicker.Value,
                OperatorId = regNo,
                Capacity = int.TryParse(innerCapacityBox.Text, out int capacity) ? capacity : 0,
                PricePerPerson = decimal.TryParse(innerPricePerPersonBox.Text, out decimal price) ? price : 0,
            };
            // Validate trip data
            bool valid = true;

            try
            {
                trip.StartLocationId = ((Location)startLocationComboBox.SelectedItem).DestId;
            }
            catch {
                trip.StartLocationId = null;
                valid = false;
            }

            try
            {
                trip.Category = ((Category)categoryComboBox.SelectedItem).Id;
            }
            catch
            {
                trip.Category = null;
                valid = false;
            }


            if (string.IsNullOrEmpty(trip.Title))
            {
                valid = false;
                MessageBox.Show("Please enter a valid title.");
            }

            if (string.IsNullOrEmpty(trip.Description))
            {
                valid = false;
                MessageBox.Show("Please enter a valid description.");
            }

            if (trip.StartLocationId == null)
            {
                valid = false;
                MessageBox.Show("Please select a valid start location.");
            }

            if (trip.StartDate >= trip.EndDate)
            {
                valid = false;
                MessageBox.Show("End date must be after start date.");
            }

            if (trip.Capacity <= 0)
            {
                valid = false;
                MessageBox.Show("Please enter a valid capacity.");
            }

            if (trip.PricePerPerson <= 0)
            {
                valid = false;
                MessageBox.Show("Please enter a valid price per person.");
            }

            foreach (var location in tripLocations)
            {
                trip.VisitedLocations.Add(location);
            }

            if (trip.VisitedLocations.Count <= 0)
            {
                valid = false;
                MessageBox.Show("Please select at least one location.");
            }



            if (valid)
            {
                trip.DurationDays = (int)(trip.EndDate - trip.StartDate).TotalDays;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // Get next trip ID
                        string tripId;
                        string query = "SELECT last_number FROM reg_counter WHERE user_type = 'TRIP'";
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            object result = command.ExecuteScalar();
                            if (result == null)
                            {
                                MessageBox.Show("Error: No operator ID counter found.");
                                return;
                            }

                            int maxOpId = Convert.ToInt32(result);
                            tripId = "TRIP-" + (maxOpId + 1).ToString("D6");
                        }

                        // Update counter
                        string updateQuery = "UPDATE reg_counter SET last_number = last_number + 1 WHERE user_type = 'TRIP'";
                        using (SqlCommand command = new SqlCommand(updateQuery, connection, transaction))
                        {
                            command.ExecuteNonQuery();
                        }

                        // Insert trip
                        string insertTripQuery = @"
                        INSERT INTO trips 
                        (trip_id, title, descirption, capacity, duration, status, price_per_person, start_loc_id, start_date, end_date, operator_id, profileTrip_image_url, category) 
                        VALUES 
                        (@tripId, @title, @description, @capacity, @duration, @status, @price_per_person, @startLocId, @startDate, @endDate, @operatorId, @imageUrl, @category)";

                        using (SqlCommand command = new SqlCommand(insertTripQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@tripId", tripId);
                            command.Parameters.AddWithValue("@title", trip.Title);
                            command.Parameters.AddWithValue("@description", trip.Description);
                            command.Parameters.AddWithValue("@capacity", trip.Capacity);
                            command.Parameters.AddWithValue("@duration", trip.DurationDays);
                            command.Parameters.AddWithValue("@status", "active");
                            command.Parameters.AddWithValue("@price_per_person", trip.PricePerPerson);
                            command.Parameters.AddWithValue("@startLocId", trip.StartLocationId);
                            command.Parameters.AddWithValue("@startDate", trip.StartDate);
                            command.Parameters.AddWithValue("@endDate", trip.EndDate);
                            command.Parameters.AddWithValue("@operatorId", trip.OperatorId);
                            command.Parameters.AddWithValue("@imageUrl", "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg");
                            command.Parameters.AddWithValue("@category", trip.Category);

                            command.ExecuteNonQuery();
                        }

                        // Insert trip locations with order
                        foreach (var location in trip.VisitedLocations)
                        {
                            string insertLocationQuery = @"
                            INSERT INTO trip_location 
                            (trip_id, location_id, destination_order) 
                            VALUES 
                            (@tripId, @locationId, @destinationOrder)";
                            using (SqlCommand command = new SqlCommand(insertLocationQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@tripId", tripId);
                                command.Parameters.AddWithValue("@locationId", location.DestId);
                                command.Parameters.AddWithValue("@destinationOrder", trip.VisitedLocations.IndexOf(location) + 1);
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show($"Trip added successfully! Trip ID: {tripId}");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error adding trip: {ex.Message}");
                    }
                }
            }
        }
    }
}
