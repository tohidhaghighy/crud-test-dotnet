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
        public string Number { get; private set; }
        public PhoneNumber(string number) 
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            string countryCode = "US";
            PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(number, countryCode);
            bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
            if (!isValidNumber)
            {
                throw new Exception("This is not number format");
            }
            this.Number = number;
        }

        public PhoneNumber()
        {
        }
        public static PhoneNumber? Create(string number)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            string countryCode = "US";
            PhoneNumbers.PhoneNumber phoneNumber = phoneUtil.Parse(number, countryCode);
            bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber);
            if (!isValidNumber)
            {
                throw new Exception("This is not number format");
            }
            return new PhoneNumber(number);
        }
    }
}
