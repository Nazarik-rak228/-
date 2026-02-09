internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите кол-во элементов");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите элементы массива");
        int[] array = new int[n]; // создаем массив на 5 элементов, обращатся к ним с помощью индекста (с 0):
        { 
        for (int i = 0; i < n; i++) 
            array[i] = int.Parse(Console.ReadLine());
        }
        /*int count = 0;
        for (int minc = 0; minc < n; minc++)
        {
            if (array[minc] < 0)
            {
                count++;
            }
        }
        Console.WriteLine("Массив");
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine(array[i]);
        }
        Console.WriteLine("Минусы:" + count);*
        int first = 0;
        int second = 0;
        for (int i = 0; i < n; i++)
        {
            if (array[i] < 0)
            {
                second = i;
            }
        }
        for (int i = n-1; i >=0; i++)
        {
            if (array[i] < 0)
            {
                first = i;
            }
        
        int sum = 0;
        {
            for (int i = first + 1;i < second; i++)
                sum += array[i];
        }
        Console.WriteLine("Первый и последний минусы" + first + "  "+ second /n + "Сумма" +sum);
        int imin = 0;
        int max = array[0];

        for (int i = 0; i < n; i++) {
            if (array[i] > max) {
                max = array[i];
            }
            if (array[i] < imin)
            {
                imin = i;
            }

        }
        Console.WriteLine("Минимальный " + imin + " и " +  "Максимальнвый " + max);*/

        int temp = 0;
        for (int i = 0;i < n-1 ; i++)
        {
            for(int j = i+1; j < n ; j++)
            {
                if (array[i] > array[j])
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
        Console.WriteLine("Массив отсортированный ");
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine(array[i]);
        }
    }
}


