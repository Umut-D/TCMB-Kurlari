using System;
using System.Windows.Forms;

namespace tcmb_kurlari
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmTcmbKurlari());
        }
    }
}
