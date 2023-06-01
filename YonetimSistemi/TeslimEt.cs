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
    public partial class TeslimEt : Form
    {
        private int yetki;
        private string aktifTC;
        public TeslimEt(int yetki, string aktifITC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifITC;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TeslimEt_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
            textBox3.MaxLength = 10;
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
            string query = "SELECT * FROM evraklar";
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
            dataGridView1.Columns["evrakAd"].HeaderText = "Evrak Ad ";
            dataGridView1.Columns["evrakDetay"].HeaderText = "Detay";
            dataGridView1.Columns["evrakTur"].HeaderText = "Tür";
            dataGridView1.Columns["evrakKTarihi"].HeaderText = "Kayıt Tarihi";
            dataGridView1.Columns["evrakKAlanTC"].HeaderText = "Kayıt Alan Tc No";
            dataGridView1.Columns["evrakRafNo"].HeaderText = "Raf Numarası";
            dataGridView1.Columns["evrakDurum"].HeaderText = "Durum";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                }
            }
            string arananEvrakAdi = textBox4.Text.ToLower();
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
        private void ComboBox()
        {
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'Grup15-2023' AND TABLE_NAME = 'evraklar';";

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

        private void button6_Click(object sender, EventArgs e)
        {
            string EvrakId = textBox1.Text;
            string emanetAlanAdSoyad = textBox2.Text;
            string emanetAlanIletisim = textBox3.Text;

            // TextBox'lara değer girilmediyse hata mesajı göster
            if (string.IsNullOrEmpty(EvrakId) || string.IsNullOrEmpty(emanetAlanAdSoyad) || string.IsNullOrEmpty(emanetAlanIletisim))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (emanetAlanIletisim.Length != 10 || !emanetAlanIletisim.All(char.IsDigit))
            {
                MessageBox.Show("Geçersiz telefon numarası. Telefon numarası 10 basamaklı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
            string teslimEdenSekreterID = aktifTC;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string checkQuery = "SELECT evrakDurum FROM evraklar WHERE evrakID = @evrakID";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@evrakID", EvrakId);
                string currentStatus = checkCommand.ExecuteScalar()?.ToString();

                if (currentStatus == "Emanet")
                {
                    MessageBox.Show("Bu evrak zaten Emanet verildi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string checkQuery2 = "SELECT COUNT(*) FROM evraklar WHERE evrakID = @evrakID";
                MySqlCommand checkCommand2 = new MySqlCommand(checkQuery2, connection);
                checkCommand2.Parameters.AddWithValue("@evrakID", EvrakId);
                int evrakCount = Convert.ToInt32(checkCommand2.ExecuteScalar());

                if (evrakCount == 0)
                {
                    MessageBox.Show("Girilen evrak ID geçersiz. Böyle bir evrak Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Evrak durumunu güncelle
                string updateQuery = "UPDATE evraklar SET evrakDurum = 'Emanet' WHERE evrakID = @evrakID";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@evrakID", EvrakId);
                updateCommand.ExecuteNonQuery();

                // Emanet bilgilerini ekle
                string insertQuery = "INSERT INTO emanet (evrakID, emanetTarihi, emanetEdenTC, emanetAlanAdSoyad, emanetAlanIletisim, teslimTarihi,teslimAlanTc) " +
                                     "VALUES (@evrakID, NOW(), @teslimEdenSekreterID, @emanetAlanAdSoyad, @emanetAlanIletisim, NULL,NULL)";
                MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@evrakID", EvrakId);
                insertCommand.Parameters.AddWithValue("@teslimEdenSekreterID", teslimEdenSekreterID);
                insertCommand.Parameters.AddWithValue("@emanetAlanAdSoyad", emanetAlanAdSoyad);
                insertCommand.Parameters.AddWithValue("@emanetAlanIletisim", emanetAlanIletisim);
                insertCommand.ExecuteNonQuery();

                connection.Close();
            }

            // Bildirim göster
            MessageBox.Show("Evrak Emanet Edildi.", "Bildirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox2.Text = string.Empty;

        }

        private void TeslimEt_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TeslimEt_Resize(object sender, EventArgs e)
        {
            AdjustControls();
        }
        private void AdjustControls()
        {
            panel3.Left = (this.ClientSize.Width - panel3.Width) / 2; // Formun genişliğine göre panel2'nin yatay konumunu ayarla
            panel3.Top = 10; // Formun üstünden 10 piksel aşağıda konumlandır

        }
    }
}
