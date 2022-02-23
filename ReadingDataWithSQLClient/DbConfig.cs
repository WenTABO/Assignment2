using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataWithSQLClient
{
    public static class DbConfig
    {
        public static string Config()
        {
            
            return @"Data Source =DESKTOP-BJ635MR\SQLEXPRESS; Initial Catalog = Chinook; Trusted_Connection = True;";

            
        }
    }
}
