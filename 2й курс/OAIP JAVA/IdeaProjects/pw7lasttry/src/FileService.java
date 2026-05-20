import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;

public class FileService {

    public void saveProducts(ProductService productService) {
        Product[] products = productService.getProducts();
        int count = productService.getProductCount();

        try {
            DataOutputStream sas = new DataOutputStream(
                    new FileOutputStream("prod.dat"));
            sas.writeInt(count);

            for (int i =0; i < count;i++){
                Product p = products[i];
                sas.writeInt(p.getId());
                sas.writeUTF(p.getName());
                sas.writeUTF(p.getCategory());
                sas.writeDouble(p.getPrice());
                sas.writeInt(p.getQuantity());
            }
            sas.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }



    }
    public void loadProducts(ProductService productService) {
        try{
            File file = new File("prod.dat");
            if (!file.exists()) return;

            DataInputStream sus  = new DataInputStream(new FileInputStream("prod.dat"));
            int count = sus.readInt();
            for (int i = 0; i < count; i++){
                int id = sus.readInt();
                String title = sus.readUTF();
                System.out.println("Загружено: " + title);
                String cat = sus.readUTF();
                double price = sus.readDouble();
                int quantity = sus.readInt();

                productService.addProductLoad(id,title,cat,price,quantity);
            }

        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
    public void saveUsers(User[] users, int userCount) {

        try {
            DataOutputStream out = new DataOutputStream(
                    new FileOutputStream("users.dat"));
            out.writeInt(userCount);
            for (int i =0; i < userCount;i++){
                User u = users[i];
                if( u instanceof Employee){
                    out.writeUTF("Employee");
                    out.writeUTF(u.login);
                    out.writeUTF(u.password);
                }
                if(u instanceof  Customer)
                {
                    out.writeUTF("Customer");
                    out.writeUTF(u.login);
                    out.writeUTF(u.password);
                }

            }
            out.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }

    }
    public void loadUsers(UserService userService) {
        File file = new File("users.dat");
        if (!file.exists()) return;

        try {

            DataInputStream in = new DataInputStream(new FileInputStream("users.dat"));
            int userCount = in.readInt();

            for (int i = 0; i < userCount; i++){
                String tip = in.readUTF();
                String n = in.readUTF();
                String por = in.readUTF();

                if(tip.equals("Employee")){
                    userService.addLoadedUser(new Employee(n,por));
                }
                if(tip.equals("Customer")){
                    userService.addLoadedUser(new Customer(n,por));
                }
            }

        } catch (IOException e) {
            throw new RuntimeException(e);
        }


    }
}

        /*
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


        }
        catch (Exception e) {
            System.out.println("Ошибка сохранения");
        }*/
/* try {

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
        }*/

/*
        try {


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
        }*/

        /*
        try {


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
        }*/