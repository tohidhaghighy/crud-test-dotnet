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
        
        public PhoneNumber PhoneNumber { get; }
        public Email Email { get; }
        public BankAccountNumber BankAccountNumber { get; }
        public CustomerInfo CustomerInfo { get; private set; }

        public void UpdateInfo(CustomerInfo customerInfo)
        {
            this.CustomerInfo = customerInfo;
        }



    }
    public record CustomerInfo(string FirstName, string LastName, DateTime DateOfBirth);

}
