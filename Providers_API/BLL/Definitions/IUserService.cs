using Azure.Core.Pipeline;
using Providers_API.DAL.Definitions;
using Providers_API.Models;
using Providers_API.ViewModels;

namespace Providers_API.BLL.Definitions
{
    public interface IUserService
    {
        public Task<User> createNewUser(User user);
        public Task<bool> SaveProfile(User user);

        public Task<List<User>> getUsersList();

        public Task<User> getUserByCredentials(string mail, string password);

        public Task<User> getUserById(int id);

    }
}
