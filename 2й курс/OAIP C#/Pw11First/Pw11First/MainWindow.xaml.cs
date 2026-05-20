using System.Text;
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

namespace Pw11First
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        private bool pokazatDate = true;
        private Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            
            timer.Interval = TimeSpan.FromSeconds(10);
            
            timer.Tick += pocazat;
            timer.Start();
            updataAll();    

        }
        public void pocazat(object sender, EventArgs e)
        {
            updataAll();
        }
        public void updataAll()
        {
            if (pokazatDate)
            {   dada.Text = DateTime.Now.ToString("dd.MM.yyyy");
                

                byte r = (byte)rnd.Next(256);
                byte g = (byte)rnd.Next(256);
                byte b = (byte)rnd.Next(256);
                dada.Foreground = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
            else {
                dada.Text = DateTime.Now.ToString("HH:mm:ss");

                byte r = (byte)rnd.Next(256);
                byte g = (byte)rnd.Next(256);
                byte b = (byte)rnd.Next(256);
                this.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
            }
            pokazatDate = !pokazatDate;

        }

    }
}