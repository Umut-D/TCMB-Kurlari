using System.Linq;
using System.Windows.Forms;

namespace TcmbLibrary.DataGrid
{
    public class DataGridIslem
    {
        private readonly DataGridView _dataGrid;

        public DataGridIslem(DataGridView dataGrid)
        {
            _dataGrid = dataGrid;
        }

        public void Gorunum()
        {
            TumSutunlariEtkisizlestir();

            for (int sutun = 0; sutun < 7; sutun++)
            {
                if (IkinciSutunuIptalEt(sutun))
                    continue;

                BaslikSutunlari(sutun);

                ParaBirimliHucreleriSagaHizala(sutun);
            }

            BirimSutunuKucult();
        }

        private void BaslikSutunlari(int sutun)
        {
            _dataGrid.Columns[sutun].Visible = true;
            _dataGrid.Columns[sutun].HeaderText = new DataGridSutunlari().Sutunlar.ElementAt(sutun);
        }

        private void TumSutunlariEtkisizlestir()
        {
            // Tüm sutunları etkisiz hale getir (5 yıl önceki veri alanları ile şimdiki alanlar arasında fark olduğu için, görüntülenecek sabit sütunları seçmek daha mantıklı)
            foreach (DataGridViewBand sutunlar in _dataGrid.Columns)
                sutunlar.Visible = false;
        }

        private bool IkinciSutunuIptalEt(int sutunNo)
        {
            // Döviz Cinsi'nin yazdığı ikinci sütunu almaya gerek yok
            return sutunNo == 2;
        }

        private void ParaBirimliHucreleriSagaHizala(int sutun)
        {
            if (sutun > 2)
                _dataGrid.Columns[sutun].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void BirimSutunuKucult()
        {
            _dataGrid.Columns[0].Width = 45;
        }
    }
}