using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Bank_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Welcome message with magenta color

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("         =============================\n");
            Console.WriteLine("          Welcome to Our Bank System.    \n");
            Console.WriteLine("         =============================\n");

            // Display system features in yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ==== Features Of System ==== \n");

            Console.WriteLine("1. Creat New Account.");
            Console.WriteLine("2. Deposit to Account.");
            Console.WriteLine("3. Withdraw from Account. ");
            Console.WriteLine("4. Apply Interests Of Savings account.");
            Console.WriteLine("5. Display all acounts.");
            Console.WriteLine("6. Exit.");
            Console.WriteLine();

            BankManage BankManager = new BankManage();    // Create object of BankManage

            char answer;
            do
            {
                // Ask for user input in cyan
                Console.ForegroundColor = ConsoleColor.Cyan;
               
                Console.Write("Enter your choice number (1 -> 6): ");
                Console.ResetColor();

                int number = 0;

                // Validate input: must be integer between 1 and 6
                while (!int.TryParse(Console.ReadLine(), out number) || number < 1 || number > 6)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("Invalid number . try again : ");
                    Console.ResetColor();

                    continue;
                }
                // Execute chosen operation
                switch (number)
                {
                    case 1:
                   
                        BankManager.TypeOfAccount();     // Create new account
                        break;

                    case 2:

                        BankManager.DepositToAccount();    // Deposit to account
                        break;

                    case 3: 
                        BankManager.WithdrawFromAccount();  // Withdraw from account
                        break;

                    case 4:
                        BankManager.ApplyInterestsOfSavings();   // Apply interest to savings
                        break;

                    case 5:
                        BankManager.DisplayAllAccounts();  // Display all accounts
                        break;

                    case 6:
                        // Exit the system
                        Console.ForegroundColor= ConsoleColor.Green;
                        Console.WriteLine("  \n ===== Thank you for Using our Bank System. =====\n");
                        Console.ResetColor();

                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n   Invalid number .\n");
                        Console.ResetColor();
                        break;
                }

                // Ask users if they want to perform another action
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Do you want to choose another feature ? --> (y|Y): ");
                Console.ResetColor();

                string input = Console.ReadLine();

                // If input is empty, treat as 'no'
                if (string.IsNullOrWhiteSpace(input))
                {
                    answer = 'n';
                }
                else
                {
                    answer = input[0];    // Take first character
                }

            } while (answer == 'y' || answer == 'Y');     // Loop while user wants to continue

            // Goodbye message in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n===== Thank you for using our Bank System. See you again! =====\n");
            Console.ResetColor();
        }
    }
}
