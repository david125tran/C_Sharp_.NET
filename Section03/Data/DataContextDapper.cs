using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Section03.Data
{
    public class DataContextDapper
    {
        // private IConfiguration _config;
        private string _connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true";
        public DataContextDapper(IConfiguration config)
        {
            // _config = config;
            _connectionString = config.GetConnectionString("DefaultConnection") + "";
        }

        // We use a <T> data type because we want a generic data type because we will be 
        // passing in multiple data types & so we want this field to be dynamic.  
        // We also put a <T> next to the method "Load Data" because the data type is yet 
        // to be defined.  When we call the method (& pass in our argument) is when we will 
        // specifiy the data type.  
        public IEnumerable <T> LoadData <T> (string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // ".Query" will return a full list of the object
            return dbConnection.Query<T>(sql);
        }

        public T LoadDataSingle <T> (string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // ".Query" will return a full list of the object
            return dbConnection.QuerySingle<T>(sql);
        }

        public bool ExecuteSql (string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // ".Execute" will return an integer for the number of rows affected
            return (dbConnection.Execute(sql) > 0); // If a row was affected, it returns 'true'
        }

        public int ExecuteSqlWithRowCount (string sql)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            // ".Execute" will return an integer for the number of rows affected
            return dbConnection.Execute(sql);
        }

    }
}

// Mac & OS user JSON connection string:
// {
//     "ConnectionStrings": {
//     "DefaultConnection": "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=false;User Id=xxxxx;Password=xxxxx;"
//      }
// }