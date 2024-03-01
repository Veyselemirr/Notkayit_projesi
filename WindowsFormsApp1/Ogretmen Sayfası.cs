using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Ogretmen_Sayfası : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2K9PCLA;Initial Catalog=DbNotlar;Integrated Security=True");
        public Ogretmen_Sayfası()
        {
            InitializeComponent();
        }

        private void Ogretmen_Sayfası_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbNotlarDataSet.Tbl_Notlar' table. You can move, or remove it, as needed.
            this.tbl_NotlarTableAdapter.Fill(this.dbNotlarDataSet.Tbl_Notlar);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Notlar (OgrNumara,OgrAd,OgrSoyad) Values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", MskNumara.Text);
            komut.Parameters.AddWithValue("@p2", MskAd.Text);
            komut.Parameters.AddWithValue("@p3", MskSoyad.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Sİsteme Eklendi");
            this.tbl_NotlarTableAdapter.Fill(this.dbNotlarDataSet.Tbl_Notlar);


        }

        private void button2_Click(object sender, EventArgs e)
        {

            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(TxtSınav1.Text);
            s2 = Convert.ToDouble(TxtSınav2.Text);
            s3 = Convert.ToDouble(TxtSınav3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }
            LblOrt.Text = ortalama.ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Notlar set Ogrs1=@p1,ogrs2=@p2,ogrs3=@p3,ortalama=@s4,durum=@s5 where ogrnumara=@s6", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtSınav1.Text);
            komut.Parameters.AddWithValue("@p2", TxtSınav2.Text);
            komut.Parameters.AddWithValue("@p3", TxtSınav3.Text);
            komut.Parameters.AddWithValue("@s4", decimal.Parse(LblOrt.Text));
            komut.Parameters.AddWithValue("@s5", durum);
            komut.Parameters.AddWithValue("@s6", MskNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Güncellendi");
            this.tbl_NotlarTableAdapter.Fill(this.dbNotlarDataSet.Tbl_Notlar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtSınav1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtSınav2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtSınav3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }
    }
}
