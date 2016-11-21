using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientAnaSayfa
{
    public partial class UyariPenceresi : Form
    {
        public bool secim;
        public UyariPenceresi(string baslik, string uyari, string buttonText1, string buttonText2)
        {
            InitializeComponent();
            Text = baslik;
            label1.Text = uyari;
            button1.Text = buttonText1;
            button2.Text = buttonText2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secim = true;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secim = false;
            Close();
        }
    }
}
