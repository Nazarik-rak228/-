import java.io.*;
import java.util.Scanner;

public class SimpleTextEditor {

    // Счётчик изменений для каждого файла (только пока программа работает)
    private static int changesCount = 0;
    static String currentFilePath = ""; // Запоминаем последний использованный файл

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        while (true) {
            System.out.println("\n=== Простой редактор TXT файлов ===");
            System.out.println("1. Создать новый файл и записать текст");
            System.out.println("2. Прочитать файл");
            System.out.println("3. Добавить текст в файл");
            System.out.println("4. Удалить файл");
            System.out.println("5. Информация о файле");
            System.out.println("6. Выход");
            System.out.print("Выберите действие (1-6): ");

            String choice = scanner.nextLine();

            if (choice.equals("6")) {
                System.out.println("До свидания!");
                break;
            }

            // Спрашиваем путь к файлу (кроме выхода)
            System.out.print("Введите полный путь к файлу (например, C:\\test.txt или просто введите название файла" +
                    "\n( если не достаточно прав и вы не можеет дать их вашей Intellij)): ");
            String path = scanner.nextLine().trim();

            if (path.isEmpty()) {
                System.out.println("Путь не может быть пустым!");
                continue;
            }

            currentFilePath = path; // Запоминаем путь для информации

            switch (choice) {
                case "1":
                    createAndWriteFile(path, scanner);
                    break;
                case "2":
                    readFile(path);
                    break;
                case "3":
                    appendToFile(path, scanner);
                    break;
                case "4":
                    deleteFile(path);
                    break;
                case "5":
                    showFileInfo(path);
                    break;
                default:
                    System.out.println("Неверный выбор. Попробуйте ещё раз.");
            }
        }

        scanner.close();
    }

    // 1. Создание файла и запись текста
    private static void createAndWriteFile(String path, Scanner scanner) {
        System.out.print("Введите текст для записи в файл: ");
        String text = scanner.nextLine();

        try {
            FileWriter writer = new FileWriter(path);
            writer.write(text);
            writer.close();
            System.out.println("Файл успешно создан и текст записан!");
            changesCount++; // Увеличиваем счётчик изменений
        } catch (IOException e) {
            System.out.println("Ошибка при создании файла: " + e.getMessage());
        }
    }

    // 2. Чтение файла
    private static void readFile(String path) {
        try {
            FileReader reader = new FileReader(path);
            BufferedReader bufferedReader = new BufferedReader(reader);

            System.out.println("Содержимое файла:");
            String line;
            while ((line = bufferedReader.readLine()) != null) {
                System.out.println(line);
            }
            bufferedReader.close();
        } catch (FileNotFoundException e) {
            System.out.println("Файл не найден!");
        } catch (IOException e) {
            System.out.println("Ошибка при чтении файла.");
        }
    }

    // 3. Добавить текст в конец файла
    private static void appendToFile(String path, Scanner scanner) {
        System.out.print("Введите текст, который хотите добавить: ");
        String text = scanner.nextLine();

        try {
            FileWriter writer = new FileWriter(path, true); // true = добавлять в конец
            writer.write("\n" + text); // Добавляем новую строку + текст
            writer.close();
            System.out.println("Текст успешно добавлен в файл!");
            changesCount++;
        } catch (IOException e) {
            System.out.println("Ошибка при добавлении текста: " + e.getMessage());
        }
    }

    // 4. Удаление файла
    private static void deleteFile(String path) {
        File file = new File(path);
        if (file.exists()) {
            if (file.delete()) {
                System.out.println("Файл успешно удалён!");
                changesCount = 0; // Сбрасываем счётчик, файл-то удалён
            } else {
                System.out.println("Не удалось удалить файл.");
            }
        } else {
            System.out.println("Файл не существует.");
        }
    }

    // 5. Информация о файле
    private static void showFileInfo(String path) {
        File file = new File(path);

        if (!file.exists()) {
            System.out.println("Файл не существует.");
            return;
        }

        // Считаем слова
        int wordCount = 0;
        try {
            BufferedReader reader = new BufferedReader(new FileReader(path));
            String line;
            while ((line = reader.readLine()) != null) {
                if (!line.trim().isEmpty()) {
                    String[] words = line.trim().split("\\s+"); // Разбиваем по пробелам
                    wordCount += words.length;
                }
            }
            reader.close();
        } catch (IOException e) {
            System.out.println("Ошибка при подсчёте слов.");
        }

        System.out.println("\n=== Информация о файле ===");
        System.out.println("Путь: " + path);
        System.out.println("Количество слов: " + wordCount);
        System.out.println("Количество изменений за эту сессию: " + changesCount);
    }
}