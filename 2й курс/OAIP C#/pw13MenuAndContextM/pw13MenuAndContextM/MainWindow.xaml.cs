using System.ComponentModel;
using System.Security.Policy;
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

namespace pw13MenuAndContextM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PeopleData original;
        private PeopleData current;
        public MainWindow()
        {

            InitializeComponent();

            original = new PeopleData("", "", "");
            current = new PeopleData("", "", "");

            this.Closing += Window_Closing;
            this.KeyDown += Window_KeyDown;
        }
        private PeopleData GetData()
        {
            return new PeopleData(
                name.Text.Trim(),
                famil.Text.Trim(),
                otch.Text.Trim()
            );
        }
        private void UpdateCurrent()
        {
            current = GetData();
        }
        private bool HasChanges()
        {
            return current.NameP != original.NameP || current.Fam != original.Fam || current.Last != original.Last;
        }
        private void ShowData()
        {
            MessageBox.Show(
                $"{current.NameP} {current.Fam} {current.Last}", "Текущее состояние", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ResetData()
        {
            current = new PeopleData(
                original.NameP,
                original.Fam,
                original.Last
            );

            name.Text = current.NameP;
            famil.Text = current.Fam;
            otch.Text = current.Last;

            MessageBox.Show(
                "Сброшено",
                "Info",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            UpdateCurrent();

            if (!HasChanges())
                return;

            var res = MessageBox.Show(
                "Есть изменения. Выйти?",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (res == MessageBoxResult.No)
                e.Cancel = true;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                UpdateCurrent();
                original = new PeopleData(current.NameP, current.Fam, current.Last);

            }

            if (e.Key == Key.Z && Keyboard.Modifiers == ModifierKeys.Control)
            {
                ResetData();
            }
            if (e.Key == Key.B && Keyboard.Modifiers == ModifierKeys.Control)
            {
                ShowData();
            }
        }

        public class PeopleData
        {
            public string NameP { get; set; }
            public string Fam { get; set; }
            public string Last { get; set; }

            public PeopleData(string name, string fam, string last)
            {
                NameP = name;
                Fam = fam;
                Last = last;
            }
        }




        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // меню сохранения 
            UpdateCurrent();
            original = new PeopleData(current.NameP,current.Fam,current.Last);


        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            ResetData();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            ShowData();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            Sas.Background = Brushes.Gray;
            name.Foreground = Brushes.White;
            famil.Foreground = Brushes.White;
            otch.Foreground = Brushes.White;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            Sas.Background = Brushes.White;
            
            name.Foreground = Brushes.Black;
            famil.Foreground = Brushes.Black;
            otch.Foreground = Brushes.Black;

        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            
        }
    }
}