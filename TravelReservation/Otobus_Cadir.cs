using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Otobus_Cadir : AbstractSeyahatFactory
    {
        public override DataTable UlasimBul(string sehir1,  string sehir2, DateTime tarih)
        {
            string kalkisNoktasi = sehir1 + " Otogarı";
            string varisNoktasi = sehir2 + " Otogarı";
            SqlCommand command1 = new SqlCommand("Select distinct SeferID, Firma, KalkışNoktası, VarışNoktası, Tarih, KalkışSaati, VarışSaati, Fiyat from" +
                " OtobüsSeferleri where SeferID in (Select distinct seferID from OtobüsKoltukları where Durum = 'Boş') and " +
                "KalkışNoktası = @KalkisNoktasi and VarışNoktası = @VarisNoktasi and Tarih = @Tarih", SqlManager.connection);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.Parameters.AddWithValue("@KalkisNoktasi", kalkisNoktasi);
            command1.Parameters.AddWithValue("@VarisNoktasi", varisNoktasi);
            command1.Parameters.AddWithValue("@Tarih", tarih);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public override DataTable KonaklamaBul(string sehir, DateTime gidisTarihi, DateTime donusTarihi)
        {
            SqlCommand command1 = new SqlCommand("select Çadırlar.ÇadırID, çadırlar.Şehir, çadırlar.KişiSayısı, Çadırlar.Fiyat " +
               "from Çadırlar left join ÇadırRezervasyonları on " +
               "Çadırlar.ÇadırID = ÇadırRezervasyonları.ÇadırID where Çadırlar.Şehir = @Şehir and ÇadırRezervasyonları.ÇadırID is null or " +
               "ÇadırRezervasyonları.GirişTarihi not between @gidisTarihi and @donusTarihi and ÇadırRezervasyonları.ÇıkışTarihi " +
               "not between @gidisTarihi and @donusTarihi", SqlManager.connection);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.Parameters.AddWithValue("@Şehir", sehir);
            command1.Parameters.AddWithValue("@gidisTarihi", gidisTarihi);
            command1.Parameters.AddWithValue("@donusTarihi", donusTarihi);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}
