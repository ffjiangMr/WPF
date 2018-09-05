using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWpfApplication
{
    public class Calculator
    {
        public String Add(String arg1, String arg2)
        {
            Double x = 0;
            Double y = 0;
            Double z = 0;
            if (Double.TryParse(arg1, out x) && Double.TryParse(arg2, out y))
            {
                z = x + y;
                return z.ToString();
            }
            return "Input error!";
        }
    }
}
