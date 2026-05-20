import java.util.Scanner;

public class ProductService {

    private Product[] products = new Product[100];
    private int productCount = 0;

    private Product[] backupProducts = new Product[100];
    private int backupCount = 0;

    public int getBackupCount() {
        return backupCount;
    }

    public void setBackupCount(int backupCount) {
        this.backupCount = backupCount;
    }

    public Product[] getBackupProducts() {
        return backupProducts;
    }

    public void setBackupProducts(Product[] backupProducts) {
        this.backupProducts = backupProducts;
    }

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
        backupProduct();
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

    public  void  addProductLoad(int id, String name, String category, double price, int quantity){
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
        backupProduct();
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
        backupProduct();
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

    public void backupProduct (){
        backupCount = productCount;
        for (int i =0;i< backupCount;i++){
            Product p = products[i];
            backupProducts[i] = new Product(p.getId(), p.getName(), p.getCategory(),p.getPrice(),p.getQuantity());
        }
    }
    public void  useBack(){
        productCount = backupCount;
        for (int i =0;i< productCount;i++){
            Product p = backupProducts[i];
            products[i] = new Product(p.getId(), p.getName(), p.getCategory(),p.getPrice(),p.getQuantity());
        }
        System.out.println("Последнее действие отменено");
    }
}

