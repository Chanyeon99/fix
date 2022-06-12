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
        readonly string connectionString = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;

        SqlConnection sqlConnection { get; set; }
        SqlCommand cmd{ get; set; }

        string query;

        System.Data.ConnectionState isConnecting = System.Data.ConnectionState.Connecting;
        System.Data.ConnectionState isOpen = System.Data.ConnectionState.Open;
        System.Data.ConnectionState isClosed = System.Data.ConnectionState.Closed;

        public DBConnect()
        {
            if(this.sqlConnection == null)
            {
                this.sqlConnection = new SqlConnection(connectionString);
            }
        }

        public void connect()
        {
            this.sqlConnection.Open();
        }

        public void disconnect()
        {
            this.sqlConnection.Close();
        }

        public bool isAdmin = false;

        public bool login(string username, string password)
        {
            connect();

            query = "SELECT * FROM account WHERE username = '" + username + "' "
                                               +"and pass = '" + password + "'";
            //Console.WriteLine(query);
            cmd = new SqlCommand(query, this.sqlConnection);
            try
            {
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) isAdmin = isAdmin = rd.GetBoolean(3);
                return rd.Read();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw new Exception("SqlException: fail to connect to SQL Server");

            }
        }

    }
}
