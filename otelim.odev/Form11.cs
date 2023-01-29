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
    public partial class Form11 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        DataSet ds = new DataSet();
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            tbtc.MaxLength = 11;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            tbtc.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            tbad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (tbtc.Text!=""&&tbtc.Text.Length==11)
            {
                int a = -1;
                DialogResult c = MessageBox.Show("MİSAFİR ÇIKIŞINI YAPMAK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (c == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand kmt2 = new OleDbCommand("update odalar set  doluyatak= doluyatak +'" + a + "'  where odano='" + textBox1.Text + "'", baglanti);
                    kmt2.ExecuteNonQuery();
                    OleDbCommand silme = new OleDbCommand("delete from misafir where tcno='" + tbtc.Text + "'", baglanti);
                    silme.ExecuteNonQuery();

                    MessageBox.Show("MİSAFİR ÇIKIŞI YAPILDI", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   

                    OleDbCommand cmd = new OleDbCommand("select *from odalar where odano='" + textBox1.Text + "'", baglanti);
                    OleDbDataReader ole = cmd.ExecuteReader();
                    while (ole.Read())
                    {
                        if (ole["durumu"].ToString() == "dolu")
                        {
                            string durum = "boş";
                            OleDbCommand duzenle1 = new OleDbCommand("update odalar set durumu='" + durum + "'where odano='" + textBox1.Text + "'", baglanti);
                            duzenle1.ExecuteNonQuery();

                        }
                    }
                   
                    baglanti.Close();
                    this.Close();
                   }
                     
            }

            else
            {
                MessageBox.Show("LÜTFEN GİRDİĞİNİZ TC NUMARASINI KONTROL EDİNİZ YADA SİLMEK İSTEDİĞİNİZ KAYDI TABLODAN SEÇİN", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tbtc.Text != "" && tbtc.Text.Length == 11)
            {
                Form4 fr4 = new Form4();
                fr4.Show();
                fr4.misafirkayit.Visible = false;
                fr4.button1.Visible = true;

                bool kayitarama = false;
               
                    baglanti.Open();
                    OleDbCommand slctsorgu = new OleDbCommand("select *from misafir where tcno='" + tbtc.Text + "'", baglanti);
                    OleDbDataReader ko = slctsorgu.ExecuteReader();
                    while (ko.Read())
                    {
                        kayitarama = true;
                        fr4.tbtc.Text = ko.GetValue(0).ToString();
                        fr4.tbadi.Text = ko.GetValue(1).ToString();
                        fr4.tbsadi.Text = ko.GetValue(2).ToString();
                        fr4.dateTimePicker3.Text = ko.GetValue(3).ToString();
                        fr4.cbcinsiyet.Text = ko.GetValue(4).ToString();
                        fr4.maskedTextBox2.Text = ko.GetValue(5).ToString();
                        fr4.cbkan.Text = ko.GetValue(6).ToString();
                        fr4.tbmail.Text = ko.GetValue(7).ToString();
                        fr4.tbadres.Text = ko.GetValue(8).ToString();
                        fr4.tbacilkisi.Text = ko.GetValue(9).ToString();
                        fr4.maskedTextBox1.Text = ko.GetValue(10).ToString();
                        fr4.tbacilyakin.Text = ko.GetValue(11).ToString();
                        fr4.tbodano.Text = ko.GetValue(12).ToString();
                        fr4.tbkat.Text = ko.GetValue(13).ToString();
                        fr4.dateTimePicker1.Text = ko.GetValue(14).ToString();
                        fr4.dateTimePicker2.Text = ko.GetValue(15).ToString();
                        fr4.tbkalinacakgun.Text = ko.GetValue(16).ToString();
                        fr4.tbgunlukucret.Text = ko.GetValue(17).ToString();
                        fr4.tbtpucret.Text = ko.GetValue(18).ToString();
                        fr4.cbodeme.Text = ko.GetValue(19).ToString();
                        Form1.tcno = ko.GetValue(20).ToString();

                        this.Close();

                        break;

                    }
                    if (kayitarama == false)
                    {
                        MessageBox.Show("!!ARANAN KAYIT BULUNAAMADI!!", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            else
            {
                MessageBox.Show("LÜTFEN GİRDİĞİNİZ TC NUMARASINI KONTROL EDİNİZ YADA DÜZENLEMEK İSTEDİĞİNİZ KAYDI TABLODAN SEÇİN", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            textBox3.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            maskedTextBox1.Text= dataGridView2.Rows[secilen].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text != "" && maskedTextBox1.Text.Length == 14)
            {
                Form7 fr7 = new Form7();
                fr7.Show();
                fr7.button2.Visible = false;
                fr7.button3.Visible = true;

                bool kayitarama = false;

                baglanti.Open();
                OleDbCommand slctsorgu = new OleDbCommand("select *from rezerve where cepno='" + maskedTextBox1.Text + "'", baglanti);
                OleDbDataReader ko = slctsorgu.ExecuteReader();
                while (ko.Read())
                {
                    kayitarama = true;
                    fr7.tbad.Text = ko.GetValue(0).ToString();
                    fr7.tbsad.Text = ko.GetValue(1).ToString();
                    fr7.mbcep.Text = ko.GetValue(2).ToString();
                    fr7.tbemail.Text = ko.GetValue(3).ToString();
                    fr7.tbodano.Text = ko.GetValue(4).ToString();
                    fr7.tbkat.Text = ko.GetValue(5).ToString();
                    fr7.tbistek.Text = ko.GetValue(6).ToString();
                    fr7.dateTimePicker1.Text = ko.GetValue(7).ToString();
                    fr7.dateTimePicker2.Text = ko.GetValue(8).ToString();
                    fr7.dateTimePicker3.Text = ko.GetValue(9).ToString();
                    Form1.tcno = ko.GetValue(10).ToString();
                    this.Close();
                    break;

                }
                if (kayitarama == false)
                {
                    MessageBox.Show("!!ARANAN KAYIT BULUNAAMADI!!", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else
            {
                MessageBox.Show("LÜTFEN GİRDİĞİNİZ CEP NUMARASINI KONTROL EDİNİZ YADA DÜZENLEMEK İSTEDİĞİNİZ KAYDI TABLODAN SEÇİN", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
