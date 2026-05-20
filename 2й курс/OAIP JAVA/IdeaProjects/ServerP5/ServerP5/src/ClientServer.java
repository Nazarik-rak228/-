    import java.io.*;
    import java.net.ServerSocket;
    import java.net.Socket;
    import java.nio.channels.Channel;
    import java.util.HashMap;
    import java.util.HashSet;
    import java.util.Map;
    import java.util.Set;

    public class ClientServer {


        // Порт, на котором будет работать сервер
        // Набор для хранения объектов PrintWriter, представляющих клиентов
        private static final int PORT = 12345;
        private static Set<PrintWriter> clientWriters = new HashSet<>();
        private static Map<String,Set<PrintWriter>> channels = new HashMap<>();
        private static Map<String, PrintWriter> users = new HashMap<>();


        public ClientServer() throws IOException {
        }
        private static void saveMessage(String message, String channel) {
            try {
                FileWriter fileWriter = new FileWriter(channel + ".txt", true);
                BufferedWriter bufferedWriter = new BufferedWriter(fileWriter);
                PrintWriter writer = new PrintWriter(bufferedWriter);
                writer.println(message);
                writer.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        public static void main(String[] args) {
            channels.put("general", new HashSet<>());
            channels.put("games", new HashSet<>());
            channels.put("music", new HashSet<>());
            System.out.println("Chat server started...");
            try (ServerSocket serverSocket = new ServerSocket(PORT)) {

                while (true) {
                    new ClientHandler(serverSocket.accept()).start();// старт делает новый поток, а ран в этом работает
                }
            } catch (IOException e) {
                e.printStackTrace();
            }

        }

        // Вложенный класс для обработки подключений клиентов
        private static class ClientHandler extends Thread {
            // наследуя класс потоков мы делаем наш класс отдельным потоком
            // это «умный» писатель текста, который умеет печатать почти что угодно без явного преобразования в байты. имба короче. на тип ей пофиг
            // Сокет для общения с клиентом
            // Для отправки сообщений клиенту
            // Для получения сообщений от клиента
            // мы используем буферед, чтобы читать ридером не по символам, а кусками текста, так намного быстрее

            private Socket socket;
            private String currentChannel;
            private String username;
            private PrintWriter out;
            private BufferedReader in;
            public ClientHandler(Socket socket) {
                this.socket = socket;
            }
            private static boolean loginUser(String login, String password){

                try {
                    File file = new File("user.txt");
                    if (!file.exists()) {
                        return false;
                    }
                    BufferedReader reader = new BufferedReader(new FileReader(file));
                    String line;

                    while ((line = reader.readLine()) != null) {
                        String[] parts = line.split(":");

                        String sLogin = parts[0];
                        String sPassword = parts[1];
                        if (sLogin.equals(login) && sPassword.equals(password)) {
                            reader.close();
                            return true;
                        }
                    }
                    reader.close();

                } catch (IOException e) {

                    e.printStackTrace();
                }

                return false;
            }
            private static boolean registerUser(String login, String password){
                try {
                    File file = new File("user.txt");
                    file.createNewFile();
                    BufferedReader bufferedReader = new BufferedReader(new FileReader(file));
                    String line;
                    while ((line = bufferedReader.readLine())!= null){
                        String [] part = line.split(":");
                        String LoginS = part[0];
                        if(LoginS.equals(login)){
                            bufferedReader.close();
                            return false;
                        }
                    }
                    bufferedReader.close();
                    PrintWriter writer = new PrintWriter(new BufferedWriter(new FileWriter(file,true)));
                    writer.println(login+":"+password);
                    writer.close();
                    return  true;
                }
                catch (IOException e){
                    e.printStackTrace();
                    return false;
                }
            }
            private void sendChatHistory(String channel) {
                try {
                    File file = new File(channel + ".txt");
                    if (!file.exists()){
                        return;
                    }
                    BufferedReader reader = new BufferedReader(new FileReader(file));
                    String line;
                    while ((line = reader.readLine()) != null) {
                        out.println(line);
                    }
                    reader.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
            public void run() { // поскольку у нас свой поток - запускаем код прямо в этом потоке
                try {
                    // Создаем потоки ввода и вывода для общения с клиентом
                    //InputStream  возвращает байты из сокета, InputStreamReader читает байты и декодирует их в char согласно кодировке
                    //getOutputStream отправляет, на оборот получается, true в конце говорит авто-сбрасываться после каждой отправки
                    // если не делать autoFlush, то клиент должен будет сам чистить канал после каждого сообщения с помощью server.Flush()
                    // Синхронизируем доступ к набору клиентов и добавляем текущего клиента
                    // Читаем сообщения от клиента до тех пор, пока они не закончатся
                    in = new BufferedReader(new InputStreamReader(socket.getInputStream()));
                    out = new PrintWriter(socket.getOutputStream(), true);

                    synchronized (clientWriters) { //
                        clientWriters.add(out);
                    }
                    String message;
                    String firstMessage = in.readLine();
                    String [] parts = firstMessage.split(" ");
                    if (parts.length < 3) {
                        out.println("Ошибка команды");
                        socket.close();
                        return;
                    }
                    String command = parts[0];

                    String name =parts[1];
                    String password = parts[2];
                    boolean success = false;
                    if (command.equals("/register")) {
                        success = registerUser(name, password);

                    } else if (command.equals("/login")) {
                        success = loginUser(name, password);

                    }
                    if (!success) {

                        out.println("Ошибка авторизации");

                        socket.close();

                        return;
                    }
                    username =name;
                    synchronized (users){
                        users.put(username,out);
                    }

                    while ((message = in.readLine()) != null) {

                        if (message.startsWith("/channel")){
                            String [] partse = message.split(" ");
                            if (partse.length < 2) {
                                out.println("Укажите канал");
                                continue;
                            }
                            if (currentChannel != null) {

                                channels.get(currentChannel).remove(out);
                            }
                            currentChannel = partse[1];
                            if (!channels.containsKey(currentChannel)) {
                                out.println("Такого канала нет");
                                currentChannel = null;
                                continue;
                            }
                            synchronized (channels){


                                channels.get(currentChannel).add(out);
                                sendChatHistory(currentChannel);
                            }
                            continue;
                        }

                        if (message.startsWith("/pm")) {
                            String[] partses = message.split(" ", 3);
                            if (partses.length < 3) {
                                out.println("Неверный формат команды");
                                continue;
                            }
                            String targetUser = partses[1];
                            String privateMessage = partses[2];
                            sendPrivateMessage(targetUser, privateMessage);
                            continue;
                        }
                        System.out.println("Received: " + message);

                        if (currentChannel == null) {
                            out.println("Вы не выбрали канал");
                            continue;
                        }
                        saveMessage(username + ": " + message,currentChannel);
                        broadcast(message);

                    }
                } catch (IOException e) {

                    e.printStackTrace();
                }

                finally {
                    try {
                        socket.close();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                    synchronized (clientWriters) {
                        clientWriters.remove(out);
                    }
                    synchronized (users) {

                        users.remove(username);
                    }
                    synchronized (channels) {
                        if (currentChannel != null) {
                            channels.get(currentChannel).remove(out);
                        }
                    }
                }
            }

            private void  sendPrivateMessage(String target, String message){
                synchronized (users){
                    PrintWriter writer = users.get(target);
                    if (writer != null){
                       writer.println("[ЛИЧНОЕ СООБЩЕНИЕ]"  + username + ": " + message);
                    }
                    else {

                        out.println("Пользователь не найден");
                    }
                }
            }

            private void broadcast(String message) {
                synchronized (channels) {


                    Set<PrintWriter> channelUsers =
                            channels.get(currentChannel);

                    for (PrintWriter writer : channelUsers){
                        writer.println(username + ": " + message);
                    }
                }
            }
        }
    }