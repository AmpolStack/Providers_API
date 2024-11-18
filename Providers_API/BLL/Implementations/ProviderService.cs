using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;

namespace Providers_API.BLL.Implementations
{
    public class ProviderService : IProviderService
    {
        private readonly IGenericRepository<Provider> _repository;
        public ProviderService(IGenericRepository<Provider> repository)
        {
            _repository = repository;
        } 

        public async Task<Provider> creteNewProvider(Provider provider)
        {
            var response = await _repository.Create(provider);
            return response;

        }

        public async Task<IQueryable<Provider>> GetAllProviders()
        {
            return await _repository.GetAll();
        }

        public async Task<Provider> GetProvider(int Userid)
        {
            IQueryable<Provider> response = await _repository.GetAll(x => x.UserId == Userid);
            if(response == null)
            {
                return null;
            }
            return response.Include(x => x.Contacts).Include(x => x.Activities).Include(x => x.Actives).ToList().First();
        }
    }
}
