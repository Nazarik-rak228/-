import java.util.Scanner;

public class UserService {
    private User[] users = new User[50];
    private int userCount = 0;

    public void register(Scanner scanner) {

        System.out.println("Выберите роль:");
        System.out.println("1. Сотрудник");
        System.out.println("2. Клиент");

        int role = scanner.nextInt();
        scanner.nextLine();

        System.out.println("Введите логин:");
        String login = scanner.nextLine();

        System.out.println("Введите пароль:");
        String password = scanner.nextLine();

        if (role == 1) {
            users[userCount] = new Employee(login, password);
        } else {
            users[userCount] = new Customer(login, password);
        }

        userCount++;
    }

    public User login(Scanner scanner) {

        System.out.println("Введите логин:");
        String login = scanner.nextLine();

        System.out.println("Введите пароль:");
        String password = scanner.nextLine();

        for (int i = 0; i < userCount; i++) {
            if (users[i].getLogin().equals(login)
                    && users[i].getPassword().equals(password)) {
                return users[i];
            }
        }

        return null;
    }
    public User[] getUsers() {
        return users;
    }

    public int getUserCount() {
        return userCount;
    }

    public void setUserCount(int userCount) {
        this.userCount = userCount;
    }
    public void addLoadedUser(User user) {
        users[userCount] = user;
        userCount++;
    }

    public void setUsers(User[] users) {
        this.users = users;
    }
}
