using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentInfoApp.Domains
{
    public abstract class BaseDomain
    {
        public SqlConnection SqlConnection { get; set; }
        public SqlCommand SqlCommand { get; set; }

        public BaseDomain()
        {
            this.SqlConnection = new SqlConnection(@"Data Source=LAPTOP-2GNVTV4M\SQLEXPRESS;Initial Catalog=StudentInfoDb;Integrated Security=True");
            this.SqlConnection.Open();
        }

        public void ExecuteNonQuery(string command)
        {
            SqlCommand = new SqlCommand(command, SqlConnection);
            SqlCommand.ExecuteNonQuery();
        }

        public SqlDataReader GetReader(string command)
        {
            this.SqlCommand = new SqlCommand(command, SqlConnection);
            return this.SqlCommand.ExecuteReader();
        }

        public void CloseConnection()
        {
            SqlConnection.Close();
        }
    }
}
