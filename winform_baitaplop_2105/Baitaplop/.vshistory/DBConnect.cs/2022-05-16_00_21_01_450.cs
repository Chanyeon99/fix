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
        SqlDataReader rd;


        string query;
        int row_return = 0;
        public DBConnect()
        {
            this.sqlConnection = new SqlConnection(connectionString);
            connect();
        }

        private void connect()
        {
            this.sqlConnection.Open();
        }

        private void disconnect()
        {
            this.sqlConnection.Close();
        }

        public bool login(string username, string password)
        {
            query = "select * from account where user_name='" + username + "' and pass='" + password + "'";
            cmd = new SqlCommand(query, sqlConnection);
            
            rd = cmd.ExecuteReader();

            row_return = rd.RecordsAffected;
            return row_return > 0 && row_return <= 1;
        }

    }
}
