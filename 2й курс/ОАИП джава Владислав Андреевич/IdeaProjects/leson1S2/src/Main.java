
public class Main {
    public static void main(String[] args) {
        Menu menu = new Menu();
        Operations operations = new Operations();
        Insert insert = new Insert();

        menu.welcom();
        menu.shownumber();
        int one = insert.insertNumber();
        int two = insert.insertNumber();

        menu.showOperations();
        char operation = insert.insertOperation();
        double result = 0;
        switch (operation){
            case '+':
                result = operations.plus(one,two);
                break;
            case '-':
                result = operations.minus(one,two);
                break;
            case '*':
                result = operations.mnojh(one,two);
                break;
            case '/':
                result = operations.del(one,two);
                break;
        }
        menu.showResult(result);

    }

}