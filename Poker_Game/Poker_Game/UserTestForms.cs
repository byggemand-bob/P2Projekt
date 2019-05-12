using System;
using System.Windows.Forms;

namespace Poker_Game
{
    static class UserTestForms
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UserTestForm());

        }
    }
}
