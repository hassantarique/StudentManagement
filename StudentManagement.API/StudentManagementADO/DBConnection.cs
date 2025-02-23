using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.ADODAL
{
    internal static class DBConnection
    {
        public static SqlConnection GetConnection() 
        {
            string connectionString = "Server=tcp:htmlearning.database.windows.net,1433;Initial Catalog=MotorSportDev;Persist Security Info=False;User ID=htmlearningSQLServerAdmin;Password=TAJsocket@123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;  
        }
    }
}
