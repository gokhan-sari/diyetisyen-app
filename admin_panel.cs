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
    public partial class admin_panel : Form
    {
        public admin_panel()
        {
            InitializeComponent();
        }

        private void admin_panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void geri_butonu_Click(object sender, EventArgs e)
        {
            this.Hide();
            login login = new login();
            login.Show();
        }

        private void diyetisyen_ekle_Click(object sender, EventArgs e)
        {
            if ((ad.Text == "") || (soyad.Text == "") || (tcno.Text == "") || (telno.Text == "") ||
               (email.Text == "") || (adres.Text == "") || (id.Text == "") || (pw.Text == ""))
            {
                MessageBox.Show("Tüm Alanları Doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("insert into users (ad,soyad,tcno,telno,email,adres,kadi,pw) values ('" + ad.Text + "','" + soyad.Text + "','" + tcno.Text + "','" + telno.Text + "','" + email.Text + "','" + adres.Text + "','" + id.Text + "','" + pw.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Kayıt İşlemi Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ad.Text = "";
                soyad.Text = "";
                tcno.Text = "";
                telno.Text = "";
                email.Text = "";
                adres.Text = "";
                id.Text = "";
                pw.Text = "";
            }
        }

        private void hastalik_ekle_Click(object sender, EventArgs e)
        {
            if (hastalik_adi.Text == "")
            {
                MessageBox.Show("Giriş Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("insert into hastalik_diyet (hastalik_ad, tur) values ('" + hastalik_adi.Text + "', 'Hastalık')", con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Ekleme İşlemi Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                hastalik_adi.Text = "";
            }
        }

        private void diyet_ekle_Click(object sender, EventArgs e)
        {
            if (diyet_adi.Text == "")
            {
                MessageBox.Show("Giriş Yapınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
                con.Open();

                OleDbCommand cmd = new OleDbCommand("insert into hastalik_diyet (diyet_ad, tur) values ('" + diyet_adi.Text + "', 'Diyet')", con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Ekleme İşlemi Gerçekleşti.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                diyet_adi.Text = "";
            }
        }
    }
}
