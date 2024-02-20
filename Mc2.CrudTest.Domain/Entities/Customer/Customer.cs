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
        
        public PhoneNumber PhoneNumber { get; private set; }
        public Email Email { get; private set; }
        public BankAccountNumber BankAccountNumber { get; private set; }
        public CustomerInfo CustomerInfo { get; private set; }

        public void UpdateInfo(CustomerInfo customerInfo)
        {
            this.CustomerInfo = customerInfo;
        }
        public void SetPhoneNumber(PhoneNumber phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        public void SetEmail(Email email)
        {
            this.Email = email;
        }

        public void SetBankAccountNumber(BankAccountNumber bankAccountNumber)
        {
            this.BankAccountNumber = bankAccountNumber;
        }
    }
}
