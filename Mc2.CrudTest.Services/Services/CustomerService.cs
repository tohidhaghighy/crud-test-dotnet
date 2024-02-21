﻿using Mc2.CrudTest.Domain.Entities.Customer;
using Mc2.CrudTest.Domain.Interfaces.Customer;
using Mc2.CrudTest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Services.Services
{
    public class CustomerService : ICustomerService
    {
        public CustomerService(CustomerDbContext _dbContext)
        {
            DbContext = _dbContext;
        }

        public CustomerDbContext DbContext { get; }

        public async Task<Customer> AddAsync(Customer entity)
        {
            var customer = new Customer(entity.PhoneNumber, entity.Email, entity.BankAccountNumber, entity.CustomerInfo);

            await DbContext.Customers.AddAsync(customer);
            await DbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<bool> DeleteAsync(Customer entity)
        {
            var customer = DbContext.Customers.Remove(entity);
            return customer!=null?true:false;
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            var result = await DbContext.Customers.Where(expression).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Customer>> ListAsync(Expression<Func<Customer, bool>> expression)
        {
            var result = await DbContext.Customers.Where(expression).ToListAsync();
            return result;
        }

        public async Task<Customer> UpdateAsync(Customer entity)
        {
            var customer= DbContext.Customers.Update(entity);
            return customer.Entity;
        }
    }
}
