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
    public partial class Stokgüncelle : Form
    {
        public Stokgüncelle()
        {
            InitializeComponent();
        }
        private SqlConnection baglan;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Stokgüncelle_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            baglan = new SqlConnection(connectionString);
            baglan.Open();
            dataAdapter = new SqlDataAdapter("select * from giyim", baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string onayla = "update giyim set urunstok =@urunstok+urunstok where urunid=@urunid";
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            baglan = new SqlConnection(connectionString);
            baglan.Open();
            SqlCommand güncelle = new SqlCommand(onayla, baglan);
            güncelle.Parameters.AddWithValue("@urunid", Convert.ToInt32(textBox1.Text));
            güncelle.Parameters.AddWithValue("@urunstok", Convert.ToInt32(textBox2.Text));
            güncelle.ExecuteNonQuery();
            MessageBox.Show("İzin Onaylanmıştır");
            dataAdapter = new SqlDataAdapter("select * from giyim", baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            müdürsayfası müdürsayfası= new müdürsayfası();
            this.Hide();
            müdürsayfası.Show();
        }
    }
}
