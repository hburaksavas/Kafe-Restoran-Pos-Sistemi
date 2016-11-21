namespace ClientAnaSayfa
{
    partial class HesapPenceresi
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
            this.dataGridHesap = new System.Windows.Forms.DataGridView();
            this.buttonAdisyonAyir = new System.Windows.Forms.Button();
            this.buttonMasaKapat = new System.Windows.Forms.Button();
            this.buttonIptal = new System.Windows.Forms.Button();
            this.groupBoxAdisyon = new System.Windows.Forms.GroupBox();
            this.labelToplam = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxAdisyon = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHesap)).BeginInit();
            this.groupBoxAdisyon.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridHesap
            // 
            this.dataGridHesap.AllowUserToAddRows = false;
            this.dataGridHesap.AllowUserToDeleteRows = false;
            this.dataGridHesap.AllowUserToResizeColumns = false;
            this.dataGridHesap.AllowUserToResizeRows = false;
            this.dataGridHesap.BackgroundColor = System.Drawing.Color.White;
            this.dataGridHesap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHesap.Location = new System.Drawing.Point(12, 12);
            this.dataGridHesap.Name = "dataGridHesap";
            this.dataGridHesap.RowHeadersVisible = false;
            this.dataGridHesap.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridHesap.Size = new System.Drawing.Size(334, 250);
            this.dataGridHesap.TabIndex = 0;
            // 
            // buttonAdisyonAyir
            // 
            this.buttonAdisyonAyir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonAdisyonAyir.Location = new System.Drawing.Point(128, 268);
            this.buttonAdisyonAyir.Name = "buttonAdisyonAyir";
            this.buttonAdisyonAyir.Size = new System.Drawing.Size(110, 40);
            this.buttonAdisyonAyir.TabIndex = 1;
            this.buttonAdisyonAyir.Text = "Adisyon Ayır";
            this.buttonAdisyonAyir.UseVisualStyleBackColor = true;
            this.buttonAdisyonAyir.Click += new System.EventHandler(this.buttonAdisyonAyir_Click);
            // 
            // buttonMasaKapat
            // 
            this.buttonMasaKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonMasaKapat.Location = new System.Drawing.Point(12, 268);
            this.buttonMasaKapat.Name = "buttonMasaKapat";
            this.buttonMasaKapat.Size = new System.Drawing.Size(110, 40);
            this.buttonMasaKapat.TabIndex = 2;
            this.buttonMasaKapat.Text = "Masa Kapat";
            this.buttonMasaKapat.UseVisualStyleBackColor = true;
            this.buttonMasaKapat.Click += new System.EventHandler(this.buttonMasaKapat_Click);
            // 
            // buttonIptal
            // 
            this.buttonIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonIptal.Location = new System.Drawing.Point(244, 268);
            this.buttonIptal.Name = "buttonIptal";
            this.buttonIptal.Size = new System.Drawing.Size(102, 40);
            this.buttonIptal.TabIndex = 3;
            this.buttonIptal.Text = "İptal";
            this.buttonIptal.UseVisualStyleBackColor = true;
            this.buttonIptal.Click += new System.EventHandler(this.buttonIptal_Click);
            // 
            // groupBoxAdisyon
            // 
            this.groupBoxAdisyon.Controls.Add(this.labelToplam);
            this.groupBoxAdisyon.Controls.Add(this.label2);
            this.groupBoxAdisyon.Controls.Add(this.label1);
            this.groupBoxAdisyon.Controls.Add(this.listBoxAdisyon);
            this.groupBoxAdisyon.Location = new System.Drawing.Point(384, 12);
            this.groupBoxAdisyon.Name = "groupBoxAdisyon";
            this.groupBoxAdisyon.Size = new System.Drawing.Size(200, 250);
            this.groupBoxAdisyon.TabIndex = 4;
            this.groupBoxAdisyon.TabStop = false;
            this.groupBoxAdisyon.Text = "Son İşlem";
            // 
            // labelToplam
            // 
            this.labelToplam.AutoSize = true;
            this.labelToplam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelToplam.Location = new System.Drawing.Point(149, 219);
            this.labelToplam.Name = "labelToplam";
            this.labelToplam.Size = new System.Drawing.Size(31, 15);
            this.labelToplam.TabIndex = 3;
            this.labelToplam.Text = "0,00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(67, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Toplam :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adisyon";
            // 
            // listBoxAdisyon
            // 
            this.listBoxAdisyon.FormattingEnabled = true;
            this.listBoxAdisyon.Location = new System.Drawing.Point(25, 43);
            this.listBoxAdisyon.Name = "listBoxAdisyon";
            this.listBoxAdisyon.Size = new System.Drawing.Size(155, 173);
            this.listBoxAdisyon.TabIndex = 0;
            // 
            // HesapPenceresi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 319);
            this.Controls.Add(this.groupBoxAdisyon);
            this.Controls.Add(this.buttonIptal);
            this.Controls.Add(this.buttonMasaKapat);
            this.Controls.Add(this.buttonAdisyonAyir);
            this.Controls.Add(this.dataGridHesap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HesapPenceresi";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hesap Penceresi";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHesap)).EndInit();
            this.groupBoxAdisyon.ResumeLayout(false);
            this.groupBoxAdisyon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridHesap;
        private System.Windows.Forms.Button buttonAdisyonAyir;
        private System.Windows.Forms.Button buttonMasaKapat;
        private System.Windows.Forms.Button buttonIptal;
        private System.Windows.Forms.GroupBox groupBoxAdisyon;
        private System.Windows.Forms.Label labelToplam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxAdisyon;
    }
}