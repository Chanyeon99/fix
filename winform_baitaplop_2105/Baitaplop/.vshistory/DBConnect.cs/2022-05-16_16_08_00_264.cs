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
        SqlCommand cmd { get; set; }
        SqlDataReader reader { get; set; }

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
            if(this.sqlConnection.State != isOpen)
                this.sqlConnection.Open();
            else
            {
                disconnect();
                connect();
            }
        }

        public void disconnect()
        {
            this.sqlConnection.Close();
        }

        public bool isAdmin = false;

        public bool login(string username, string password)
        {
            query = "select * from account where username='" + username 
                                            + "' and pass='" + password + "'";
            try
            {
                connect();
                Console.WriteLine(query);
                cmd = new SqlCommand(query, this.sqlConnection);
                if(!reader.IsClosed)
                    reader = cmd.ExecuteReader();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read()) isAdmin = (bool)rd["isAdmin"];
                return rd.Read();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                throw new Exception("SqlException: fail to connect to SQL Server" + e.Message);
            }
            catch(Exception eg)
            {
                Console.WriteLine(eg.StackTrace);
                throw new Exception("Exception: fail to connect to SQL Server" + eg.Message);
            }
        }

    }
}
