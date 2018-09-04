using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            List<Student> stuList = new List<Student>()
            {
                new Student(){ID=0,Name="Tim", Age=29, },
                new Student(){ID=2,Name="Tom", Age=27, },
                new Student(){ID=3,Name="Kyle", Age=26, },
                new Student(){ID=4,Name="Tony", Age=25, },
                new Student(){ID=5,Name="Mike", Age=24, },
            };

            //this.listBoxStudents.ItemsSource = stuList;
            //this.listBoxStudents.DisplayMemberPath = "Name";            
            //Binding binding = new Binding("SelectedItem.ID") { Source = this.listBoxStudents };
            //this.textBoxId.SetBinding(TextBox.TextProperty, binding);

            //stu = new Student();

            //Binding binding = new Binding();
            //binding.Source = stu;
            //binding.Path = new PropertyPath("Name");

            //BindingOperations.SetBinding(this.textBoxName, TextBox.TextProperty, binding);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.textBox.Text = this.FindResource("myString") as String;
            List<Student> stuList = new List<Student>()
            {
                new Student(){ID=0,Name="Tim", Age=29, },
                new Student(){ID=2,Name="Tom", Age=27, },
                new Student(){ID=3,Name="Kyle", Age=26, },
                new Student(){ID=4,Name="Tony", Age=25, },
                new Student(){ID=5,Name="Mike", Age=24, },
            };
            this.listViewStudents.ItemsSource = from stu in stuList where stu.Name.StartsWith("T") select stu;
        }
    }
}