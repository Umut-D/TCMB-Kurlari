using System;
using System.Diagnostics;
using System.Windows.Forms;
using TcmbLibrary;
using TcmbLibrary.DataGrid;

namespace TcmbUI
{
    public partial class FrmTcmbKurlari : Form
    {
        private readonly Tarih _tarih;
        private readonly WebSitesi _webSitesi;

        public FrmTcmbKurlari()
        {
            InitializeComponent();

            _tarih = new Tarih();
            _webSitesi = new WebSitesi();
        }

        private void FrmTcmbKurlari_Load(object sender, EventArgs e)
        {
            DateTimePickerTarihAraligi();

            Internet internet = new Internet();
            if (internet.BaglantiVarMi())
                dtpTarih.Click += DtpTarih_ValueChanged;
        }

        private void DateTimePickerTarihAraligi()
        {
            dtpTarih.MaxDate = DateTime.Today;
            dtpTarih.MinDate = new DateTime(1996, 05, 02);
        }

        private void DtpTarih_ValueChanged(object sender, EventArgs e)
        {
            _tarih.SecilenGun(dtpTarih.Value);
            string webLink = _webSitesi.Adres(_tarih);

            try
            {
                DataGridOlustur(webLink);
                tsDurum.Text = new XmlBelge().BultenBilgisiAl(webLink);
            }
            catch (Exception)
            {
                dataGridGorunumu.DataSource = null;

                MessageBox.Show(@"İstem yaptığınız güne dair herhangi bir veri bulunamadı. Bunun iki olası sebebi var:;"
                                + Environment.NewLine +
                                @"1) Bulunulan günün saati 15:30'dan önce olabilir. Zira TCMB, bulunulan günün verilerini 15:30 itibariyle paylaşıma sunmakta."
                                + Environment.NewLine +
                                @"2) Seçilen gün; hafta sonuna, resmi tatil veya bayram tatiline denk gelmiş olabilir.",
                    @"Gün Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridOlustur(string link)
        {
            var dataSet = new DataSetIslem();
            dataGridGorunumu.DataSource = dataSet.Olustur(link).Tables[1];

            var dataGrid = new DataGridIslem(dataGridGorunumu);
            dataGrid.Gorunum();
        }

        private void MenuSayfayaGit_Click(object sender, EventArgs e)
        {
            Process.Start(_webSitesi.Adres(_tarih));
        }

        private void MenuHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Türkiye Cumhuriyeti Merkez Bankası'nın (TCMB) resmi web sitesinde yayınlanan ve '2 Mayıs 1996’dan bugüne değin' sunulan döviz alış/satış ve döviz efektif alış/satış bilgilerini görebilirsiniz.",
                @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MenuCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}