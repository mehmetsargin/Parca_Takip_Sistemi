using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace proje_geliştirme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            btnRed.BackColor = Color.Red;
            btnRework.BackColor = Color.Yellow;
            btnOk.BackColor = Color.Green;
            btnListele.BackColor = Color.MediumSeaGreen;
            groupBox1.Text = "KAYITLAR";
            lblSaat.BringToFront();
            lblSaat.ForeColor = Color.Red;


            comboBox1.Items.Add("kaynak hatası");
            comboBox1.Items.Add("cnc işleme hatası");
            comboBox1.Items.Add("geometri hatası");

            comboBox4.Items.Add("kaynak hatası");
            comboBox4.Items.Add("cnc işleme hatası");
            comboBox4.Items.Add("geometri hatası");

            comboBox2.Items.Add("Kaynakta gözenek, köpürme");
            comboBox2.Items.Add("Hatalı işlenmiş yüzey(Yarım, dalgalı vb.)	");
            comboBox2.Items.Add("Kaynakta delme erime");
            comboBox2.Items.Add("Konum hatası.");
            comboBox2.Items.Add("Kaynak boyu hatalı (Kısa, uzun)");
            comboBox2.Items.Add("t. Plakası ince");
            comboBox2.Items.Add("Kaynak dikişi bozuk(Çökme, aşırı yığılma, ince kaynak)");
            comboBox2.Items.Add("Detay parça kaynaklı hata(Bükme, kesme vb.)");

            comboBox5.Items.Add("Kaynakta delme erime");
            comboBox5.Items.Add("Hatalı işlenmiş yüzey(Yarım, dalgalı vb.)");
            comboBox5.Items.Add("Deformasyon");
            comboBox5.Items.Add("Eksik Kaynak");
            

        }
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-F1P7BKK\\SQLEXPRESS;Initial Catalog=proje_geliştirme;Integrated Security=True");
        int barkod = 0;
        
        private void btnRed_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_geliştir (hata,hatadetay,durum,barkod,PerAd,SicilNo) values (@h1,@h2,@h3,@h4,@h5,@h6)", baglanti);
            if (comboBox1.Text != "" && comboBox2.Text != "" && maskedTextBox1.Text !=""&&textBox1.Text!=""&&textBox2.Text!="" )
            {
                int nbarkod = Convert.ToInt32(maskedTextBox1.Text);
                if (barkod == nbarkod) 
                {
                    SqlCommand komutsil = new SqlCommand("delete from tbl_geliştir where barkod=@k1", baglanti);
                    komutsil.Parameters.AddWithValue("@k1", nbarkod);
                    komutsil.ExecuteNonQuery();

                }
                komut.Parameters.AddWithValue("@h1", comboBox1.Text);
                komut.Parameters.AddWithValue("@h2", comboBox2.Text);
                komut.Parameters.AddWithValue("@h3", btnRed.Text);
                komut.Parameters.AddWithValue("@h4", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@h5", textBox1.Text);
                komut.Parameters.AddWithValue("@h6", textBox2.Text);
                komut.ExecuteNonQuery();
                barkod = nbarkod;

            }
            else
            {
                MessageBox.Show("Lütfen değerleri eksiksiz girin.");
            }

            baglanti.Close();

        }

        private void btnRework_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_geliştir (hata,hatadetay,durum,barkod,PerAd,SicilNo) values (@h1,@h2,@h3,@h4,@h5,@h6)", baglanti);
            if (comboBox4.Text != "" && comboBox5.Text != "" && maskedTextBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                int nbarkod = Convert.ToInt32(maskedTextBox1.Text);
                if (barkod == nbarkod)
                {
                    SqlCommand komutsil = new SqlCommand("delete from tbl_geliştir where barkod=@k1", baglanti);
                    komutsil.Parameters.AddWithValue("@k1", nbarkod);
                    komutsil.ExecuteNonQuery();

                }
                komut.Parameters.AddWithValue("@h1", comboBox4.Text);
                komut.Parameters.AddWithValue("@h2", comboBox5.Text);
                komut.Parameters.AddWithValue("@h3", btnRework.Text);
                komut.Parameters.AddWithValue("@h4", maskedTextBox1.Text);
                komut.Parameters.AddWithValue("@h5", textBox1.Text);
                komut.Parameters.AddWithValue("@h6", textBox2.Text);
                komut.ExecuteNonQuery();
                barkod = nbarkod;

            }
            else
            {
                MessageBox.Show("Lütfen değerleri eksiksiz girin.");
            }

            baglanti.Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            maskedTextBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_geliştir (hata,hatadetay,durum,barkod,PerAd,SicilNo) values (@h1,@h2,@h3,@h4,@h5,@h6)", baglanti);
            if (comboBox4.Text == "" && comboBox5.Text == "" && maskedTextBox1.Text != ""&&comboBox1.Text==""&&comboBox2.Text==""&&textBox1.Text != "" && textBox2.Text != "")
            {
                int nbarkod = Convert.ToInt32(maskedTextBox1.Text);
                if (barkod == nbarkod)
                {
                    SqlCommand komutsil = new SqlCommand("delete from tbl_geliştir where barkod=@k1", baglanti);
                    komutsil.Parameters.AddWithValue("@k1", nbarkod);
                    komutsil.ExecuteNonQuery();
                }
                    komut.Parameters.AddWithValue("@h1", "none");
                    komut.Parameters.AddWithValue("@h2", "none");
                    komut.Parameters.AddWithValue("@h3", btnOk.Text);
                    komut.Parameters.AddWithValue("@h4", maskedTextBox1.Text);
                    komut.Parameters.AddWithValue("@h5", textBox1.Text);
                    komut.Parameters.AddWithValue("@h6", textBox2.Text);
                    komut.ExecuteNonQuery();
                    barkod = nbarkod;

            }
                else
                {
                    MessageBox.Show("Lütfen OK için ad soyad, sicil no ve barkodu girin.");
                }

                baglanti.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.tbl_geliştirTableAdapter.Fill(this.proje_geliştirmeDataSet1.tbl_geliştir);
            

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            this.tbl_geliştirTableAdapter.Fill(this.proje_geliştirmeDataSet1.tbl_geliştir);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            
        }

    }

}
    



