import java.util.Scanner;
public class Insert {
    public int insertNumber(){
        Scanner scanner = new Scanner(System.in);
        int num = scanner.nextInt();
        return num;

    }
    public char insertOperation(){
        Scanner scanner = new Scanner(System.in);
        char symb = scanner.next().charAt(0);
        return symb;
    }
}
