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

        SqlConnection sqlConnection { get; set; }
        SqlCommand cmd;

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
            else
            {
                //neu da duoc tao
                //if (this.sqlConnection.State == isConnecting)
                //{
                //    disconnect();
                //    this.sqlConnection = null;
                //}
            }
            
                
        }

        public void connect()
        {
            if (this.sqlConnection.State == isConnecting)
            {
                disconnect();
            }
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

            query = "SELECT * FROM [dbo.account] WHERE username = '" + username + "' "
                                               +"and pass = '" + password + "'";
            //Console.WriteLine(query);
            cmd = new SqlCommand(query, this.sqlConnection);
            SqlDataReader rd = cmd.ExecuteReader();
            //if(rd.Read()) isAdmin = isAdmin = rd.GetBoolean(3);
            return rd.Read();
        }

    }
}
