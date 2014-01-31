using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using UsageDetails;



namespace UsageDetails
{
    class DBFunctions
    {
        public virtual List<string> cmbboxMonth()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=E:\\DemoUsagePatterns.sqlite");
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "select DISTINCT month.month_name from month";
            conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            List<string> month = new List<string>();
            while (dr.Read())
            {
                month.Add(dr["mname"].ToString());
            }
            return month;
        }

        public virtual List<string> cmbboxYear()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=E:\\DemoUsagePatterns.sqlite");
            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "select DISTINCT month.year from month";
            conn.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            List<string> month = new List<string>();
            while (dr.Read())
            {
                month.Add(dr["mname"].ToString());
            }
            return month;
        }

        public virtual List<string> retrieveData(string mname, int year, int usage)
        {
            List<string> personName = new List<string>();
            return personName;
        }
    }
}
   
   
        
        




