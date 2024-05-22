using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        static string constring = @"Data Source=DESKTOP-OG41JC3;Initial Catalog=yazilim yapimi;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection connect = new SqlConnection(constring);
        OpenFileDialog openFileDialog = new OpenFileDialog(); // OpenFileDialog nesnesini tanımla

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string kayit = $"insert into tblkelime(kelimeIng,kelimeTr,kelimeCumle) values (@kelimeIng,@kelimeTr,@kelimeCumle)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@kelimeIng", textBox1.Text);
                komut.Parameters.AddWithValue("@kelimeTr", textBox2.Text);
                komut.Parameters.AddWithValue("@kelimeCumle", textBox3.Text);
                komut.ExecuteNonQuery();

                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    pictureBox1.Image = Image.FromFile(filePath);

                    byte[] imageBytes = File.ReadAllBytes(filePath);

                    string username = "exampleUser"; // Bu değeri giriş yapılan kullanıcıdan alabilirsiniz.
                    SavePhotoToDatabase(username, imageBytes);
                }

                connect.Close();
                MessageBox.Show("Kelime eklendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata meydana geldi: " + hata.Message);
            }
        }

        private void SavePhotoToDatabase(string kullaniciID, byte[] imageBytes)
        {
            using (SqlConnection connection = new SqlConnection(constring))
            {
                connection.Open();

                string updateQuery = "UPDATE tblkelime SET kelimeResim = @kelimeResim WHERE kullaniciID = @kullaniciID";
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciID", kullaniciID);
                    command.Parameters.AddWithValue("@kelimeResim", imageBytes);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
