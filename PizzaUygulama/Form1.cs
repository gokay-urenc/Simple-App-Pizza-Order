using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace PizzaUygulama
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Pizza> pizzalar;
        List<Ebat> ebatlar;
        List<string> malzemeler;

        private void Form1_Load(object sender, EventArgs e)
        {
            pizzalar = new List<Pizza>()
            {
                new Pizza{Adi="Klasik",Fiyati=14 },
                new Pizza{ Adi="Karışık",Fiyati=17},
                new Pizza{ Adi="Extravaganza",Fiyati=21},
                new Pizza{ Adi="Italiano",Fiyati=20},
                new Pizza{ Adi="Turkish",Fiyati=23},
                new Pizza{ Adi="Tuna",Fiyati=18},
                new Pizza{ Adi="SeaFood",Fiyati=19},
                new Pizza{ Adi="Kastamonu",Fiyati=20},
                new Pizza{ Adi="Calypso",Fiyati=24},
                new Pizza{ Adi="Akdeniz",Fiyati=21},
                new Pizza{ Adi="Karadeniz",Fiyati=21},
            };

            ebatlar = new List<Ebat>()
            {
                new Ebat{ Adi="Küçük",FiyatCarpani=1},
                new Ebat{ Adi="Orta",FiyatCarpani=1.25m},
                new Ebat{ Adi="Büyük",FiyatCarpani=1.75m},
                new Ebat{ Adi="Maxi",FiyatCarpani=2},
            };
            malzemeler = new List<string>()
            {
                "DanaJambon","Salam","Sosis","Sucuk","Mısır","Mantar","Ançuez","Ton Balığı","Zeytin","Peynir"
            };

            foreach (var item in pizzalar)
            {
                lstPizza.Items.Add(item);
            }
            foreach (var item in ebatlar)
            {
                cmbEbat.Items.Add(item);
            }
            foreach (var item in malzemeler)
            {
                CheckBox chk = new CheckBox();
                chk.Text = item;
                flowLayoutPanel1.Controls.Add(chk);
            }
            rdbInce.Checked = true;
        }

        Ebat secilenEbat;
        Pizza secilenPizza;
        string secilenKenar;
        List<string> secilenMalzemeler;
        int Adet;
        decimal Tutar;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                secilenMalzemeler = new List<string>();
                if (cmbEbat.SelectedItem == null)
                {
                    MessageBox.Show("Ebat Seçiniz");
                }
                else
                {
                    secilenEbat = (Ebat)cmbEbat.SelectedItem;
                }
                if (lstPizza.SelectedItem == null)
                {
                    MessageBox.Show("Lütfen Pizza seçiniz");
                }
                else
                {
                    secilenPizza = (Pizza)lstPizza.SelectedItem;
                }

                if (rdbInce.Checked == true)
                {
                    secilenKenar = rdbInce.Text;
                }
                else
                {
                    secilenKenar = rdbKalin.Text;
                }

                // Seçilen malzemeleri bulabilmek için flowlayotpanel'in kontrollerinde dönüyoruz. Ve her checkbox olan kontrolün checked özelliğini kontrol ederek listeye ekliyoruz.
                foreach (var ctrl in flowLayoutPanel1.Controls)
                {
                    if (ctrl is CheckBox) // her ctrl nesnesi CheckBox tipinde mi kontrol et
                    {
                        CheckBox kutucuk = (CheckBox)ctrl; // ctrl nesnesini CheckBox tipinde dışarıya çıkart. Unboxing yap
                        if (kutucuk.Checked == true)
                        {
                            secilenMalzemeler.Add(kutucuk.Text);
                        }
                    }
                }

                Adet = Convert.ToInt32(txtAdet.Text);
                Tutar = secilenPizza.Fiyati * secilenEbat.FiyatCarpani * Adet;
                txtTutar.Text = Tutar.ToString("c2");
                button2.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Adet boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        decimal SiparisToplamTutar;
        private void button2_Click(object sender, EventArgs e)
        {
            string malzemelerMetni = "";
            foreach (var item in secilenMalzemeler)
            {
                malzemelerMetni += item + ", ";
            }
            SiparisToplamTutar += Tutar;
            lstSiparisler.Items.Add(string.Format("{0} , {1} , {2} , {3} : {4} x {5} = {6:c2}", secilenEbat, secilenPizza, secilenKenar, malzemelerMetni, Adet, secilenEbat.FiyatCarpani * secilenPizza.Fiyati, Tutar));
            lblToplamTutar.Text = SiparisToplamTutar.ToString("c2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Toplam " + lstSiparisler.Items.Count + " adet siparişiniz alındı.\n" + SiparisToplamTutar.ToString("c2") + " tutarındadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}