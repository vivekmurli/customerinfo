using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.EntityClient;

namespace UsageDetails
{
    class LINQFunctions : DBFunctions
    {
        DemoUsagePatternsEntities db;
        public LINQFunctions(string conStr)
        {
            db = new DemoUsagePatternsEntities(conStr);
        }
        public override List<string> retrieveData(string mname, int year, int usage)
        {
            List<string> lst = new List<string>();
            var query = from p in db.water_usage
                           group p by new { p.person, p.month } into g
                           where (g.Key.month.month_name == mname && g.Key.month.year == year && g.Sum(p=>p.usage) > usage)
                           select g.Key.person.person_name;

            foreach (var row in query)
            {
                lst.Add(row);
            }
            return lst;
        } 
    }
}
