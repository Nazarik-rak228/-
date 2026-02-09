using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Channels;
internal class program
{
    static void Main(string[] args)

    {

        while (true)
        {
            Console.WriteLine("Добро пожаловать");
            Console.WriteLine("Выберите задание:");
            Console.WriteLine("Дано целое число N(1 ≤ N ≤ 26).Выведите N первых заглавных букв латинского алфавита.");
            Console.WriteLine("Дан символ C и строка S. Удвоить каждое вхождение символа C в строке S.");
            Console.WriteLine("Дана строка с русскими словами в верхнем регистре. Найдите количество слов, которые содержат хотя бы одну букву «А».");
            Console.WriteLine("Дана строка. Преобразуйте её в строку, которая будет представлять её ASCII код в шестнадцатеричной системе.");
            Console.WriteLine("Выйти из программы");
            int insert = int.Parse(Console.ReadLine());
            
            switch (insert)
            {
                case (1): 
                    TaskFirst();
                    break;
                case (2):
                    SecondTask();
                    break;
                case (3):
                    TaskThree();
                    break;
                case (4):
                    TaskThour();
                    break;
                case (5):
                    break;
            }
        }
    }
    static void TaskFirst()//Дано целое число N (1 ≤ N ≤ 26). Выведите N первых заглавных букв латинского алфавита.
    {
        
        Console.WriteLine("Введите путь к файлу:");
        string Pathfirst = Console.ReadLine();
        string na = File.ReadAllText(Pathfirst);
        int n = Convert.ToInt32(na);

        if (n >= 1 && n <= 26)  
        {
            char[] ArrayOtvet = new char[n];  

            for (int i = 0; i < n; i++)
            {
                char OtvetOdin = (char)('A' + i);
                Console.WriteLine(OtvetOdin);  

                ArrayOtvet[i] = OtvetOdin;  
            }

            // Копируем массив в строку и выводим как строку
            string resultString = new string(ArrayOtvet);
            Console.WriteLine("Строка из массива: " + resultString);
            Console.WriteLine("Ответ будет записан или добавлен в файл, введите путь");
            String PathOtvet1 = Console.ReadLine();

            File.AppendAllText(PathOtvet1, resultString);
        }
        else
        {
            Console.WriteLine("N должно быть в диапазоне от 1 до 26.");
        }
        

    }
    static void SecondTask()//Дан символ C и строка S. Удвоить каждое вхождение символа C в строке S.
    {
        Console.WriteLine("Введите путь ");
        string Pathsecond1 = Console.ReadLine();
        string[] masiv = File.ReadAllLines(Pathsecond1);
        char C = Convert.ToChar(masiv[0]);
        string S = string.Join(" ", masiv.Skip(0));
        StringBuilder result = new StringBuilder();
        foreach (char ch in S)
        {
            result.Append(ch);
            if (ch == C)
            {
                result.Append(C);
            }
        }
        string OtvetDva = result.ToString();
        Console.WriteLine(OtvetDva);
        Console.WriteLine("Ответ будет записан или добавлен в файл, введите путь");
        String PathOtvet2 = Console.ReadLine();
        File.AppendAllText(PathOtvet2, OtvetDva);

    }
    static void TaskThree() // Дана строка с русскими словами в верхнем регистре. Найдите количество слов, которые содержат хотя бы одну букву «А».
    {
        Console.WriteLine("Введите путь");
        string PathThree = Console.ReadLine();
        string text = File.ReadAllText(PathThree);
        string line = text.ToUpper();
        string[] words = line.Split(' ');
        int count = 0;
        foreach (string w in words)
        {
            if (w.Contains('А'))
            {
                count++;
            }

        }
        Console.WriteLine("Ответ");
        Console.WriteLine(count);
        Console.WriteLine("Ответ будет записан или добавлен в файл, введите путь");
        String PathOtvet2 = Console.ReadLine();
        File.AppendAllText(PathOtvet2,Convert.ToString(count));
    }
    static void TaskThour() //Дана строка. Преобразуйте её в строку, которая будет представлять её ASCII код в шестнадцатеричной системе.
    {
        Console.WriteLine("Введите путь:");
        string PathThour = Console.ReadLine();
        string line2 = File.ReadAllText(PathThour);

        StringBuilder result2 = new StringBuilder();
        foreach (char ch in line2)
        {
            result2.Append(((int)ch).ToString("X2")); // X2 для двухзначного hex
        }
        Console.WriteLine(result2.ToString());
    }
}   


