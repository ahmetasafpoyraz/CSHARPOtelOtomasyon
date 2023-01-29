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
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }
        
       
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
            DataSet ds = new DataSet();
            private void temizle()
            {
                 tbtoda.Clear(); tbioda.Clear(); tbuoda.Clear(); tbdoda.Clear(); tbtpoda.Clear();
            }
         
            private void btnkaydet1_Click(object sender, EventArgs e)
            {
                numericUpDown1.Maximum = int.Parse(tbokat.Text)+1;
                int toplamkat;
                toplamkat = int.Parse(tbokat.Text);
                
                bool kayitkontrol = false;
                baglanti.Open();
                OleDbCommand slctsorgu = new OleDbCommand("select * from odagurup where kat='" + numericUpDown1.Value + "'", baglanti);
                OleDbDataReader kytokuma = slctsorgu.ExecuteReader();
               
             

                while (kytokuma.Read())
                {
                    kayitkontrol = true;
                    break;

                }
                baglanti.Close();
                 if (kayitkontrol == false)
            {
                if (numericUpDown1.Value <= toplamkat)
                    {     
                        baglanti.Open();
                        OleDbCommand ekle = new OleDbCommand("insert into odagurup values ('" + numericUpDown1.Value + "','" + tbtoda.Text + "','" + tbioda.Text + "','" + tbuoda.Text + "','" + tbdoda.Text + "','" + tbtpoda.Text + "') ", baglanti);
                        ekle.ExecuteNonQuery();
                        button2.Enabled = true;
                        baglanti.Close();

                        MessageBox.Show("KAT BİLGİLERİ KAYDI GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        numericUpDown1.Value++;
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("TÜM KATLAR İÇİN BİLGİ GİRİLDİ","OTELİM BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    }

            }
                 else
                 {
                     MessageBox.Show("GİRİLEN KAT İLE İLGİLİ BİLGİLER DAHA ÖNCE KAYIT EDİLMİŞTİR", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
                  
                    
                
            }


            private void Form2_Load(object sender, EventArgs e)
            {
                button2.Enabled = false;
                baglanti.Open();
                OleDbCommand slctsorgu = new OleDbCommand("select * from otelbilgileri ", baglanti);
                OleDbDataReader ko = slctsorgu.ExecuteReader();
                while (ko.Read())
                {
                    tboad.Text = ko.GetValue(0).ToString();
                    tboadres.Text = ko.GetValue(1).ToString();
                    tbokat.Text = ko.GetValue(2).ToString();                 
                    break;
                }
                  baglanti.Close();

                  numericUpDown1.Maximum = int.Parse(tbokat.Text)+1;
                  numericUpDown1_ValueChanged(sender, e);
            }

            private void btnduzenle_Click(object sender, EventArgs e)
            {
                if (tbtoda.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (tbioda.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;

                if (tbuoda.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                if (tbdoda.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (tbtoda.Text != "" && tbioda.Text != "" && tbuoda.Text != "" && tbdoda.Text != "")
                {

                    try
                    {
                        baglanti.Open();
                        OleDbCommand silme = new OleDbCommand("delete from odalar where kat='" + numericUpDown1.Value + "' ", baglanti);
                        silme.ExecuteNonQuery();
                        OleDbCommand duzenle = new OleDbCommand("update odagurup set  tekkisilik='" + tbtoda.Text + "',ikikisilik='" + tbioda.Text + "',uckisilik='" + tbuoda.Text + "',dortkisilik='" + tbdoda.Text + "',toplamoda='" + tbtpoda.Text + "'where kat='" + numericUpDown1.Value + "'", baglanti);
                        duzenle.ExecuteNonQuery();
                        baglanti.Close();

                        MessageBox.Show("KAT BİLGİLERİ KAYDI GÜNCELLENDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        temizle();
                    }
                    catch (Exception hatabildirimi)
                    {

                        MessageBox.Show(hatabildirimi.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }
                }
                else
                {
                    MessageBox.Show("KIRMIZI İLE İŞARETLİ ALANLARI KONTROL EDİNİZ", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

          

            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {    
                    tbtoda.Clear();
                    tbioda.Clear();
                    tbuoda.Clear();
                    tbdoda.Clear();
                    tbtpoda.Clear();
                bool kayitarama = false;
                baglanti.Open();
                OleDbCommand slctsorgu = new OleDbCommand("select*from odagurup where kat like '%" + numericUpDown1.Value + "%'", baglanti);
                OleDbDataReader ko = slctsorgu.ExecuteReader();
                while (ko.Read())
                {
                    kayitarama = true;
                    tbtoda.Text = ko.GetValue(1).ToString();
                    tbioda.Text = ko.GetValue(2).ToString();
                    tbuoda.Text = ko.GetValue(3).ToString();
                    tbdoda.Text = ko.GetValue(4).ToString();
                    tbtpoda.Text = ko.GetValue(5).ToString();

                    break;

                }
                if (kayitarama == false)
                {

                }
                 
                baglanti.Close();
                

            }

            private void bntnkaydet2_Click_1(object sender, EventArgs e)
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand silme = new OleDbCommand("delete from otelbilgileri where oteladi='" + tboad.Text + "'", baglanti);
                    silme.ExecuteNonQuery();
                    OleDbCommand ekle = new OleDbCommand("insert into otelbilgileri values ('" + tboad.Text + "','" + tboadres.Text + "','" + tbokat.Text + "') ", baglanti);
                    ekle.ExecuteNonQuery();

                    baglanti.Close();

                    MessageBox.Show("OTEL BİLGİLERİ KAYDI GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    bntnkaydet2.Enabled = false;
                }
                catch (Exception hatabildirimi)
                {

                    MessageBox.Show(hatabildirimi.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    baglanti.Close();
                }
                
            }

            private void duzenle2_Click_1(object sender, EventArgs e)
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand duzenle = new OleDbCommand("update otelbilgileri set  oteladi='" + tboad.Text + "',oteladres='" + tboadres.Text + "',katsayisi='" + tbokat.Text + "'", baglanti);
                    duzenle.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("OTEL BİLGİLERİ GÜNCELLENDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                }
                catch (Exception hatabildirimi)
                {

                    MessageBox.Show(hatabildirimi.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }
            }

            private void button2_Click(object sender, EventArgs e)
            {DialogResult c = MessageBox.Show("LÜTFEN OTEL İLE İLGİLİ BÜTÜN BİLGİLERİ DOĞRU GİRDİĞİNİZDEN EMİN OLUN EĞER EMİN DEĞİLSENİZ BİLGİLERİNİZİ KONTROL EDİN. BİLGİLERDEN EMİN MİSİNİZ ?", "OTELİM UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (c == DialogResult.Yes)
            {
                this.Close();
                Form5 frm5 = new Form5();
                frm5.Show();
                frm5.btnsil.Visible = false;
                frm5.btnkaydet.Visible = false;
                frm5.btnduzenle.Visible = false;
                frm5.btnkytrstrt.Visible = true;
            }
               
            }

            private void tbdoda_TextChanged(object sender, EventArgs e)
            {
                if (tbdoda.Text!="")
                {
                    int toplam = int.Parse(tbtoda.Text) + int.Parse(tbioda.Text) + int.Parse(tbuoda.Text) + int.Parse(tbdoda.Text);
                    tbtpoda.Text = toplam.ToString();
                }
                else
                {
                    tbtpoda.Clear();
                }
                
            }

            private void tbuoda_TextChanged(object sender, EventArgs e)
            {
                if (tbuoda.Text != "")
                {
                    int toplam = int.Parse(tbtoda.Text) + int.Parse(tbioda.Text) + int.Parse(tbuoda.Text);
                    tbtpoda.Text = toplam.ToString();
                }
                else
                {
                    tbtpoda.Clear();
                }
            }

            private void tbioda_TextChanged(object sender, EventArgs e)
            {
                if (tbioda.Text != "")
                {
                    int toplam = int.Parse(tbtoda.Text) + int.Parse(tbioda.Text);
                    tbtpoda.Text = toplam.ToString();
                }
                else
                {
                    tbtpoda.Clear();
                }
            }

            private void tbtoda_TextChanged(object sender, EventArgs e)
            {
                if (tbtoda.Text != "")
                {
                    int toplam = int.Parse(tbtoda.Text);
                    tbtpoda.Text = toplam.ToString();
                }
                else
                {
                    tbtpoda.Clear();
                }
            }

         

           
           
           
    }
}
 