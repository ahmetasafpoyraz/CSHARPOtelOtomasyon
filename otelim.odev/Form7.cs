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
    public partial class Form7 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        public Form7()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                tbistek.Visible = true;
            }
            else
            {
                tbistek.Visible = false;
                tbistek.Clear();
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from rezerve where cepno ='" + mbcep.Text + "'", baglanti);
            OleDbDataReader kytokuma = slctsorgu.ExecuteReader();

            while (kytokuma.Read())
            {
                kayitkontrol = true;
                break;

            }
            baglanti.Close();
            if (kayitkontrol == false)
            {
                if (tbad.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (tbsad.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (tbemail.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (mbcep.Text == "(   )    -" || mbcep.Text.Length < 14)
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (tbad.Text != "" && tbsad.Text != "" && tbemail.Text != "" && mbcep.Text != "(   )    -" && mbcep.Text.Length == 14)
                {

                    string durum = "rezerve";
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into rezervasyon values('" + tbad.Text + "','" + tbsad.Text + "','" + mbcep.Text + "','" + tbemail.Text + "','" + tbodano.Text + "','" + tbkat.Text + "','" + tbistek.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + Form1.tcno + "')", baglanti);
                    ekle.ExecuteNonQuery();

                    OleDbCommand ekle2 = new OleDbCommand("insert into rezerve values('" + tbad.Text + "','" + tbsad.Text + "','" + mbcep.Text + "','" + tbemail.Text + "','" + tbodano.Text + "','" + tbkat.Text + "','" + tbistek.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + Form1.tcno + "')", baglanti);
                    ekle2.ExecuteNonQuery();
                   
                    OleDbCommand duzenle = new OleDbCommand("update odalar set durumu='" + durum + "'where odano='" + tbodano.Text + "'", baglanti);
                    duzenle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("REZEVASYON OLUŞTURULDU", "OTELİİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                else
                {
                    MessageBox.Show("KIRMIZI İLE İŞARETLİ ALANLARI KONTROL EDİNİZ", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("GİRİLEN TELEFON NUMARASI DAHA ÖNCE KAYIT EDİLMİŞTİR", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            tbad.CharacterCasing = CharacterCasing.Upper;
            tbsad.CharacterCasing = CharacterCasing.Upper;
        }

        private void button3_Click(object sender, EventArgs e)
        {
              if (tbad.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (tbsad.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (tbemail.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (mbcep.Text == "(   )    -" || mbcep.Text.Length < 14)
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (tbad.Text != "" && tbsad.Text != "" && tbemail.Text != "" && mbcep.Text != "(   )    -" && mbcep.Text.Length == 14)
                {
                    baglanti.Open();
                    OleDbCommand duzenle = new OleDbCommand("update rezervasyon set adi='" + tbad.Text + "',soyadi='" + tbsad.Text + "',cepno='" + mbcep.Text + "',email='" + tbemail.Text + "',odano='" + tbodano.Text + "',kat='" + tbkat.Text + "',ozelistek='" + tbistek.Text + "',kayittarihi='" + dateTimePicker1.Text + "',giris='" + dateTimePicker2.Text + "',cikis='" + dateTimePicker3.Text + "',kaydiyapan='" + Form1.tcno + "'where odano '" + tbodano.Text + "'", baglanti);
                    duzenle.ExecuteNonQuery();

                    OleDbCommand duzenle2 = new OleDbCommand("update rezerve set adi='" + tbad.Text + "',soyadi='" + tbsad.Text + "',cepno='" + mbcep.Text + "',email='" + tbemail.Text + "',odano='" + tbodano.Text + "',kat='" + tbkat.Text + "',ozelistek='" + tbistek.Text + "',kayittarihi='" + dateTimePicker1.Text + "',giris='" + dateTimePicker2.Text + "',cikis='" + dateTimePicker3.Text + "',kaydiyapan='" + Form1.tcno + "'where odano '"+tbodano.Text+"'", baglanti);
                    duzenle2.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("REZEVASYON BİLGİLERİ DÜZENLENDİ ", "OTELİİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                 }
                else
                {
                    MessageBox.Show("KIRMIZI İLE İŞARETLİ ALANLARI KONTROL EDİNİZ", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

          
        }
    }
}
