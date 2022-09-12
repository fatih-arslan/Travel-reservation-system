using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class UserManager
    {
        public static void AddUser(User user)
        {
            SqlCommand command1 = new SqlCommand("insert into Kullanıcılar values (@Mail, @Ad, @Soyad, @Sifre, @TC)", SqlManager.connection);
            command1.Parameters.AddWithValue("Mail", user.Mail);
            command1.Parameters.AddWithValue("Ad", user.Ad);
            command1.Parameters.AddWithValue("Soyad", user.Soyad);
            command1.Parameters.AddWithValue("Sifre", user.Sifre);
            command1.Parameters.AddWithValue("TC", user.TC);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();
        }

        public static User GetUserByMail(string mail)
        {
            User user = new User();
            SqlCommand command1 = new SqlCommand("Select * from Kullanıcılar where Mail = @Mail", SqlManager.connection);
            command1.Parameters.AddWithValue("@Mail", mail);
            SqlManager.connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            SqlManager.connection.Close();
            if(dt.Rows.Count > 0)
            {
                user.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                user.Mail = mail;
                user.Ad = dt.Rows[0]["Ad"].ToString();
                user.Soyad = dt.Rows[0]["Soyad"].ToString();
                user.Sifre = dt.Rows[0]["Şifre"].ToString();
                user.TC = dt.Rows[0]["TC"].ToString();
            }
            else
            {
                user = null;
            }
            return user;
        }

        public static void CadirRezEkle(User user, Cadir cadir)
        {
            SqlCommand command1 = new SqlCommand("insert into ÇadırRezervasyonları values (@ÇadırID, @UserID, @Ad, @Soyad, @TC, @Giriş, @Çıkış, @ToplamFiyat, 'Aktif')", SqlManager.connection);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            command1.Parameters.AddWithValue("@ÇadırID", cadir.CadirID);
            command1.Parameters.AddWithValue("@Ad", user.Ad);
            command1.Parameters.AddWithValue("@Soyad", user.Soyad);
            command1.Parameters.AddWithValue("@TC", user.Soyad);
            command1.Parameters.AddWithValue("@Giriş", cadir.GirisTarihi);
            command1.Parameters.AddWithValue("@Çıkış", cadir.CikisTarihi);
            command1.Parameters.AddWithValue("@ToplamFiyat", cadir.ToplamFiyat);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();
        }

        public static void OtobusRezEkle(User user, Otobus otobus)
        {
            SqlCommand command1 = new SqlCommand("insert into OtobüsRezervasyonları values (@SeferID, @UserID, @Ad, @Soyad, @Tarih, @KalkisNoktasi, " +
                "@VarisNoktasi, @KalkisSaati, @VarisSaati, @KoltukNumarası, 'Aktif')", SqlManager.connection);
            command1.Parameters.AddWithValue("@SeferID", otobus.SeferID);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            command1.Parameters.AddWithValue("@Ad", user.Ad);
            command1.Parameters.AddWithValue("@Soyad", user.Soyad);
            command1.Parameters.AddWithValue("@Tarih", otobus.Tarih);
            command1.Parameters.AddWithValue("@KalkisNoktasi", otobus.KalkisNoktasi);
            command1.Parameters.AddWithValue("@VarisNoktasi", otobus.VarisNoktasi);
            command1.Parameters.AddWithValue("@KalkisSaati", otobus.KalkisSaati);
            command1.Parameters.AddWithValue("@VarisSaati", otobus.VarisSaati);
            command1.Parameters.AddWithValue("@KoltukNumarası", otobus.SeciliKoltuk);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("Update OtobüsKoltukları set Durum = 'Dolu' where SeferID = @SeferID and " +
                "KoltukNumarası = @KoltukNumarası", SqlManager.connection);
            command2.Parameters.AddWithValue("@SeferID", otobus.SeferID);
            command2.Parameters.AddWithValue("@KoltukNumarası", otobus.SeciliKoltuk);

        }

        public static void UcusRezEkle(User user, Ucak ucak)
        {
            SqlCommand command1 = new SqlCommand("insert into UçuşRezervasyonları values (@UcusID, @UserID, @Ad, @Soyad, @Tarih, @KalkisNoktasi, " +
                "@VarisNoktasi, @KalkisSaati, @VarisSaati, 'Aktif')",SqlManager.connection);
            command1.Parameters.AddWithValue("@UcusID", ucak.UcusID);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            command1.Parameters.AddWithValue("@Ad", user.Ad);
            command1.Parameters.AddWithValue("@Soyad", user.Soyad);
            command1.Parameters.AddWithValue("@Tarih", ucak.Tarih);
            command1.Parameters.AddWithValue("@KalkisNoktasi", ucak.KalkisNoktasi);
            command1.Parameters.AddWithValue("@VarisNoktasi", ucak.VarisNoktasi);
            command1.Parameters.AddWithValue("@KalkisSaati", ucak.KalkisSaati);
            command1.Parameters.AddWithValue("@VarisSaati", ucak.VarisSaati);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("Update Uçuşlar set BoşKoltukSayısı = BoşKoltukSayısı -1 where UçuşID = @UcusID", SqlManager.connection);
            command2.Parameters.AddWithValue("@UcusID", ucak.UcusID);
            SqlManager.CheckConnection(SqlManager.connection);
            command2.ExecuteNonQuery();
        }

        public static void OtelRezEkle(User user, Otel otel)
        {
            SqlCommand command1 = new SqlCommand("insert into OtelRezervasyonları values (@UserID, @Ad, @Soyad, @OtelAdı, @OdaNumarası, @GirisTarihi, @CikisTarihi, 'Aktif')", SqlManager.connection);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            command1.Parameters.AddWithValue("@Ad", user.Ad);
            command1.Parameters.AddWithValue("@Soyad", user.Soyad);
            command1.Parameters.AddWithValue("@OtelAdı", otel.OtelAdi);
            command1.Parameters.AddWithValue("@OdaNumarası", otel.SeciliOda);
            command1.Parameters.AddWithValue("@GirisTarihi", otel.GirisTarihi);
            command1.Parameters.AddWithValue("@CikisTarihi", otel.CikisTarihi);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();            
        }

        public static DataTable OtelRezGetir(User user)
        {
            SqlCommand command1 = new SqlCommand("Select RezervasyonKodu, Ad, Soyad, OtelAdı, OdaNumarası, GirişTarihi, ÇıkışTarihi, Durum " +
                "from OtelRezervasyonları where UserID = @UserID", SqlManager.connection);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            SqlManager.CheckConnection(SqlManager.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable OtobusRezGetir(User user)
        {
            SqlCommand command1 = new SqlCommand("Select RezervasyonKodu, Ad, Soyad, Tarih, KalkışNoktası, VarışNoktası, KalkışSaati, VarışSaati, KoltukNumarası, Durum " +
                "from OtobüsRezervasyonları where UserID = @UserID", SqlManager.connection);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            SqlManager.CheckConnection(SqlManager.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable UcusRezGetir(User user)
        {
            SqlCommand command1 = new SqlCommand("Select RezervasyonKodu, Ad, Soyad, Tarih, KalkışNoktası, VarışNoktası, KalkışSaati, VarışSaati, Durum " +
                "from UçuşRezervasyonları where UserID = @UserID", SqlManager.connection);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static DataTable CadirRezGetir(User user)
        {
            SqlCommand command1 = new SqlCommand("Select RezervasyonKodu, Ad, Soyad, TC, GirişTarihi, ÇıkışTarihi, durum from ÇadırRezervasyonları where UserID = @UserID", SqlManager.connection);
            command1.Parameters.AddWithValue("@UserID", user.UserID);
            SqlManager.CheckConnection(SqlManager.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static void OtelRezIptalEt(int rezKod)
        {
            SqlCommand command1 = new SqlCommand("Update OtelRezervasyonları set Durum = 'İptal edildi' where RezervasyonKodu = @rezKod ", SqlManager.connection);
            command1.Parameters.AddWithValue("@rezKod", rezKod);
            SqlManager.CheckConnection (SqlManager.connection);
            command1.ExecuteNonQuery();
        }

        public static void CadirRezIptalEt(int rezKod)
        {
            SqlCommand command1 = new SqlCommand("Update ÇadırRezervasyonları set Durum = 'İptal edildi' where RezervasyonKodu = @rezKod ", SqlManager.connection);
            command1.Parameters.AddWithValue("@rezKod", rezKod);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();
        }

        public static void OtobusRezIptalEt(int rezKod)
        {
            SqlCommand command1 = new SqlCommand("Update OtobüsRezervasyonları set Durum = 'İptal edildi' where RezervasyonKodu = @rezKod ", SqlManager.connection);
            command1.Parameters.AddWithValue("@rezKod", rezKod);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();
        }

        public static void UcusRezIptalEt(int rezKod)
        {
            SqlCommand command1 = new SqlCommand("Update UçuşRezervasyonları set Durum = 'İptal edildi' where RezervasyonKodu = @rezKod ", SqlManager.connection);
            command1.Parameters.AddWithValue("@rezKod", rezKod);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.ExecuteNonQuery();
        }
       
    }
}
