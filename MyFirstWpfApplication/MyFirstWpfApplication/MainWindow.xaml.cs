using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyFirstWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student stu;

        public MainWindow()
        {
            InitializeComponent();


            this.gridMain.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(this.StudentNameChangedHandler));

            //this.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.Button_Click));
            //this.gridRoot.AddHandler(Button.ClickEvent, new RoutedEventHandler(this.Button_Click));
            //Student stu = new Student();
            //stu.SetBinding(Student.NameProperty, new Binding("Text") { Source = this.textBox1 });
            //this.textBox2.SetBinding(TextBox.TextProperty, new Binding("Name") { Source = stu });

            #region 
            //List<Student> stuList = new List<Student>()
            //{
            //    new Student(){ID=0,Name="Tim", Age=29, },
            //    new Student(){ID=2,Name="Tom", Age=27, },
            //    new Student(){ID=3,Name="Kyle", Age=26, },
            //    new Student(){ID=4,Name="Tony", Age=25, },
            //    new Student(){ID=5,Name="Mike", Age=24, },
            //};

            //this.SetMultiBinding();

            //Binding binding = new Binding("Value") { Source = this.slider1 };
            //binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            //RangeValidationRule rvr = new RangeValidationRule();
            //binding.ValidationRules.Add(rvr);
            //binding.NotifyOnValidationError = true;
            //rvr.ValidatesOnTargetUpdated = true;
            //this.textBox1.SetBinding(TextBox.TextProperty, binding);
            //this.textBox1.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(this.ValidationError));
            //RelativeSource rs = new RelativeSource(RelativeSourceMode.FindAncestor);
            //rs.AncestorLevel = 1;
            //rs.AncestorType = typeof(Grid);
            //Binding binding = new Binding("Name") { RelativeSource = rs };
            //this.textBox1.SetBinding(TextBox.TextProperty, binding);

            //this.SetBinding();
            //this.listBoxStudents.ItemsSource = stuList;
            //this.listBoxStudents.DisplayMemberPath = "Name";            
            //Binding binding = new Binding("SelectedItem.ID") { Source = this.listBoxStudents };
            //this.textBoxId.SetBinding(TextBox.TextProperty, binding);

            //stu = new Student();

            //Binding binding = new Binding();
            //binding.Source = stu;
            //binding.Path = new PropertyPath("Name");

            //BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
            #endregion 

        }

        private void StudentNameChangedHandler(Object sender, RoutedEventArgs args)
        {
            MessageBox.Show((args.OriginalSource as Student).Name);
        }

        private void ValidationError(Object sender, RoutedEventArgs args)
        {
            //if (Validation.GetErrors(this.textBox1).Count > 0)
            //{
            //    this.textBox1.ToolTip = Validation.GetErrors(this.textBox1)[0].ErrorContent.ToString();
            //}
        }

        private void ReportTimeHandler(Object sender, ReportTimeEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            String timeStr = e.ClickTime.ToString();
            String content = $"{timeStr}到达{element.Name}";
            //this.listBox.Items.Add(content);
            if (element.Name.Equals("grid_2", StringComparison.InvariantCultureIgnoreCase))
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            #region 
            //this.textBox.Text = this.FindResource("myString") as String;
            //List<Student> stuList = new List<Student>()
            //{
            //    new Student(){ID=0,Name="Tim", Age=29, },
            //    new Student(){ID=2,Name="Tom", Age=27, },
            //    new Student(){ID=3,Name="Kyle", Age=26, },
            //    new Student(){ID=4,Name="Tony", Age=25, },
            //    new Student(){ID=5,Name="Mike", Age=24, },
            //};
            //this.listViewStudents.ItemsSource = from stu in stuList where stu.Name.StartsWith("T") select stu;
            //ObjectDataProvider odp = new ObjectDataProvider();
            //odp.ObjectInstance = new Calculator();
            //odp.MethodName = "Add";
            //odp.MethodParameters.Add("100");
            //odp.MethodParameters.Add("200");
            //MessageBox.Show(odp.Data.ToString());

            //Student stu = new Student();
            ////stu.SetValue(Student.NameProperty, this.textBox1.Text);
            //this.textBox2.Text = (String)stu.GetValue(Student.NameProperty);
            #endregion

            #region

            //Human human = new Human();
            //School.SetGarde(human, 6);
            //Int32 grade = School.GetGarde(human);
            //MessageBox.Show(grade.ToString());

            #endregion

            Student stu = new Student() { Id = 101, Name = "Time", };
            stu.Name = "Tom";
            RoutedEventArgs arg = new RoutedEventArgs(Student.NameChangedEvent, stu);
            this.button1.RaiseEvent(arg);

            //String strOriginalSource = $"VisualTree start point {(e.OriginalSource as FrameworkElement).Name},type is {e.OriginalSource.GetType().Name}";
            //String strSource = $"LogicalTree start point {(e.Source as FrameworkElement).Name},type is {e.Source.GetType().Name}";
            //MessageBox.Show(strOriginalSource + Environment.NewLine + strSource);
        }

        private void SetBinding()
        {
            ObjectDataProvider odp = new ObjectDataProvider();
            odp.ObjectInstance = new Calculator();
            odp.MethodName = "Add";
            odp.MethodParameters.Add("0");
            odp.MethodParameters.Add("0");
            Binding bindingToArg1 = new Binding("MethodParameters[0]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };

            Binding bindingToArg2 = new Binding("MethodParameters[1]")
            {
                Source = odp,
                BindsDirectlyToSource = true,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };
            Binding bindingToResult = new Binding(".") { Source = odp };
            //this.textBoxArg1.SetBinding(TextBox.TextProperty, bindingToArg1);
            //this.textBoxArg2.SetBinding(TextBox.TextProperty, bindingToArg2);
            //this.textBoxResult.SetBinding(TextBox.TextProperty, bindingToResult);
        }

        private void buttonLoad_Click(object sender, RoutedEventArgs e)
        {
            List<Plane> planeList = new List<Plane>() {
                new Plane(){ Category = Category.Bomber,Name="B-1",State= State.Unknown},
                new Plane(){ Category = Category.Bomber,Name="B-2",State= State.Unknown},
                new Plane(){ Category = Category.Fighter,Name="F-22",State= State.Unknown},
                new Plane(){ Category = Category.Fighter,Name="Su-47",State= State.Unknown},
                new Plane(){ Category = Category.Bomber,Name="B-52",State= State.Unknown},
                new Plane(){ Category = Category.Fighter,Name="J-10",State= State.Unknown},
            };
            //this.listBoxPlane.ItemsSource = planeList;            
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            //foreach (Plane p in listBoxPlane.Items)
            //{
            //    sb.AppendLine($"Category={p.Category},Name={p.Name},State={p.State}");
            //}            
        }

        private void SetMultiBinding()
        {
            //Binding b1 = new Binding("Text") { Source = this.textBox1 };
            //Binding b2 = new Binding("Text") { Source = this.textBox2 };
            //Binding b3 = new Binding("Text") { Source = this.textBox3 };
            //Binding b4 = new Binding("Text") { Source = this.textBox4 };
            //MultiBinding mb = new MultiBinding() { Mode = BindingMode.OneWay };
            //mb.Bindings.Add(b1);
            //mb.Bindings.Add(b2);
            //mb.Bindings.Add(b3);
            //mb.Bindings.Add(b4);
            //mb.Converter = new LogonMultiBindingConverter();

            //this.button1.SetBinding(Button.IsEnabledProperty, mb);
        }
    }
}