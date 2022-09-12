using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelReservation
{
    public partial class OtelRezervasyonu : Form
    {
        public OtelRezervasyonu()
        {
            InitializeComponent();
        }

        private void OtelRezervasyonu_Load(object sender, EventArgs e)
        {
            Otel otel = KullaniciEkrani.otel;
            comboBoxOda.DataSource = otel.Odalar;
            textBoxGiris.Text = otel.GirisTarihi.ToString("yyyy,MM,dd");
            textBoxCikis.Text = otel.CikisTarihi.ToString("yyyy,MM,dd");

        }

        private void comboBoxOda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Otel otel = KullaniciEkrani.otel;
            int n = int.Parse(comboBoxOda.SelectedItem.ToString());            
            SqlCommand command1 = new SqlCommand("Select Fiyat from OtelOdaları where OtelAdı = @OtelAdı and OdaNumarası = @OdaNumarası", SqlManager.connection);
            command1.Parameters.AddWithValue("@OtelAdı", otel.OtelAdi);
            command1.Parameters.AddWithValue("@OdaNumarası", n);
            SqlManager.CheckConnection(SqlManager.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);  
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            double fiyat = double.Parse(dt.Rows[0]["Fiyat"].ToString());
            double toplamFiyat = Math.Abs((otel.CikisTarihi - otel.GirisTarihi).TotalDays * fiyat);
            textBoxToplamFiyat.Text = toplamFiyat.ToString();
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
            Otel otel = KullaniciEkrani.otel;            
            otel.SeciliOda = int.Parse(comboBoxOda.SelectedItem.ToString());
            User user = new User();
            user.UserID = GirisEkrani.user.UserID;
            user.Ad = textBoxAd.Text;
            user.Soyad = textBoxSoyad.Text;
            user.Mail = textBoxMail.Text;
            user.TC = textBoxTC.Text;
            UserManager.OtelRezEkle(user, otel);
            this.Close();
            MessageBox.Show("Rezervasyon tamamlandı");
            KullaniciEkrani.seyahatOtobusOtel.konaklama = otel;
            KullaniciEkrani.seyahatUcakOtel.konaklama = otel;
            if (KullaniciEkrani.seyahatOtobusOtel.ulasim != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatOtobusOtel;
                SeyahatRaporu.konaklamaBilgileri = UserManager.OtelRezGetir(GirisEkrani.user);
                SeyahatRaporu.ulasimBilgileri = UserManager.OtobusRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
            else if (KullaniciEkrani.seyahatUcakOtel.ulasim != null)
            {
                KullaniciEkrani.Seyahat = KullaniciEkrani.seyahatOtobusOtel;
                SeyahatRaporu.konaklamaBilgileri = UserManager.OtelRezGetir(GirisEkrani.user);
                SeyahatRaporu.ulasimBilgileri = UserManager.UcusRezGetir(GirisEkrani.user);
                MessageBox.Show("Seyahatiniz oluşturuldu");
            }
        }
    }
}
