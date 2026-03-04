import java.util.Scanner;

public class Main {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        ProductService productService = new ProductService();
        UserService userService = new UserService();
        FileService fileService = new FileService();

        fileService.loadProducts(productService);
        fileService.loadUsers(userService);

        System.out.println("1. Регистрация");
        System.out.println("2. Авторизация");

        int startChoice = scanner.nextInt();
        scanner.nextLine();

        if (startChoice == 1) {
            userService.register(scanner);
        }

        User currentUser = userService.login(scanner);

        if (currentUser == null) {
            System.out.println("Ошибка входа");
            return;
        }

        while (true) {
            currentUser.showMenu();
            int choice = scanner.nextInt();
            scanner.nextLine();
            if (currentUser instanceof Employee) {

                if (choice == 1) {
                    productService.addProduct(scanner);
                } else if (choice == 2) {
                    productService.showProducts();
                } else if (choice == 3) {
                    productService.editProduct(scanner);
                } else if (choice == 4) {
                    productService.deleteProduct(scanner);
                } else if (choice == 5) {
                    fileService.saveProducts(productService);
                    break;
                }

            }
            else if (currentUser instanceof Customer) {

                if (choice == 1) {
                    productService.showProducts();
                } else if (choice == 2) {
                    fileService.saveUsers(userService);
                    break;
                }

            }
        }

        System.out.println("Программа завершена.");
    }
}

