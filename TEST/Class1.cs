using System;

public class Class1
{
    static void Main(string[] args) 
    {
        Program n = new Program();
        //int ans = 0;
        //n.fizzbuzz();
        //n.EvenorOdd(int.Parse(inp));


        /* while (true)
         {

             var inp = Console.ReadLine();       

             if (int.Parse(inp) == 0)
             {
                 break;
             }

             var inp2 = Console.ReadLine();

             n.Multiply(int.Parse(inp), int.Parse(inp2));
         }
        */

        //string a = Console.ReadLine();
        //n.palindromechecker(a);
        /*
        string a = Console.ReadLine();
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        n.calculator(a,b,c);*/


        /*     int[] arr = new int[5];
             Console.WriteLine("Enter 5 Numbers");
             for (int i = 0; i < 5; i++)
             {
                 arr[i] = int.Parse(Console.ReadLine());
             }

              int max = arr[0];
              int min = arr[0];

         for (int i = 1; i < arr.Length; i++)
         {
             if (arr[i] > max)
             {
                 max = arr[i];
             }
             if (arr[i] < min)
             {
                 min = arr[i];
             }
         }

         Console.WriteLine($"\nMaximum number: {max}");
         Console.WriteLine($"Minimum number: {min}");
        */
        string a = Console.ReadLine();
        
        n.reversetring(a);

    }
}
