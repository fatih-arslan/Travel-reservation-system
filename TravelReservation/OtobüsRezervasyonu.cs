using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelReservation
{
    public partial class OtobüsRezervasyonu : Form
    {
        public OtobüsRezervasyonu()
        {
            InitializeComponent();
        }

        private void OtobüsRezervasyonu_Load(object sender, EventArgs e)
        {
            Otobus otobus = KullaniciEkrani.otobus;
            textBoxFirma.Text = otobus.Firma;
            textBoxKalkisNoktasi.Text = otobus.KalkisNoktasi;
            textBoxKalkisSaati.Text = otobus.KalkisSaati;
            textBoxVarisNoktasi.Text = otobus.VarisNoktasi;
            textBoxVarisSaati.Text = otobus.VarisSaati;
            textBoxTarih.Text = otobus.Tarih.ToString("yyyy,MM,d");
            comboBoxKoltuk.DataSource = otobus.Koltuklar;
            textBoxFiyat.Text = otobus.Fiyat.ToString();
        }

        private void linkLabelKK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBoxAd.Text = GirisEkrani.user.Ad;
            textBoxSoyad.Text = GirisEkrani.user.Soyad;
            textBoxMail.Text = GirisEkrani.user.Mail;
            textBoxTC.Text = GirisEkrani.user.TC;
        }
       
        private void buttonRezTamamla_Click(object sender, EventArgs e)
        {
            Otobus otobus = KullaniciEkrani.otobus;
            otobus.SeciliKoltuk = int.Parse(comboBoxKoltuk.SelectedItem.ToString());            
            User user = new User();
            user.UserID = GirisEkrani.user.UserID;
            user.Ad = textBoxAd.Text;
            user.Soyad = textBoxSoyad.Text;
            user.Mail = textBoxMail.Text;
            user.TC = textBoxTC.Text;
            UserManager.OtobusRezEkle(user, otobus);
            this.Close();
            MessageBox.Show("Rezervasyon tamamlandı");
            KullaniciEkrani.seyahatOtobusOtel.ulasim = otobus;
            KullaniciEkrani.seyahatOtobusCadir.ulasim = otobus;
            if (KullaniciEkrani.seyahatOtobusCadir.konaklama != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatOtobusCadir;
                SeyahatRaporu.ulasimBilgileri = UserManager.OtobusRezGetir(GirisEkrani.user);
                SeyahatRaporu.konaklamaBilgileri = UserManager.CadirRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
            else if (KullaniciEkrani.seyahatOtobusOtel.konaklama != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatOtobusOtel;
                SeyahatRaporu.ulasimBilgileri = UserManager.OtobusRezGetir(GirisEkrani.user);
                SeyahatRaporu.konaklamaBilgileri = UserManager.OtelRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
        }
    }
}
