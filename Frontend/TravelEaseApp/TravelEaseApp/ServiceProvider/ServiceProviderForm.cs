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

namespace TravelEaseApp
{
    public partial class ServiceProviderForm : Form
    {
        public ServiceProviderForm()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;
            ShowDashboardForm();

            // dashboardTrayPanel
            dashboardTrayPanel.Click += dashboardTrayPanel_Click;
            dashboardTrayLabel.Click += dashboardTrayPanel_Click;
            dashboardTrayPictureBox.Click += dashboardTrayPanel_Click;

            // servicesTrayPanel
            serviceTrayPanel.Click += serviceTrayPanel_Click;
            serviceTrayLabel.Click += serviceTrayPanel_Click;
            serviceTrayPictureBox.Click += serviceTrayPanel_Click;

            SelectPanel(dashboardTrayPanel); // Select the dashboard panel by default

            // example:             AddHoverTransition(DashboardButton, DashBoardButtonPanel, DashBoardButtonPanel.BackColor, Color.Silver, DashBoardButtonPanel.ForeColor, DashBoardButtonPanel.ForeColor);
        }

        private void ShowDashboardForm()
        {
            var dashboardForm = new dashboardForm();
            dashboardForm.TopLevel = false;
            dashboardForm.FormBorderStyle = FormBorderStyle.None;
            dashboardForm.Dock = DockStyle.Fill;

            dashboardForm.RequestAddServiceForm += ShowAddServiceForm;

            subFormPanel.Controls.Clear();
            subFormPanel.Controls.Add(dashboardForm);
            dashboardForm.Show();
        }

        private void ShowServicesForm()
        {
            var servicesForm = new servicesForm();
            servicesForm.TopLevel = false;
            servicesForm.FormBorderStyle = FormBorderStyle.None;
            servicesForm.Dock = DockStyle.Fill;
            subFormPanel.Controls.Clear();
            subFormPanel.Controls.Add(servicesForm);
            servicesForm.Show();
        }

        private void ShowAddServiceForm()
        {
            var addServiceForm = new addServiceForm();
            addServiceForm.TopLevel = false;
            addServiceForm.FormBorderStyle = FormBorderStyle.None;
            addServiceForm.Dock = DockStyle.Fill;

            subFormPanel.Controls.Clear();
            subFormPanel.Controls.Add(addServiceForm);
            addServiceForm.Show();
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
            UnselectPanel(serviceTrayPanel);
            SelectPanel(dashboardTrayPanel);
        }

        private void serviceTrayPanel_Click(object sender, EventArgs e)
        {
            // if subform is equal to servicesForm, do nothing
            if (subFormPanel.Controls.Count > 0 && subFormPanel.Controls[0] is servicesForm)
            {
                return;
            }
            foreach (Control ctrl in subFormPanel.Controls)
            {
                ctrl.Dispose(); // Remove existing controls (forms)
            }
            ShowServicesForm();
            UnselectPanel(dashboardTrayPanel);
            SelectPanel(serviceTrayPanel);
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
