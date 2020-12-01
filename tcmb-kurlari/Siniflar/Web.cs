namespace tcmb_kurlari.Siniflar
{
    public static class Web
    {
        public static string Adres(string gunAyYil)
        {
            return "http://www.tcmb.gov.tr/kurlar/" + gunAyYil + ".xml";
        }
    }
}