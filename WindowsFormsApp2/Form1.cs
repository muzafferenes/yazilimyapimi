using System;
using System.Data;
using System.Windows.Forms;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using System.Drawing;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void formgetir(Form frm)
        {
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            con = new SqlConnection(@"Data Source=DESKTOP-OG41JC3;Initial Catalog=""yazilim yapimi"";Integrated Security=True;Trust Server Certificate=True");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM tblkullanici WHERE kullaniciID = '" + textBox1.Text + "' AND kullaniciSifre = '" + textBox2.Text + "'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Form3 kelime = new Form3();
                formgetir(kelime);
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyeformu uye = new uyeformu();
            formgetir(uye);
        }

        private void button2_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
    }
}
