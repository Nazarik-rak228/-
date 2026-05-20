//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        String name ="aboltus";
        String surname ="Batkovich";

        User user = new User(1,name,surname," ",34);
        System.out.print(user.getName());

        user.setName("Denis");
        System.out.print(user.getName() + " " + user.getSurname());
    }
}