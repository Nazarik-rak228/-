using System; 
public class Programm {
   

    static void SCHITALKA(int a, int b, out int c, out int d)
    {   
        c = a + b;
        d = a - b;
       
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        int sum = 0, raz = 0;
        Console.WriteLine("ssss");
        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());
        SCHITALKA(x, y, out sum, out raz);
        Console.WriteLine(sum);
        Console.WriteLine(raz);


          // блин .я  запутался, короч пишу консппект 
    }      // return c; сохраняет в памяти чему равет С, ретурн только если  тип данных Void
}          // чтобы выводила, а не забирала = OUT, но если надо и туда и сюда = Ref потом INT потом тпеременная
           // тип данных, название и аргументы или параметры -так строятся функции 
