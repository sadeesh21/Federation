//using Federation.Models.Data;
using Federation.Models.Data;
using Microsoft.EntityFrameworkCore;
namespace Federation.Models
{
    public class FerderationDbContext : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmpAddressDtl> EmpAddressDtl { get; set; }

        public FerderationDbContext(DbContextOptions<FerderationDbContext> options) : base(options)
        {

            Database.EnsureCreated();
        }
    }
}
