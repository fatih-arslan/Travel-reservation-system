using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public interface Ulasim
    {
        string KalkisNoktasi { get; set; }
        string VarisNoktasi { get; set; }
        DateTime Tarih { get; set; }
        string KalkisSaati { get; set; }
        string VarisSaati { get; set; }
        int Fiyat { get; set; }

    }
}
