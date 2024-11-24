namespace Challenge.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateAsync(Customer customer);
        Task<List<Customer>> GetAllAsync(int pageNumber = 1, int pageSize = 100);
        Task<Customer?> UpdateAsync(int customerNumber, Customer customer);
    }
}
