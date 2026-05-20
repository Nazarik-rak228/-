import java.util.Scanner;
    public class ReverseNumber {
        public static void main (String[] args) {
        Scanner firsscanner = new Scanner(System.in);
        long number = 0; // инициализируем переменную, лонг - 18 цифр число, больше инт. 0 - просто чтобы инициализируют
        boolean IsValid = false; // переменная, если правильно, то не повторяем

        do {
            System.out.print("Введите положительное целое число:");
            if (firsscanner.hasNextLong()) {
                number = firsscanner.nextLong();
                if (number > 0) {
                    IsValid = true;
                }
                else {
                    System.out.print("Вы ввели отрицательное число!");
                }
            }
            else {
                System.out.print("Похоже, вы ввели не целое число, попробуйте снова!");
                firsscanner.next(); // очистили буфер
            }
        }
        while (!IsValid);

        System.out.print("Обратный порядок:");
        StringBuilder reversed = new StringBuilder(); // это что то типо блокнота, в который мы можем добавить какой то символ
        long temp = number;
        while (temp > 0) {
            long digit = temp % 10;
            reversed.append(digit);
            temp /= 10;

        }
        System.out.print(reversed);



    }
}