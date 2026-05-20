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

namespace WpfApp16
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

        private void ButtnForm_Click(object sender, RoutedEventArgs e)
        {
            this.Title = "П-8-24";
            this.Width = 1200;
            this.Height = 800;
            this.Background = Brushes.GreenYellow;
            Button.Visibility = Visibility.Visible;
        }

        private void ButtnStyle_Click(object sender, RoutedEventArgs e)
        {
            ButtnStyle.FontSize = 50;
            ButtnStyle.FontFamily = new FontFamily("Times New Roman");
            ButtnStyle.Width = 300;
            ButtnStyle.Background = Brushes.White;
            ButtnForm.IsEnabled = true;
            Button.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtnForm.IsEnabled = false;
        }
    }
}
