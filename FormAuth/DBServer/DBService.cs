using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace FormAuth.DBServer
{
    public class DBService
    {
        protected string ConnStr;
        public DBService(string connStr)
        {
            ConnStr = ConfigurationManager.ConnectionStrings[connStr].ConnectionString;
        }
    }
}