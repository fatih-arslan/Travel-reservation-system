using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public interface Konaklama
    {
        string Sehir { get; set; }
        DateTime GirisTarihi { get; set; }
        DateTime CikisTarihi { get; set; }
        double ToplamFiyat { get; set; }
    }
}
