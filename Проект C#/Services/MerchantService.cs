using Core;
using Some_API.Abstractions;

namespace Some_API.Services
{
    public class MerchantService : IMerchantService
    {
        private readonly IMerchantRepository _merchantRepository;
        public MerchantService(IMerchantRepository merchantRepository)
        {
            _merchantRepository = merchantRepository;
        }

        public async Task<List<Merchant>> GetAllMerchants()
        {
            return await _merchantRepository.Get();
        }

        public async Task<Guid> CreateMerchants(Merchant merchant)
        {
            return await _merchantRepository.Create(merchant);
        }

        public async Task<Guid> UpdateMerchants(Guid id, string title, string status, string description)
        {
            return await _merchantRepository.Update(id, title, status, description);
        }

        public async Task<Guid> DeleteMerchants(Guid id)
        {
            return await _merchantRepository.Delete(id);
        }
    }
}
