using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyFirstWpfApplication
{
    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent routedEvent, Object source) : base(routedEvent, source)
        {

        }

        public DateTime ClickTime { get; set; }
    }
}
