using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFirstWpfApplication
{
    [TypeConverter(typeof(StringToHumanTypeConverter))]
    public class Human:DependencyObject
    {
        public String Name { get; set; }
        public Human Child { get; set; }
    }
}
