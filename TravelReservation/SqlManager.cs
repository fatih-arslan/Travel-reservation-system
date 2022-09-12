using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelReservation
{
    public class SqlManager
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-SUPB5RF;Initial Catalog=ReservationAppDataBase;Integrated Security=True");
        public static void CheckConnection(SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
    }
}
