using Challenge.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<List<Customer>> GetAllAsync(int pageNumber = 1, int pageSize = 100)
        {
            var customers = _dbContext.Customers.AsQueryable();
            customers.OrderBy(x => x.CustomerNumber);
            var skipResults = (pageNumber - 1) * pageSize;

            return await customers.Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<Customer?> UpdateAsync(int customerNumber, Customer customer)
        {
            var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);

            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.DateOfBirth = customer.DateOfBirth;
            existingCustomer.CustomerName = customer.CustomerName;
            existingCustomer.Gender = customer.Gender;

            await _dbContext.SaveChangesAsync();

            return existingCustomer;
        }
    }
}
