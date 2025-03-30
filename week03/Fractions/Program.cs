using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.\n");

        Fraction defaultFraction = new Fraction();
        Fraction wholeNumberFraction = new Fraction(5);
        Fraction customFraction = new Fraction(3, 4);

        Console.WriteLine("Default: " + defaultFraction.GetFractionString());
        Console.WriteLine("Decimal: " + defaultFraction.GetDecimalValue());
        
        Console.WriteLine("Whole Number: " + wholeNumberFraction.GetFractionString());
        Console.WriteLine("Decimal: " + wholeNumberFraction.GetDecimalValue());

        Console.WriteLine("Custom: " + customFraction.GetFractionString());
        Console.WriteLine("Decimal: " + customFraction.GetDecimalValue());

        // Testing Getters and Setters
        customFraction.SetTop(1);
        customFraction.SetBottom(3);
        Console.WriteLine("Updated Fraction: " + customFraction.GetFractionString());
        Console.WriteLine("Update Decimal: " + customFraction.GetDecimalValue()); 
        

    }
}