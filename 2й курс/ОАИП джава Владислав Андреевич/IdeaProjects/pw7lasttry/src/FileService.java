import java.io.File;
import java.io.FileWriter;
import java.util.Scanner;

public class FileService {

    public void saveProducts(ProductService productService) {

        try {
            FileWriter writer = new FileWriter("products.txt");

            Product[] products = productService.getProducts();
            int count = productService.getProductCount();

            for (int i = 0; i < count; i++) {
                writer.write(
                        products[i].getId() + ";" +
                                products[i].getName() + ";" +
                                products[i].getCategory() + ";" +
                                products[i].getPrice() + ";" +
                                products[i].getQuantity() + "\n"
                );
            }

            writer.close();

        } catch (Exception e) {
            System.out.println("Ошибка сохранения");
        }
    }

    public void loadProducts(ProductService productService) {

        try {
            File file = new File("products.txt");
            if (!file.exists()) return;

            Scanner fileScanner = new Scanner(file);

            while (fileScanner.hasNextLine()) {

                String line = fileScanner.nextLine();
                String[] parts = line.split(";");

                Product product = new Product(
                        Integer.parseInt(parts[0]),
                        parts[1],
                        parts[2],
                        Double.parseDouble(parts[3]),
                        Integer.parseInt(parts[4])
                );

                productService.getProducts()[productService.getProductCount()] = product;
                productService.setProductCount(productService.getProductCount() + 1);
            }

            fileScanner.close();

        } catch (Exception e) {
            System.out.println("Ошибка загрузки");
        }
    }
    public void saveUsers(UserService userService) {

        try {
            FileWriter writer = new FileWriter("users.txt");

            User[] users = userService.getUsers();
            int count = userService.getUserCount();

            for (int i = 0; i < count; i++) {
                if(users[i] instanceof Employee ){
                    writer.write("Сотрудник");
                }else if(users[i] instanceof Customer ){
                    writer.write("Клиент");
                }
                writer.write(
                        users[i].getLogin() + ";" + users[i].getPassword() + "\n"
                );
            }

            writer.close();

        } catch (Exception e) {
            System.out.println("Ошибка сохранения пользователей");
        }
    }
    public void loadUsers(UserService userService) {

        try {
            File file = new File("users.txt");
            if (!file.exists()) return;

            Scanner fileScanner = new Scanner(file);

            while (fileScanner.hasNextLine()) {

                String line = fileScanner.nextLine();
                String[] parts = line.split(";");

                String role = parts[0];
                String login = parts[1];
                String password = parts[2];

                if (role.equals("Сотрудник")) {
                    userService.addLoadedUser(new Employee(login, password));
                } else {
                    userService.addLoadedUser(new Customer(login, password));
                }
                fileScanner.close();
            }

            fileScanner.close();

        } catch (Exception e) {
            System.out.println("Ошибка загрузки пользователей");
        }
    }
}
