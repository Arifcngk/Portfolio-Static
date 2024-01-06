namespace PortfolioStatic
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            saveBtn = new Button();
            adminBtn = new Button();
            controlBtn = new Button();
            clearBtn = new Button();
            backBtn = new Button();
            deleteBtn = new Button();
            refreshBtn = new Button();
            dersDuzenlemeTablosu = new GroupBox();
            gun = new ComboBox();
            saat = new ComboBox();
            sinif = new ComboBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            ogretmen = new TextBox();
            label3 = new Label();
            id = new TextBox();
            label2 = new Label();
            ders = new TextBox();
            idtxtBox = new Label();
            DerslerDGV = new DataGridView();
            updateBtn = new Button();
            newLessonBtn = new Button();
            dersDuzenlemeTablosu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DerslerDGV).BeginInit();
            SuspendLayout();
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.Gainsboro;
            saveBtn.Location = new Point(774, -108);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(130, 37);
            saveBtn.TabIndex = 9;
            saveBtn.Text = "Veritabanına Aktar";
            saveBtn.UseVisualStyleBackColor = false;
            // 
            // adminBtn
            // 
            adminBtn.BackColor = Color.Teal;
            adminBtn.FlatAppearance.BorderColor = Color.LightGray;
            adminBtn.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
            adminBtn.FlatStyle = FlatStyle.Flat;
            adminBtn.ForeColor = SystemColors.ButtonHighlight;
            adminBtn.Location = new Point(28, -108);
            adminBtn.Name = "adminBtn";
            adminBtn.Size = new Size(175, 37);
            adminBtn.TabIndex = 11;
            adminBtn.Text = "Gelişmiş Düzenleme";
            adminBtn.UseVisualStyleBackColor = false;
            // 
            // controlBtn
            // 
            controlBtn.Location = new Point(638, -108);
            controlBtn.Name = "controlBtn";
            controlBtn.Size = new Size(130, 37);
            controlBtn.TabIndex = 5;
            controlBtn.Text = "Kontrol Et";
            controlBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            clearBtn.BackColor = SystemColors.InactiveCaption;
            clearBtn.Location = new Point(12, 264);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(188, 37);
            clearBtn.TabIndex = 15;
            clearBtn.Text = "Tabloyu Temizle";
            clearBtn.UseVisualStyleBackColor = false;
            clearBtn.Click += clearBtn_Click;
            // 
            // backBtn
            // 
            backBtn.BackColor = Color.Teal;
            backBtn.FlatAppearance.BorderColor = Color.LightGray;
            backBtn.FlatAppearance.MouseDownBackColor = Color.DarkCyan;
            backBtn.FlatStyle = FlatStyle.Flat;
            backBtn.ForeColor = SystemColors.ButtonHighlight;
            backBtn.Location = new Point(12, 11);
            backBtn.Name = "backBtn";
            backBtn.Size = new Size(175, 37);
            backBtn.TabIndex = 17;
            backBtn.Text = "Geri Dön";
            backBtn.UseVisualStyleBackColor = false;
            backBtn.Click += backBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(622, 11);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(130, 37);
            deleteBtn.TabIndex = 12;
            deleteBtn.Text = "Dersi Sil";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = Color.FromArgb(224, 224, 224);
            refreshBtn.Location = new Point(206, 264);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(188, 37);
            refreshBtn.TabIndex = 13;
            refreshBtn.Text = "Tabloyu Yenile";
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // dersDuzenlemeTablosu
            // 
            dersDuzenlemeTablosu.BackColor = SystemColors.ActiveCaption;
            dersDuzenlemeTablosu.Controls.Add(gun);
            dersDuzenlemeTablosu.Controls.Add(saat);
            dersDuzenlemeTablosu.Controls.Add(sinif);
            dersDuzenlemeTablosu.Controls.Add(label6);
            dersDuzenlemeTablosu.Controls.Add(label5);
            dersDuzenlemeTablosu.Controls.Add(label4);
            dersDuzenlemeTablosu.Controls.Add(ogretmen);
            dersDuzenlemeTablosu.Controls.Add(label3);
            dersDuzenlemeTablosu.Controls.Add(id);
            dersDuzenlemeTablosu.Controls.Add(label2);
            dersDuzenlemeTablosu.Controls.Add(ders);
            dersDuzenlemeTablosu.Controls.Add(idtxtBox);
            dersDuzenlemeTablosu.Location = new Point(12, 54);
            dersDuzenlemeTablosu.Name = "dersDuzenlemeTablosu";
            dersDuzenlemeTablosu.Size = new Size(876, 204);
            dersDuzenlemeTablosu.TabIndex = 16;
            dersDuzenlemeTablosu.TabStop = false;
            dersDuzenlemeTablosu.Text = "Düzenle - Ekle";
            // 
            // gun
            // 
            gun.FormattingEnabled = true;
            gun.Items.AddRange(new object[] { "pazartesi", "salı", "çarşamba", "perşembe", "cuma" });
            gun.Location = new Point(306, 161);
            gun.Name = "gun";
            gun.Size = new Size(355, 23);
            gun.TabIndex = 22;
            // 
            // saat
            // 
            saat.FormattingEnabled = true;
            saat.Items.AddRange(new object[] { "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00" });
            saat.Location = new Point(306, 132);
            saat.Name = "saat";
            saat.Size = new Size(355, 23);
            saat.TabIndex = 21;
            // 
            // sinif
            // 
            sinif.FormattingEnabled = true;
            sinif.Items.AddRange(new object[] { "1036", "1040", "1041", "1044" });
            sinif.Location = new Point(306, 103);
            sinif.Name = "sinif";
            sinif.Size = new Size(355, 23);
            sinif.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(227, 164);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 11;
            label6.Text = "GÜN :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(227, 135);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 9;
            label5.Text = "SAAT :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(227, 106);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 7;
            label4.Text = "SINIF :";
            // 
            // ogretmen
            // 
            ogretmen.Location = new Point(306, 74);
            ogretmen.Name = "ogretmen";
            ogretmen.Size = new Size(355, 23);
            ogretmen.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 77);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 5;
            label3.Text = "ÖĞRETMEN :";
            // 
            // id
            // 
            id.Enabled = false;
            id.Location = new Point(306, 16);
            id.Name = "id";
            id.Size = new Size(355, 23);
            id.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(227, 48);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 3;
            label2.Text = "DERS :";
            // 
            // ders
            // 
            ders.Location = new Point(306, 45);
            ders.Name = "ders";
            ders.Size = new Size(355, 23);
            ders.TabIndex = 1;
            // 
            // idtxtBox
            // 
            idtxtBox.AutoSize = true;
            idtxtBox.Location = new Point(227, 19);
            idtxtBox.Name = "idtxtBox";
            idtxtBox.Size = new Size(24, 15);
            idtxtBox.TabIndex = 0;
            idtxtBox.Text = "ID :";
            // 
            // DerslerDGV
            // 
            DerslerDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DerslerDGV.BackgroundColor = Color.White;
            DerslerDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DerslerDGV.Location = new Point(12, 307);
            DerslerDGV.Name = "DerslerDGV";
            DerslerDGV.Size = new Size(876, 368);
            DerslerDGV.TabIndex = 14;
            DerslerDGV.CellContentClick += DerslerDGV_CellContentClick;
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.Gainsboro;
            updateBtn.Location = new Point(758, 11);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(130, 37);
            updateBtn.TabIndex = 18;
            updateBtn.Text = "Güncelle";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // newLessonBtn
            // 
            newLessonBtn.BackColor = SystemColors.ActiveCaption;
            newLessonBtn.Location = new Point(486, 11);
            newLessonBtn.Name = "newLessonBtn";
            newLessonBtn.Size = new Size(130, 37);
            newLessonBtn.TabIndex = 19;
            newLessonBtn.Text = "Ders Ekle";
            newLessonBtn.UseVisualStyleBackColor = false;
            newLessonBtn.Click += newLessonBtn_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 683);
            Controls.Add(newLessonBtn);
            Controls.Add(updateBtn);
            Controls.Add(clearBtn);
            Controls.Add(backBtn);
            Controls.Add(deleteBtn);
            Controls.Add(refreshBtn);
            Controls.Add(dersDuzenlemeTablosu);
            Controls.Add(DerslerDGV);
            Controls.Add(saveBtn);
            Controls.Add(adminBtn);
            Controls.Add(controlBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AdminPanel";
            Text = "AdminPanel";
            FormClosed += AdminPanel_FormClosed;
            Load += AdminPanel_Load;
            dersDuzenlemeTablosu.ResumeLayout(false);
            dersDuzenlemeTablosu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DerslerDGV).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button saveBtn;
        private Button adminBtn;
        private Button controlBtn;
        private Button clearBtn;
        private Button backBtn;
        private Button deleteBtn;
        private Button refreshBtn;
        private GroupBox dersDuzenlemeTablosu;
        private DataGridView DerslerDGV;
        private Button updateBtn;
        private Label idtxtBox;
        private Label label4;
        private TextBox ogretmen;
        private Label label3;
        private TextBox id;
        private Label label2;
        private TextBox ders;
        private Label label5;
        private Label label6;
        private Button newLessonBtn;
        private ComboBox gun;
        private ComboBox saat;
        private ComboBox sinif;
    }
}