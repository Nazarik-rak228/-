internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожвловать \n Выберите операцию (1-10)");

        int vibor = int.Parse(Console.ReadLine());
        switch (vibor) 
        { 
            case (1):
                
                perw();
                break;
            case (2):
                vTOR();
                break;
            case (3):
                tret();
                break;
            case (4):  
                chet();
                break;

            case (5):
                piaty();
                break;
            case (6):
                shest();
                break;
            case (7):
                Sem();
                break;
            case (8):
                Vosem();
                break;
            case (9):
                Devit();
                break;
            case (10):
                Ten();
                break;

        }
        
    }
    static void perw()
    {
        string[] firstLine = Console.ReadLine().Split();
        int N = int.Parse(firstLine[0]);
        int K = int.Parse(firstLine[1]);
        int L = int.Parse(firstLine[2]);

        string[] secondLine = Console.ReadLine().Split();
        int[] array = new int[N];
        for (int i = 0; i < N; i++)
        {
            array[i] = int.Parse(secondLine[i]);
        }

        long sum = 0;
        for (int i = K - 1; i <= L - 1; i++)
        {
            sum += array[i]; 
        }

        Console.WriteLine(sum); 
    
    }
    static void vTOR()
    {

        int N = int.Parse(Console.ReadLine());

        string[] line = Console.ReadLine().Split();
        int[] original = new int[N];
        for (int i = 0; i < N; i++)
        {
            original[i] = int.Parse(line[i]);
        }

        // Сначала считаем, сколько чётных 
        int countEven = 0;
        for (int i = 0; i < N; i++)
        {
            if (original[i] % 2 == 0)  
            {
                countEven++;
            }
        }

        // Создаём новый массив размером c четным
        int[] evenArray = new int[countEven];
        int portalIndex = 0;  

        for (int i = 0; i < N; i++)
        {
            if (original[i] % 2 == 0)
            {
                evenArray[portalIndex] = original[i];  
                portalIndex++;  
            }
        }


        Console.WriteLine(countEven);
        string output = "";
        for (int i = 0; i < countEven; i++)
        {
            if (i > 0) output += " ";
            output += evenArray[i].ToString();
        }
        Console.WriteLine(output);
    }
    static void tret()
    {
       
        int n = int.Parse(Console.ReadLine());

        string[] line = Console.ReadLine().Split();
        double[] array = new double[n];
        for (int i = 0; i < n; i++)
        {
            array[i] = double.Parse(line[i]);
        }

        double sum = 0;
        if (n > 2)
        {
            for (int i = 1; i < n - 1; i++)  
            {
                sum += array[i];  
            }
        }
        

        Console.WriteLine(sum); 


    } 
    static void chet()
    {
        int N = int.Parse(Console.ReadLine());

        string[] line = Console.ReadLine().Split();
        int[] A = new int[N]; 
        for (int i = 0; i < N; i++)
        {
            A[i] = int.Parse(line[i]);
        }

        int sizeB = 0;
        for (int i = 0; i < N; i++)
        {
            if (A[i] % 2 == 0)  
            {
                sizeB++;
            }
        }

        int[] B = new int[sizeB];
        int mysticIndex = 0; 

        for (int i = 0; i < N; i++)
        {
            if (A[i] % 2 == 0)
            {
                B[mysticIndex] = A[i];
                mysticIndex++;
            }
        }

        Console.WriteLine(sizeB);
        string mysticOutput = "";
        for (int i = 0; i < sizeB; i++)
        {
            if (i > 0) mysticOutput += " ";
            mysticOutput += B[i].ToString();
        }
        Console.WriteLine(mysticOutput); 
    }
    static void piaty()
        
    {
        Nach();

        static void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right) return;
            int pivot = Partition(arr, left, right);
            QuickSort(arr, left, pivot - 1);
            QuickSort(arr, pivot + 1, right);
        }

        static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[right];
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, right);
            return i + 1;
        }

        static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        static void Nach()
        {
            Console.WriteLine("Задача 5.3: Быстрая сортировка");
            Console.Write("Введите N: ");
            int N = int.Parse(Console.ReadLine());
            int[] A = new int[N];

            Console.WriteLine("Введите элементы:");
            for (int i = 0; i < N; i++)
                A[i] = int.Parse(Console.ReadLine());

            QuickSort(A, 0, N - 1);

            Console.WriteLine("Отсортированный массив: " + string.Join(" ", A));
        }
    }
    static void shest()
    {
        Console.WriteLine("Задача 6.3: Сумма элементов каждой строки матрицы");
        Console.Write("Введите M и N: ");
        string[] mn = Console.ReadLine().Split();
        int M = int.Parse(mn[0]);
        int N = int.Parse(mn[1]);

        int[,] matrix = new int[M, N];
        Console.WriteLine("Введите матрицу построчно:");
        for (int i = 0; i < M; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < N; j++)
                matrix[i, j] = int.Parse(row[j]);
        }

        Console.WriteLine("Суммы строк:");
        for (int i = 0; i < M; i++)
        {
            int sum = 0;
            for (int j = 0; j < N; j++)
                sum += matrix[i, j];
            Console.WriteLine($"Строка {i + 1}: {sum}");
        }
    }
    static void Sem()
    {
        Console.WriteLine("Задача 7.3: Поменять min и max в каждой строке");
        Console.Write("Введите M и N: ");
        string[] mn = Console.ReadLine().Split();
        int M = int.Parse(mn[0]), N = int.Parse(mn[1]);

        int[,] matrix = new int[M, N];
        Console.WriteLine("Введите матрицу:");
        for (int i = 0; i < M; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < N; j++)
                matrix[i, j] = int.Parse(row[j]);
        }

        for (int i = 0; i < M; i++)
        {
            int minVal = matrix[i, 0], maxVal = matrix[i, 0];
            int minIdx = 0, maxIdx = 0;
            for (int j = 1; j < N; j++)
            {
                if (matrix[i, j] < minVal) { minVal = matrix[i, j]; minIdx = j; }
                if (matrix[i, j] > maxVal) { maxVal = matrix[i, j]; maxIdx = j; }
            }
            // Swap
            int temp = matrix[i, minIdx];
            matrix[i, minIdx] = matrix[i, maxIdx];
            matrix[i, maxIdx] = temp;
        }

        Console.WriteLine("Преобразованная матрица:");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
    static void Vosem()
    {
        Console.WriteLine("Задача 8.3: Суммы диагоналей, параллельных главной");
        Console.Write("Введите порядок M: ");
        int M = int.Parse(Console.ReadLine());
        int[,] A = new int[M, M];

        Console.WriteLine("Введите матрицу:");
        for (int i = 0; i < M; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < M; j++)
                A[i, j] = int.Parse(row[j]);
        }

        // Диагонали параллельные главной: i - j = const
        // const от -(M-1) до (M-1)
        Console.WriteLine("Суммы диагоналей (начиная с верхнего правого угла):");
        for (int d = -(M - 1); d <= (M - 1); d++)
        {
            int sum = 0;
            int count = 0;
            for (int i = 0; i < M; i++)
            {
                int j = i - d;
                if (j >= 0 && j < M)
                {
                    sum += A[i, j];
                    count++;
                }
            }
            if (count > 0)
                Console.WriteLine($"Диагональ с разностью i-j = {d}: сумма = {sum}");
        }
    }
    static void Devit()
    {
        Console.WriteLine("Задача 9.3: Змейка вертикально, начиная с правого верхнего угла");
        Console.Write("Введите количество элементов K: ");
        int K = int.Parse(Console.ReadLine());
        Console.Write("Введите M (строк): ");
        int M = int.Parse(Console.ReadLine());
        int N = (K + M - 1) / M; // столбцов

        int[] arr = new int[K];
        Console.WriteLine("Введите элементы одномерного массива:");
        for (int i = 0; i < K; i++)
            arr[i] = int.Parse(Console.ReadLine());

        int[,] matrix = new int[M, N];
        int idx = 0;
        for (int j = N - 1; j >= 0; j--) // начинаем с правого столбца
        {
            if ((N - 1 - j) % 2 == 0) // чётные столбцы (считая от правого) — сверху вниз
            {
                for (int i = 0; i < M && idx < K; i++)
                    matrix[i, j] = arr[idx++];
            }
            else // нечётные — снизу вверх
            {
                for (int i = M - 1; i >= 0 && idx < K; i--)
                    matrix[i, j] = arr[idx++];
            }
        }

        Console.WriteLine("Полученная матрица:");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }
    static void Ten()
    {   
        Console.WriteLine("Задача 10.3: Спираль по часовой, начиная с правого верхнего");
        Console.Write("Введите K (элементов): ");
        int K = int.Parse(Console.ReadLine());
        Console.Write("Введите M (строк): ");
        int M = int.Parse(Console.ReadLine());
        int N = (K + M - 1) / M;

        int[] arr = new int[K];
        Console.WriteLine("Введите элементы:");
        for (int i = 0; i < K; i++)
            arr[i] = int.Parse(Console.ReadLine());

        int[,] matrix = new int[M, N];
        int idx = 0;
        int top = 0, bottom = M - 1, left = 0, right = N - 1;

        // Начинаем с правого верхнего угла
        int row = 0, col = N - 1;
        matrix[row, col] = arr[idx++];

        while (idx < K)
        {
            // Вниз по правому столбцу
            while (row < bottom && idx < K)
            {
                row++;
                matrix[row, col] = arr[idx++];
            }
            right--;
            // Влево по нижней строке
            while (col > left && idx < K)
            {
                col--;
                matrix[row, col] = arr[idx++];
            }
            bottom--;
            // Вверх по левому столбцу
            while (row > top && idx < K)
            {
                row--;
                matrix[row, col] = arr[idx++];
            }
            left++;
            // Вправо по верхней строке
            while (col < right && idx < K)
            {
                col++;
                matrix[row, col] = arr[idx++];
            }
            top++;
        }

        Console.WriteLine("Матрица:");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }

}





     
