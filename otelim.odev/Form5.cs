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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        
        private void temizle()
        {
            tbad.Clear(); tbka.Clear(); tbrsim.Clear(); tbsad.Clear(); tbsf.Clear(); tbsft.Clear(); tbtc.Clear(); pictureBox1.ImageLocation = ""; rbmudur.Checked = false; rbpersonel.Checked = false;
        }
        
        private void kullanicilarigoster()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter
                    ("select tcno AS[TC KİMLİK NO],ad AS[ADI],soyad AS[SOYADI],kullaniciadi AS[KULLANICI ADI],parola AS[PAROLA],yetki AS[YETKİ],resim AS[RESİM]  from kullanicibilgileri Order By ad ASC", baglanti);
                DataSet ds = new DataSet();
                listele.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                baglanti.Close();
            }
            catch (Exception hatabildir)
            {
                MessageBox.Show(hatabildir.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            tbrsim.Text = openFileDialog1.FileName;
        }
      
      
        private void Form5_Load(object sender, EventArgs e)
        {
            
            tbtc.MaxLength = 11;
            tbka.MaxLength = 8;
            toolTip1.SetToolTip(this.tbtc, "TC Kimlik No 11 Karakter Olmalı !!");
            toolTip1.SetToolTip(this.tbka, "Kullanıcı Adı Enfala 8 Karakter Olmalı!!");
            tbad.CharacterCasing = CharacterCasing.Upper;
            tbsad.CharacterCasing = CharacterCasing.Upper;
            
           kullanicilarigoster();


            
         

        }

        private void tbtc_TextChanged(object sender, EventArgs e)
        {
            if (tbtc.Text.Length < 11)
                errorProvider1.SetError(tbtc, "TC KİMLİK NO 11 HANELİ OLMALİ !!");
            else
                errorProvider1.Clear();
            if (tbtc.Text == "")
                errorProvider1.Clear();

            if (tbtc.Text == "")
                temizle();
               
        }

        private void tbtc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;

        }

        private void tbsft_TextChanged(object sender, EventArgs e)
        {
            if (tbsft.Text != tbsf.Text)
                errorProvider1.SetError(tbsft, "!!Parola Tekrarı Eşleşmiyor!!");
            else
                errorProvider1.Clear();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            string yetki = "";
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from kullanicibilgileri where tcno='" + tbtc.Text + "'", baglanti);
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
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (tbad.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                if (tbsad.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;

                if (tbka.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (rbmudur.Checked != true && rbpersonel.Checked != true)
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;


                if (tbrsim.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (tbsft.Text != tbsf.Text || tbsf.Text == "" || tbsft.Text == "")
                {
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                }
             else 
                {
                    label3.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                }


                if (tbtc.Text.Length == 11 && tbtc.Text != "" && tbad.Text != "" && tbsad.Text != "" && tbka.Text != "" && tbsf.Text != "" && tbsft.Text != "" && tbsf.Text == tbsft.Text &&tbrsim.Text != ""&& rbmudur.Checked == true || rbpersonel.Checked == true)
                {
                    if (rbmudur.Checked == true)
                        yetki = "MÜDÜR";
                    else if (rbpersonel.Checked == true)
                        yetki = "PERSONEL";
                    try
                    {
                        baglanti.Open();
                        OleDbCommand ekle = new OleDbCommand("insert into kullanicibilgileri values ('" + tbtc.Text + "','" + tbad.Text + "','" + tbsad.Text + "','" + tbka.Text + "','" + tbsf.Text + "','" + yetki + "','" + tbrsim.Text + "') ", baglanti);
                        ekle.ExecuteNonQuery();

                        baglanti.Close();

                        MessageBox.Show("KULLANICI KAYDI GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        kullanicilarigoster();
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
            else
            {
                MessageBox.Show("GİRİLEN TC NUMARASI DAHA ÖNCE KAYIT EDİLMİŞTİR", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool kayitarama = false;
            if (tbtc.Text.Length == 11)
            {
                baglanti.Open();
                OleDbCommand slctsorgu = new OleDbCommand("select *from kullanicibilgileri where tcno='" + tbtc.Text + "'", baglanti);
                OleDbDataReader ko = slctsorgu.ExecuteReader();
                while (ko.Read())
                {
                    kayitarama = true;
                    tbad.Text = ko.GetValue(1).ToString();
                    tbsad.Text = ko.GetValue(2).ToString();
                    if (ko.GetValue(5).ToString() == "MÜDÜR")
                        rbmudur.Checked = true;
                    else
                        rbpersonel.Checked = true;
                    tbka.Text = ko.GetValue(3).ToString();
                    tbsf.Text = ko.GetValue(4).ToString();
                    tbsft.Text = ko.GetValue(4).ToString();
                    tbrsim.Text = ko.GetValue(6).ToString();
                    pictureBox1.ImageLocation = ko.GetValue(6).ToString();
                    
                    break;

                }
                if (kayitarama == false)
                {
                    MessageBox.Show("!!ARANAN KAYIT BULUNAAMADI!!", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("LÜTFEN 11 HANELİ TC KİMLİK NUMARANIZI GİRİNİZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnduzenle_Click(object sender, EventArgs e)
        {
            string yetki = "";
            /*   bool kayitkontrol = false;
               baglanti.Open();
               OleDbCommand slctsorgu = new OleDbCommand("select * from kullanicibilgileri where tcno='" + tbtc.Text + "'", baglanti);
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
                label7.ForeColor = Color.Red;
            else
                label7.ForeColor = Color.Black;

            if (tbad.Text == "")
                label5.ForeColor = Color.Red;
            else
                label5.ForeColor = Color.Black;

            if (tbsad.Text == "")
                label6.ForeColor = Color.Red;
            else
                label6.ForeColor = Color.Black;

            if (tbka.Text == "")
                label1.ForeColor = Color.Red;
            else
                label1.ForeColor = Color.Black;

            if (rbmudur.Checked != true && rbpersonel.Checked != true)
                label8.ForeColor = Color.Red;
            else
                label8.ForeColor = Color.Black;


            if (tbrsim.Text == "")
                label4.ForeColor = Color.Red;
            else
                label4.ForeColor = Color.Black;

            if (tbsft.Text != tbsf.Text || tbsf.Text == "" || tbsft.Text == "")
            {
                label2.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
            }
            else
            {
                label3.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }


            if (tbtc.Text.Length == 11 && tbtc.Text != "" && tbad.Text != "" && tbsad.Text != "" && tbka.Text != "" && tbsf.Text != "" && tbsft.Text != "" && tbsf.Text == tbsft.Text && tbrsim.Text != "" && rbmudur.Checked == true || rbpersonel.Checked == true)
            {
                if (rbmudur.Checked == true)
                    yetki = "MÜDÜR";
                else if (rbpersonel.Checked == true)
                    yetki = "PERSONEL";
                try
                { /*if()
                    else( */
                        baglanti.Open();
                    OleDbCommand duzenle = new OleDbCommand("update kullanicibilgileri set  tcno='" + tbtc.Text + "',ad='" + tbad.Text + "',soyad='" + tbsad.Text + "',kullaniciadi='" + tbka.Text + "',parola='" + tbsf.Text + "',yetki='" + yetki + "',resim='" + tbrsim.Text + "'where tcno='" + tbtc.Text + "'", baglanti);
                    duzenle.ExecuteNonQuery();
                    baglanti.Close();

                    MessageBox.Show("KULLANICI BİLGİLERİ GÜNCELLENDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    kullanicilarigoster();
                    temizle();
                    /*)*/
                   
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
            /* }
             else
              {
                  MessageBox.Show("GİRİLEN TC NUMARASI DAHA ÖNCE KAYIT EDİLMİŞTİR", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }*/
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            bool kayitarama = false;
                        DialogResult c = MessageBox.Show("KAYDI SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ ?", "OTELİM BİLGİ", MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
                        if (c == DialogResult.Yes)
                        {
                            if (tbtc.Text.Length == 11)
                            {
                              
                                baglanti.Open();
                                OleDbCommand slctsorgu = new OleDbCommand("select * from kullanicibilgileri where tcno='" + tbtc.Text + "'", baglanti);
                                OleDbDataReader ko = slctsorgu.ExecuteReader();
                                while (ko.Read())
                                {
                                    kayitarama = true;
                                    OleDbCommand silme = new OleDbCommand("delete from kullanicibilgileri where tcno='" + tbtc.Text + "'", baglanti);
                                    silme.ExecuteNonQuery();
                                    MessageBox.Show("KAYIT SİLİNDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    baglanti.Close();
                                    kullanicilarigoster();
                                    break;
                                }

                                if (kayitarama == false&&tbtc.Text=="")
                                 MessageBox.Show("!!SİLİNECEK KAYIT BULUNAAMADI!!", "OTELİM HATA BİLGİSİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                baglanti.Close();

                                kullanicilarigoster();
                                temizle();

                            }
                            else
                            {
                                MessageBox.Show("LÜTFEN 11 HANELİ TC KİMLİK NUMARANIZI GİRİNİZ", "OTELİM UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                        }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            tbtc.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            tbad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            tbsad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            tbka.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            tbsf.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            tbsft.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            tbrsim.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
           
            if (dataGridView1.Rows[secilen].Cells[5].Value.ToString() == "MÜDÜR")
                rbmudur.Checked = true;
            else
                rbpersonel.Checked = true;
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string yetki = "";
            MessageBox.Show("GİRDİİNİZ BİLGİLER EKSİKSİZ VE DOĞRU İSE GİRDİĞİNİZ BİLGİLER DOĞRULTUSUNDA KAYDINIZ OLUŞTURULACAKTIR VE PROGRAM YENİDEN BAŞLATILACAKTIR YENİ BİLGİLERİNİZ İLE PROGRAMA GİRİŞ YAPABİLİRSİNİZ","OTELİM BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from kullanicibilgileri where tcno='" + tbtc.Text + "'", baglanti);
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
                    label7.ForeColor = Color.Red;
                else
                    label7.ForeColor = Color.Black;

                if (tbad.Text == "")
                    label5.ForeColor = Color.Red;
                else
                    label5.ForeColor = Color.Black;

                if (tbsad.Text == "")
                    label6.ForeColor = Color.Red;
                else
                    label6.ForeColor = Color.Black;

                if (tbka.Text == "")
                    label1.ForeColor = Color.Red;
                else
                    label1.ForeColor = Color.Black;

                if (rbmudur.Checked != true && rbpersonel.Checked != true)
                    label8.ForeColor = Color.Red;
                else
                    label8.ForeColor = Color.Black;


                if (tbrsim.Text == "")
                    label4.ForeColor = Color.Red;
                else
                    label4.ForeColor = Color.Black;

                if (tbsft.Text != tbsf.Text || tbsf.Text == "" || tbsft.Text == "")
                {
                    label2.ForeColor = Color.Red;
                    label3.ForeColor = Color.Red;
                }
                else
                {
                    label3.ForeColor = Color.Black;
                    label2.ForeColor = Color.Black;
                }


                if (tbtc.Text.Length == 11 && tbtc.Text != "" && tbad.Text != "" && tbsad.Text != "" && tbka.Text != "" && tbsf.Text != "" && tbsft.Text != "" && tbsf.Text == tbsft.Text && tbrsim.Text != "" && rbmudur.Checked == true || rbpersonel.Checked == true)
                {
                    if (rbmudur.Checked == true)
                        yetki = "MÜDÜR";
                    else if (rbpersonel.Checked == true)
                        yetki = "PERSONEL";
                    try
                    {
                        baglanti.Open();
                        OleDbCommand ekle = new OleDbCommand("insert into kullanicibilgileri values ('" + tbtc.Text + "','" + tbad.Text + "','" + tbsad.Text + "','" + tbka.Text + "','" + tbsf.Text + "','" + yetki + "','" + tbrsim.Text + "') ", baglanti);
                        ekle.ExecuteNonQuery();

                        baglanti.Close();

                        MessageBox.Show("KULLANICI KAYDI GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Application.Restart();
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


        }
    }

