using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // Static class for validating user input
    static class ValidInput
    {
        // Validate positive integer input
        public static int ValidationOfPositiveInt(ref int value)
        {

            do
            {
                string input = Console.ReadLine();

                // Try to convert input to int and check if it's positive
                if (!int.TryParse(input, out value) || value<0 )
                {
                    // Display error message in dark red
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" Invalid input! Please enter a valid number : ");
                    Console.ResetColor();
                }
                else
                {
                    break; // Input is valid, exit loop
                }
            } while (true);

            return value;   // Return the validated value
        }
        // Validate positive double input
        public static double ValidationOfPositiveDouble(ref double value)
        {

            do
            {
                string input = Console.ReadLine();

                // Try to convert input to double and check if it's positive
                if (!double.TryParse(input, out value) || value< 0)
                {
                    // Display error message in dark red
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" Invalid input! Please enter a valid number : ");
                    Console.ResetColor();
                }
                else
                {
                    break;
                }
            } while (true);    // Input is valid, exit loop

            return value;  // Return the validated value
        }
    
    }
}
