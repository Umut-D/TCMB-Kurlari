using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace tcmb_kurlari.Siniflar
{
    class Baglanti : Tarih
    {
        // İnternet bağlantısının olup olmadığını Google'a ping atarak test et
        public static string Kontrol()
        {
            PingReply pingDurum = new Ping().Send("www.google.com", 1000);

            if (pingDurum?.Status == IPStatus.Success)
                return @"İnternet bağlantınız aktif. TCMB'nin web sitesine bağlanarak güncel kurları indirebilirsiniz.";

            return @"Maalesef internet bağlantınız yok. TCMB'nin web sitesine bağlanamazsınız.";
        }

        // Hafta içine gelen bazı özel günlerde (Örn. 29 Ekim vb.) kur sayfası güncellenmiyor
        // Bu durumsa program hata veriyor. Bu fonksiyon ile sayfanın veri döndürüp döndürmediği kontrol ediliyor
        public static bool Hata404VarMi(DateTimePicker dtpTarih)
        {
            try
            {
                Tarih tarih = new Tarih();
                WebClient webClient = new WebClient();
                Stream strm = webClient.OpenRead(tarih.LinkOlustur(dtpTarih));
                strm?.Flush();
            }
            catch (WebException)
            {
                MessageBox.Show(@"İstem yaptığınız güne dair herhangi bir veri bulunamadı. Yarım gün veya resmi tatil olabilir. Başka bir gün seçmeyi deneyin.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
    }
}