using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Data;

namespace MyFirstWpfApplication
{

    public class Student : DependencyObject /*: INotifyPropertyChanged*/
    {

        public static readonly RoutedEvent NameChangedEvent = EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Student));

        public String Name { get; set; }
        public Int32 Id { get; set; }

        //private String name;
        //public Int32 ID { get; set; }
        //public String Name { get { return (String)this.GetValue(NameProperty); } set { this.SetValue(NameProperty, value); } }
        //public Int32 Age { get; set; }

        //public static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(String), typeof(Student));

        //public BindingExpressionBase SetBinding(DependencyProperty dp, BindingBase binding)
        //{
        //    return BindingOperations.SetBinding(this, dp, binding);
        //}

        #region 

        //public String Name
        //{
        //    get { return this.name; }
        //    set 
        //    {
        //        this.name = value;
        //        PropertyChangedEventHandler temp = Volatile.Read(ref this.PropertyChanged);
        //        if (temp != null)
        //        {
        //            temp(this, new PropertyChangedEventArgs("Name"));
        //        }
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

    }

}
