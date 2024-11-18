using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IProviderService
    {
        Task<Provider> creteNewProvider(Provider provider);

        Task<Provider> GetProvider(int UserId);

        Task<IQueryable<Provider>> GetAllProviders();
    }
}
