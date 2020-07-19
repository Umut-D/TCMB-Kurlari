using System.Net.NetworkInformation;

namespace tcmb_kurlari.Siniflar
{
    class Baglanti : Tarih
    {
        // İnternet bağlantısının olup olmadığını Google'a ping atarak test et
        public static bool Kontrol()
        {
            PingReply pingDurum = new Ping().Send("www.google.com", 1000);

            if (pingDurum?.Status == IPStatus.Success)
                return true;

            return false;
        }
    }
}