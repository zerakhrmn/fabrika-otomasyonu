using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace zeragiyimfabrika
{
    public partial class personelsayfası : Form
    {
        public personelsayfası()
        {
            InitializeComponent();
        }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string eposta { get; set; }
        public int calisanid { get; set; }
        public string yetki { get; set; }
        public string departman { get; set; }

        public int izinhakkı {  get; set; }

        SqlCommand komut;
        SqlConnection baglan;
        SqlDataReader okuyucu;

        string baglanti = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
   






        private void personelsayfası_Load(object sender, EventArgs e)
        {
            label3.Text = "Hosgeldiniz " + ad + " " + soyad;
            label5.Text = "İzin hakkı" + izinhakkı;
           

        }

      
       

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            DateTime baslangic = dateTimePicker1.Value.Date;
            DateTime bitis=dateTimePicker2.Value.Date;
            while (baslangic <= bitis)
            {
                sayac++;
                baslangic=baslangic.AddDays(1);

            }
            if (sayac > izinhakkı)
            {
                MessageBox.Show("İzin Hakkınızdan Fazla İzin Talep Ettiniz.");
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker2.Value = DateTime.Today;
            }
            else
            {



                baglan = new SqlConnection(baglanti);
                komut = new SqlCommand();
                baglan.Open();
                komut.Connection = baglan;
                komut.CommandText = "insert into izintalep (calisanid,adi,soyadi,eposta,departman,yetki,baslangictarih,bitistarih,durum,izinsayisi,İzinNedeni)values (@calisanid,@adi,@soyadi,@eposta,@departman,@yetki,@baslangictarih,@bitistarih,@durum,@izinhak,@Sebep)";
                komut.Parameters.AddWithValue("@adi", ad);
                komut.Parameters.AddWithValue("@soyadi", soyad);
                komut.Parameters.AddWithValue("@calisanid", calisanid);
                komut.Parameters.AddWithValue("@eposta", eposta);
                komut.Parameters.AddWithValue("@departman", departman);
                komut.Parameters.AddWithValue("@yetki", yetki);
                komut.Parameters.AddWithValue("@baslangictarih", dateTimePicker1.Value);
                komut.Parameters.AddWithValue("@bitistarih", dateTimePicker2.Value);
                komut.Parameters.AddWithValue("@durum", 0);
                komut.Parameters.AddWithValue("@izinhak", sayac);
                komut.Parameters.AddWithValue("@Sebep", richTextBox1.Text);
                komut.ExecuteNonQuery();
                MessageBox.Show("İzin Talebiniz Alınmıştır.");
                baglan.Close();
            }

        }
    }

}
