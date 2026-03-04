import java.util.Scanner;

public class Main {
    public static int countDigits(int n) {
        if (n < 0) {
            n = -n;
        }
        if (n < 10) {
            return 1;
        }
        return 1 + countDigits(n / 10);
    }
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.print("Введи число: ");
        int number = scanner.nextInt();
        int result = countDigits(number);
        System.out.println("Цифр: " + result);
    }
}