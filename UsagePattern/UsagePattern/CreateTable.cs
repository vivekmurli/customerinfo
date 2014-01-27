using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsagePattern;

namespace UsagePattern
{
    class CreateTable
    {
        string[] createTableQuery = new string[5];
        
        public void table()
        {  

            createTableQuery[0] = @"create table if not exists [city](
                                  [city_id] integer not null primary key autoincrement,
                                  [city_name] varchar not null,
                                  [state] varchar not null
                                  )";



            createTableQuery[1] = @"create table if not exists [person](
                                   [person_id] integer not null primary key autoincrement,
                                   [person_name] varchar not null,
                                   [city_id] integer not null,
                                   foreign key(city_id) references city(city_id)
                                   )";

            createTableQuery[2] = @"create table if not exists [month](
                                  [month_id] integer not null primary key autoincrement,
                                  [month_name] varchar not null,
                                  [year] integer not null
                                  )";

            createTableQuery[3] = @"create table if not exists [water_usage](
                                  [person_id] integer not null,
                                  [day] integer not null,
                                  [month_id] integer not null,
                                  [usage] integer not null,
                                  foreign key(person_id) references person(person_id),
                                  foreign key(month_id) references month(month_id)
                                  )";

            createTableQuery[4] = @"create table if not exists [electricity_usage](
                                  [person_id] integer not null,
                                  [day] integer not null,
                                  [month_id] integer not null,
                                  [usage] integer not null,
                                  foreign key(person_id) references person(person_id),
                                  foreign key(month_id) references month(month_id)
                                  )";
        }

        public void executeTable()
        {
            for (int i = 0; i <= 4; i++)
            {
                DataDao.sqlite_cmd.CommandText = createTableQuery[i];
                DataDao.sqlite_cmd.ExecuteNonQuery();

            }
        }
    }
}
