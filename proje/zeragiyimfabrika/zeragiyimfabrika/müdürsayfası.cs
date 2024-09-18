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
    public partial class müdürsayfası : Form
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string yetki { get; set; }
        public müdürsayfası()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void müdürsayfası_Load(object sender, EventArgs e)
        {
            label1.Text = "Hosgeldiniz " + ad + " " + soyad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            izinonay izinonay = new izinonay();
            this.Hide();
            izinonay.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stokontrolsayfası stokontrolsayfası= new stokontrolsayfası();
            stokontrolsayfası.yetki = yetki;
            this.Hide();
            stokontrolsayfası.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stokgüncelle stokgüncelle= new Stokgüncelle();  
            this.Hide();
            stokgüncelle.Show();
        }
    }
}
