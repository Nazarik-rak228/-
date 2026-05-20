import java.util.Scanner;
public class Main {
    public static void main(String[] args) {
        double pervoe, vtoroe;
        Scanner loh = new Scanner(System.in);
        System.out.print("Введите первое число ");
        pervoe = loh.nextDouble();
        System.out.print("Введите второе число ");
        vtoroe = loh.nextDouble();
        System.out.println("итог при сложении");
        System.out.println(pervoe+vtoroe);
        System.out.println("итог при вычитание");
        System.out.println(pervoe-vtoroe);
        System.out.println("итог при умножение");
        System.out.println(pervoe*vtoroe);
        System.out.println("итог при деление");
        System.out.println(pervoe/vtoroe);
        System.out.println("итог при делении с остатком");
        System.out.println(pervoe%vtoroe);
        System.out.println("итог при возведении первого числа в степень второго");
        System.out.println(Math.pow(pervoe, vtoroe));
        System.out.println("Среднее арефметическое");
        System.out.println((pervoe+vtoroe)/2);
        System.out.println("Поставьте 5, ну пожалуйста!");

    }
}