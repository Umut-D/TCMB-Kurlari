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
            tsDurum.Text = Baglanti.Kontrol();
        }

        private void dovizKurlariIndir_Click(object sender, EventArgs e)
        {
            string link = _tarih.LinkOlustur(dtpTarih);

            // İstem yapılan sayfanın var olup olmamasına göre işleme devam et
            // Bazı yarım gün veya resmi tatillerde kur sayfası web sitesine eklenmiyor
            if (!Baglanti.Hata404VarMi(dtpTarih))
            {
                DataSet dataSet = new DataSet();

                dataSet.Clear();
                dataSet.ReadXml(link);

                // Mevcut verileri 2. tablodan alarak işe koyul
                dataGridGorunumu.DataSource = dataSet.Tables[1];
                DataGridIslem.Gorunum(dataGridGorunumu);

                XmlOku xmlOku = new XmlOku();
                tsDurum.Text = xmlOku.BilgiAl(link);
            }
        }

        private void dtpTarih_ValueChanged(object sender, EventArgs e)
        {
            _tarih.LinkOlustur(dtpTarih);
        }

        private void SayfayaGit_Click(object sender, EventArgs e)
        {
            // Kullanıcının belirttiği günün sayfasını aç
            Process.Start(_tarih.LinkOlustur(dtpTarih));
        }

        private void hakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Türkiye Cumhuriyeti Merkez Bankası'nın (TCMB) resmi web sitesinde sunulan güncel veya eski tarihli döviz alış/satış ve döviz efektif alış/satış bilgilerini görebilirsiniz.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}