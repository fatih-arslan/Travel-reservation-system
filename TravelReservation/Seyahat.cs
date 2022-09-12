using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class Seyahat
    {
        public AbstractSeyahatFactory SeyahatFactory;
        public Ulasim ulasim;
        public Konaklama konaklama;
        public Seyahat(AbstractSeyahatFactory abstractSeyahatFactory)
        {
            SeyahatFactory = abstractSeyahatFactory;
        }        
    }
}
