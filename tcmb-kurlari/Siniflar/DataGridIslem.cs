using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace tcmb_kurlari.Siniflar
{
    class DataGridIslem
    {
        private static List<string> SutunAdlari()
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

        public static void Gorunum(DataGridView dataGridGorunumu)
        {
            // Tüm sutunları etkisiz hale getir (5 yıl önceki veri alanları ile şimdiki alanlar arasında fark olduğu için, görüntülenecek sabit sütunları seçmek daha mantıklı)
            foreach (DataGridViewBand sutunlar in dataGridGorunumu.Columns)
                sutunlar.Visible = false;

            for (int i = 0; i < 7; i++)
            {
                // Döviz Cinsi'nin yazdığı ikinci sütunu almaya gerek yok
                if (i == 2)
                    continue;

                dataGridGorunumu.Columns[i].Visible = true;
                dataGridGorunumu.Columns[i].HeaderText = SutunAdlari().ElementAt(i);

                // Para birimleri olan hücreleri sağa hizala (Excel stili olsun)
                if (i > 2)
                    dataGridGorunumu.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Birim sütununu küçült (Yoksa çok göze batıyor)
            dataGridGorunumu.Columns[0].Width = 45;
        }
    }
}