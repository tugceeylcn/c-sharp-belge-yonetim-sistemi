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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace YonetimSistemi
{
    public partial class EvrakAra : Form
    {
        private int yetki;
        private string aktifTC;
        public EvrakAra(int yetki, string aktifTC)
        {
            InitializeComponent();
            this.yetki = yetki;
            this.aktifTC = aktifTC;
        }

        private void EvrakAra_Load(object sender, EventArgs e)
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

            for (int i = 0; i < reader.FieldCount; i++)
            {
                dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
            }


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

        private void EvrakAra_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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



        private void button2_Click(object sender, EventArgs e)
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime bugun = DateTime.Now;
                int yil = bugun.Year;
                int ay = bugun.Month;
                string query = "SELECT * FROM evraklar WHERE YEAR(evrakKTarihi) = " + yil + " AND MONTH(evrakKTarihi) = " + ay;
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView1.Rows.Add(rowData);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            Listele();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime bugun = DateTime.Now.Date;
                string query = "SELECT * FROM evraklar WHERE DATE(evrakKTarihi) = '" + bugun.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView1.Rows.Add(rowData);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime dun = DateTime.Now.Date.AddDays(-1);
                string query = "SELECT * FROM evraklar WHERE DATE(evrakKTarihi) = '" + dun.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView1.Rows.Add(rowData);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime simdikiTarih = DateTime.Now.Date;
                DateTime gecenAyBaslangic = simdikiTarih.AddMonths(-1).AddDays(-simdikiTarih.Day + 1);
                DateTime gecenAyBitis = simdikiTarih.AddDays(-simdikiTarih.Day);
                string query = "SELECT * FROM evraklar WHERE evrakKTarihi >= '" + gecenAyBaslangic.ToString("yyyy-MM-dd") + "' AND evrakKTarihi <= '" + gecenAyBitis.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView1.Rows.Add(rowData);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime simdikiTarih = DateTime.Now.Date;
                int yil = simdikiTarih.Year;
                DateTime buYilBaslangic = new DateTime(yil, 1, 1);
                DateTime buYilBitis = new DateTime(yil, 12, 31);
                string query = "SELECT * FROM evraklar WHERE evrakKTarihi >= '" + buYilBaslangic.ToString("yyyy-MM-dd") + "' AND evrakKTarihi <= '" + buYilBitis.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView1.Rows.Add(rowData);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                DateTime simdikiTarih = DateTime.Now.Date;
                int gecenYil = simdikiTarih.Year - 1;
                DateTime gecenYilBaslangic = new DateTime(gecenYil, 1, 1);
                DateTime gecenYilBitis = new DateTime(gecenYil, 12, 31);
                string query = "SELECT * FROM evraklar WHERE evrakKTarihi >= '" + gecenYilBaslangic.ToString("yyyy-MM-dd") + "' AND evrakKTarihi <= '" + gecenYilBitis.ToString("yyyy-MM-dd") + "'";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dataGridView1.Columns.Add(reader.GetName(i), reader.GetName(i));
                }

                while (reader.Read())
                {
                    object[] rowData = new object[reader.FieldCount];
                    reader.GetValues(rowData);
                    dataGridView1.Rows.Add(rowData);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void EvrakAra_Resize(object sender, EventArgs e)
        {
            AdjustControls();
        }
        private void AdjustControls()
        {
            panel4.Left = (this.ClientSize.Width - panel4.Width) / 2; // Formun genişliğine göre panel2'nin yatay konumunu ayarla
            panel4.Top = 10; // Formun üstünden 10 piksel aşağıda konumlandır


        }

    }
}
