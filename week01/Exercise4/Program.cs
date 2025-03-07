using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;
        do
        {
            Console.Write("Enter a number (0 to quit): ");
            string response = Console.ReadLine();
            userNumber = int.Parse(response);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }

        }
        while (userNumber != 0);
        {

            if (numbers.Count > 0)
            {
                int sum = 0;
                foreach (int number in numbers)
                {
                    sum += number;
                }

                Console.WriteLine($"The sum is: {sum}");

                float average = ((float)sum) / numbers.Count;
                Console.WriteLine($"The average is: {average}");

                int maxNumber = numbers[0];

                foreach (var number in numbers)
                {
                    if (number > maxNumber)
                    {
                        maxNumber = number;
                    }
                }

                Console.WriteLine($"The max number: {maxNumber}");

            }

        }

    }
}