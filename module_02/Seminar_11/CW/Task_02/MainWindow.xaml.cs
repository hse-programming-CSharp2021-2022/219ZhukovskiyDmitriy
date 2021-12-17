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
using System.Windows.Threading;

namespace Task_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button button = new Button();
        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += Tick;
            timer.Start();
            button.Width = 150;
            button.Height = 150;
            layout.Children.Add(button);
            button.Click += button_click;
        }

        private void Tick(object sender, EventArgs e)
        {
            if (button.IsVisible)
                button.Visibility = Visibility.Hidden;
            else button.Visibility = Visibility.Visible;
        }
        int incr = 0;
        private void button_click(object sender, RoutedEventArgs e)
        {
            Tap.Content = incr++;
        }
        
    }
}
