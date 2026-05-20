import java.util.Random;
import java.util.Scanner;

public class PasswordGenerator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        String upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        String lowerCase = "abcdefghijklmnopqrstuvwxyz";
        String digits = "0123456789";
        String specialChars = "!@#$%^&*()_+=-[]{}|;':\",./<>?";

        String allChars = upperCase + lowerCase + digits + specialChars;
        System.out.print("Введите длину пароля (минимум 4): ");
        int length = scanner.nextInt();
        if (length < 4) {
            System.out.println("Ошибка: Длина пароля должна быть не менее 4 символов!");
            return;
        }
        StringBuilder password = new StringBuilder();
        // Обеспечиваем включение хотя бы одного символа из каждого типа
        password.append(upperCase.charAt(random.nextInt(upperCase.length())));
        password.append(lowerCase.charAt(random.nextInt(lowerCase.length())));
        password.append(digits.charAt(random.nextInt(digits.length())));
        password.append(specialChars.charAt(random.nextInt(specialChars.length())));
        for (int i = 4; i < length; i++) {
            password.append(allChars.charAt(random.nextInt(allChars.length())));
        }

        // Перемешиваем пароль для случайности (опционально, но рекомендуется для безопасности)
        String shuffledPassword = shuffleString(password.toString(), random);

        System.out.println("Сгенерированный пароль: " + shuffledPassword);
        scanner.close();
    }

    private static String shuffleString(String input, Random random) {
        char[] chars = input.toCharArray();
        for (int i = chars.length - 1; i > 0; i--) {
            int j = random.nextInt(i + 1);
            // Меняем местами символы
            char temp = chars[i];
            chars[i] = chars[j];
            chars[j] = temp;
        }
        return new String(chars);
    }
}