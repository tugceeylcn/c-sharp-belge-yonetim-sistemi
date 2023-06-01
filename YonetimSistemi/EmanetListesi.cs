using Google.Protobuf.WellKnownTypes;
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
    public partial class EmanetListesi : Form
    {
        private int yetki;
        private string aktifTC;
        public EmanetListesi(int yetki, string aktifTC)
        {

            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void EmanetListesi_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
            if (yetki == 2)
            {
                textBox4.Enabled = false;
                button3.Enabled = false;
            }
            else
            {
                textBox4.Enabled = true;
                button3.Enabled = true;
            }

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
            string query = "SELECT * FROM emanet WHERE teslimTarihi IS NULL";
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
        private void button4_Click(object sender, EventArgs e)
        {
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            PersonelForm PersonelForm = new PersonelForm(yetki, aktifTC);
            PersonelForm.Show();
        }

        private void EmanetListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



        private void button2_Click(object sender, EventArgs e)
        {


            Listele();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
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

        private void button3_Click_2(object sender, EventArgs e)
        {
            string girilenEmanetkID = textBox4.Text;

            // TextBox boş ise hata mesajı göster ve işlemi durdur
            if (string.IsNullOrEmpty(girilenEmanetkID))
            {
                MessageBox.Show("Lütfen Evrak ID girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Girilen Emanet ID'nin veritabanında olup olmadığını kontrol et
                string checkQuery = "SELECT COUNT(*) FROM emanet WHERE emanetID = @emanetID";
                MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                checkCommand.Parameters.AddWithValue("@emanetID", girilenEmanetkID);
                int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                if (count == 0)
                {
                    // Emanet ID mevcut değilse bildirim göster ve işlemi durdur
                    MessageBox.Show("Girilen Emanet ID mevcut değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;
                }

                // Emanet ID'ye ait evrakID değerini bul
                string evrakIDQuery = "SELECT evrakID FROM emanet WHERE emanetID = @emanetID";
                MySqlCommand evrakIDCommand = new MySqlCommand(evrakIDQuery, connection);
                evrakIDCommand.Parameters.AddWithValue("@emanetID", girilenEmanetkID);
                string evrakID = evrakIDCommand.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(evrakID))
                {
                    // Evrak ID mevcut ise evrakDurum değerini güncelle
                    string updateEvrakDurumQuery = "UPDATE evraklar SET evrakDurum = 'Mevcut' WHERE evrakID = @evrakID";
                    MySqlCommand updateEvrakDurumCommand = new MySqlCommand(updateEvrakDurumQuery, connection);
                    updateEvrakDurumCommand.Parameters.AddWithValue("@evrakID", evrakID);
                    updateEvrakDurumCommand.ExecuteNonQuery();
                }

                // Teslim alan TC değerini kontrol et
                string checkTcQuery = "SELECT teslimAlanTc FROM emanet WHERE emanetID = @emanetID";
                MySqlCommand checkTcCommand = new MySqlCommand(checkTcQuery, connection);
                checkTcCommand.Parameters.AddWithValue("@emanetID", girilenEmanetkID);
                string teslimAlanTc = checkTcCommand.ExecuteScalar()?.ToString();

                if (!string.IsNullOrEmpty(teslimAlanTc))
                {
                    // Teslim alan TC değeri dolu ise hata ver ve işlemi durdur
                    MessageBox.Show("Girilen Emanet ID mevcut değil.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return;
                }

                // Teslim tarihini güncelle
                string updateQuery = "UPDATE emanet SET teslimTarihi = NOW(), teslimAlanTc = @teslimAlanTc WHERE emanetID = @emanetID";
                MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                updateCommand.Parameters.AddWithValue("@emanetID", girilenEmanetkID);
                updateCommand.Parameters.AddWithValue("@teslimAlanTc", aktifTC); // aktifTC değişkeniyle güncelle
                updateCommand.ExecuteNonQuery();

                connection.Close();
            }

            MessageBox.Show("Veriler başarıyla güncellendi.", "Bildirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }


        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void EmanetListesi_Resize(object sender, EventArgs e)
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
