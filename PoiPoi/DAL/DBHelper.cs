using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoiPoi.DAL
{
    public class DBHelper
    {
        private static DBHelper _Instance;
        private SqlConnection cnn;

        private DBHelper()
        {
            cnn = new SqlConnection("Server=.;Database=demo2;Trusted_Connection=True");
        }

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DBHelper();
                }

                return _Instance;
            }
            private set { }
        }

        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, cnn);
            cnn.Open();
            da.Fill(dt);
            cnn.Close();
            return dt;
        }

            
    }
}
