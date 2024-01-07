using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortfolioStatic
{
    public partial class AdminPanel : Form
    {
        public string connectionString = "Server=localhost;Port=5050;Database=nodedb;Uid=root;Pwd=1234";
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            GetData();
        }

        //Verileri Databaseden getiren kod.
        private void GetData()
      
        {
            try
            {
                //Veritabanına bağlanmak için connection oluşturuyoruz.
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = @" SELECT * FROM dersprogrami ";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DerslerDGV.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        //Panel Kapatıldığında programın sonlanması için gereken kod
        private void AdminPanel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Ana Panele dönme butonu
        private void backBtn_Click(object sender, EventArgs e)
        {
            AnaPanel anaPanel = new AnaPanel();
            anaPanel.Show();
            this.Hide();
        }

        //Data Grid View'deki veriye tıklandığında satır bilgileri gelmesi için aşağıdaki kodu yazıyoruz.
        private void DerslerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Lütfen geçerli bir hücreye giriniz !");
            }
            else
            {
                DataGridViewRow row = DerslerDGV.Rows[e.RowIndex];

                // DataGridView hücrelerindeki verileri al
                string idValue = row.Cells["iddersprogrami"].Value.ToString();
                string dersValue = row.Cells["DersAdi"].Value.ToString();
                string ogretmenValue = row.Cells["Ogretmen"].Value.ToString();
                string sinifValue = row.Cells["Sinif"].Value.ToString();
                string saatValue = row.Cells["Saat"].Value.ToString();
                string gunValue = row.Cells["Gun"].Value.ToString();

                // TextBox'lara verileri aktar
                id.Text = idValue;
                ders.Text = dersValue;
                ogretmen.Text = ogretmenValue;

                // ComboBox'lara verileri aktar
                sinif.SelectedItem = sinifValue;
                saat.SelectedItem = saatValue;
                gun.SelectedItem = gunValue;
            }
        }

        //Tabloyu tazeleme butonu
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            DerslerDGV.Refresh();
            GetData();
        }

        //Tabloyu Temizleme butonu
        private void clearBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tabloyu temizlemek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string connectionString = "Server=localhost;Port=5050;Database=nodedb;Uid=root;Pwd=1234;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string clearQuery = "DELETE FROM dersprogrami";
                        MySqlCommand clearCommand = new MySqlCommand(clearQuery, connection);

                        clearCommand.ExecuteNonQuery();

                        MessageBox.Show("Tablo başarıyla temizlendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView içeriğini temizle
                        DerslerDGV.DataSource = null;
                        DerslerDGV.Rows.Clear();
                        DerslerDGV.Columns.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(id.Text))
            {
                MessageBox.Show("Lütfen bir ders seçin !");
            }

            else
            {
                string connectionString = "Server=localhost;Port=5050;Database=nodedb;Uid=root;Pwd=1234;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string clearQuery = "DELETE FROM dersprogrami Where iddersprogrami = @id";
                        MySqlCommand clearCommand = new MySqlCommand(clearQuery, connection);
                        clearCommand.Parameters.AddWithValue("@id", id.Text);

                        clearCommand.ExecuteNonQuery();

                        MessageBox.Show("Ders başarıyla silindi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView içeriğini temizle
                        DerslerDGV.DataSource = null;
                        DerslerDGV.Rows.Clear();
                        DerslerDGV.Columns.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(id.Text))
            {
                MessageBox.Show("Lütfen bir ders seçin");
            }
            else
            {
                string connectionString = "Server=localhost;Port=5050;Database=nodedb;Uid=root;Pwd=1234;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "Update dersprogrami SET DersAdi = @dersAdi, Ogretmen = @ogretmen, Sinif = @sinif, Saat = @saat, Gun = @gun Where iddersprogrami = @id;";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@id", id.Text);
                        updateCommand.Parameters.AddWithValue("@dersAdi", ders.Text);
                        updateCommand.Parameters.AddWithValue("@ogretmen", ogretmen.Text);
                        updateCommand.Parameters.AddWithValue("@sinif", sinif.Text);
                        updateCommand.Parameters.AddWithValue("@saat", saat.Text);
                        updateCommand.Parameters.AddWithValue("@gun", gun.Text);
                        updateCommand.ExecuteNonQuery();

                        MessageBox.Show("Ders başarıyla güncellendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView içeriğini güncelle
                        DerslerDGV.Refresh();
                        GetData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void newLessonBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ders.Text) || String.IsNullOrEmpty(ogretmen.Text) || String.IsNullOrEmpty(sinif.Text) || String.IsNullOrEmpty(saat.Text) || string.IsNullOrEmpty(gun.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun !");
            }
            else
            {
                string connectionString = "Server=localhost;Port=5050;Database=nodedb;Uid=root;Pwd=1234;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string updateQuery = "INSERT INTO dersprogrami (DersAdi, Ogretmen, Sinif, Saat, Gun) VALUES (@dersAdi, @ogretmen, @sinif, @saat, @gun) ";
                        MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@dersAdi", ders.Text);
                        updateCommand.Parameters.AddWithValue("@ogretmen", ogretmen.Text);
                        updateCommand.Parameters.AddWithValue("@sinif", sinif.Text);
                        updateCommand.Parameters.AddWithValue("@saat", saat.Text);
                        updateCommand.Parameters.AddWithValue("@gun", gun.Text);
                        updateCommand.ExecuteNonQuery();

                        MessageBox.Show("Ders başarıyla eklendi !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView içeriğini güncelle
                        DerslerDGV.Refresh();
                        GetData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("İşlem sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
