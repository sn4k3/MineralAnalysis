using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineralAnalysis
{
    static class Program
    {
        public static FrmMain FrmMain { get; private set; }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        [SecurityCritical]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe")) {
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += ApplicationOnThreadException;

            // Set the unhandled exception mode to force all Windows Forms errors
            // to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            //}

            FrmMain = new FrmMain();
            Application.Run(FrmMain);
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            MessageBox.Show(ex.ExceptionObject.ToString(), "Unhandled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs ex)
        {
            MessageBox.Show(ex.Exception.ToString(), "Unhandled Thread Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
