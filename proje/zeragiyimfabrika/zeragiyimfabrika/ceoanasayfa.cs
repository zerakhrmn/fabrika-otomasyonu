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
    public partial class ceoanasayfa : Form
    {
        public ceoanasayfa()
        {
            InitializeComponent();
        }
        public string ad {  get; set; }
        public string soyad { get; set; }
        public string yetki { get; set; }

        private void ceoanasayfa_Load(object sender, EventArgs e)
        {
            label1.Text = "Hosgeldiniz " + ad + " " + soyad;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stok kontrol sayfasına yönlendiriliyorsunuz.");
             stokontrolsayfası stokontrolsayfasi = new stokontrolsayfası();
            stokontrolsayfasi.yetki = yetki;
            this.Hide();
            stokontrolsayfasi.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            İzinalanlar izinalanlar = new İzinalanlar();
            this.Hide();
           
            izinalanlar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }
    }
}
