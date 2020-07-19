namespace tcmb_kurlari
{
    partial class FrmTcmbKurlari
    {
        /// <summary>
        ///Gerekli designer değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        ///Designer desteği için gerekli metottur; bu metodun
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTcmbKurlari));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.dosyaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTcmbSayfasi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridGorunumu = new System.Windows.Forms.DataGridView();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.menu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGorunumu)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dosyaToolStripMenuItem,
            this.menuHakkinda});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(780, 31);
            this.menu.TabIndex = 0;
            // 
            // dosyaToolStripMenuItem
            // 
            this.dosyaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTcmbSayfasi,
            this.menuCikis});
            this.dosyaToolStripMenuItem.Name = "dosyaToolStripMenuItem";
            this.dosyaToolStripMenuItem.Size = new System.Drawing.Size(72, 27);
            this.dosyaToolStripMenuItem.Text = "Dosya";
            // 
            // menuTcmbSayfasi
            // 
            this.menuTcmbSayfasi.Name = "menuTcmbSayfasi";
            this.menuTcmbSayfasi.Size = new System.Drawing.Size(395, 30);
            this.menuTcmbSayfasi.Text = "Günün TCMB Döviz Kuru Sayfasına Git";
            this.menuTcmbSayfasi.Click += new System.EventHandler(this.MenuSayfayaGit_Click);
            // 
            // menuCikis
            // 
            this.menuCikis.Name = "menuCikis";
            this.menuCikis.Size = new System.Drawing.Size(395, 30);
            this.menuCikis.Text = "Çıkış";
            this.menuCikis.Click += new System.EventHandler(this.MenuCikis_Click);
            // 
            // menuHakkinda
            // 
            this.menuHakkinda.Name = "menuHakkinda";
            this.menuHakkinda.Size = new System.Drawing.Size(96, 27);
            this.menuHakkinda.Text = "Hakkında";
            this.menuHakkinda.Click += new System.EventHandler(this.MenuHakkinda_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDurum});
            this.statusStrip.Location = new System.Drawing.Point(0, 491);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(780, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // tsDurum
            // 
            this.tsDurum.Name = "tsDurum";
            this.tsDurum.Size = new System.Drawing.Size(0, 15);
            // 
            // dataGridGorunumu
            // 
            this.dataGridGorunumu.AllowUserToAddRows = false;
            this.dataGridGorunumu.AllowUserToDeleteRows = false;
            this.dataGridGorunumu.AllowUserToOrderColumns = true;
            this.dataGridGorunumu.AllowUserToResizeRows = false;
            this.dataGridGorunumu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridGorunumu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridGorunumu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridGorunumu.Location = new System.Drawing.Point(0, 31);
            this.dataGridGorunumu.Name = "dataGridGorunumu";
            this.dataGridGorunumu.ReadOnly = true;
            this.dataGridGorunumu.RowHeadersVisible = false;
            this.dataGridGorunumu.RowHeadersWidth = 57;
            this.dataGridGorunumu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridGorunumu.Size = new System.Drawing.Size(780, 460);
            this.dataGridGorunumu.TabIndex = 2;
            // 
            // dtpTarih
            // 
            this.dtpTarih.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTarih.Location = new System.Drawing.Point(593, 1);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(187, 30);
            this.dtpTarih.TabIndex = 3;
            this.dtpTarih.ValueChanged += new System.EventHandler(this.dtpTarih_ValueChanged);
            // 
            // FrmTcmbKurlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 513);
            this.Controls.Add(this.dtpTarih);
            this.Controls.Add(this.dataGridGorunumu);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "FrmTcmbKurlari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Türkiye Cumhuriyeti Merkez Bankası (TCMB) Kurları";
            this.Load += new System.EventHandler(this.FrmTcmbKurlari_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridGorunumu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem dosyaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuTcmbSayfasi;
        private System.Windows.Forms.ToolStripMenuItem menuCikis;
        private System.Windows.Forms.ToolStripMenuItem menuHakkinda;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsDurum;
        private System.Windows.Forms.DataGridView dataGridGorunumu;
        private System.Windows.Forms.DateTimePicker dtpTarih;
    }
}

