using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.ValueObjects
{
    public class Email
    {
        private string EmailAddress { get; set; }
        public Email(string email)
        {
            this.EmailAddress = email;
            if (!Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                throw new Exception("This is not email format");
            }
        }
    }
}
