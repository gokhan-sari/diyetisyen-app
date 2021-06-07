using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace diyetisyen_uygulamasi
{
    public partial class diyetisyen_panel : Form
    {
        public diyetisyen_panel()
        {
            InitializeComponent();
        }

        public void hastalar_tablosu_doldur()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select ad,soyad,hastalik,diyet_tur,tcno,telno,email,adres from hastalar", con);
            DataTable tablo1 = new DataTable();
            tablo1.Load(cmd.ExecuteReader());
            hastalar_tablosu.DataSource = tablo1;

            con.Close();
        }

        public void hastaliklar_doldur()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select hastalik_ad from hastalik_diyet where tur='Hastalık'", con);
            OleDbDataReader sorgu = cmd.ExecuteReader();

            while (sorgu.Read())
            {
                hastaliklar.Items.Add(sorgu["hastalik_ad"]).ToString();
            }

            con.Close();
        }

        public void hastalar_doldur()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            int hasta_sayisi = hastalar_tablosu.RowCount - 1;

            hastalar.Items.Clear();

            for (int i = 0; i < hasta_sayisi; i++)
            {
                hastalar.Items.Add(hastalar_tablosu[0, i].Value.ToString() + " " + hastalar_tablosu[1, i].Value.ToString());
            }

            con.Close();
        }

        public void secili_hasta_getir()
        {
            if (hastalar.SelectedIndex != -1)
            {
                int secili_index = hastalar.SelectedIndex;
                string hastalik, diyet;

                hastalik = hastalar_tablosu[2, secili_index].Value.ToString();
                diyet = hastalar_tablosu[3, secili_index].Value.ToString();

                hastalar_tablosu.ClearSelection();
                hastalar_tablosu.Rows[secili_index].Selected = true;
                hastalar_tablosu.CurrentCell = hastalar_tablosu.Rows[secili_index].Cells[0];

                hastaliklar.Text = hastalik;
                diyetler.Text = diyet;
            }
            
        }

        public void diyetler_doldur()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select diyet_ad from hastalik_diyet where tur='Diyet'", con);
            OleDbDataReader sorgu = cmd.ExecuteReader();

            while (sorgu.Read())
            {
                diyetler.Items.Add(sorgu["diyet_ad"]).ToString();
            }

            con.Close();
        }

        private void diyetisyen_panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void diyetisyen_panel_Load(object sender, EventArgs e)
        {
            hastalar_tablosu_doldur();
            hastaliklar_doldur();
            diyetler_doldur();
            hastalar_doldur();
        }

        private void hastalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            secili_hasta_getir();
        }

        private void hasta_ekle_Click(object sender, EventArgs e)
        {
            if ((ad.Text == "") || (soyad.Text == "") || (tcno.Text == "") || 
                (telno.Text == "") || (email.Text == "") || (adres.Text == ""))
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("insert into hastalar (ad,soyad,tcno,telno,email,adres) values ('" + ad.Text + "','" + soyad.Text + "','" + tcno.Text + "','" + telno.Text + "','" + email.Text + "','" + adres.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Kayıt İşlemi Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ad.Text = "";
                soyad.Text = "";
                tcno.Text = "";
                telno.Text = "";
                email.Text = "";
                adres.Text = "";

                hastaliklar.Text = "Seçiniz";
                diyetler.Text = "Seçiniz";
                hastalar.Text = "Seçiniz";

                hastalar_tablosu_doldur();
                hastalar_doldur();
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            if (hastaliklar.Text == "Seçiniz" || diyetler.Text == "Seçiniz" || hastalar.Text == "Seçiniz")
            {
                MessageBox.Show("Seçim Yapmalısınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string ad, soyad, hastalik, diyet;
                ad = hastalar_tablosu.CurrentRow.Cells[0].Value.ToString();
                soyad = hastalar_tablosu.CurrentRow.Cells[1].Value.ToString();
                hastalik = hastalar_tablosu.CurrentRow.Cells[2].Value.ToString();
                diyet = hastalar_tablosu.CurrentRow.Cells[3].Value.ToString();                   

                if (hastaliklar.Text == hastalik && diyetler.Text == diyet) 
                {
                    MessageBox.Show("Değişiklik Yapmalısınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand("update hastalar set hastalik='" + hastaliklar.Text + "', diyet_tur='" + diyetler.Text + "' where ad='" + ad + "' and soyad='" + soyad + "'", con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Güncelleme Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    con.Close();
                }
                
            }
            hastalar_tablosu_doldur();
            secili_hasta_getir();
        }
    }
}
