namespace ServerAnaSayfa
{
    partial class Form_Restorant_Durum
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
            this.panel_Tables = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox_acikMasalar = new System.Windows.Forms.CheckBox();
            this.checkBox_kapaliMasalar = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_hesap = new System.Windows.Forms.Label();
            this.label_masakapasite = new System.Windows.Forms.Label();
            this.label_masagarson = new System.Windows.Forms.Label();
            this.label_masatarih = new System.Windows.Forms.Label();
            this.label_masadurumu = new System.Windows.Forms.Label();
            this.label_masano = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_masaAra = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_acikMasaSayisi = new System.Windows.Forms.Label();
            this.textBox_kapaliMasaSayisi = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Tables
            // 
            this.panel_Tables.AutoScroll = true;
            this.panel_Tables.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Tables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Tables.Location = new System.Drawing.Point(388, 55);
            this.panel_Tables.Name = "panel_Tables";
            this.panel_Tables.Size = new System.Drawing.Size(684, 493);
            this.panel_Tables.TabIndex = 0;
            // 
            // checkBox_acikMasalar
            // 
            this.checkBox_acikMasalar.AutoSize = true;
            this.checkBox_acikMasalar.Location = new System.Drawing.Point(94, 19);
            this.checkBox_acikMasalar.Name = "checkBox_acikMasalar";
            this.checkBox_acikMasalar.Size = new System.Drawing.Size(87, 17);
            this.checkBox_acikMasalar.TabIndex = 1;
            this.checkBox_acikMasalar.Text = "Açık Masalar";
            this.checkBox_acikMasalar.UseVisualStyleBackColor = true;
            this.checkBox_acikMasalar.CheckedChanged += new System.EventHandler(this.checkBox_acikMasalar_CheckedChanged);
            // 
            // checkBox_kapaliMasalar
            // 
            this.checkBox_kapaliMasalar.AutoSize = true;
            this.checkBox_kapaliMasalar.Location = new System.Drawing.Point(187, 19);
            this.checkBox_kapaliMasalar.Name = "checkBox_kapaliMasalar";
            this.checkBox_kapaliMasalar.Size = new System.Drawing.Size(95, 17);
            this.checkBox_kapaliMasalar.TabIndex = 1;
            this.checkBox_kapaliMasalar.Text = "Kapalı Masalar";
            this.checkBox_kapaliMasalar.UseVisualStyleBackColor = true;
            this.checkBox_kapaliMasalar.CheckedChanged += new System.EventHandler(this.checkBox_kapaliMasalar_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.checkBox_kapaliMasalar);
            this.groupBox1.Controls.Add(this.checkBox_acikMasalar);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(388, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(322, 46);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Masa Göster";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 461);
            this.panel1.TabIndex = 4;
            // 
            // listView1
            // 
            this.listView1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.listView1.AutoArrange = false;
            this.listView1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView1.HoverSelection = true;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(19, 277);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(325, 172);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(19, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Masada Bulunan Siparişler";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label_hesap);
            this.panel2.Controls.Add(this.label_masakapasite);
            this.panel2.Controls.Add(this.label_masagarson);
            this.panel2.Controls.Add(this.label_masatarih);
            this.panel2.Controls.Add(this.label_masadurumu);
            this.panel2.Controls.Add(this.label_masano);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(19, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(324, 215);
            this.panel2.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label15.Location = new System.Drawing.Point(3, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(295, 1);
            this.label15.TabIndex = 8;
            this.label15.Text = "label15";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label14.Location = new System.Drawing.Point(3, 117);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(295, 1);
            this.label14.TabIndex = 7;
            this.label14.Text = "label14";
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.label13.Location = new System.Drawing.Point(3, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(288, 1);
            this.label13.TabIndex = 6;
            this.label13.Text = "label13";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label12.Location = new System.Drawing.Point(3, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(295, 1);
            this.label12.TabIndex = 5;
            this.label12.Text = "label12";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label11.Location = new System.Drawing.Point(3, 65);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(295, 1);
            this.label11.TabIndex = 4;
            this.label11.Text = "label11";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(3, 38);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(295, 1);
            this.label10.TabIndex = 3;
            this.label10.Text = "label10";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(156, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(1, 150);
            this.label9.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label8.Location = new System.Drawing.Point(3, 147);
            this.label8.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Hesap:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label7.Location = new System.Drawing.Point(3, 125);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Kapasite:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label6.Location = new System.Drawing.Point(3, 97);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Masayı Açan Garson :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label5.Location = new System.Drawing.Point(3, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Açılış Tarihi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Masa Durumu:";
            // 
            // label_hesap
            // 
            this.label_hesap.AutoSize = true;
            this.label_hesap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_hesap.Location = new System.Drawing.Point(163, 147);
            this.label_hesap.Name = "label_hesap";
            this.label_hesap.Size = new System.Drawing.Size(0, 17);
            this.label_hesap.TabIndex = 0;
            // 
            // label_masakapasite
            // 
            this.label_masakapasite.AutoSize = true;
            this.label_masakapasite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_masakapasite.Location = new System.Drawing.Point(163, 125);
            this.label_masakapasite.Name = "label_masakapasite";
            this.label_masakapasite.Size = new System.Drawing.Size(0, 17);
            this.label_masakapasite.TabIndex = 0;
            // 
            // label_masagarson
            // 
            this.label_masagarson.AutoSize = true;
            this.label_masagarson.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_masagarson.Location = new System.Drawing.Point(163, 97);
            this.label_masagarson.Name = "label_masagarson";
            this.label_masagarson.Size = new System.Drawing.Size(0, 17);
            this.label_masagarson.TabIndex = 0;
            // 
            // label_masatarih
            // 
            this.label_masatarih.AutoSize = true;
            this.label_masatarih.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_masatarih.Location = new System.Drawing.Point(163, 72);
            this.label_masatarih.Name = "label_masatarih";
            this.label_masatarih.Size = new System.Drawing.Size(0, 17);
            this.label_masatarih.TabIndex = 0;
            // 
            // label_masadurumu
            // 
            this.label_masadurumu.AutoSize = true;
            this.label_masadurumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_masadurumu.Location = new System.Drawing.Point(163, 46);
            this.label_masadurumu.Name = "label_masadurumu";
            this.label_masadurumu.Size = new System.Drawing.Size(0, 17);
            this.label_masadurumu.TabIndex = 0;
            // 
            // label_masano
            // 
            this.label_masano.AutoSize = true;
            this.label_masano.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label_masano.Location = new System.Drawing.Point(163, 21);
            this.label_masano.Name = "label_masano";
            this.label_masano.Size = new System.Drawing.Size(0, 17);
            this.label_masano.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Masa No:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(18, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Masa Bilgileri";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox_masaAra);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(716, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 45);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Masa Ara";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 9.25F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.button1.Location = new System.Drawing.Point(287, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "ARA";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox_masaAra
            // 
            this.textBox_masaAra.BackColor = System.Drawing.SystemColors.HotTrack;
            this.textBox_masaAra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_masaAra.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox_masaAra.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_masaAra.Location = new System.Drawing.Point(57, 17);
            this.textBox_masaAra.Name = "textBox_masaAra";
            this.textBox_masaAra.Size = new System.Drawing.Size(224, 22);
            this.textBox_masaAra.TabIndex = 1;
            this.textBox_masaAra.Text = "Masa No Veya Id Giriniz";
            this.textBox_masaAra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_masaAra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_masaAra_MouseClick);
            this.textBox_masaAra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_masaAra_KeyPress);
            this.textBox_masaAra.Leave += new System.EventHandler(this.textBox_masaAra_Leave);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.Controls.Add(this.textBox_acikMasaSayisi);
            this.panel3.Controls.Add(this.textBox_kapaliMasaSayisi);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Location = new System.Drawing.Point(12, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 76);
            this.panel3.TabIndex = 5;
            // 
            // textBox_acikMasaSayisi
            // 
            this.textBox_acikMasaSayisi.BackColor = System.Drawing.Color.ForestGreen;
            this.textBox_acikMasaSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.textBox_acikMasaSayisi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_acikMasaSayisi.Location = new System.Drawing.Point(16, 38);
            this.textBox_acikMasaSayisi.Margin = new System.Windows.Forms.Padding(3, 25, 3, 0);
            this.textBox_acikMasaSayisi.Name = "textBox_acikMasaSayisi";
            this.textBox_acikMasaSayisi.Size = new System.Drawing.Size(153, 30);
            this.textBox_acikMasaSayisi.TabIndex = 3;
            this.textBox_acikMasaSayisi.Text = "label17";
            this.textBox_acikMasaSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_kapaliMasaSayisi
            // 
            this.textBox_kapaliMasaSayisi.BackColor = System.Drawing.Color.Crimson;
            this.textBox_kapaliMasaSayisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.textBox_kapaliMasaSayisi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox_kapaliMasaSayisi.Location = new System.Drawing.Point(190, 38);
            this.textBox_kapaliMasaSayisi.Margin = new System.Windows.Forms.Padding(3, 25, 3, 0);
            this.textBox_kapaliMasaSayisi.Name = "textBox_kapaliMasaSayisi";
            this.textBox_kapaliMasaSayisi.Size = new System.Drawing.Size(153, 30);
            this.textBox_kapaliMasaSayisi.TabIndex = 3;
            this.textBox_kapaliMasaSayisi.Text = "label17";
            this.textBox_kapaliMasaSayisi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label18.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label18.Location = new System.Drawing.Point(190, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(153, 22);
            this.label18.TabIndex = 2;
            this.label18.Text = "Kapalı Masa Sayısı";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label16.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label16.Location = new System.Drawing.Point(16, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(153, 22);
            this.label16.TabIndex = 2;
            this.label16.Text = "Açık Masa Sayısı";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form_Restorant_Durum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1084, 560);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel_Tables);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Restorant_Durum";
            this.Text = "Form_Restorant_Durum";
            this.Load += new System.EventHandler(this.Form_Restorant_Durum_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel_Tables;
        private System.Windows.Forms.CheckBox checkBox_acikMasalar;
        private System.Windows.Forms.CheckBox checkBox_kapaliMasalar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label_hesap;
        private System.Windows.Forms.Label label_masakapasite;
        private System.Windows.Forms.Label label_masagarson;
        private System.Windows.Forms.Label label_masatarih;
        private System.Windows.Forms.Label label_masadurumu;
        private System.Windows.Forms.Label label_masano;
        private System.Windows.Forms.Label textBox_acikMasaSayisi;
        private System.Windows.Forms.Label textBox_kapaliMasaSayisi;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_masaAra;
    }
}