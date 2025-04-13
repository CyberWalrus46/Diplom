using Core;

namespace Some_API.Abstractions
{
    public interface IMerchantRepository
    {
        Task<Guid> Create(Merchant merchant);
        Task<Guid> Delete(Guid id);
        Task<List<Merchant>> Get();
        Task<Guid> Update(Guid id, string title, string status, string description);
    }
}