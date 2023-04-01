namespace TcmbLibrary
{
    public class WebSitesi
    {
        public string Adres(Tarih tarih)
        {
            return "http://www.tcmb.gov.tr/kurlar/" + tarih.Gun + ".xml";
        }
    }
}