using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Tests.Customer.CustomerCrudService
{
    public class Add_New_Customer
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Add_New_Customer(Customer customer)
        {
            // Arrange
            var service = new CustomerService();

            // Act

            var customer = service.AddCustomer(customer);

            // Assert
            Assert.NotNull(customer);

        }

        public static IEnumerable<Customer> Data()
        {
            yield return new Customer { new Customer() { } };
            yield return new Customer { new Customer() { } };
            yield return new Customer { new Customer() { } };
            yield return new Customer { new Customer() { } };
        }
    }
}
