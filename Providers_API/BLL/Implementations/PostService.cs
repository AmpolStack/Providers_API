using Providers_API.BLL.Definitions;
using Providers_API.DAL.Definitions;
using Providers_API.Models;

namespace Providers_API.BLL.Implementations
{
    public class PostService : IPostService
    {
        private readonly IGenericRepository<Post> _repository;
        public PostService(IGenericRepository<Post> repository)
        {
            _repository = repository;
        }
        public async Task<IQueryable<Post>> getAllPosts()
        {
            var response = await _repository.GetAll();
            return response;
        }
    }
}
