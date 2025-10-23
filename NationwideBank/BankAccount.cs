using System;

namespace NationwideBank
{

    public class BankAccount
    {
       
        public string Name;
        public string Type;     
        public double Balance;

        // set up an account
        public void CreateAccount(string name, string type, double openingBalance)
        {
            Name = name;
            Type = type;

            // Savings account restriction: cannot be zero (set to £1 minimum)
            if (type.ToLower() == "savings" && openingBalance <= 0)
            {
                Console.WriteLine("⚠️ Savings account cannot start at £0. Setting to £1.");
                Balance = 1;
            }
            else if (openingBalance <= 0)
            {
                Console.WriteLine("⚠️ Opening balance must be greater than £0. Setting to £1.");
                Balance = 1;
            }
            else
            {
                Balance = openingBalance;
            }
        }

        // put money in
        public void Credit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"✅ £{amount} credited. New balance: £{Balance}");
            }
            else
            {
                Console.WriteLine("⚠️ Amount must be positive.");
            }
        }

        // take money out
        public void Debit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("⚠️ Amount must be greater than zero.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("❌ Insufficient funds.");
            }
            else if (Type.ToLower() == "savings" && (Balance - amount) < 1)
            {
                Console.WriteLine("❌ Savings account cannot go below £1.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"💸 £{amount} debited. New balance: £{Balance}");
            }
        }

        public void ShowDetails()
        {
            Console.WriteLine("\n=== Account Details ===");
            Console.WriteLine("Name   : " + Name);
            Console.WriteLine("Type   : " + Type);
            Console.WriteLine("Balance: £" + Balance);
        }
    }
}
