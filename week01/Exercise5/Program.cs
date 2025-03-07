using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string userName = PromptUserName();
        int favouriteNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(favouriteNumber);

        DisplayResult(userName, squaredNumber);

    }
    
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program ");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        return (number * number);
    }

    static void DisplayResult(string userName, int square)
    {
        Console.WriteLine($"Brother {userName}, the square of your number is {square}");
    }


}