using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Policy;
using System.Windows.Forms;

namespace PortfolioStatic
{
    public partial class AnaPanel : Form
    {
        //Boþ bir Data Table oluþturuyoruz, ki DataGridView ile baðlantýsýný saðlayalým.
        public string connectionString = "Server=localhost;Port=5050;Database=nodedb;Uid=root;Pwd=1234";
        public AnaPanel()
        {
            InitializeComponent();
        }

        void CakismaKontrol(Graph graph)
        {
            bool cakismaVar = false;
            //Bu kýsýmda List veri seti yerine HashSet kullanýyorum, çünkü List daha maliyetli.
            HashSet<string> kontrolEdilenOgretmenler = new HashSet<string>();
            HashSet<string> kontrolEdilenOgretmenSlotlari = new HashSet<string>();

            foreach (Node dugum in graph.Nodes)
            {
                string ogretmenToken = $"{dugum.Ogretmen}-{dugum.Gun}-{dugum.Saat}";

                if (kontrolEdilenOgretmenSlotlari.Contains(ogretmenToken))
                {
                    MessageBox.Show("Çakýþma bulundu: Öðretmenlerin çakýþan zaman dilimleri var.");
                    cakismaVar = true;
                    break;
                }

                kontrolEdilenOgretmenSlotlari.Add(ogretmenToken);

                HashSet<string> kontrolEdilenDugumler = new HashSet<string>();

                string dugumAnahtari = $"{dugum.Saat}-{dugum.Sinif}-{dugum.Gun}";

                if (kontrolEdilenDugumler.Contains(dugumAnahtari) && kontrolEdilenOgretmenler.Contains(dugum.Ogretmen))
                {
                    MessageBox.Show("Çakýþma bulundu: Tekrarlanan düðüm anahtarý ve öðretmen kombinasyonu.");
                    cakismaVar = true;
                    break;
                }

                kontrolEdilenDugumler.Add(dugumAnahtari);
                kontrolEdilenOgretmenler.Add(dugum.Ogretmen);

                foreach (Edge kenar in dugum.Komsular)
                {
                    Node komsuDugum = kenar.Kaynak == dugum ? kenar.Hedef : kenar.Kaynak;

                    string komsuAnahtari = $"{komsuDugum.Saat}-{komsuDugum.Sinif}-{komsuDugum.Gun}";

                    if (dugumAnahtari == komsuAnahtari)
                    {
                        MessageBox.Show("Çakýþma bulundu: Düðümler ayný anahtara sahip.");
                        cakismaVar = true;
                        break;
                    }
                }

                if (cakismaVar)
                    break;
            }

            saveBtn.Enabled = !cakismaVar;
        }

        //Verileri Databaseden getiren kod.
        private void GetData()
        {
            try
            {
                //Veritabanýna baðlanmak için connection oluþturuyoruz.
                using MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string query = @"
                        SELECT Gun, Saat, DersAdi, Ogretmen, Sinif
                        FROM dersprogrami
                    ";

                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                DerslerDGV.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri yüklenirken bir hata oluþtu: " + ex.Message);
            }
        }

        //Ana Panel yani form1 yüklendiðinde çalýþacak kod
        private void AnaPanel_Load(object sender, EventArgs e)
        {
            GetData();
            saveBtn.Enabled = false;
        }

        //DataGridView Silme Kodu
        private void clearBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Tabloyu temizlemek istediðinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

                        MessageBox.Show("Tablo baþarýyla temizlendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // DataGridView içeriðini temizle
                        DerslerDGV.DataSource = null;
                        DerslerDGV.Rows.Clear();
                        DerslerDGV.Columns.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ýþlem sýrasýnda hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //Data Grid View Tazeleme Kodu
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            DerslerDGV.Refresh();
            GetData();
        }

