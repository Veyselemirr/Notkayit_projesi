using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-2K9PCLA;Initial Catalog=DbNotlar;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            OgretmenGirisi frm = new OgretmenGirisi();
            frm.Show();
            this.Hide();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Notlar where OgrSifre=@p1 ",baglanti);
            komut.Parameters.AddWithValue("@p1", MskTxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                OgrenciSayfası frm = new OgrenciSayfası();
                                frm.numara = TxtNumara.Text;

                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
            baglanti.Close();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
