﻿using System;
using System.Windows.Forms;

namespace LibrarianUI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DashBoardLibrarian());
            MessageBox.Show("This is not the main entry point for the application!!!");
        }
    }
}