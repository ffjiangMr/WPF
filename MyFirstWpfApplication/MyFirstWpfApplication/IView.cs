using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWpfApplication
{
    public interface IView
    {
        Boolean IsChanged { get; set; }
        void SetBinding();
        void Refresh();
        void Clear();
        void Save();
    }
}
