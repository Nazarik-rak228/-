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
using System.IO;
using Microsoft.Win32;

namespace lekcFromPW15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentpath = "";
        private bool isTextChanged = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        // файл, уф 
        private void newFail(object sender, RoutedEventArgs e)
        {
            if (!checksave())
            {
                return;
            }
            Editor.Clear();
            currentpath = "";
            isTextChanged = false;
            Title = "Новый файл - блокнотик";

        }
        // когда мы нажимаем сохранить как, открывапется окно операционки, а не приложение делает отдельнор
        // называется это опен файл диалог, 
        // и есть на все, и на сейв, и на опен, такая вот херь, открывается через Microsoft.win32
        private void open(object sender, RoutedEventArgs e)
        {
            if (!checksave())
            {
                return;
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Открать файл";
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt| все файлы(*.*)|*.*|";
            if (dialog.ShowDialog() == true) {
                Editor.Text = File.ReadAllText(dialog.FileName, Encoding.UTF8);
                currentpath = dialog.FileName;
                isTextChanged = false;
                Title = currentpath + " -блокнот";
            }// тут короче надо будлет почитать, часть прослушал 

        }
        private bool save()
        {
            if (currentpath == "")
            {
                return saveWhat();
            }
            File.WriteAllText(currentpath, Editor.Text, Encoding.UTF8);
            isTextChanged = false;
            Title = currentpath + " -блокнот";
            return true;
        }
        private bool saveWhat()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Созранить как ";
            save.Filter = "Текстовые файлы (*.txt)|*.txt| все файлы(*.*)|*.*|";
            save.FileName = "Новый документ .txt";
            if (save.ShowDialog() == true) {

                currentpath = save.FileName;
                return true;
            }
            return false;
        }
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            isTextChanged = true;
            if (currentpath == "")
            {
                Title = "Новый файл * - блокнот";
            }
            isTextChanged = true;
            if (currentpath != "")
            {
                Title = currentpath + " * - блокнот";
            }
        }
        private bool checksave()
        {
            if (!isTextChanged)
            {
                return true;
            }
            MessageBoxResult result = MessageBox.Show(
                "файл изменен, Сохранить изменение?", "Сохранение...",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question
                );
            if (result == MessageBoxResult.Yes) {
                return save();
            }
            if (result== MessageBoxResult.No)
            {
                return true;
            }
            return false;
        }

        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            updateStatus();
        }
        private void updateStatus()
        {
            int caretindex = Editor.CaretIndex;
            int lines = Editor.GetLineIndexFromCharacterIndex(caretindex);
            int column = caretindex- Editor.GetCharacterIndexFromLineIndex(lines);
            line.Text = "строка" + (lines+1)+ "Слолбец" + (column+1);
            sleng.Text = "Символов: " + Editor.Text.Length;
            if(currentpath == "")
            {
                path.Text = "нОВЫЙ ФАЙЛ";
            }
            if (currentpath != "")
            {
                path.Text =  currentpath;
            }
        }

        private void printall(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(Editor, "начать печать");
            }
        }

        /// <summary>
        ///  тут по правке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void otmena(object sender, RoutedEventArgs e)
        {
            if(Editor.CanUndo)
            {
                Editor.Undo();
            }
        }
        private void powtor(object sender, RoutedEventArgs e)
        {
            if (Editor.CanRedo)
            {
                Editor.Redo();
            }
        }
        private void del(object sender, RoutedEventArgs e)
        {
            // тут  сложно
            if (Editor.SelectionLength >0)
            {
                int start = Editor.SelectionStart; // это свойство работает с выделоением
                Editor.Text = Editor.Text.Remove(Editor.SelectionStart, Editor.SelectionLength);
                Editor.SelectionStart = start; // переводим курсор обратно, после удаления
            }
        }
        

        private void perenos(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item != null) {
                if (item.IsChecked)
                {
                    Editor.TextWrapping= TextWrapping.Wrap;
                }
                if (!item.IsChecked)
                {
                    Editor.TextWrapping = TextWrapping.NoWrap;
                }
            }
        }
        // формат надо блин все доделать
        private void sgriftPlus(object sender, RoutedEventArgs e)
        {

            if (Editor.FontSize < 100)
            {
                Editor.FontSize = Editor.FontSize + 1;

            }
        }
        private void sgriftMinus(object sender, RoutedEventArgs e)
        {

            if (Editor.FontSize > 5)
            {
                Editor.FontSize = Editor.FontSize -1 ;

            }
        }

       
    }
}