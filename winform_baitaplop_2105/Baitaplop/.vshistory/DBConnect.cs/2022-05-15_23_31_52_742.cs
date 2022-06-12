﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baitaplop
{
    internal class DBContext
    {
        private static string connectionString = ConfigurationManager
                                                    .ConnectionStrings["btl"].ConnectionString;

        SqlConnection sqlConnection;

        public DBContext()
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
    }
}
