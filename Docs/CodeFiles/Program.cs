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
        {
            // Start the application and run the SignInForm
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInForm());
        }
    }
}
