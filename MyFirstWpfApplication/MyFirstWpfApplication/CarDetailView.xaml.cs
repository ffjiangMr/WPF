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
    /// Interaction logic for CarDetailView.xaml
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }

        private Car car;

        public Car Car { get { return this.Car; }
            set{
                this.car = value;
                this.textBlockName.Text = car.Name;
                this.textBlockAutomaker.Text = car.Automaker;
                this.textBlockTopSpeed.Text = car.TopSpeed;
                this.textBlockYear.Text = car.Year;
                String uriStr = $@"/Resources/Images/{car.Name}.jpg";
                this.imagePhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            } }

    }
}
