﻿using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Persistence;
using System.Threading.Tasks;

namespace NorthwindTraders.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IDeleteCustomerCommand
    {
        private readonly NorthwindContext _context;

        public DeleteCustomerCommand(NorthwindContext context)
        {
            _context = context;
        }

        public async Task Execute(string id)
        {
            var entity = await _context.Customers.SingleAsync(c => c.CustomerId == id);

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
