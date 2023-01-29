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

namespace otelim.odev
{
    public partial class Form8 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
       public static DataSet ds = new DataSet();
       public static DataSet ds2 = new DataSet();
        public Form8()
        {
            InitializeComponent();
        }
        private void rezrevegoster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter
           ("select adi,soyadi,cepno,email,odano,kat,ozelistek,kayittarihi,giris,cikis,kaydiyapan from rezervasyon", baglanti);
                if (ds2.Tables["rezervasyon"] != null) ds2.Tables["rezervasyon"].Clear();
                listele.Fill(ds2, "rezervasyon");
                dataGridView2.DataSource = ds2.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatabildir)
            {
                MessageBox.Show(hatabildir.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
           
        }
        private void kayitgoster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter
       ("select tcno,adi,soyadi,dogumtarihi,cinsiyet,cepno,kangurubu,mail,adres,acildurumdaaranacakkisi,acildurumdaaranacakkisicep,acildurumdaaranacakkiiyakinlikderecesi,odano,kat,giristarihi,cikistarihi,kalinacakgun,gunlukucret,toplamucret,odemeturu,kaydiyapan from musteribilgileri Order By adi ASC", baglanti);
                if (ds.Tables["musteribilgileri"] != null) ds.Tables["musteribilgileri"].Clear();
                listele.Fill(ds, "musteribilgileri");
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatabildir)
            {
                MessageBox.Show(hatabildir.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            kayitgoster();
            dataGridView2.Visible = false;
            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            rezrevegoster();
            groupBox1.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            groupBox2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kayitgoster();
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
        }

        private void tbtcara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from musteribilgileri where tcno like '%" + tbtcara.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds.Clear();
            da.Fill(ds, "musteribilgileri");
        }

        private void tbadara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from musteribilgileri where adi like '%" + tbadara.Text + "%'"; 
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds.Clear();
            da.Fill(ds, "musteribilgileri");
        }

        private void tbodanoara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from musteribilgileri where odano like '%" + tbodanoara.Text + "%'"; 
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds.Clear();
            da.Fill(ds, "musteribilgileri");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 fr10 = new Form10();
            fr10.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            DialogResult c = MessageBox.Show("SEÇİLEN TARİHE KADARKİ BÜTÜN  MİSAFİR VERİLERİ SİLİNECEK SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
              if (c == DialogResult.Yes)
            {
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "delete from musteribilgileri where cikistarihi between dtp1 and dtp2 ";
                cmd.Parameters.AddWithValue("dtp1", dateTimePicker2.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("dtp2", dateTimePicker1.Value.ToShortDateString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("SEÇMİŞ OLDUĞUNUZ TARİHE KADAR OLAN VERİLER SİLİNDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();
             } 
            kayitgoster();

        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from rezervasyon where adi like '%" + textBox1.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds2.Clear();
            da.Fill(ds2, "rezervasyon");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from rezervasyon where odano like '%" + textBox2.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
            ds2.Clear();
            da.Fill(ds2, "rezervasyon");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult c = MessageBox.Show(" SEÇİLEN TARİHE KADARKİ BÜTÜN REZERVASYON KAYITLARI SİLİNECEK SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (c == DialogResult.Yes)
            {
                baglanti.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglanti;
                cmd.CommandText = "delete from rezervasyon where cikis between dtp1 and dtp2 ";
                cmd.Parameters.AddWithValue("dtp1", dateTimePicker2.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("dtp2", dateTimePicker1.Value.ToShortDateString());
                cmd.ExecuteNonQuery();
                MessageBox.Show("SEÇMİŞ OLDUĞUNUZ TARİHE KADAR OLAN VERİLER SİLİNDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                baglanti.Close();

            }    
            rezrevegoster(); 
        }
        

          
        }

    }
