using System;
using System.Xml;

namespace TcmbLibrary
{
    public class XmlBelge
    {
        public string BultenBilgisiAl(string webLink)
        {
            XmlReader xmlOku = XmlReader.Create(webLink);

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

        private bool ElementVarMi(XmlReader xmlOku)
        {
            return xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "Tarih_Date" || !xmlOku.HasAttributes;
        }
    }
}