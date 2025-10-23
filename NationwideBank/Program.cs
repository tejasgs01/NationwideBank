using System;

namespace NationwideBank
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== Nationwide Bank Account System ===\n");

            BankAccount account = new BankAccount();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter account type (Savings / Current): ");
            string type = Console.ReadLine();

            Console.Write("Enter opening balance: ");
            double opening;
            while (!double.TryParse(Console.ReadLine(), out opening) || opening < 0)
            {
                Console.Write("Please enter a valid non-negative number: ");
            }

           
            account.CreateAccount(name, type, opening);
            account.ShowDetails();

          
            Console.Write("\nEnter amount to credit: ");
            double creditAmt;
            while (!double.TryParse(Console.ReadLine(), out creditAmt))
            {
                Console.Write("Enter a valid number: ");
            }
            account.Credit(creditAmt);

            Console.Write("Enter amount to debit: ");
            double debitAmt;
            while (!double.TryParse(Console.ReadLine(), out debitAmt))
            {
                Console.Write("Enter a valid number: ");
            }
            account.Debit(debitAmt);

            // final details
            account.ShowDetails();

            Console.WriteLine("\nThank you for banking with Nationwide! Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
