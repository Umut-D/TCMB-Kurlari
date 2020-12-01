using System.Net.NetworkInformation;

namespace tcmb_kurlari.Siniflar
{
    public static class Baglanti
    {
        public static bool Kontrol()
        {
            Ping ping = new Ping();
            PingReply pingCevap = ping.Send("www.google.com", 1000);

            if (pingCevap?.Status == IPStatus.Success)
                return true;

            return false;
        }
    }
}