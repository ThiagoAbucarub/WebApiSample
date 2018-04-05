using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MySQL_Windows.Infra
{
    public class SQLConnection
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["SQLConnection"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(connectionString);

        public static void Connect()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public static void Disconnect()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
