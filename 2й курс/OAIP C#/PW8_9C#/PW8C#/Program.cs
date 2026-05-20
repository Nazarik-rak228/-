using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace PW8_9C
{
    internal class Program
    {
        class Film
        {
            protected string names;
            protected string genres;

            public Film(string name, string genre)
            {
                names = name;
                genres = genre;
            }
            public void PrintInfo(int index)
            {
                Console.WriteLine($"Название: {names[index]} Жанр: {genres[index]}");

            }

        }
        class FestivalFilm : Film
        {
            private int[] juryScores;
            private int[] audienceScores;

            public FestivalFilm(string name, string genre, int[] jury, int[] audience) : base(name, genre)
            {
                juryScores = jury;
                audienceScores = audience;

            }



            private double GetAverage(int[] arr)
            {
                if (arr.Length == 0) return 0;
                int sum = 0;
                foreach (int i in arr) { sum += i; }

                return sum / (double)arr.Length;
            }


            private double GetAudience()
            {
                return GetAverage(audienceScores);
            }

            private double GetJureScire()
            {
                return GetAverage(juryScores);
            }

            public double GetOverallRating()
            {
                return (GetJureScire() + GetAudience()) / 2;
            }

            public void PrintList()
            {
                Console.WriteLine($"Название: {names} Жанр: {genres} Общий рейтинг: {GetOverallRating():F2}");

            }
            public void PrintFullInfo()
            {
                Console.WriteLine($"Название: {names} Жанр: {genres}");
                Console.WriteLine($" Жанр: {genres}");
                Console.WriteLine($"Зрители: {GetAudience():F2}");
                Console.WriteLine($"Жюри: {GetJureScire():F2}");
                Console.WriteLine($"Общий рейтинг: {GetOverallRating():F2}");
                Console.WriteLine();
            }


            public static void PrintSorted(FestivalFilm[] films)
            {
                FestivalFilm[] sorted = new FestivalFilm[films.Length];
                for (int i = 0; i < films.Length; i++)
                {
                    sorted[i] = films[i];
                }
                for (int i = 0; i < sorted.Length; i++)
                {
                    for (int j = 0; j < sorted.Length -1 - i; j++)
                    {
                        if (sorted[j].GetOverallRating() > sorted[j + 1].GetOverallRating())
                        {
                            var temp = sorted[j];
                            sorted[j] = sorted[j + 1];
                            sorted[j + 1] = temp;
                        }
                    }
                }

                Console.WriteLine("=== От лучшего к худшему ===\n");
                for (int i =sorted.Length-1; i >= 0 ; i--)
                {
                    //(int i = 17; i >= 0; i--)
                    Console.Write($"{i+1}. ");
                    sorted[i].PrintList();
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {


            FestivalFilm[] fest = new FestivalFilm[18];

            fest[0] = new FestivalFilm("Паразиты", "Триллер", new int[] { 9, 8, 9 }, new int[] { 9, 8, 10, 9 });
            fest[1] = new FestivalFilm("Оппенгеймер", "Драма", new int[] { 8, 7, 8 }, new int[] { 9, 8 });
            fest[2] = new FestivalFilm("Барби", "Комедия", new int[] { 6, 7, 6 }, new int[] { 8, 9, 8, 7 });
            fest[3] = new FestivalFilm("Дюна 2", "Фантастика", new int[] { 5, 6, 4 }, new int[] { 5, 6, 4 });
            fest[4] = new FestivalFilm("Всё везде и сразу", "Фантастика/комедия", new int[] { 9, 10, 9, 8 }, new int[] { 9, 8, 10, 9, 9 });
            fest[5] = new FestivalFilm("1917", "Военный/драма", new int[] { 8, 9, 8, 7 }, new int[] { 8, 9, 7, 8, 9 });
            fest[6] = new FestivalFilm("Джокер", "Драма/триллер", new int[] { 7, 8, 9, 8 }, new int[] { 9, 8, 9, 10, 7 });
            fest[7] = new FestivalFilm("Довод", "Научная фантастика", new int[] { 6, 7, 5, 6 }, new int[] { 7, 6, 8, 5, 7 });
            fest[8] = new FestivalFilm("Форма воды", "Фэнтези/романтика", new int[] { 7, 8, 7, 6 }, new int[] { 8, 7, 8, 9, 7 });
            fest[9] = new FestivalFilm("Ла-Ла Ленд", "Мюзикл/романтика", new int[] { 8, 9, 8, 7 }, new int[] { 9, 8, 10, 9, 8 });
            fest[10] = new FestivalFilm("Зелёная книга", "Драма/комедия", new int[] { 8, 9, 8, 9 }, new int[] { 9, 9, 8, 9, 10 });
            fest[11] = new FestivalFilm("Маленькие женщины", "Драма", new int[] { 7, 8, 7, 8 }, new int[] { 8, 7, 9, 8, 8 });
            fest[12] = new FestivalFilm("Душа", "Анимация/драма", new int[] { 9, 9, 10, 8 }, new int[] { 9, 10, 9, 9, 10 });
            fest[13] = new FestivalFilm("Манк", "Драма/биография", new int[] { 7, 6, 8, 7 }, new int[] { 7, 6, 8, 7, 7 });
            fest[14] = new FestivalFilm("Минари", "Драма", new int[] { 8, 8, 9, 8 }, new int[] { 8, 9, 8, 8, 9 });
            fest[15] = new FestivalFilm("Номадленд", "Драма", new int[] { 8, 9, 8, 7 }, new int[] { 7, 8, 7, 8, 7 });
            fest[16] = new FestivalFilm("Вечные", "Супергероика", new int[] { 5, 6, 5, 6 }, new int[] { 7, 6, 8, 5, 6 });
            fest[17] = new FestivalFilm("Драйв моя машина", "Драма", new int[] { 9, 9, 8, 9 }, new int[] { 8, 9, 8, 9, 8 });


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
                        for (int i = 0; i < fest.Length; i++)
                        {
                            Console.Write($"{i + 1}. ");
                            fest[i].PrintList();
                        }
                        break;

                    case 2:
                        Console.Write("Введи номер фильма (1-18): ");
                        if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= 18)
                        {
                            fest[num-1].PrintFullInfo();
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер\n");
                        }
                        break;

                    case 3:
                        FestivalFilm.PrintSorted(fest);
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет\n");
                        break;
                }
            }
        }
    }
}