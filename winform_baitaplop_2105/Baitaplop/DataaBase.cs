using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace Baitaplop
{
    internal class DataaBase
    {
        string connString = @"Data Source=LAPTOP-VSG9RULI\ORREY;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection sqlcon;
        SqlCommand sqlcom;
        SqlDataAdapter sqlda;
        SqlDataReader sqldr;
        DataSet ds = new DataSet();


        void ketnoi()
        {
            sqlcon = new SqlConnection(connString);
            sqlcon.Open();
        }

        void ngatketnoi()
        {
            sqlcon.Close();
        }
    }
}
