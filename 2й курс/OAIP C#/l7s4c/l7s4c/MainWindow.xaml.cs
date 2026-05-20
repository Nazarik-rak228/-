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

namespace l7s4c
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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Box.Background = Brushes.Red;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Box.Background = Brushes.Green;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Box.Background = Brushes.Blue;
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Box.BorderBrush = Brushes.Red;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Box.BorderBrush = Brushes.Green;
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            Box.BorderBrush = Brushes.Blue;
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            Box.BorderThickness = new Thickness(5);
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            Box.BorderThickness = new Thickness(6);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == Key.G) { 
             Box.Background = Brushes.Green;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР", "Джафар:",MessageBoxButton.YesNoCancel);
            
            MessageBoxResult res = MessageBox.Show("НЕГР НЕГР НЕГР НЕГР НЕГР НЕГР ", "Джафар:", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (res == MessageBoxResult.Yes) {
                MessageBox.Show("ДЖАФАР ПИ ПИ, ДЖАФАР ДОР ДОР, ДЖАФАР ПИПИ ПИПИДОР ДОР");
            }
            if (res == MessageBoxResult.No)
            {
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var ress = MessageBox.Show("Джафар же педик?", "Ебень!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (ress == MessageBoxResult.Yes) {
                MessageBox.Show("Ладно, ты прав!");
                
            }
            if (ress == MessageBoxResult.No)
            {
                MessageBox.Show("Ты че! Джафар же педик!");
                e.Cancel = true;
            }
        }

    }
}