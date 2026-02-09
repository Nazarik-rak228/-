
using System;
/*
 П-8-24 
Брагин Назар Практическая работа №3 
 */
public class Programm
{
    static double globalResult = 0.0;
    /// <summary>
    /// основной метод, вызывает тут все остальные методы, большая часть ввода и т.д.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать!");
        Console.WriteLine("Первая подпрограмма");
        Summa();
        Console.WriteLine("Вторая подпрограмма \n Введите первое число");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        double b = Convert.ToDouble(Console.ReadLine());
        Minus(a, b);
        Console.WriteLine("Третья программа");
        Console.WriteLine("Введите первое число");
        double e = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        double r = Convert.ToDouble(Console.ReadLine());
        double Um = 0;
        Umnozshenie(e, r, out Um);
        Console.WriteLine(Um);
        Console.WriteLine("Четвертая программа");
        double rez = Delenie();
        Console.WriteLine(rez);
        Console.WriteLine("Пятая подпрограмма");
        Console.WriteLine("Введите число");
        double num = Convert.ToDouble(Console.ReadLine()); ;
        Kvadrat(ref num);
        globalResult = num;
        Console.WriteLine($"Квадрат: {globalResult}");
    }
    /// <summary>
    /// вовзважу в квадрат без мат функций, лол
    /// </summary>
    /// <param name="value"></param>
    
    static void Kvadrat(ref double value)
    {
        value = value * value; 
    }
    /// <summary>
    /// слаживаем и выводим, 52.....................
    /// </summary>
    static void Summa() {
        int c = 4 + 48;
        Console.WriteLine( "Результат :  " + c);
    }
    /// <summary>
    /// минус с вводом из майн
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    static void Minus(double a, double b)
    {
        double x = a - b;
        Console.WriteLine(x);
    }
    /// <summary>
    /// умножаем
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    static double Umnozshenie(double a, double b, out double f)
    {
        f = a * b;
        return f;
    }
    /// <summary>
    /// Делим введенные значения
    /// </summary>
    /// <returns></returns>
    static double Delenie()
    {   double del = 0;
        Console.WriteLine("Введите первое число");
        double s = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите второе число");
        double g = Convert.ToDouble(Console.ReadLine());
        double v = s / g;
        return v;
    }
    











}
