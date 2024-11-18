using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IActivityService
    {
        public Task<IQueryable<Activity>> getAllActivitys();
    }
}
