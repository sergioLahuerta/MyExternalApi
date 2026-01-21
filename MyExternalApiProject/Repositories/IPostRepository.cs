using MyExternalIntegrationApi.Models;

namespace MyExternalIntegrationApi.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetExternalPostsAsync();
        Task<Post?> GetExternalPostByIdAsync(int id);
        Task<bool> DeleteExternalPostAsync(int id);
    }
}