using Core;
using Microsoft.EntityFrameworkCore;
using Some_API.Abstractions;
using Some_API.Data;
using Some_API.Data.Entities;

namespace Some_API.Repositories
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly MerchantDbContext context;
        public MerchantRepository(MerchantDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Merchant>> Get()
        {
            var merchantEntities = await context.Merchants
                .AsNoTracking()
                .ToListAsync();

            var merchants = merchantEntities
                .Select(m => Merchant.Create(m.Id, m.Title, m.Status, m.Description).merchant)
                .ToList();

            return merchants;
        }

        public async Task<Guid> Create(Merchant merchant)
        {
            var merchantEntity = new MerchantEntity
            {
                Id = merchant.Id,
                Title = merchant.Title,
                Status = merchant.Status,
                Description = merchant.Description
            };
            await context.Merchants.AddAsync(merchantEntity);
            await context.SaveChangesAsync();

            return merchantEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string status, string description)
        {
            await context.Merchants
                .Where(m => m.Id == id)
                .ExecuteUpdateAsync(x => x
                .SetProperty(a => a.Title, title)
                .SetProperty(a => a.Status, status)
                .SetProperty(a => a.Description, description));

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await context.Merchants
                .Where(m => m.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
