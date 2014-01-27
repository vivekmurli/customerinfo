using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsagePattern
{
    class MainUsageClass
    {
        static void Main(string[] args)
        {
            DataDao datadao = new DataDao();
            //datadao.createDataBase();
            datadao.connection();
            datadao.openConnection();

            //CreateTable createtable = new CreateTable();
            //createtable.table();
            //createtable.executeTable();

            //InsertQuery insertQuery = new InsertQuery();
            
            //datadao.beginTransaction();
            //insertQuery.insertCity();
            //insertQuery.insertmonth();
            //insertQuery.insertWaterUsage();
            //insertQuery.insertElectricityUsage();
           
            //datadao.commitTransaction();
            
            SelectQuery selectquery = new SelectQuery();
            selectquery.select();

            datadao.reader();

            datadao.closeConnection();
        }
    }
}
