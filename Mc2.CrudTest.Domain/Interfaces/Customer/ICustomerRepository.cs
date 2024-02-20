using Mc2.CrudTest.Domain.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Interfaces.Customer
{
    public interface ICustomerService : IAsyncRepository<Entities.Customer.Customer>
    {

    }
}
