using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWpfApplication
{
        public enum Category
        {
            Bomber,
            Fighter,
        }

        public enum State
        {
            Available,
            Locked,
            Unknown,
        }

        public class Plane
        {
            public Category Category { get; set; }
            public String Name { get; set; }
            public State State { get; set; }
        }
}
