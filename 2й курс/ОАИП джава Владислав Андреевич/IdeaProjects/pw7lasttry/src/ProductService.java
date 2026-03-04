import java.util.Scanner;

public class ProductService {

    private Product[] products = new Product[100];
    private int productCount = 0;

    public Product[] getProducts() {
        return products;
    }

    public int getProductCount() {
        return productCount;
    }

    public void setProductCount(int productCount) {
        this.productCount = productCount;
    }

    public void addProduct(Scanner scanner) {

        System.out.println("Введите id:");
        int id = scanner.nextInt();
        scanner.nextLine();

        System.out.println("Введите название:");
        String name = scanner.nextLine();
        scanner.nextLine();

        System.out.println("Введите категорию:");
        String category = scanner.nextLine();

        System.out.println("Введите цену:");
        double price = scanner.nextDouble();

        System.out.println("Введите количество:");
        int quantity = scanner.nextInt();
        scanner.nextLine();

        products[productCount] = new Product(id, name, category, price, quantity);
        productCount++;
    }

    public void showProducts() {

        for (int i = 0; i < productCount; i++) {
            System.out.println(products[i].getId() +
                    " " + products[i].getName() +
                    " " + products[i].getCategory() +
                    " " + products[i].getPrice() +
                    " " + products[i].getQuantity()
            );
        }
    }

    public void editProduct(Scanner scanner) {

        System.out.println("Введите id товара:");
        int id = scanner.nextInt();

        for (int i = 0; i < productCount; i++) {
            if (products[i].getId() == id) {

                System.out.println("Новое название:");
                products[i].setName(scanner.nextLine());
                scanner.nextLine();

                System.out.println("Новая категория:");
                products[i].setCategory(scanner.nextLine());

                System.out.println("Новая цена:");
                products[i].setPrice(scanner.nextDouble());

                System.out.println("Новое количество:");
                products[i].setQuantity(scanner.nextInt());
                scanner.nextLine();

                break;
            }
        }
    }

    public void deleteProduct(Scanner scanner) {

        System.out.println("Введите id товара:");
        int id = scanner.nextInt();
        scanner.nextLine();

        for (int i = 0; i < productCount; i++) {
            if (products[i].getId() == id) {

                for (int j = i; j < productCount - 1; j++) {
                    products[j] = products[j + 1];
                }

                productCount--;
                break;
            }
        }
    }
}
