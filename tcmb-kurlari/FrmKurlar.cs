using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using tcmb_kurlari.Siniflar;

namespace tcmb_kurlari
{
    public partial class FrmTcmbKurlari : Form
    {
        private readonly Tarih _tarih;

        public FrmTcmbKurlari()
        {
            InitializeComponent();
            _tarih = new Tarih();
        }

        private void FrmTcmbKurlari_Load(object sender, EventArgs e)
        {
            TarihAraligiBelirle();

            _tarih.GunuAl(dtpTarih);

            if (Baglanti.Kontrol())
                dtpTarih.Click += DtpTarih_ValueChanged;
            else
                MessageBox.Show(@"Maalesef internet bağlantınız yok. TCMB'nin web sitesine bağlanamazsınız.", @"Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TarihAraligiBelirle()
        {
            // TCMB'nin ilk XML yayınına başladığı ve mevcut güne göre DateTimePicker'ı kısıtla
            dtpTarih.MaxDate = _tarih.GunIciSaatKontrolu();
            dtpTarih.MinDate = new DateTime(1996, 05, 02);
        }

        private void DtpTarih_ValueChanged(object sender, EventArgs e)
        {
            string link = _tarih.GunuAl(dtpTarih);
            try
            {
                DataGridOlustur(link);
                tsDurum.Text = XmlOku.BilgiAl(link);
            }
            catch (Exception)
            {
                MessageBox.Show(@"İstem yaptığınız güne dair herhangi bir veri bulunamadı. Yarım gün veya resmi tatil olabilir. Başka bir gün seçmeyi deneyin.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridOlustur(string link)
        {
            dataGridGorunumu.DataSource = VeriSetiOlustur(link).Tables[1];

            DataGridIslem dataGridIslem = new DataGridIslem();
            dataGridIslem.Gorunum(dataGridGorunumu);
        }

        private DataSet VeriSetiOlustur(string link)
        {
            // İstem yapılan sayfanın var olup olmamasına göre işleme devam et
            DataSet dataSet = new DataSet();
            dataSet.Clear();
            dataSet.ReadXml(link);

            return dataSet;
        }

        private void MenuSayfayaGit_Click(object sender, EventArgs e)
        {
            Process.Start(_tarih.GunuAl(dtpTarih));
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