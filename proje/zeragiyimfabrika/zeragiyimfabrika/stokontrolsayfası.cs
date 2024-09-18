using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeragiyimfabrika
{
    public partial class stokontrolsayfası : Form
    {
        public stokontrolsayfası()
        {
            InitializeComponent();
        }
        public string yetki {  get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            dışgiyimstok dışgiyimstok=new dışgiyimstok();
            this.Hide();
            dışgiyimstok.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            üstgiyimstok üstgiyimstok = new üstgiyimstok();
            this.Hide();
            üstgiyimstok.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            altgiyimstok altgiyimstok = new altgiyimstok();
            this.Hide();
            altgiyimstok.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(yetki=="ceo")
            {
                ceoanasayfa ceoanasayfa = new ceoanasayfa();
                ceoanasayfa.Show();
                this.Hide();
            }
            else if (yetki == "müdür")
            {
                müdürsayfası müdürsayfası = new müdürsayfası();
                müdürsayfası.Show();
                this.Hide();
            }
        }
    }
}
