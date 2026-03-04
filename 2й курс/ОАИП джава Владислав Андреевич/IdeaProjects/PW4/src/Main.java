import java.util.Scanner;
import java.util.Random;
import java.util.Arrays;  // Для Arrays.sort()

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        Random random = new Random();

        System.out.println("=== Лабораторная работа: Работа с массивами в Java (3-й вариант) ===");
        System.out.println("1. Сортировка одномерного массива методом слиянием (Merge Sort) + Меню");
        System.out.println("2. Поиск максимального элемента в двумерном массиве");

        System.out.print("Выберите задание (1 или 2): ");
        int choice = scanner.nextInt();

        if (choice == 1) {
            // Первое задание: Merge Sort + Меню
            System.out.print("Введите размер массива (минимум 5): ");
            int n = scanner.nextInt();
            if (n < 5) {
                System.out.println("Размер должен быть минимум 5. Устанавливаем 5.");
                n = 5;
            }

            int[] array = new int[n];
            System.out.println("Заполните массив " + n + " элементами:");
            for (int i = 0; i < n; i++) {
                System.out.print("Элемент " + (i + 1) + ": ");
                array[i] = scanner.nextInt();
            }

            System.out.println("Массив до сортировки:");
            printArray(array);

            // Merge Sort (оригинальная сортировка)
            mergeSort(array, 0, array.length - 1);
            System.out.println("Массив после сортировки (Merge Sort):");
            printArray(array);

            // Теперь меню (из "На 4")
            menuForArray(scanner, array);

        } else if (choice == 2) {
            // Второе задание:
            System.out.print("Введите размер квадратной матрицы (строки = столбцы, минимум 2): ");
            int size = scanner.nextInt();
            if (size < 2) {
                System.out.println("Размер должен быть минимум 2. Устанавливаем 3.");
                size = 3;
            }

            int[][] matrix = new int[size][size];

            // Заполнение случайными числами (от 0 до 100)
            System.out.println("Матрица заполнена случайными числами (0-100):");
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    matrix[i][j] = random.nextInt(101);
                    System.out.print(matrix[i][j] + "\t");
                }
                System.out.println();
            }

            // Поиск максимума и индексов
            int maxValue = matrix[0][0];
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    if (matrix[i][j] > maxValue) {
                        maxValue = matrix[i][j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            System.out.println("\nМаксимальный элемент: " + maxValue);
            System.out.println("Индексы: строка " + maxRow + ", столбец " + maxCol);

        } else {
            System.out.println("Неверный выбор. Завершение.");
        }

        scanner.close();
    }

    // Метод для вывода одномерного массива
    public static void printArray(int[] arr) {
        for (int value : arr) {
            System.out.print(value + " ");
        }
        System.out.println();
    }

    // Новое меню после сортировки
    public static void menuForArray(Scanner sc, int[] arr) {
        System.out.println("\n=== Меню для работы с массивом ===");
        System.out.println("1. Поиск элемента по индексу");
        System.out.println("2. Сортировка от минимального к максимальному (Arrays.sort)");
        System.out.println("3. Изменить на максимального к минимальному (sort + reverse)");
        System.out.println("4. Выход");

        int option;
        do {
            System.out.print("Выберите опцию (1-4): ");
            option = sc.nextInt();

            switch (option) {
                case 1:
                    System.out.print("Введите индекс (0-" + (arr.length - 1) + "): ");
                    int index = sc.nextInt();
                    if (index >= 0 && index < arr.length) {
                        System.out.println("Элемент по индексу " + index + ": " + arr[index]);
                    } else {
                        System.out.println("Неверный индекс! Должен быть от 0 до " + (arr.length - 1));
                    }
                    break;

                case 2:
                    Arrays.sort(arr);  // По возрастанию
                    System.out.println("Массив отсортирован по возрастанию:");
                    printArray(arr);
                    break;

                case 3:
                    Arrays.sort(arr);  // Сначала по возрастанию
                    reverseArray(arr); // Затем реверс для убывания
                    System.out.println("Массив отсортирован по убыванию:");
                    printArray(arr);
                    break;

                case 4:
                    System.out.println("Выход из меню.");
                    break;

                default:
                    System.out.println("Неверная опция! Выберите 1-4.");
            }
        } while (option != 4);
    }

    // Простой реверс массива (swap элементов)
    public static void reverseArray(int[] arr) {
        for (int i = 0; i < arr.length / 2; i++) {
            int temp = arr[i];
            arr[i] = arr[arr.length - 1 - i];
            arr[arr.length - 1 - i] = temp;
        }
    }

    // Merge Sort: Рекурсивная сортировка слиянием (без изменений)
    public static void mergeSort(int[] arr, int left, int right) {
        if (left < right) {
            int mid = left + (right - left) / 2;

            // Сортируем левую и правую половины
            mergeSort(arr, left, mid);
            mergeSort(arr, mid + 1, right);

            // Слияние
            merge(arr, left, mid, right);
        }
    }

    // Слияние двух отсортированных подмассивов (без изменений)
    public static void merge(int[] arr, int left, int mid, int right) {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        // Временные массивы
        int[] leftArr = new int[n1];
        int[] rightArr = new int[n2];

        // Копирование данных
        for (int i = 0; i < n1; i++) {
            leftArr[i] = arr[left + i];
        }
        for (int j = 0; j < n2; j++) {
            rightArr[j] = arr[mid + 1 + j];
        }

        // Слияние обратно в оригинальный массив
        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2) {
            if (leftArr[i] <= rightArr[j]) {
                arr[k] = leftArr[i];
                i++;
            } else {
                arr[k] = rightArr[j];
                j++;
            }
            k++;
        }

        // Копирование остатков
        while (i < n1) {
            arr[k] = leftArr[i];
            i++;
            k++;
        }
        while (j < n2) {
            arr[k] = rightArr[j];
            j++;
            k++;
        }
    }
}