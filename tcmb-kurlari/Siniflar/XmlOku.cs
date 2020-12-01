using System;
using System.Xml;

namespace tcmb_kurlari.Siniflar
{
    public static class XmlOku
    {
        public static string BilgiAl(string linkBilgisi)
        {
            XmlReader xmlOku = XmlReader.Create(linkBilgisi);

            string bilgi = null;
            while (xmlOku.Read())
            {
                if (ElementVarMi(xmlOku)) 
                    continue;
                
                string bultenNo = xmlOku.GetAttribute("Bulten_No");
                string tarih = Convert.ToDateTime(xmlOku.GetAttribute("Tarih")).ToLongDateString();
                bilgi = tarih + @" günü saat 15:30'da belirlenen gösterge niteliğindeki TCMB kurları (Bülten No: " + bultenNo + @")";
            }

            return bilgi;
        }

        private static bool ElementVarMi(XmlReader xmlOku)
        {
            return xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "Tarih_Date" || !xmlOku.HasAttributes;
        }
    }
}