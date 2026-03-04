import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int a = 0;
        int b = 1;
        int c = 0;
        System.out.println("Введите положительные целые числа (для завершения введите отрицательное число):");

        while (true) {
            System.out.print("Число: ");
            int number = scanner.nextInt();

            if (number < 0) {
                break;
            }

            a += number;
            b *= number;
            c++;
            System.out.println("Результаты:");
            System.out.println("Сумма всех чисел: " + a);
            System.out.println("Произведение всех чисел: " + b);
            System.out.println("Количество введенных чисел: " + c);
            if (c > 0) {
                double average = (double) a / c;
                System.out.println("Среднее арифметическое: " + average);
            } else {
                System.out.println("Среднее арифметическое: не определено (не было введено положительных чисел)");
            }
        }
        scanner.close();  // Бонус: закрываем сканер, чтоб не было утечек
    }
}