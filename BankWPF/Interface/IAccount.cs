using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Interface
{
    public interface IAccount
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
    }
}
