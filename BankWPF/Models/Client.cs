using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    public class Client : User
    {
        public SavingsAccount SavingsAccount { get; set; } = new();
        public SalaryAccount SalaryAccount { get; set; } = new();

        private decimal GetTotalFunds()
        {
            return SavingsAccount.Balance + SalaryAccount.Balance;
        }

        public string GetInfo()
        {
            return $"{base.Username} || Total funds: ${GetTotalFunds().ToString()}";
        }

    }
}
