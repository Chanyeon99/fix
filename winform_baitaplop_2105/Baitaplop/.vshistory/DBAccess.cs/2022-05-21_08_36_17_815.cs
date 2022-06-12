using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitaplop
{
    public class DBAccess
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["btl"].ConnectionString;

        static SqlConnection sqlConnection { get; set; }
        SqlCommand cmd { get; set; }
        SqlDataReader reader { get; set; }

        string query;

        ConnectionState isOpen = ConnectionState.Open;

        public DBAccess()
        {
            if(sqlConnection == null)
            {
                sqlConnection = new SqlConnection(connectionString);
                connect();
            }
        }

        public void connect()
        {
            if(sqlConnection.State != isOpen)
                sqlConnection.Open();
            else
            {
                disconnect();
                connect();
            }
        }

        public static void disconnect()
        {
            sqlConnection.Close();
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
                cmd = new SqlCommand(query, sqlConnection);
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

        public static SqlConnection KetNoi()
        {
            sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }

        public static DataTable LayDuLieu(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, KetNoi());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void GanNguonDataGridView(DataGridView dgName, string sql)
        {
            dgName.DataSource = LayDuLieu(sql);
        }

    }
}
