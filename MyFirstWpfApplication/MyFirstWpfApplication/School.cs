using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFirstWpfApplication
{
    public class School:DependencyObject
    {
        public static int GetGarde(DependencyObject obj)
        {
            return (Int32)obj.GetValue(GardeProperty);
        }

        public static void SetGarde(DependencyObject obj, int value)
        {
            obj.SetValue(GardeProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GardeProperty =
            DependencyProperty.RegisterAttached("Garde", typeof(Int32), typeof(School), new PropertyMetadata(0));


    }
}
