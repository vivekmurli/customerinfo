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

    class SQLFunctions : DBFunctions
    {
        SQLiteConnection con;



        public SQLFunctions(string path)
        {
            con = new SQLiteConnection(path);
        }

        public override List<string> cmbboxMonth()
        {
            
            List<string> month = new List<string>();
            //SQLiteConnection conn = new SQLiteConnection(@"Data Source=E:\DemoUsagePatterns.sqlite");
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText="select DISTINCT month.month_name from month order by month.month_id";
            
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                month.Add(dr.GetString(0));
            }
            con.Close();
            return month;
        }

        public override List<string> cmbboxYear()
        {
            List<string> year = new List<string>();
            //SQLiteConnection conn = new SQLiteConnection(@"Data Source=E:\DemoUsagePatterns.sqlite");
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "select DISTINCT month.year from month order by month.month_id";
            con.Open();
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            SQLiteDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                year.Add(Convert.ToString(dr.GetInt32(0)));
            }
            con.Close();
            return year;
 
        }


        public override List<string> retrieveData(string mname, int year, int usage)
        {
            List<string> lst = new List<string>();

            string query = "SELECT water_usage.person_id, person.person_name, sum(water_usage.usage) usage, month.month_name month, month.year FROM person JOIN water_usage ON person.person_id = water_usage.person_id JOIN month ON water_usage.month_id = month.month_id GROUP BY water_usage.person_id, water_usage.month_id HAVING (month.month_name = '" + mname + "' AND month.year="+ year +" AND sum(water_usage.usage) >"+ usage+")";

            SQLiteCommand cmd = new SQLiteCommand(query, con);
            con.Open();
            SQLiteDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lst.Add(reader.GetString(1));
            }
            con.Close();
            return lst;
        }
        
    }
    
}        


    






        
