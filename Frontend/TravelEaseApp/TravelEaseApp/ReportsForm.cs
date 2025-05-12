using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static TravelEaseApp.Helpers;

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

            var lblTitle = new Label
            {
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Height = 50,
                Name = "labelTitle"
            };

            var btnExport = new Button
            {
                Text = "Export to Excel",
                Dock = DockStyle.Bottom,
                Height = 40,
                Name = "buttonExport"
            };
            btnExport.Click += BtnExport_Click;

            this.Controls.Add(dgv);
            this.Controls.Add(lblTitle);
            this.Controls.Add(btnExport);

            LoadReportData(dgv, lblTitle);
        }

        private void LoadReportData(DataGridView dgv, Label titleLabel)
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
                    default:
                        throw new ArgumentException("Invalid report type");
                }

                titleLabel.Text = title;
                dgv.DataSource = data;
                FormatDataGridView(dgv, reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load report data:\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;

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
                    sb.Append(i < dataTable.Columns.Count - 1 ? "," : Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}