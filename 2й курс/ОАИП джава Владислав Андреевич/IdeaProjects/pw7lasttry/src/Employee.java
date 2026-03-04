public class Employee extends User {
    public Employee(String login, String password) {
        super(login, password);
    }
    @Override
    public void showMenu() {
        System.out.println("Меню сотрудника:");
        System.out.println("1. Добавить товар");
        System.out.println("2. Показать товары");
        System.out.println("3. Редактировать товар");
        System.out.println("4. Удалить товар");
        System.out.println("5. Выход");
    }
}
