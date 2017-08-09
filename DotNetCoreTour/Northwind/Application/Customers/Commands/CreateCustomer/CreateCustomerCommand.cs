﻿using NorthwindTraders.Domain;
using NorthwindTraders.Persistence;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICreateCustomerCommand
    {
        private readonly NorthwindContext _context;

        public CreateCustomerCommand(NorthwindContext context)
        {
            _context = context;
        }

        public async Task Execute(CreateCustomerModel model)
        {
            var entity = new Customer
            {
                CustomerId = model.Id,
                Address = model.Address,
                City = model.City,
                CompanyName = model.CompanyName,
                ContactName = model.ContactName,
                ContactTitle = model.ContactTitle,
                Country = model.Country,
                Fax = model.Fax,
                Phone = model.Phone,
                PostalCode = model.PostalCode
            };

            _context.Customers.Add(entity);

            await _context.SaveChangesAsync();
        }
    }
}
