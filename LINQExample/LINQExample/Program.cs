using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExample
{
    class Program
    {
       /* public void insertCity()
        {
            using (ThermoEntities db = new ThermoEntities())
            {
                
                City c = new City();
                Console.WriteLine("Enter City :");
                c.city_name = Console.ReadLine();
                Console.WriteLine("Enter State :");
                c.city_state = Console.ReadLine();
                db.Cities.Add(c);
                db.SaveChanges();
            }
            displayCity();
        }
        public void displayCity()
        {
            using (ThermoEntities db = new ThermoEntities())
            {
                var querySelect = from qtemp in db.Cities
                                  select qtemp;
                Console.WriteLine("Id\tCity\tState");
                foreach (var row in querySelect)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", row.city_id, row.city_name, row.city_state);
                }
            }
        }*/

        static void Main(string[] args)
        {
            //-----------Simple Insert and Select query-----------
           // Program t = new Program();
           // t.insertCity();

            //------------Select Query for Usage > 200-------------
            SelectQuery s = new SelectQuery();
            s.waterUsage();

            Console.Read();
        }
    }
}
