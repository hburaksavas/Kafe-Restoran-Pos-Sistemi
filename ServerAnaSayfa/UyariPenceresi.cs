using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAnaSayfa
{
    public partial class UyariPenceresi : Form
    {
     
        public UyariPenceresi()
        {
            InitializeComponent();
        }
        public UyariPenceresi(string message)
        {
            InitializeComponent();
            label2.Text = message;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UyariPenceresi_Load(object sender, EventArgs e)
        {

        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }
    }
}
