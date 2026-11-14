using System;
using System.Windows.Forms;

namespace Lab06a
{
    internal static class Program
    {
        // WinForms yêu cầu STA khi sử dụng các thành phần giao diện của Windows.
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
