using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp29
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
               string current = Directory.GetCurrentDirectory();

               Console.WriteLine("Текущая директория:");
               Console.WriteLine(current);

           //-----------------------------------------------

           // Имя папки
           string folderName = "Work";

           // Имя файла
           string fileName = "note.txt";

           // Объединяем 2 строки в 1 путь
           string relativePath = Path.Combine(folderName, fileName);
           Console.WriteLine("Относительный путь:");
           Console.WriteLine(relativePath);

           // Получение абсолютного пути
           string fullPath = Path.GetFullPath(relativePath);
           Console.WriteLine("Абсолютный путь");
           Console.WriteLine(fullPath);
        */
            //-----------------------------------------------
            /*
            string folder = "Work";

            // Возвращает true (если фай существует) или false
            bool exists = Directory.Exists(folder);

            if (!exists)
            {
                Directory.CreateDirectory(folder);

                Console.WriteLine("1Папка создана: " + Path.GetFullPath(folder));
            }
            else
            {
                Console.WriteLine("2Папка существует: " + Path.GetFullPath(folder));
            }
            */
            //-----------------------------------------------
            /*
            string folder = "Work";

            Directory.CreateDirectory(folder);

            string filePath = Path.Combine(folder, "note.txt");

            // Создается файл и записывается строка
            File.WriteAllText(filePath, "drfdfhdfhdfhdfhdfhdfhdfhdfhdfh");

            Console.WriteLine("Файл записан:");
            Console.WriteLine(Path.GetFullPath(filePath));

            */
            //-----------------------------------------------
            /*
              string filePath = Path.Combine("Work", "note.txt");

              if (!File.Exists(filePath))
              {
                  Console.WriteLine("ОШТБКА: такого файла нет!");
                  Console.WriteLine(Path.GetFullPath(filePath));
                  return; // выходим из программы
              }

              // Читается весь файл как одна строка
              string text = File.ReadAllText(filePath);

              Console.WriteLine("Содержимое файла:");
              Console.WriteLine(text);
             */
            //-----------------------------------------------
            /*
             string filePath = Path.Combine("Work", "note.txt");

             // Добавим строку в конец.
             // Environment.NewLine — правильный перенос строки под твою ОС.
             string newLine = Environment.NewLine + "Добавленная дата: " + DateTime.Now;

             // Дозапись!
             File.AppendAllText(filePath, newLine);

             Console.WriteLine("Готово!");
             Console.WriteLine(Path.GetFullPath(filePath));
            */
            //-----------------------------------------------
            /*
            string folder = "Work";

            if (!Directory.Exists(folder))
            {
                Console.WriteLine("No folder Work");
                return;
            }

            // Пулучаем список файлов
            string[] files = Directory.GetFiles(folder);

            Console.WriteLine("Все файлы:");
            foreach (string f in files)
            {
                Console.WriteLine("- " + f);
            }

            // Фильтруем файлы
            string[] txtFiles = Directory.GetFiles(folder, "*.txt");


                        Console.WriteLine("ТХТ файлы:");
                        foreach (string f in txtFiles)
                        {
                            Console.WriteLine("- " + f);
                        }
                        */
            //-----------------------------------------------
            /*
            string source = Path.Combine("Work", "note.txt");
            string dest = Path.Combine("Work", "note_copy.txt");

            if (!File.Exists(source))
            {
                Console.WriteLine("Source файл не найден.");
                return;
            }
            // Делается копия
            File.Copy(source, dest, true);

            Console.WriteLine("Скопированный:");
            Console.WriteLine(Path.GetFullPath(dest));
            */
            //-----------------------------------------------
            /*
            Directory.CreateDirectory("Work");
            Directory.CreateDirectory("Work2");

            string source = Path.Combine("Work", "note_copy.txt");
            string dest = Path.Combine("Work2", "moved.txt");

            if (!File.Exists(source))
            {
                Console.WriteLine("Файлне найден: " + source);
                return;
            }

            // Переносим файл в новое место
            File.Move(source, dest);

            Console.WriteLine("Перемещенный файл:");
            Console.WriteLine(Path.GetFullPath(dest));
            */
            //-----------------------------------------------
            /*
            string path = Path.Combine("Work2", "moved.txt");

            if (File.Exists(path))
            {
                // Удаляется файл
                File.Delete(path);

                Console.WriteLine("Победа.");
            }
            else
            {
                Console.WriteLine("Нечего удалять.");
            }
            */
            //---------------------------------------------

            string folder = "Work2";

            if (Directory.Exists(folder))
            {
                // Удаляется папка
                // recursive = true => удалить папку вместе со всем внутри
                Directory.Delete(folder, true);

                Console.WriteLine("Уничтожено: " + folder);
            }
            else
            {
                Console.WriteLine("Не найдена папка: " + folder);
            }

        }
    }
}
