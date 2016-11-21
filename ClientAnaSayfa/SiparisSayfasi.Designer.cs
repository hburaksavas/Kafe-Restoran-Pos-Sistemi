namespace ClientAnaSayfa
{
    partial class SiparisSayfasi
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGeriAl = new System.Windows.Forms.Button();
            this.buttonIptal = new System.Windows.Forms.Button();
            this.buttonSiparisEkle = new System.Windows.Forms.Button();
            this.dataGridSiparis = new System.Windows.Forms.DataGridView();
            this.flowLayoutUrun = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutKategori = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSiparis)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGeriAl);
            this.groupBox1.Controls.Add(this.buttonIptal);
            this.groupBox1.Controls.Add(this.buttonSiparisEkle);
            this.groupBox1.Controls.Add(this.dataGridSiparis);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 487);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Siparişler";
            // 
            // buttonGeriAl
            // 
            this.buttonGeriAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGeriAl.Location = new System.Drawing.Point(120, 429);
            this.buttonGeriAl.Name = "buttonGeriAl";
            this.buttonGeriAl.Size = new System.Drawing.Size(79, 33);
            this.buttonGeriAl.TabIndex = 3;
            this.buttonGeriAl.Text = "GERİ AL";
            this.buttonGeriAl.UseVisualStyleBackColor = true;
            this.buttonGeriAl.Click += new System.EventHandler(this.buttonGeriAl_Click);
            // 
            // buttonIptal
            // 
            this.buttonIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonIptal.Location = new System.Drawing.Point(17, 429);
            this.buttonIptal.Name = "buttonIptal";
            this.buttonIptal.Size = new System.Drawing.Size(96, 33);
            this.buttonIptal.TabIndex = 2;
            this.buttonIptal.Text = "İPTAL";
            this.buttonIptal.UseVisualStyleBackColor = true;
            this.buttonIptal.Click += new System.EventHandler(this.buttonIptal_Click);
            // 
            // buttonSiparisEkle
            // 
            this.buttonSiparisEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonSiparisEkle.Location = new System.Drawing.Point(205, 429);
            this.buttonSiparisEkle.Name = "buttonSiparisEkle";
            this.buttonSiparisEkle.Size = new System.Drawing.Size(110, 33);
            this.buttonSiparisEkle.TabIndex = 1;
            this.buttonSiparisEkle.Text = "SİPARİŞ EKLE";
            this.buttonSiparisEkle.UseVisualStyleBackColor = true;
            this.buttonSiparisEkle.Click += new System.EventHandler(this.buttonSiparisEkle_Click);
            // 
            // dataGridSiparis
            // 
            this.dataGridSiparis.AllowUserToAddRows = false;
            this.dataGridSiparis.AllowUserToDeleteRows = false;
            this.dataGridSiparis.AllowUserToResizeColumns = false;
            this.dataGridSiparis.AllowUserToResizeRows = false;
            this.dataGridSiparis.BackgroundColor = System.Drawing.Color.White;
            this.dataGridSiparis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSiparis.Location = new System.Drawing.Point(17, 30);
            this.dataGridSiparis.Name = "dataGridSiparis";
            this.dataGridSiparis.RowHeadersVisible = false;
            this.dataGridSiparis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridSiparis.Size = new System.Drawing.Size(298, 393);
            this.dataGridSiparis.TabIndex = 0;
            // 
            // flowLayoutUrun
            // 
            this.flowLayoutUrun.AutoScroll = true;
            this.flowLayoutUrun.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutUrun.Location = new System.Drawing.Point(339, 103);
            this.flowLayoutUrun.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.flowLayoutUrun.Name = "flowLayoutUrun";
            this.flowLayoutUrun.Size = new System.Drawing.Size(833, 396);
            this.flowLayoutUrun.TabIndex = 1;
            // 
            // flowLayoutKategori
            // 
            this.flowLayoutKategori.AutoScroll = true;
            this.flowLayoutKategori.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutKategori.Location = new System.Drawing.Point(339, 13);
            this.flowLayoutKategori.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.flowLayoutKategori.Name = "flowLayoutKategori";
            this.flowLayoutKategori.Size = new System.Drawing.Size(833, 90);
            this.flowLayoutKategori.TabIndex = 2;
            // 
            // SiparisSayfasi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 511);
            this.Controls.Add(this.flowLayoutKategori);
            this.Controls.Add(this.flowLayoutUrun);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SiparisSayfasi";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sipariş Sayfası";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSiparis)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonSiparisEkle;
        private System.Windows.Forms.DataGridView dataGridSiparis;
        private System.Windows.Forms.Button buttonIptal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutUrun;
        private System.Windows.Forms.Button buttonGeriAl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutKategori;
    }
}