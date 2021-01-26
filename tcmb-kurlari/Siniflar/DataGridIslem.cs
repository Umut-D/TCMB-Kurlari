using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace tcmb_kurlari.Siniflar
{
    public class DataGridIslem
    {
        public void Gorunum(DataGridView dataGridGorunumu)
        {
            TumSutunlariEtkisizlestir(dataGridGorunumu);

            for (int sutun = 0; sutun < 7; sutun++)
            {
                if (IkinciSutunuIptalEt(sutun))
                    continue;

                dataGridGorunumu.Columns[sutun].Visible = true;
                dataGridGorunumu.Columns[sutun].HeaderText = SutunAdlari().ElementAt(sutun);

                ParaBirimliHucreleriSagaHizala(dataGridGorunumu, sutun);
            }

            BirimSutununKucult(dataGridGorunumu);
        }

        private void TumSutunlariEtkisizlestir(DataGridView dataGridGorunumu)
        {
            // Tüm sutunları etkisiz hale getir (5 yıl önceki veri alanları ile şimdiki alanlar arasında fark olduğu için, görüntülenecek sabit sütunları seçmek daha mantıklı)
            foreach (DataGridViewBand sutunlar in dataGridGorunumu.Columns)
                sutunlar.Visible = false;
        }

        private bool IkinciSutunuIptalEt(int sutunNo)
        {
            // Döviz Cinsi'nin yazdığı ikinci sütunu almaya gerek yok
            return sutunNo == 2;
        }

        private List<string> SutunAdlari()
        {
            List<string> sutunlar = new List<string>
            {
                "Birim",
                "İsim",
                "Döviz Cinsi",
                "Döviz Alış",
                "Döviz Satış",
                "Efektif Alış",
                "Efektif Satış"
            };

            return sutunlar;
        }

        private void ParaBirimliHucreleriSagaHizala(DataGridView dataGridGorunumu, int sutun)
        {
            if (sutun > 2)
                dataGridGorunumu.Columns[sutun].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void BirimSutununKucult(DataGridView dataGridGorunumu)
        {
            dataGridGorunumu.Columns[0].Width = 45;
        }
    }
}