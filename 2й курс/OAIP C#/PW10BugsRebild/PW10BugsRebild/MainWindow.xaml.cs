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

namespace PW10BugsRebild
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

        private void Rastizhenie_Click(object sender, RoutedEventArgs e)
        {
            if (this.Height - 20 >= 400)
            {
                this.Width += 20;
                this.Height -= 20;
            }
            if (this.Height - 20 <= 400)
            {
                Rastizhenie.IsEnabled = false;
            }
            if (this.Height >= 400)
            {
                Rastizhenie.IsEnabled = true;
            }

        }
    }
}