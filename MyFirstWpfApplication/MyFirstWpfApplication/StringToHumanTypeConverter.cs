﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWpfApplication
{    
    public class StringToHumanTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is String)
            {
                Human h = new Human();
                h.Name = value as String;
                return h;
            }
            return base.ConvertFrom(context, culture, value);
        }
    }
}
