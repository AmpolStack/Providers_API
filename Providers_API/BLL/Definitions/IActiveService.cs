using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IActiveService
    {
        Task<IQueryable<Active>> getAllActives();
      
    }
}
