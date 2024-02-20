using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public record PhoneNumber
    {
        private readonly PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
        public string Number { get; set; }
        public PhoneNumber(string number) 
        { 
            this.Number = number;
            string countryCode = "US";
            PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(number, countryCode);
            bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
            if (!isValidNumber)
            {
                throw new Exception("This is not number format");
            }
        }
    }
}
