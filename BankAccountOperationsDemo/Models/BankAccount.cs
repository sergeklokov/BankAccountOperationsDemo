using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAccountOperationsDemo.Models
{
    public class BankAccount
    {
        private readonly List<Transaction> _transactions = new();

        public string Owner { get; }

        public decimal Balance => _transactions.Count == 0 ? 0m : _transactions.Last().BalanceAfter;

        public BankAccount(string owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public void Deposit(decimal amount, string? description = null)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Deposit amount must be positive.");

            var newBalance = Balance + amount;
            var transaction = new Transaction(DateTime.UtcNow, TransactionType.Credit, amount, newBalance, description ?? "Deposit");
            _transactions.Add(transaction);
        }

        public void Withdraw(decimal amount, string? description = null)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Withdrawal amount must be positive.");
            if (amount > Balance) throw new InvalidOperationException("Insufficient funds.");

            var newBalance = Balance - amount;
            var transaction = new Transaction(DateTime.UtcNow, TransactionType.Debit, amount, newBalance, description ?? "Withdrawal");
            _transactions.Add(transaction);
        }

        public IReadOnlyList<Transaction> GetTransactions() => _transactions.AsReadOnly();
    }
}
