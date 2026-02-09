using System.Runtime.Intrinsics.Arm;

internal class Program
{
    static void Main(string[] args)
    {
       /* string text = "P-8-24"; // создает переменную сразу, грузит пк
        string s = new string('A', 10); // динамический, это переменная создасться только во время выполнения, оптимизирована
        string S2 = new string(new char[] { 'A', 'B', 'C' }); // другой способ
        Console.WriteLine(text);        
        Console.ReadLine();*/
        string text2 = "C:\\AmyRepositoryONE"; //   \a создает короткое звуковое оповищение винды, \n переносит строку, \\ пишет \,
                                               //   это чтобы небыло конфликта с \а ,если лень, ставь @ перед строкой, и \ как оператор будет игнорироваться
        /*Console.WriteLine(text2.Length); // считает символы
        for (int i = 0; i < text2.Length; i++)
        {
            Console.WriteLine(text2[i]);
        }
        foreach (char c in text2) // показываем все символы, в прошлом мы считали как части списка, тут так

        {
            string text = "P-8-24";
            Console.WriteLine(c);
            Console.WriteLine($"vs {text2}"); // моно так
            Console.WriteLine("vs {1}",text2); // или так
            
        }*/
        string d = "C:\\Users\\      nazar\\Music\\мемы музыка";
        Console.WriteLine(d.ToUpper());
        Console.WriteLine(d.ToLower());
        Console.WriteLine(d.Trim()); // лишние пробелы убирает
        Console.WriteLine(text2.StartsWith('C'));
        Console.WriteLine(text2.EndsWith("ONE"));
        Console.WriteLine(d.Contains("Users"));// ищем первое появление слова
        Console.WriteLine(d.IndexOf("Users"));
        Console.WriteLine(d.LastIndexOf("Users")); // ищет последнее 
        string text6 = text2.Substring(3, 12); // собираем все символы от одного до другого и копирование этого промежутка
        Console.WriteLine(text6.Insert(0,"sadadsadasdasdasd"));
        Console.WriteLine(text6.Remove(0,12));
        int code = 'A';
        Console.WriteLine(code); // вывели код этого символа в юникоде
        int code2 = 'B';
        char B = (char)code2;
        Console.WriteLine(B);
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine(i + " - " + (char)i);
        }
        Console.ReadLine();
    }
}
