using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class SelectQuery
    {
        public void waterUsage()
        {
            using (var db = new UsagePatternsEntities())
            {
                var query = from q in db.people
                            join w in db.water_usage on q.person_id equals w.person_id
                            join x in db.months on w.month_id equals x.month_id
                            group new { w.w_usage } by new { w.person_id, x.name, x.year, q.person_name } into g
                            where g.Key.name == "January" && g.Key.year == 2012 && g.Sum(w => w.w_usage) > 200
                            select new { use = g.Sum(w => w.w_usage), per = g.Key.person_id, mon = g.Key.name, pname = g.Key.person_name };

                Console.WriteLine("PersonId\tPersonName\tMonth\tWaterUsage");
                foreach (var t in query)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t{3}", t.per, t.pname, t.mon, t.use);
                }
                Console.Read();
            }
        }
    }
}
