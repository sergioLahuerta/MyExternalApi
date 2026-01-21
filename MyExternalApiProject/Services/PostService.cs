using MyExternalIntegrationApi.Models;
using MyExternalIntegrationApi.Repositories;

namespace MyExternalIntegrationApi.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetExternalPostsAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetExternalPostByIdAsync(id);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            return await _postRepository.DeleteExternalPostAsync(id);
        }
    }
}