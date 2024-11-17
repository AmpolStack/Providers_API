using Providers_API.DAL.Definitions;
using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IUserService
    {
        public Task<User> createNewUser();
        public Task<bool> updateUser();
    }
}
