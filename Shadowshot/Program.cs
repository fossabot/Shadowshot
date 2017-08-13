﻿using System;
using System.Windows.Forms;
using Shadowshot.Views;

namespace Shadowshot
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var _ = new MainForm();

            Application.Run();
        }
    }
}
