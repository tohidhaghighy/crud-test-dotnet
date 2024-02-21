using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record BankAccountNumber
    {
        public string BankAccount { get; private set; }
        public BankAccountNumber(string bankAcount)
        {
            if (!Regex.IsMatch(bankAcount, @"^[0-9]{9,18}$"))
            {
                throw new Exception("This is not account number format");
            }
            this.BankAccount = bankAcount;
        }
        public BankAccountNumber()
        {
        }

        public static BankAccountNumber? Create(string bankAcount)
        {
            if (!Regex.IsMatch(bankAcount, @"^[0-9]{9,18}$"))
            {
                throw new Exception("This is not account number format");
            }
            return new BankAccountNumber(bankAcount);
        }
    }
}
