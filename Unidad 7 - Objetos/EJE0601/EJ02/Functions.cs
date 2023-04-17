using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ02
{
    internal class Functions
    {
        public static decimal IntroduceMoney()
        {
            Console.WriteLine("How much money are you going to introduce to the machine?");
            return DoubleValue(lowerLimit: 0, upperLimit: 100); ;
        }
        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        {
            int userInput;
            bool check = false;
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            Console.WriteLine(":");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine("Input value not within the specified range. Enter a new value between " + lowerLimit + " and " + upperLimit + ":");
                else
                    check = true;
            } while (!check);
            return userInput;
        }

        public static decimal DoubleValue(decimal lowerLimit = decimal.MinValue, decimal upperLimit = decimal.MaxValue, int maxDecimalPlaces = int.MaxValue)
        {
            decimal userInput;
            bool check = false;
            Console.Write("Input a value");
            if (lowerLimit != decimal.MinValue && upperLimit != decimal.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            else if (lowerLimit != decimal.MinValue && upperLimit == decimal.MaxValue)
                Console.Write(" higher than " + lowerLimit);
            else if (upperLimit != decimal.MaxValue && lowerLimit == decimal.MinValue)
                Console.Write(" lower than " + upperLimit);
            Console.WriteLine(":");

            do
            {
                string input = Console.ReadLine() ?? "";
                if (!decimal.TryParse(input, out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine($"Input value not within the specified range. Enter a new value between the accepted range:");
                else if (input.Contains(".") && input.Split('.')[1].Length > maxDecimalPlaces)
                    Console.WriteLine($"Input value cannot have more than {maxDecimalPlaces} decimal places. Enter a new value:");
                else
                    check = true;
            } while (!check);
            Console.Clear();
            return userInput;
        }

        public static void EndMethod()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
