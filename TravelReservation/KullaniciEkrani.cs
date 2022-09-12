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
    public partial class KullaniciEkrani : Form
    {        
        public KullaniciEkrani()
        {
            InitializeComponent();
        }
        public static Seyahat Seyahat;

        public static Seyahat seyahatUcakOtel;
        public static Seyahat seyahatOtobusOtel;
        public static Seyahat seyahatUcakCadir;
        public static Seyahat seyahatOtobusCadir;

        public static Cadir cadir;
        public static Otobus otobus;
        public static Ucak ucak;
        public static Otel otel;

        DataTable otelTable;
        DataTable otobusTable;
        DataTable cadirTable;
        DataTable ucusTable;
        private void button4_Click(object sender, EventArgs e)
        {
            GirisEkrani girisEkrani = new GirisEkrani();
            this.Close();
            girisEkrani.Show();
        }

        private void buttonCikis_Click(object sender, EventArgs e)
        {
            this.Close();         
        }

        private void buttonBul_Click(object sender, EventArgs e)
        {
            string sehir1 = comboBoxNereden.Text;
            string sehir2 = comboBoxNereye.Text;
            DateTime gidisTarihi = dateTimePickerGidis.Value;
            DateTime donusTarihi = dateTimePickerDonus.Value;

            Ucak_Otel ucak_Otel = new Ucak_Otel();
            seyahatUcakOtel = new Seyahat(ucak_Otel);
            DataTable dt = seyahatUcakOtel.SeyahatFactory.KonaklamaBul(sehir1, gidisTarihi, donusTarihi); 
            dataGridViewUcakOtel1.DataSource = dt;
            panelSonuc.Visible = true;
            DataTable dt2 = seyahatUcakOtel.SeyahatFactory.UlasimBul(sehir1, sehir2, gidisTarihi);
            dataGridViewUcakOtel2.DataSource = dt2;

            Ucak_Cadir ucak_Cadir = new Ucak_Cadir();
            seyahatUcakCadir = new Seyahat(ucak_Cadir);
            DataTable dt3 = seyahatUcakCadir.SeyahatFactory.KonaklamaBul(sehir1, gidisTarihi, donusTarihi);
            dataGridViewUcakCadir1.DataSource = dt3;
            DataTable dt4 = seyahatUcakCadir.SeyahatFactory.UlasimBul(sehir1, sehir2, gidisTarihi);
            dataGridViewUcakCadir2.DataSource = dt4;

            Otobus_Otel otobus_Otel = new Otobus_Otel();
            seyahatOtobusOtel = new Seyahat(otobus_Otel);
            DataTable dt5 = seyahatOtobusOtel.SeyahatFactory.KonaklamaBul(sehir1, gidisTarihi, donusTarihi);
            dataGridViewOtobusOtel1.DataSource= dt5;
            DataTable dt6 = seyahatOtobusOtel.SeyahatFactory.UlasimBul(sehir1, sehir2, gidisTarihi);
            dataGridViewOtobusOtel2.DataSource= dt6;

            Otobus_Cadir otobus_Cadir = new Otobus_Cadir();
            seyahatOtobusCadir = new Seyahat(otobus_Cadir);
            DataTable dt7 = seyahatOtobusCadir.SeyahatFactory.KonaklamaBul(sehir1, gidisTarihi, donusTarihi);
            dataGridViewOtobusCadir1.DataSource= dt7;
            DataTable dt8 = seyahatOtobusCadir.SeyahatFactory.UlasimBul(sehir1, sehir2, gidisTarihi);
            dataGridViewOtobusCadir2.DataSource= dt8;
        }

        private void buttonUcakOtel_Click(object sender, EventArgs e)
        {
            panelUcakOtel.Visible = true;
            panelUcakCadir.Visible = false;
            panelOtobusCadir.Visible = false;
            panelOtobusOtel.Visible = false;
        }

        private void buttonUcakCadir_Click(object sender, EventArgs e)
        {
            panelUcakOtel.Visible = false;
            panelOtobusOtel.Visible=false;
            panelOtobusCadir.Visible=false;
            panelUcakCadir.Visible = true;
        }

        private void dataGridViewUcakCadir1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUcakCadirR1.Enabled = true;
        }

        private void dataGridViewUcakCadir2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUcakCadirR2.Enabled = true;
        }

        private void dataGridViewUcakOtel1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUcakOtelR1.Enabled = true;
        }

        private void dataGridViewUcakOtel2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonUcakOtelR2.Enabled = true;
        }
        
        private void buttonOtobusOtel_Click(object sender, EventArgs e)
        {
            panelOtobusOtel.Visible = true;
            panelOtobusCadir.Visible = false;
            panelUcakCadir.Visible = false;
            panelUcakOtel.Visible = false;
        }

        private void buttonOtobusCadir_Click(object sender, EventArgs e)
        {
            panelOtobusOtel.Visible = false;
            panelOtobusCadir.Visible = true;
            panelUcakCadir.Visible = false;
            panelUcakOtel.Visible = false;
        }

        private void dataGridViewOtobusOtel1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonOtobusOtel1.Enabled = true;
        }

        private void dataGridViewOtobusOtel2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonOtobusOtel2.Enabled = true;
        }

        private void dataGridViewOtobusCadir1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonOtobusCadir1.Enabled = true;
        }

        private void dataGridViewOtobusCadir2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            buttonOtobusCadir2.Enabled = true;
        }

        private void KullaniciEkrani_Load(object sender, EventArgs e)
        {
            dateTimePickerGidis.MinDate = DateTime.Today.AddDays(1);
            dateTimePickerGidis.MaxDate = DateTime.Today.AddMonths(6);
            dateTimePickerDonus.MinDate = DateTime.Today.AddDays(2);            
        }
        
        private void buttonOtobusCadir1_Click_1(object sender, EventArgs e)
        {
            int cadirID = int.Parse(dataGridViewOtobusCadir1.CurrentRow.Cells["ÇadırID"].Value.ToString());
            DateTime girisTarihi = dateTimePickerGidis.Value;
            DateTime cikisTarihi = dateTimePickerDonus.Value;
            int fiyat = int.Parse(dataGridViewOtobusCadir1.CurrentRow.Cells["Fiyat"].Value.ToString());
            double toplamFiyat = (cikisTarihi - girisTarihi).TotalDays * fiyat;
            cadir = new Cadir { CadirID = cadirID, GirisTarihi = girisTarihi, CikisTarihi = cikisTarihi, ToplamFiyat = toplamFiyat };
            
            CadirRezervasyonu c = new CadirRezervasyonu();
            c.Show();
        }

        private void buttonOtobusCadir2_Click(object sender, EventArgs e)
        {
            int seferID = int.Parse(dataGridViewOtobusCadir2.CurrentRow.Cells["SeferID"].Value.ToString());
            string firma = dataGridViewOtobusCadir2.CurrentRow.Cells["Firma"].Value.ToString();
            DateTime tarih = dateTimePickerGidis.Value;
            string kalkisNoktasi = dataGridViewOtobusCadir2.CurrentRow.Cells["KalkışNoktası"].Value.ToString();
            string varisNoktasi = dataGridViewOtobusCadir2.CurrentRow.Cells["VarışNoktası"].Value.ToString();
            string kalkisSaati = dataGridViewOtobusCadir2.CurrentRow.Cells["KalkışSaati"].Value.ToString();
            string varisSaati = dataGridViewOtobusCadir2.CurrentRow.Cells["VarışSaati"].Value.ToString();
            int fiyat = int.Parse(dataGridViewOtobusCadir2.CurrentRow.Cells["Fiyat"].Value.ToString());
            otobus = new Otobus { SeferID = seferID, Firma = firma, Tarih = tarih, KalkisNoktasi = kalkisNoktasi, VarisNoktasi= varisNoktasi, 
                VarisSaati = varisSaati, KalkisSaati = kalkisSaati, Fiyat = fiyat};
            OtobüsRezervasyonu or = new OtobüsRezervasyonu();
            or.Show();
        }

        private void buttonUcakOtelR2_Click(object sender, EventArgs e)
        {
            int ucusID = int.Parse(dataGridViewUcakOtel2.CurrentRow.Cells["UçuşID"].Value.ToString());
            string kalkisNoktasi = dataGridViewUcakOtel2.CurrentRow.Cells["KalkışNoktası"].Value.ToString();
            string varisNoktasi = dataGridViewUcakOtel2.CurrentRow.Cells["VarışNoktası"].Value.ToString();
            string kalkisSaati = dataGridViewUcakOtel2.CurrentRow.Cells["KalkışSaati"].Value.ToString();
            string varisSaati = dataGridViewUcakOtel2.CurrentRow.Cells["VarışSaati"].Value.ToString();
            DateTime tarih = DateTime.Parse(dataGridViewUcakOtel2.CurrentRow.Cells["Tarih"].Value.ToString());
            string firma = dataGridViewUcakOtel2.CurrentRow.Cells["Firma"].Value.ToString();
            int fiyat = int.Parse(dataGridViewUcakOtel2.CurrentRow.Cells["Fiyat"].Value.ToString());
            ucak = new Ucak { Firma = firma, KalkisNoktasi = kalkisNoktasi, KalkisSaati = kalkisSaati, Tarih = tarih, 
                                   UcusID = ucusID, VarisNoktasi = varisNoktasi, VarisSaati = varisSaati, Fiyat = fiyat};
            UcusRezervasyonu ur = new UcusRezervasyonu();
            ur.Show();
        }

        private void buttonOtobusOtel2_Click(object sender, EventArgs e)
        {
            int seferID = int.Parse(dataGridViewOtobusOtel2.CurrentRow.Cells["SeferID"].Value.ToString());
            string firma = dataGridViewOtobusOtel2.CurrentRow.Cells["Firma"].Value.ToString();
            DateTime tarih = dateTimePickerGidis.Value;
            string kalkisNoktasi = dataGridViewOtobusOtel2.CurrentRow.Cells["KalkışNoktası"].Value.ToString();
            string varisNoktasi = dataGridViewOtobusOtel2.CurrentRow.Cells["VarışNoktası"].Value.ToString();
            string kalkisSaati = dataGridViewOtobusOtel2.CurrentRow.Cells["KalkışSaati"].Value.ToString();
            string varisSaati = dataGridViewOtobusOtel2.CurrentRow.Cells["VarışSaati"].Value.ToString();
            int fiyat = int.Parse(dataGridViewOtobusOtel2.CurrentRow.Cells["Fiyat"].Value.ToString());
            otobus = new Otobus
            {
                SeferID = seferID,
                Firma = firma,
                Tarih = tarih,
                KalkisNoktasi = kalkisNoktasi,
                VarisNoktasi = varisNoktasi,
                VarisSaati = varisSaati,
                KalkisSaati = kalkisSaati,
                Fiyat = fiyat
            };
            OtobüsRezervasyonu or = new OtobüsRezervasyonu();
            or.Show();
        }

        private void buttonUcakCadirR2_Click(object sender, EventArgs e)
        {
            int ucusID = int.Parse(dataGridViewUcakCadir2.CurrentRow.Cells["UçuşID"].Value.ToString());
            string kalkisNoktasi = dataGridViewUcakCadir2.CurrentRow.Cells["KalkışNoktası"].Value.ToString();
            string varisNoktasi = dataGridViewUcakCadir2.CurrentRow.Cells["VarışNoktası"].Value.ToString();
            string kalkisSaati = dataGridViewUcakCadir2.CurrentRow.Cells["KalkışSaati"].Value.ToString();
            string varisSaati = dataGridViewUcakCadir2.CurrentRow.Cells["VarışSaati"].Value.ToString();
            DateTime tarih = DateTime.Parse(dataGridViewUcakCadir2.CurrentRow.Cells["Tarih"].Value.ToString());
            string firma = dataGridViewUcakCadir2.CurrentRow.Cells["Firma"].Value.ToString();
            int fiyat = int.Parse(dataGridViewUcakCadir2.CurrentRow.Cells["Fiyat"].Value.ToString());
            ucak = new Ucak
            {
                Firma = firma,
                KalkisNoktasi = kalkisNoktasi,
                KalkisSaati = kalkisSaati,
                Tarih = tarih,
                UcusID = ucusID,
                VarisNoktasi = varisNoktasi,
                VarisSaati = varisSaati,
                Fiyat = fiyat
            };
            UcusRezervasyonu ur = new UcusRezervasyonu();
            ur.Show();
        }

        private void buttonUcakCadirR1_Click(object sender, EventArgs e)
        {
            int cadirID = int.Parse(dataGridViewUcakCadir1.CurrentRow.Cells["ÇadırID"].Value.ToString());
            DateTime girisTarihi = dateTimePickerGidis.Value;
            DateTime cikisTarihi = dateTimePickerDonus.Value;
            int fiyat = int.Parse(dataGridViewUcakCadir1.CurrentRow.Cells["Fiyat"].Value.ToString());
            double toplamFiyat = (cikisTarihi - girisTarihi).TotalDays * fiyat;
            cadir = new Cadir { CadirID = cadirID, GirisTarihi = girisTarihi, CikisTarihi = cikisTarihi, ToplamFiyat = toplamFiyat };

            CadirRezervasyonu c = new CadirRezervasyonu();
            c.Show();
        }

        private void buttonOtobusOtel1_Click(object sender, EventArgs e)
        {
            string OtelAd = dataGridViewOtobusOtel1.CurrentRow.Cells["OtelAdı"].Value.ToString();
            DateTime girisTarihi = dateTimePickerGidis.Value;
            DateTime cikisTarihi = dateTimePickerDonus.Value;
            otel = new Otel { GirisTarihi = girisTarihi, CikisTarihi = cikisTarihi, OtelAdi = OtelAd };
            OtelRezervasyonu or = new OtelRezervasyonu();
            or.Show();
        }

        private void buttonUcakOtelR1_Click(object sender, EventArgs e)
        {
            string OtelAd = dataGridViewUcakOtel1.CurrentRow.Cells["OtelAdı"].Value.ToString();
            DateTime girisTarihi = dateTimePickerGidis.Value;
            DateTime cikisTarihi = dateTimePickerDonus.Value;
            otel = new Otel { GirisTarihi = girisTarihi, CikisTarihi = cikisTarihi, OtelAdi = OtelAd };
            OtelRezervasyonu or = new OtelRezervasyonu();
            or.Show();
        }

        private void buttonRez_Click(object sender, EventArgs e)
        {
            RefreshPage();          
        }

        private void buttonOtelIptal_Click(object sender, EventArgs e)
        {
            string date = dataGridViewOtelRez.CurrentRow.Cells["GirişTarihi"].Value.ToString();
            int rezKod = int.Parse(dataGridViewOtelRez.CurrentRow.Cells["RezervasyonKodu"].Value.ToString());
            UserManager.OtelRezIptalEt(rezKod);
            if(Seyahat == seyahatUcakOtel || Seyahat == seyahatOtobusOtel)
            {
                Seyahat = null;
            }
            if(seyahatUcakOtel != null)
            {
                seyahatUcakOtel.konaklama = null;
            }
            if(seyahatOtobusOtel != null)
            {
                seyahatOtobusOtel.konaklama = null;
            }            
            RefreshPage();
            MessageBox.Show("Rezervasyon iptal edildi");
            DataTable dt = UserManager.UcusRezGetir(GirisEkrani.user);
            DataTable dt2 = UserManager.OtobusRezGetir(GirisEkrani.user);
            if(dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Tarih"].ToString() == date)
                {                    
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli uçuş rezervasyonunuz da iptal edilsin mi?", "Uçuş rezervasyonu", MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.UcusRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0]["Tarih"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli otobüs rezervasyonunuz da iptal edilsin mi?", "Otobüs rezervasyonu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt2.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.OtobusRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            RefreshPage();
        }
        public void RefreshPage()
        {
            User user = GirisEkrani.user;
            otelTable = UserManager.OtelRezGetir(user);
            otobusTable = UserManager.OtobusRezGetir(user);
            cadirTable = UserManager.CadirRezGetir(user);
            ucusTable = UserManager.UcusRezGetir(user);
            dataGridViewOtelRez.DataSource = otelTable;
            dataGridViewCadirRez.DataSource = cadirTable;
            dataGridViewOtobusRez.DataSource = otobusTable;
            dataGridViewUcusRez.DataSource = ucusTable;
            panelSonuc.Visible = false;
            panelRez.Visible = true;
        }

        private void buttonCadirIptal_Click(object sender, EventArgs e)
        {
            string date = dataGridViewCadirRez.CurrentRow.Cells["GirişTarihi"].Value.ToString();
            int rezKod = int.Parse(dataGridViewCadirRez.CurrentRow.Cells["RezervasyonKodu"].Value.ToString());
            UserManager.CadirRezIptalEt(rezKod);
            if(Seyahat == seyahatOtobusCadir || Seyahat == seyahatUcakCadir)
            {
                Seyahat = null;
            }
            if(seyahatUcakCadir != null)
            {
                seyahatUcakCadir.konaklama = null;
            }
            if(seyahatOtobusCadir != null)
            {
                seyahatOtobusCadir.konaklama = null;
            }
            RefreshPage();
            MessageBox.Show("Rezervasyon iptal edildi");
            DataTable dt = UserManager.UcusRezGetir(GirisEkrani.user);
            DataTable dt2 = UserManager.OtobusRezGetir(GirisEkrani.user);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Tarih"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli uçuş rezervasyonunuz da iptal edilsin mi?", "Uçuş rezervasyonu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.UcusRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0]["Tarih"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli otobüs rezervasyonunuz da iptal edilsin mi?", "Otobüs rezervasyonu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt2.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.OtobusRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            RefreshPage();
        }

        private void buttonOtobusIptal_Click(object sender, EventArgs e)
        {
            string date = dataGridViewOtobusRez.CurrentRow.Cells["Tarih"].Value.ToString();
            int rezKod = int.Parse(dataGridViewOtobusRez.CurrentRow.Cells["RezervasyonKodu"].Value.ToString());
            UserManager.OtobusRezIptalEt(rezKod);
            if(Seyahat == seyahatOtobusCadir || Seyahat == seyahatOtobusOtel)
            {
                Seyahat = null;
            }
            if(seyahatOtobusOtel != null)
            {
                seyahatOtobusOtel.ulasim = null;
            }
            if(seyahatOtobusCadir != null)
            {
                seyahatOtobusCadir.ulasim = null;
            }
            MessageBox.Show("Rezervasyon iptal edildi");
            RefreshPage();
            DataTable dt = UserManager.OtelRezGetir(GirisEkrani.user);
            DataTable dt2 = UserManager.CadirRezGetir(GirisEkrani.user);
            if(dt.Rows.Count > 0)
            {
                if(dt.Rows[0]["GirişTarihi"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli otel rezervasyonunuz da iptal edilsin mi?", "Otel rezervasyonu",MessageBoxButtons.YesNo);
                    if(dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.OtelRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            if(dt2.Rows.Count > 0)
            {
                if(dt2.Rows[0]["GirişTarihi"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli çadır rezervasyonunuz da iptal edilsin mi?", "Çadır rezervasyonu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt2.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.CadirRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            RefreshPage();
        }

        private void buttonUcusIptal_Click(object sender, EventArgs e)
        {
            string date = dataGridViewUcusRez.CurrentRow.Cells["Tarih"].Value.ToString();
            int rezKod = int.Parse(dataGridViewUcusRez.CurrentRow.Cells["RezervasyonKodu"].Value.ToString());
            UserManager.UcusRezIptalEt(rezKod);
            if(Seyahat == seyahatUcakCadir || Seyahat == seyahatUcakOtel)
            {
                Seyahat = null;
            }
            if(seyahatUcakOtel != null)
            {
                seyahatUcakOtel.ulasim = null;
            }
            if(seyahatUcakCadir != null)
            {
                seyahatUcakCadir.ulasim = null;
            }
            RefreshPage();
            MessageBox.Show("Rezervasyon iptal edildi");
            DataTable dt = UserManager.OtelRezGetir(GirisEkrani.user);
            DataTable dt2 = UserManager.CadirRezGetir(GirisEkrani.user);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["GirişTarihi"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli otel rezervasyonunuz da iptal edilsin mi?", "Otel rezervasyonu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.OtelRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            if (dt2.Rows.Count > 0)
            {
                if (dt2.Rows[0]["GirişTarihi"].ToString() == date)
                {
                    DialogResult dialogResult = MessageBox.Show("Aynı tarihli çadır rezervasyonunuz da iptal edilsin mi?", "Çadır rezervasyonu", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        int rezKod2 = int.Parse(dt2.Rows[0]["RezervasyonKodu"].ToString());
                        UserManager.CadirRezIptalEt(rezKod2);
                        MessageBox.Show("Rezervasyon iptal edildi");
                    }
                }
            }
            RefreshPage();
        }

        private void buttonYeniRez_Click(object sender, EventArgs e)
        {
            panelRez.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SeyahatRaporu sr = new SeyahatRaporu();
            sr.Show();
        }
        
    }
}
