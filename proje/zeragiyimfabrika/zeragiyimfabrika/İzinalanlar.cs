using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class İzinalanlar : Form
    {
        public İzinalanlar()
        {
            InitializeComponent();



        }

        private SqlConnection baglan;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void İzinalanlar_Load(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True";
            baglan = new SqlConnection(connectionString);
            baglan .Open();
            dataAdapter = new SqlDataAdapter("select * from izintalep where durum=1",baglan);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sekme kapatılıyor.");
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ceoanasayfa ceoanasayfa = new ceoanasayfa();
            this.Hide();
            ceoanasayfa.Show();
        }
    }
}
