using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // CurrentAccount class inherits from Account
    // Represents a current account with an overdraft facility
    class CurrentAccount : Account
    {
        public static double OverdraftLimit = 2000;   // Maximum allowed overdraft

        // Override Deposit method for CurrentAccount
        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;     // Add deposit to balance

                // Display success message in green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n     Deposit Successful ! New Balance = {Balance}\n");
                  Console.ResetColor();
            }
            else
            {
                // Display error message if deposit is invalid
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n     Invalid amount to deposit.\n");
                Console.ResetColor();
            }
        }

        // Override Withdraw method for CurrentAccount
        public override void Withdraw(double amount)
        {

            // Allow withdrawal up to balance + overdraft limit
            if (amount <= (Balance + OverdraftLimit))
            {
                Balance -= amount;     // Subtract withdrawal from balance

                // Display success message in green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n     Withdraw successful ! Your current Balance = {Balance}\n");
                Console.ResetColor();
            }
            else
            {
                // Display error if withdrawal exceeds overdraft limit
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n     Your balance is not enough! \n");
                Console.ResetColor();
            }
        }
    }
}
