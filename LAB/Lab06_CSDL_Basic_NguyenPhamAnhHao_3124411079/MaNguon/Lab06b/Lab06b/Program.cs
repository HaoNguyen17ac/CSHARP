using System;
using System.Windows.Forms;

namespace Lab06b
{
    internal static class Program
    {
        // WinForms dùng STA để hỗ trợ các thành phần giao diện của Windows.
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
