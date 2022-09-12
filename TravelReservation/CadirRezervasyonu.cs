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
    public partial class CadirRezervasyonu : Form
    {
        public CadirRezervasyonu()
        {
            InitializeComponent();
        }

        private void CadirRezervasyonu_Load(object sender, EventArgs e)
        {
            textBoxGiris.Text = KullaniciEkrani.cadir.GirisTarihi.ToString("yyyy/MM/d");
            textBoxCikis.Text = KullaniciEkrani.cadir.CikisTarihi.ToString("yyyy/MM/d");
            textBoxToplamFiyat.Text = KullaniciEkrani.cadir.ToplamFiyat.ToString();
        }

        private void linkLabelKK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User user = GirisEkrani.user;
            textBoxAd.Text = user.Ad;
            textBoxSoyad.Text = user.Soyad;
            textBoxMail.Text = user.Mail;
            textBoxTC.Text = user.TC;
        }
        
        private void buttonRezTamamla_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserID = GirisEkrani.user.UserID;
            user.Ad = textBoxAd.Text;
            user.Soyad = textBoxSoyad.Text;
            user.Mail = textBoxMail.Text;
            user.TC = textBoxTC.Text;
            Cadir cadir = KullaniciEkrani.cadir;            
            UserManager.CadirRezEkle(user, cadir);
            this.Close();
            MessageBox.Show("Rezervasyon tamamlandı");
            KullaniciEkrani.seyahatUcakCadir.konaklama = cadir;
            KullaniciEkrani.seyahatOtobusCadir.konaklama = cadir;
            if (KullaniciEkrani.seyahatUcakCadir.ulasim != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatUcakCadir;
                SeyahatRaporu.konaklamaBilgileri = UserManager.CadirRezGetir(GirisEkrani.user);
                SeyahatRaporu.ulasimBilgileri = UserManager.UcusRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
            else if (KullaniciEkrani.seyahatOtobusCadir.ulasim != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatOtobusCadir;
                SeyahatRaporu.konaklamaBilgileri = UserManager.CadirRezGetir(GirisEkrani.user);
                SeyahatRaporu.ulasimBilgileri = UserManager.OtobusRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
        }
    }
}
