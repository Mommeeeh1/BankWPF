using BankWPF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    public class SalaryAccount : IAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; } = Math.Abs(Guid.NewGuid().GetHashCode());
    }
}
