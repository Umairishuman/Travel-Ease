using Microsoft.ReportingServices.Diagnostics.Internal;
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
using Microsoft.Data.SqlClient;

namespace TravelEaseApp.ServiceProvider
{
    public partial class addServiceForm : Form
    {
        string regNo;
        public addServiceForm(string REGNO)
        {
            InitializeComponent();
            regNo = REGNO;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddHoverTransition(submitLabel, submitLabel.BackColor, submitLabel.ForeColor, submitLabel.ForeColor, submitLabel.BackColor);

            Color borderColor = Color.FromArgb(220, 224, 230);
            typeSelectOptions.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, typeSelectOptions.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };
            typeSelectOptions.Text = "-- Select Service Type --";
        }

        private void submitLabel_Click(object sender, EventArgs e)
        {
            Service service = new Service
            {
                ServiceType = typeSelectOptions.Text,
                ServiceDescription = innerServiceDescriptionBox.Text,
                Price = decimal.TryParse(innerPricePerPersonBox.Text, out decimal price) ? price : -1,
                Capacity = int.TryParse(innerCapacityBox.Text, out int capacity) ? capacity : -1,
            };

            List<String> validServices = new List<string> { "Hotel", "Guide", "Transport", "Other" };

            bool valid = true;
            if (!validServices.Contains(service.ServiceType))
            {
                valid = false;
                MessageBox.Show("Please select a valid service type.");
            }
            if (service.Price < 0)
            {
                valid = false;
                MessageBox.Show("Please enter a valid price.");
            }
            if (service.Capacity < 0)
            {
                valid = false;
                MessageBox.Show("Please enter a valid capacity.");
            }

            if (valid)
            {
                // get max serviceId from database table reg_counter
                // increment it by 1 and assign it to 
                string query = $"SELECT * FROM reg_counter WHERE user_type = 'SRV'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int maxServiceId = reader.GetInt32(1);
                        service.ServiceId = "SRV-" + (maxServiceId + 1).ToString("D6");
                        MessageBox.Show("Service ID: " + service.ServiceId);
                    }
                    else
                    {
                        MessageBox.Show("Error: No service ID found.");
                        return;
                    }
                }
                string query2 = $"UPDATE reg_counter SET last_number = last_number + 1 WHERE user_type = 'SRV'";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query2, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }


                // use Transaction based tsql query to insert the service
                string query3 = $"INSERT INTO services (service_id, service_type, service_description, price, provider_id, capacity) VALUES ('{service.ServiceId}', '{service.ServiceType}', '{service.ServiceDescription}', {service.Price}, '{regNo}', {service.Capacity})";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query3, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Service added successfully.");
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
    }
}
