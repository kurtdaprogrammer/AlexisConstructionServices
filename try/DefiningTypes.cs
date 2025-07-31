using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


public interface IPerson
{
    public String fname { get; set; }
    public String lname { get; set; }
    public String address { get; set; }
}

public class Employee : IPerson
{
    public Employee()
    {
        
    }
    public Employee(string firstname, string lastname, string add, int emp_id)
    {
        fname = firstname;
        lname = lastname;
        address = add;
        employee_id = emp_id;
    }
    public string fname { get; set; }
    public string lname { get; set; }
    public string address { get; set; }

    //employee properties
    public int employee_id { get; set; }
    public string contactnumber { get; set; }
}

public interface Calculator
{
    public int input1 {  get; set; }
    public int input2 { get; set; }
    public int total {  get; set; }
}

public class Operators: Calculator
{
    public int Add(int inp1, int inp2)
    {
        return inp1 + inp2;
    }
    public int Subtraction(int inp1, int inp2)
    {
        return inp1 - inp2;
    }
    public int input1 { get; set; }
    public int input2 { get; set; }
    public int total { get; set; }
}

public interface Palindrome
{
   public String input1 { get; set; }
}
public class palindromeoperator : Palindrome
{
    
    public string input1 { get; set; }

    public bool isPalindrome()
    {
        string reversed = new string (input1.Reverse ().ToArray());
        return input1.Equals(reversed, StringComparison.OrdinalIgnoreCase);
    }
}


public class Try : Input
{
    public int input1 { get; set; }
    public int input2 { get; set; }

    public int Minus(int input1, int input2)
    {
        return input1 - input2;
    }
}
public class Try2 : Input
{
    public int add(int input1, int input2)
    {
        return input1 + input2;
    }
    public int input1 { get; set; }
    public int input2 { get; set; }

   
}

public interface Input
{
    public int input1 { get; set; }
    public int input2 { get; set; }
}
public class fizzbuzz : Input {
    public int input1 { get; set; }
    public int input2 { get; set; }


    public void fizzdetect(int input1) {
        for (int i = 1; i < input1; i++)
        {
            if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else if (i % 2 == 0)
            {
                Console.WriteLine("Fizzbuzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}