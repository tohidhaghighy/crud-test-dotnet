using Mc2.CrudTest.Domain.Base;
using Mc2.CrudTest.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Entities.Customer
{
    public class Customer:BaseEntity<Guid>
    {
        public Customer(PhoneNumber PhoneNumber, Email Email, BankAccountNumber BankAccountNumber, CustomerInfo CustomerInfo)
        {
            this.Id = Guid.NewGuid();
            this.PhoneNumber = PhoneNumber;
            this.Email = Email;
            this.BankAccountNumber = BankAccountNumber;
        }

        public Customer()
        {
        }

        public PhoneNumber PhoneNumber { get; private set; } 
        public Email Email { get; private set; }
        public BankAccountNumber BankAccountNumber { get; private set; }
        public CustomerInfo CustomerInfo { get; private set; }

        public CustomerInfo UpdateInfo(CustomerInfo customerInfo)
        {
            return this.CustomerInfo = customerInfo;
        }
        public PhoneNumber SetPhoneNumber(PhoneNumber phoneNumber)
        {
            return this.PhoneNumber = phoneNumber;
        }

        public Email SetEmail(Email email)
        {
            return this.Email = email;
        }

        public BankAccountNumber SetBankAccountNumber(BankAccountNumber bankAccountNumber)
        {
            return this.BankAccountNumber = bankAccountNumber;
        }
    }
}
