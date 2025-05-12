using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using static TravelEaseApp.Helpers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ScottPlot;
using ScottPlot.WinForms;
using FastReport.Editor;
using FastReport.DataVisualization.Charting;

namespace TravelEaseApp
{
    public partial class ReportsForm : Form
    {
        private readonly int reportType;

        public ReportsForm(int reportType)
        {
            InitializeComponent();
            this.reportType = reportType;
            this.WindowState = FormWindowState.Maximized;
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            // Create main controls
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                AllowUserToAddRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BackgroundColor = SystemColors.Window,
                Name = "dataGridViewReport"
            };

            var lblTitle = new System.Windows.Forms.Label
            {
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 16, System.Drawing.FontStyle.Bold),
                Height = 50,
                Name = "labelTitle"
            };

            // Add a panel to hold buttons at the bottom
            var panelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40
            };

            var btnExport = new Button
            {
                Text = "Export to Excel",
                Width = 120,
                Dock = DockStyle.Right,
                Name = "buttonExport"
            };
            btnExport.Click += BtnExport_Click;

            var btnVisualize = new Button
            {
                Text = "Visualize",
                Width = 120,
                Dock = DockStyle.Right,
                Name = "buttonVisualize"
            };
            btnVisualize.Click += BtnVisualize_Click;

            panelButtons.Controls.Add(btnExport);
            panelButtons.Controls.Add(btnVisualize);

            this.Controls.Add(dgv);
            this.Controls.Add(lblTitle);
            this.Controls.Add(panelButtons); // Replace btnExport with panel

            LoadReportData(dgv, lblTitle);
        }

        private void LoadReportData(DataGridView dgv, System.Windows.Forms.Label titleLabel)
        {
            try
            {
                DataTable data;
                string title;

                switch (reportType)
                {
                    case 1:
                        (data, title) = GetRevenueByCategoryReport();
                        break;
                    case 2:
                        (data, title) = GetTripBookingRevenueReport();
                        break;
                    case 3:
                        (data, title) = GetTripCancellationRateReport();
                        break;
                    case 4:
                        (data, title) = GetPeakBookingPeriodsReport();
                        break;
                    case 5:
                        (data, title) = GetAverageBookingValueReport();
                        break;
                    case 6:
                        (data, title) = GetTravelerDemographicsReport();
                        break;
                    case 7:
                        (data, title) = GetPreferredTripTypesReport();
                        break;
                    case 8:
                        (data, title) = GetPreferredDestinationsReport();
                        break;
                    case 9:
                        (data, title) = GetTravelerSpendingHabitsReport();
                        break;
                    case 10:
                        (data, title) = GetAverageOperatorRatingReport();
                        break;
                    case 11:
                        (data, title) = GetOperatorTotalRevenueReport();
                        break;
                    case 12:
                        (data, title) = GetHotelOccupancyRateReport();
                        break;
                    case 13:
                        (data, title) = GetGuideServiceRatingsReport();
                        break;
                    case 14:
                        (data, title) = GetMostBookedDestinationsReport();
                        break;
                    case 15:
                        (data, title) = GetSeasonalTrendsReport();
                        break;
                    case 16:
                        (data, title) = GetTravelerSatisfactionScoreReport();
                        break;
                    case 17:
                        (data, title) = GetEmergingDestinationsReport();
                        break;
                    case 18:
                        (data, title) = GetAbandonedBookingAnalysisReport();
                        break;
                    case 19:
                        (data, title) = GetAbandonedBookingReasonsReport();
                        break;
                    case 20:
                        (data, title) = GetAbandonedBookingRecoveryRateReport();
                        break;
                    case 21:
                        (data, title) = GetPotentialRevenueLossReport();
                        break;
                    case 22:
                        (data, title) = GetNewUserRegistrationsReport();
                        break;
                    case 23:
                        (data, title) = GetMonthlyActiveUsersReport();
                        break;
                    case 24:
                        (data, title) = GetPartnershipGrowthReport();
                        break;
                    case 25:
                        (data, title) = GetRegionalExpansionReport();
                        break;
                    case 26:
                        (data, title) = GetPaymentSuccessFailureRateReport();
                        break;
                    case 27:
                        (data, title) = GetChargebackRateReport();
                        break;
                    default:
                        throw new ArgumentException("Invalid report type");
                }
                if (data == null || data.Rows.Count == 0)
                {
                    MessageBox.Show("No data found for this report", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    titleLabel.Text = title;
                    dgv.DataSource = data;
                    FormatDataGridView(dgv, reportType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load report data:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private (DataTable data, string title) GetChargebackRateReport()
        {
            string query = @"
        SELECT 
            month,
            chargebacks,
            total_transactions,
            chargeback_percentage
        FROM 
            chargeback_rate";

            DataTable data = ExecuteQuery(query);
            return (data, "CHARGEBACK RATE REPORT");
        }


        private (DataTable data, string title) GetPaymentSuccessFailureRateReport()
        {
            string query = @"
        SELECT 
            month,
            SUM(total_transactions) AS total_transactions
        FROM 
            payment_success_failure_rate
        GROUP BY 
            month
        ORDER BY 
            month";

            DataTable data = ExecuteQuery(query);
            return (data, "PAYMENT SUCCESS/FAILURE RATE REPORT");
        }



        private (DataTable data, string title) GetRegionalExpansionReport()
        {
            string query = @"
        SELECT 
            month,
            new_destinations
        FROM 
            regional_expansion";

            DataTable data = ExecuteQuery(query);
            return (data, "REGIONAL EXPANSION REPORT");
        }


        private (DataTable data, string title) GetPartnershipGrowthReport()
        {
            string query = @"
        SELECT 
            month,
            SUM(new_partners) AS total_new_partners
        FROM 
            monthly_partnership_growth
        GROUP BY 
            month
        ORDER BY 
            month";

            DataTable data = ExecuteQuery(query);
            return (data, "MONTHLY PARTNERSHIP GROWTH REPORT");
        }


        private (DataTable data, string title) GetMonthlyActiveUsersReport()
        {
            string query = @"
        SELECT 
            month,
            user_role,
            active_users
        FROM 
            monthly_active_users";

            DataTable data = ExecuteQuery(query);
            return (data, "MONTHLY ACTIVE USERS REPORT");
        }

        private (DataTable data, string title) GetNewUserRegistrationsReport()
        {
            string query = @"
        SELECT 
            month,
            user_role,
            total_registered
        FROM 
            new_user_registrations";

            DataTable data = ExecuteQuery(query);
            return (data, "NEW USER REGISTRATIONS REPORT");
        }

        private (DataTable data, string title) GetPotentialRevenueLossReport()
        {
            string query = @"
        SELECT 
            estimated_lost_revenue
        FROM 
            potential_revenue_loss";

            DataTable data = ExecuteQuery(query);
            return (data, "POTENTIAL REVENUE LOSS REPORT");
        }

        private (DataTable data, string title) GetAbandonedBookingRecoveryRateReport()
        {
            string query = @"
        SELECT 
            abandoned,
            recovered,
            recovery_percentage
        FROM 
            abandoned_recovery_rate";

            DataTable data = ExecuteQuery(query);


            return (data, "ABANDONED BOOKING RECOVERY RATE REPORT");
        }

        private (DataTable data, string title) GetAbandonedBookingReasonsReport()
        {
            string query = @"
        SELECT 
            reason_type,
            occurrences
        FROM 
            abandoned_booking_reasons";

            DataTable data = ExecuteQuery(query);
            return (data, "ABANDONED BOOKING REASONS REPORT");
        }


        private (DataTable data, string title) GetAbandonedBookingAnalysisReport()
        {
            string query = @"
        SELECT 
            abandonment_percentage
        FROM 
            abandonment_rate";

            DataTable data = ExecuteQuery(query);
            return (data, "ABANDONED BOOKING ANALYSIS REPORT");
        }

        private (DataTable data, string title) GetEmergingDestinationsReport()
        {
            string query = @"
        SELECT 
            city,
            region,
            recent_bookings,
            previous_bookings,
            growth_ratio
        FROM 
            emerging_destinations
        ORDER BY 
            growth_ratio DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "EMERGING DESTINATIONS REPORT");
        }


        private (DataTable data, string title) GetTravelerSatisfactionScoreReport()
        {
            string query = @"
        SELECT 
            city,
            region,
            avg_rating
        FROM 
            destination_satisfaction_scores
        ORDER BY 
            avg_rating DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "TRAVELER SATISFACTION SCORE REPORT");
        }


        private (DataTable data, string title) GetSeasonalTrendsReport()
        {
            string query = @"
        SELECT 
            booking_month,
            total_bookings
        FROM 
            seasonal_booking_trends
        ORDER BY 
            booking_month";

            DataTable data = ExecuteQuery(query);
            return (data, "SEASONAL TRENDS REPORT");
        }


        private (DataTable data, string title) GetMostBookedDestinationsReport()
        {
            string query = @"
        SELECT 
            city,
            region,
            total_bookings
        FROM 
            most_booked_destinations
        ORDER BY 
            total_bookings DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "MOST BOOKED DESTINATIONS REPORT");
        }


        private (DataTable data, string title) GetGuideServiceRatingsReport()
        {
            string query = @"
        SELECT 
            service_id,
            guide_name,
            avg_rating
        FROM 
            guide_service_ratings
        ORDER BY 
            avg_rating DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "GUIDE SERVICE RATINGS REPORT");
        }

        private (DataTable data, string title) GetHotelOccupancyRateReport()
        {
            string query = @"
        SELECT 
            service_id,
            provider_name,
            approx_occupancy_rate
        FROM 
            hotel_occupancy_rate
        ORDER BY 
            approx_occupancy_rate DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "HOTEL OCCUPANCY RATE REPORT");
        }

        private (DataTable data, string title) GetOperatorTotalRevenueReport()
        {
            string query = @"
        SELECT 
            reg_no,
            operator_name,
            total_revenue
        FROM 
            operator_total_revenue
        ORDER BY 
            total_revenue DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "OPERATOR TOTAL REVENUE REPORT");
        }


        private (DataTable data, string title) GetAverageOperatorRatingReport()
        {
            string query = @"
        SELECT 
            reg_no,
            operator_name,
            avg_rating
        FROM 
            avg_operator_rating
        ORDER BY 
            avg_rating DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "AVERAGE OPERATOR RATING REPORT");
        }


        private (DataTable data, string title) GetTravelerSpendingHabitsReport()
        {
            string query = @"
        SELECT 
            reg_no,
            average_spending
        FROM 
            traveler_spending_habits
        ORDER BY 
            average_spending DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "TRAVELER SPENDING HABITS REPORT");
        }


        private (DataTable data, string title) GetPreferredDestinationsReport()
        {
            string query = @"
        SELECT 
            destination_name,
            total_bookings
        FROM 
            preferred_destinations
        ORDER BY 
            total_bookings DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "PREFERRED DESTINATIONS REPORT");
        }


        private (DataTable data, string title) GetPreferredTripTypesReport()
        {
            string query = @"
        SELECT 
            trip_type,
            total_bookings
        FROM 
            preferred_trip_types
        ORDER BY 
            total_bookings DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "PREFERRED TRIP TYPES REPORT");
        }



        private (DataTable data, string title) GetAverageBookingValueReport()
        {
            string query = @"
        SELECT 
            trip_id,
            trip_title,
            average_booking_value
        FROM 
            trip_booking_revenue_report
        ORDER BY 
            average_booking_value DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "AVERAGE BOOKING VALUE REPORT");
        }


        private (DataTable data, string title) GetTripCancellationRateReport()
        {
            string query = @"
        SELECT 
            t.trip_id,
            t.title AS trip_title,
            (CAST(SUM(CASE WHEN b.booking_status = 'Canceled' THEN 1 ELSE 0 END) AS FLOAT) 
             / NULLIF(COUNT(b.booking_id), 0)) * 100 AS cancellation_rate
        FROM 
            trips t
        JOIN 
            bookings b ON t.trip_id = b.trip_id
        GROUP BY 
            t.trip_id, t.title"
            ;

            DataTable data = ExecuteQuery(query);
            return (data, "TRIP CANCELLATION RATE REPORT");
        }


        private (DataTable data, string title) GetPeakBookingPeriodsReport()
        {
            string query = @"
        SELECT 
            booking_month,
            booking_day,
            SUM(total_bookings) AS total_bookings
        FROM 
            trip_booking_revenue_report
        GROUP BY 
            booking_month, booking_day
        ORDER BY 
            total_bookings DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "PEAK BOOKING PERIODS REPORT");
        }

        private (DataTable data, string title) GetTravelerDemographicsReport()
        {
            string query = @"
        SELECT 
            nationality,
            FLOOR(DATEDIFF(DAY, date_of_birth, GETDATE()) / 365.25) AS age,
            COUNT(*) AS traveler_count
        FROM 
            travelers
        GROUP BY 
            nationality, FLOOR(DATEDIFF(DAY, date_of_birth, GETDATE()) / 365.25)
        ORDER BY 
            traveler_count DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "TRAVELER AGE AND NATIONALITY DISTRIBUTION REPORT");
        }


        private (DataTable data, string title) GetRevenueByCategoryReport()
        {
            string query = @"
                SELECT 
                    category_name AS Category, 
                    FORMAT(Revenue, 'C') AS Revenue
                FROM RevenueByCategory 
                ORDER BY Revenue DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "REVENUE BY CATEGORY REPORT");
        }

        private (DataTable data, string title) GetTripBookingRevenueReport()
        {
            string query = @"
        SELECT 
            trip_id AS [Trip ID],
            trip_title AS [Trip Title],
            trip_category AS [Category],
            trip_capacity AS [Capacity],
            trip_duration AS [Duration (Days)],
            total_bookings AS [Total Bookings],
            FORMAT(total_revenue, 'C') AS [Total Revenue],
            FORMAT(average_booking_value, 'C') AS [Avg Booking Value],
            FORMAT(cancellation_rate, 'N2') + '%' AS [Cancellation Rate],
            booking_month AS [Booking Month],
            booking_day AS [Booking Day]
        FROM trip_booking_revenue_report
        ORDER BY total_revenue DESC";

            DataTable data = ExecuteQuery(query);
            return (data, "TRIP BOOKING REVENUE REPORT");
        }


        private DataTable ExecuteQuery(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var adapter = new SqlDataAdapter(query, connection))
            {
                DataTable data = new DataTable();
                adapter.Fill(data);
                return data;
            }
        }

        private void FormatDataGridView(DataGridView dgv, int reportType)
        {
            // Common formatting
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, System.Drawing.FontStyle.Bold);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke;

            // Report-specific formatting
            switch (reportType)
            {
                case 1: // Revenue by Category
                    if (dgv.Columns.Contains("Revenue"))
                    {
                        dgv.Columns["Revenue"].DefaultCellStyle.Alignment =
                            DataGridViewContentAlignment.MiddleRight;
                        dgv.Columns["Revenue"].HeaderCell.Style.Alignment =
                            DataGridViewContentAlignment.MiddleRight;
                    }
                    break;
                    // Add formatting for other report types
            }

            // Center-align all other columns by default
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.DefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet)
                {
                    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }

        private void BtnVisualize_Click(object sender, EventArgs e)
        {
            var dgv = this.Controls.Find("dataGridViewReport", true)[0] as DataGridView;
            if (dgv?.DataSource is not DataTable data || data.Rows.Count == 0)
            {
                MessageBox.Show("No data to visualize!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new form for the chart
            var chartForm = new Form
            {
                Text = "Data Visualization",
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.CenterParent
            };

            // Create ScottPlot control
            var formsPlot = new ScottPlot.WinForms.FormsPlot
            {
                Dock = DockStyle.Fill
            };

            // Plot data based on report type
            try
            {
                switch (reportType)
                {
                    case 1:
                        PlotLineChart(formsPlot, data, "Category", "Revenue");
                        break;
                    case 2:
                        PlotLineChart(formsPlot, data, "Trip Title", "Total Revenue");
                        break;
                    case 3:
                        PlotBarChart(formsPlot, data, "trip_title", "cancellation_rate");
                        break;
                    case 4:
                        PlotBarChart(formsPlot, data, "booking_month", "total_bookings");
                        break;
                    case 5:
                        PlotBarChart(formsPlot, GetAverageBookingValueReport().data, "trip_title", "average_booking_value");
                        break;
                    case 6:
                        PlotBarChart(formsPlot, GetTravelerDemographicsReport().data, "nationality", "traveler_count");
                        break;
                    case 7:
                        PlotBarChart(formsPlot, GetPreferredTripTypesReport().data, "trip_type", "total_bookings");
                        break;
                    case 8:
                        PlotBarChart(formsPlot, GetPreferredDestinationsReport().data, "destination_name", "total_bookings");
                        break;
                    case 9:
                        PlotBarChart(formsPlot, GetTravelerSpendingHabitsReport().data, "reg_no", "average_spending");
                        break;
                    case 10:
                        PlotBarChart(formsPlot, GetAverageOperatorRatingReport().data, "operator_name", "avg_rating");
                        break;
                    case 11:
                        PlotBarChart(formsPlot, GetOperatorTotalRevenueReport().data, "operator_name", "total_revenue");
                        break;
                    case 12:
                        PlotBarChart(formsPlot, GetHotelOccupancyRateReport().data, "provider_name", "approx_occupancy_rate");
                        break;
                    case 13:
                        PlotBarChart(formsPlot, GetGuideServiceRatingsReport().data, "guide_name", "avg_rating");
                        break;
                    case 14:
                        var mostBookedDestinationsData = GetMostBookedDestinationsReport().data;
                        mostBookedDestinationsData.Columns.Add("CityRegion", typeof(string));
                        foreach (DataRow row in mostBookedDestinationsData.Rows)
                        {
                            row["CityRegion"] = row["city"].ToString() + " " + row["region"].ToString();
                        }
                        PlotBarChart(formsPlot, mostBookedDestinationsData, "CityRegion", "total_bookings");
                        break;
                    case 15:
                        PlotLineChart(formsPlot, GetSeasonalTrendsReport().data, "booking_month", "total_bookings");
                        break;
                    case 16:
                        var satisfactionData = GetTravelerSatisfactionScoreReport().data;
                        satisfactionData.Columns.Add("CityRegion", typeof(string));
                        foreach (DataRow row in satisfactionData.Rows)
                        {
                            row["CityRegion"] = row["city"].ToString() + " " + row["region"].ToString();
                        }
                        PlotBarChart(formsPlot, satisfactionData, "CityRegion", "avg_rating");
                        break;
                    case 17:
                        var emergingDestData = GetEmergingDestinationsReport().data;
                        emergingDestData.Columns.Add("CityRegion", typeof(string));
                        foreach (DataRow row in emergingDestData.Rows)
                        {
                            row["CityRegion"] = row["city"].ToString() + " " + row["region"].ToString();
                            if (row["growth_ratio"] == DBNull.Value)
                            {
                                row["growth_ratio"] = 0;
                            }
                        }
                        PlotBarChart(formsPlot, emergingDestData, "CityRegion", "growth_ratio");
                        break;
                    case 18:
                        var ABdata = GetAbandonedBookingAnalysisReport().data;
                        PlotBarChart(formsPlot, ABdata, "abandonment_percentage", "abandonment_percentage");
                        break;
                    case 19:
                        var reasonsData = GetAbandonedBookingReasonsReport().data;
                        PlotBarChart(formsPlot, reasonsData, "reason_type", "occurrences");
                        break;
                    case 20:
                        var recoveryData = GetAbandonedBookingRecoveryRateReport().data;
                        foreach (DataRow row in recoveryData.Rows)
                        {
                            if (row["recovery_percentage"] == DBNull.Value)
                                row["recovery_percentage"] = 0;
                        }
                        PlotLineChart(formsPlot, recoveryData, "abandoned", "recovery_percentage");
                        break;
                    case 21:
                        var revenueLossData = GetPotentialRevenueLossReport().data;
                        DataTable chartData = new DataTable();
                        chartData.Columns.Add("Label", typeof(string));
                        chartData.Columns.Add("Value", typeof(decimal));
                        decimal lostRevenue = revenueLossData.Rows.Count > 0 && revenueLossData.Rows[0]["estimated_lost_revenue"] != DBNull.Value
                            ? Convert.ToDecimal(revenueLossData.Rows[0]["estimated_lost_revenue"])
                            : 0;
                        chartData.Rows.Add("Estimated Lost Revenue", lostRevenue);
                        PlotBarChart(formsPlot, chartData, "Label", "Value");
                        break;
                    case 22:
                        var regData = GetNewUserRegistrationsReport().data;
                        regData.Columns.Add("MonthRole", typeof(string));
                        foreach (DataRow row in regData.Rows)
                        {
                            row["MonthRole"] = row["month"].ToString() + " - " + row["user_role"].ToString();
                        }
                        PlotBarChart(formsPlot, regData, "MonthRole", "total_registered");
                        break;
                    case 23:
                        var activeUsersData = GetMonthlyActiveUsersReport().data;
                        activeUsersData.Columns.Add("MonthRole", typeof(string));
                        foreach (DataRow row in activeUsersData.Rows)
                        {
                            row["MonthRole"] = row["month"].ToString() + " - " + row["user_role"].ToString();
                        }
                        PlotBarChart(formsPlot, activeUsersData, "MonthRole", "active_users");
                        break;
                    case 24:
                        var Partdata = GetPartnershipGrowthReport().data;
                        PlotBarChart(formsPlot, Partdata, "month", "total_new_partners");
                        break;
                    case 25:
                        var regionalData = GetRegionalExpansionReport().data;
                        PlotLineChart(formsPlot, regionalData, "month", "new_destinations");
                        break;
                    case 26:
                        var Paydata = GetPaymentSuccessFailureRateReport().data;
                        PlotBarChart(formsPlot, Paydata, "month", "total_transactions");
                        break;
                    case 27:
                        data = GetChargebackRateReport().data;
                        PlotBarChart(formsPlot, data, "month", "chargeback_percentage");
                        break;




                    default:
                        MessageBox.Show("Visualization not supported for this report type.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                }

                chartForm.Controls.Add(formsPlot);
                chartForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to visualize data:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PlotBarChart(FormsPlot formsPlot, DataTable data, string xColumn, string yColumn)
        {
            try
            {
                // Extract data
                var categories = data.AsEnumerable()
                    .Select(row => row.Field<string>(xColumn) ?? "N/A")
                    .ToArray();

                var values = data.AsEnumerable()
                    .Select(row => Convert.ToDouble(row[yColumn]))
                    .ToArray();

                // Clear previous plot
                formsPlot.Plot.Clear();

                // Create positions for bars
                double[] positions = Enumerable.Range(0, categories.Length).Select(i => (double)i).ToArray();

                // Create bar plot
                var bars = formsPlot.Plot.Add.Bars(positions, values);

                // Set X-axis tick labels
                formsPlot.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(positions, categories);

                // Axis labels and title
                formsPlot.Plot.Axes.Left.Label.Text = yColumn;
                formsPlot.Plot.Axes.Bottom.Label.Text = xColumn;
                formsPlot.Plot.Title($"{yColumn} by {xColumn}");


                // Add padding
                formsPlot.Plot.Axes.AutoScale(true);


                // Render
                formsPlot.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating chart: {ex.Message}");
            }
        }

        private void PlotLineChart(FormsPlot formsPlot, DataTable data, string xColumn, string yColumn)
        {
            try
            {
                // Get X-axis values (assuming numeric or date)
                var xValues = data.AsEnumerable()
                    .Select((row, index) => (double)index) // Use index if not numeric
                    .ToArray();

                // Get Y-axis values
                var yValues = data.AsEnumerable()
                    .Select(row =>
                    {
                        var val = row[yColumn].ToString();
                        if (val.Contains("$"))
                            return double.Parse(val.Replace("$", "").Replace(",", ""));
                        return Convert.ToDouble(val);
                    })
                    .ToArray();

                // Clear and plot
                formsPlot.Plot.Clear();
                formsPlot.Plot.Add.Scatter(xValues, yValues);
                formsPlot.Plot.Title($"{yColumn} by {xColumn}");
                formsPlot.Plot.XLabel(xColumn);
                formsPlot.Plot.YLabel(yColumn);
                formsPlot.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating line chart: {ex.Message}");
            }
        }

        // In PlotBarChart/PlotLineChart, handle currency/percentage formatting:
        public double[] ExtractYValues(DataTable data, string yColumn)
        {
            return data.Rows.Cast<DataRow>().Select(row =>
            {
                var val = row[yColumn].ToString();
                if (val.Contains("$"))
                    return double.Parse(val.Replace("$", "").Replace(",", ""));
                if (val.Contains("%"))
                    return double.Parse(val.Replace("%", ""));
                return Convert.ToDouble(val);
            }).ToArray();
        }




        private void BtnExport_Click(object sender, EventArgs e)
        {
            var dgv = this.Controls.Find("dataGridViewReport", true)[0] as DataGridView;

            if (dgv?.DataSource is DataTable data && data.Rows.Count > 0)
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV Files|*.csv";
                    sfd.Title = "Export Report";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            System.IO.File.WriteAllText(sfd.FileName, DataTableToCsv(data));
                            MessageBox.Show("Exported successfully!", "Success",
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Export failed: {ex.Message}", "Error",
                                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export", "Information",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string DataTableToCsv(DataTable dataTable)
        {
            var sb = new System.Text.StringBuilder();

            // Column headers
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                sb.Append(dataTable.Columns[i].ColumnName);
                sb.Append(i < dataTable.Columns.Count - 1 ? "," : Environment.NewLine);
            }

            // Data rows
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString());
                    sb.Append(row[i].ToString());
                    sb.Append(i < dataTable.Columns.Count - 1 ? "," : Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}