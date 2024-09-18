using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace zeragiyimfabrika
{
    public partial class şifremiunuttum : Form
    {
        public şifremiunuttum()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            girişyap girişegeridön = new girişyap();
            girişegeridön.Show();
            this.Hide();
        }

        private void şifremiunuttum_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;
            
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox3.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {

            
            string query="UPDATE calisan SET sifre = @sifre Where eposta=@eposta";
            SqlConnection connect = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=zerabutik;Integrated Security=True");
                connect.Open();
            SqlCommand cmd = new SqlCommand(query,connect);
            cmd.Parameters.AddWithValue("@sifre",textBox2.Text);
            cmd.Parameters.AddWithValue("@eposta",textBox1.Text);
            cmd.ExecuteNonQuery();
                MessageBox.Show("Şifreniz güncellenmiştir");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                connect.Close();
            }
            else if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("Lütfen aynı şifreleri giriniz");
                textBox3.Clear();
                textBox2.Clear();
            }
        }
    }
}
