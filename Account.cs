using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // Struct to store customer information
    struct customer
    {
        public string name;     // Customer's name 
        public string phone;    // Customer's Phone
        public string Address;  // Customer's Address
    }

    // Base class for all types of bank accounts
    class Account
    {
        public static int UniqueId = 1000;    // Static variable to generate unique account IDs
        public int AccountId;                // Account ID for this specific account
        public double Balance;              // Current balance of the account
        public customer customerData;      // Stores the customer's information

        // Method to create a new account
        public void NewAccount() 
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your name : "); 
            customerData.name = Console.ReadLine();
            
            Console.Write("Enter your phone : "); 
            customerData.phone = Console.ReadLine();

            Console.Write("Enter your address : "); 
            customerData.Address = Console.ReadLine();

            AccountId = UniqueId++;    // Assign a unique account ID

            Console.Write("Enter your initial Balance \\ deboist : ");
            Balance = 0;

            // Validate the input to ensure the balance is a positive double
            ValidInput.ValidationOfPositiveDouble(ref Balance);
            Console.ResetColor();

            // Display success message in green
            Console.ForegroundColor = ConsoleColor.Green; 
            Console.WriteLine($"\n      Account created successfully! Your Account ID is: {AccountId} \n");
            Console.ResetColor();
        }

        // Virtual method to deposit money into the account
        public virtual void Deposit(double Amount)
        {
            if (Amount > 0)
            {
                Balance += Amount;   // Add amount to balance

                // Display success message in green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n      Deposit Successfully ! New Balance = {Balance}\n");
                Console.ResetColor();
            }
            else
            {
                // Display error message in red
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    Invalid amount to deposit .\n");
                Console.ResetColor();
            }
        }

        // Virtual method to withdraw money from the account
        public virtual void Withdraw(double amount)
        {
              
            if(amount <= (Balance))
            {
                Balance -= amount;     // Subtract amount from balance

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" \n    Withdraw successful ! Your current Balance = {Balance}\n");
                Console.ResetColor();
            }
            else
            {
                // Display error message if balance is insufficient
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    Invalid amount to Withdraw.\n");
                Console.ResetColor();
            }
        }
    }
}
