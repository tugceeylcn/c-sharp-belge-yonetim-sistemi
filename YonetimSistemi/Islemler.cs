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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace YonetimSistemi
{
    public partial class Islemler : Form
    {
        private int yetki;
        private string aktifTC;
        public Islemler(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void Islemler_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
            Listele();
            ComboBox();

            dataGridView1.Enabled = true;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);

        }
        private void Listele()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.Size = new Size(dataGridView1.Width, dataGridView1.Height);
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string query = "SELECT * FROM emanet ";
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();

            // DataGridView'e sütunları ekle
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
            }

            // Verileri DataGridView'e ekle
            while (reader.Read())
            {
                object[] rowData = new object[reader.FieldCount];
                reader.GetValues(rowData);
                dataGridView1.Rows.Add(rowData);
            }

            reader.Close();
            connection.Close();
            dataGridView1.Columns["evrakID"].HeaderText = "Evrak ID ";
            dataGridView1.Columns["emanetTarihi"].HeaderText = "Emanet Alınma Tarihi";
            dataGridView1.Columns["emanetEdenTC"].HeaderText = "Emanet Eden Tc No";
            dataGridView1.Columns["emanetAlanAdSoyad"].HeaderText = "Emanet Alan Ad Soyad";
            dataGridView1.Columns["emanetAlanIletisim"].HeaderText = "Emanet Alan İletişim";
            dataGridView1.Columns["teslimTarihi"].HeaderText = "Teslim Tarihi";
            dataGridView1.Columns["teslimAlanTc"].HeaderText = "Teslim Alan Tc No";
        }
        private void ComboBox()
        {
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'Grup15-2023' AND TABLE_NAME = 'emanet';";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> columnNames = new List<string>();

                        while (reader.Read())
                        {
                            string columnName = reader.GetString(0);
                            columnNames.Add(columnName);
                        }

                        comboBox1.DataSource = columnNames;
                    }
                }

                connection.Close();
            }
        }

        private void Islemler_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void Ara_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                }
            }
            string arananEvrakAdi = textBox1.Text.ToLower();
            string arananStunAdi = comboBox1.SelectedItem.ToString(); // ComboBox'tan seçilen sütun adını burada kullanabilirsiniz

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[arananStunAdi].Value != null && row.Cells[arananStunAdi].Value.ToString().ToLower() == arananEvrakAdi)
                {
                    // Aranan değer bulundu, istediğiniz işlemi gerçekleştirin
                    // Örneğin, bulunan satırı seçebilirsiniz:
                    row.Selected = true;
                    break; // Döngüden çık
                }
            }

            // Döngü tamamlandıktan sonra hala seçili bir satır yoksa, kullanıcıya bilgi mesajı gösterebilirsiniz
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Aradığınız kayıt bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Islemler_Resize(object sender, EventArgs e)
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
