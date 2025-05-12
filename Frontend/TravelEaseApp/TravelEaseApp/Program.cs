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
            string regNo = "123456"; // Example registration number
            Application.Run(new ReportsForm(3));
        }
    }
}
