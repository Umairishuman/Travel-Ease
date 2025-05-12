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
            /* FOR TESTING:
            OP-000022 - tourOperator
            SP-000029 - serviceProvider
            */
            ////////////////////////////////////////////////
            // REGISTERATION NUMBER
            ////////////////////////////////////////////////
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string regNo = "123456"; // Example registration number
            Application.Run(new tourOperatorForm("OP-000022"));
        }
    }
}
