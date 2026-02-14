using System;

namespace PW8_9C
{
    internal class Program
    {
        class Festival
        {
            private string[] names = new string[18];
            private string[] genres = new string[18];
            private int[][] juryScores = new int[18][];
            private int[][] audienceScores = new int[18][];

            public Festival()
            {
                // те же данные, но теперь внутри класса
                SetFilm(0, "Паразиты", "Триллер", new int[] { 9, 8, 9 }, new int[] { 9, 8, 10, 9 });
                SetFilm(1, "Оппенгеймер", "Драма", new int[] { 8, 7, 8 }, new int[] { 9, 8 });
                SetFilm(2, "Барби", "Комедия", new int[] { 6, 7, 6 }, new int[] { 8, 9, 8, 7 });
                SetFilm(3, "Дюна 2", "Фантастика", new int[] { 5, 6, 4 }, new int[] { 5, 6, 4 });
                SetFilm(4, "Всё везде и сразу", "Фантастика/комедия", new int[] { 9, 10, 9, 8 }, new int[] { 9, 8, 10, 9, 9 });
                SetFilm(5, "1917", "Военный/драма", new int[] { 8, 9, 8, 7 }, new int[] { 8, 9, 7, 8, 9 });
                SetFilm(6, "Джокер", "Драма/триллер", new int[] { 7, 8, 9, 8 }, new int[] { 9, 8, 9, 10, 7 });
                SetFilm(7, "Довод", "Научная фантастика", new int[] { 6, 7, 5, 6 }, new int[] { 7, 6, 8, 5, 7 });
                SetFilm(8, "Форма воды", "Фэнтези/романтика", new int[] { 7, 8, 7, 6 }, new int[] { 8, 7, 8, 9, 7 });
                SetFilm(9, "Ла-Ла Ленд", "Мюзикл/романтика", new int[] { 8, 9, 8, 7 }, new int[] { 9, 8, 10, 9, 8 });
                SetFilm(10, "Зелёная книга", "Драма/комедия", new int[] { 8, 9, 8, 9 }, new int[] { 9, 9, 8, 9, 10 });
                SetFilm(11, "Маленькие женщины", "Драма", new int[] { 7, 8, 7, 8 }, new int[] { 8, 7, 9, 8, 8 });
                SetFilm(12, "Душа", "Анимация/драма", new int[] { 9, 9, 10, 8 }, new int[] { 9, 10, 9, 9, 10 });
                SetFilm(13, "Манк", "Драма/биография", new int[] { 7, 6, 8, 7 }, new int[] { 7, 6, 8, 7, 7 });
                SetFilm(14, "Минари", "Драма", new int[] { 8, 8, 9, 8 }, new int[] { 8, 9, 8, 8, 9 });
                SetFilm(15, "Номадленд", "Драма", new int[] { 8, 9, 8, 7 }, new int[] { 7, 8, 7, 8, 7 });
                SetFilm(16, "Вечные", "Супергероика", new int[] { 5, 6, 5, 6 }, new int[] { 7, 6, 8, 5, 6 });
                SetFilm(17, "Драйв моя машина", "Драма", new int[] { 9, 9, 8, 9 }, new int[] { 8, 9, 8, 9, 8 });
            }

            private void SetFilm(int index, string name, string genre, int[] jury, int[] audience)
            {
                names[index] = name;
                genres[index] = genre;
                juryScores[index] = jury;
                audienceScores[index] = audience;
            }

            private double GetJury(int index)
            {
                if (juryScores[index].Length == 0) return 0;
                int sum = 0;
                for (int i = 0; i < juryScores[index].Length; i++)
                    sum += juryScores[index][i];
                return sum / (double)juryScores[index].Length;
            }

            private double GetAudience(int index)
            {
                if (audienceScores[index].Length == 0) return 0;
                int sum = 0;
                for (int i = 0; i < audienceScores[index].Length; i++)
                    sum += audienceScores[index][i];
                return sum / (double)audienceScores[index].Length;
            }

            public double GetOverallRating(int index)
            {
                return (GetJury(index) + GetAudience(index)) / 2;
            }

            public void PrintListLine(int index)
            {
                Console.WriteLine($"{index + 1}. {names[index]} | {genres[index]} | Рейтинг: {GetOverallRating(index):F2}");
            }

            public void PrintFullInfo(int index)
            {
                Console.WriteLine($"Название: {names[index]}");
                Console.WriteLine($"Жанр: {genres[index]}");
                Console.WriteLine($"Зрители: {GetAudience(index):F2}");
                Console.WriteLine($"Жюри: {GetJury(index):F2}");
                Console.WriteLine($"Общий рейтинг: {GetOverallRating(index):F2}");
                Console.WriteLine();
            }

            public void PrintAllFilms()
            {
                Console.WriteLine("=== Фильмы нашего фестиваля ===\n");
                for (int i = 0; i < 18; i++)
                {
                    PrintListLine(i);
                }
                Console.WriteLine();
            }

            public void PrintSorted()
            {
                int[] order = new int[18];
                for (int i = 0; i < 18; i++) order[i] = i;
                for (int x = 0; x < 17; x++)
                {
                    for (int j = 0; j < 17 - x; j++)
                    {
                        if (GetOverallRating(order[j]) > GetOverallRating(order[j + 1]))
                        {
                            int temp = order[j];
                            order[j] = order[j + 1];
                            order[j + 1] = temp;
                        }
                    }
                }

                Console.WriteLine("=== От лучшего к худшему ===\n");
                for (int i = 17; i >= 0; i--)
                {
                    int idx = order[i];
                    Console.WriteLine($"{18 - i}. {names[idx]} | {genres[idx]} | Рейтинг: {GetOverallRating(idx):F2}");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Festival fest = new Festival();

            bool running = true;
            while (running)
            {
                Console.WriteLine("=== Добро пожаловать на кинофестиваль! ===");
                Console.WriteLine("1 - список фильмов");
                Console.WriteLine("2 - больше информации о фильме");
                Console.WriteLine("3 - от лучшего к худшему");
                Console.WriteLine("0 - выход");
                Console.Write("Выбери пункт: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Введите число\n");
                    continue;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:
                        fest.PrintAllFilms();
                        break;

                    case 2:
                        Console.Write("Введи номер фильма (1-18): ");
                        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 18)
                        {
                            fest.PrintFullInfo(num - 1);
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер\n");
                        }
                        break;

                    case 3:
                        fest.PrintSorted();
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет\n");
                        break;
                }
            }
        }




    }
}