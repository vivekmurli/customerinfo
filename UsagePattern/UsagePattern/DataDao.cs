using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace UsagePattern
{
    class DataDao
    {
        SQLiteConnection sqlite_conn;
       public static SQLiteCommand sqlite_cmd;
        SQLiteTransaction sqlite_tran;
       // StopWatch sw = new StopWatch();
        

        public void createDataBase()
        {
            SQLiteConnection.CreateFile("DemoUsagePattern.sqlite");
        }
        
        public void connection()
        {
        sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\manu\\Desktop\\Folders\\internship\\DemoUsagePatterns.sqlite");
        sqlite_cmd = sqlite_conn.CreateCommand();
        }

        public void openConnection()
        {
            sqlite_conn.Open();
        }

        public void beginTransaction()
        {
            sqlite_tran = sqlite_conn.BeginTransaction();
            sqlite_cmd.Transaction = sqlite_tran;
        }

        public void commitTransaction()
        {
            sqlite_tran.Commit();
        }

        public void reader()
        {
            try
            {
                SQLiteDataReader reader = sqlite_cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetInt32(0) + " " + reader.GetString(1)+" " + reader.GetInt32(2) + " " + reader.GetString(3)+" "+ reader.GetInt32(4));

                }
                Console.Read();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public void closeConnection()
        {
            sqlite_conn.Close();
        }
    }
}
