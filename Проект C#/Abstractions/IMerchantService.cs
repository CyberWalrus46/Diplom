using Core;

namespace Some_API.Abstractions
{
    public interface IMerchantService
    {
        Task<Guid> CreateMerchants(Merchant merchant);
        Task<Guid> DeleteMerchants(Guid id);
        Task<List<Merchant>> GetAllMerchants();
        Task<Guid> UpdateMerchants(Guid id, string title, string status, string description);
    }
}