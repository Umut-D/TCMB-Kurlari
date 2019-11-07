using System;
using System.Xml;

namespace tcmb_kurlari.Siniflar
{
    class XmlOku
    {
        private string Bilgi { get; set; }
        private DateTime Tarih { get; set; }
        private string BultenNo { get; set; }

        // Durum çubuğunda gün, bülten numarası bilgisi göster    
        public string BilgiAl(string linkBilgisi)
        {
            XmlReader xmlOku = XmlReader.Create(linkBilgisi);

            while (xmlOku.Read())
            {
                if (xmlOku.NodeType == XmlNodeType.Element && xmlOku.Name == "Tarih_Date" && xmlOku.HasAttributes)
                {
                    Tarih = Convert.ToDateTime(xmlOku.GetAttribute("Tarih"));
                    BultenNo = xmlOku.GetAttribute("Bulten_No");

                    Bilgi = Tarih.ToLongDateString() + @" günü saat 15:30'da belirlenen gösterge niteliğindeki TCMB kurları (Bülten No: " + BultenNo + @")";
                }
            }

            return Bilgi;
        }
    }
}