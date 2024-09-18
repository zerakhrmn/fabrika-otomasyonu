using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeragiyimfabrika
{
    public partial class girişyap : Form
    {
        public girişyap()
        {
            InitializeComponent();
        }
        
        SqlCommand komut;
        SqlConnection baglan;
        SqlDataReader okuyucu;

        string baglanti = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            baglan=new SqlConnection(baglanti);
            komut = new SqlCommand();
            baglan.Open();
            komut.Connection = baglan;
            komut.CommandText = "\r\nselect adi,soyadi,departman,yetki,calisanid,eposta ,izinhak from calisan where eposta =@eposta and sifre=@sifre";
            komut.Parameters.AddWithValue("@eposta", textBox1.Text);
            komut.Parameters.AddWithValue("@sifre", textBox2.Text);
            okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                string departman = okuyucu[2].ToString();
                string adi = okuyucu[0].ToString();
                string soyadi = okuyucu[1].ToString();
                string yetki = okuyucu[3].ToString();
                int calisanid =Convert.ToInt16(okuyucu[4]) ;
                string eposta = okuyucu[5].ToString();
                int izinhakkı = Convert.ToInt16(okuyucu[6]);

                if (yetki == "ceo")
                {
                    MessageBox.Show("Ceo anasayfasına yönlendiriliyorsunuz.");
                    ceoanasayfa ceoanasayfa = new ceoanasayfa();
                    ceoanasayfa.ad = adi;
                    ceoanasayfa.soyad = soyadi;
                    ceoanasayfa.yetki = yetki;
                    ceoanasayfa.Show();
                    this.Hide();
                }
             if(yetki == "çalışan")
                {
                    MessageBox.Show("Personel anasayfasına yönlendiriliyorsunuz.");
                        personelsayfası personelsayfası = new personelsayfası();
                    personelsayfası.ad = adi;
                    personelsayfası.soyad = soyadi;
                    personelsayfası.calisanid = calisanid;
                    personelsayfası.yetki = yetki;
                    personelsayfası.departman = departman;
                    personelsayfası.eposta = eposta;
                    personelsayfası.izinhakkı = izinhakkı;
                    personelsayfası.Show();
                    this.Hide();

            } if (yetki == "müdür")
            {
                MessageBox.Show( "Müdür anasayfasına yönlendiriliyorsunuz.");
                müdürsayfası müdürsayfası = new müdürsayfası();
                    müdürsayfası.ad = adi;
                    müdürsayfası.soyad = soyadi;
                   müdürsayfası.yetki= yetki;
                    müdürsayfası.Show();
                this.Hide();
            }
                }
          
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            şifremiunuttum şifremiunuttum = new şifremiunuttum();
            şifremiunuttum.Show();
            this.Hide();
        }

       

        private void girişyap_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
