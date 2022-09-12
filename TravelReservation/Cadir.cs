using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Cadir : Konaklama
    {
        public int CadirID { get; set; }
        public string Sehir { get; set; }
        public int KisiSayisi { get; set; }
        public bool BosMu { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public double Fiyat { get; set; }
        public double ToplamFiyat { get; set; }
    }
}
