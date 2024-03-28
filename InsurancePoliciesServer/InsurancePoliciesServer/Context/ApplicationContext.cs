using InsurancePoliciesServer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InsurancePoliciesServer.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<InsurancePolicies> InsurancePolicies { get; set; }
    }
}
