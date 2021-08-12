using System.Net;
using System.Windows.Forms;

namespace TcmbLibrary
{
    public class Internet
    {
        private readonly Tarih _tarih;

        public Internet(Tarih tarih)
        {
            _tarih = tarih;
        }

        public bool BaglantiVarMi()
        {
            try
            {
                using (WebClient webBaglanti = new WebClient())
                {
                    using (webBaglanti.OpenRead("http://google.com/"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Maalesef internet bağlantınız bulunmuyor. Dolayısıyla, Türkiye Cumhuriyeti Merkez Bankası'nın web sitesine bağlanıp verileri alamazsınız.", @"Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public string OlusturulanWebAdresi()
        {
            return "http://www.tcmb.gov.tr/kurlar/" + _tarih.Gun + ".xml";
        }
    }
}