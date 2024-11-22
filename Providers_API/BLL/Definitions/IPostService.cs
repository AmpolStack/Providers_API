using Providers_API.Models;

namespace Providers_API.BLL.Definitions
{
    public interface IPostService
    {
        Task<IQueryable<Post>> getAllPosts();
    }
}
