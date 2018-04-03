using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormAuth.Utils
{
    public class DBConvert
    {
        public static int ToInt(object o)
        {
            if (o == DBNull.Value)
                return -1;
            else
                return (int)o;
        }
        public static string ToString(object o)
        {
            if (o == DBNull.Value)
                return string.Empty;
            else
                return (string)o;
        }

    }
}