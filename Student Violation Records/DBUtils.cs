using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student_Violation_Records
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"ASPIRE-E5\SQLEXPRESS";
            string database = "StudentViolationRecords";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }
}
