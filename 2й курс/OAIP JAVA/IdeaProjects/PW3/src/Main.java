import java.util.Scanner;

public class Main {

    // Методы для математических операций
    public static double add(double[] numbers, int count) {
        double result = numbers[0];
        for (int i = 1; i < count; i++) {
            result += numbers[i];
        }
        return result;
    }

    public static double subtract(double[] numbers, int count) {
        double result = numbers[0];
        for (int i = 1; i < count; i++) {
            result -= numbers[i];
        }
        return result;
    }

    public static double multiply(double[] numbers, int count) {
        double result = numbers[0];
        for (int i = 1; i < count; i++) {
            result *= numbers[i];
        }
        return result;
    }

    public static double divide(double[] numbers, int count) throws ArithmeticException {
        double result = numbers[0];
        for (int i = 1; i < count; i++) {
            if (numbers[i] == 0) {
                throw new ArithmeticException("Деление на ноль!");
            }
            result /= numbers[i];
        }
        return result;
    }

    public static double modulus(double[] numbers, int count) throws ArithmeticException {
        double result = numbers[0];
        for (int i = 1; i < count; i++) {
            if (numbers[i] == 0) {
                throw new ArithmeticException("Деление на ноль!");
            }
            result %= numbers[i];
        }
        return result;
    }

    // Методы для перевода систем счисления
    public static String decimalToBinary(int number) {
        return Integer.toBinaryString(number);
    }

    public static String decimalToOctal(int number) {
        return Integer.toOctalString(number);
    }

    public static String decimalToHex(int number) {
        return Integer.toHexString(number).toUpperCase();
    }

    public static int binaryToDecimal(String binary) {
        return Integer.parseInt(binary, 2);
    }

    public static int octalToDecimal(String octal) {
        return Integer.parseInt(octal, 8);
    }

    public static int hexToDecimal(String hex) {
        return Integer.parseInt(hex, 16);
    }

    // Вспомогательные методы
    public static void displayMenu() {
        System.out.println("\n=== КАЛЬКУЛЯТОР ===");
        System.out.println("Математические операции:");
        System.out.println("+ - Сложение");
        System.out.println("- - Вычитание");
        System.out.println("* - Умножение");
        System.out.println("/ - Деление");
        System.out.println("% - Деление с остатком");
        System.out.println("\nПеревод систем счисления:");
        System.out.println("bin - Перевод в двоичную систему");
        System.out.println("oct - Перевод в восьмеричную систему");
        System.out.println("hex - Перевод в шестнадцатеричную систему");
        System.out.println("todec - Перевод в десятичную систему");
        System.out.println("exit - Выход");
    }

    public static int getNumbersCount(Scanner scanner) {
        System.out.print("Сколько чисел вы хотите ввести? (1-5): ");
        int count = scanner.nextInt();
        while (count < 1 || count > 5) {
            System.out.print("Пожалуйста, введите число от 1 до 5: ");
            count = scanner.nextInt();
        }
        return count;
    }

    public static void inputNumbers(double[] numbers, int count, Scanner scanner) {
        for (int i = 0; i < count; i++) {
            System.out.print("Введите число " + (i + 1) + ": ");
            numbers[i] = scanner.nextDouble();
        }
    }

    public static void performMathOperation(String operation, double[] numbers, int count) {
        try {
            double result;
            switch (operation) {
                case "+":
                    result = add(numbers, count);
                    System.out.println("Результат сложения: " + result);
                    break;
                case "-":
                    result = subtract(numbers, count);
                    System.out.println("Результат вычитания: " + result);
                    break;
                case "*":
                    result = multiply(numbers, count);
                    System.out.println("Результат умножения: " + result);
                    break;
                case "/":
                    result = divide(numbers, count);
                    System.out.println("Результат деления: " + result);
                    break;
                case "%":
                    result = modulus(numbers, count);
                    System.out.println("Результат деления с остатком: " + result);
                    break;
                default:
                    System.out.println("Неизвестная операция!");
            }
        } catch (ArithmeticException e) {
            System.out.println("Ошибка: " + e.getMessage());
        }
    }

    public static void performConversion(String operation, Scanner scanner) {
        switch (operation) {
            case "bin":
                System.out.print("Введите десятичное число: ");
                int decToBin = scanner.nextInt();
                System.out.println("Двоичное представление: " + decimalToBinary(decToBin));
                break;
            case "oct":
                System.out.print("Введите десятичное число: ");
                int decToOct = scanner.nextInt();
                System.out.println("Восьмеричное представление: " + decimalToOctal(decToOct));
                break;
            case "hex":
                System.out.print("Введите десятичное число: ");
                int decToHex = scanner.nextInt();
                System.out.println("Шестнадцатеричное представление: " + decimalToHex(decToHex));
                break;
            case "todec":
                System.out.print("Из какой системы? (bin/oct/hex): ");
                String fromSystem = scanner.next();
                System.out.print("Введите число: ");
                String numberStr = scanner.next();
                try {
                    int decimalResult;
                    switch (fromSystem) {
                        case "bin":
                            decimalResult = binaryToDecimal(numberStr);
                            System.out.println("Десятичное представление: " + decimalResult);
                            break;
                        case "oct":
                            decimalResult = octalToDecimal(numberStr);
                            System.out.println("Десятичное представление: " + decimalResult);
                            break;
                        case "hex":
                            decimalResult = hexToDecimal(numberStr);
                            System.out.println("Десятичное представление: " + decimalResult);
                            break;
                        default:
                            System.out.println("Неизвестная система счисления!");
                    }
                } catch (NumberFormatException e) {
                    System.out.println("Ошибка: неверный формат числа!");
                }
                break;
            default:
                System.out.println("Неизвестная операция конвертации!");
        }
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double[] numbers = new double[5];

        System.out.println("Добро пожаловать в улучшенный калькулятор!");

        while (true) {
            displayMenu();
            System.out.print("\nВыберите операцию: ");
            String operation = scanner.next();

            if (operation.equals("exit")) {
                System.out.println("До свидания!");
                break;
            }

            // Проверяем, является ли операция математической
            if (operation.equals("+") || operation.equals("-") || operation.equals("*") ||
                    operation.equals("/") || operation.equals("%")) {

                int count = getNumbersCount(scanner);
                inputNumbers(numbers, count, scanner);
                performMathOperation(operation, numbers, count);

            }
            // Проверяем, является ли операция конвертацией
            else if (operation.equals("bin") || operation.equals("oct") ||
                    operation.equals("hex") || operation.equals("todec")) {

                performConversion(operation, scanner);

            } else {
                System.out.println("Неизвестная операция! Пожалуйста, выберите из списка.");
            }

            System.out.println("\n" + "=".repeat(40));
        }

        scanner.close();
    }
}