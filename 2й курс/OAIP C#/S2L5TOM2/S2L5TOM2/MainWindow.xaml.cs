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

namespace WpfApp17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Start();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += EverySecond;
        }
        private void EverySecond(object sender, EventArgs e)
        {
            Label.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label.FontSize = 50;
            Label.HorizontalAlignment = HorizontalAlignment.Right;
            Label.VerticalAlignment = VerticalAlignment.Bottom;
            Label.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}