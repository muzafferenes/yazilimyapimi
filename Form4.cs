using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void formgetir(Form frm)
        {
            frm.Show();
        }
        private void klmekle_Click(object sender, EventArgs e)
        {
            Form3 klmekle = new Form3();
            formgetir(klmekle);
        }

        private void snvgiris_Click(object sender, EventArgs e)
        {
            Form5 sinav = new Form5();
            formgetir(sinav);
        }
    }
}
