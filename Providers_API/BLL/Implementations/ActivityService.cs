using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;

namespace Providers_API.BLL.Implementations
{
    public class ActivityService : IActivityService
    {
        private readonly IGenericRepository<Activity> _repository;
        public ActivityService(IGenericRepository<Activity> repository)
        {
            _repository = repository;
        }
        public async Task<IQueryable<Activity>> getAllActivitys()
        {
            return await _repository.GetAll();
        }
    }
}
