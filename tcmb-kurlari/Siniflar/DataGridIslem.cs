using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace tcmb_kurlari.Siniflar
{
    public class DataGridIslem
    {
        private List<string> SutunAdlari()
        {
            List<string> sutunAdlari = new List<string>
            {
                "Birim",
                "İsim",
                "Döviz Cinsi",
                "Döviz Alış",
                "Döviz Satış",
                "Efektif Alış",
                "Efektif Satış"
            };

            return sutunAdlari;
        }

        public void Gorunum(DataGridView dataGridGorunumu)
        {
            TumSutunlariEtkisizlestir(dataGridGorunumu);

            for (int sutun = 0; sutun < 7; sutun++)
            {
                if (IkinciSutunuIptalEt(sutun)) 
                    continue;

                dataGridGorunumu.Columns[sutun].Visible = true;
                dataGridGorunumu.Columns[sutun].HeaderText = SutunAdlari().ElementAt(sutun);

                HucreleriSagaHizala(dataGridGorunumu, sutun);
            }

            BirimSutununKucult(dataGridGorunumu);
        }

        private void TumSutunlariEtkisizlestir(DataGridView dataGridGorunumu)
        {
            // Tüm sutunları etkisiz hale getir (5 yıl önceki veri alanları ile şimdiki alanlar arasında fark olduğu için, görüntülenecek sabit sütunları seçmek daha mantıklı)
            foreach (DataGridViewBand sutunlar in dataGridGorunumu.Columns)
                sutunlar.Visible = false;
        }

        private bool IkinciSutunuIptalEt(int i)
        {
            // Döviz Cinsi'nin yazdığı ikinci sütunu almaya gerek yok
            return i == 2;
        }

        private void HucreleriSagaHizala(DataGridView dataGridGorunumu, int sutun)
        {
            // Para birimleri olan hücreleri sağa hizala (Excel stili olsun)
            if (sutun > 2)
                dataGridGorunumu.Columns[sutun].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void BirimSutununKucult(DataGridView dataGridGorunumu)
        {
            dataGridGorunumu.Columns[0].Width = 45;
        }
    }
}