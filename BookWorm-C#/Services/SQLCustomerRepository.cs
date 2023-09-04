using BookWorm_C_.Entities;
using BookWorm_C_.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookWorm_C_.Services
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly AppdbContext _context;

        public SQLCustomerRepository(AppdbContext context)
        {
            _context = context;
        }
        public Task<List<Customer>> GetAllCustomers()
        {
            return  _context.Customers.ToListAsync();
        }

        public Task<Customer> GetById(long id)
        {
            return _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }
    }
}
