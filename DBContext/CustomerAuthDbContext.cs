using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Challenge.DBContext
{
    public class CustomerAuthDbContext : IdentityDbContext
    {
        public CustomerAuthDbContext(DbContextOptions<CustomerAuthDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

    }
}
