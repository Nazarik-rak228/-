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

namespace S2l6bugs
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrameworkElement botonchik;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void coloring(object sender, MouseButtonEventArgs e) { 
            botonchik = (FrameworkElement)sender;// присваем переменной обьект на который мы шажали 
            this.Title = botonchik.Name;
            
        }
        private void Color_Left(object sender, RoutedEventArgs e) 
        { 
        Button tiknul = (Button)sender; // мы так как брали и сохраняли обьект, так и кнопку
        Brush color =tiknul.Background;
            if (botonchik is Rectangle rect)
            {
                rect.Fill = color;

            }
            if (botonchik is Ellipse elipse)
            {
                elipse.Fill = color;

            }
            if (botonchik is Border border)
            {
                border.Background = color;


            }


        }
        private void Color_right(object sender, RoutedEventArgs e) 
        {

            Button tiknul = (Button)sender; // мы так как брали и сохраняли обьект, так и кнопку
            Brush color = tiknul.Background;
            if (botonchik is Rectangle rect)
            {
                rect.Stroke = color;

            }
            if (botonchik is Ellipse elipse)
            {
                elipse.Stroke = color;

            }
            if (botonchik is Border border)
            {
                border.BorderBrush = color;


            }
        }

    }
}