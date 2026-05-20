using System.Collections.ObjectModel;
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

namespace RandomizerHehehe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<String> item = new ObservableCollection<String>();
        public MainWindow()
        {
            InitializeComponent();
            megalist.ItemsSource = item;

            

            double screenWidth = SystemParameters.WorkArea.Width;
            double screenHeight = SystemParameters.WorkArea.Height;

            Width = screenWidth * 0.40;
            Height = screenHeight ;

            Left = 0;
            Top = 0;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
                Button_Click(sender, e); 
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(input.Text))
            {
                item.Add(input.Text);
                input.Clear();
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели!", "АХТУНГ", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}