        //Cakisma olup olmadýðýný kontrol eden kod
        private void controlBtn_Click(object sender, EventArgs e)
        {
            //Textbox ve Combobox'lardaki deðerleri aldýk, kontrol edeceðiz.
            List<Lesson> dersler = new List<Lesson>
            {
                new Lesson(ders1.Text, ogretmen1.Text, sinif1.Text, saat1.Text, gun1.Text),
                new Lesson(ders2.Text, ogretmen2.Text, sinif2.Text, saat2.Text, gun2.Text),
                new Lesson(ders3.Text, ogretmen3.Text, sinif3.Text, saat3.Text, gun3.Text),
                new Lesson(ders4.Text, ogretmen4.Text, sinif4.Text, saat4.Text, gun4.Text),
                new Lesson(ders5.Text, ogretmen5.Text, sinif5.Text, saat5.Text, gun5.Text),
                new Lesson(ders6.Text, ogretmen6.Text, sinif6.Text, saat6.Text, gun6.Text),
                new Lesson(ders7.Text, ogretmen7.Text, sinif7.Text, saat7.Text, gun7.Text),
                new Lesson(ders8.Text, ogretmen8.Text, sinif8.Text, saat8.Text, gun8.Text),
            };

            //Kontrol mekanizmasý için Graf sýnýfýmýzý oluþturalým.
            Graph graph = new Graph();

            foreach (var lesson in dersler)
            {
                Node node = new Node(lesson.Ad, lesson.Ogretmen, lesson.Sinif, lesson.Saat, lesson.Gun);
                graph.AddNode(node);

                foreach (var foreignNode in graph.Nodes)
                {
                    if (foreignNode != node)
                    {
                        if (foreignNode.DersAdi == node.DersAdi || foreignNode.Ogretmen == node.Ogretmen || foreignNode.Sinif == node.Sinif || foreignNode.Saat == node.Saat || foreignNode.Gun == node.Gun)
                        {
                            graph.AddEdge(node, foreignNode);
                        }
                    }
                }
            }

            CakismaKontrol(graph);
            graph.Temizle();
            dersler.Clear();
        }

        //Verileri Database'e kaydetme kodu
        private void saveBtn_Click(object sender, EventArgs e)
        {
            DataTable programTable = new DataTable();

            // Sütunlarý DataTable'a ekle
            programTable.Columns.Add("DersAdi", typeof(string));
            programTable.Columns.Add("Ogretmen", typeof(string));
            programTable.Columns.Add("Sinif", typeof(string));
            programTable.Columns.Add("Saat", typeof(string));
            programTable.Columns.Add("Gun", typeof(string));

            // Ders örneklerini DataTable'a ekle
            programTable.Rows.Add(ders1.Text, ogretmen1.Text, sinif1.Text, saat1.Text, gun1.Text);
            programTable.Rows.Add(ders2.Text, ogretmen2.Text, sinif2.Text, saat2.Text, gun2.Text);
            programTable.Rows.Add(ders3.Text, ogretmen3.Text, sinif3.Text, saat3.Text, gun3.Text);
            programTable.Rows.Add(ders4.Text, ogretmen4.Text, sinif4.Text, saat4.Text, gun4.Text);
            programTable.Rows.Add(ders5.Text, ogretmen5.Text, sinif5.Text, saat5.Text, gun5.Text);
            programTable.Rows.Add(ders6.Text, ogretmen6.Text, sinif6.Text, saat6.Text, gun6.Text);
            programTable.Rows.Add(ders7.Text, ogretmen7.Text, sinif7.Text, saat7.Text, gun7.Text);
            programTable.Rows.Add(ders8.Text, ogretmen8.Text, sinif8.Text, saat8.Text, gun8.Text);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    foreach (DataRow row in programTable.Rows)
                    {
                        string insertQuery = "INSERT INTO dersprogrami (DersAdi, Ogretmen, Sinif, Saat, Gun) VALUES (@DersAdi, @Ogretmen, @Sinif, @Saat, @Gun)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@DersAdi", row["DersAdi"]);
                        insertCommand.Parameters.AddWithValue("@Ogretmen", row["Ogretmen"]);
                        insertCommand.Parameters.AddWithValue("@Sinif", row["Sinif"]);
                        insertCommand.Parameters.AddWithValue("@Saat", row["Saat"]);
                        insertCommand.Parameters.AddWithValue("@Gun", row["Gun"]);

                        insertCommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Veriler baþarýyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Veriler gönderildikten sonra DataTable'ý temizle
                    programTable.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ýþlem sýrasýnda hata oluþtu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close(); // Baðlantýyý kapat
                }
            }

            saveBtn.Enabled = false;
            GetData(); // Verileri yeniden çekmek için bir metod çaðýrýlabilir
        }

        //Admin Panel'i açmak için butona gerekli atamayý yapýyoruz.
        private void adminBtn_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Visible = true;
            this.Hide();
        }
    }
}
