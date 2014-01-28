using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterUsageLINQ
{
    class Query
    {
        //------------LINQ Query for Inserting Records ------------------
        public void insertRecords()
        {
            
            using(var db=new WaterUsageEntities())
            {
                Random rnd = new Random();
                db.Configuration.AutoDetectChangesEnabled = false;
                for(int pid=1;pid<=1000;pid++)             //Person
                {
                    for(int mid=1;mid<=24;mid++)            //Month
                    {
                        for(int day=1;day<=30;day++)        //Day
                        {
                            wusage w=new wusage();
                            w.person_id=pid;
                            w.month_id=mid;
                            w.day = day;
                            w.w_usage=rnd.Next(1,12);
                            db.wusages.Add(w);
                        }
                    }
                    
                    if (pid % 400 == 0)
                    {
                        db.SaveChanges();
                        Console.WriteLine("\n\nCommit");
                    }
                }
                db.SaveChanges();                
            }
        }

       //-------------LINQ Query to select person with usage > 200 ---------------
        public void selectRecords()
        {
            using (var db = new WaterUsageEntities())
            {
                var records = from p in db.People
                              join w in db.wusages on p.person_id equals w.person_id
                              join m in db.months on w.month_id equals m.month_id
                              group new { w.w_usage } by new { w.person_id, p.pname, m.mname, m.year } into g
                              where g.Key.mname == "January" && g.Key.year == 2012 && g.Sum(w => w.w_usage)>200
                              select new {pid=g.Key.person_id,name=g.Key.pname,year=g.Key.year,mname=g.Key.mname,usage=g.Sum(w=>w.w_usage)};

                Console.WriteLine("PersonId || Name || Month || Year || Usage");
                foreach (var row in records)
                {
                    Console.WriteLine("{0} || {1} || {2} || {3} || {4}", row.pid, row.name, row.mname, row.year, row.usage);
                }
            }
        }

    }
}
