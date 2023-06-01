using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
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
    public partial class İstatistikler : Form
    {
        private int yetki;
        private string aktifTC;
        public İstatistikler(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void İstatistikler_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            string countQuery = "SELECT COUNT(*) FROM kullanici WHERE kullaniciYetki != 'Sekreter'";
            MySqlCommand command = new MySqlCommand(countQuery, connection);
            int rowCount = Convert.ToInt32(command.ExecuteScalar());
            label6.Text = rowCount.ToString();

            string countQuery1 = "SELECT COUNT(*) FROM emanet ";
            MySqlCommand command1 = new MySqlCommand(countQuery1, connection);
            int rowCount1 = Convert.ToInt32(command1.ExecuteScalar());
            label5.Text = rowCount1.ToString();

            string countQuery2 = "SELECT COUNT(*) FROM kullanici WHERE kullaniciYetki = 'Sekreter'";
            MySqlCommand command2 = new MySqlCommand(countQuery2, connection);
            int rowCount2 = Convert.ToInt32(command2.ExecuteScalar());
            label7.Text = rowCount2.ToString();

            string countQuery3 = $"SELECT COUNT(*) FROM evraklar";
            MySqlCommand command3 = new MySqlCommand(countQuery3, connection);
            int rowCount3 = Convert.ToInt32(command3.ExecuteScalar());
            label8.Text = rowCount3.ToString();

            string countQuery4 = "SELECT COUNT(*) FROM evraklar WHERE evrakDurum = 'Mevcut'";
            MySqlCommand command4 = new MySqlCommand(countQuery4, connection);
            int rowCount4 = Convert.ToInt32(command4.ExecuteScalar());
            label12.Text = rowCount4.ToString();

            string countQuery5 = "SELECT COUNT(*) FROM evraklar WHERE evrakDurum = 'Emanet'";
            MySqlCommand command5 = new MySqlCommand(countQuery5, connection);
            int rowCount5 = Convert.ToInt32(command5.ExecuteScalar());
            label11.Text = rowCount5.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (yetki == 2)
            {
                this.Hide();
                KullanıcıForm KullanıcıForm = new KullanıcıForm(yetki, aktifTC);
                KullanıcıForm.Show();
            }

            if (yetki == 1)
            {
                this.Hide();
                PersonelForm PersonelForm = new PersonelForm(yetki, aktifTC);
                PersonelForm.Show();
            }
        }
        private void İstatistikler_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void İstatistikler_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void İstatistikler_Resize(object sender, EventArgs e)
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
