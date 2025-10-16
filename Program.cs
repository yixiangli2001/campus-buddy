using campus_buddy.Forms;
using campus_buddy.Models;
namespace campus_buddy
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (var loginForm = new LoginForm())
            {
                var result = loginForm.ShowDialog(); 
                if (result == DialogResult.OK && loginForm.Tag is User user)
                {
                    Application.Run(new MainForm(user));
                }
                else
                {
                    return;
                }
            }

        }
    }
}
