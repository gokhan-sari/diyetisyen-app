using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace diyetisyen_uygulamasi
{
    class rapor
    {
        public void rapor_al(string ad, string soyad)
        {
            string hastalik, diyet_tur, detay, tcno, telno, email, adres;

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=db.accdb;");
            con.Open();

            OleDbCommand cmd = new OleDbCommand("select * from hastalar where ad='" + ad + "' and soyad='" + soyad + "'", con);
            OleDbDataReader sorgu = cmd.ExecuteReader();

            while (sorgu.Read())
            {
                hastalik = sorgu["hastalik"].ToString();
                diyet_tur = sorgu["diyet_tur"].ToString();
                detay = sorgu["detay"].ToString();
                tcno = sorgu["tcno"].ToString();
                telno = sorgu["telno"].ToString();
                email = sorgu["email"].ToString();
                adres = sorgu["adres"].ToString();

                string[] lines = File.ReadAllLines(@"deneme.html");
                if (lines.Length > 0)
                {
                    lines[40] = "<td>" + ad + "</td>";
                    lines[41] = "<td>" + soyad + "</td>";
                    lines[42] = "<td>" + tcno + "</td>";
                    lines[43] = "<td>" + telno + "</td>";
                    lines[44] = "<td>" + email + "</td>";
                    lines[45] = "<td>" + adres + "</td>";

                    lines[57] = "<td>" + hastalik + "</td>";
                    lines[58] = "<td>" + diyet_tur + "</td>";
                    lines[59] = "<td>" + detay + "</td>";

                    File.WriteAllLines("deneme.html", lines);

                    System.Diagnostics.Process.Start(@"deneme.html");

                    MessageBox.Show("Rapor Alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            con.Close();
        }
    }
}
