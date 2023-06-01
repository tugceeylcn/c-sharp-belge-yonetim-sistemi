using MySql.Data.MySqlClient;

namespace YonetimSistemi
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }


        private void AnaForm_Load(object sender, EventArgs e)
        {
            this.Text = "Belge Yönetim Sistemi";
            this.CenterToScreen();
            textBox2.PasswordChar = '*';
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int yetki = 0;
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;
            string connectionString = "server=172.21.54.3; database=Grup15-2023; uid=Grup15-2023; password=NyP:974.cc;";
            string kullaniciTcNo = "";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT kullaniciTcNo FROM kullanici WHERE kullaniciAd = @kullaniciAdi";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        kullaniciTcNo = result.ToString();
                    }

                    connection.Close();
                }
            }




            if (yetki == 0)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM kullanici WHERE kullaniciAd = @kullaniciAdi AND kullaniciSifre = @sifre";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                        command.Parameters.AddWithValue("@sifre", sifre);

                        int result = Convert.ToInt32(command.ExecuteScalar());

                        if (result > 0)
                        {
                            query = "SELECT kullaniciYetki FROM kullanici WHERE kullaniciAd = @kullaniciAdi";

                            using (MySqlCommand yetkiCommand = new MySqlCommand(query, connection))
                            {
                                yetkiCommand.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);

                                string kullaniciYetki = yetkiCommand.ExecuteScalar()?.ToString();

                                if (kullaniciYetki == "Sekreter")
                                {
                                    yetki = 1;
                                }
                                else
                                {
                                    yetki = 2;
                                }
                            }
                        }
                        else
                        {
                            yetki = 0;
                        }
                    }
                }
            }



            if (yetki == 1)
            {


                this.Hide();
                PersonelForm PersonelForm = new PersonelForm(yetki, kullaniciTcNo);
                PersonelForm.Show();
            }
            else if (yetki == 2)
            {


                this.Hide();
                KullanýcýForm KullanýcýForm = new KullanýcýForm(yetki, kullaniciTcNo);
                KullanýcýForm.Show();
            }
            else
            {
                MessageBox.Show("Giriþ baþarýsýz! Kullanýcý adý veya þifre hatalý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void AnaForm_SizeChanged(object sender, EventArgs e)
        {

        }

        private void AnaForm_Resize(object sender, EventArgs e)
        {
            AdjustControls();
        }
        private void AdjustControls()
        {
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2; // Formun geniþliðine göre panelin yatay konumunu ayarla
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2; // Formun yüksekliðine göre panelin dikey konumunu ayarla


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}


