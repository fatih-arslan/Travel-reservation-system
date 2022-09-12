using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public abstract class AbstractSeyahatFactory
    {
        public abstract DataTable UlasimBul(string sehir1, string sehir2, DateTime tarih);
        public abstract DataTable KonaklamaBul(string sehir, DateTime gidisTarihi, DateTime donusTarihi);
    }
}
