using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle, Color.LimeGreen, Color.PaleGreen, 25f))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            labels[0] = label1;
            labels[1] = label2;
            labels[2] = label3;
            labels[3] = label4;
            labels[4] = label5;
        }

       

        private void LoadRandomWords()
        {
            string connectionString = @"Data Source=DESKTOP-OG41JC3;Initial Catalog=yazilim yapimi;Integrated Security=True;Trust Server Certificate=True";
            string query = "SELECT TOP 5 kelimeIng FROM tblkelime ORDER BY NEWID()";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read() && i < 5)
                        {
                            if (!reader.IsDBNull(0))
                            {
                                labels[i].Text = reader.GetString(0);
                            }
                            else
                            {
                                labels[i].Text = "Veri yok";
                            }
                            i++;
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadRandomWords();
        }
    }
}

