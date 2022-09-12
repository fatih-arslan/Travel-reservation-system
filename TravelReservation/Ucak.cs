using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Ucak : Ulasim
    {
        public int UcusID { get; set; }
        public string Firma { get; set; }
        public string KalkisNoktasi { get; set; }
        public string VarisNoktasi { get; set; }
        public DateTime Tarih { get; set; }
        public string KalkisSaati { get; set; }
        public string VarisSaati { get; set; }
        public int Fiyat { get; set; }
    }
}
