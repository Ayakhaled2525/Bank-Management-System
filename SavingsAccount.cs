using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // SavingsAccount class inherits from Account
    // Represents a savings account with interest
    class SavingsAccount : Account
    {

        public  static double InterestRate = 0.05;   // Interest rate for savings accounts

        // Override Deposit method for SavingsAccount
        public override  void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;     // Add deposit amount to balance

                // Display success message in green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n     Deposit Successful ! New Balance = {Balance}\n");
                Console.ResetColor();
            }
            else
            {
                // Display error message if amount is invalid
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    Invalid amount to deposit.\n");
                Console.ResetColor();
            }
        }
        // Override Withdraw method for SavingsAccount
        public override void Withdraw(double amount)
        {
            if(amount <= Balance)
            {
                Balance -= amount;  // Subtract withdrawal from balance]

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n    Withdraw Successful ! Your Current Balance = {Balance}\n");
                Console.ResetColor();
            }
            else
            {
                // Display error message if balance is insufficient
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    Your balance is not enough!\n");
                Console.ResetColor();
            }
        }
        // Apply interest to the savings account
        public void ApplyInterest()
        {
            double interest = Balance * InterestRate;    // Calculate interest
            Balance += interest;        // Add interest to balance


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n   Interest Applied = {interest} ! Your New Balance ={Balance}\n");
            Console.ResetColor();
        }
    }
}
