namespace WUManager
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    static class Program
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        static extern void FreeConsole();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            FreeConsole();

            //IntPtr hWnd = FindWindow(null, Console.Title);
            //if (hWnd != IntPtr.Zero)
            //{
            //    ShowWindow(hWnd, 0); // 0 = SW_HIDE
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
