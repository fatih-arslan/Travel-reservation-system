using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Otobus : Ulasim
    {
        public int SeferID { get; set; }
        public string Firma { get; set; }
        public string KalkisNoktasi { get; set; }
        public string VarisNoktasi { get; set; }
        public DateTime Tarih { get; set; }
        public string KalkisSaati { get; set; }
        public string VarisSaati { get; set; }
        public int SeciliKoltuk { get; set; }
        public int Fiyat { get; set; }
        public List<int> Koltuklar { get
            {
                return KoltukBilgisiGetir();
            }
            set
            {
                Koltuklar = KoltukBilgisiGetir();
            } 
        }

        public List<int> KoltukBilgisiGetir()
        {
            SqlCommand command1 = new SqlCommand("Select KoltukNumarası from OtobüsKoltukları where SeferID = @SeferID and Durum = 'Boş'", SqlManager.connection);
            SqlManager.CheckConnection(SqlManager.connection);
            command1.Parameters.AddWithValue("@SeferID", this.SeferID);
            SqlDataAdapter adapter = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            List<int> koltuklar = new List<int>();
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                koltuklar.Add(int.Parse(dt.Rows[i]["KoltukNumarası"].ToString()));
            }
            return koltuklar;
        }
    }
}
