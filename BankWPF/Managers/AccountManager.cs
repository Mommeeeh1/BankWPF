using BankWPF.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Managers
{
    public class AccountManager
    {
        public bool TransferFunds(IAccount senderAccount, IAccount targetAccount, decimal amount)
        {
            if (senderAccount.Balance >= amount)
            {
                senderAccount.Balance -= amount;
                targetAccount.Balance += amount;

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
