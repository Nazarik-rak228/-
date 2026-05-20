using Microsoft.Win32; // Диалоговые окна открытия и сохранения файла.
using System.IO; // Работа с файлами.
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



namespace pw15notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath = "";
        private bool isTextChanged = false;
        private double currentScale = 1.0;
        private double baseFontSize = 16.0;
        private string GetEditorText()
        {
            TextRange textRange = new TextRange(
            Editor.Document.ContentStart,
            Editor.Document.ContentEnd);
            string text = textRange.Text;
            if (text.EndsWith("\r\n"))
            {
                text = text.Substring(0, text.Length - 2);

            }
            return text;
        }
        private void SetEditorText(string text)
        {
            Editor.Document.Blocks.Clear();
            Paragraph paragraph = new Paragraph();
            paragraph.Inlines.Add(text);
            Editor.Document.Blocks.Add(paragraph);
        }
        private void ClearEditor()
        {
            Editor.Document.Blocks.Clear();
            Editor.Document.Blocks.Add(new Paragraph());
        }
        public MainWindow()
        {
            InitializeComponent();
            InitializeFormattingToolbar();
        }
        /// <summary>
        /// Это файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //New file
        private void NewFile_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSaveBeforeAction())
            {
                return;
            }
            ClearEditor();
            currentFilePath = "";
            isTextChanged = false;
            Title = "Новый файл — Блокнот";
        }
        // Open
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckSaveBeforeAction()) { return; }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Открыть файл";
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                SetEditorText(File.ReadAllText(dialog.FileName, Encoding.UTF8));
                currentFilePath = dialog.FileName;
                isTextChanged = false;
                Title = currentFilePath + " — Блокнот";
            }
        }
        // Save
        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }
        private bool SaveFile()
        {
            
            if (currentFilePath == "")
            {
                return SaveFileAs();
            }

            File.WriteAllText(currentFilePath, GetEditorText(), Encoding.UTF8);
            isTextChanged = false;
            Title = currentFilePath + " — Блокнот";
            return true;
        }



        // save As
        private void SaveAsFile_Click(object sender, RoutedEventArgs e)

        {
            SaveFileAs();
        }

        private bool SaveFileAs()
        {
          
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранить файл как";
            dialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            dialog.FileName = "Новый документ.txt";
            if (dialog.ShowDialog() == true)
            {
                currentFilePath = dialog.FileName;
                return SaveFile();
            }
            return false;
        }


        // EEEEE!, Let's print!

        private void PrintFile_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(Editor, "Печать документа");
            }
        }
        // Exit
        private void Exit_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (!CheckSaveBeforeAction())
            {
                e.Cancel = true;
            }
            base.OnClosing(e);
        }


        /// <summary>
        /// Правка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        // back
        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (Editor.CanUndo)
                Editor.Undo();
        }
        // repeat 
        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (Editor.CanRedo)
                Editor.Redo();
        }
        // cut
        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Editor.Cut();
        }
        //copy
        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            Editor.Copy();
        }
        // paste
        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            Editor.Paste();
        }
        // delite
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!Editor.Selection.IsEmpty)
            {
                Editor.Selection.Text = "";
            }
        }
        // Find
        private void ShowFindPanel_Click(object sender, RoutedEventArgs e)
        {
            FindPanel.Visibility = Visibility.Visible;
            ReplaceTextBlock.Visibility = Visibility.Collapsed;
            ReplaceTextBox.Visibility = Visibility.Collapsed;
            ReplaceButton.Visibility = Visibility.Collapsed;
            ReplaceAllButton.Visibility = Visibility.Collapsed;
            FindTextBox.Focus();
        }
        // replace
        private void ShowReplacePanel_Click(object sender, RoutedEventArgs e)
        {
            FindPanel.Visibility = Visibility.Visible;
            ReplaceTextBlock.Visibility = Visibility.Visible;
            ReplaceTextBox.Visibility = Visibility.Visible;
            ReplaceButton.Visibility = Visibility.Visible;
            ReplaceAllButton.Visibility = Visibility.Visible;
            FindTextBox.Focus();
        }
        // close find/replace
        private void CloseFindPanel_Click(object sender, RoutedEventArgs e)
        {
            FindPanel.Visibility = Visibility.Collapsed;
            Editor.Focus();
        }
        // find next 
        private void FindNext_Click(object sender, RoutedEventArgs e)
        {
            FindNext();
        }
        private void FindNext()
        {
            string findText = FindTextBox.Text;
            if (findText == "")
            {
                MessageBox.Show("Введите текст для поиска.",
                "Поиск",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            StringComparison comparison; // какая то крутая настройка сравнения строк
            if (CaseSensitiveCheckBox.IsChecked == true)
            {
                comparison = StringComparison.CurrentCulture;
            }
            else
            {
                comparison = StringComparison.CurrentCultureIgnoreCase;
            }
            string fullText = GetEditorText();
            int startIndex = Editor.Document.ContentStart.GetOffsetToPosition(Editor.Selection.Start);
            int index = fullText.IndexOf(findText, startIndex, comparison);
            // вообще бомба, берем массив, старт, настройка, кайф
            if (index == -1 && startIndex > 0)
            {
                index = fullText.IndexOf(findText, 0, comparison);
            }
            if (index >= 0)
            {
                Editor.Focus();
                TextPointer start = Editor.Document.ContentStart.GetPositionAtOffset(index);
                TextPointer end = Editor.Document.ContentStart.GetPositionAtOffset(index + findText.Length);
                Editor.Selection.Select(start, end);
            }
            else
            {
                MessageBox.Show("Текст не найден.",
                    "Поиск",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
        }

        //find replase
        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            string findText = FindTextBox.Text;
            string replaceText = ReplaceTextBox.Text;
            if (findText == "")
            {
                MessageBox.Show("Введите текст для поиска.",
                "Замена",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            StringComparison comparison;
            if (CaseSensitiveCheckBox.IsChecked == true)
            {
                comparison = StringComparison.CurrentCulture;
            }
            else
            {
                comparison = StringComparison.CurrentCultureIgnoreCase;
            }
            if (Editor.Selection.Text.Equals(findText, comparison))
            {

                Editor.Selection.Text = replaceText;
            }
            FindNext();
        }
        //find replaceAll
        private void ReplaceAll_Click(object sender, RoutedEventArgs e)
        {
            string findText = FindTextBox.Text;
            string replaceText = ReplaceTextBox.Text;
            if (findText == "")
            {
                MessageBox.Show("Введите текст для поиска.",
                "Замена",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
                return;
            }
            StringComparison comparison;
            if (CaseSensitiveCheckBox.IsChecked == true)
            {
                comparison = StringComparison.CurrentCulture;
            }
            else
            {
                comparison = StringComparison.CurrentCultureIgnoreCase;
            }
            string text = GetEditorText();
            int count = 0;
            int index = 0;
            while (true)
            {
                index = text.IndexOf(findText, index, comparison);
                if (index == -1)
                { 
                    break; 
                }
                text = text.Remove(index, findText.Length);
                text = text.Insert(index, replaceText);
                index = index + replaceText.Length;
                count++;
            }
            SetEditorText(text);
            MessageBox.Show("Выполнено замен: " + count,
                "Замена",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
        // All select
        private void SelectAll_Click(object sender, RoutedEventArgs e)
        {
            Editor.SelectAll();

        }

        /// <summary>
        /// Дальше идет формат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // а все, больше нету...

        
        /// <summary>
        /// О ПРограммке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Заглушка для пункта меню "Справка → О программе".
        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Блокнотик \n Это программа была украдена почти вся у препода \n после доработана по заданию студентом П-8-24","О нас...",MessageBoxButton.OK, MessageBoxImage.Question);
        }
        /// <summary>
        /// Короче всяки проверки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {

            isTextChanged = true;
            if (currentFilePath == "")
            {
                Title = "Новый файл * — Блокнот";
            }
            else
            {
                Title = currentFilePath + " * — Блокнот";
            }
            UpdateStatus();
        }

        private bool CheckSaveBeforeAction()
        {
            if (!isTextChanged)
            {
                return true;
            }

            MessageBoxResult result = MessageBox.Show(
                "Файл был изменён. Сохранить изменения?",
                "Сохранение",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                return SaveFile();
            }
            if (result == MessageBoxResult.No)
            {
                return true;
            }
            return false;




        }
        private void Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
            UpdateStatus();
        }
        private void UpdateStatus()
        {
            string text = GetEditorText();
            TextRange rangeToCaret = new TextRange(
                Editor.Document.ContentStart,
                Editor.CaretPosition);
            string textBeforeCaret = rangeToCaret.Text;
            if (textBeforeCaret.EndsWith("\r\n"))
            {
                textBeforeCaret = textBeforeCaret.Substring(0, textBeforeCaret.Length - 2);
            }
            int line = 1;
            int column = 1;
            for (int i = 0; i < textBeforeCaret.Length; i++)
            {
                if (textBeforeCaret[i] == '\n')
                {
                    line++;
                    column = 1;
                }
                else if (textBeforeCaret[i] != '\r')
                {
                    column++;
                }
            }
            LineColumnText.Text = "Строка: " + line + ", Столбец: " + column;
            CharCountText.Text = "Символов: " + text.Length;
            if (currentFilePath == "")
            {
                FilePathText.Text = "Новый файл";
            }
            else
            {
                FilePathText.Text = currentFilePath;
            }
        }
        // тулбар
        private void InitializeFormattingToolbar()
        {
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontFamilyComboBox.Items.Add(fontFamily.Source);
            }
            FontFamilyComboBox.SelectedItem = "Consolas";

            FontSizeComboBox.Items.Add("8");
            FontSizeComboBox.Items.Add("10");
            FontSizeComboBox.Items.Add("12");
            FontSizeComboBox.Items.Add("14");
            FontSizeComboBox.Items.Add("16");
            FontSizeComboBox.Items.Add("18");
            FontSizeComboBox.Items.Add("20");
            FontSizeComboBox.Items.Add("24");
            FontSizeComboBox.Items.Add("28");
            FontSizeComboBox.Items.Add("32");
            FontSizeComboBox.Items.Add("36");
            FontSizeComboBox.Items.Add("48");
            FontSizeComboBox.Items.Add("72");
            FontSizeComboBox.SelectedItem = "16";

            FontColorComboBox.SelectedIndex = 0;
        }

        // жирни 
        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            Editor.Focus();
        }
        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            Editor.Focus();
        }
        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            Editor.Focus();
        }

        // шрифт 
        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem == null) return;
            string selectedFont = FontFamilyComboBox.SelectedItem.ToString();
            Editor.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily(selectedFont));
            Editor.Focus();
        }
        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeComboBox.SelectedItem == null) return;
            string selectedSizeText = FontSizeComboBox.SelectedItem.ToString();
            double selectedSize;
            if (double.TryParse(selectedSizeText, out selectedSize))
            {
                Editor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, selectedSize);
            }
            Editor.Focus();
        }

        // цвет текста
        private void FontColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontColorComboBox.SelectedItem == null) return;
            ComboBoxItem selectedItem = FontColorComboBox.SelectedItem as ComboBoxItem;
            if (selectedItem == null) return;
            string colorName = selectedItem.Tag.ToString();
            BrushConverter converter = new BrushConverter();
            Brush brush = converter.ConvertFromString(colorName) as Brush;
            if (brush != null)
            {
                Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, brush);
            }
            Editor.Focus();
        }

        // выравнивание
        private void AlignLeft_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Left);
            Editor.Focus();
        }
        private void AlignCenter_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Center);
            Editor.Focus();
        }
        private void AlignRight_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Right);
            Editor.Focus();
        }
        private void AlignJustify_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Justify);
            Editor.Focus();
        }

        //размер шрифта
        private void IncreaseFont_Click(object sender, RoutedEventArgs e)
        {
            object value = Editor.Selection.GetPropertyValue(TextElement.FontSizeProperty);
            double currentSize = 16;
            if (value != DependencyProperty.UnsetValue)
            {
                currentSize = (double)value;
            }
            double newSize = currentSize + 2;
            Editor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, newSize);
            FontSizeComboBox.Text = newSize.ToString();
            Editor.Focus();
        }
        private void DecreaseFont_Click(object sender, RoutedEventArgs e)
        {
            object value = Editor.Selection.GetPropertyValue(TextElement.FontSizeProperty);
            double currentSize = 16;
            if (value != DependencyProperty.UnsetValue)
            {
                currentSize = (double)value;
            }
            if (currentSize > 8)
            {
                double newSize = currentSize - 2;
                Editor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, newSize);
                FontSizeComboBox.Text = newSize.ToString();
            }
            Editor.Focus();
        }
            // новый перенос
        private void WordWrap_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = sender as MenuItem;
            if (item != null)
            {
                if (item.IsChecked)
                {
                    Editor.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                }
                else
                {
                    Editor.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                }
            }
        }



        private void ScaleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (ScaleComboBox.SelectedItem is ComboBoxItem item && item.Tag != null)
            {
                if (double.TryParse(item.Tag.ToString(), out double scale))
                    ApplyScale(scale);
            }
        }

        // Кнопки A+, A-, Сброс
        private void ScaleUp_Click(object sender, RoutedEventArgs e) => ApplyScale(currentScale + 0.1);
        private void ScaleDown_Click(object sender, RoutedEventArgs e)
        {
            if (currentScale > 0.2) ApplyScale(currentScale - 0.1);
        }
        private void ScaleReset_Click(object sender, RoutedEventArgs e) => ApplyScale(1.0);

        // Общая логика масштабирования
        // Общая логика масштабирования
        // Общая логика масштабирования
        private void ApplyScale(double newScale)
        {
            if (newScale < 0.2)
                return;

            currentScale = Math.Round(newScale, 2);

            ScaleTransform scale = new ScaleTransform(currentScale, currentScale);

            Editor.LayoutTransform = scale;

            ScaleStatusText.Text = $"Масштаб: {(int)(currentScale * 100)}%";
        }

        // Кнопка "Обычный стиль" (сброс форматирования)
        private void NormalStyle_Click(object sender, RoutedEventArgs e)
        {
            Editor.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Consolas"));
            Editor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, baseFontSize);
            Editor.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
            Editor.Selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
            Editor.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Black);
            Editor.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            Editor.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Left);
            Editor.Focus();
        }
    }   
}