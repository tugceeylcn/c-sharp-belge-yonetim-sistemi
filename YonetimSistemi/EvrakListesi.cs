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
    public partial class EvrakListesi : Form
    {
        private int yetki;
        private string aktifTC;
        public EvrakListesi(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void EvrakListesi_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
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

        private void EvrakListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string silinecekID = textBox10.Text.ToString();


            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM evraklar WHERE evrakId = @evrakId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@evrakId", silinecekID);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Veri silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen ID'ye sahip veri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string evrakAd = textBox1.Text;
            string evrakTur = textBox8.Text;
            string evrakDetay = textBox4.Text;
            DateTime evrakKTarihi = DateTime.Now;
            string evrakKAlanTC = aktifTC;
            string evrakRafNo = textBox3.Text;
            string evrakDurum = "Mevcut";

            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";

            if (string.IsNullOrWhiteSpace(evrakAd) || string.IsNullOrWhiteSpace(evrakTur) || string.IsNullOrWhiteSpace(evrakDetay) || string.IsNullOrWhiteSpace(evrakRafNo))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Kaydetme işlemi yapmadan metoddan çıkılıyor.
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string queryCheckEvrakAd = "SELECT COUNT(*) FROM evraklar WHERE evrakAd = @evrakAd";
                using (MySqlCommand commandCheckEvrakAd = new MySqlCommand(queryCheckEvrakAd, connection))
                {
                    commandCheckEvrakAd.Parameters.AddWithValue("@evrakAd", evrakAd);

                    int count = Convert.ToInt32(commandCheckEvrakAd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Bu evrak adı zaten kayıtlı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Kaydetme işlemi yapmadan metoddan çıkılıyor.
                    }
                }

                string query = "INSERT INTO evraklar (evrakAd,evrakTur,evrakDetay,evrakKTarihi,evrakKAlanTC,evrakRafNo,evrakDurum) VALUES (@evrakAd, @evrakTur, @evrakDetay, @evrakKTarihi, @evrakKAlanTC, @evrakRafNo,@evrakDurum)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@evrakAd", evrakAd);
                    command.Parameters.AddWithValue("@evrakTur", evrakTur);
                    command.Parameters.AddWithValue("@evrakDetay", evrakDetay);
                    command.Parameters.AddWithValue("@evrakKTarihi", evrakKTarihi);
                    command.Parameters.AddWithValue("@evrakKAlanTC", evrakKAlanTC);
                    command.Parameters.AddWithValue("@evrakRafNo", evrakRafNo);
                    command.Parameters.AddWithValue("@evrakDurum", evrakDurum);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Evrak kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Evrak kaydedilirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();
            }

            Listele();
            textBox1.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox8.Text = string.Empty;
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
        private void Ara_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Selected = false;
                }
            }
            string arananEvrakAdi = textBox9.Text.ToLower();
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

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void EvrakListesi_Resize(object sender, EventArgs e)
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
