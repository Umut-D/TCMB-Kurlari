using System;
using System.Windows.Forms;

namespace tcmb_kurlari.Siniflar
{
    class Tarih
    {
        private string Gun { get; set; }
        private string Ay { get; set; }
        private string Yil { get; set; }
        private DateTime TarihAl { get; set; }
        private string _tcmbAdres;

        public string TcmbAdres
        {
            get => _tcmbAdres;
            set => _tcmbAdres = "http://www.tcmb.gov.tr/kurlar/" + value + ".xml";
        }

        // TCMB'deki mevcut XML sayfasına erişmek için düzenli link oluştur 
        public string LinkOlustur(DateTimePicker dtpTarih)
        {
            Gun = dtpTarih.Value.Day.ToString("00");
            Ay = dtpTarih.Value.Month.ToString("00");
            Yil = dtpTarih.Value.Year.ToString();

            HaftaSonuKontrol();

            TcmbAdres = Yil + Ay + "/" + Gun + Ay + Yil;

            return TcmbAdres;
        }

        // Mevcut günün saati 15:30 geçmişse aynı günü, geçmemişse bir önceki günü seç
        public DateTime GunKontrol()
        {
            TimeSpan saat = DateTime.Now.TimeOfDay;
            TimeSpan kapanisSaati = new TimeSpan(15, 30, 0);
            
            if (saat <= kapanisSaati)
                return DateTime.Today.AddDays(-1);
            
            return DateTime.Today;
        }

        // Kullanıcı hafta sonundan bir gün seçerse tarihi o haftanın cumasına sabitle
        private void HaftaSonuKontrol()
        {
            string secilenTarih = Gun + "/" + Ay + "/" + Yil;
            TarihAl = Convert.ToDateTime(secilenTarih);

            switch (TarihAl.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    TarihAl = TarihAl.AddDays(-1);
                    break;
                case DayOfWeek.Sunday:
                    TarihAl = TarihAl.AddDays(-2);
                    break;
            }

            Gun = TarihAl.Day.ToString("00");
            Ay = TarihAl.Month.ToString("00");
            Yil = TarihAl.Year.ToString();
        }
    }
}