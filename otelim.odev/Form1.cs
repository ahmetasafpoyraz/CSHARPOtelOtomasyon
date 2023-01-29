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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        public static string kullaniciadi, yetki, tcno, ad, soyad, resim;
        bool durum = false;
        int hak = 5;
        private void Form1_Load(object sender, EventArgs e)
        {
            rbmudur.Checked = true;
            this.AcceptButton = btngrs; this.CancelButton = btncks;
            label4.Text = Convert.ToString(hak);
           
            tbka.Text = "poyraz";
            tbsf.Text = "1234";
        }

        private void btngrs_Click(object sender, EventArgs e)
        {  
            if (hak != 0)
            {
                baglanti.Open();
                OleDbCommand ole = new OleDbCommand("select * from kullanicibilgileri", baglanti);
                OleDbDataReader kayitokuma = ole.ExecuteReader();
                while (kayitokuma.Read())
                {
                    if (rbmudur.Checked == true && checkBox1.Checked == true)
                    {
                        if (kayitokuma["kullaniciadi"].ToString() == tbka.Text&&kayitokuma["parola"].ToString()==tbsf.Text&&kayitokuma["yetki"].ToString()=="MÜDÜR")
                        {
                            durum = true;
                             this.Hide();
                             Form2 frm2 = new Form2();
                             frm2.Show();
                          
                             break;
                        }
                       
                    }
                    if (rbpersonel.Checked == true && checkBox1.Checked == true)
                    {
                        durum = true;
                        MessageBox.Show("BU İŞLEM İÇİN YETKİYE SAHİP DEĞİLSİNİZ","OTELİM UYARI",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        baglanti.Close();
                       break;
                    }


                    if (rbmudur.Checked == true)
                    {
                        if (kayitokuma["kullaniciadi"].ToString() == tbka.Text&&kayitokuma["parola"].ToString()==tbsf.Text&&kayitokuma["yetki"].ToString()=="MÜDÜR")
                        {
                            durum = true;
                            kullaniciadi = kayitokuma.GetValue(3).ToString();
                            ad = kayitokuma.GetValue(1).ToString();
                            soyad = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(5).ToString();
                            resim = kayitokuma.GetValue(6).ToString();
                            tcno = kayitokuma.GetValue(0).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3();
                            frm3.Show();
                           MessageBox.Show("OTELİM PROGRAMINA HOŞGELDİNİZ SAYIN "+ad+" "+soyad, "OTELİM", MessageBoxButtons.OK, MessageBoxIcon.None);
                       
                            break;
                        }
                      
                    }
                     if (rbpersonel.Checked == true)
                    {
                        if (kayitokuma["kullaniciadi"].ToString() == tbka.Text && kayitokuma["parola"].ToString() == tbsf.Text && kayitokuma["yetki"].ToString() == "PERSONEL")
                        {
                            durum = true;
                            kullaniciadi = kayitokuma.GetValue(3).ToString();
                            ad = kayitokuma.GetValue(1).ToString();
                            soyad = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(5).ToString();
                            resim = kayitokuma.GetValue(6).ToString();
                            tcno = kayitokuma.GetValue(0).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3();
                            frm3.btnkatkayıt.Visible = false;
                            frm3.btnkulbilg.Visible = false;
                            frm3.button1.Visible = false;
                            frm3.Show();
                            MessageBox.Show("OTELİM PROGRAMINA HOŞGELDİNİZ SAYIN " + ad + " " + soyad, "OTELİM", MessageBoxButtons.OK, MessageBoxIcon.None);
                          
                            break;
                        }
                    }

                     
                }
                if (durum == false)
                {
                    MessageBox.Show("!!GİRDİĞİNİZ KULLANICI ADI,PAROLA VEYA YETKİ HATALI!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    hak--;                 
                }
                baglanti.Close();
            }
                  label4.Text = Convert.ToString(hak);
               
                if (hak <= 3 && hak!=0 )
                {
                    label4.ForeColor = Color.Red;
                    MessageBox.Show(hak + "  DENEME HAKKINIZ KALDI");
                }
            
            if (hak == 0)
            {
                btngrs.Enabled = false;
                MessageBox.Show("!!YANLIŞ GİRİŞ HAKKINIZI DOLDURDUNUZ!!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }


          
        }

        private void btncks_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}