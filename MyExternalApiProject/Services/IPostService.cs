using MyExternalIntegrationApi.Models;

namespace MyExternalIntegrationApi.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post?> GetPostByIdAsync(int id);
        Task<bool> DeletePostAsync(int id);
    }
}