using System;

class Program
{
    public void fizzbuzz()
    {
        for (int i = 1; i <= 100; i++)  // Start from 1, not 0
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }

    public void Add(int a,int b)
    {
        Console.WriteLine(a + b);
    }

    public void StringtoInt()
    {
        string a = "3";
        string b = "2";  
        Console.WriteLine(int.Parse(a)+int.Parse(b));
        
    }

    public void EvenorOdd(int a)
    {
        if (a % 2 == 0)
        {
            Console.WriteLine("Even");

        }
        else
        {
            Console.WriteLine("Odd");
        }
    }

    public void Multiply(int a, int b)
    {
        Console.WriteLine(a * b);

    }

    public void palindromechecker(string a)
    {

        string inputedstring = a.Trim().ToLower();

        char[] arr = inputedstring.ToCharArray();

        Array.Reverse(arr);
        string reversed = new string(arr);

        if (inputedstring==reversed)
        {
            Console.WriteLine("palindrome");
        }
        else
        {
            Console.WriteLine("not palindrome");
        }


    }

    public void calculator(string a,int b, int c){
        if (a == "+")
        {
            Console.WriteLine(b + c);
        }
        else if (a == "/")
        {
            Console.WriteLine(b / c);
        }
        else if (a == "*")
        {
            Console.WriteLine(b * c);
        }
        else if (a == "-")
        {
            Console.WriteLine(b - c);
        }
    }

    public void reversetring(string a) {
        char[] arr = a.ToCharArray();
        Array.Reverse(arr);
        string reverse = new string(arr);
        Console.WriteLine(reverse);
    }

    public void calculator(int a,int b)
    {

    }
}


    
