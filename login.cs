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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_FormClosed(object sender, FormClosedEventArgs e). 
        {
            Application.Exit();
        }

        private void giris_butonu_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select * from users where kadi='" + kullanici_adi.Text + "' and pw='" + sifre.Text + "'", con);
            OleDbDataReader sorgu = cmd.ExecuteReader();

            if (sorgu.Read())
            {
                if (kullanici_adi.Text == "admin")
                {
                    this.Hide();
                    admin_panel admin_panel = new admin_panel();
                    admin_panel.Show();
                }
                else
                {
                    this.Hide();
                    diyetisyen_panel diyetisyen_panel = new diyetisyen_panel();
                    diyetisyen_panel.Show();
                }
            }
            else
            {
                MessageBox.Show("Hatalı Giriş", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                kullanici_adi.Text = "";
                sifre.Text = "";
            }

            con.Close();
        }
    }
}
