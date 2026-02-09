
/*Console.WriteLine(Math.PI);
Console.WriteLine(Math.Abs(1212)); // выводит модуль числа
Console.WriteLine(Math.Sqrt(12)); // квадратный корень
Console.WriteLine(Math.Pow(23,2)); // значение возвезти в степень
Console.WriteLine(Math.Log10(45));// понятно
Console.WriteLine(Math.Cos(45));// понятно
Console.WriteLine(Math.PI);
int score = 70;
string s = score >= 70 ? "фвфы" : "вфывы";
Console.WriteLine(s);


Console.WriteLine(Math.PI);
Console.WriteLine(Math.PI);
bool skemto = true;
Console.WriteLine("Введи возвраст ");
int age = Convert.ToInt16(Console.ReadLine() );

if (age >= 14 && skemto == true) {
    Console.WriteLine("C родаками? ");
    string otvet = Console.ReadLine();
    if (otvet == "Да")
        Console.WriteLine("ты принят в клуб");
    else {
        Console.WriteLine(age + "!?!?!?!?!? пошел отсуда, щенок");
    }

}
else
    Console.WriteLine(age + "!?!?!?!?!? пошел отсуда, щенок");

int i = 0;
while (i <10)
{
    Console.Write("LOH, ");
    i++;
    Console.WriteLine(i);
}
do
{
    Console.Write("LOH, ");
    i++;
}
while (i < 10);
{
    Console.Write("LOH, ");
    i++;
    Console.WriteLine(i);
}

int i = 0;
for (; ; ) // вид бесконечного цикла короч, сначала говорим что у нас за i, потом условие выполнения, затем мы можем по титогу сделать что то с I

{
    Console.WriteLine(i++);
}


for (int i = 10; i > 10;i-- ) 

{
    Console.WriteLine(i++);
}
*/
int n  = Convert.ToInt32(Console.ReadLine());
bool plus  = true;
int znam = 2;
double sum = 1;

sum = sum + (1 / znam);
for (znam = 2; znam < n; znam++)
{
    if (plus = true)
    {
        sum = sum - (1.0 / znam);
        plus = false;
    }
    else {
        sum = sum + (1.0 / znam);
        plus = true;

    }

}Console.WriteLine(sum);