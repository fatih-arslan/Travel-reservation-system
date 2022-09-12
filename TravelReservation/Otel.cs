using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Otel : Konaklama
    {
        public int OtelID { get; set; }
        public string OtelAdi { get; set; }
        public string Sehir { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public double ToplamFiyat { get; set; }
        public int SeciliOda { get; set; }
        public List<int> Odalar 
        {
            get
            {
                return OdaBilgisiGetir();
            }
            set
            {
                Odalar = OdaBilgisiGetir();
            }
        }

        public List<int> OdaBilgisiGetir()
        {
            SqlCommand command1 = new SqlCommand("Select * from OtelOdaları where OtelAdı = @OtelAdı", SqlManager.connection);
            command1.Parameters.AddWithValue("@OtelAdı", this.OtelAdi);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<int> odalar = new List<int>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                odalar.Add(int.Parse(dt.Rows[i]["OdaNumarası"].ToString()));
            }
            return odalar;
        }
    }
}
