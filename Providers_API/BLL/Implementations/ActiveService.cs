using Microsoft.AspNetCore.Mvc;
using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;

namespace Providers_API.BLL.Implementations
{
    public class ActiveService : IActiveService
    {
        private readonly IGenericRepository<Active> _repository;
        public ActiveService(IGenericRepository<Active> repository)
        {
            _repository = repository;
        }
        public async Task<IQueryable<Active>> getAllActives()
        {
            var response = await _repository.GetAll();
            return response;
        }
    }
}
