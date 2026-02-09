using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Общие методы сортировки (пункт 5)");
        Console.Write("Введите размер массива N: ");
        int N = int.Parse(Console.ReadLine());

        int[] arr = new int[N];
        Console.WriteLine("Введите элементы массива:");
        for (int i = 0; i < N; i++)
            arr[i] = int.Parse(Console.ReadLine());

        Console.WriteLine("\nВыберите метод сортировки:");
        Console.WriteLine("1 — Пузырьковая сортировка (прямой обмен)");
        Console.WriteLine("2 — Сортировка прямым включением");
        Console.WriteLine("3 — Сортировка прямым выбором");
        Console.WriteLine("4 — Шейкерная сортировка");
        Console.Write("Ваш выбор (1-4): ");
        int choice = int.Parse(Console.ReadLine());

        int[] sorted = (int[])arr.Clone(); // Копируем, чтобы не менять оригинал

        switch (choice)
        {
            case 1:
                BubbleSort(sorted);
                Console.WriteLine("\nРезультат пузырьковой сортировки:");
                break;
            case 2:
                InsertionSort(sorted);
                Console.WriteLine("\nРезультат сортировки прямым включением:");
                break;
            case 3:
                SelectionSort(sorted);
                Console.WriteLine("\nРезультат сортировки прямым выбором:");
                break;
            case 4:
                ShakerSort(sorted);
                Console.WriteLine("\nРезультат шейкерной сортировки:");
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                return;
        }

        PrintArray(sorted);
    }

    // 1. Сортировка пузырьком (прямой обмен)
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(arr, j, j + 1);
                }
            }
        }
    }

    // 2. Сортировка прямым включением
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    // 3. Сортировка прямым выбором 
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIdx])
                    minIdx = j;
            }
            if (minIdx != i)
                Swap(arr, i, minIdx);
        }
    }

    // 4. Шейкерная сортировка 
    static void ShakerSort(int[] arr)
    {
        int left = 0;
        int right = arr.Length - 1;
        bool swapped = true;

        while (swapped && left < right)
        {
            swapped = false;

            // Проход слева направо (как обычный пузырёк)
            for (int i = left; i < right; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                    swapped = true;
                }
            }
            right--;

            if (!swapped) break;

            swapped = false;

            // Проход справа налево
            for (int i = right; i > left; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    Swap(arr, i - 1, i);
                    swapped = true;
                }
            }
            left++;
        }
    }

    // Вспомогательный метод обмена
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // Вывод массива
    static void PrintArray(int[] arr)
    {
        Console.WriteLine(string.Join(" ", arr));
    }
}