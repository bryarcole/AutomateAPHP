using System;

namespace TFSWebApplication.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLiteDb sqLiteDb = new SQLiteDb("C:\\Database\\TestDatabase.db");
            sqLiteDb.Create();
        }
    }
}
    