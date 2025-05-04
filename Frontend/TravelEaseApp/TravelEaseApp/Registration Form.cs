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
    public partial class Registration_Form : Form
    {
        Label hiddenLabel;
        Panel currentPanel;
        public Registration_Form()
        {
            hiddenLabel = new Label();
            hiddenLabel.Size = new Size(0, 0); // Invisible
            hiddenLabel.Location = new Point(0, 0);
            hiddenLabel.TabStop = false; // Does not appear in the tab order
            this.Controls.Add(hiddenLabel);

            this.ActiveControl = hiddenLabel; // Set focus to the invisible label
            currentPanel = rolePanel;
            InitializeComponent();


            AddHoverTransition(nextButton, nextButton.BackColor, nextButton.ForeColor, nextButton.ForeColor, nextButton.BackColor);


        }
        //click on form
        private void Registration_Form_Click(object sender, EventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }

        private void RoleSelectOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (RoleSelectOptions.SelectedItem == null)
            {
                MessageBox.Show("Please select a role.");
                return;
            }

            string selectedRole = RoleSelectOptions.SelectedItem.ToString();
            currentPanel = selectedRole switch
            {
                "Traveller" => TraverllerPanel,
                "Service Provider" => ServiceProviderPanel,
                "Tour Operator" => TourOperatorPanel,
                "Admin" => AdminPanel,
                _ => null
            };

            if (currentPanel != null)
            {
                SlideToPanel(rolePanel, currentPanel);
            }
            else
            {
                MessageBox.Show("Invalid role selected.");
            }
        }

        private void Registration_Form_Load(object sender, EventArgs e)
        {
            rolePanel.Click += Panel_Click!;
            TraverllerPanel.Click += Panel_Click!;
            TourOperatorPanel.Click += Panel_Click!;
            ServiceProviderPanel.Click += Panel_Click!;
            AdminPanel.Click += Panel_Click!;
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label

            //////////Traveler////////////
            SetupGroupBoxFocusBehavior(FirstNameBox, innerFirstNameBox);
            AddPlaceholder(innerFirstNameBox, "Muhammad");

            SetupGroupBoxFocusBehavior(LastNameBox, innerLastName);
            AddPlaceholder(innerLastName, "Umair");

            SetupGroupBoxFocusBehavior(EmailBox, innerEmail);
            AddPlaceholder(innerEmail, "ThisisTakingTooLong@gmail.com");

            SetupGroupBoxFocusBehavior(CnicBox, innerCNIC);
            AddPlaceholder(innerCNIC, "12345-1234567-1");

            SetupGroupBoxFocusBehavior(BioBox, innerBio);
            AddPlaceholder(innerBio, "I am a software engineer");

            SetupGroupBoxFocusBehavior(NationalityBox, innerNationality);
            AddPlaceholder(innerNationality, "Pakistan");

            SetupPasswordField(PasswordBox, innerPasswordBox, EyePassword, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(innerPasswordBox, "Password");

            SetupPasswordField(ConfirmPasswordBox, innerConfirmPassword, EyeConfirmPassword, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(innerConfirmPassword, "Password");

            AddHoverTransition(TravllerSIgnUp, TravllerSIgnUp.BackColor, TravllerSIgnUp.ForeColor, TravllerSIgnUp.ForeColor, TravllerSIgnUp.BackColor);

            ///////Tour Operator//////////

            SetupGroupBoxFocusBehavior(OperatorName, innerOpNameBox);
            AddPlaceholder(innerOpNameBox, "Tayyab & sons");

            SetupGroupBoxFocusBehavior(BusinessAddressOp, innerAddressOpBox);
            AddPlaceholder(innerAddressOpBox, "123 Street, Lahore");

            SetupGroupBoxFocusBehavior(EmailOpBox, innerOpEmail);
            AddPlaceholder(innerOpEmail, "aa@gmail.com");

            SetupGroupBoxFocusBehavior(WebUrlOp, innerWebUrl);
            AddPlaceholder(innerWebUrl, "www.example.com");

            SetupPasswordField(passwordOpBox, innerPasswordOp, eyeOp, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(innerPasswordOp, "Password");

            SetupPasswordField(ConfirmOp, innerConfirmOp, eyeConfirmOp, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(innerConfirmOp, "Password");

            AddHoverTransition(SignUpOperator, SignUpOperator.BackColor, SignUpOperator.ForeColor, SignUpOperator.ForeColor, SignUpOperator.BackColor);
            AddHoverTransition(OpBackArrow, OpBackArrow.BackColor, Color.Silver, OpBackArrow.ForeColor, OpBackArrow.ForeColor);

            ////////Service Provider//////////
            ///
            SetupGroupBoxFocusBehavior(ProviderName, ProviderInnerName);
            AddPlaceholder(ProviderInnerName, "Zaid Brothers & sons");

            SetupGroupBoxFocusBehavior(ProviderLocation, ProviderLocationInner);
            AddPlaceholder(ProviderLocationInner, "123 Street, Lahore");

            SetupGroupBoxFocusBehavior(ProviderEmailBox, ProviderInnerEmail);
            AddPlaceholder(ProviderInnerEmail, "neendaarahi@gmail.com");

            SetupGroupBoxFocusBehavior(ProviderAboutBox, ProviderInnerAbout);
            //i know how to spell meat(meet)
            AddPlaceholder(ProviderInnerAbout, "Where Peace meats Luxury!!");

            //SetupGroupBoxFocusBehavior(ProviderPasswordBox, ProviderInnerPassword);
            SetupPasswordField(ProviderPasswordBox, ProviderInnerPassword, providerPassEye, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(ProviderInnerPassword, "Password");

            SetupPasswordField(ProviderConfirmPassword, ProviderInnerConfirm, ProviderConfirmEye, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(ProviderInnerConfirm, "Password");

            AddHoverTransition(ProviderSignUp, ProviderSignUp.BackColor, ProviderSignUp.ForeColor, ProviderSignUp.ForeColor, ProviderSignUp.BackColor);
            AddHoverTransition(ProviderIsBack, ProviderIsBack.BackColor, Color.Silver, ProviderIsBack.ForeColor, ProviderIsBack.ForeColor);

            ////////Admin//////////
            SetupGroupBoxFocusBehavior(AdminName, AdminInnerName);
            AddPlaceholder(AdminInnerName, "Admin");

            SetupGroupBoxFocusBehavior(AdminEmail, AdminInnerEmail);
            AddPlaceholder(AdminInnerEmail, "admin@hotmail.com");

            SetupGroupBoxFocusBehavior(AdminAbout, AdminInnerAbout);
            AddPlaceholder(AdminInnerAbout, "ME BE ADMIN PLEASE!!!");

            SetupPasswordField(AdminPassword, AdminInnerPassword, AdminPassEye, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(AdminInnerPassword, "Password");

            SetupPasswordField(AdminConfirm, AdminInnerConfirm, AdminConfirmEye, TravelEaseApp.Properties.Resources.eye, TravelEaseApp.Properties.Resources.hide);
            AddPlaceholder(AdminInnerConfirm, "Password");

            AddHoverTransition(AdminSignUpButton, AdminSignUpButton.BackColor, AdminSignUpButton.ForeColor, AdminSignUpButton.ForeColor, AdminSignUpButton.BackColor);
            AddHoverTransition(AdminIsBack, AdminIsBack.BackColor, Color.Silver, AdminIsBack.ForeColor, AdminIsBack.ForeColor);
        }


        private void SlideToPanel(Panel currentPanel, Panel nextPanel)
        {
            int step = 20;
            nextPanel.Left = this.Width;
            nextPanel.Top = currentPanel.Top;
            nextPanel.Visible = true;

            System.Windows.Forms.Timer slideTimer = new System.Windows.Forms.Timer();
            slideTimer.Interval = 10;
            slideTimer.Tick += (s, e) =>
            {
                currentPanel.Left -= step;
                nextPanel.Left -= step;

                if (nextPanel.Left <= 0)
                {
                    slideTimer.Stop();
                    nextPanel.Left = 0;
                    currentPanel.Visible = false;
                    currentPanel.Left = 0; // reset position
                    slideTimer.Dispose();
                }
            };
            slideTimer.Start();
        }

        private void GoBackArrow_Click(object sender, EventArgs e)
        {
            SlideToPanel(currentPanel, rolePanel);
            currentPanel = rolePanel;
        }

        private void TraverllerPanel_Paint(object sender, PaintEventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }

        private void rolePanel_Paint(object sender, PaintEventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }

        private void rolePanel_Click(object sender, EventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label

        }

        private void TraverllerPanel_Click(object sender, EventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }
        private void Panel_Click(object sender, EventArgs e)
        {
            this.ActiveControl = hiddenLabel; // Set focus to the hidden label
        }

    }
}
