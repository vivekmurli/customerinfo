using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace UsagePattern
{
    class SelectQuery
    {
        public void select()
        {
            String a = "January";
            try
            {
               String query = "SELECT  water_usage.person_id, person.person_name, sum(water_usage.w_usage) usage, month.name month, month.year FROM person JOIN water_usage ON person.person_id = water_usage.person_id JOIN month ON water_usage.month_id = month.month_id GROUP BY water_usage.person_id, water_usage.month_id HAVING (month.name = '"+a+"' AND month.year=2012 AND sum(water_usage.w_usage) > 200)";

               DataDao.sqlite_cmd.CommandText = query;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
