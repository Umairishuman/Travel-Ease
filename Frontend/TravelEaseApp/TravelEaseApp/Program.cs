using System;
using System.Windows.Forms;
using TravelEaseApp;
using TravelEaseApp.TourOperator;

namespace TravelEase
{
    static class Program
    {
        [STAThread]
        static void Main()  
            ///////////WAIIIIIIIIIIISSSSSSSSSSSSSTTTTTTTTTTTTTTTTTT OOOOOOOFFFFFFFFFFFFFF TTTTTTTTTTTTTIMMMMMMMMMMEEEEEEEEEEEEE
        {
            // Start the application and run the SignInForm
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string regNo = "AD-000001"; // Example registration number
            //SignInForm signInForm = new SignInForm();

            Application.Run(new Traveller(regNo));
            //signInForm.Close();

        }
    }
}
