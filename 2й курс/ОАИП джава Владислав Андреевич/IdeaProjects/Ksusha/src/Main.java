import java.util.Scanner;
public class Main{
    public static void main(String[] args){
        Scanner scanner = new Scanner(System.in);

        System.out.println("введите первое число ");
        float chislo1;
        chislo1 = scanner.nextFloat();

        System.out.print("введите второе число ");
        float chislo2;
        chislo2 = scanner.nextFloat();

        float summa = chislo1 + chislo2;
        float raznost = chislo1 - chislo2;
        float umnozenie = chislo1 * chislo2;
        float delenie = chislo1 / chislo2;
        float delsost = chislo1 % chislo2;
        double vozvedenie = Math.pow(chislo1, chislo2);
        float srednee = (chislo1 + chislo2)/2;

        System.out.println("получившиеся результаты " );
        System.out.println("сумма чисел " + summa);
        System.out.println("разность чисел " + raznost);
        System.out.print("произведение чисел " + umnozenie);
        System.out.print("частное чисел " + delenie);
        System.out.print("остаток от деления чисел " + delsost);
        System.out.print("возведение первого числа в степень второго " + vozvedenie);
        System.out.print("среднее арифметическое чисел " + srednee);

        scanner.close();




    }
}