public class Customer extends User{
    public Customer(String login, String password) {
        super(login, password);
    }
    @Override
    public void showMenu() {
        System.out.println("Меню клиента:");
        System.out.println("1. Показать товары");
        System.out.println("2. Выход");
    }
}
