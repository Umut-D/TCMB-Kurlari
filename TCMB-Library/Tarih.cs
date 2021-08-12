using System;

namespace TcmbLibrary
{
    public class Tarih
    {
        public string Gun { get; private set; }
        private string _gun, _ay, _yil;

        public void SecilenGun(DateTime secilenTarih)
        {
            _gun = secilenTarih.Day.ToString("00");
            _ay = secilenTarih.Month.ToString("00");
            _yil = secilenTarih.Year.ToString();

            Gun = _yil + _ay + "/" + _gun + _ay + _yil;
        }
    }
}