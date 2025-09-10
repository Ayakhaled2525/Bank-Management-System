using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_System
{
    // BankManage class manages all accounts and operations
    class BankManage
    {
        public List<Account> accounts = new List<Account>();    // List to store all accounts

        // Method to choose account type and create account
        public void TypeOfAccount()
        {

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n   ==== Types Of Account. ====\n");
            Console.WriteLine("1. Savings Account.");
            Console.WriteLine("2. Current Account.");
            Console.ResetColor();
            Console.WriteLine();

            int choice=0;

            // Create savings account
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter Choice number : ");
            Console.ResetColor();
            ValidInput.ValidationOfPositiveInt(ref choice);
           

            switch (choice)
            {
                case 1:
                    
                    CreatSavingsAccount();     // Create savings account
                    break;

                case 2:
                    CreatCurrentAccount();    // Create current account
                    break;

                default:
                    // Invalid choice message in Red
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n    Invalid Choice .\n");
                    Console.ResetColor();

                    break;
            }

        }

        // Create a new savings account
        public void CreatSavingsAccount()
        {
            SavingsAccount savingaccount = new SavingsAccount();    

            savingaccount.NewAccount();      // Call method to fill account details

            accounts.Add(savingaccount);     // Add account to list
        }

        // Create a new current account
        public void CreatCurrentAccount()
        {
            CurrentAccount currentaccount = new CurrentAccount();

            currentaccount.NewAccount();     // Call method to fill account details

            accounts.Add(currentaccount);    // Add account to list
        }

        // Find an account by its ID
        private Account FindAccount(int id)
        {
            foreach (Account acc in accounts)
            {
                if(acc.AccountId == id)
                {
                    return acc;    // Return account if found
                }
            }   
                return null;    // Return null if not found  
        }


        public void DepositToAccount()
        {
            int id = 0;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your  account Id : ");
           ValidInput.ValidationOfPositiveInt(ref id);     // Validate ID input

            Account account = FindAccount(id);    // Find account by ID

            if (account != null)
            {
                
                Console.Write("Enter the amount to deposit : ");
                Console.ResetColor();

                double amount = 0;
                ValidInput. ValidationOfPositiveDouble(ref amount);    // Validate deposit amount

                account.Deposit(amount);     // Call account's deposit method
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n     Account Not found\n");     // Error if account doesn't exist
                Console.ResetColor();
            }
        }

        // Withdraw money from a specific account
        public void WithdrawFromAccount()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your Account Id : ");
            Console.ResetColor();

            int id = 0;
            ValidInput.ValidationOfPositiveInt(ref id);     // Validate ID input

            Account account = FindAccount(id);     // Find account by ID

            if (account != null)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the amount to Withdraw : ");
                Console.ResetColor();

                double amount = 0;
                ValidInput.ValidationOfPositiveDouble(ref amount);    // Validate withdrawal amount

                account.Withdraw(amount);   // Call account's withdraw method
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n     Account Not found\n");    // Error if account doesn't exist
                Console.ResetColor();
                Console.ResetColor();
            }
        }

        // Apply interest to a savings account
        public void ApplyInterestsOfSavings()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Enter your Account Id : ");
            Console.ResetColor();

            int id = 0;
            ValidInput.ValidationOfPositiveInt(ref id);  // Validate ID input

            Account account= FindAccount(id);  // Find account by ID

            if (account != null && account is SavingsAccount saving)
            {
                saving.ApplyInterest();  // Apply interest if account is savings
            }
            else
            {
                // Error message if not savings in Red
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n      Account isn't savings account or not found .\n");
                Console.ResetColor();
            }
        }
        // Display all accounts with their details
        public void DisplayAllAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    No accounts found in the system!\n");   // Error if list empty
                Console.ResetColor();

                return;
            }
            // print All details
            foreach (Account account in accounts)
            {

                if (account is SavingsAccount)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("      ---> Savings account <---\n");
                    Console.WriteLine($" * ID = {account.AccountId} \n * Name ={account.customerData.name}\n * Phone = {account.customerData.phone} \n * Address = {account.customerData.Address}\n * Balance = {account.Balance}\n ");
                    Console.ResetColor();
                    Console.WriteLine("\n    ------------------------\n");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("      ---> Current account <---\n");
                    Console.WriteLine($" * ID = {account.AccountId} \n * Name ={account.customerData.name}\n * Phone = {account.customerData.phone} \n * Address = {account.customerData.Address}\n * Balance = {account.Balance}\n ");

                    Console.ResetColor();
                    Console.WriteLine("\n    ------------------------\n");
                }
            }
        }
    }
}
