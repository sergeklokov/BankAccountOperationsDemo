using System;
using BankAccountOperationsDemo.Models;

Console.WriteLine("Bank Account Demo\n");

var account = new BankAccount("Alice");

account.Deposit(1000m, "Initial deposit");
account.Withdraw(250.75m, "ATM withdrawal");
account.Deposit(500m, "Paycheck");

try
{
    account.Withdraw(2000m, "Attempt overdraft");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Operation failed: {ex.Message}\n");
}

Console.WriteLine($"Current balance: {account.Balance:C}\n");

Console.WriteLine("Transaction history:");
foreach (var t in account.GetTransactions())
{
    Console.WriteLine($"{t.Date:yyyy-MM-dd HH:mm:ss} | {t.Type} | {t.Amount:C} | Balance: {t.BalanceAfter:C} | {t.Description}");
}

