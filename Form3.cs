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
        OpenFileDialog openFileDialog1 = new OpenFileDialog(); // OpenFileDialog nesnesini burada tanımla
        byte[] imageBytes; // Resim dosyasını saklamak için byte dizisi
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.LimeGreen, Color.PaleGreen, 25f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        public Form3()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            klmcml.BackColor = Color.Transparent;
            klming.BackColor = Color.Transparent;
            klmrsm.BackColor = Color.Transparent;
            klmtr.BackColor = Color.Transparent;
            label1.BackColor = Color.Transparent;
        }
        private void formgetir(Form frm)
        {
            frm.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();

                string kayit = "insert into tblkelime(kelimeIng,kelimeTr,kelimeCumle,kelimeResim) values (@kelimeIng,@kelimeTr,@kelimeCumle,@kelimeResim)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@kelimeIng", textBox1.Text);
                komut.Parameters.AddWithValue("@kelimeTr", textBox2.Text);
                komut.Parameters.AddWithValue("@kelimeCumle", textBox3.Text);
                komut.Parameters.AddWithValue("@kelimeResim", imageBytes); 
                komut.ExecuteNonQuery();
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(textBox2.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text) ||
        imageBytes == null)
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun ve bir resim seçin.");
                    return;
                }

                MessageBox.Show("Kelime eklendi");
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata meydana geldi: " + hata.Message);
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                    connect.Close();
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
        string.IsNullOrWhiteSpace(textBox2.Text) ||
        string.IsNullOrWhiteSpace(textBox3.Text) ||
        imageBytes == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurun ve bir resim seçin.");
                return; 
            }
            textBox1.Clear();   
            textBox2.Clear();       
            textBox3.Clear();
            imgPath.Clear();
            pictureBox1.Image = null; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    string fileName = openFileDialog1.FileName;
                    imgPath.Text = fileName;
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        if (myStream.Length > 5200000)
                        {
                            MessageBox.Show("Hata: Dosya boyutu büyük.");
                        }
                        else
                        {
                            pictureBox1.Load(fileName);
                            imageBytes = File.ReadAllBytes(fileName); // Resmi byte dizisine oku
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata meydana geldi.");
                }
            }
        }

        private void geri_Click(object sender, EventArgs e)
        {
            Form4 geri = new Form4();
            formgetir(geri);
        }
    }
}
