using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Entities.Customer
{
    public record CustomerInfo(string FirstName, string LastName, DateTime DateOfBirth);
}
