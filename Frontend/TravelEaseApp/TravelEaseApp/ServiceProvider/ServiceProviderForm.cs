using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            this.IsMdiContainer = true;
            ShowDashboardForm();

            // dashboardTrayPanel
            dashboardTrayPanel.Click += dashboardTrayPanel_Click;
            dashboardTrayLabel.Click += dashboardTrayPanel_Click;
            dashboardTrayPictureBox.Click += dashboardTrayPanel_Click;

            // servicesTrayPanel
            serviceTrayPanel.Click += serviceTrayPanel_Click;
            serviceTrayLabel.Click += serviceTrayPanel_Click;
            serviceTrayPictureBox.Click += serviceTrayPanel_Click;
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
            SetRoundedCorners(subFormPanel, 20);
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
            SetRoundedCorners(subFormPanel, 20);
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
            SetRoundedCorners(subFormPanel, 20);
            addServiceForm.Show();
        }



        private void ServiceProviderForm_Load(object sender, EventArgs e)
        {
            //////////////////////////////////////
            // SIDEBAR
            SetRoundedCorners(sidebarPanel, 20);
            //////////////////////////////////////

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
        }
    }
}
