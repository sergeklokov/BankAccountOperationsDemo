using System;

namespace BankAccountOperationsDemo.Models
{
    public enum TransactionType
    {
        Credit,
        Debit
    }

    public class Transaction
    {
        public DateTime Date { get; }
        public TransactionType Type { get; }
        public decimal Amount { get; }
        public decimal BalanceAfter { get; }
        public string Description { get; }

        public Transaction(DateTime date, TransactionType type, decimal amount, decimal balanceAfter, string? description = null)
        {
            Date = date;
            Type = type;
            Amount = amount;
            BalanceAfter = balanceAfter;
            Description = description ?? string.Empty;
        }
    }
}
