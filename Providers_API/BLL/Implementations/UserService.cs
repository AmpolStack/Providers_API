using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;
using Providers_API.ViewModels;

namespace Providers_API.BLL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _repository;
        public UserService(IGenericRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> createNewUser(User user)
        {
            var coincidences = await _repository.Select(x => x.Email == user.Email);
            if(coincidences != null)
            {
                return null;
            }
            return await _repository.Create(user);
        }

        public async Task<User> getUserByCredentials(string mail, string password)
        {
            var coincidence = await _repository.Select(x => x.Email == mail && x.Password == password);
            if (coincidence == null)
            {
                return null;
            }
            return coincidence;

        }

        public async Task<User> getUserById(int id)
        {
            var coincidence = await _repository.Select(x => x.UserId == id);
            if (coincidence == null)
            {
                return null;
            }
            return coincidence;

        }

        public async Task<List<User>> getUsersList()
        {
            IQueryable<User> userList = await _repository.GetAll();
            return userList.ToList();
        }

        public async Task<bool> SaveProfile(User user)
        {
            return await _repository.Update(user);
        }
    }
}
