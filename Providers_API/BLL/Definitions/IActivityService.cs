using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IActivityService
    {
        Task<IQueryable<Activity>> getAllActivitys();
        
    }
}
