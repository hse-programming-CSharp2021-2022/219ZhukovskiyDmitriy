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

namespace HW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Polyline.Points.Add(new Point(horiz.Value, 200 - vert.Value));
        }

        private void ClearClick(object sender, RoutedEventArgs e)
        {
            Polyline.Points.Clear();
        }
    }
}
