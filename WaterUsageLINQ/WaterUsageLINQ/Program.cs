using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterUsageLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Query q = new Query();
            q.insertRecords();
            q.selectRecords();
            Console.Read();
        }
    }
}
