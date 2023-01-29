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
    public partial class Form4 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            tbtc.MaxLength = 11;
            tbtc.Focus();
            tbadi.CharacterCasing = CharacterCasing.Upper;
            tbsadi.CharacterCasing = CharacterCasing.Upper;
           
           

        }

        private void tbtc_TextChanged(object sender, EventArgs e)
        {

            if (tbtc.Text.Length < 11)
                errorProvider1.SetError(tbtc, "TC KİMLİK NO 11 HANELİ OLMALİ !!");
            else
                errorProvider1.Clear();
            if (tbtc.Text == "")
                errorProvider1.Clear();

            if (tbtc.Text.Length == 11)
            {
                bool kayitarama = false;

                baglanti.Open();
                OleDbCommand slctsorgu = new OleDbCommand("select*from musteribilgileri where tcno like '%" + tbtc.Text + "%'", baglanti);
                OleDbDataReader ko = slctsorgu.ExecuteReader();
                while (ko.Read())
                {
                    kayitarama = true;

                    tbadi.Text = ko.GetValue(1).ToString();
                    tbsadi.Text = ko.GetValue(2).ToString();
                    dateTimePicker3.Text = ko.GetValue(3).ToString();
                    cbcinsiyet.Text = ko.GetValue(4).ToString();
                    maskedTextBox2.Text = ko.GetValue(5).ToString();
                    cbkan.Text = ko.GetValue(6).ToString();
                    tbmail.Text = ko.GetValue(7).ToString();
                    tbadres.Text = ko.GetValue(8).ToString();
                    tbacilkisi.Text = ko.GetValue(9).ToString();
                    maskedTextBox1.Text = ko.GetValue(10).ToString();
                    tbacilyakin.Text = ko.GetValue(11).ToString();
                    dateTimePicker1.Text = ko.GetValue(14).ToString();
                    dateTimePicker2.Text = ko.GetValue(15).ToString();                   
                    
                    break;

                }
                baglanti.Close();
                if (kayitarama == false) { }
            }
            else
            {
                tbadi.Clear(); tbsadi.Clear(); maskedTextBox2.Clear(); tbmail.Clear(); tbadres.Clear();
                tbacilkisi.Clear(); maskedTextBox1.Clear(); tbacilyakin.Clear(); cbcinsiyet.Text = "";
            }     

        }

        private void tbtc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void misafirkayit_Click(object sender, EventArgs e)
        {   string yataksayisi,doluyataksayisi;
            int a = 1;
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from misafir where tcno='" + tbtc.Text + "'", baglanti);
            OleDbDataReader kytokuma = slctsorgu.ExecuteReader();

            while (kytokuma.Read())
            {
                kayitkontrol = true;
                break;

            }
            baglanti.Close();
            if (kayitkontrol == false)
            {
                if (tbtc.Text.Length < 11 || tbtc.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (tbadi.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (tbsadi.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (cbcinsiyet.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                if (cbkan.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (tbadres.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (maskedTextBox2.Text == "(   )    -"||maskedTextBox2.Text.Length<14)
                    label10.ForeColor = Color.Red;
                else
                    label10.ForeColor = Color.Black;

                if (tbmail.Text == "")
                    label11.ForeColor = Color.Red;
                else
                    label11.ForeColor = Color.Black;
                if (tbacilkisi.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;

                if (maskedTextBox1.Text == "(   )    -"||maskedTextBox1.Text.Length<14)
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;
           
                if (tbacilyakin.Text == "")
                    label12.ForeColor = Color.Red;
                else
                    label12.ForeColor = Color.Black;
///////////////////////////////////////////////////////////////
                if (tbkalinacakgun.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;

                if (tbgunlukucret.Text == "")
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;

                if (tbtpucret.Text == "")
                    label18.ForeColor = Color.Red;
                else
                    label18.ForeColor = Color.Black;

                if (cbodeme.Text == "")
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;
                if (tbtc.Text.Length == 11 && tbgunlukucret.Text != "" && cbodeme.Text != "" && tbtpucret.Text != "" && tbkalinacakgun.Text != "" && tbtc.Text != "" && tbadi.Text != "" && tbsadi.Text != "" && tbadres.Text != "" && cbcinsiyet.Text != "" && cbkan.Text != "" && maskedTextBox2.Text != "(   )    -" && maskedTextBox2.Text.Length == 14 && tbmail.Text != "" && tbacilkisi.Text != "" && maskedTextBox1.Text != "(   )    -" && maskedTextBox1.Text.Length == 14 && tbacilyakin.Text != "")
                {

                    try
                    {
                      
                        baglanti.Open();
                        OleDbCommand ekle = new OleDbCommand("insert into musteribilgileri values ('" + tbtc.Text + "','" + tbadi.Text + "','" + tbsadi.Text + "','" + dateTimePicker3.Text + "','" + cbcinsiyet.Text + "','" + maskedTextBox2.Text + "','" + cbkan.Text + "','" + tbmail.Text + "','" + tbadres.Text + "','" + tbacilkisi.Text + "','" + maskedTextBox1.Text + "','" + tbacilyakin.Text + "','" + tbodano.Text + "','" + tbkat.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + tbkalinacakgun.Text + "','" + tbgunlukucret.Text + "','" + tbtpucret.Text + "','" + cbodeme.Text + "','" + Form1.tcno + "') ", baglanti);
                        ekle.ExecuteNonQuery();
                        OleDbCommand ekle2 = new OleDbCommand("insert into misafir values ('" + tbtc.Text + "','" + tbadi.Text + "','" + tbsadi.Text + "','" + dateTimePicker3.Text + "','" + cbcinsiyet.Text + "','" + maskedTextBox2.Text + "','" + cbkan.Text + "','" + tbmail.Text + "','" + tbadres.Text + "','" + tbacilkisi.Text + "','" + maskedTextBox1.Text + "','" + tbacilyakin.Text + "','" + tbodano.Text + "','" + tbkat.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + tbkalinacakgun.Text + "','" + tbgunlukucret.Text + "','" + tbtpucret.Text + "','" + cbodeme.Text + "','" + Form1.tcno + "') ", baglanti);
                        ekle2.ExecuteNonQuery();
                        OleDbCommand kmt2 = new OleDbCommand("update odalar set  doluyatak= doluyatak +'" + a + "'  where odano='" + tbodano.Text+ "'", baglanti);
                        kmt2.ExecuteNonQuery();
                       
                        MessageBox.Show("MİSAFİR KAYDI GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        OleDbCommand cmd = new OleDbCommand("select *from odalar where odano='"+tbodano.Text+"'", baglanti);
                        OleDbDataReader ole = cmd.ExecuteReader();
                        while (ole.Read())
                        {
                           yataksayisi=ole.GetValue(3).ToString();
                           doluyataksayisi=ole.GetValue(4).ToString();

                            if (doluyataksayisi==yataksayisi)
                            {
                                string durum = "dolu";
                                OleDbCommand duzenle1 = new OleDbCommand("update odalar set durumu='" + durum + "'where odano='" + tbodano.Text + "'", baglanti);
                                duzenle1.ExecuteNonQuery();
                            
                            }
                            

                        }
                        this.Close();
                        baglanti.Close();
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
            else
            {
                MessageBox.Show("GİRİLEN TC NUMARASI DAHA ÖNCE KAYIT EDİLMİŞTİR", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
           
         

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime grstarih = Convert.ToDateTime(dateTimePicker1.Text);
            DateTime ckstarih = Convert.ToDateTime(dateTimePicker2.Text);
            TimeSpan Sonuc = ckstarih - grstarih;
         
            tbkalinacakgun.Text = Sonuc.TotalDays.ToString();
          
        }

        private void tbgunlukucret_TextChanged(object sender, EventArgs e)
        {
            if (tbgunlukucret.Text != "")
            {
                int tpucret = int.Parse(tbkalinacakgun.Text) * int.Parse(tbgunlukucret.Text);
                tbtpucret.Text = tpucret.ToString();
            }
            else
                tbtpucret.Clear();

        }

        private void tbgunlukucret_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from misafir where tcno='" + tbtc.Text + "'", baglanti);
            OleDbDataReader kytokuma = slctsorgu.ExecuteReader();

            while (kytokuma.Read())
            {
                kayitkontrol = true;
                break;

            }
            baglanti.Close();
            if (kayitkontrol == false)
            {*/
                if (tbtc.Text.Length < 11 || tbtc.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (tbadi.Text == "")
                    label2.ForeColor = Color.Red;
                else
                    label2.ForeColor = Color.Black;

                if (tbsadi.Text == "")
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Black;

                if (cbcinsiyet.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                if (cbkan.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (tbadres.Text == "")
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (maskedTextBox2.Text == "(   )    -" || maskedTextBox2.Text.Length < 14)
                    label10.ForeColor = Color.Red;
                else
                    label10.ForeColor = Color.Black;

                if (tbmail.Text == "")
                    label11.ForeColor = Color.Red;
                else
                    label11.ForeColor = Color.Black;
                if (tbacilkisi.Text == "")
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;

                if (maskedTextBox1.Text == "(   )    -" || maskedTextBox1.Text.Length < 14)
                    label9.ForeColor = Color.Red;
                else
                    label9.ForeColor = Color.Black;

                if (tbacilyakin.Text == "")
                    label12.ForeColor = Color.Red;
                else
                    label12.ForeColor = Color.Black;
                ///////////////////////////////////////////////////////////////
                if (tbkalinacakgun.Text == "")
                    label19.ForeColor = Color.Red;
                else
                    label19.ForeColor = Color.Black;

                if (tbgunlukucret.Text == "")
                    label20.ForeColor = Color.Red;
                else
                    label20.ForeColor = Color.Black;

                if (tbtpucret.Text == "")
                    label18.ForeColor = Color.Red;
                else
                    label18.ForeColor = Color.Black;

                if (cbodeme.Text == "")
                    label17.ForeColor = Color.Red;
                else
                    label17.ForeColor = Color.Black;
                if (tbtc.Text.Length == 11 && tbgunlukucret.Text != "" && cbodeme.Text != "" && tbtpucret.Text != "" && tbkalinacakgun.Text != "" && tbtc.Text != "" && tbadi.Text != "" && tbsadi.Text != "" && tbadres.Text != "" && cbcinsiyet.Text != "" && cbkan.Text != "" && maskedTextBox2.Text != "(   )    -" && maskedTextBox2.Text.Length == 14 && tbmail.Text != "" && tbacilkisi.Text != "" && maskedTextBox1.Text != "(   )    -" && maskedTextBox1.Text.Length == 14 && tbacilyakin.Text != "")
                {

                    try
                    {
                        baglanti.Open();
                        OleDbCommand ekle = new OleDbCommand("update musteribilgileri set tcno='" + tbtc.Text + "',adi='" + tbadi.Text + "',soyadi='" + tbsadi.Text + "',dogumtarihi='" + dateTimePicker3.Text + "',cinsiyet='" + cbcinsiyet.Text + "',cepno='" + maskedTextBox2.Text + "',kangurubu='" + cbkan.Text + "',mail='" + tbmail.Text + "',adres='" + tbadres.Text + "',acildurumdaaranacakkisi='" + tbacilkisi.Text + "',acildurumdaaranacakkisicep='" + maskedTextBox1.Text + "',acildurumdaaranacakkiiyakinlikderecesi='" + tbacilyakin.Text + "',odano='" + tbodano.Text + "',kat='" + tbkat.Text + "',giristarihi='" + dateTimePicker1.Text + "',cikistarihi='" + dateTimePicker2.Text + "',kalinacakgun='" + tbkalinacakgun.Text + "',gunlukucret='" + tbgunlukucret.Text + "',toplamucret='" + tbtpucret.Text + "',odemeturu='" + cbodeme.Text + "',kaydiyapan='" + Form1.tcno + "'where tcno='" + tbtc.Text + "' ", baglanti);
                        ekle.ExecuteNonQuery();
                        OleDbCommand ekle2 = new OleDbCommand("update misafir set tcno='" + tbtc.Text + "',adi='" + tbadi.Text + "',soyadi='" + tbsadi.Text + "',dogumtarihi='" + dateTimePicker3.Text + "',cinsiyet='" + cbcinsiyet.Text + "',cepno='" + maskedTextBox2.Text + "',kangurubu='" + cbkan.Text + "',mail='" + tbmail.Text + "',adres='" + tbadres.Text + "',acildurumdaaranacakkisi='" + tbacilkisi.Text + "',acildurumdaaranacakkisicep='" + maskedTextBox1.Text + "',acildurumdaaranacakkiiyakinlikderecesi='" + tbacilyakin.Text + "',odano='" + tbodano.Text + "',kat='" + tbkat.Text + "',giristarihi='" + dateTimePicker1.Text + "',cikistarihi='" + dateTimePicker2.Text + "',kalinacakgun='" + tbkalinacakgun.Text + "',gunlukucret='" + tbgunlukucret.Text + "',toplamucret='" + tbtpucret.Text + "',odemeturu='" + cbodeme.Text + "',kaydiyapan='" + Form1.tcno + "'where tcno='" + tbtc.Text + "' ", baglanti);
                        ekle2.ExecuteNonQuery();
                        MessageBox.Show("MİSAFİR KAYDI DÜZENLEMESİ GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
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
          /*  }
            else
            {
                MessageBox.Show("GİRİLEN TC NUMARASI DAHA ÖNCE KAYIT EDİLMİŞTİR", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/



        }

        
    }
}
