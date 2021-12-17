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

namespace CW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Button button = new Button();
            button.Content = "Another one";
            button.Height = 150;
            button.Width = 150;
            Layout.Children.Add(button);
            button.Click += Button_Click;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox.Text);
        }
    }
}
