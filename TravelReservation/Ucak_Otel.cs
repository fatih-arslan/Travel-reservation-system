using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Ucak_Otel : AbstractSeyahatFactory
    {
        public override DataTable UlasimBul(string sehir1, string sehir2, DateTime tarih)
        {
            //throw new NotImplementedException();
            SqlCommand command1 = new SqlCommand("Select  distinct UçuşID, Firma, KalkışNoktası, VarışNoktası, Tarih, KalkışSaati, VarışSaati, Fiyat from Uçuşlar" +
                " where KalkışNoktası = @Şehir1 and VarışNoktası = @Şehir2 and Tarih = @Tarih and BoşKoltukSayısı > 0", SqlManager.connection);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.Parameters.AddWithValue("@Şehir1", sehir1);
            command1.Parameters.AddWithValue("@Şehir2", sehir2);
            command1.Parameters.AddWithValue("@Tarih", tarih);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;

        }
        public override DataTable KonaklamaBul(string sehir, DateTime gidisTarihi, DateTime donusTarihi)
        {            
            SqlCommand command1 = new SqlCommand("Select OtelAdı, Şehir from Oteller where OtelID in (select otelodaları.OtelID from OtelOdaları left join " +
                "otelRezervasyonları on OtelOdaları.OtelAdı = otelRezervasyonları.OtelAdı where OtelOdaları.OtelID in " +
                "(Select OtelID from oteller where Şehir = @Şehir) and otelRezervasyonları.OtelAdı is null or " +
                "OtelRezervasyonları.GirişTarihi not between @gidisTarihi and @donusTarihi and OtelRezervasyonları.ÇıkışTarihi " +
                "not between @gidisTarihi and @donusTarihi)", SqlManager.connection);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.Parameters.AddWithValue("@Şehir", sehir);
            command1.Parameters.AddWithValue("@gidisTarihi", gidisTarihi);
            command1.Parameters.AddWithValue("@donusTarihi", donusTarihi);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
            
        }
    }
}
