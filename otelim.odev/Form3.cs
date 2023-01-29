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
    public partial class Form3 : Form
    {
       
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\otelim.mdb");
        public Form3()
        {
            InitializeComponent();
        }
        public static string btn1, btnn2, btnn3, btnn4, kt;

        int x, bir, iki, uc, dort,kat;

        private void remove()
        {
            int x = panel1.Controls.Count;
          for (int i = 0; i < x; i++)
           {
               panel1.Controls.Remove(panel1.Controls[0]);
           }
        }

        public void odadurumu()
        {
            int dolu = 0;
            int bos = 0;
            int rezerve = 0;
            int yaridolu=0;
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select *from odalar", baglanti);
            OleDbDataReader ole = cmd.ExecuteReader();
           
            while (ole.Read()) 
            {
              
              
                    foreach (Control oda in panel1.Controls)
                    {
                        if (oda is Button)
                        {


                       if (ole["odano"].ToString() == oda.Text && ole["durumu"].ToString() == "boş") 
                        {
                            oda.BackColor = Color.Green;
                            bos++;
                        }

                      if (ole["odano"].ToString() == oda.Text && ole["durumu"].ToString() == "dolu"&&ole["yataksayisi"].ToString()==ole["doluyatak"].ToString())
                        {
                            oda.BackColor = Color.Gray;
                            dolu++;
                        }

                        if (ole["odano"].ToString() == oda.Text && ole["durumu"].ToString() == "rezerve")
                        {
                            oda.BackColor = Color.Beige;
                            rezerve++;
                        }

                        if (ole["odano"].ToString() == oda.Text && int.Parse(ole["doluyatak"].ToString()) >= 1 && ole["yataksayisi"].ToString() != ole["doluyatak"].ToString())
                        {
                            oda.BackColor = Color.Orange;
                            yaridolu++;
                            
                        }
                        }
                 }
             
         }
            baglanti.Close();
            label6.Text = bos.ToString();
            label7.Text = dolu.ToString();
            label8.Text = rezerve.ToString();
            label16.Text=yaridolu.ToString();
            
     }

      
   
      


       private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from odagurup where kat='" + textBox1.Text + "'", baglanti);
            OleDbDataReader ko = slctsorgu.ExecuteReader();
            while (ko.Read())
            {
                textBox2.Text = ko.GetValue(1).ToString();
                textBox3.Text = ko.GetValue(2).ToString();
                textBox4.Text = ko.GetValue(3).ToString();
                textBox5.Text = ko.GetValue(4).ToString();
                textBox6.Text = ko.GetValue(5).ToString();
                break;
            }

            baglanti.Close();

            if (textBox1.Text == "")
            {

                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            textBox1.Text = numericUpDown1.Value.ToString();
        }
      
        
        

        private void Form3_Load(object sender, EventArgs e)
       {
           baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("select * from kullanicibilgileri where kullaniciadi='"+Form1.kullaniciadi+"'",baglanti);
            OleDbDataReader bilgi = cmd.ExecuteReader();
            while (bilgi.Read())
            {
                label5.Text = Form1.ad.ToString()+" "+ Form1.soyad.ToString();
                pictureBox1.ImageLocation = Form1.resim.ToString();
            }
            baglanti.Close();
            textBox1.Text = numericUpDown1.Value.ToString();
            textBox1.Focus();
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select *from otelbilgileri where oteladi", baglanti);
            OleDbDataReader ko = slctsorgu.ExecuteReader();
            while (ko.Read())
            {
                textBox7.Text = ko.GetValue(0).ToString();
               textBox8.Text = ko.GetValue(2).ToString();
               
                break;
            }
            baglanti.Close();
            x = int.Parse(textBox8.Text);
            numericUpDown1.Maximum = x;
            numericUpDown1_ValueChanged(sender, e);
            label1.Text = textBox7.Text;
            
            
        }

        public void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {   
            remove();
            textBox1.Text = numericUpDown1.Value.ToString();
            bir = int.Parse(textBox2.Text);
            iki = int.Parse(textBox3.Text);
            uc = int.Parse(textBox4.Text);
            dort = int.Parse(textBox5.Text);
            kat = int.Parse(textBox1.Text);
            label12.Text = textBox6.Text;
           
  ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            for (int i = 1; i <= bir; i++)
            {
                Button btn = new Button();
                btn.Text = "ODA-" +kat+"1"+ i;
                btn.Name = "ODA" + i;
                btn.BackColor = Color.Red;
                btn.Size = new Size(100, 80);
                btn.Location = new Point(100 * i, 70);
                btn.Click += btn_Click;
                panel1.Controls.Add(btn);
                
               
                
            }

            for (int i = 1; i <= iki; i++)
            {
                Button btn2 = new Button();
                btn2.Text = "ODA-"+kat+"2" + i;
                btn2.Name = "ODA" + i.ToString();
                btn2.BackColor = Color.Red;
                btn2.Size = new Size(100, 80);
                btn2.Location = new Point(100 * i, 155);
                btn2.Click += btn2_Click;
                panel1.Controls.Add(btn2);
               
            }

            for (int i = 1; i <= uc; i++)
            {
                Button btn3 = new Button();
                btn3.Text = "ODA-" +kat+"3"+ i;
                btn3.Name = "ODA" + i;
                btn3.BackColor = Color.Red;
                btn3.Size = new Size(100, 80);
                btn3.Location = new Point(100 * i, 240);
                btn3.Click += btn3_Click;
                panel1.Controls.Add(btn3);

            }

            for (int i = 1; i <= dort; i++)
            {
                Button btn4 = new Button();
                btn4.Text = "ODA-"+ kat+"4"+ i;
                btn4.Name = "ODA" + i;
                btn4.BackColor = Color.Red;
                btn4.Size = new Size(100, 80);
                btn4.Location = new Point(100 * i, 330);
                btn4.Click += btn4_Click;
                panel1.Controls.Add(btn4);

            }
            odadurumu();
            Label lbl = new Label();
            lbl.Text = "1 KİŞİLİK ODALAR";
            lbl.ForeColor = Color.Red;
            lbl.BackColor = Color.White;
            lbl.Location = new Point(1, 100);
            panel1.Controls.Add(lbl);

            Label lbl1 = new Label();
            lbl1.Text = "2 KİŞİLİK ODALAR";
            lbl1.ForeColor = Color.Red;
            lbl1.BackColor = Color.White;
            lbl1.Location = new Point(1, 185);
            panel1.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Text = "3 KİŞİLİK ODALAR";
            lbl2.ForeColor = Color.Red;
            lbl2.BackColor = Color.White;
            lbl2.Location = new Point(1, 270);
            panel1.Controls.Add(lbl2);

            Label lbl3 = new Label();
            lbl3.Text = "4 KİŞİLİK ODALAR";
            lbl3.BackColor = Color.White;
            lbl3.ForeColor = Color.Red;
            lbl3.Location = new Point(0, 360);
            panel1.Controls.Add(lbl3);




           
           

            
        }

        void btn_Click(object sender, EventArgs e)
        {
            
            int ks=1;
                Button btn = (Button)sender;
                Form6 frm6 = new Form6();
                frm6.Show();
                frm6.tboda.Text = btn.Text;
                frm6.tbkat.Text = numericUpDown1.Value.ToString();
                frm6.tbk.Text = ks.ToString(); 
              
        }
        void btn2_Click(object sender, EventArgs e)
        {
            int ks = 2;
                Button btn2 = (Button)sender;
                Form6 frm6 = new Form6();
                frm6.Show();
                frm6.tboda.Text = btn2.Text;
                frm6.tbkat.Text = numericUpDown1.Value.ToString();
                frm6.tbk.Text = ks.ToString();
        }
        void btn3_Click(object sender, EventArgs e)
        {

            int ks = 3;
                Button btn3 = (Button)sender;
                Form6 frm6 = new Form6();
                frm6.Show();
                frm6.tboda.Text = btn3.Text;
                frm6.tbkat.Text = numericUpDown1.Value.ToString();
                frm6.tbk.Text = ks.ToString();
        }
        void btn4_Click(object sender, EventArgs e)
        {    
            int ks = 4;
               Button btn4 = (Button)sender; 
               Form6 frm6 = new Form6();
               frm6.Show();
               frm6.tboda.Text = btn4.Text;
               frm6.tbkat.Text = numericUpDown1.Value.ToString();
               frm6.tbk.Text = ks.ToString();
      
        }

        private void katkayıt_Click(object sender, EventArgs e)
        {
            
            string durum = "boş";
            string doluyatak="0";
            bool kayitkontrol = false;
            baglanti.Open();
            OleDbCommand slctsorgu = new OleDbCommand("select * from odalar where kat='" + kat + "'", baglanti);
            OleDbDataReader kytokuma = slctsorgu.ExecuteReader();

            while (kytokuma.Read())
            {
                kayitkontrol = true;
                break;

            }
            baglanti.Close();

            if (kayitkontrol == false)
            {
                try
                {
                    for (int i = 1; i <= bir; i++)
                    {
                        Button btn = new Button();
                        btn.Text = "ODA-" + kat + "1" + i;
                        baglanti.Open();
                        OleDbCommand oda = new OleDbCommand("insert into odalar values ('" + btn.Text + "','" + kat.ToString() + "','" + durum + "','"+1+"','"+doluyatak+"')", baglanti);
                        oda.ExecuteNonQuery();
                        baglanti.Close();
                    }

                    for (int i = 1; i <= iki; i++)
                    {
                        Button btn2 = new Button();
                        btn2.Text = "ODA-" + kat + "2" + i;
                        baglanti.Open();
                        OleDbCommand oda = new OleDbCommand("insert into odalar values ('" + btn2.Text + "','" + kat.ToString() + "','" + durum + "','"+2+"','"+doluyatak+"')", baglanti);
                        oda.ExecuteNonQuery();
                        baglanti.Close();
                    }

                    for (int i = 1; i <= uc; i++)
                    {
                        Button btn3 = new Button();
                        btn3.Text = "ODA-" + kat + "3" + i;
                        baglanti.Open();
                        OleDbCommand oda = new OleDbCommand("insert into odalar values ('" + btn3.Text + "','" + kat.ToString() + "','" + durum + "','"+3+"','"+doluyatak+"')", baglanti);
                        oda.ExecuteNonQuery();
                        baglanti.Close();
                    }

                    for (int i = 1; i <= dort; i++)
                    {
                        Button btn4 = new Button();
                        btn4.Text = "ODA-" + kat + "4" + i;
                        baglanti.Open();
                        OleDbCommand oda = new OleDbCommand("insert into odalar values ('" + btn4.Text + "','" + kat.ToString() + "','" + durum + "','"+4+"','"+doluyatak+"')", baglanti);
                        oda.ExecuteNonQuery();
                        baglanti.Close();
                    }
                    MessageBox.Show("KAT BİLGİLERİ KAYDI GERÇEKLEŞTİRİLDİ", "OTELİM BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                catch (Exception hatabildirimi)
                {

                    MessageBox.Show(hatabildirimi.Message, "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("BU KATTAKİ ODA KAYITLARI ZATEN YAPILMIŞ", "OTELİM HATA BİLDİRİMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            odadurumu();
        }

        private void btnkulbilg_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            odadurumu();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Show();
        }

        


        

   

       
        
    }
}
