using System;

/*Employee e = new Employee("Kurt","David","Toril",15);
Console.WriteLine($"From {e.fname} {e.lname} {e.address} {e.employee_id},Hello World!");
Employee e2 = new Employee();
e2.fname = "Alyssa";
e2.contactnumber = "09453902952";

Console.WriteLine($"The Contact Number {e2.contactnumber} {e2.fname}");


Operators operators = new Operators();
int addresult = operators.Add(3, 5);
int subtractionresult = operators.Subtraction(8, 5);
Console.WriteLine($"Add Operator {addresult}");
Console.WriteLine($"Subtraction Operator {subtractionresult}");

palindromeoperator palindromeoperator = new palindromeoperator();
palindromeoperator.input1 = "NoN";
Console.WriteLine($"Palindrome Operator {palindromeoperator.isPalindrome()}");*/

fizzbuzz fizzbuzz = new fizzbuzz();
int input = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Fizzbuzz Detector :");
fizzbuzz.fizzdetect(input);

