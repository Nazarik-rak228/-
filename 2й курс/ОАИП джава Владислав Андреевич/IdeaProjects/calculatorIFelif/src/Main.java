import java.util.Scanner;
public class Main {
    public static void main(String[] args) {
        System.out.println("добро пождаловать в калькулятор");
        System.out.println("доступные операции:");
        System.out.println("Сложение: + ");
        System.out.println("Вычетание: - ");
        System.out.println("Деление: / ");
        System.out.println("Деление с остатком: % ");
        System.out.println("Умножение: * ");
        double pervoe, vtoroe;
        Scanner loh = new Scanner(System.in);
        System.out.println("Введите первое число ");
        pervoe = loh.nextDouble();
        System.out.println("Введите оператор");
        String znak = loh.next();
        System.out.println("Введите второе число ");
        vtoroe = loh.nextDouble();
        if (znak.equals("+")) {
            System.out.print("итог при сложении: ");
            System.out.print(pervoe+vtoroe);
        }
        else if (znak.equals("-")) {
            System.out.print("итог при вычитание: ");
            System.out.print(pervoe-vtoroe);
        }
        else if (znak.equals("*")) {
            System.out.print("итог при умножение: ");
            System.out.print(pervoe*vtoroe);
        }
        else if (znak.equals("/")) {
            System.out.print("итог при деление: ");
            if (vtoroe != 0)
            {
                System.out.print(pervoe / vtoroe);
            }
            else {
                System.out.print("На ноль делить нельзя! [вообще, получится бесконечность, но не у нас :) ] ");
            }
        }
        else if (znak.equals("%")){
            System.out.print("итог при делении с остатком: ");
            if (vtoroe != 0)
            {
                System.out.print(pervoe%vtoroe);
            }
            else {System.out.print("На ноль делить нельзя! [вообще, получится бесконечность, но не у нас :) ] ");
            }
        }
        else {System.out.print("Неверный оператор");}

    }
}