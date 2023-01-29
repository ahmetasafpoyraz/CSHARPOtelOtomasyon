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
    public partial class Form6 : Form
    {
        public static int doluyatak, bosyatak,yataksayisi;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        DataSet ds = new DataSet();
        public Form6()
        {
            InitializeComponent();
        }

        private void misafirkayit_Click(object sender, EventArgs e)
        {
            int x,j;
            x = bosyatak;
            j = doluyatak;
           baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano='"+tboda.Text+"'", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
            while (ole.Read())
            {
                if (ole["durumu"].ToString() == "rezerve")
                {
                    DialogResult c = MessageBox.Show("ODA REZERVE EDİLMİŞ YİNEDE MİSAFİR EKLEMEK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (c == DialogResult.Yes)
                    {
                        for (int i = 1; i <= x; i++)
                        {
                            Form4 frm4 = new Form4();
                            frm4.Show();
                            frm4.label21.Text = (j+i) + ".KİŞİ BİLGİLERİ";
                            frm4.tbodano.Text = tboda.Text;
                            frm4.tbkat.Text = tbkat.Text;
                        }
                       
                        
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                   
                }
	
                else if (ole["durumu"].ToString() == "boş")
                {
                    for (int i = 1; i <= x; i++)
                    {
                        Form4 frm4 = new Form4();
                        frm4.Show();
                        frm4.label21.Text = (j+i) + ".KİŞİ BİLGİLERİ";
                        frm4.tbodano.Text = tboda.Text;
                        frm4.tbkat.Text = tbkat.Text;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ODA ZATEN DOLU", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
               
                break;
              
            }
            baglanti.Close();

            
        }
       
        private void btnmisafirciks_Click(object sender, EventArgs e)
        {
           if (doluyatak!=0)
            { 
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano='" + tboda.Text + "'", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
            while (ole.Read())
            {
                if (ole["doluyatak"].ToString() != "0")
                {

                    string seckomutu = "select*from misafir where odano like '%" + tboda.Text + "%'";
                    OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
                    ds.Clear();
                    da.Fill(ds, "misafir");
                    Form11 fr11 = new Form11();
                    fr11.Show();
                    fr11.textBox1.Text = tboda.Text;
                    fr11.groupBox2.Visible = false;
                    fr11.dataGridView2.Visible = false;
                    fr11.button2.Visible = false;
                    fr11.dataGridView1.DataSource = ds.Tables[0];
                    this.Close();

                }
            }
            baglanti.Close();
            }
             else
             {
                 MessageBox.Show("ODA BOŞ VEYA REZERVELİ OLDUĞU İÇİN BU İŞLEM YAPILAMAZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 this.Close();
             }
        }
        private void rzrvsyniptl_Click(object sender, EventArgs e)
        {
          
             
           baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano='"+tboda.Text+"'", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
            while (ole.Read())
            {
                if (ole["durumu"].ToString() == "rezerve")
                {

                    DialogResult c = MessageBox.Show("ODA REZERVASYONUNU İPTAL ETMEK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (c == DialogResult.Yes)
                    {
                        string durum = "boş";    
                        OleDbCommand duzenle = new OleDbCommand("update odalar set durumu='" + durum + "'where odano='" + tboda.Text + "'", baglanti);
                        duzenle.ExecuteNonQuery();

                        OleDbCommand silme = new OleDbCommand("delete from rezerve where odano='" + tboda.Text + "'", baglanti);
                        silme.ExecuteNonQuery();
                        MessageBox.Show("REZERVASYON İPTALİ YAPILDI", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("ODA DOLU VEYA BOŞ OLDUĞU İÇİN BU İŞLEM YAPILAMAZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            baglanti.Close();
        }

        private void rezerve_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano='"+tboda.Text+"'", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
            while (ole.Read())
            {
                if (ole["durumu"].ToString() != "rezerve"&&ole["doluyatak"].ToString()=="0")
                {
                    Form7 frm7 = new Form7();
                    frm7.Show();
                    frm7.tbodano.Text = tboda.Text;
                    frm7.tbkat.Text = tbkat.Text;
                    this.Close();
                } 
                else
                {
                    MessageBox.Show("ODA DOLU VEYA ODADA DOLU YATAKLAR OLDUĞUNDAN YADA ODA ZATEN REZERVELİ OLDUĞUNDAN BU İŞLEM YAPILAMAZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
              
            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano='" + tboda.Text + "'", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
            while (ole.Read())
            {
                if (ole["doluyatak"].ToString() != "0")
                {
                    string seckomutu = "select*from misafir where odano like '%" + tboda.Text + "%'";
                    OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
                    ds.Clear();
                    da.Fill(ds, "musteribilgileri");
                    Form11 fr11 = new Form11();
                    fr11.Show();
                    fr11.textBox1.Text = tboda.Text;
                    fr11.groupBox2.Visible = false;
                    fr11.dataGridView2.Visible = false;
                    fr11.button1.Visible = false;
                    fr11.dataGridView1.DataSource = ds.Tables[0];
                    this.Close();

                }

                else if (ole["durumu"].ToString() == "rezerve")
                {
                    string seckomutu = "select*from rezerve where odano like '%" + tboda.Text + "%'";
                    OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
                    ds.Clear();
                    da.Fill(ds, "rezerve");
                    Form11 fr11 = new Form11();
                    fr11.Show();
                    fr11.textBox2.Text = tboda.Text;
                    fr11.groupBox1.Visible = false;
                    fr11.dataGridView1.Visible = false;
                    fr11.dataGridView2.Visible = true;
                    fr11.dataGridView2.DataSource = ds.Tables[0];
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ODA BOŞ OLDUĞU İÇİN BU İŞLEM YAPILAMAZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            baglanti.Close();
        }

        private void tboda_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from odalar where odano='" + tboda.Text + "'", baglanti);
            OleDbDataReader ko = slctsorgu.ExecuteReader();
            while (ko.Read())
            {
                textBox1.Text = ko.GetValue(3).ToString();
                textBox2.Text = ko.GetValue(4).ToString();

                break;
            }
            baglanti.Close();
            bosyatak = int.Parse(textBox1.Text) - int.Parse(textBox2.Text);
            doluyatak = int.Parse(textBox1.Text) - bosyatak;
            textBox3.Text = bosyatak.ToString();
            textBox2.Text = doluyatak.ToString();
        
        }

    
    }
    /*
          
           baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from odalar where odano='"+tboda.Text+"'", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
            while (ole.Read())
            {
                if (ole["durumu"].ToString() == "dolu")
                {
                    DialogResult c = MessageBox.Show("MİSAFİR ÇIKIŞINI YAPMAK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (c == DialogResult.Yes)
                    {
                        string durum = "boş";

                        OleDbCommand duzenle = new OleDbCommand("update odalar set durumu='" + durum + "'where odano='" + tboda.Text + "'", baglanti);
                        duzenle.ExecuteNonQuery();
                        //OleDbCommand silme = new OleDbCommand("delete from misafir where odano='" + tboda.Text + "'", baglanti);
                      //  silme.ExecuteNonQuery();
                        MessageBox.Show("MİSAFİR ÇIKIŞI YAPILDI", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                       
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("ODA BOŞ VEYA REZERVELİ OLDUĞU İÇİN BU İŞLEM YAPILAMAZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
            baglanti.Close();
     * 
     * 
     * 
     * 
     * 
     * 
     *  else if (ole["durumu"].ToString() == "rezerve")
                {
                    string seckomutu = "select*from rezervasyon where odano like '%" + tboda.Text + "%'";
                    OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglanti);
                    ds.Clear();
                    da.Fill(ds, "rezervasyon");
                    Form11 fr11 = new Form11();
                    fr11.Show();
                    fr11.dataGridView1.Visible = false;
                    fr11.dataGridView2.Visible = true;
                    fr11.dataGridView2.DataSource = ds.Tables[0];
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ODA BOŞ OLDUĞU İÇİN BU İŞLEM YAPILAMAZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();
                }
            }
     */
}
