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
using static TravelEaseApp.Helpers;
using System.Data.SqlClient;

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
            AddPlaceholder(innerCNIC, "12345123456712");

            SetupGroupBoxFocusBehavior(BioBox, innerBio);
            AddPlaceholder(innerBio, "I am a software engineer");

            SetupGroupBoxFocusBehavior(NationalityBox, innerNationality);
            AddPlaceholder(innerNationality, "Pakistan");

            SetupGroupBoxFocusBehavior(PhoneNoBox, innerPhoneNoBox);
            AddPlaceholder(innerPhoneNoBox, "03001234567");

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

            SetupGroupBoxFocusBehavior(PhoneNoOpBox, innerOpPhoneBox);
            AddPlaceholder(innerOpPhoneBox, "03001234567");

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

            SetupGroupBoxFocusBehavior(PhoneSPBox, innerSPPhoneBox);
            AddPlaceholder(innerSPPhoneBox, "03001234567");


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

            SetupGroupBoxFocusBehavior(adminPhoneNoBox, innerAdminPhone);
            AddPlaceholder(innerAdminPhone, "03001234567");

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



        // 1. Email Validation
        public bool ValidateEmail(TextBox emailBox)
        {
            string email = emailBox.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email field cannot be empty.");
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE contact_email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("This email is already registered.");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking email in database: " + ex.Message);
                return false;
            }

            return true;
        }


        // 2. DOB (Age ≥ 13, Not Future)
        public bool ValidateDOB(DateTimePicker dobPicker)
        {
            DateTime selectedDate = dobPicker.Value;
            DateTime today = DateTime.Today;

            if (selectedDate > today)
            {
                MessageBox.Show("Date of birth cannot be in the future.");
                return false;
            }

            int age = today.Year - selectedDate.Year;
            if (selectedDate > today.AddYears(-age)) age--;

            if (age < 13)
            {
                MessageBox.Show("User must be at least 13 years old.");
                return false;
            }

            return true;
        }

        // 3. CNIC (14 digits, numeric only)
        public bool ValidateCNIC(TextBox cnicBox)
        {
            string cnic = cnicBox.Text.Trim();

            if (string.IsNullOrEmpty(cnic))
            {
                MessageBox.Show("CNIC field cannot be empty.");
                return false;
            }

            if (!Regex.IsMatch(cnic, @"^\d{14}$"))
            {
                MessageBox.Show("CNIC must be exactly 14 digits and contain only numbers.");
                return false;
            }

            return true;
        }

        // 4. Nationality (no digits allowed)
        public bool ValidateNationality(TextBox nationalityBox)
        {
            string nationality = nationalityBox.Text.Trim();

            if (string.IsNullOrEmpty(nationality))
            {
                MessageBox.Show("Nationality field cannot be empty.");
                return false;
            }

            if (Regex.IsMatch(nationality, @"\d"))
            {
                MessageBox.Show("Nationality must not contain numbers.");
                return false;
            }

            return true;
        }

        // 5. Phone Number (valid prefix and digits)
        public bool ValidatePhone(TextBox phoneBox)
        {
            string phone = phoneBox.Text.Trim();

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Phone number cannot be empty.");
                return false;
            }

            if (!Regex.IsMatch(phone, @"^(?:\+|0|92|3)\d{9,14}$"))
            {
                MessageBox.Show("Phone number must be valid and start with '+', '0', '92', or '3'.");
                return false;
            }

            return true;
        }

        // 6. Passwords (≥8 chars, must match)
        public bool ValidatePasswords(TextBox passwordBox, TextBox confirmPasswordBox)
        {
            string password = passwordBox.Text;
            string confirmPassword = confirmPasswordBox.Text;

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Password fields cannot be empty.");
                return false;
            }

            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long.");
                return false;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return false;
            }

            return true;
        }

        private string GetNextRegNo(string userType)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                UPDATE reg_counter
                SET last_number = last_number + 1
                OUTPUT INSERTED.last_number
                WHERE user_type = @type;
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@type", userType);
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            int number = Convert.ToInt32(result);
                            return userType + "-" + number.ToString("D6");
                        }
                        else
                        {
                            throw new Exception("User type not found in reg_counter.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating registration number: " + ex.Message);
                return null; // Caller should handle null as failure
            }
        }


        private void TravellerSIgnUp_Click(object sender, EventArgs e)
        {
            // Run validations first
            if (!ValidateEmail(innerEmail)) return;
            if (!ValidatePhone(innerPhoneNoBox)) return;
            if (!ValidateCNIC(innerCNIC)) return;
            if (!ValidateNationality(innerNationality)) return;
            if (!ValidateDOB(DateOfBirthPicker)) return;
            if (!ValidatePasswords(innerPasswordBox, innerConfirmPassword)) return;
            if (innerFirstNameBox.Text.Trim() == "" || innerLastName.Text.Trim() == "")
            {
                MessageBox.Show("First name and last name cannot be empty.");
                return;
            }


            string here = "here";
            // All validations passed — proceed
            string regNo = GetNextRegNo("TR");

            string firstName = innerFirstNameBox.Text.Trim();
            string lastName = innerLastName.Text.Trim();
            string email = innerEmail.Text.Trim();
            string phone = innerPhoneNoBox.Text.Trim();
            string password = innerPasswordBox.Text;
            string cnic = innerCNIC.Text.Trim();
            string nationality = innerNationality.Text.Trim();
            DateTime dob = DateOfBirthPicker.Value;
            string profileDescription = innerBio.Text.Trim();
            string profileImageUrl = "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert into users table
                    string insertUser = @"
                INSERT INTO users 
                (reg_no, password_hash, contact_email, contact_phone, user_status, user_role, user_profile_image, user_profile_description)
                VALUES
                (@reg_no, @password, @contact_email, @contact_phone, 'pending', 'traveler', @image, @description);";

                    using (SqlCommand cmd = new SqlCommand(insertUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@contact_email", email);
                        cmd.Parameters.AddWithValue("@contact_phone", phone);
                        cmd.Parameters.AddWithValue("@image", profileImageUrl);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(profileDescription) ? (object)DBNull.Value : profileDescription);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into travelers table
                    string insertTraveler = @"
                INSERT INTO travelers 
                (reg_no, first_name, last_name, nationality, cnic, date_of_birth)
                VALUES
                (@reg_no, @first_name, @last_name, @nationality, @cnic, @dob);";

                    using (SqlCommand cmd = new SqlCommand(insertTraveler, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@first_name", firstName);
                        cmd.Parameters.AddWithValue("@last_name", lastName);
                        cmd.Parameters.AddWithValue("@nationality", nationality);
                        cmd.Parameters.AddWithValue("@cnic", cnic);
                        cmd.Parameters.AddWithValue("@dob", dob);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Traveler registered successfully with Reg No: " + regNo);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Registration failed: " + ex.Message);
                }
            }
        }

        private void SignUpOperator_Click(object sender, EventArgs e)
        {
            // Run validations first
            if (!ValidateEmail(innerOpEmail)) return;
            if (!ValidatePhone(innerOpPhoneBox)) return;
            if (innerOpNameBox.Text.Trim() == "" || innerOpNameBox.Text.Trim() == "Tayyab & Sons")
            {
                MessageBox.Show("Operator name cannot be empty.");
                return;
            }
            if (innerAddressOpBox.Text.Trim() == "" || innerAddressOpBox.Text.Trim() == "123 Street, Lahore")
            {
                MessageBox.Show("Business address cannot be empty.");
                return;
            }
            if (!ValidatePasswords(innerPasswordOp, innerConfirmOp)) return;

            // All validations passed — proceed
            string regNo = GetNextRegNo("OP");

            string operatorName = innerOpNameBox.Text.Trim();
            string businessAddress = innerAddressOpBox.Text.Trim();
            string email = innerOpEmail.Text.Trim();
            string phone = innerOpPhoneBox.Text.Trim();
            string password = innerPasswordOp.Text;
            string websiteUrl = innerWebUrl.Text.Trim();
            string profileImageUrl = "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert into users table
                    string insertUser = @"
                INSERT INTO users 
                (reg_no, password_hash, contact_email, contact_phone, user_status, user_role, user_profile_image)
                VALUES
                (@reg_no, @password, @contact_email, @contact_phone, 'pending', 'tour_operator', @image);";

                    using (SqlCommand cmd = new SqlCommand(insertUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@contact_email", email);
                        cmd.Parameters.AddWithValue("@contact_phone", phone);
                        cmd.Parameters.AddWithValue("@image", profileImageUrl);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into tour_operator table
                    string insertOperator = @"
                INSERT INTO tour_operator 
                (reg_no, operator_name, business_address, website_url)
                VALUES
                (@reg_no, @operator_name, @business_address, @website_url);";

                    using (SqlCommand cmd = new SqlCommand(insertOperator, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@operator_name", operatorName);
                        cmd.Parameters.AddWithValue("@business_address", businessAddress);
                        cmd.Parameters.AddWithValue("@website_url", string.IsNullOrWhiteSpace(websiteUrl) ? (object)DBNull.Value : websiteUrl);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Tour operator registered successfully with Reg No: " + regNo);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Registration failed: " + ex.Message);
                }
            }
        }

        private void ProviderSignUp_Click(object sender, EventArgs e)
        {
            // Run validations first
            if (!ValidateEmail(ProviderInnerEmail)) return;
            if (!ValidatePhone(innerSPPhoneBox)) return;
            if (ProviderInnerName.Text.Trim() == "")
            {
                MessageBox.Show("Provider name cannot be empty.");
                return;
            }
            if (ProviderLocationInner.Text.Trim() == "")
            {
                MessageBox.Show("Provider location cannot be empty.");
                return;
            }
            if (!ValidatePasswords(ProviderInnerPassword, ProviderInnerConfirm)) return;

            // All validations passed — proceed
            string regNo = GetNextRegNo("SP");

            string providerName = ProviderInnerName.Text.Trim();
            string providerLocation = ProviderLocationInner.Text.Trim();
            string email = ProviderInnerEmail.Text.Trim();
            string phone = innerSPPhoneBox.Text.Trim();
            string password = ProviderInnerPassword.Text;
            string about = ProviderInnerAbout.Text.Trim();
            string profileImageUrl = "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert into users table
                    string insertUser = @"
                INSERT INTO users 
                (reg_no, password_hash, contact_email, contact_phone, user_status, user_role, 
                 user_profile_image, user_profile_description)
                VALUES
                (@reg_no, @password, @contact_email, @contact_phone, 'pending', 'service_provider', 
                 @image, @description);";

                    using (SqlCommand cmd = new SqlCommand(insertUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@contact_email", email);
                        cmd.Parameters.AddWithValue("@contact_phone", phone);
                        cmd.Parameters.AddWithValue("@image", profileImageUrl);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(about) ? (object)DBNull.Value : about);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into service_provider table
                    string insertProvider = @"
                INSERT INTO service_provider 
                (reg_no, provider_name, provider_location)
                VALUES
                (@reg_no, @provider_name, @provider_location);";

                    using (SqlCommand cmd = new SqlCommand(insertProvider, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@provider_name", providerName);
                        cmd.Parameters.AddWithValue("@provider_location", providerLocation);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Service provider registered successfully with Reg No: " + regNo);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Registration failed: " + ex.Message);
                }
            }
        }

        private void AdminSignUpButton_Click(object sender, EventArgs e)
        {
            // Run validations first
            if (!ValidateEmail(AdminInnerEmail)) return;
            if (!ValidatePhone(innerAdminPhone)) return;
            if (AdminInnerName.Text.Trim() == "")
            {
                MessageBox.Show("Admin name cannot be empty.");
                return;
            }
            if (!ValidatePasswords(AdminInnerPassword, AdminInnerConfirm)) return;

            // All validations passed — proceed
            string regNo = GetNextRegNo("AD");

            string adminName = AdminInnerName.Text.Trim();
            string email = AdminInnerEmail.Text.Trim();
            string phone = innerAdminPhone.Text.Trim();
            string password = AdminInnerPassword.Text;
            string about = AdminInnerAbout.Text.Trim();
            string profileImageUrl = "https://i.postimg.cc/j5dPFtS8/fabrizio-conti-c3ws-Mnx-QZDw-unsplash.jpg";
            DateTime currentTimestamp = DateTime.Now;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert into users table
                    string insertUser = @"
                INSERT INTO users 
                (reg_no, password_hash, contact_email, contact_phone, user_status, user_role, 
                 user_profile_image, user_profile_description)
                VALUES
                (@reg_no, @password, @contact_email, @contact_phone, 'pending', 'admin', 
                 @image, @description);";

                    using (SqlCommand cmd = new SqlCommand(insertUser, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@contact_email", email);
                        cmd.Parameters.AddWithValue("@contact_phone", phone);
                        cmd.Parameters.AddWithValue("@image", profileImageUrl);
                        cmd.Parameters.AddWithValue("@description", string.IsNullOrWhiteSpace(about) ? (object)DBNull.Value : about);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into admins table
                    string insertAdmin = @"
                INSERT INTO admins 
                (reg_no, admin_name, last_action_timestamp)
                VALUES
                (@reg_no, @admin_name, @timestamp);";

                    using (SqlCommand cmd = new SqlCommand(insertAdmin, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@reg_no", regNo);
                        cmd.Parameters.AddWithValue("@admin_name", adminName);
                        cmd.Parameters.AddWithValue("@timestamp", currentTimestamp);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Admin registered successfully with Reg No: " + regNo);
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Registration failed: " + ex.Message);
                }
            }
        }
    }
}
