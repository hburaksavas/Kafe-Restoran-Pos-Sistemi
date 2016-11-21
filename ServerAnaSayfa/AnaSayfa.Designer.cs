namespace ServerAnaSayfa
{
    partial class AnaSayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_serverStart = new System.Windows.Forms.Button();
            this.button_serverStop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_serverDurumu = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_adisyon_raporu = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button_listeleme = new System.Windows.Forms.Button();
            this.button_kullanici_islemleri = new System.Windows.Forms.Button();
            this.button_yonetici_islemleri = new System.Windows.Forms.Button();
            this.button_kafe_durum = new System.Windows.Forms.Button();
            this.button_masa_islemleri = new System.Windows.Forms.Button();
            this.button_kategori_islemleri = new System.Windows.Forms.Button();
            this.button_urun_islemleri = new System.Windows.Forms.Button();
            this.button_anaSayfa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_serverStart
            // 
            this.button_serverStart.Location = new System.Drawing.Point(21, 19);
            this.button_serverStart.Name = "button_serverStart";
            this.button_serverStart.Size = new System.Drawing.Size(81, 23);
            this.button_serverStart.TabIndex = 0;
            this.button_serverStart.Text = "Server Başlat";
            this.button_serverStart.UseVisualStyleBackColor = true;
            this.button_serverStart.Click += new System.EventHandler(this.button_serverStart_Click);
            // 
            // button_serverStop
            // 
            this.button_serverStop.Location = new System.Drawing.Point(108, 19);
            this.button_serverStop.Name = "button_serverStop";
            this.button_serverStop.Size = new System.Drawing.Size(81, 23);
            this.button_serverStop.TabIndex = 1;
            this.button_serverStop.Text = "Server Durdur";
            this.button_serverStop.UseVisualStyleBackColor = true;
            this.button_serverStop.Click += new System.EventHandler(this.button_serverStop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(29, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server Durumu:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(232, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1110, 591);
            this.panel1.TabIndex = 3;
            // 
            // label_serverDurumu
            // 
            this.label_serverDurumu.AutoSize = true;
            this.label_serverDurumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_serverDurumu.ForeColor = System.Drawing.Color.Red;
            this.label_serverDurumu.Location = new System.Drawing.Point(128, 56);
            this.label_serverDurumu.Name = "label_serverDurumu";
            this.label_serverDurumu.Size = new System.Drawing.Size(48, 15);
            this.label_serverDurumu.TabIndex = 4;
            this.label_serverDurumu.Text = "Kapalı";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_serverStart);
            this.groupBox1.Controls.Add(this.label_serverDurumu);
            this.groupBox1.Controls.Add(this.button_serverStop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 87);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // button_adisyon_raporu
            // 
            this.button_adisyon_raporu.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_adisyon_raporu.ForeColor = System.Drawing.Color.Black;
            this.button_adisyon_raporu.Location = new System.Drawing.Point(20, 375);
            this.button_adisyon_raporu.Name = "button_adisyon_raporu";
            this.button_adisyon_raporu.Size = new System.Drawing.Size(169, 33);
            this.button_adisyon_raporu.TabIndex = 6;
            this.button_adisyon_raporu.Text = "Rapor Sayfası";
            this.button_adisyon_raporu.UseVisualStyleBackColor = true;
            this.button_adisyon_raporu.Click += new System.EventHandler(this.button_adisyon_raporu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.button_listeleme);
            this.groupBox2.Controls.Add(this.button_kullanici_islemleri);
            this.groupBox2.Controls.Add(this.button_yonetici_islemleri);
            this.groupBox2.Controls.Add(this.button_kafe_durum);
            this.groupBox2.Controls.Add(this.button_masa_islemleri);
            this.groupBox2.Controls.Add(this.button_kategori_islemleri);
            this.groupBox2.Controls.Add(this.button_urun_islemleri);
            this.groupBox2.Controls.Add(this.button_anaSayfa);
            this.groupBox2.Controls.Add(this.button_adisyon_raporu);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.groupBox2.Location = new System.Drawing.Point(13, 105);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 481);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yönetici Menü";
            // 
            // button_listeleme
            // 
            this.button_listeleme.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_listeleme.ForeColor = System.Drawing.Color.Black;
            this.button_listeleme.Location = new System.Drawing.Point(20, 336);
            this.button_listeleme.Name = "button_listeleme";
            this.button_listeleme.Size = new System.Drawing.Size(169, 33);
            this.button_listeleme.TabIndex = 14;
            this.button_listeleme.Text = "Listeleme İşlemleri";
            this.button_listeleme.UseVisualStyleBackColor = true;
            this.button_listeleme.Click += new System.EventHandler(this.button_listeleme_Click);
            // 
            // button_kullanici_islemleri
            // 
            this.button_kullanici_islemleri.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kullanici_islemleri.ForeColor = System.Drawing.Color.Black;
            this.button_kullanici_islemleri.Location = new System.Drawing.Point(20, 258);
            this.button_kullanici_islemleri.Name = "button_kullanici_islemleri";
            this.button_kullanici_islemleri.Size = new System.Drawing.Size(169, 33);
            this.button_kullanici_islemleri.TabIndex = 13;
            this.button_kullanici_islemleri.Text = "Kullanici İşlemleri";
            this.button_kullanici_islemleri.UseVisualStyleBackColor = true;
            this.button_kullanici_islemleri.Click += new System.EventHandler(this.button_kullanici_islemleri_Click);
            // 
            // button_yonetici_islemleri
            // 
            this.button_yonetici_islemleri.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_yonetici_islemleri.ForeColor = System.Drawing.Color.Black;
            this.button_yonetici_islemleri.Location = new System.Drawing.Point(20, 297);
            this.button_yonetici_islemleri.Name = "button_yonetici_islemleri";
            this.button_yonetici_islemleri.Size = new System.Drawing.Size(169, 33);
            this.button_yonetici_islemleri.TabIndex = 12;
            this.button_yonetici_islemleri.Text = "Yönetici İşlemleri";
            this.button_yonetici_islemleri.UseVisualStyleBackColor = true;
            this.button_yonetici_islemleri.Click += new System.EventHandler(this.button_yonetici_islemleri_Click);
            // 
            // button_kafe_durum
            // 
            this.button_kafe_durum.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kafe_durum.ForeColor = System.Drawing.Color.Black;
            this.button_kafe_durum.Location = new System.Drawing.Point(21, 102);
            this.button_kafe_durum.Name = "button_kafe_durum";
            this.button_kafe_durum.Size = new System.Drawing.Size(168, 33);
            this.button_kafe_durum.TabIndex = 11;
            this.button_kafe_durum.Text = "Kafe Durum";
            this.button_kafe_durum.UseVisualStyleBackColor = true;
            this.button_kafe_durum.Click += new System.EventHandler(this.button_kafe_durum_Click);
            // 
            // button_masa_islemleri
            // 
            this.button_masa_islemleri.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_masa_islemleri.ForeColor = System.Drawing.Color.Black;
            this.button_masa_islemleri.Location = new System.Drawing.Point(20, 219);
            this.button_masa_islemleri.Name = "button_masa_islemleri";
            this.button_masa_islemleri.Size = new System.Drawing.Size(169, 33);
            this.button_masa_islemleri.TabIndex = 10;
            this.button_masa_islemleri.Text = "Masa İşlemleri";
            this.button_masa_islemleri.UseVisualStyleBackColor = true;
            this.button_masa_islemleri.Click += new System.EventHandler(this.button_masa_islemleri_Click);
            // 
            // button_kategori_islemleri
            // 
            this.button_kategori_islemleri.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_kategori_islemleri.ForeColor = System.Drawing.Color.Black;
            this.button_kategori_islemleri.Location = new System.Drawing.Point(20, 141);
            this.button_kategori_islemleri.Name = "button_kategori_islemleri";
            this.button_kategori_islemleri.Size = new System.Drawing.Size(169, 33);
            this.button_kategori_islemleri.TabIndex = 9;
            this.button_kategori_islemleri.Text = "Kategori İşlemleri";
            this.button_kategori_islemleri.UseVisualStyleBackColor = true;
            this.button_kategori_islemleri.Click += new System.EventHandler(this.button_kategori_islemleri_Click);
            // 
            // button_urun_islemleri
            // 
            this.button_urun_islemleri.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_urun_islemleri.ForeColor = System.Drawing.Color.Black;
            this.button_urun_islemleri.Location = new System.Drawing.Point(20, 180);
            this.button_urun_islemleri.Name = "button_urun_islemleri";
            this.button_urun_islemleri.Size = new System.Drawing.Size(169, 33);
            this.button_urun_islemleri.TabIndex = 8;
            this.button_urun_islemleri.Text = "Ürün İşlemleri";
            this.button_urun_islemleri.UseVisualStyleBackColor = true;
            this.button_urun_islemleri.Click += new System.EventHandler(this.button_urun_islemleri_Click);
            // 
            // button_anaSayfa
            // 
            this.button_anaSayfa.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_anaSayfa.ForeColor = System.Drawing.Color.Black;
            this.button_anaSayfa.Location = new System.Drawing.Point(21, 63);
            this.button_anaSayfa.Name = "button_anaSayfa";
            this.button_anaSayfa.Size = new System.Drawing.Size(168, 33);
            this.button_anaSayfa.TabIndex = 7;
            this.button_anaSayfa.Text = "Ana Sayfa";
            this.button_anaSayfa.UseVisualStyleBackColor = true;
            this.button_anaSayfa.Click += new System.EventHandler(this.button_anaSayfa_Click);
            // 
            // AnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 733);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "AnaSayfa";
            this.Text = "Ana Sayfa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_serverStart;
        private System.Windows.Forms.Button button_serverStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_serverDurumu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_adisyon_raporu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button_anaSayfa;
        private System.Windows.Forms.Button button_listeleme;
        private System.Windows.Forms.Button button_kullanici_islemleri;
        private System.Windows.Forms.Button button_yonetici_islemleri;
        private System.Windows.Forms.Button button_kafe_durum;
        private System.Windows.Forms.Button button_masa_islemleri;
        private System.Windows.Forms.Button button_kategori_islemleri;
        private System.Windows.Forms.Button button_urun_islemleri;
    }
}