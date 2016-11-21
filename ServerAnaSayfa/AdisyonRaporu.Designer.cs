namespace ServerAnaSayfa
{
    partial class AdisyonRaporu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.button_gelirToplamlari = new System.Windows.Forms.Button();
            this.button_adisyonToplamlari = new System.Windows.Forms.Button();
            this.button_calisanIstatistikleri = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_periyot = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_tarih = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_gelir = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_adisyonSayisi = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_ortalamaAdisyonGeliri = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label_calisanSayisi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            legend2.IsTextAutoFit = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(358, 24);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(724, 573);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "Kafe günlük satış, adisyon sayısı, masa sayısı, müşteri sayısına bağlı olarak; gü" +
    "nlük, aylık , yıllık olmaz üzere farklı periyotlarda ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(112, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kafe Rapor Sistemi";
            // 
            // button_gelirToplamlari
            // 
            this.button_gelirToplamlari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_gelirToplamlari.Location = new System.Drawing.Point(28, 28);
            this.button_gelirToplamlari.Name = "button_gelirToplamlari";
            this.button_gelirToplamlari.Size = new System.Drawing.Size(142, 35);
            this.button_gelirToplamlari.TabIndex = 2;
            this.button_gelirToplamlari.Text = "Gelir Toplamları";
            this.button_gelirToplamlari.UseVisualStyleBackColor = true;
            this.button_gelirToplamlari.Click += new System.EventHandler(this.button_gelirToplamlari_Click);
            // 
            // button_adisyonToplamlari
            // 
            this.button_adisyonToplamlari.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_adisyonToplamlari.Location = new System.Drawing.Point(28, 69);
            this.button_adisyonToplamlari.Name = "button_adisyonToplamlari";
            this.button_adisyonToplamlari.Size = new System.Drawing.Size(142, 35);
            this.button_adisyonToplamlari.TabIndex = 3;
            this.button_adisyonToplamlari.Text = "Adisyon Toplamları";
            this.button_adisyonToplamlari.UseVisualStyleBackColor = true;
            this.button_adisyonToplamlari.Click += new System.EventHandler(this.button_adisyonToplamlari_Click);
            // 
            // button_calisanIstatistikleri
            // 
            this.button_calisanIstatistikleri.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button_calisanIstatistikleri.Location = new System.Drawing.Point(28, 110);
            this.button_calisanIstatistikleri.Name = "button_calisanIstatistikleri";
            this.button_calisanIstatistikleri.Size = new System.Drawing.Size(142, 35);
            this.button_calisanIstatistikleri.TabIndex = 4;
            this.button_calisanIstatistikleri.Text = "Çalışan İstatistikleri";
            this.button_calisanIstatistikleri.UseVisualStyleBackColor = true;
            this.button_calisanIstatistikleri.Click += new System.EventHandler(this.button_calisanIstatistikleri_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_gelirToplamlari);
            this.groupBox1.Controls.Add(this.button_adisyonToplamlari);
            this.groupBox1.Controls.Add(this.button_calisanIstatistikleri);
            this.groupBox1.Location = new System.Drawing.Point(88, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(202, 170);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rapor";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_periyot);
            this.groupBox2.Location = new System.Drawing.Point(88, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 84);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detaylı Bilgi";
            // 
            // comboBox_periyot
            // 
            this.comboBox_periyot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBox_periyot.FormattingEnabled = true;
            this.comboBox_periyot.Items.AddRange(new object[] {
            "Periyot Seçiniz",
            "Günlük",
            "Haftalık",
            "Aylık"});
            this.comboBox_periyot.Location = new System.Drawing.Point(28, 43);
            this.comboBox_periyot.Name = "comboBox_periyot";
            this.comboBox_periyot.Size = new System.Drawing.Size(142, 24);
            this.comboBox_periyot.TabIndex = 0;
            this.comboBox_periyot.SelectedIndexChanged += new System.EventHandler(this.combobox_periyot_selectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(97, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tarih:";
            // 
            // label_tarih
            // 
            this.label_tarih.AutoSize = true;
            this.label_tarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_tarih.Location = new System.Drawing.Point(260, 380);
            this.label_tarih.Name = "label_tarih";
            this.label_tarih.Size = new System.Drawing.Size(20, 16);
            this.label_tarih.TabIndex = 9;
            this.label_tarih.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(97, 396);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label3.Size = new System.Drawing.Size(39, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Gelir:";
            // 
            // label_gelir
            // 
            this.label_gelir.AutoSize = true;
            this.label_gelir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_gelir.Location = new System.Drawing.Point(260, 396);
            this.label_gelir.Name = "label_gelir";
            this.label_gelir.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_gelir.Size = new System.Drawing.Size(20, 26);
            this.label_gelir.TabIndex = 11;
            this.label_gelir.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(97, 422);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label4.Size = new System.Drawing.Size(100, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "Adisyon Sayısı:";
            // 
            // label_adisyonSayisi
            // 
            this.label_adisyonSayisi.AutoSize = true;
            this.label_adisyonSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_adisyonSayisi.Location = new System.Drawing.Point(260, 422);
            this.label_adisyonSayisi.Name = "label_adisyonSayisi";
            this.label_adisyonSayisi.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_adisyonSayisi.Size = new System.Drawing.Size(20, 26);
            this.label_adisyonSayisi.TabIndex = 13;
            this.label_adisyonSayisi.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(97, 448);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label5.Size = new System.Drawing.Size(152, 26);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ortalama Adisyon Geliri:";
            // 
            // label_ortalamaAdisyonGeliri
            // 
            this.label_ortalamaAdisyonGeliri.AutoSize = true;
            this.label_ortalamaAdisyonGeliri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_ortalamaAdisyonGeliri.Location = new System.Drawing.Point(260, 448);
            this.label_ortalamaAdisyonGeliri.Name = "label_ortalamaAdisyonGeliri";
            this.label_ortalamaAdisyonGeliri.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_ortalamaAdisyonGeliri.Size = new System.Drawing.Size(20, 26);
            this.label_ortalamaAdisyonGeliri.TabIndex = 15;
            this.label_ortalamaAdisyonGeliri.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(97, 474);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label6.Size = new System.Drawing.Size(96, 26);
            this.label6.TabIndex = 16;
            this.label6.Text = "Çalışan Sayısı:";
            // 
            // label_calisanSayisi
            // 
            this.label_calisanSayisi.AutoSize = true;
            this.label_calisanSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_calisanSayisi.Location = new System.Drawing.Point(260, 474);
            this.label_calisanSayisi.Name = "label_calisanSayisi";
            this.label_calisanSayisi.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.label_calisanSayisi.Size = new System.Drawing.Size(20, 26);
            this.label_calisanSayisi.TabIndex = 17;
            this.label_calisanSayisi.Text = "---";
            // 
            // AdisyonRaporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 600);
            this.Controls.Add(this.label_calisanSayisi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label_ortalamaAdisyonGeliri);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_adisyonSayisi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_gelir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_tarih);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdisyonRaporu";
            this.Text = "AdisyonRaporu";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_gelirToplamlari;
        private System.Windows.Forms.Button button_adisyonToplamlari;
        private System.Windows.Forms.Button button_calisanIstatistikleri;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_periyot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_tarih;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_gelir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_adisyonSayisi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label_ortalamaAdisyonGeliri;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label_calisanSayisi;
    }
}