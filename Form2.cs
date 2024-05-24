using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;



namespace WindowsFormsApp2
{
    public partial class uyeformu : Form
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.LimeGreen, Color.PaleGreen, 25f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }
        public uyeformu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }
        private void formgetir(Form frm)
        {
            frm.Show();
        }
        static string constring = @"Data Source=DESKTOP-OG41JC3;Initial Catalog=""yazilim yapimi"";Integrated Security=True;Trust Server Certificate=True";
        SqlConnection connect = new SqlConnection(constring);
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                    connect.Open();
                string kayit = $"insert into tblkullanici(kullaniciID,kullaniciSifre) values (@kullaniciID,@kullaniciSifre)";
                SqlCommand komut = new SqlCommand(kayit, connect);
                komut.Parameters.AddWithValue("@kullaniciID", textBox1.Text);
                komut.Parameters.AddWithValue("@kullaniciSifre", textBox2.Text);
                komut.ExecuteNonQuery();
                connect.Close();
                if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                    string.IsNullOrWhiteSpace(textBox2.Text) )
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun ve bir resim seçin.");
                    return;
                }
                MessageBox.Show("kayıt eklendi");
                this.Close();
                

            }
            catch (Exception hata)
            {
                MessageBox.Show("hata meydana geldi" + hata.Message);
            }

        }

        private void uyeformu_Load(object sender, EventArgs e)
        {

        }
    }
}
