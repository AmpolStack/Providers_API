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

        public async Task<Provider> GetProvider(int UserId)
        {
            var response = await _repository.GetAll(x => x.UserId == UserId);
            return response.Include(x => x.User).First();
        }

        public async Task<Provider> GetProviderWithProperties(int Userid)
        {
            IQueryable<Provider> response = await _repository.GetAll(x => x.UserId == Userid);
            if(response == null)
            {
                return null;
            }
            return response.Include(x => x.Contacts).Include(x => x.Activities).Include(x => x.Actives).Include(x => x.User).ToList().First();
        }

        public async Task<Provider> GetProviderWithUserData(int userId)
        {
            IQueryable<Provider> response = await _repository.GetAll(x => x.UserId == userId);
            if (response == null)
            {
                return null;
            }
            return response.Include(x => x.User).First();
        }

        public async Task<IQueryable<Provider>> GetAllProvidersWithAllData()
        {
            IQueryable<Provider> response = await _repository.GetAll();
            if (response == null)
            {
                return null;
            }
            return response.Include(x => x.User).Include(x => x.Posts).Include(x => x.Actives).Include(x => x.Activities).Include(x => x.Contacts);
        }
        public async Task<Provider> GetProviderWithAllDataById(int idProvider)
        {
            IQueryable<Provider> response = await _repository.GetAll(x => x.ProviderId == idProvider);
            if (response == null)
            {
                return null;
            }
            return response.Include(x => x.User).Include(x => x.Posts).Include(x => x.Actives).Include(x => x.Activities).Include(x => x.Contacts).First();
        }

        public async Task<IQueryable<Provider>> GetAllProviders()
        {
            var response = await _repository.GetAll();
            return response.Include(x => x.User);
        }

        public async Task<bool> UpdateProvider(Provider provider)
        {
            var response = await _repository.Update(provider);
            return response;
        }
    }
}
