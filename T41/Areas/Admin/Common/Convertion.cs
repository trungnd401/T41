using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace T41.Areas.Admin.Common
{
    public class Convertion
    {
        public int DateToInt(string date)
        {
            // 01/01/2018
            try
            {
                string yyyy = date.Substring(6, 4);
                string mm = date.Substring(3, 2);
                string dd = date.Substring(0, 2);
                return Convert.ToInt32(yyyy + mm + dd);
            }
            catch
            {
                return 0;
            }

        }
    }
}