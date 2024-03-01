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
    public partial class OgrenciSayfası : Form
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2K9PCLA;Initial Catalog=DbNotlar;Integrated Security=True");
        public OgrenciSayfası()
        {
            InitializeComponent();
        }
        public string numara;
        private void OgrenciSayfası_Load(object sender, EventArgs e)
        {
           LblNo.Text = numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Notlar where OgrNumara=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",LblNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAd.Text = dr[2].ToString();
                LblSoyad.Text = dr[3].ToString();
                LblSınav1.Text = dr[4].ToString();
                LblSınav2.Text = dr[5].ToString();
                LblSınav3.Text = dr[6].ToString();
            }
            baglanti.Close();
        }
    }
}
