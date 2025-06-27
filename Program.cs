using System;
using System.Windows.Forms;

namespace MyVN
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // ― ручная инициализация ―
            Application.SetHighDpiMode(HighDpiMode.SystemAware);   // DPI-Aware
            Application.EnableVisualStyles();                      // современные темы
            Application.SetCompatibleTextRenderingDefault(false);  // GDI+ для шрифтов

            Application.Run(new MainForm());
        }
    }
}
