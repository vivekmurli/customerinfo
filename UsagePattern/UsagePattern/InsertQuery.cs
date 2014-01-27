using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace UsagePattern
{
    class InsertQuery
    {
        int person_id = 1, day = 1, month_id = 1;
        Random rnd = new Random();
        
        
       // SQLiteConnection sqlite_conn;
        

        
        
        SQLiteParameter p1,p2,p3,p4;

        String[] month ={"January", "February", "March", "April","May","June","July","Auugust","September","October","November","December"};
        String[] city_name={"Vashi","Sanpada","Nerul"};
        String[] state = { "Maharashtra" };

        public void insertmonth()
        {
            //DataDao.sqlite_cmd = sqlite_conn.CreateCommand();
           DataDao.sqlite_cmd.CommandText = "insert into month(month_id,month_name,year) values (@month_id,@month_name,@year)";
            p1 = new SQLiteParameter("@month_id", DbType.Int32);
            p2 = new SQLiteParameter("@month_name",DbType.String);
            p3 = new SQLiteParameter("@year",DbType.Int32);

            DataDao.sqlite_cmd.Parameters.Add(p1);
            DataDao.sqlite_cmd.Parameters.Add(p2);
            DataDao.sqlite_cmd.Parameters.Add(p3);

            //for(month_id=1;month_id<=24;month_id++)
            for (int i = 1; i <= 12; i++)
            {
                p1.Value = i;
                p2.Value = month[i-1];
                p3.Value = 2012;
                DataDao.sqlite_cmd.ExecuteNonQuery();

            }

            
        }

        public void insertCity()
        {
            try
            {
                //DataDao.sqlite_cmd = sqlite_conn.CreateCommand();
                DataDao.sqlite_cmd.CommandText = "insert into city(city_id,city_name,state) values (@city_id,@city_name,@state)";
                p1 = new SQLiteParameter("@city_id", DbType.Int32);
                p2 = new SQLiteParameter("@city_name", DbType.String);
                p3 = new SQLiteParameter("@state", DbType.String);

                DataDao.sqlite_cmd.Parameters.Add(p1);
                DataDao.sqlite_cmd.Parameters.Add(p2);
                DataDao.sqlite_cmd.Parameters.Add(p3);

                for (int m = 1; m <= 3; m++)
                {
                   // for (int n = m; n <= m-1; n++)
                   // {
                       p1.Value = m;
                       p2.Value = city_name[m-1];
                       p3.Value = state[0];
                       DataDao.sqlite_cmd.ExecuteNonQuery();
                   // }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("SQLite Exception : {0}", ex.Message);

            }

            
        }


        public void insertWaterUsage()
        {
            DataDao.sqlite_cmd.CommandText = "insert into water_usage(person_id,day,month_id, usage) values(@person_id,@day,@month_id,@usage)";
            data();
        }

        public void insertElectricityUsage()
        {
            DataDao.sqlite_cmd.CommandText = "insert into electricity_usage(person_id,day,month_id, usage) values(@person_id,@day,@month_id,@usage)";
            data();
        }
        
        
        public void data()
            {
            p1 = new SQLiteParameter("@person_id", DbType.Int32);
            p2 = new SQLiteParameter("@day", DbType.Int32);
            p3 = new SQLiteParameter("@month_id", DbType.Int32);
            p4 = new SQLiteParameter("@usage", DbType.Int32);
           // SQLiteParameter p4 = new SQLiteParameter("@w_usage", DbType.Int32);


            DataDao.sqlite_cmd.Parameters.Add(p1);
            DataDao.sqlite_cmd.Parameters.Add(p2);
            DataDao.sqlite_cmd.Parameters.Add(p3);
            DataDao.sqlite_cmd.Parameters.Add(p4);

            //for (person_id = 1; person_id <= 10000; person_id++)
            for (person_id = 1; person_id <= 10; person_id++)
            {
               // for (month_id = 1; month_id <= 24; month_id++)
                 for (month_id = 1; month_id <= 12; month_id++)
                {
                    for (day = 1; day <= 30; day++)
                    // for (day = 1; day <= 10; day++)
                    {
                        int usage = rnd.Next(1, 12);
                        p1.Value = person_id;
                        p2.Value = day;
                        p3.Value = month_id;
                        p4.Value = usage;
                        DataDao.sqlite_cmd.ExecuteNonQuery();


                    }
                }
            
            }
           
        }

            
        }

    }
