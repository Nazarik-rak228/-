import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class ChatClient {
    // Адрес сервера и порт для подключения
    private static final String SERVER_ADDRESS = "localhost";
    private static final int SERVER_PORT = 12345;

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("1 - Вход");
        System.out.println("2 - Регистрация");
        String choice = scanner.nextLine();

        System.out.println("Введите логин:");
        String login = scanner.nextLine();
        System.out.println("Введите пароль:");
        String password = scanner.nextLine();

        connect(choice, login, password);

    }
    public static void connect(String choice, String login, String password){

        try (Socket socket = new Socket(SERVER_ADDRESS, SERVER_PORT)) {
            // Создаем и запускаем новый поток для обработки входящих сообщений от сервера
            // Создаем PrintWriter для отправки сообщений на сервер
            // Создаем BufferedReader для чтения ввода с консоли
            // Читаем ввод пользователя из консоли и отправляем его на сервер
            new Thread(new IncomingMessageHandler(socket,login)).start();
            PrintWriter out = new PrintWriter(socket.getOutputStream(), true);
            BufferedReader consoleInput = new BufferedReader(new InputStreamReader(System.in));
            String userInput;
            System.out.println("Выберите канал: /channel Ваш выбор");
            System.out.println("general");
            System.out.println("games");
            System.out.println("music");
            System.out.println("Для личного сообщения /pm АДРЕС СООБЩЕНИЕ");
            if (choice.equals("1")){
                out.println("/login "+ login+" "+password );
            }
            if (choice.equals("2")){
                out.println("/register "+ login+" "+password );
            }

            String channel = consoleInput.readLine();


                out.println("/channel " + channel);
            while ((userInput = consoleInput.readLine()) != null) {
                out.println(userInput); // Отправляем введенное сообщение на сервер
                if (userInput.equals("/exit")){
                    socket.close();
                    break;
                }
            }

        }  // Обработка исключений при работе с сетью
        catch (IOException e) {

            e.printStackTrace();
        }
    }
public void menu(){

}
    // Вложенный класс для обработки входящих сообщений от сервера
    public static class IncomingMessageHandler implements Runnable {
        private Socket socket; // Сокет для общения с сервером
        private String name;
        public IncomingMessageHandler(Socket socket, String name) {

            this.socket = socket; // Инициализация сокета
            this.name = name;
        }
        // Читаем сообщения от сервера до тех пор, пока они не закончатся
        // Выводим полученное сообщение на консоль
        // Обработка исключений при работе с вводом-выводом
        @Override
        public void run() {
            try (BufferedReader in = new BufferedReader(new InputStreamReader(socket.getInputStream()))) {
                String message;
                while ((message = in.readLine()) != null) {
                    System.out.println(message);
                }
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}