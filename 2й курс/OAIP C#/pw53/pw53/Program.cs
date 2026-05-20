using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {


        Console.WriteLine("ЗАДАЧА 1");

        int[] arr1 = { 9, 3, 7, 1, 5, 2, 8, 6, 4 };

        Array.Sort(arr1);

        int K = (int)Math.Sqrt(arr1.Length);

        int[,] matrix1 = new int[K, K];

        int index = 0;

        for (int i = K - 1; i >= 0; i--)
        {
            if ((K - 1 - i) % 2 == 0)
            {
                for (int j = 0; j < K; j++)
                {
                    matrix1[i, j] = arr1[index++];
                }
            }
            else
            {
                for (int j = K - 1; j >= 0; j--)
                {
                    matrix1[i, j] = arr1[index++];
                }
            }
        }

        for (int i = 0; i < K; i++)
        {
            for (int j = 0; j < K; j++)
            {
                Console.Write(matrix1[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();




        Console.WriteLine("ЗАДАЧА 2");

        int[,] matrix2 =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        int rows2 = matrix2.GetLength(0);
        int cols2 = matrix2.GetLength(1);

        int[] sums = new int[cols2];

        for (int j = 0; j < cols2; j++)
        {
            int sum = 0;

            for (int i = 0; i < rows2; i++)
            {
                sum += matrix2[i, j];
            }

            sums[j] = sum;
        }

        foreach (int x in sums)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
        Console.WriteLine();



        Console.WriteLine("ЗАДАЧА 3");

        int[,] matrix3 =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        int n = matrix3.GetLength(0);

        List<int> list = new List<int>();

        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                list.Add(matrix3[i, j]);
            }
        }

        foreach (int x in list)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
        Console.WriteLine();




        Console.WriteLine("ЗАДАЧА 4");

        int[] A4 = { 1, 2, 3, 4 };
        int[] B4 = { 5, 6, 7, 8 };

        int[] C4 = new int[A4.Length];

        for (int i = 0; i < A4.Length; i++)
        {
            C4[i] = A4[i] * B4[i];
        }

        foreach (int x in C4)
        {
            Console.Write(x + " ");
        }

        Console.WriteLine();
        Console.WriteLine();


     

        Console.WriteLine("ЗАДАЧА 5");

        int[,] A5 =
        {
            {1, 2},
            {3, 4}
        };

        int[,] B5 =
        {
            {5, 6},
            {7, 8}
        };

        int rows5 = A5.GetLength(0);
        int cols5 = A5.GetLength(1);

        int[,] C5 = new int[rows5, cols5];

        for (int i = 0; i < rows5; i++)
        {
            for (int j = 0; j < cols5; j++)
            {
                C5[i, j] = A5[i, j] * B5[i, j];
            }
        }

        for (int i = 0; i < rows5; i++)
        {
            for (int j = 0; j < cols5; j++)
            {
                Console.Write(C5[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}