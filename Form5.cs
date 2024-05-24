using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sql;
using System;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {
        Label[] labels = new Label[5];
        public Form5()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            LoadRandomWords();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.LimeGreen, Color.PaleGreen,25f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            // Label dizisine Label kontrollerini ekle
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
        }
        private void LoadRandomWords()
{
    // Veritabanı bağlantı dizesi
    string connectionString = @"Data Source=DESKTOP-OG41JC3;Initial Catalog=yazilim yapimi;Integrated Security=True;Trust Server Certificate=True";

    // Tek bir SQL sorgusu
    string query = "SELECT TOP 5 kelimeIng FROM tblkelime  ORDER BY NEWID()";

    // SqlConnection oluştur
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        // SqlCommand oluştur
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            

            // Bağlantıyı aç
            connection.Open();

            // Sorguyu çalıştır ve sonucu al
            using (SqlDataReader reader = command.ExecuteReader())
            {
                // Her bir Label kontrolüne sırayla veriyi yazdır
                int i = 0;
                while (reader.Read() && i < 5)
                {
                            labels[i].Text = reader["kelimeIng"].ToString();
                    i++;
                }

                // Okuyucuyu kapat
                reader.Close();

                // Veri bulunamadıysa, uygun bir mesajı Label kontrolüne yazdır
                while (i < 5)
                {
                    labels[i].Text = "Kelime bulunamadı";
                    i++;
                }
            }
        }
    }
}
    }
}