using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace UsageDetails
{
    class LINQFunctions : DBFunctions
    {
        
        public override List<string> retrieveData(string mname, int year, int usage)
        {
            List<string> lst = new List<string>();
            var db= new DemoUsagePatternsEntities();
            var query = from p in db.people  join w in db.water_usage  on p.person_id equals w.person_id join m in db.months on w.month_id equals m.month_id group new { w.usage } by new { w.person_id, p.person_name , m.month_name , m.year } into g where g.Key.month_name  == "mname" && g.Key.year == year && g.Sum(w => w.usage)>usage select new {pid=g.Key.person_id,name=g.Key.person_name,year=g.Key.year,mname=g.Key.month_name ,usage=g.Sum(w=>w.usage)};
            foreach (var row in query)
            {
                  lst.Add(row.name);
            }
                
               return lst;
        }    
    }

}
