using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyFirstWpfApplication
{
    public class MyButton : Button
    {
        public Type UserWindowType { get; set; }

        protected override void OnClick()
        {
            base.OnClick();
            var temp = Activator.CreateInstance(this.UserWindowType) as Window;
            if (temp != null)
            {
                temp.Show();
            }
        }
    }
}
