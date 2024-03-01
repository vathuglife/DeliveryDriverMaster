using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class StringUtils
    {
        public static string IncrementPoints(string txt)
        {
            int txtInt = Convert.ToInt32(txt);
            txtInt++;
            return Convert.ToString(txtInt);
        }
        public static string DecrementPoints(string txt)
        {
            int txtInt = Convert.ToInt32(txt);
            txtInt--;
            return Convert.ToString(txtInt);
        }
    }

}
