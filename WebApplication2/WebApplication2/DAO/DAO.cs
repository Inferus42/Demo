using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication2.DAO
{
    public class DAO
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["ShipConnectionString"].ConnectionString;
        protected SqlConnection sql { get; set; }

        public void Connect()
        {
            sql = new SqlConnection(connectionString);
            sql.Open();
        }

        public void Disconnect()
        {
            sql.Close();
        }
    }
}