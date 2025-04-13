using Microsoft.EntityFrameworkCore;
using Some_API.Data.Entities;

namespace Some_API.Data
{
    public class MerchantDbContext : DbContext
    {
        //public readonly
        public MerchantDbContext(DbContextOptions<MerchantDbContext> options) : base(options)
        {
        }

        public DbSet<MerchantEntity> Merchants { get; set; }
    }
}
