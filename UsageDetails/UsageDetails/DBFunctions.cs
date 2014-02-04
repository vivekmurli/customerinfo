using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace UsageDetails
{
    abstract class DBFunctions
    {
        public virtual List<string> cmbboxMonth()
        {
            List<string> month = new List<string>();
            return month;
        }

        public virtual List<string> cmbboxYear()
        {
            List<string> month = new List<string>();
            return month;
        }

        public virtual List<string> retrieveData(string mname, int year, int usage)
        {
            List<string> personName = new List<string>();
            return personName;
        }
    }
}
