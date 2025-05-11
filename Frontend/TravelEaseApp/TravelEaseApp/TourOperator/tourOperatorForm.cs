using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelEaseApp.ServiceProvider;

namespace TravelEaseApp.TourOperator
{
    public partial class tourOperatorForm : Form
    {
        string regNo;
        public tourOperatorForm(string regNo)
        {
            this.regNo = regNo;
            InitializeComponent();
            //this.IsMdiContainer = true;
            ShowDashboardForm();

            // dashboardTrayPanel
            dashboardTrayPanel.Click += dashboardTrayPanel_Click;
            dashboardTrayLabel.Click += dashboardTrayPanel_Click;
            dashboardTrayPictureBox.Click += dashboardTrayPanel_Click;

            // tripsTrayPanel
            tripTrayPanel.Click += tripTrayPanel_Click;
            tripTrayLabel.Click += tripTrayPanel_Click;
            tripTrayPictureBox.Click += tripTrayPanel_Click;

            SelectPanel(dashboardTrayPanel); // Select the dashboard panel by default
            this.regNo = regNo;
        }

        private void ShowDashboardForm()
        {
            var dashboardForm = new dashboardForm("OP-000001");
            dashboardForm.TopLevel = false;
            dashboardForm.FormBorderStyle = FormBorderStyle.None;
            dashboardForm.Dock = DockStyle.Fill;

            dashboardForm.RequestAddTripForm += ShowAddTripForm;

            subFormPanel.Controls.Clear();
            subFormPanel.Controls.Add(dashboardForm);
            dashboardForm.Show();
        }

        private void ShowTripsForm()
        {
            var tripsForm = new tripsForm(regNo);
            tripsForm.TopLevel = false;
            tripsForm.FormBorderStyle = FormBorderStyle.None;
            tripsForm.Dock = DockStyle.Fill;
            subFormPanel.Controls.Clear();
            subFormPanel.Controls.Add(tripsForm);
            tripsForm.Show();
        }

        private void ShowAddTripForm()
        {
            var addServiceForm = new addTripForm();
            addServiceForm.TopLevel = false;
            addServiceForm.FormBorderStyle = FormBorderStyle.None;
            addServiceForm.Dock = DockStyle.Fill;

            subFormPanel.Controls.Clear();
            subFormPanel.Controls.Add(addServiceForm);
            addServiceForm.Show();
        }

        private void tourOperatorForm_Load(object sender, EventArgs e)
        {
            Color borderColor = Color.FromArgb(220, 224, 230);
            sidebarPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, sidebarPanel.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };
        }

        private void dashboardTrayPanel_Click(object sender, EventArgs e)
        {
            // if subform is equal to dashboardForm, do nothing
            if (subFormPanel.Controls.Count > 0 && subFormPanel.Controls[0] is dashboardForm)
            {
                return;
            }

            foreach (Control ctrl in subFormPanel.Controls)
            {
                ctrl.Dispose(); // Remove existing controls (forms)
            }
            ShowDashboardForm();
            UnselectPanel(tripTrayPanel);
            UnselectPanel(dashboardTrayPanel);
            SelectPanel(dashboardTrayPanel);
        }

        private void tripTrayPanel_Click(object sender, EventArgs e)
        {
            // if subform is equal to tripsForm, do nothing
            if (subFormPanel.Controls.Count > 0 && subFormPanel.Controls[0] is tripsForm)
            {
                return;
            }
            foreach (Control ctrl in subFormPanel.Controls)
            {
                ctrl.Dispose(); // Remove existing controls (forms)
            }
            ShowTripsForm();
            UnselectPanel(dashboardTrayPanel);
            UnselectPanel(tripTrayPanel);
            SelectPanel(tripTrayPanel);
        }

        private Dictionary<Panel, (Color BackColor, Color LabelForeColor, Image OriginalImage)> originalPanelStates = new();

        public void SelectPanel(Panel panel)
        {
            var label = panel.Controls.OfType<Label>().FirstOrDefault();
            var pictureBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();

            if (!originalPanelStates.ContainsKey(panel))
            {
                originalPanelStates[panel] = (
                    panel.BackColor,
                    label?.ForeColor ?? Color.Black,
                    pictureBox?.Image != null ? new Bitmap(pictureBox.Image) : null
                );
            }

            panel.BackColor = InvertColor(panel.BackColor);
            if (label != null)
                label.ForeColor = InvertColor(label.ForeColor);

            if (pictureBox?.Image != null)
                pictureBox.Image = InvertImage(pictureBox.Image);

            panel.BorderStyle = BorderStyle.FixedSingle;
        }

        private Color InvertColor(Color color)
        {
            return Color.FromArgb(color.A, 255 - color.R, 255 - color.G, 255 - color.B);
        }

        public void UnselectPanel(Panel panel)
        {
            if (originalPanelStates.ContainsKey(panel))
            {
                var (originalBack, originalFore, originalImage) = originalPanelStates[panel];

                panel.BackColor = originalBack;

                var label = panel.Controls.OfType<Label>().FirstOrDefault();
                if (label != null)
                    label.ForeColor = originalFore;

                var pictureBox = panel.Controls.OfType<PictureBox>().FirstOrDefault();
                if (pictureBox != null && originalImage != null)
                    pictureBox.Image = new Bitmap(originalImage);

                panel.BorderStyle = BorderStyle.None;

                originalPanelStates.Remove(panel);
            }
        }


        private Image InvertImage(Image original)
        {
            Bitmap inverted = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixelColor = ((Bitmap)original).GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(
                        pixelColor.A,
                        255 - pixelColor.R,
                        255 - pixelColor.G,
                        255 - pixelColor.B
                    );
                    inverted.SetPixel(x, y, invertedColor);
                }
            }

            return inverted;
        }

        private void ServiceProviderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
