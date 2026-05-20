namespace PW7C
{
    internal class Program
    {internal struct FilmInfo
        {
            public int Num;
            public string Name;
            public string Ganre;
            public int[] Jury_scores;
            public int[] Audience_scores;
        }

        public class Move
        {
            public FilmInfo Info;

            public Move(int num, string name, string ganre, int[] jury_scores, int[] audience_scores)
            {
                Info = new FilmInfo
                {
                    Num = num,
                    Name = name,
                    Ganre = ganre,
                    Jury_scores = jury_scores,
                    Audience_scores = audience_scores
                };
            }

            public double GetJury()
            {
                if (Info.Jury_scores.Length == 0) return 0;
                int sum = 0;
                for (int i = 0; i < Info.Jury_scores.Length; i++)
                {
                    sum += Info.Jury_scores[i];
                }
                return sum / (double)Info.Jury_scores.Length;
            }

            public double GetAudience()
            {
                if (Info.Audience_scores.Length == 0) return 0;
                int sum = 0;
                for (int i = 0; i < Info.Audience_scores.Length; i++)
                {
                    sum += Info.Audience_scores[i];
                }
                return sum / (double)Info.Audience_scores.Length;
            }

            public double OverallRating()
            {
                return (GetJury() + GetAudience()) / 2;
            }

            public string ListOfFilms()
            {
                return Info.Num + ". " + Info.Name + " | " + Info.Ganre + " | Рейтинг: " + OverallRating();
            }

            public string GetMoreInfo()
            {
                return "Название: " + Info.Name + "\n" +
                       "Жанр: " + Info.Ganre + "\n" +
                       "Зрители: " + GetAudience() + "\n" +
                       "Жюри: " + GetJury() + "\n" +
                       "Общий рейтинг: " + OverallRating();
            }

            public void PrintListLine()
            {
                Console.WriteLine(ListOfFilms());
            }

            public void PrintFullInfo()
            {
                Console.WriteLine(GetMoreInfo());
            }
        }

        static void Main(string[] args)
        {
            Move[] films = new Move[18];

            films[0] = new Move(1, "Паразиты", "Триллер", new int[] { 9, 8, 9 }, new int[] { 9, 8, 10, 9 });
            films[1] = new Move(2, "Оппенгеймер", "Драма", new int[] { 8, 7, 8 }, new int[] { 9, 8 });
            films[2] = new Move(3, "Барби", "Комедия", new int[] { 6, 7, 6 }, new int[] { 8, 9, 8, 7 });
            films[3] = new Move(4, "Дюна 2", "Фантастика", new int[] { 5, 6, 4 }, new int[] { 5, 6, 4 });
            films[4] = new Move(5, "Всё везде и сразу", "Фантастика/комедия", new int[] { 9, 10, 9, 8 }, new int[] { 9, 8, 10, 9, 9 });
            films[5] = new Move(6, "1917", "Военный/драма", new int[] { 8, 9, 8, 7 }, new int[] { 8, 9, 7, 8, 9 });
            films[6] = new Move(7, "Джокер", "Драма/триллер", new int[] { 7, 8, 9, 8 }, new int[] { 9, 8, 9, 10, 7 });
            films[7] = new Move(8, "Довод", "Научная фантастика", new int[] { 6, 7, 5, 6 }, new int[] { 7, 6, 8, 5, 7 });
            films[8] = new Move(9, "Форма воды", "Фэнтези/романтика", new int[] { 7, 8, 7, 6 }, new int[] { 8, 7, 8, 9, 7 });
            films[9] = new Move(10, "Ла-Ла Ленд", "Мюзикл/романтика", new int[] { 8, 9, 8, 7 }, new int[] { 9, 8, 10, 9, 8 });
            films[10] = new Move(11, "Зелёная книга", "Драма/комедия", new int[] { 8, 9, 8, 9 }, new int[] { 9, 9, 8, 9, 10 });
            films[11] = new Move(12, "Маленькие женщины", "Драма", new int[] { 7, 8, 7, 8 }, new int[] { 8, 7, 9, 8, 8 });
            films[12] = new Move(13, "Душа", "Анимация/драма", new int[] { 9, 9, 10, 8 }, new int[] { 9, 10, 9, 9, 10 });
            films[13] = new Move(14, "Манк", "Драма/биография", new int[] { 7, 6, 8, 7 }, new int[] { 7, 6, 8, 7, 7 });
            films[14] = new Move(15, "Минари", "Драма", new int[] { 8, 8, 9, 8 }, new int[] { 8, 9, 8, 8, 9 });
            films[15] = new Move(16, "Номадленд", "Драма", new int[] { 8, 9, 8, 7 }, new int[] { 7, 8, 7, 8, 7 });
            films[16] = new Move(17, "Вечные", "Супергероика", new int[] { 5, 6, 5, 6 }, new int[] { 7, 6, 8, 5, 6 });
            films[17] = new Move(18, "Драйв моя машина", "Драма", new int[] { 9, 9, 8, 9 }, new int[] { 8, 9, 8, 9, 8 });

            bool running = true;
            while (running)
            {
                
                Console.WriteLine("=== Добро пожаловать на кинофестиваль! ===");
                Console.WriteLine("1 - список фильмов");
                Console.WriteLine("2 - больше информации о фильме");
                Console.WriteLine("3 - от лучшего к худшему");
                Console.WriteLine("0 - выход");
                Console.Write("Выбери пункт: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 0:
                        running = false;
                        break;

                    case 1:
                        Console.WriteLine("=== Фильмы нашего фестиваля ===\n");
                        for (int i = 0; i < films.Length; i++)
                        {
                            if (films[i] != null)
                            {
                                films[i].PrintListLine();
                            }
                        }
                        break;
                    case 2:
                        Console.Write("Введи номер фильма (1-18): ");
                        int numInput = Convert.ToInt32(Console.ReadLine());
                        if (numInput<=17 | numInput >=0 )
                        {
                            films[numInput - 1].PrintFullInfo();
                        }
                        else
                        {
                            Console.WriteLine("Неверный номер или фильм не найден");
                        }
                        break;
                    case 3:
                        Move[] sorted = (Move[])films.Clone();

                        // пузырьковая сортировка от худшего к лучшему
                        for (int x = 0; x < sorted.Length - 1; x++)
                        {
                            for (int j = 0; j < sorted.Length - 1 - x; j++)
                            {
                                if (sorted[j].OverallRating() > sorted[j + 1].OverallRating())
                                {
                                    Move temp = sorted[j];
                                    sorted[j] = sorted[j + 1];
                                    sorted[j + 1] = temp;
                                }
                            }
                        }

                        Console.WriteLine("=== От лучшего к худшему ===\n");
                        for (int i = sorted.Length - 1; i >= 0; i--)
                        {
                            Console.WriteLine((sorted.Length - i) + ". " + sorted[i].ListOfFilms());
                        }
                        break;

                    default:
                        Console.WriteLine("Такого пункта нет");
                        break;
                }
            }
        }
    }
}