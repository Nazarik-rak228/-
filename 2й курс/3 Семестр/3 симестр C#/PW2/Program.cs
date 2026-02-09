using System;
using System.Linq.Expressions;
/*
 Брагин Назар
 П-8-24
Практическая работа 2
 
 */
class Program
{
    /// <summary>
    /// короче, программа
    /// </summary>
    static void Main()
    {
        
        ///Ввод данных
        Console.Write("Введите начало диапазона: ");
        int start = int.Parse(Console.ReadLine());
        Console.Write("Введите конец диапазона: ");
        int end = int.Parse(Console.ReadLine());

        // Проверка
        if (start > end)
        {
            Console.WriteLine("Ошибка: начало диапазона должно быть меньше или равно концу.");
            return;
        }

        // Вывод чисел диапазона
        Console.Write("Числа диапазона: ");
        for (int num = start; num <= end; num++)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine(); // Переход на новую строку

        // Количество чисел
        int count = end - start + 1;
        Console.WriteLine($"Количество чисел: {count}");

        // Расчёт суммы и среднего
        double totalSum = 0;
        for (int num = start; num <= end; num++)
        {
            totalSum += num;
        }
        double average = totalSum / count;

        // Вывод результата
        Console.WriteLine($"Среднее арифметическое: {average:F2}");
        Console.WriteLine("Хотите посчитать сумму последовательности?  (Да/Нет)");
        string otvet = Console.ReadLine();
        otvet = otvet.ToLower();
        switch (otvet)
        {
            case ("да"):
                Posledovatelnost();
                break;
            case ("нет"):
                Console.WriteLine(otvet + "Как хотите...");
                break;
        }
    }
    static void Posledovatelnost()
    {
        // Ввод данных
        Console.Write("Введите натуральное число N (≥1): ");
        int N = int.Parse(Console.ReadLine());
        if (N < 1)
        {
            Console.WriteLine("Ошибка: N должно быть ≥1.");
            return;
        }

        Console.Write("Введите вещественное число A: ");
        double A = double.Parse(Console.ReadLine());

        // Расчёт суммы с использованием while
        double S = 0.0;
        int power = 1;
        int i = 1;
        while (i <= N)
        {
            S += Math.Pow(A, power);
            power++;
            i++;
        }

        // Вывод результата
        Console.WriteLine($"Сумма S для N={N}, A={A}: {S:F4}");
    }
}