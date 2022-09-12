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
    public partial class UcusRezervasyonu : Form
    {
        public UcusRezervasyonu()
        {
            InitializeComponent();
        }

        private void UcusRezervasyonu_Load(object sender, EventArgs e)
        {
            Ucak ucak = KullaniciEkrani.ucak;
            textBoxFirma.Text = ucak.Firma;
            textBoxKalkisNoktasi.Text = ucak.KalkisNoktasi;
            textBoxKalkisSaati.Text = ucak.KalkisSaati;
            textBoxVarisNoktasi.Text = ucak.VarisNoktasi;
            textBoxVarisSaati.Text = ucak.VarisSaati;
            textBoxTarih.Text = ucak.Tarih.ToString("yyyy,MM,d");
            textBoxFiyat.Text = ucak.Fiyat.ToString();
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
            Ucak ucak = KullaniciEkrani.ucak;
            User user = new User();
            user.UserID = GirisEkrani.user.UserID;
            user.Ad = textBoxAd.Text;
            user.Soyad = textBoxSoyad.Text;
            user.Mail = textBoxMail.Text;
            user.TC = textBoxTC.Text;           
            UserManager.UcusRezEkle(user, ucak);
            this.Close();
            MessageBox.Show("Rezervasyon tamamlandı");
            KullaniciEkrani.seyahatUcakCadir.ulasim = ucak;
            KullaniciEkrani.seyahatUcakOtel.ulasim = ucak;
            if (KullaniciEkrani.seyahatUcakCadir.konaklama != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatUcakCadir;
                SeyahatRaporu.ulasimBilgileri = UserManager.UcusRezGetir(GirisEkrani.user);
                SeyahatRaporu.konaklamaBilgileri = UserManager.CadirRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
            else if (KullaniciEkrani.seyahatUcakOtel.konaklama != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatUcakOtel;
                SeyahatRaporu.ulasimBilgileri = UserManager.UcusRezGetir(GirisEkrani.user);
                SeyahatRaporu.konaklamaBilgileri = UserManager.OtelRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
        }
    }
}
