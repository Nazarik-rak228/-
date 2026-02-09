using System.Text;

internal class program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать");
        Console.WriteLine("Выберите задание (введите 1-4)");
        int insert = int.Parse(Console.ReadLine());
        switch (insert)
        {
            case (1): //Дано целое число N (1 ≤ N ≤ 26). Выведите N первых заглавных букв латинского алфавита.
                                Console.WriteLine("Введите число:");
                int n = int.Parse(Console.ReadLine());
                if (n <= 26 | n >= 0 )
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.WriteLine((char)('A' + i));
                    }
                }
                else
                {
                    Console.WriteLine("Число должно быть не больше 26 и не меньше 0!");
                }
                break;
            case (2)://Дан символ C и строка S. Удвоить каждое вхождение символа C в строке S.
                Console.WriteLine("Введите символ и строку! ");
                char C = Console.ReadLine()[0];
                string S = Console.ReadLine();
                StringBuilder result = new StringBuilder();
                foreach (char ch in S)
                {
                    result.Append(ch);
                    if (ch == C)
                    {
                        result.Append(C);
                    }
                }
                Console.WriteLine(result.ToString());
                break;
            case (3):// Дана строка с русскими словами в верхнем регистре. Найдите количество слов, которые содержат хотя бы одну букву «А».
                Console.WriteLine("Введите предложение на русском!" );
                string line = Console.ReadLine().ToUpper();
                string[] words = line.Split(' ');
                int count = 0;
                foreach (string w in words)
                {
                    if (w.Contains('А')) 
                    {
                        count++;
                    }
                    
                }
                Console.WriteLine(count);
                break;
            case (4): //Дана строка. Преобразуйте её в строку, которая будет представлять её ASCII код в шестнадцатеричной системе.
                Console.WriteLine("Введите строку");
                string line2 = Console.ReadLine();
                StringBuilder result2 = new StringBuilder();
                foreach (char ch in line2)
                {
                    result2.Append(((int)ch).ToString("X2")); // X2 для двухзначного hex
                }
                Console.WriteLine(result2.ToString());

                break;
        }
    }
    
}