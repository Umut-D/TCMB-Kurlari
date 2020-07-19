using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using tcmb_kurlari.Siniflar;

namespace tcmb_kurlari
{
    public partial class FrmTcmbKurlari : Form
    {
        public FrmTcmbKurlari()
        {
            InitializeComponent();
        }

        private readonly Tarih _tarih = new Tarih();

        private void FrmTcmbKurlari_Load(object sender, EventArgs e)
        {
            // TCMB'nin ilk XML yayınına başladığı ve mevcut güne göre DateTimePicker'ı kısıtla
            dtpTarih.MaxDate = _tarih.GunKontrol();
            dtpTarih.MinDate = new DateTime(1996, 05, 02);

            _tarih.LinkOlustur(dtpTarih);

            if (Baglanti.Kontrol())
                dtpTarih.Click += dtpTarih_ValueChanged;
            else
                MessageBox.Show(@"Maalesef internet bağlantınız yok. TCMB'nin web sitesine bağlanamazsınız.", @"Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            string link = _tarih.LinkOlustur(dtpTarih);
            try
            {
                // İstem yapılan sayfanın var olup olmamasına göre işleme devam et
                DataSet dataSet = new DataSet();

                dataSet.Clear();
                dataSet.ReadXml(link);

                // Mevcut verileri 2. tablodan alarak işe koyul
                dataGridGorunumu.DataSource = dataSet.Tables[1];
                DataGridIslem.Gorunum(dataGridGorunumu);

                tsDurum.Text = new XmlOku().BilgiAl(link);
            }
            // Hafta içine gelen bazı özel günlerde (Örn. 29 Ekim vb.) kur sayfası güncellenmiyor
            // Bu durumsa program hata veriyor. Bu fonksiyon ile sayfanın veri döndürüp döndürmediği kontrol ediliyor
            catch (Exception)
            {
                MessageBox.Show(@"İstem yaptığınız güne dair herhangi bir veri bulunamadı. Yarım gün veya resmi tatil olabilir. Başka bir gün seçmeyi deneyin.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuSayfayaGit_Click(object sender, EventArgs e)
        {
            // Kullanıcının belirttiği günün sayfasını aç
            Process.Start(_tarih.LinkOlustur(dtpTarih));
        }

        private void MenuHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Türkiye Cumhuriyeti Merkez Bankası'nın (TCMB) resmi web sitesinde '2 Mayıs 1996’dan bugüne değin' sunulan döviz alış/satış ve döviz efektif alış/satış bilgilerini görebilirsiniz.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}