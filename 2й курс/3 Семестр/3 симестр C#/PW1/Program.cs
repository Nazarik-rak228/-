using System.ComponentModel.Design;

internal class Program
{
    /// <summary>
    /// Основная часть программы, принимает переменные,
    /// выдает сообщения и приветствие, делает итоговое действие.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать");
        Console.WriteLine("Программа выполняет такие вычисления: \n(-2*c + d*82) / tg(a/4 - 1)");
        Console.WriteLine("Введите число - a");
        double num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число - c");
        double num3 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Введите число - d");
        double num4 = Convert.ToInt32(Console.ReadLine());
        double numerator_res = 0;
        double denominator_res = 0;
        Numerator(num3, num4, ref numerator_res);
        Denominator(num1,ref denominator_res);
        if (denominator_res == 0)
        {
            Console.WriteLine("В знаменатиле получился 0");
            Console.WriteLine(numerator_res);
            Console.WriteLine(denominator_res);
        }
        else
        {
            double denominator_res_finel = numerator_res / denominator_res;
            Console.WriteLine(denominator_res_finel);
        }
        
    }
    /// <summary>
    /// вычисляет первую часть примера
    /// </summary>
    /// <param name="num3"></param> 
    /// <param name="num4"></param>
    /// <returns></returns>
    static double Numerator(double num3, double num4,ref double numerator_res)
    {
        numerator_res = (-2 * num3) + (num4 * 82);
        return numerator_res;
    } 
    /// <summary>
    /// вычисляет вторую часть примера
    /// </summary>
    /// <param name="num1"></param>
    /// <returns></returns>
    static double Denominator(double num1, ref double denominator_res)
    {
        denominator_res = Math.Tan((num1 / 4) - 1);
        return denominator_res;
    }
    
}