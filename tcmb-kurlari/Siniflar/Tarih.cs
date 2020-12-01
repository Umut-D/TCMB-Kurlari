using System;
using System.Windows.Forms;

namespace tcmb_kurlari.Siniflar
{
    public class Tarih
    {
        private string _gun, _ay, _yil;
        private DateTime _tarihAl;

        // TCMB'deki mevcut XML sayfasına erişmek için düzenli link oluştur 
        public string GunuAl(DateTimePicker dtpTarih)
        {
            _gun = dtpTarih.Value.Day.ToString("00");
            _ay = dtpTarih.Value.Month.ToString("00");
            _yil = dtpTarih.Value.Year.ToString();

            return TarihtenWebAdresOlustur();
        }

        private string TarihtenWebAdresOlustur()
        {
            HaftaSonuKontrol();

            string gunAyYil = _yil + _ay + "/" + _gun + _ay + _yil;
            return Web.Adres(gunAyYil);
        }

        private void HaftaSonuKontrol()
        {
            // Kullanıcı hafta sonundan bir gün seçerse, istem tarihini o haftanın cumasına sabitle
            string secilenTarih = _gun + "/" + _ay + "/" + _yil;
            _tarihAl = Convert.ToDateTime(secilenTarih);

            switch (_tarihAl.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    _tarihAl = _tarihAl.AddDays(-1);
                    break;
                case DayOfWeek.Sunday:
                    _tarihAl = _tarihAl.AddDays(-2);
                    break;
            }

            GunAyYilDegerleri();
        }

        private void GunAyYilDegerleri()
        {
            _gun = _tarihAl.Day.ToString("00");
            _ay = _tarihAl.Month.ToString("00");
            _yil = _tarihAl.Year.ToString();
        }

        public DateTime GunIciSaatKontrolu()
        {
            // Mevcut günün saati 15:30 geçmişse aynı günü, geçmemişse bir önceki günü seç
            if (DateTime.Now.TimeOfDay <= new TimeSpan(15, 30, 0))
                return DateTime.Today.AddDays(-1);

            return DateTime.Today;
        }
    }
}