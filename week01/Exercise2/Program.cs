using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string response = Console.ReadLine();
        int percentage = int.Parse(response);

        string grade = "";
        string sign = "";

        if(percentage >= 90)
        {
            grade = "A";
        } 
        else if (percentage >= 80)
        {
            grade = "B";
        }
        else if (percentage >= 70)
        {
            grade = "C";
        }
        else if (percentage >= 60) 
        {
            grade = "D";
        } else
        {
            grade = "F";
        }

        int lastDigit = percentage % 10;

        if(grade != "A" && grade != "F")
        {
            if(lastDigit >= 7)
            {
                sign = "+";
            }
            else if(lastDigit <= 3)
            {
                sign = "-";
            }
        }
        else if(grade == "A" && lastDigit <= 3)
        {
            sign = "-";
        }

        Console.WriteLine($"Your grade is: {grade}{sign}");

        if(percentage >= 70)
        {
            Console.WriteLine("You passed!");
        } 
        else
        {
            Console.WriteLine("Better Luck next time!");
        }
    }
}