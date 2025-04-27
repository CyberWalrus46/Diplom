using Microsoft.EntityFrameworkCore;
using Some_API.Data.Entities;

namespace Some_API.Data
{
    public class EmployeeDbContext : DbContext
    {
        //public readonly
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}
