using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWPF.Models
{
    public class Admin : User
    {
        public Admin(string username, string password)
        {
            base.Username = username;
            base.Password = password;
        }
    }
}
