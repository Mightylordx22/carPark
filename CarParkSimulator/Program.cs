using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarParkSimulator
{
    static class Program
    {
        // What are you doing here? Nothing to see here.
        // The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimulatorInterface());
        }
    }
}
