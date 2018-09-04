using System;
using System.ComponentModel;
using System.Threading;

namespace MyFirstWpfApplication
{
    public class Student : INotifyPropertyChanged
    {
        private String name;

        public String Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                PropertyChangedEventHandler temp = Volatile.Read(ref this.PropertyChanged);
                if (temp != null)
                {
                    temp(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
