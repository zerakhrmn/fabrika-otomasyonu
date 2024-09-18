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
    public partial class üstgiyimstok : Form
    {
        public üstgiyimstok()
        {
            InitializeComponent();
        }

        private SqlConnection baglan;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;

        private void üstgiyimstok_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            baglan = new SqlConnection(connectionString);
            baglan.Open();
            dataAdapter = new SqlDataAdapter("select * from giyim where urunturu = 'üst'", baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stokontrolsayfası stokontrolsayfası = new stokontrolsayfası();
            this.Hide();
            stokontrolsayfası.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }
    }
}
