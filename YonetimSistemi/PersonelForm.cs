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
    public partial class PersonelForm : Form
    {
        private int yetki;
        private string aktifTC;
        public PersonelForm(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            KullanıcıListesi KullanıcıListesi = new KullanıcıListesi(yetki, aktifTC);
            KullanıcıListesi.Show();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Islemler Ayarlar = new Islemler(yetki, aktifTC);
            Ayarlar.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Application.Exit();
        }

        private void PersonelForm_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
        }

        private void PersonelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonelListesi PersonelListesi = new PersonelListesi(yetki, aktifTC);
            PersonelListesi.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            EvrakAra EvrakAra = new EvrakAra(yetki, aktifTC);
            EvrakAra.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            TeslimEt TeslimEt = new TeslimEt(yetki, aktifTC);
            TeslimEt.Show();
        }

        private void PersonelForm_Resize(object sender, EventArgs e)
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
