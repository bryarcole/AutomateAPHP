using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace TFSWebApplication.Repository
{
    public class DbConnectionFactory
    {
        public static IDbConnection GetDbConnection(EDbConnectionTypes dbType, string connectionString)
        {
            IDbConnection connection = null;

            switch (dbType)
            {
                case EDbConnectionTypes.Sqlite:
                    connection = new SQLiteConnection(connectionString);
                    break;
                default:
                    connection = null;
                    break;
            }

            connection.Open();
            return connection;
        }
    }

    public enum EDbConnectionTypes
    {
        Sqlite,
        Mongo,
        Xml
    }
}
