﻿using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class PersonelListesi : Form
    {
        private int yetki;
        private string aktifTC;
        public PersonelListesi(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void PersonelListesi_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
            textBox6.MaxLength = 11;
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
            string query = "SELECT * FROM kullanici WHERE kullaniciYetki = 'Sekreter'";
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
            dataGridView1.Columns["kullaniciAdSoyad"].HeaderText = "Ad Soyad";
            dataGridView1.Columns["kullaniciAd"].HeaderText = "Personel Adı";
            dataGridView1.Columns["kullaniciSifre"].HeaderText = "Sifre";
            dataGridView1.Columns["kullaniciEmail"].HeaderText = "Mail";
            dataGridView1.Columns["kullaniciTelefonNo"].HeaderText = "Telefon";
            dataGridView1.Columns["kullaniciDepartman"].HeaderText = "Departman";
            dataGridView1.Columns["kullaniciTcNo"].HeaderText = "Tc No";
            dataGridView1.Columns["kullaniciYetki"].HeaderText = "Yetki";
            dataGridView1.Columns["kullaniciID"].HeaderText = "Personel ID";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdSoyad = textBox1.Text;
            string kullaniciAd = textBox8.Text;
            string kullaniciEmail = textBox2.Text;
            string kullaniciTelefonNo = textBox3.Text;
            string kullaniciDepartman = textBox7.Text;
            string kullaniciTcNo = textBox6.Text;
            string kullaniciSifre = textBox4.Text;
            string kullaniciSifreTekrar = textBox5.Text;
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";

            if (string.IsNullOrWhiteSpace(kullaniciAdSoyad) || string.IsNullOrWhiteSpace(kullaniciAd) || string.IsNullOrWhiteSpace(kullaniciSifre) || string.IsNullOrWhiteSpace(kullaniciSifreTekrar) || string.IsNullOrWhiteSpace(kullaniciEmail) || string.IsNullOrWhiteSpace(kullaniciTelefonNo) || string.IsNullOrWhiteSpace(kullaniciDepartman) || string.IsNullOrWhiteSpace(kullaniciTcNo))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (kullaniciSifre.ToString() == kullaniciSifreTekrar.ToString())
            {
                if (kullaniciTelefonNo.Length != 10 || !kullaniciTelefonNo.All(char.IsDigit))
                {
                    MessageBox.Show("Geçersiz telefon numarası. Telefon numarası 10 basamaklı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (kullaniciTcNo.Length != 11 || !kullaniciTcNo.All(char.IsDigit))
                {
                    MessageBox.Show("Geçersiz TC numarası. Tc numarası 11 basamaklı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string queryCheckTcNo = "SELECT COUNT(*) FROM kullanici WHERE kullaniciTcNo = @kullaniciTcNo";
                    using (MySqlCommand commandCheckTcNo = new MySqlCommand(queryCheckTcNo, connection))
                    {
                        commandCheckTcNo.Parameters.AddWithValue("@kullaniciTcNo", kullaniciTcNo);

                        int count = Convert.ToInt32(commandCheckTcNo.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Bu TC kimlik numarası zaten kayıtlı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Kaydetme işlemi yapmadan metoddan çıkılıyor.
                        }
                    }

                    string query = "INSERT INTO kullanici (kullaniciAdSoyad,kullaniciAd, kullaniciSifre, kullaniciEmail, kullaniciTelefonNo, kullaniciDepartman, kullaniciTcNo,kullaniciYetki) VALUES (@kullaniciAdSoyad,@kullaniciAd, @kullaniciSifre, @kullaniciEmail, @kullaniciTelefonNo, @kullaniciDepartman, @kullaniciTcNo,'Sekreter')";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullaniciAdSoyad", kullaniciAdSoyad);
                        command.Parameters.AddWithValue("@kullaniciAd", kullaniciAd);
                        command.Parameters.AddWithValue("@kullaniciSifre", kullaniciSifre);
                        command.Parameters.AddWithValue("@kullaniciEmail", kullaniciEmail);
                        command.Parameters.AddWithValue("@kullaniciTelefonNo", kullaniciTelefonNo);
                        command.Parameters.AddWithValue("@kullaniciDepartman", kullaniciDepartman);
                        command.Parameters.AddWithValue("@kullaniciTcNo", kullaniciTcNo);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Kullanıcı kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı kaydedilirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı kaydedilirken bir hata oluştu. Şifreler Uyumu Değil!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = string.Empty;
                textBox5.Text = string.Empty;
                return;
            }
            Listele();
            textBox1.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
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

        private void PersonelListesi_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string silinecekID = textBox10.Text.ToString();


            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query1 = "SELECT kullaniciTcNo FROM kullanici WHERE kullaniciId = @kullaniciID";
                using (MySqlCommand command1 = new MySqlCommand(query1, connection))
                {
                    command1.Parameters.AddWithValue("@kullaniciId", silinecekID);

                    using (MySqlDataReader reader1 = command1.ExecuteReader())
                    {
                        if (reader1.Read())
                        {
                            string kullaniciTcNo = reader1.GetString("kullaniciTcNo");

                            if (kullaniciTcNo == aktifTC)
                            {
                                MessageBox.Show("Silinecek kullanıcı aktif kullanıcı (siz) olduğu için silme işlemi gerçekleştirilemez.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Belirtilen ID'ye sahip veri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                string query = "DELETE FROM kullanici WHERE kullaniciId = @kullaniciID AND kullaniciYetki = 'Sekreter'";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciId", silinecekID);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Veri silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Belirtilen ID'ye sahip veri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Listele();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void ComboBox()
        {
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = 'Grup15-2023' AND TABLE_NAME = 'kullanici';";

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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void PersonelListesi_Resize(object sender, EventArgs e)
        {
            AdjustControls();
        }
        private void AdjustControls()
        {
            panel3.Left = (this.ClientSize.Width - panel3.Width) / 2; // Formun genişliğine göre panel2'nin yatay konumunu ayarla
            panel3.Top = 10; // Formun üstünden 10 piksel aşağıda konumlandır

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
