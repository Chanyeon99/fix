using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaplop
{
    public class DBAccess
    {
        readonly string connectionString = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;

        SqlConnection sqlConnection { get; set; }
        SqlCommand cmd { get; set; }
        SqlDataReader reader { get; set; }

        string query;

        System.Data.ConnectionState isOpen = System.Data.ConnectionState.Open;

        public DBAccess()
        {
            if(this.sqlConnection == null)
            {
                this.sqlConnection = new SqlConnection(connectionString);
                connect();
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
                SqlDataReader rd = cmd.ExecuteReader();
                bool isReaderHasData = rd.Read();
                if (isReaderHasData) isAdmin = (bool)rd["isAdmin"];
                return isReaderHasData;
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
