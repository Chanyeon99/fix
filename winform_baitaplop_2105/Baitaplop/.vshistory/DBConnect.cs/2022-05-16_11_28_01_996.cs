using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaplop
{
    public class DBConnect
    {
        readonly static string connectionString = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;

        SqlConnection sqlConnection;
        SqlCommand cmd;

        string query;

        public DBConnect()
        {
            this.sqlConnection = new SqlConnection(connectionString);
        }

        private void connect()
        {
            this.sqlConnection.Open();
        }

        private void disconnect()
        {
            this.sqlConnection.Close();
        }

        public bool isAdmin = false;

        public bool login(string username, string password)
        {
            connect();

            query = "select * from account where username='" + username + "' and pass='" + password + "'";
            cmd = new SqlCommand(query, this.sqlConnection);
            SqlDataReader rd = cmd.ExecuteReader();
            isAdmin = rd.GetBoolean(3);
            return rd.Read();
        }

    }
}
