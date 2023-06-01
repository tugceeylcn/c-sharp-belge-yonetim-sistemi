using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YonetimSistemi
{
    public partial class KullanıcıForm : Form
    {
        private int yetki;
        private string aktifTC;
        public KullanıcıForm(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void KullanıcıForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            EvrakListesi EvrakListesi = new EvrakListesi(yetki, aktifTC);
            EvrakListesi.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmanetListesi EmanetListesi = new EmanetListesi(yetki, aktifTC);
            EmanetListesi.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            İstatistikler İstatistikler = new İstatistikler(yetki, aktifTC);
            İstatistikler.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void KullanıcıForm_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            EvrakAra EvrakAra = new EvrakAra(yetki, aktifTC);
            EvrakAra.Show();
        }

        private void KullanıcıForm_Resize(object sender, EventArgs e)
        {
            AdjustControls();
        }
        private void AdjustControls()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2; // Formun genişliğine göre panel2'nin yatay konumunu ayarla
            panel1.Top = 10; // Formun üstünden 10 piksel aşağıda konumlandır

        }
    }
}
