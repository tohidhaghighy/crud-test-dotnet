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
        public string Number { get; set; }
        public PhoneNumber(string number) 
        { 
            this.Number = number;
            if (!Regex.IsMatch(number, @"/d{3}-/d{3}-/d{4}"))
            {
                throw new Exception("This is not number format");
            }
        }
    }
}
