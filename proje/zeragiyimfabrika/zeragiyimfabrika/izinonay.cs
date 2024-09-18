using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zeragiyimfabrika
{
    public partial class izinonay : Form
    {
        public izinonay()
        {
            InitializeComponent();
        }
        private SqlConnection baglan;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        SqlDataReader reader;
        int calisanid;
        private void button2_Click(object sender, EventArgs e)
        {
            string reddet = "delete izintalep where izinid=@izinid";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            baglan = new SqlConnection(connectionString);
            baglan.Open();
            SqlCommand güncelle = new SqlCommand(reddet, baglan);
            güncelle.Parameters.AddWithValue("@izinid", Convert.ToInt32(textBox1.Text));
            güncelle.ExecuteNonQuery();
            MessageBox.Show("İzin Reddedilmiştir");
            dataAdapter = new SqlDataAdapter("select * from izintalep where durum=0", baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglan.Close();
        }

        private void izinonay_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            baglan = new SqlConnection(connectionString);
            baglan.Open();
            dataAdapter = new SqlDataAdapter("select * from izintalep where durum=0", baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            textBox1.Enabled = false;
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string izinhakkı = "update calisan set izinhak=izinhak-@izinsayisi where calisanid=@calisanid";

            string onayla = "update izintalep set durum = 1 where izinid=@izinid";
            string izinsayisi = "select izinsayisi from izintalep where calisanid=@calisanid and durum = 0";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            if (textBox1.Text==null) MessageBox.Show("Lütfen değer giriniz");
            else { 
            baglan = new SqlConnection(connectionString);
            baglan.Open();
           
            SqlCommand güncelle = new SqlCommand(onayla,baglan);
            SqlCommand getir = new SqlCommand(izinsayisi,baglan);

            getir.Parameters.AddWithValue("@calisanid",calisanid);
            reader=getir.ExecuteReader();
            reader.Read();
            int izinhak = Convert.ToInt32(reader[0]);
            reader.Close();
            SqlCommand izingüncelle = new SqlCommand(izinhakkı, baglan);
            izingüncelle.Parameters.AddWithValue("@izinid", Convert.ToInt32(textBox1.Text));
            izingüncelle.Parameters.AddWithValue("@izinsayisi", izinhak);
                izingüncelle.Parameters.AddWithValue("@calisanid", calisanid);
            
            güncelle.Parameters.AddWithValue("@izinid",Convert.ToInt32(textBox1.Text));
            güncelle.ExecuteNonQuery();
            izingüncelle.ExecuteNonQuery();
            MessageBox.Show("İzin Onaylanmıştır");
                textBox1.Clear();
            dataAdapter = new SqlDataAdapter("select * from izintalep where durum=0", baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglan.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            calisanid = Convert.ToInt16( dataGridView1.CurrentRow.Cells[1].Value);
            MessageBox.Show(calisanid.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             müdürsayfası müdürsayfası= new müdürsayfası();
            this.Hide();
            müdürsayfası.Show();
        }
    }
}
