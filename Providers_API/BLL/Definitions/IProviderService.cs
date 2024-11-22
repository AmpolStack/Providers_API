using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IProviderService
    {
        Task<Provider> creteNewProvider(Provider provider);

        Task<Provider> GetProvider(int UserId);

        Task<Provider> GetProviderWithProperties(int userId);

        Task<Provider> GetProviderWithUserData(int userId);

        Task<IQueryable<Provider>> GetAllProvidersWithAllData();

        Task<IQueryable<Provider>> GetAllProviders();

        Task<Provider> GetProviderWithAllDataById(int idProvider);
        Task<bool> UpdateProvider(Provider provider);
    }
}
