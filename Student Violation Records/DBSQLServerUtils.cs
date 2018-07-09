using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student_Violation_Records
{
    class DBSQLServerUtils
    {
        public static SqlConnection
                 GetDBConnection(string datasource, string database)
        {
            //Data Source=ADMINRG-S0R6T5U\SQLEXPRESS;Initial Catalog=studentDB;Integrated Security=True
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
