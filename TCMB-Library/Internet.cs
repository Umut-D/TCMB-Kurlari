using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace TcmbLibrary
{
    public class Internet
    {
        public bool BaglantiVarMi()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingCevap = ping.Send("www.google.com", 1000, new byte[32]);
                if (pingCevap?.Status == IPStatus.Success)
                    return true;
            }
            catch
            {
                MessageBox.Show(
                    @"Maalesef internet bağlantınız bulunmuyor. Dolayısıyla, Türkiye Cumhuriyeti Merkez Bankası'nın web sitesine bağlanıp verileri alamazsınız.",
                    @"Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}