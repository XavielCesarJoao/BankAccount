using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_List
{
    class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number { get; }
        public string Owner { get; set; }
        public string Note { get; set; }
        public decimal Balance 
        {   get
            {
                decimal balance = 0;
                foreach (var item in allTransations)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        public BankAccount (string name, decimal initialBalance)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            MakeDeposit(initialBalance, DateTime.Now , "Abertura de conta para " + Owner);
        }
        private List<Transaction> allTransations = new List<Transaction>();
        public void MakeDeposit (decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor do depósito deve ser positivo");
            }
            var deposit = new Transaction(amount, date, note);
            allTransations.Add(deposit);
        }
        public void MakeWithdrawal (decimal amount, DateTime date, string note)
        {
            if(amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor para retirada deve ser positivo");
            }
            if(Balance - amount < 0)
            {
                throw new InvalidOperationException("Não há fundos suficientes para esta retirada");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransations.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();
            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach(var item in allTransations)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return report.ToString();
        }

    }
}
